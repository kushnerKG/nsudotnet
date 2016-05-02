using System;
using System.Diagnostics;
using System.IO;
using System.Threading;


namespace Kushner.Nsudotnet.LinesCounter
{
    class Program
    {
        static void Main(string[] args)
        {
            //Stopwatch s = new Stopwatch();
            DirectoryInfo dir1 = new DirectoryInfo(Directory.GetCurrentDirectory());
            Explorer explorer = new Explorer(dir1, args[0]);
            Counter counter = new Counter(explorer);
            //s.Start();
            Console.WriteLine(counter.DoCount());
            //s.Stop();
            //Console.WriteLine(s.ElapsedMilliseconds);
            Console.ReadKey();
        }
    }
}
