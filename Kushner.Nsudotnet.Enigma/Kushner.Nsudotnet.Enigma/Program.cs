﻿using System;
using System.IO;

namespace Kushner.Nsudotnet.Enigma
{
    class Program
    {
        public static void Main(string[] args)
        {
            Executor executor = new Executor();
            if (args.Length == 0) {
                Console.WriteLine("программа принимает параметры");
                Console.ReadKey();
                return;
            }
            try
            {
                executor.Execute(args);
            }
            catch (ArgumentException exp)
            {
                Console.WriteLine(exp.Message);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("не существеут переданного файла");
            }
            Console.ReadKey();
        }
    }
}
