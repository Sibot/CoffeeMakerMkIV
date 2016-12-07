using CofeeMakerMkIV.Services;

namespace CofeeMakerMkIV.Tests.Services
{
    public class CoffeeMakerServiceHelpers
    {
        public static CoffeeMakerService CreateCoffeeMakerService(int water, int coffee, bool filter, bool potInserted)
        {
            var boilerService = new BoilerService();

            var coffeeService = new CoffeeService(coffee);

            var filterService = new FilterService(filter);

            var heaterService = new HeaterService();

            var potService = new PotService(potInserted);

            var waterService = new WaterService(filterService, coffeeService, boilerService, water);

            var coffeeMakerService = new CoffeeMakerService(heaterService, waterService, potService);

            return coffeeMakerService;
        }
    }
}
