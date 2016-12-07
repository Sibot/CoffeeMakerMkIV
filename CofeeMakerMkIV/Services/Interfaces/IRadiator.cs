using CofeeMakerMkIV.Models;

namespace CofeeMakerMkIV.Services.Interfaces
{
    public interface IRadiator : ISensor
    {
        int MaxTemperature { get;}

        int OptimalTemperature { get; }

        SensorStatus Start();

        SensorStatus Stop();

        int Temperature { get; }

        RadiatorTemperatureScale TemperatureScale { get; set; }
    }
}
