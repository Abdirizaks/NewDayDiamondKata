namespace NewDayDiamondKata;

public interface IPrinterCalculator
{
    int GetLetterIndex(char input);

    string GetLeadingSpaces(int letterIndex, int currentRow);

    string GetMiddleSpaces(int currentRow);

    char GetCurrentLetter(int currentRow);
}

public class PrinterCalculator : IPrinterCalculator
{
    public int GetLetterIndex(char input)
    {
        return input - 'A';
    }

    public string GetLeadingSpaces(int letterIndex, int currentRow)
    {
        return new string(' ', letterIndex - currentRow);
    }

    public string GetMiddleSpaces(int currentRow)
    {
        return new string(' ', 2 * currentRow - 1);
    }

    public char GetCurrentLetter(int currentRow)
    {
        return (char)('A' + currentRow);
    }
}