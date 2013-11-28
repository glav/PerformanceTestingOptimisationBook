using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringOperationExample
{
    class Program
    {
        static void Main(string[] args)
        {
            const int NumberOfOperations = 10000;
            var worker = new MyStringManipulator();
            var watch = new System.Diagnostics.Stopwatch();
            int numChars = 0;

            watch.Start();
            //numChars = worker.UseRegularString(NumberOfOperations);
            numChars = worker.UseStringBuilder(NumberOfOperations);
            watch.Stop();
            Console.WriteLine("Your String Data totalled: {0} chars in length in {1} milliseconds.", numChars,watch.ElapsedMilliseconds);

            Console.WriteLine("Press ENTER key");
            Console.ReadLine();

        }
    }
}
