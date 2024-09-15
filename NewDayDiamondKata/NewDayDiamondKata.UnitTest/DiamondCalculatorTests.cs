using FluentAssertions;
using Xunit;

namespace NewDayDiamondKata.UnitTest;

public class DiamondCalculatorTests
{
    private readonly DiamondCalculator _sut;

    public DiamondCalculatorTests()
    {
        _sut = new DiamondCalculator();
    }

    [Fact]
    public void MiddleRow_Should_Return_Correct_Value()
    {
        // Arrange
        int n = 5;
        int expectedMiddleRow = 3;

        // Act
        int result = _sut.MiddleRow(n);

        // Assert
        result.Should().Be(expectedMiddleRow);
    }

    [Fact]
    public void RowCharacters_Should_Return_Correct_Value()
    {
        // Arrange
        int n = 5;
        int spaces = 1;
        int expectedRowCharacters = 3;

        // Act
        int result = _sut.RowCharacters(n, spaces);

        // Assert
        result.Should().Be(expectedRowCharacters);
    }

    [Fact]
    public void RowSpacing_Should_Return_Correct_Value()
    {
        // Arrange
        int n = 8;
        int i = 2;
        int expectedRowSpacing = 2;

        // Act
        int result = _sut.RowSpacing(n, i);

        // Assert
        result.Should().Be(expectedRowSpacing);
    }
}