using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace NewDayDiamondKata;

static class Program
{
    private static void Main()
    {
        var serviceProvider = new ServiceCollection()
            .AddSingleton<IDiamondCalculator, DiamondCalculator>()
            .BuildServiceProvider();

        var diamondCalculatorService = serviceProvider.GetService<IDiamondCalculator>();

        Console.WriteLine("Enter the number of rows: ");
        var numberOfRows = Console.ReadLine();
        var isNumberOfRowsValid =
            DiamondPrinterValidation.ValidateNumberOfRowsInput(numberOfRows!);
        while (isNumberOfRowsValid.valid is false)
        {
            numberOfRows = Console.ReadLine();
            isNumberOfRowsValid =
                DiamondPrinterValidation.ValidateNumberOfRowsInput(numberOfRows!);
        }

        Console.WriteLine("Choose a character which will appear across the middle of the diamond: ");
        var character = Console.ReadLine();
        var isCharacterValid = DiamondPrinterValidation.ValidateCharacterInput(character!);
        while (isCharacterValid.valid is false)
        {
            character = Console.ReadLine();
            isCharacterValid = DiamondPrinterValidation.ValidateCharacterInput(character!);
        }

        DiamondPrinter diamondPrinter = new DiamondPrinter(diamondCalculatorService!, isCharacterValid.character, isNumberOfRowsValid.numberOfRows);
        var diamond = diamondPrinter.PrintDiamond();

        Console.OutputEncoding = Encoding.Unicode;
        Console.WriteLine(diamond);
        Console.ReadLine();
    }
}