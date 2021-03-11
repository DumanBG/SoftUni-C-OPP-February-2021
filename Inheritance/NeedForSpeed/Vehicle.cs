using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class Vehicle
    {
        private const double DefaultFuelConsumption = 1.25;

        public Vehicle(int horsePower, double fuel)
        {
            this.HorsePower = horsePower;
            this.Fuel = fuel;

        }

        public double Fuel { get; set; }
        public int HorsePower { get; set; }

    
        public virtual double FuelConsumption { get =>DefaultFuelConsumption; } // Може и  без get и {}     =>1.25




        public virtual void Drive(double Kilometers)
        {
            this.Fuel -= Kilometers * this.FuelConsumption;

        }
    }
}
