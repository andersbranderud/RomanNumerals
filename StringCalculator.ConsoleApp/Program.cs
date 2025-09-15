using System;
using StringCalculator.Model;


namespace StringCalculator.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter numbers to add (comma separated):");
            string input = Console.ReadLine();
            int result = StringCalculatorUtility.Add(input);
            Console.WriteLine($"Result: {result}");
        }
    }
}
