using CofeeMakerMkIV.Models;
using System.Timers;

namespace CofeeMakerMkIV.Services.Interfaces
{
    public interface IWaterService : ISensor
    {
        Timer Trickle { get; set; }

        IRadiator Boiler { get; set; }

        int AmountWater { get; set; }

        int MaxAmountWater { get; }

        int MinAmountWater { get; }

        FilterService Filter { get; }

        CoffeeService Coffee { get; }

        PotService Pot { get; }

        SensorStatus Start(PotService pot);

        SensorStatus Stop();
    }
}