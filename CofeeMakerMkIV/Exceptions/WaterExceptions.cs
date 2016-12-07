using System;
using CofeeMakerMkIV.Internationalization;

namespace CofeeMakerMkIV.Exceptions
{
    public class WaterExceptions
    {
        public class WaterHighException : Exception
        {
            public WaterHighException(string message = Language.ErrorWaterHigh) : base(message)
            {
            }
        }

        public class WaterLowException : Exception
        {
            public WaterLowException(string message = Language.ErrorWaterLow) : base(message)
            {
            }
        }

        public class WaterMissingException : Exception
        {
            public WaterMissingException(string message = Language.ErrorWaterMissing) : base(message)
            {
            }
        }
    }
}
