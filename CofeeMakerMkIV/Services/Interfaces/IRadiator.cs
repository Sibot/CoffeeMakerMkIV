using CofeeMakerMkIV.Models;

namespace CofeeMakerMkIV.Services.Interfaces
{
    public interface IRadiator
    {
        int MaxTemperature { get;}

        int OptimalTemperature { get; }

        Sensor Sensor { get; }

        SensorStatus Start();

        SensorStatus Stop();

        int Temperature { get; }

        RadiatorTemperatureScale TemperatureScale { get; set; }
    }
}
