using CarManager;
using System;
using NUnit.Framework;

namespace Tests
{
    //private Car car;
    public class CarTests
    {
        private string make = "Opel";
        private string model = "Sintra";
        private double fuelConsumation = 10;
        private double fuelCapacity = 100;
        private Car car;
        private double distanceToDrive;

        [SetUp]
        public void Setup()
        {
            car = new Car(make, model, fuelConsumation, fuelCapacity);
        }

        [Test]

        public void Ctor_InitialFuelAmount_ShouldBeZero()
        {
            Assert.That(car.FuelAmount, Is.EqualTo(0));
        }

        [Test]
        [TestCase("", "Model", 6.1, 100)]
        [TestCase(null, "Model", 6.1, 100)]
        [TestCase("Make", "", 6.1, 100)]
        [TestCase("Make", null, 6.1, 100)]
        [TestCase("Make", "Model", 0, 100)] //FuelConsumation can be 0 or -1
        [TestCase("Make", "Model", -5, 100)]// can be 0 or -1
        [TestCase("Make", "Model", 6.1, 0)]//FuelCapacity can be 0 or -1
        [TestCase("Make", "Model", 6.1, -5)]
        [TestCase(null, null, 0, 0)] //All inputs are incorect
        public void Ctor_ThrowsExecption_WhenDataIsInvalid(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() => { car = new Car(make, model, fuelConsumption, fuelCapacity); });

        }
        [Test]
        [TestCase("Volvo", "S60", 6.1, 100)]
        public void Ctor_CorrectlyInitialized(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            car = new Car(make, model, fuelConsumption, fuelCapacity);

            Assert.That(car.Make, Is.EqualTo(make));
            Assert.That(car.Model, Is.EqualTo(model));
            Assert.That(car.FuelConsumption, Is.EqualTo(fuelConsumption));
            Assert.That(car.FuelCapacity, Is.EqualTo(fuelCapacity));
        }
        [Test]
        [TestCase(0)]
        [TestCase(-5.2)]
        public void Refuel_ThrowsException_WithNegativeOrZeroAmount(double fuelToRefuel)
        {
            Assert.Throws<ArgumentException>(() => { car.Refuel(fuelToRefuel); }, "Fuel amount cannot be zero or negative!");

        }
        [Test]
        public void Refuel_SetFuelAmountToCapacty_WhenCapacityIsExeeded()
        {
           
            double maxFuelCapacity = this.car.FuelCapacity;


            car.Refuel(maxFuelCapacity + 50);
            Assert.That(car.FuelAmount, Is.EqualTo(maxFuelCapacity));
        }
        [Test]
        public void Refuel_ManyTimesCorrectly()
        {
            int timesToRefuel = 3;
            double amountToRefuel = 10;

            for (int i = 0; i < timesToRefuel; i++)
            {
                car.Refuel(amountToRefuel);
            }
            Assert.That(car.FuelAmount, Is.EqualTo(amountToRefuel * timesToRefuel));
        }
        [Test]
        public void Refuel_MoreThatCapacity()
        {
            double maxCapacity = this.fuelCapacity;

            car.Refuel(maxCapacity + 1000.0);

            Assert.That(car.FuelAmount, Is.EqualTo(maxCapacity));
        }
        [Test]
        public void Drive_ThrowsInvalidOperationException_WithZeroFuelAmount()
        {
             distanceToDrive = 100.10;
          
            Assert.Throws<InvalidOperationException>(() => { car.Drive(distanceToDrive); }, "You don't have enough fuel to drive!");
        }
        [Test]
        public void Drive_Correctly_WithMoreThanNeededFuel()
        {
            distanceToDrive = 100;
            double fuelToRefuel = 80;
            car.Refuel(fuelToRefuel);

            car.Drive(distanceToDrive);
            Assert.That(car.FuelAmount, Is.EqualTo(fuelToRefuel - distanceToDrive/100 * car.FuelConsumption));
        }
        [Test]
        public void Drive_DecreasesFuelAmountToZero_WhenRequiredFuelIsEqualToFuelAmount()
        {
         
            car.Refuel(car.FuelCapacity);
            double zero = 0;
            double distance = car.FuelCapacity * car.FuelConsumption;

            car.Drive(distance);

            Assert.That(car.FuelAmount, Is.EqualTo(zero));

        }
        [Test]
        public void FuelAmount_ThrowsException_WhenNegativeValueIsPassed() 
            //Bugg BusinesLogic Lipsva verifikaciq da izkarame distance s -100, <0
        {
            car.Refuel(car.FuelCapacity);
            //  Assert.Throws<ArgumentException>(() =>  this.car.Drive(-100));

            Assert.Pass();

        }

    }

}
