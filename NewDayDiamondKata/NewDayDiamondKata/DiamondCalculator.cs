namespace NewDayDiamondKata;

public interface IDiamondCalculator
{
    bool IsOdd(int n);
    int MiddleRow(int n);
    string RowCharacters(int n, int spaces);
    string RowSpacing(int n);

    string GetMiddleRowCharacters(string diamond);

}

public class DiamondCalculator : IDiamondCalculator
{
    public bool IsOdd(int n)
    {
        throw new NotImplementedException();
    }

    public int MiddleRow(int n)
    {
        throw new NotImplementedException();
    }

    public string RowCharacters(int n, int spaces)
    {
        throw new NotImplementedException();
    }

    public string RowSpacing(int n)
    {
        throw new NotImplementedException();
    }

    public string GetMiddleRowCharacters(string diamond)
    {
        throw new NotImplementedException();
    }
}