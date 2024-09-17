using FluentAssertions;
using Xunit;

namespace NewDayDiamondKata.UnitTest;

public class DiamondCreatorTests
{
    private readonly DiamondCreator _sut = new();

    [Fact]
    public void PrintForRowOneAndFive_ShouldReturnExpectedRow()
    {
        // Arrange
        char inputChar = 'X';
        string expectedRow = "  X";

        // Act
        string result = _sut.PrintForRowOneAndFive(inputChar);

        // Assert
        result.Should().Be(expectedRow);
    }

    [Fact]
    public void PrintForRowTwoAndFour_ShouldReturnExpectedRow()
    {
        // Arrange
        char inputChar = 'Y';
        string expectedRow = " Y Y";
        _sut.initialIndexCount = 4;
        _sut.numberOfSpaces = 2;
        _sut.eachRowIndexToSkip.Add(new KeyValuePair<int, int>(0, 2));

        // Act
        string result = _sut.PrintForRowTwoAndFour(inputChar);

        // Assert
        result.Should().Be(expectedRow);
    }

    [Fact]
    public void PrintForRowThree_ShouldReturnExpectedRow()
    {
        // Arrange
        char inputChar = 'Z';
        string expectedRow = "Z   Z";
        _sut.initialIndexCount = 5;
        _sut.numberOfSpaces = 0;
        _sut.eachRowIndexToSkip.Add(new KeyValuePair<int, int>(0, 2));
        _sut.eachRowIndexToSkip.Add(new KeyValuePair<int, int>(1, 1));
        _sut.eachRowIndexToSkip.Add(new KeyValuePair<int, int>(1, 3));

        // Act
        string result = _sut.PrintForRowThree(inputChar);

        // Assert
        result.Should().Be(expectedRow);
    }
}