using System.Text;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace NewDayDiamondKata.UnitTest;

public class DiamondPrinterTests
{
    private readonly IDiamondCalculator _diamondCalculator;

    public DiamondPrinterTests()
    {
        _diamondCalculator = Substitute.For<IDiamondCalculator>();
    }

    [Fact]
    public void DiamondPrinter_WhenCalledWithValidCharacterAndNumberOfRows_ReturnsDiamond()
    {
        // Arrange
        int numberOfRows = 5;
        char character = 'X';

        _diamondCalculator.MiddleRow(numberOfRows).Returns(3);
        _diamondCalculator.RowSpacing(numberOfRows, 0).Returns(2);
        _diamondCalculator.RowCharacters(numberOfRows, 2).Returns(1);

        _diamondCalculator.RowSpacing(numberOfRows, 1).Returns(1);
        _diamondCalculator.RowCharacters(numberOfRows, 1).Returns(3);

        _diamondCalculator.RowSpacing(numberOfRows, 2).Returns(0);
        _diamondCalculator.RowCharacters(numberOfRows, 0).Returns(5);

        _diamondCalculator.RowSpacing(numberOfRows, 3).Returns(1);
        _diamondCalculator.RowCharacters(numberOfRows, 1).Returns(3);

        _diamondCalculator.RowSpacing(numberOfRows, 4).Returns(2);
        _diamondCalculator.RowCharacters(numberOfRows, 2).Returns(1);

        var sut = new DiamondPrinter(_diamondCalculator, character, numberOfRows);

        // Act
        var result = sut.PrintDiamond();

        // Expected output
        var expected = new StringBuilder()
            .Append(' ', 2).Append('\u25c8').Append('\n')  // Row 0
            .Append(' ', 1).Append('\u25c8').Append('\u25c8').Append('\u25c8').Append('\n')  // Row 1
            .Append(character, 5).Append('\n')  // Row 2 (Middle row)
            .Append(' ', 1).Append('\u25c8').Append('\u25c8').Append('\u25c8').Append('\n')  // Row 3
            .Append(' ', 2).Append('\u25c8').Append('\n')  // Row 4
            .ToString();

        // Assert
        result.Should().NotBeNullOrEmpty();
        result.Should().Contain("XXXXX");
        result.Should().Be(expected);
    }
}