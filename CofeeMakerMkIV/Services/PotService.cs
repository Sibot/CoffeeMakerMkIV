using CofeeMakerMkIV.Models;

namespace CofeeMakerMkIV.Services
{
    public class PotService
    {
        public int CupsOfCoffee { get; set; }

        public int MaxCupsOfCoffee { get; set; } = 12;

        public SensorStatus Status { get; }

        public PotService(bool hasPot)
        {
            if (hasPot)
            {
                this.Status = SensorStatus.On;
            }
        }
    }
}