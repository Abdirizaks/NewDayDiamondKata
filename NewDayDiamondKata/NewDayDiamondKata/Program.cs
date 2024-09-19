using Microsoft.Extensions.DependencyInjection;

namespace NewDayDiamondKata;

static class Program
{
    private static void Main()
    {
        var serviceProvider = new ServiceCollection()
            .AddSingleton<IPrinterCalculator, PrinterCalculator>()
            .BuildServiceProvider();

        var diamondCalculator = serviceProvider.GetRequiredService<IPrinterCalculator>();

        var diamondService = new DiamondPrinter(diamondCalculator);
        Console.WriteLine("Enter a letter: ");
        var letter = Console.ReadLine();
        diamondService.PrintDiamond(letter);
        Console.WriteLine("\n\nEnd of program. Press any key to exit.");
        Console.ReadLine();
    }
}