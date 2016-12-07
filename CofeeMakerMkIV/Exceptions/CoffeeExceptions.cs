using System;
using CofeeMakerMkIV.Internationalization;

namespace CofeeMakerMkIV.Exceptions
{
    public class CoffeeExceptions
    {
        public class CoffeeHighException : Exception
        {
            public CoffeeHighException(string message = Language.ErrorCoffeeHigh) : base(message)
            {
            }
        }

        public class CoffeeLowException : Exception
        {
            public CoffeeLowException(string message = Language.ErrorCoffeeLow) : base(message)
            {
            }
        }
    }
}
