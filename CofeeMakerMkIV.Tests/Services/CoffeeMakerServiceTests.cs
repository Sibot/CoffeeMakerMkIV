using CofeeMakerMkIV.Models;
using CofeeMakerMkIV.Tests.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CofeeMakerMkIV.Tests.Controllers
{
    [TestClass]
    public class CoffeeMakerServiceTests
    {
        [TestMethod]
        public void CoffeeMakerService_StartWithOptimalConditions_StatusOn()
        {
            // Arrange
            var filter = true;
            var water = 12;
            var coffee = 12;
            var hasPot = true;
            var coffeeMakerService = CoffeeMakerServiceHelpers.CreateCoffeeMakerService(water, coffee, filter, hasPot);

            // Act
            coffeeMakerService.Start();

            // Assert
            Assert.AreEqual(coffeeMakerService.Status, SensorStatus.On);
        }

        [TestMethod]
        public void CoffeeMakerService_StartWithTooLittleWater_StatusOff()
        {
            // Arrange
            var filter = true;
            var water = 0;
            var coffee = 12;
            var hasPot = true;
            var coffeeMakerService = CoffeeMakerServiceHelpers.CreateCoffeeMakerService(water, coffee, filter, hasPot);

            // Act
            coffeeMakerService.Start();

            // Assert
            Assert.AreEqual(coffeeMakerService.Status, SensorStatus.Off);
        }

        [TestMethod]
        public void CoffeeMakerService_StartWithNoPot_StatusOff()
        {
            // Arrange
            var filter = true;
            var water = 6;
            var coffee = 12;
            var hasPot = false;
            var coffeeMakerService = CoffeeMakerServiceHelpers.CreateCoffeeMakerService(water, coffee, filter, hasPot);

            // Act
            coffeeMakerService.Start();

            // Assert
            Assert.AreEqual(coffeeMakerService.Status, SensorStatus.Off);
        }

        [TestMethod]
        public void CoffeeMakerService_StartWithNoFilter_StatusOff()
        {
            // Arrange
            var filter = false;
            var water = 12;
            var coffee = 12;
            var hasPot = true;
            var coffeeMakerService = CoffeeMakerServiceHelpers.CreateCoffeeMakerService(water, coffee, filter, hasPot);

            // Act
            coffeeMakerService.Start();

            // Assert
            Assert.AreEqual(coffeeMakerService.Status, SensorStatus.Off);
        }

        [TestMethod]
        public void CoffeeMakerService_StartWithTooLittleCoffee_StatusOff()
        {
            // Arrange
            var filter = false;
            var water = 12;
            var coffee = 0;
            var hasPot = true;
            var coffeeMakerService = CoffeeMakerServiceHelpers.CreateCoffeeMakerService(water, coffee, filter, hasPot);

            // Act
            coffeeMakerService.Start();

            // Assert
            Assert.AreEqual(coffeeMakerService.Status, SensorStatus.Off);
        }

        [TestMethod]
        public void CoffeeMakerService_StartWithWrongCoffeeWaterRatio_StatusOff()
        {
            // Arrange
            var filter = true;
            var water = 12;
            var coffee = 6;
            var hasPot = true;
            var coffeeMakerService = CoffeeMakerServiceHelpers.CreateCoffeeMakerService(water, coffee, filter, hasPot);

            // Act
            coffeeMakerService.Start();

            // Assert
            Assert.AreEqual(coffeeMakerService.Status, SensorStatus.Off);
        }

        [TestMethod]
        public void CoffeeMakerService_StopWithOptimalConditions_StatusOff()
        {
            // Arrange
            var filter = false;
            var water = 12;
            var coffee = 12;
            var hasPot = true;
            var coffeeMakerService = CoffeeMakerServiceHelpers.CreateCoffeeMakerService(water, coffee, filter, hasPot);

            // Act
            coffeeMakerService.Start();
            coffeeMakerService.Stop();

            // Assert
            Assert.AreEqual(coffeeMakerService.Status, SensorStatus.Off);
        }
    }
}
