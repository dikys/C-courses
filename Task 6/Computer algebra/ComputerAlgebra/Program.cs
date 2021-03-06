﻿using System;
using System.Linq.Expressions;

namespace ComputerAlgebra
{
    class Program
    {
        static void Main(string[] args)
        {
            Expression<Func<double, double>> f = x => x*x*x;
            Console.WriteLine(f.ToString());

            Expression<Func<double, double>> df = f.Differentiate();
            Console.WriteLine(df);

            Console.Read();
        }
    }
}
