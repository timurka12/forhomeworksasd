using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ConsoleApp24
{
    class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();
            HashSet<string> Hash = new HashSet<string>();
            while (Hash.Count < 10_000)
            {
                string value = default;
                for (int j = 0; j < r.Next(5, 10); j++) value += ((char)r.Next('a', 'z')).ToString();
                Hash.Add(value);
            }
            Stopwatch stop = Stopwatch.StartNew();
            foreach (var item in Hash)
            {
                if (item.Equals("балдееееж"))
                {
                    break;
                }
            }
            stop.Stop();
            TimeSpan ts = stop.Elapsed;
            string time = $"{ts.Hours}:{ts.Minutes}:{ts.Seconds}:{ts.Milliseconds / 10}";
            Console.WriteLine("RunTime " + time);
        }
    }
}
