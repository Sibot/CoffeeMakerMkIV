using System;
using CofeeMakerMkIV.Models;
using CofeeMakerMkIV.Services.Interfaces;

namespace CofeeMakerMkIV.Services
{
    public class WaterService
    {
        private Timer Trickle;

        public IRadiator Boiler { get; set; }

        public int AmountWater { get; set; }

        public int MaxAmountWater { get; set; } = 12;

        public int MinAmountWater { get; private set; } = 1;

        public SensorStatus Status { get; private set; }

        public Sensor Sensor = Sensor.Water;

        public FilterService Filter { get; }

        public CoffeeService Coffee { get; }

        public PotService Pot { get; private set; }

        public WaterService(FilterService filter, CoffeeService coffee, IRadiator boiler, int amountWater)
        {
            this.Boiler = boiler;
            this.Filter = filter;
            this.Coffee = coffee;

            this.AmountWater = amountWater;
        }

        public SensorStatus Start(PotService pot)
        {
            if (this.AmountWater < this.MinAmountWater
                || this.AmountWater > this.MaxAmountWater 
                || this.AmountWater != this.Coffee.AmountCoffee)
            {
                this.Status = SensorStatus.Off;
                return this.Status;
            }
            
            if (Coffee.Status != SensorStatus.On)
            {
                this.Status = Coffee.Status;

                return this.Status;
            }

            this.Pot = pot;// ?? throw new ArgumentNullException(nameof(pot));

            try
            {
                var boilerStatus = this.Boiler.Start();

                if (boilerStatus == SensorStatus.On && this.Filter.HasFilter)
                {
                    this.StartTrickle();
                    this.Status = SensorStatus.On;
                }
            }
            catch (Exception)
            {
                this.Status = SensorStatus.Malfunction;
            }

            return this.Status;
        }

        private void StartTrickle()
        {
            this.Trickle = new Timer(1000);

            this.Trickle.Elapsed += OnTrickle;

            this.Trickle.Start();
        }

        private void OnTrickle(object sender, ElapsedEventArgs e)
        {
            if(this.Filter.HasFilter && this.AmountWater > 0 && this.Pot.Status == SensorStatus.On)
            {
                this.AmountWater--;
                this.Coffee.AmountCoffee--;

                this.Pot.CupsOfCoffee++;
            }
            else
            {
                this.Trickle.Stop();
            }

        }
    }
}
