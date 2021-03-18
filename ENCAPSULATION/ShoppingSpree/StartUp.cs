using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, Person> people = new Dictionary<string, Person>();
            Dictionary<string, Product> products = new Dictionary<string, Product>();
            try
            {
                people = ReadPeople();
                products = ReadProducts();
            }
            catch (ArgumentException ex)
            {

                Console.WriteLine(ex.Message);
                return;
            }

            while(true)
            {
                string line = Console.ReadLine();
                if(line == "END")
                {
                    break;
                }
                string[] parts = line.Split();
               
                string personName = parts[0];
                string productName = parts[1];

                Person person = people[personName];
                Product product = products[productName];
                try
                {
                person.BuyProduct(product);

                Console.WriteLine($"{personName} bought {productName}");

                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }
            foreach (var person in people.Values)
            {
                Console.WriteLine(person);
            }

        }

        private static Dictionary<string, Product> ReadProducts()
        {
            Dictionary<string, Product> result = new Dictionary<string, Product>();
            string[] parts = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);

            foreach (string part in parts)
            {
                string[] productData = part.Split("=");
                string productName = productData[0];
                decimal productCost = decimal.Parse(productData[1]);

                result[productName] = new Product(productName, productCost);
            }
            return result;
        }

        private static Dictionary<string, Person> ReadPeople()
        {
            Dictionary<string,Person> result = new Dictionary<string, Person>();

            string[] parts = Console.ReadLine().Split(";");

            foreach (string part in parts)
            {
                string[] personData = part.Split("=", StringSplitOptions.RemoveEmptyEntries);
                string name = personData[0];
                decimal money = decimal.Parse(personData[1]);

                result[name] = new Person(name, money);
            }


                return result;
        }
    }
}