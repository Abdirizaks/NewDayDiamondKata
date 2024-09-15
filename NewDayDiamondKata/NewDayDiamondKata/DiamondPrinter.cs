using System.Text;

namespace NewDayDiamondKata;

public class DiamondPrinter(IDiamondCalculator diamondCalculator, char character, int numberOfRows)
{
    public string PrintDiamond()
    {
        var middleRow = diamondCalculator.MiddleRow(numberOfRows);

        var diamond = new StringBuilder();

        for (int i = 0; i < numberOfRows; i++)
        {
            // Calculate the number of spaces for current index
            var spaces = diamondCalculator.RowSpacing(numberOfRows, i);

            // Calculate the number of characters for current index
            var characters = diamondCalculator.RowCharacters(numberOfRows, spaces);

            // Append the spaces to the diamond
            diamond.Append(' ', spaces);

            // If index equals to middle row, append the characters to the diamond
            if (i + 1 == middleRow)
            {
                diamond.Append(character, characters);
            }
            else
            {
                diamond.Append('\u25c8', characters);
            }

            // Append a new line to the diamond
            diamond.Append('\n');
        }
        return diamond.ToString();
    }
}
