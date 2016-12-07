using CofeeMakerMkIV.Exceptions;
using CofeeMakerMkIV.Models;
using CofeeMakerMkIV.Services.Interfaces;
using System.Timers;

namespace CofeeMakerMkIV.Services
{
    public class HeaterService : IRadiator
    {
        private Timer temperatureRise;

        public RadiatorTemperatureScale TemperatureScale { get; set; }

        public int MaxTemperature { get; private set; } = 99;

        public int OptimalTemperature { get; set; } = 96;

        public SensorStatus Status { get; private set; }

        public Sensor Sensor => Sensor.Heater;

        private int TemperatureInternal { get; set; }

        public int Temperature
        {
            get
            {
                if (this.TemperatureScale == RadiatorTemperatureScale.Fahrenheit)
                {
                    return this.TemperatureInternal * 9/5 + 32;
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


            return Status;
        }

        private SensorStatus StartHeater()
        {
            Status = SensorStatus.On;
            return Status;
        }

        public SensorStatus Stop()
        {
            Status = StopHeater();

            return Status;
        }

        private SensorStatus StopHeater()
        {
            Status = SensorStatus.Off;

            return Status;
        }

        public void TemperatureRaise()
        {
            temperatureRise = new Timer(1000);

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
