using Microsoft.Extensions.DependencyInjection;

namespace NewDayDiamondKata;

class Program
{
    static void Main(string[] args)
    {
        var serviceProvider = new ServiceCollection()
            .AddSingleton<IDiamondCalculator, DiamondCalculator>()
            .BuildServiceProvider();
    }
}