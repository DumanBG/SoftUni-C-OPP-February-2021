using System;
using System.Collections.Generic;

namespace NeedForSpeed
{
    public class StartUp
    {
       public  static void Main(string[] args)
        {
            var sportCar = new SportCar(10, 42.2);
            var motorCycle = new Motorcycle(5, 55.2);
            var crossMotorcycle = new CrossMotorcycle(30, 40.2);

            List<Vehicle> vechh = new List<Vehicle>();
            vechh.Add(sportCar);
            vechh.Add(motorCycle);
            vechh.Add(crossMotorcycle);

            foreach (var item in vechh)
            {
                Console.WriteLine(item.Fuel);
                item.Drive(5);
                Console.WriteLine(item.Fuel);
            }


        }
    }
}
