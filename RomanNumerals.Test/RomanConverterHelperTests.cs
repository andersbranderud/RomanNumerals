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