using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
   public  abstract class Vehicle
    {

        protected Vehicle(double fuelQuantity, double fuelConsumation,double airConditionalModifier)
        {
            this.Fuel = fuelQuantity;
            this.FuelConsumation = fuelConsumation;
            this.AirConditionerModifier = airConditionalModifier;
        }
        private double AirConditionerModifier  { get; set; }
        public double Fuel { get; private set; }
        public double FuelConsumation { get; private set; }

        public  void Drive(double distance)
        {
            //1. Calculate required fuel
            double requiredFuel =( this.FuelConsumation + this.AirConditionerModifier)*distance; // + klimatic
             //2. Veryf that required fuel is enough
             if(requiredFuel > this.Fuel)
            {
                throw new InvalidOperationException($"{ this.GetType().Name} needs refueling");  // Get type da stane car or Truck
            }

            //3. Modify the fuel
            this.Fuel -= requiredFuel;
        }

        public virtual void Refuel(double amount)
        {

            this.Fuel += amount;
        }
        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.Fuel:F2}";
        }
    }
}
