using System;

namespace Vehicles
{
    public class StartUp
    {
        public static void Main()
        {
            Vehicle car = CreateVehicle();
            Vehicle truck = CreateVehicle();
            Vehicle bus = CreateVehicle();

            int commNumbers = int.Parse(Console.ReadLine());
            for (int i = 0; i < commNumbers; i++)
            {
                string[] parts = Console.ReadLine().Split(" ");
                string command = parts[0];
                string vehicleType = parts[1];
                double ammount = double.Parse(parts[2]);

                try
                {
                    if (vehicleType == nameof(Car))
                    {
                        ProcessCommand(car, command, ammount);
                    }
                    else if (vehicleType == nameof(Truck))
                    {
                        ProcessCommand(truck, command, ammount);
                    }
                    else if(vehicleType == nameof(Bus))
                    {
                        ProcessCommand(bus, command, ammount);
                    }
                }
                catch (Exception ex)
                when(ex is InvalidOperationException || ex is ArgumentException)
                {

                    Console.WriteLine(ex.Message);
                }
               

            }


            //Console.WriteLine($"{nameof(car)}: {car.Fuel:F2}");
            //Console.WriteLine($"{nameof(truck)}: {truck.Fuel:F2}");
            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
            
        }

        private static void ProcessCommand(Vehicle vehicle, string command, double ammount)
        {
            if (command == "Drive")
            {
               

                    vehicle.Drive(ammount);
                    Console.WriteLine($"{vehicle.GetType().Name} travelled {ammount} km");
               
               
            }
            else if(command == "DriveEmpty")
            {
                
                 
                ((Bus)vehicle).DriveEmpty(ammount); // to do ako gramne ne setva off na AirCond
                Console.WriteLine($"{vehicle.GetType().Name} travelled {ammount} km");


            }
            else if (command == "Refuel")
            {
                vehicle.Refuel(ammount);
            }
        }
        private static Vehicle CreateVehicle()
        {

            string[] parts = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string type = parts[0];
            double fuelQuanatity = double.Parse(parts[1]);
            double fuelConsumption = double.Parse(parts[2]);
            double TankCapacity = double.Parse(parts[3]);

            Vehicle vehicle = null;  // davame na4alna stoinost null i pridavame
           
            if (type == nameof(Car))
            {
                vehicle = new Car(fuelQuanatity, fuelConsumption, TankCapacity);
            }
            else if (type == nameof(Truck))
            {
                vehicle = new Truck(fuelQuanatity, fuelConsumption, TankCapacity);
            }
            else if (type == nameof(Bus))
            {
                vehicle = new Bus(fuelQuanatity, fuelConsumption, TankCapacity);
            }
            return vehicle;
        }
    }
}
