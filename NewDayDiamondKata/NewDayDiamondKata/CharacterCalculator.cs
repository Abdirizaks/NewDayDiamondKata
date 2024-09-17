namespace NewDayDiamondKata;

public interface ICharacterCalculator
{
    char IncrementCharacter(char input);
    char DecrementTwoCharactersBack(char input);
}

public class CharacterCalculator : ICharacterCalculator
{
    public char IncrementCharacter(char input)
    {
        if (input < 'Z' && input >= 'A')
            return char.Parse(((char)(input + 1)).ToString());

        return ' ';
    }

    public char DecrementTwoCharactersBack(char input)
    {
        if (input <= 'Z' && input >= 'C')
        {
            return char.Parse(((char)(input - 2)).ToString());
        }

        Console.WriteLine("Invalid input. Please enter any character which comes after B");
        return ' ';
    }
}