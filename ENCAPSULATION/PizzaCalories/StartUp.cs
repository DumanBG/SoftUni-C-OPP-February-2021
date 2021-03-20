using System;
using System.Collections.Generic;

namespace PizzaCalories
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            try
            {
                string[] CreatePizza = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
                Pizza Pizza = new Pizza(CreatePizza[1]);
                string[] CreateDough = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
                string flour = CreateDough[1];
                string baking = CreateDough[2];
                double weight = double.Parse(CreateDough[3]);
                Dough Dough = new Dough(flour, baking, weight);
                Pizza.Dough = Dough;
                string command = string.Empty;
                while (command != "END")
                {
                    command = Console.ReadLine();
                    if (command == "END")
                    {
                        break;
                    }
                    string[] splitedinput = command.Split(" ",StringSplitOptions.RemoveEmptyEntries);
                    string topping = splitedinput[1].ToString();
                    string firstletter = topping[0].ToString();
                    string uppercase = firstletter.ToUpper();
                    topping = topping.Replace(firstletter, uppercase);
                    weight = double.Parse(splitedinput[2]);
                    Topping topping1 = new Topping(topping, weight);
                    Pizza.AddToppings(topping1);
                }
                Console.WriteLine(Pizza.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
