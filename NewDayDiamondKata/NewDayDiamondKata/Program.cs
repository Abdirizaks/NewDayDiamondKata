using Microsoft.Extensions.DependencyInjection;

namespace NewDayDiamondKata;

static class Program
{
    private static void Main()
    {
        var serviceProvider = new ServiceCollection()
            .AddSingleton<ICharacterCalculator, CharacterCalculator>()
            .AddSingleton<IDiamondCreator, DiamondCreator>()
            .BuildServiceProvider();

        var diamondCalculator = serviceProvider.GetRequiredService<ICharacterCalculator>();
        var diamondPrinter = serviceProvider.GetRequiredService<IDiamondCreator>();
        var diamondService = new DiamondService(diamondCalculator, diamondPrinter);
        diamondService.Orchestrate();
        Console.WriteLine("\n\nEnd of program. Press any key to exit.");
        Console.ReadLine();
    }
}