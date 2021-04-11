using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Truck : Vehicle
    {
        private const double TruckAirConditionalModifier = 1.6;
        public Truck(double fuelQuantity, double fuelConsumation, double tankCapacity) 
            : base(fuelQuantity, fuelConsumation, tankCapacity,TruckAirConditionalModifier)
        {
        }

        

        public override void Refuel(double amount)
        {
          //  base.Refuel(amount*0.95);  // 95%  заради загубите директно в амаунт-а
            if (amount <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }
            if (this.Fuel + amount > this.TankCapacity)
            {
                throw new InvalidOperationException($"Cannot fit {amount} fuel in the tank");
            }
            this.Fuel += amount * 0.95;
        }
    }
}
