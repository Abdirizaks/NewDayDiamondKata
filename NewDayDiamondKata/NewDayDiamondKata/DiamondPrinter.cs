namespace NewDayDiamondKata;

public class DiamondPrinter(IPrinterCalculator printerCalculator)
{
    public void PrintDiamond(string? letter)
    {
        var validatedInput = InputValidation.ValidateCharacterInput(letter);
        if (validatedInput.valid is false)
        {
            return;
        }

        var letterIndex = printerCalculator.GetLetterIndex(validatedInput.character);

        for (int i = 0; i <= letterIndex; i++)
        {
            PrintRow(letterIndex, i);
        }

        for (int i = letterIndex - 1; i >= 0; i--)
        {
            PrintRow(letterIndex, i);
        }
    }

    private void PrintRow(int letterIndex, int currentRow)
    {
        var currentLetter = printerCalculator.GetCurrentLetter(currentRow);

        var leadingSpaces = printerCalculator.GetLeadingSpaces(letterIndex, currentRow);

        if (currentRow == 0)
        {
            Console.WriteLine(leadingSpaces + currentLetter);
        }
        else
        {
            var middleSpaces = printerCalculator.GetMiddleSpaces(currentRow);
            Console.WriteLine(leadingSpaces + currentLetter + middleSpaces + currentLetter);
        }
    }
}


