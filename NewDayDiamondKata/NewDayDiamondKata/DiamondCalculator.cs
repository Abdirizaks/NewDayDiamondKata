namespace NewDayDiamondKata;

public interface IDiamondCalculator
{
    int MiddleRow(int n);
    int RowCharacters(int n, int spaces);
    int RowSpacing(int n, int i);
}

public class DiamondCalculator : IDiamondCalculator
{
    public int MiddleRow(int n)
    {
        return n / 2 + 1;
    }

    public int RowCharacters(int n, int spaces)
    {
        return n - spaces * 2;
    }

    public int RowSpacing(int n, int i)
    {
        return Math.Abs(n / 2 - i);
    }
}