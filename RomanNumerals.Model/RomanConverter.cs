using System;
using System.Collections.Generic;
using System.Linq;

namespace RomanNumerals.Model
{
    public static class RomanConverter
    {
      
        public static decimal ConvertRomanToNumeric(string roman)
        {
            if (string.IsNullOrEmpty(roman))
            {
                throw new ArgumentException("Input cannot be null or empty", nameof(roman));
            }

            int total = 0;
            var currentIndexPosition = roman.Length - 1;
            var isRemaningLetters = currentIndexPosition >= 0;

            while (isRemaningLetters)
            {
                var currentChar = roman[currentIndexPosition];
                char? previousChar = currentIndexPosition - 1 >= 0 ? roman[currentIndexPosition - 1] : null;
                bool hasAppliedCalc = false;

                if (previousChar != null)
                {
                    var twoCharString = $"{previousChar}{currentChar}";

                    if (RomanConstants.RomanToDecimalMapTwoDigits.TryGetValue(twoCharString, out int twoDigitValue))
                    {
                        total += twoDigitValue;
                        currentIndexPosition -= 2;
                        hasAppliedCalc = true;
                    }
                }
                // 1 single digit.
                if (!hasAppliedCalc)
                {
                    if (RomanConstants.RomanToDecimalMapSingleDigits.TryGetValue(currentChar, out int singleDigitValue))
                    {
                        total += singleDigitValue;
                        currentIndexPosition--;
                    }
                    else
                    {
                        throw new ArgumentException($"Invalid roman character: {currentChar}");
                    }
                }
                

                isRemaningLetters = currentIndexPosition >= 0;
            }
            return total;
        }

        public static string ConvertNumericToRoman(string number)
        {
            if (string.IsNullOrEmpty(number) || !int.TryParse(number, out int numericValue))
            {
                throw new ArgumentException("Input must be a valid integer string", nameof(number));
            }
            if (numericValue <= 0 || numericValue > 3999)
            {
                throw new ArgumentOutOfRangeException(nameof(number), "Input must be between 1 and 3999");
            }

            var romanNumeral = string.Empty;

            var numbersDividedArray = DivideNumberIntoThousandsHundredsTensAndOnes(number);

            foreach (var num in numbersDividedArray)
            {
                if (RomanConstants.DecimalToRomanMap.TryGetValue(num, out string romanValue))
                {
                    romanNumeral += romanValue;
                }
            }

            return romanNumeral;
        }

        // This method divides the number into thousands, hundreds, tens and ones.
        // Example: 2021 -> [2000, 20, 1]
        private static List<int> DivideNumberIntoThousandsHundredsTensAndOnes(string numberString)
        {
            var lengthOfNumberString = numberString.Length;
            // Divide number into char array
            List<int> inputSeparatedIntoNumbers = new List<int>(numberString.Length);
            int currentPosition = 0;

            while (currentPosition < lengthOfNumberString)
            {
                var digit = int.Parse(numberString[currentPosition].ToString());
                // EXAMPLE number 2021 , we get 4 - 1 - 1 for 0 number
                // We get 4 - 1 - 2 for 20. 
                var raisedToPowerOf = lengthOfNumberString - 1 - currentPosition;
                double currentMultiplier = Math.Pow(10, raisedToPowerOf);
                int currentValue = (int)(digit * currentMultiplier);
                inputSeparatedIntoNumbers.Add(currentValue);
                currentPosition++;
            }

            return inputSeparatedIntoNumbers;
        }
    }
}
