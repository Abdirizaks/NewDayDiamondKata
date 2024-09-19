using FluentAssertions;
using NSubstitute;
using Xunit;

namespace NewDayDiamondKata.UnitTest;

public class DiamondPrinterTests
{
    private readonly IPrinterCalculator _printerCalculator;
    private readonly DiamondPrinter _sut;

    public DiamondPrinterTests()
    {
        _printerCalculator = Substitute.For<IPrinterCalculator>();
        _sut = new DiamondPrinter(_printerCalculator);
    }

    [Fact]
    public void PrintDiamond_WhenBIsPassed_ShouldMultipleCallsPrinterCalculatorAndReturnExpectedResult()
    {
        // Arrange
        var letterIndex = 1;
        var expectedResult = " A\nB B\n A".Replace("\r\n", "\n");

        _printerCalculator.GetLetterIndex('B').Returns(letterIndex);
        _printerCalculator.GetCurrentLetter(0).Returns('A');
        _printerCalculator.GetCurrentLetter(1).Returns('B');
        _printerCalculator.GetLeadingSpaces(letterIndex, 0).Returns(" ");
        _printerCalculator.GetLeadingSpaces(letterIndex, 1).Returns("");
        _printerCalculator.GetMiddleSpaces(1).Returns(" ");

        // Act
        var result = CaptureConsoleOutput(() => _sut.PrintDiamond("B")).Replace("\r\n", "\n"); ;

        // Assert
        _printerCalculator.Received(1).GetLetterIndex('B');
        _printerCalculator.Received(3).GetCurrentLetter(Arg.Any<int>());
        _printerCalculator.Received(3).GetLeadingSpaces(letterIndex, Arg.Any<int>());
        _printerCalculator.Received(1).GetMiddleSpaces(1);

        result.Should().Contain(expectedResult);
    }

    private string CaptureConsoleOutput(Action action)
    {
        var output = new StringWriter();
        Console.SetOut(output);
        action();
        return output.ToString();
    }
}