using System;
using System.IO;


namespace Kushner.Nsudotnet.LinesCounter
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo dir1 = new DirectoryInfo(Directory.GetCurrentDirectory());
            Explorer explorer = new Explorer(dir1, args[0]);
            Counter counter = new Counter(explorer);
            Console.WriteLine(counter.DoCount());

            Console.ReadKey();
        }
    }
}
