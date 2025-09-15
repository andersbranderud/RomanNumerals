using System;
using System.Collections;
using System.Collections.Generic;

namespace StringCalculator.Model
{
    public static class StringCalculatorUtility
    {
        public static int Add(string numbers)
        {
            // Validera inte null eller tom sträng.
            if (string.IsNullOrEmpty(numbers))
            {
                throw new ArgumentException("Input must be a valid string", nameof(numbers));
            }

            int totalSum = 0;
            var currentNumber = string.Empty;
            var nrOfRemainingDigits = numbers.Length;

            foreach (char currentChar in numbers)
            {
                var isDigit = Char.IsDigit(currentChar);

                if (isDigit)
                {
                    currentNumber += currentChar;
                }
                // Här har vi nått ett skiljetecken, vi har antingen lagt till ett nummer, eller så har vi det inte.
                // Om vi har lagt till nummer till currentNumber-variabeln, så lägger vi det till summan.
                // Om sista karaktärern är en siffra så behöver vi nrOfRemainingDigits == 1

                if (!isDigit || (isDigit && nrOfRemainingDigits == 1))
                {
                    if (!string.IsNullOrEmpty(currentNumber))
                    {                        
                        int currentNumberInt = Int32.Parse(currentNumber);
                        
                        if (currentNumberInt <= 1000)
                        {
                            totalSum += currentNumberInt;
                            Console.WriteLine("total sum is" + totalSum);
                        }
                    }
                    currentNumber = string.Empty;
                }
                nrOfRemainingDigits--;                
            }

            return totalSum;
        }
    }
}
