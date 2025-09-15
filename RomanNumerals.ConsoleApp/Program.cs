using System;
using RomanNumerals.Model;

namespace RomanNumerals.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //listen to user input .. call method 1 or 2 depdning on input. Option for x

            while (true)
            {
                Console.WriteLine("Enter a number.");
                Console.WriteLine("1: Convert number to Roman Numerals");
                Console.WriteLine("2: Convert Roman Numerals to number");
                Console.WriteLine("x: Exit");

                var input = Console.ReadLine();
                            
                switch (input)
                {

                    case "1":
                        Console.WriteLine("Enter a number between 1 and 3999 to convert to Roman Numerals:");
                        var numberInput = Console.ReadLine();
                        if (int.TryParse(numberInput, out int number) && number >= 1 && number <= 3999)
                        {
                            var roman = RomanConverter.ConvertNumericToRoman(number);
                            Console.WriteLine($"Roman Numeral: {roman}");
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please enter a valid number between 1 and 3999.");
                        }
                        break;

                    case "2":
                        Console.WriteLine("Enter a Roman Numeral to convert to a number:");
                        var romanInput = Console.ReadLine();
                        try
                        {
                            var numeric = RomanConverter.ConvertRomanToNumeric(romanInput);
                            Console.WriteLine($"Numeric Value: {numeric}");
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case "x":
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Invalid option. Please enter '1' to convert number to Roman Numerals, '2' to convert Roman Numerals to number, or 'x' to exit.");
                        break;
                }
            }
        }
    }
}
