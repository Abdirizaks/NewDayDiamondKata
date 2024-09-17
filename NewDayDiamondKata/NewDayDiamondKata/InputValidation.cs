namespace NewDayDiamondKata;

public static class InputValidation
{
    public static (bool valid, char character) ValidateCharacterInput(string input)
    {
        if (string.IsNullOrEmpty(input) is false && input.Length == 1 && IsAlphabet(input))
        {
            char.TryParse(input, out char userChar);
            return (true, userChar);
        }

        Console.WriteLine("Invalid input. Please enter exactly one alphabet character.");
        return (false, ' ');
    }

    private static bool IsAlphabet(string input)
    {
        return char.IsLetter(input[0]);
    }
}