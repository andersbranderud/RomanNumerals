using StringCalculator.Model;

public class StringCalculatorTests
{
    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public void Add_InvalidInput_ThrowsException(string input)
    {
        Assert.Throws<ArgumentException>(() => StringCalculatorUtility.Add(input));
    }

    [Theory]
    [InlineData("//;\n1;2", 3)]
    [InlineData("//;\n1;111", 112)]
    [InlineData("//;\n1;2;20000------", 3)]
    [InlineData("//;\n999;1001;20000------", 999)]
    [InlineData("//;\n1;2;3,4x5i6", 21)]
    public void Add_ValidInput_ThrowsException(string input, int expectedSum)
    {
        var actualSum = StringCalculatorUtility.Add(input);
        Assert.Equal(expectedSum, actualSum);
    }    
}
