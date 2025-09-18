using System;
using System.Threading;
using StringCalculator.Model;

namespace StringCalculator.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to StringCalculator.");
            Console.WriteLine("Enter a string, e.g. {5,.,3,88}. The numbers will be added together (all numbers below 1000).");
            Console.WriteLine("Enter x to exit.");

            while (true)
            {
                Console.WriteLine("\nEnter numbers to add:");

                string input = Console.ReadLine();
                int result = StringCalculatorUtility.Add(input);

                if (input == "x")
                {
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine($"Result of the numbers: {result}");
                }
            }
        }
    }
}
