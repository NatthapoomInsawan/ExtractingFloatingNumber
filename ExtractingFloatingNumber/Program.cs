﻿using System.Numerics;
using System.Runtime.CompilerServices;
using System.Threading.Channels;

namespace MyApp
{
    
    internal class Program
    {
        static void Main(string[] args)
        {
            int dividend;
            int divisor;
            int precision;

            Console.WriteLine("This program return the value of Nth precision of x/y.");

            Console.WriteLine("Please enter your dividend");
            Int32.TryParse(Console.ReadLine(), out dividend);

            Console.WriteLine("Please enter your divisor (cannot be zero)");
            Int32.TryParse(Console.ReadLine(), out divisor);

            Console.WriteLine("Please enter your target floating number precision");
            Int32.TryParse(Console.ReadLine(), out precision);

            var result = FindNthPrecision(dividend, divisor, precision);
            Console.WriteLine($"Result: {result}");
            Console.ReadLine();
        }

        static int FindNthPrecision(int _dividend, int _divisor, int _precision)
        {
            int result = 0;

            Math.DivRem(_dividend, _divisor, out var remainder);

            if (remainder == 0)
                result = 0;
            else
            {
                for (int i = 0; i < _precision; i++)
                {
                    if (remainder > _divisor)
                        result = Math.DivRem(remainder, _divisor, out remainder);
                    else
                        result = Math.DivRem(remainder * 10, _divisor, out remainder);
                }
            }

            return result;
        }
    }
}