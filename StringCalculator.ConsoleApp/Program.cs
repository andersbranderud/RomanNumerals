using System;
using StringCalculator.Model;

namespace StringCalculator.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to StringCalculator.");
            Console.WriteLine("Enter x to exit.");

            while (true)
            {
                Console.WriteLine("Enter numbers to add (comma separated):");

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
