using System;

namespace Restaurant
{
  public  class StartUp
    {
       public static void Main(string[] args)
        {

            var coffee = new Coffee("Costa", 2.1);
            Console.WriteLine($" Coffe price: {coffee.Price :F2}");

        }
    }
}
