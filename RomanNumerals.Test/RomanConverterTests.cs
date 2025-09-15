using RomanNumerals.Model;

namespace RomanNumerals.Test;

public class RomanConverterTests
{
    [Theory]
    [InlineData("III", 3)]
    [InlineData("IV", 4)]
    [InlineData("IX", 9)]
    [InlineData("LVIII", 58)]
    [InlineData("MCMXCIV", 1994)]
    [InlineData("MMXXI", 2021)]
    public void ConvertRomanToDecimal_VariousInputs_VerifyConversion(string roman, int numericalExpected)
    {
        // Act
        var numericResult = RomanConverter.ConvertRomanToNumeric(roman);

        // Assert
        Assert.Equal(numericalExpected, numericResult);
    }

    [Theory]
    [InlineData("1", "I")]
    [InlineData("4", "IV")]
    [InlineData("2021", "MMXXI")]
    [InlineData("1990", "MCMXC")]
    [InlineData("3999", "MMMCMXCIX")]
    
    public void ConvertDecimalToRoman_VariousInputs_VerifyConversion(string number, string romanExpected)
    {
        // Act
        var romanResult = RomanConverter.ConvertNumericToRoman(number);

        // Assert
        Assert.Equal(romanExpected, romanResult);
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public void ConvertRomanToDecimal_InvalidInput_ThrowsArgumentException(string roman)
    {
        Assert.Throws<ArgumentException>(() => RomanConverter.ConvertRomanToNumeric(roman));
    }

    [Theory]
    [InlineData("")]
    [InlineData("abc")]
    [InlineData(null)]
    public void ConvertDecimalToRoman_InvalidInput_ThrowsArgumentException(string number)
    {
         // Act & Assert
         var exception = Assert.Throws<System.ArgumentException>(() => RomanConverter.ConvertNumericToRoman(number));
     }

    [Theory]
    [InlineData("4000")]
    [InlineData("0")]
    public void ConvertDecimalToRoman_InvalidInput_ThrowsArgumentOutOfRangeException(string number)
    {
         // Act & Assert
         var exception = Assert.Throws<System.ArgumentOutOfRangeException>(() => RomanConverter.ConvertNumericToRoman(number));
    }
}
