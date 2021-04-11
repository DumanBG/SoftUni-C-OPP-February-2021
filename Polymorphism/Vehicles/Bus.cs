using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Bus : Vehicle
    {
        private const double BusAirConditionalModifier = 1.4;
       
        public Bus(double fuelQuantity, double fuelConsumation, double tankCapacity) 
            : base(fuelQuantity, fuelConsumation, tankCapacity, BusAirConditionalModifier)
        {
        }

       

        public  void DriveEmpty(double distance)
        {
            //1. Calculate required fuel
            double requiredFuel = (this.FuelConsumation ) * distance; // + klimatic
                                                                                                   //2. Veryf that required fuel is enough
            if (requiredFuel > this.Fuel)
            {
                throw new InvalidOperationException($"{ this.GetType().Name} needs refueling");  // Get type da stane car or Truck
            }

            //3. Modify the fuel
            this.Fuel -= requiredFuel;
        }
    }
}
