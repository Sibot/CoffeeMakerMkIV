using System;
using CofeeMakerMkIV.Models;
using CofeeMakerMkIV.Services.Interfaces;

namespace CofeeMakerMkIV.Services
{
    public class CoffeeMakerService
    {
        private readonly IRadiator Heater;

        private readonly WaterService Water;

        private readonly PotService Pot;

        public SensorStatus Status { get; private set; } = SensorStatus.Off;

        private Sensor Sensor => Sensor.CoffeeMaker;

        public CoffeeMakerService(IRadiator heater, WaterService water, PotService pot)
        {
            this.Heater = heater;
            this.Pot = pot;
            this.Water = water;
        }

        public SensorStatus Start()
        {
            try
            {
                var waterStatus = this.Water.Start(this.Pot);

                var potStatus = this.Pot.Status;

                if (potStatus == SensorStatus.On 
                    && waterStatus == SensorStatus.On)
                {
                    this.Status = SensorStatus.On;
                }
            }
            catch (Exception)
            {
                this.Status = SensorStatus.Malfunction;

                return this.Status;
            }

            return this.Status;
        }

        public SensorStatus Stop()
        {
            try
            {
                var boilerStatus = this.Water.Boiler.Stop();
                var heaterStatus = this.Heater.Stop();
            }
            finally
            {
                this.Status = SensorStatus.Off;
            }

            return this.Status;
        }
    }
}
