using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Truck : Vehicle
    {
        private const double TruckAirConditionalModifier = 1.6;
        public Truck(double fuelQuantity, double fuelConsumation) 
            : base(fuelQuantity, fuelConsumation, TruckAirConditionalModifier)
        {
        }



        public override void Refuel(double amount)
        {
            base.Refuel(amount*0.95);  // 95%  заради загубите директно в амаунт-а
        }
    }
}
