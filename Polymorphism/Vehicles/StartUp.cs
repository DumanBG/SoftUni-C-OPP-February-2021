using System;

namespace Vehicles
{
   public class StartUp
    {
       public static void Main()
        {
            Vehicle car = CreateVehicle();
            Vehicle truck = CreateVehicle();

            int commNumbers = int.Parse(Console.ReadLine());
            for (int i = 0; i < commNumbers; i++)
            {
                string[] parts = Console.ReadLine().Split(" ");
                string command = parts[0];
                string carOrTruck = parts[1];
                double ammount = double.Parse(parts[2]);

                if(command == "Drive")
                {
                    try
                    {
                        if (carOrTruck == nameof(Car))
                        {
                            car.Drive(ammount);
                        }
                        else if (carOrTruck == nameof(Truck))
                        {
                            truck.Drive(ammount);
                        }
                        Console.WriteLine($"{carOrTruck} travelled {ammount} km");
                    }
                    catch (InvalidOperationException ex)
                    {

                        Console.WriteLine(ex.Message);
                    }
                }
                else if(command == "Refuel")
                {
                   
                        if (carOrTruck == nameof(Car))
                        {
                            car.Refuel(ammount);
                        }
                        else if (carOrTruck == nameof(Truck))
                        {
                            truck.Refuel(ammount);
                        }
                }

            }
            //Console.WriteLine($"{nameof(car)}: {car.Fuel:F2}");
            //Console.WriteLine($"{nameof(truck)}: {truck.Fuel:F2}");
            Console.WriteLine(car);
            Console.WriteLine(truck);
        }

        private  static Vehicle CreateVehicle()
        {

            string[] parts = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string type = parts[0];
            double fuelQuanatity = double.Parse(parts[1]);
            double fuelConsumption = double.Parse(parts[2]);

            Vehicle vehicle = null;  // davame na4alna stoinost null i pridavame
            if(type == nameof(Car))
            {
              vehicle = new Car(fuelQuanatity,fuelConsumption); 
            }
            else if(type == nameof(Truck))
            {
               vehicle = new Truck(fuelQuanatity, fuelConsumption);
            }
            return vehicle;
        }
    }
}
