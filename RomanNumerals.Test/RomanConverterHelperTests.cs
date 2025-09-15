using Xunit;
using RomanNumerals.Model;

namespace RomanNumerals.Test
{
    public class RomanConverterHelperTests
    {
        [Fact]
        public void DivideNumberIntoThousandsHundredsTensAndOnes_ThousandsTensAndOnes_Verify()
        {
            List<int> resultList = RomanConverterHelper.DivideNumberIntoThousandsHundredsTensAndOnes("2021");
            List<int> expectedList = new List<int> { 2000, 20, 1 };
            AssertListIsExpected(resultList, expectedList);
        }

        [Fact]
        public void DivideNumberIntoThousandsHundredsTensAndOnes_ThousandsHundredsTensAndOnes_Verify()
        {
            List<int> resultList = RomanConverterHelper.DivideNumberIntoThousandsHundredsTensAndOnes("2321");
            List<int> expectedList = new List<int> { 2000, 300, 20, 1 };
            AssertListIsExpected(resultList, expectedList);
        }
        
        [Theory]
        [InlineData(2, 0, 4, 2000)] // thousands place in 4-digit number
        [InlineData(3, 1, 4, 300)]  // hundreds place in 4-digit number
        [InlineData(2, 2, 4, 20)]   // tens place in 4-digit number
        [InlineData(1, 3, 4, 1)]    // ones place in 4-digit number
        [InlineData(4, 0, 3, 400)]  // hundreds place in 3-digit number
        [InlineData(5, 1, 3, 50)]   // tens place in 3-digit number
        [InlineData(6, 2, 3, 6)]    // ones place in 3-digit number
        [InlineData(7, 0, 2, 70)]   // tens place in 2-digit number
        [InlineData(8, 1, 2, 8)]    // ones place in 2-digit number
        [InlineData(9, 0, 1, 9)]    // ones place in 1-digit number
        public void GetDigitValueAtPosition_VariousScenarios_VerifyResult(int digit, int currentPosition, int lengthOfNumberString, int expected)
        {
            int result = RomanConverterHelper.GetDigitValueAtPosition(digit, currentPosition, lengthOfNumberString);
            Assert.Equal(expected, result);
        }
        

        public void AssertListIsExpected(List<int> resultList, List<int> expectedList)
        {
            var index = 0;
            foreach (var result in resultList)
            {
                Assert.Equal(expectedList[index], result);
                index++;
            }
        }
        
    }
}