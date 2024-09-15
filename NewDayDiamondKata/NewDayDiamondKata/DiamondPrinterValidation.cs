namespace NewDayDiamondKata;

public static class DiamondPrinterValidation
{
    public static (bool valid, char character) ValidateCharacterInput(string input)
    {
        if (string.IsNullOrEmpty(input) is false && input.Length == 1 && IsAlphabet(input))
        {
            char.TryParse(input, out char userChar);
            Console.WriteLine($"Cool ! Your character {userChar} is displayed in the middle of the diamond print below \n");
            return (true, userChar);
        }

        Console.WriteLine("Invalid input. Please enter exactly one alphabet character. \n");
        return (false, ' ');
    }

    public static (bool valid, int numberOfRows) ValidateNumberOfRowsInput(string input)
    {
        if (int.TryParse(input, out int numberOfRows) && numberOfRows > 0 && IsOdd(numberOfRows))
        {
            Console.WriteLine($"Great ! You'll print a diamond with {numberOfRows} rows \n");
            return (true, numberOfRows);
        }

        Console.WriteLine("Invalid input. Please enter a positive odd integer. \n");
        return (false, 0);
    }

    private static bool IsOdd(int n)
    {
        return n % 2 != 0;
    }

    private static bool IsAlphabet(string input)
    {
        return char.IsLetter(input[0]);
    }
}