using FluentAssertions;
using Xunit;

namespace NewDayDiamondKata.UnitTest;

public class InputValidationTests
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
        var result = InputValidation.ValidateCharacterInput(input);

        // Assert
        result.valid.Should().Be(expectedValid);
        result.character.Should().Be(expectedCharacter);
    }
}