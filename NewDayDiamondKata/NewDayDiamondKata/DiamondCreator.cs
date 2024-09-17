namespace NewDayDiamondKata;

public interface IDiamondCreator
{
    string PrintForRowOneAndFive(char c);
    string PrintForRowTwoAndFour(char c);
    string PrintForRowThree(char c);
}

public class DiamondCreator() : IDiamondCreator
{
    public int initialIndexCount = 3;
    public int numberOfSpaces = 0;
    public List<KeyValuePair<int, int>> eachRowIndexToSkip = new();

    public string PrintForRowOneAndFive(char c)
    {
        var rowOne = new char[initialIndexCount];

        for (var i = 0; i < initialIndexCount; i++)
        {
            rowOne[i] = ' ';
            if (i == initialIndexCount - 1)
            {
                eachRowIndexToSkip.Add(new KeyValuePair<int, int>(0, i));
                rowOne[i] = c;
                break;
            }
            numberOfSpaces++;
        }
        initialIndexCount++;
        return string.Join("", rowOne);
    }

    public string PrintForRowTwoAndFour(char c)
    {
        var rowTwo = new char[initialIndexCount];
        for (var i = 0; i < numberOfSpaces - 1; i++)
        {
            rowTwo[i] = ' ';
        }
        for (var i = 0; i < initialIndexCount; i++)
        {
            if (rowTwo[i] == ' ')
            {
                continue;
            }

            if (eachRowIndexToSkip.Any(x => x.Value == i))
            {
                rowTwo[i] = ' ';
                continue;
            }
            rowTwo[i] = c;
            eachRowIndexToSkip.Add(new KeyValuePair<int, int>(1, i));
        }
        initialIndexCount++;
        return string.Join("", rowTwo);
    }

    public string PrintForRowThree(char c)
    {
        var rowThree = new char[initialIndexCount];
        for (var i = 0; i < initialIndexCount; i++)
        {
            if (eachRowIndexToSkip.Any(x => x.Value == i))
            {
                rowThree[i] = ' ';
                continue;
            }

            rowThree[i] = c;
        }
        return string.Join("", rowThree);
    }
}
