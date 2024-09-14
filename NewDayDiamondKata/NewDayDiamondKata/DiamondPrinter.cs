namespace NewDayDiamondKata;

public class DiamondPrinter(IDiamondCalculator _diamondCalculator)
{
    public string Character { get; set; } = string.Empty;
    public int NumberOfRows { get; set; }

    public string Diamond()
    {
        return "";
    }
}
