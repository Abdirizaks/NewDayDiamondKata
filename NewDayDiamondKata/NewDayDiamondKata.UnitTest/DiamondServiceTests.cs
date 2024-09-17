using FluentAssertions;
using NSubstitute;
using Xunit;

namespace NewDayDiamondKata.UnitTest;

public class DiamondServiceTests
{
    private readonly ICharacterCalculator _characterCalculator;
    private readonly IDiamondCreator _diamondCreator;
    private readonly DiamondService _diamondService;

    public DiamondServiceTests()
    {
        _characterCalculator = Substitute.For<ICharacterCalculator>();
        _diamondCreator = Substitute.For<IDiamondCreator>();
        _diamondService = new DiamondService(_characterCalculator, _diamondCreator);
    }

    [Fact]
    public void Orchestrate_ShouldPrintDiamond_WhenValidInputIsProvided()
    {
        // Arrange
        var inputChar = "C";
        var rowOneAndFiveChar = 'A';
        var rowTwoAndFourChar = 'B';
        var rowThreeChar = 'C';

        var resultValidation = InputValidation.ValidateCharacterInput(inputChar);

        _characterCalculator.DecrementTwoCharactersBack(resultValidation.character).Returns(rowOneAndFiveChar);
        _characterCalculator.IncrementCharacter(rowOneAndFiveChar).Returns(rowTwoAndFourChar);
        _characterCalculator.IncrementCharacter(rowTwoAndFourChar).Returns(rowThreeChar);

        _diamondCreator.PrintForRowOneAndFive(rowOneAndFiveChar).Returns("  A");
        _diamondCreator.PrintForRowTwoAndFour(rowTwoAndFourChar).Returns(" B B");
        _diamondCreator.PrintForRowThree(rowThreeChar).Returns("C   C");

        using (var consoleOutput = new StringWriter())
        {
            Console.SetOut(consoleOutput);

            // Act
            Console.SetIn(new StringReader(inputChar));
            _diamondService.Orchestrate();

            // Assert
            var output = consoleOutput.ToString().Replace("\r\n", "\n");

            var expectedString = "  A\n B B\nC   C\n B B\n  A\n";
            expectedString = expectedString.Replace("\r\n", "\n");
            output.Should().Be(expectedString);

            _diamondCreator.Received(1).PrintForRowOneAndFive(rowOneAndFiveChar);
            _diamondCreator.Received(1).PrintForRowTwoAndFour(rowTwoAndFourChar);
            _diamondCreator.Received(1).PrintForRowThree(rowThreeChar);
        }
    }
}