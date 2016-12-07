using CofeeMakerMkIV.Models;

namespace CofeeMakerMkIV.Services.Interfaces
{
    public interface ISensor
    {
        SensorStatus Status { get; }

        Sensor Sensor { get; }
    }
}