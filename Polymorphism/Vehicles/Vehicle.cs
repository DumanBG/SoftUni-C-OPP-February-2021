using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public abstract class Vehicle
    {
        private double tankCapacity;
        private double fuel;

        protected Vehicle(double fuelQuantity, double fuelConsumation, double tankCapacity, double airConditionalModifier) // ne trqbva da se vkarva busnes logica v ctor a prop
        {
            // this.Fuel = fuelQuantity >tankCapacity ? 0 : fuelQuantity;   //ternaren raboti
            this.TankCapacity = tankCapacity;
            this.Fuel = fuelQuantity;
            this.FuelConsumation = fuelConsumation;
            this.AirConditionerModifier = airConditionalModifier;
        }

        protected Vehicle(double fuelQuantity, double fuelConsumation, double carAirConditionalModifier)
        {
            FuelConsumation = fuelConsumation;
        }

        public double TankCapacity { get => this.tankCapacity; private set => this.tankCapacity = value; }
        private double AirConditionerModifier { get; set; }
        public double Fuel
        {
            get => this.fuel;
            protected set
            {
                if (value > this.tankCapacity)
                {
                    this.fuel = 0;
                }
                else
                {
                    this.fuel = value;
                }
            }
        }
        public double FuelConsumation { get; private set; }

        public virtual void Drive(double distance)
        {
            //1. Calculate required fuel
            double requiredFuel = (this.FuelConsumation + this.AirConditionerModifier) * distance; // + klimatic
                                                                                                   //2. Veryf that required fuel is enough
            if (requiredFuel > this.Fuel)
            {
                throw new InvalidOperationException($"{ this.GetType().Name} needs refueling");  // Get type da stane car or Truck
            }

            //3. Modify the fuel
            this.Fuel -= requiredFuel;
        }

        public virtual void Refuel(double amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }
            if (this.Fuel + amount > tankCapacity)
            {
                throw new InvalidOperationException($"Cannot fit {amount} fuel in the tank");
            }


            this.Fuel += amount;
        }
        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.Fuel:F2}";
        }
    }
}
