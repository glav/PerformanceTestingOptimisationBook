using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Reflection
{
    class Program
    {
        static void Main(string[] args)
        {
            const int iterations = 10000;

            Dictionary<SongType, string> songTypeDescriptions = new Dictionary<SongType, string>();
            songTypeDescriptions.Add(SongType.Classical, "Classical and Opera");
            songTypeDescriptions.Add(SongType.HeavyMetal, "Heavy Metal");
            songTypeDescriptions.Add(SongType.Pop, "Pop, Teeny Bopper");
            songTypeDescriptions.Add(SongType.Rap, "Rap and Hip Hop");
            songTypeDescriptions.Add(SongType.Rock, "Contemporary Rock");

            Dictionary<string, SongType> songs = new Dictionary<string, SongType>();
            songs.Add("Lots of heavy guitar", SongType.HeavyMetal);
            songs.Add("Oh Baby", SongType.Pop);
            songs.Add("Baby Baby", SongType.Pop);
            songs.Add("Oooh baby oooh", SongType.Pop);
            songs.Add("Shake till it falls off", SongType.Rap);

            var timer1 = Stopwatch.StartNew();
            for (int cnt = 0; cnt < iterations; cnt++)
            {
                foreach (var item in songs)
                {
                    var songType = GetDescriptiveTitle(item.Value);
                    //Console.WriteLine("{0} - {1}", item.Key, songType);
                }
            }
            timer1.Stop();
            var timer1Time = timer1.ElapsedMilliseconds;

            var timer2 = Stopwatch.StartNew();
            for (int cnt = 0; cnt < iterations; cnt++)
            {
                foreach (var item in songs)
                {
                    var songType = songTypeDescriptions[item.Value];
                    //Console.WriteLine("{0} - {1}", item.Key, songType);
                }
            }
            timer1.Stop();
            var timer2Time = timer1.ElapsedMilliseconds;

            Console.WriteLine("\n\nUsing Reflection took: {0} milliseconds", timer1.ElapsedMilliseconds);
            Console.WriteLine("Not using reflection took: {0} milliseconds", timer2.ElapsedMilliseconds);
        }

        private static string GetDescriptiveTitle(SongType enumItem)
        {
            var typeOfEnum = enumItem.GetType();
            var field = typeOfEnum.GetField(enumItem.ToString());
            var attribList = field.GetCustomAttributes(true);
            if (attribList.Length > 0)
            {
                var attrib = (DescriptiveTitleAttribute)attribList[0];
                return attrib.DisplayTitle;
            }
            return string.Empty;
        }
    }


}
