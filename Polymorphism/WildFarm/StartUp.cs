using System;
using System.Collections.Generic;

namespace WildFarm
{
   public class StartUp
    {
        public static void Main()
        {
            List<Animal> animals = new List<Animal>();
          while(true)
            {
                string line = Console.ReadLine();
                if(line == "End")
                {
                    break;
                }
                string[] animalParts = line.Split(" ",StringSplitOptions.RemoveEmptyEntries);
                Animal animal = CreateAnimal(animalParts);
                animals.Add(animal);
                Console.WriteLine(animal.ProduceSound());
                string[] foodParam = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
              
                Food food = CreateFood(foodParam);
                try
                {
                    animal.Eat(food);
                }
                catch (InvalidOperationException ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }
            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }

        private static Food CreateFood(string[] foodParam)
        {
            string foodType = foodParam[0];
            int quantity = int.Parse(foodParam[1]);

            Food food = null;
            if(foodType == nameof(Fruit))
            {
                food = new Fruit(quantity);
            }
            else if(foodType == nameof(Meat))
            {
                food = new Meat(quantity);
            }
            else if (foodType == nameof(Vegetable))
            {
                food = new Vegetable(quantity);
            }
            else if (foodType == nameof(Seeds))
            {
                food = new Seeds(quantity);
            }
            return food;
        }

        private static Animal CreateAnimal(string[] animalParts)
        {
            string type = animalParts[0];
            string name = animalParts[1];
            double weight = double.Parse(animalParts[2]);
            Animal animal = null;
            if(type == nameof(Owl))
            {
                double wingSize = double.Parse(animalParts[3]);
                animal = new Owl(name, weight, wingSize);
            }
            else if(type == nameof(Hen))
            {
                double wingSize = double.Parse(animalParts[3]);
                animal = new Hen(name, weight, wingSize);
            }
            else if(type == nameof(Cat))
            {
                string livingRegion = animalParts[3];
                string breed = animalParts[4];
                animal = new Cat(name, weight, livingRegion, breed);
            }
            else if (type == nameof(Tiger))
            {
                string livingRegion = animalParts[3];
                string breed = animalParts[4];
                animal = new Tiger(name, weight, livingRegion, breed);
            }
            else if (type == nameof(Dog))
            {
                string livingRegion = animalParts[3];
                animal = new Dog(name, weight, livingRegion);
            }
            else if (type == nameof(Mouse))
            {
                string livingRegion = animalParts[3];
                animal = new Mouse(name, weight, livingRegion);
            }
            return animal;
        }
    }
}
