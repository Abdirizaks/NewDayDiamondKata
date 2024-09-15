using FluentAssertions;
using Xunit;

namespace NewDayDiamondKata.UnitTest;

public class DiamondPrinterValidationTests
{
    [Theory]
    [InlineData("A", true, 'A')]
    [InlineData("b", true, 'b')]
    [InlineData("1", false, ' ')]
    [InlineData("", false, ' ')]
    [InlineData("AB", false, ' ')]
    public void ValidateCharacterInput_Should_Return_Correct_Results(string input, bool expectedValid, char expectedCharacter)
    {
        // Act
        var result = DiamondPrinterValidation.ValidateCharacterInput(input);

        // Assert
        result.valid.Should().Be(expectedValid);
        result.character.Should().Be(expectedCharacter);
    }

    [Theory]
    [InlineData("7", true, 7)]
    [InlineData("10", false, 0)]
    [InlineData("0", false, 0)]
    [InlineData("-5", false, 0)]
    [InlineData("abc", false, 0)]
    public void ValidateNumberOfRowsInput_Should_Return_Correct_Results(string input, bool expectedValid, int expectedNumberOfRows)
    {
        // Act
        var result = DiamondPrinterValidation.ValidateNumberOfRowsInput(input);

        // Assert
        result.valid.Should().Be(expectedValid);
        result.numberOfRows.Should().Be(expectedNumberOfRows);
    }
}