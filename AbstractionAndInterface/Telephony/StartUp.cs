using System;

namespace Telephony
{
   public class StartUp
    {
       public static void Main()
        {
            string[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] urls = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < numbers.Length; i++)
            {
                try
                {
                    if (numbers[i].Length == 7)
                    {
                        ICallable stPhone = new StationaryPhone();
                        Console.WriteLine(stPhone.Call(numbers[i]));
                    }
                    else
                    {
                        ICallable smPhone = new Smartphone();
                        Console.WriteLine(smPhone.Call(numbers[i]));
                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }
            for (int i = 0; i < urls.Length; i++)
            {
                try
                {
                    IBrowsable smPhone = new Smartphone();
                    Console.WriteLine(smPhone.Browse(urls[i]));
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}