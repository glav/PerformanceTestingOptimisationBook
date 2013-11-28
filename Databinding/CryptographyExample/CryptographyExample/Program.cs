using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Diagnostics;

namespace CryptographyExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var dataToEncrypt = new string('x', 4096);
            var encryptBuffer = System.Text.ASCIIEncoding.ASCII.GetBytes(dataToEncrypt);

            var algorithm = TripleDES.Create();
            
            var crypto = algorithm.CreateEncryptor();
            algorithm.KeySize = algorithm.LegalKeySizes.First().MinSize;
            algorithm.GenerateIV();
            algorithm.GenerateKey();

            Console.WriteLine("Press ENTER to start Encryption loop");
            Console.ReadLine();

            Stopwatch timer = Stopwatch.StartNew();

            for (int cnt = 0; cnt < 10000; cnt++)
            {
                EncryptData(encryptBuffer, crypto);
            }

            timer.Stop();

            Console.WriteLine("Encryption complete. Time Taken: {0} milliseconds", timer.ElapsedMilliseconds);
            Console.ReadLine();
        }

        private static void EncryptData(byte[] encryptBuffer, ICryptoTransform crypto)
        {
            // Create the file stream.
            var writeStream = new MemoryStream();

            // Init the encryption stuff
            var cryptStream = new CryptoStream(writeStream, crypto, CryptoStreamMode.Write);

            // Get our data as bytes
            cryptStream.Write(encryptBuffer, 0, encryptBuffer.Length);
            cryptStream.Close();
            writeStream.Close();
        }
    }
}
