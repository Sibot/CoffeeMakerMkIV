using System;
using CofeeMakerMkIV.Internationalization;

namespace CofeeMakerMkIV.Exceptions
{
    public class TemperatureExceptions
    {
        public class TemperatureHighException: Exception
        {
            public TemperatureHighException(string message = Language.ErrorTemperatureHigh) : base(message)
            {
            }
        }

        public class TemperatureLowException : Exception
        {
            public TemperatureLowException(string message = Language.ErrorTemperatureLow) : base(message)
            {
            }
        }
    }
}
