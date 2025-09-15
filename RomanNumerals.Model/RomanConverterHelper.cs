using System.Collections.Generic;
using System;

namespace RomanNumerals.Model
{
    public static class RomanConverterHelper
    {
        // This method divides the number into thousands, hundreds, tens and ones.
        // Example: 2021 -> [2000, 20, 1]
        public static List<int> DivideNumberIntoThousandsHundredsTensAndOnes(string numberString)
        {
            var lengthOfNumberString = numberString.Length;
            // Divide number into char array
            List<int> inputSeparatedIntoNumbers = new List<int>(numberString.Length);
            int currentPosition = 0;

            while (currentPosition < lengthOfNumberString)
            {
                var digit = int.Parse(numberString[currentPosition].ToString());
                int currentValue = GetDigitValueAtPosition(digit, currentPosition, lengthOfNumberString);

                if (currentValue != 0)
                {
                    inputSeparatedIntoNumbers.Add(currentValue);
                }
                currentPosition++;
            }

            return inputSeparatedIntoNumbers;
        }
        
        /// An example. Original number is 2173. We pass in digit: 2; currentPosition: 0, length: 4
        /// Calculation: 2 * 10 ^ (4 -1 - 0) = 2000.
        /// For digit: 3; currentPosition 1; length: 4 => 3 * 10 ^ (4 - 2 - 0) = 300  
        public static int GetDigitValueAtPosition(int digit, int currentPosition, int length)
        {
            var raisedToPowerOf = lengthOfNumberString - 1 - currentPosition;
            double currentMultiplier = Math.Pow(10, raisedToPowerOf);
            int currentValue = (int)(digit * currentMultiplier);
            return currentValue;
        }
    }
}