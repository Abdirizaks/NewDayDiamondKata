using FluentAssertions;
using Xunit;

namespace NewDayDiamondKata.UnitTest;

public class PrinterCalculatorTests
{
    private readonly PrinterCalculator _sut;

    public PrinterCalculatorTests()
    {
        _sut = new();
    }

    [Theory]
    [InlineData('A', 0)]
    [InlineData('B', 1)]
    [InlineData('C', 2)]
    [InlineData('Z', 25)]
    public void GetLetterIndex_ReturnsCorrectIndex(char input, int expected)
    {
        // Act
        var result = _sut.GetLetterIndex(input);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(2, 0, "  ")]
    [InlineData(5, 3, "  ")]
    [InlineData(5, 4, " ")]
    [InlineData(3, 3, "")]
    public void GetLeadingSpaces_ReturnsCorrectSpaces(int letterIndex, int currentRow, string expected)
    {
        // Act
        var result = _sut.GetLeadingSpaces(letterIndex, currentRow);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(1, " ")]
    [InlineData(2, "   ")]
    [InlineData(3, "     ")]
    public void GetMiddleSpaces_ReturnsCorrectSpaces(int currentRow, string expected)
    {
        // Act
        var result = _sut.GetMiddleSpaces(currentRow);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(0, 'A')]
    [InlineData(1, 'B')]
    [InlineData(2, 'C')]
    [InlineData(25, 'Z')]
    public void GetCurrentLetter_ReturnsCorrectLetter(int currentRow, char expected)
    {
        // Act
        var result = _sut.GetCurrentLetter(currentRow);

        // Assert
        result.Should().Be(expected);
    }
}