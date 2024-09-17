using FluentAssertions;
using Xunit;

namespace NewDayDiamondKata.UnitTest;

public class CharacterCalculatorTests
{
    private readonly CharacterCalculator _sut = new();

    [Theory]
    [InlineData('A', 'B')]
    [InlineData('B', 'C')]
    [InlineData('Y', 'Z')]
    [InlineData('Z', ' ')]
    public void IncrementCharacter_GivenInput_ShouldReturnExpectedResult(char input, char expected)
    {
        // Act
        char result = _sut.IncrementCharacter(input);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData('C', 'A')]
    [InlineData('D', 'B')]
    [InlineData('Z', 'X')]
    [InlineData('B', ' ')]
    public void DecrementTwoCharactersBack_GivenInput_ShouldReturnExpectedResult(char input, char expected)
    {
        // Act
        char result = _sut.DecrementTwoCharactersBack(input);

        // Assert
        result.Should().Be(expected);
    }
}