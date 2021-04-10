using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Car : Vehicle
    {
        private const double CarAirConditionalModifier = 0.9;
        public Car(double fuelQuantity, double fuelConsumation)
            : base(fuelQuantity, fuelConsumation, CarAirConditionalModifier) // const za Air директно в ктор на бейса
        {

        }





    }
}
