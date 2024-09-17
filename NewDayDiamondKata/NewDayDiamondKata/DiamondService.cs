namespace NewDayDiamondKata;

public class DiamondService(ICharacterCalculator characterCalculator, IDiamondCreator diamondCreator)
{
    public void Orchestrate()
    {
        var character = Console.ReadLine();

        var validationResult = InputValidation.ValidateCharacterInput(character);

        if (validationResult.valid is false)
        {
            Console.WriteLine("Re-run application.");
            return;
        }

        var rowOneAndFiveCharacter = characterCalculator.DecrementTwoCharactersBack(validationResult.character);

        if (rowOneAndFiveCharacter == ' ')
        {
            Console.WriteLine("Re-run application and enter a different character.");
            return;
        }

        var rowTwoAndFourCharacter = characterCalculator.IncrementCharacter(rowOneAndFiveCharacter);
        var rowThreeCharacter = characterCalculator.IncrementCharacter(rowTwoAndFourCharacter);

        var rowOneAndFive = diamondCreator.PrintForRowOneAndFive(rowOneAndFiveCharacter);
        var rowTwoAndFour = diamondCreator.PrintForRowTwoAndFour(rowTwoAndFourCharacter);
        var rowThree = diamondCreator.PrintForRowThree(rowThreeCharacter);

        PrintDiamond(rowOneAndFive, rowTwoAndFour, rowThree);
    }

    private void PrintDiamond(string rowOneAndFive, string rowTwoAndFour, string rowThree)
    {
        Console.WriteLine(rowOneAndFive);
        Console.WriteLine(rowTwoAndFour);
        Console.WriteLine(rowThree);
        Console.WriteLine(rowTwoAndFour);
        Console.WriteLine(rowOneAndFive);
    }
}