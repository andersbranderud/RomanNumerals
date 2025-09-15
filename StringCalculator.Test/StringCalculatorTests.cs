using StringCalculator.Model;

public class StringCalculatorTests
{
    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public void Add_InvalidInput_ThrowsException(string input)
    {
        Assert.Throws<ArgumentException>(StringCalculator.Add(input));
    }    

    [Theory]
    [InlineData("//;\n1;2", 3)]
    [InlineData("//;\n1;111", 114)]
    [InlineData("//;\n1;2;20000------", 3)]
    [InlineData("//;\n999;1001;20000------", 999)]
    public void Add_InvalidInput_ThrowsException(string input, int expectedSum)
    {
        var actualSum = StringCalculator.Add(input);
        Assert.Equal(expectedSum, actualSum);
    }    
}
