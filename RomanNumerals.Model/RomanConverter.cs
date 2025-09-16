using System;

namespace RomanNumerals.Model
{
    public static class RomanConverter
    {      
        /// Konverteras romerska bokstäver till heltal.
        /// Exempel, input: XX; output: 20
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

                // Om det finns ytterligare ett tecken.
                if (previousChar != null)
                {
                    var twoCharString = $"{previousChar}{currentChar}";

                    // Checka först om det matchar en tvåsiffrig romersk kombination.
                    if (RomanConstants.RomanToDecimalMapTwoDigits.TryGetValue(twoCharString, out int twoDigitValue))
                    {
                        total += twoDigitValue;
                        currentIndexPosition -= 2;
                        hasAppliedCalc = true;
                    }
                }
                //Om det är sista tecknet i loopen, eller om ingen match för tvåsiffrig kombination.
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

        /// Konverterar heltal till romerska bokstäver.
        /// Exempel input: 20; output: XX
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

            var numbersDividedArray = RomanConverterHelper.DivideNumberIntoThousandsHundredsTensAndOnes(number);

            foreach (var currentNumber in numbersDividedArray)
            {
                if (RomanConstants.DecimalToRomanMap.TryGetValue(currentNumber, out string romanValue))
                {
                    romanNumeral += romanValue;
                }
            }

            return romanNumeral;
        }
    }
}
