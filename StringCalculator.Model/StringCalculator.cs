using System;
using System.Collections;
using System.Collections.Generic;

namespace StringCalculator.Model
{
    public static class StringCalculator
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

            foreach (var currentChar in numbers)
            {
                if (Char.IsDigit(currentChar))
                {
                    currentNumber += currentChar;
                }
                // Här har vi nått ett skiljetecken, vi har antingen lagt till ett nummer, eller så har vi det inte.
                // Om vi har lagt till nummer till currentNumber-variabeln, så lägger vi det till summan.
                else 
                {
                    if (!string.IsNullOrEmpty(currentNumber))
                    {
                        
                        int currentNumberInt = Int32.Parse(currentNumber);

                        if (currentNumberInt <= 1000)
                        {
                            totalSum += currentNumberInt;
                        }
                    }
                    currentNumber = string.Empty;
                }                
            }
            return totalSum;
        }
    }
}
