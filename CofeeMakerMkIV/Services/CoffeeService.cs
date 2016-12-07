using CofeeMakerMkIV.Models;

namespace CofeeMakerMkIV.Services
{
    public class CoffeeService
    {
        public int AmountCoffee { get; set; }

        public int MaxAmountCoffee { get; set; } = 12;

        public int MinAmountCoffee { get; set; } = 1;

        public Sensor Sensor = Sensor.Coffee;

        public SensorStatus Status { get; }

        public CoffeeService(int amountCoffee)
        {
            this.Status = SensorStatus.Off;

            if (!(AmountCoffee > MinAmountCoffee) || !(AmountCoffee < MaxAmountCoffee))
            {
                //throw new CoffeeExceptions.CoffeeLowException();
                this.Status = SensorStatus.On;
            }

            this.AmountCoffee = amountCoffee;
        }
    }
}
