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
                // Ex.
                var raisedToPowerOf = lengthOfNumberString - 1 - currentPosition;
                double currentMultiplier = Math.Pow(10, raisedToPowerOf);
                int currentValue = (int)(digit * currentMultiplier);

                if (currentValue != 0)
                {
                    inputSeparatedIntoNumbers.Add(currentValue);
                }
                currentPosition++;
            }

            return inputSeparatedIntoNumbers;
        }
    }
}