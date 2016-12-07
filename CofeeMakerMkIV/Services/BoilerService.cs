using CofeeMakerMkIV.Exceptions;
using CofeeMakerMkIV.Models;
using CofeeMakerMkIV.Services.Interfaces;
using System.Timers;

namespace CofeeMakerMkIV.Services
{
    public class BoilerService : IRadiator
    {
        private Timer temperatureRise;

        public RadiatorTemperatureScale TemperatureScale { get; set; }

        public int MaxTemperature { get; private set; } = 200;

        public int OptimalTemperature { get; private set; } = 180;

        public SensorStatus Status { get; private set; }

        public Sensor Sensor => Sensor.Boiler;

        private int TemperatureInternal { get; set; }

        public int Temperature
        {
            get
            {
                if (TemperatureScale == RadiatorTemperatureScale.Fahrenheit)
                {
                    return this.TemperatureInternal * 9 / 5 + 32;
                }

                return this.TemperatureInternal;
            }
            private set
            {
                if (value < 0)
                {
                    this.TemperatureInternal = 0;
                }
            }
        }

        public SensorStatus Start()
        {
            if (this.Temperature > this.MaxTemperature)
            {
                throw new TemperatureExceptions.TemperatureHighException();
            }

            this.StartHeater();

            return this.Status;
        }

        private void StartHeater()
        {
            this.TemperatureRaise();
            this.Status = SensorStatus.On;
        }

        public SensorStatus Stop()
        {
            this.StopHeater();
            return SensorStatus.Off;
        }

        private void StopHeater()
        {
            this.Status = SensorStatus.Off;
        }

        public void TemperatureRaise()
        {
            temperatureRise = new Timer(50);

            temperatureRise.Elapsed += OnTemperatureRaise;

            temperatureRise.Start();
        }

        private void OnTemperatureRaise(object sender, ElapsedEventArgs e)
        {
            if (this.Status == SensorStatus.On)
            {
                this.Temperature++;
            }
            else
            {
                this.Temperature--;

                if (this.Temperature <= 0)
                {
                    temperatureRise.Stop();
                }
            }
        }
    }
}
