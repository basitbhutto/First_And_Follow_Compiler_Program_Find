﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            char[,] arr = new char[3,3];



            foreach (var item in arr)
            {
                Console.WriteLine(arr);
                Console.ReadLine();
            }
        }
    }
}