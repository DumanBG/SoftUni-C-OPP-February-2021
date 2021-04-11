using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Dog : Mammal
    {
        private static HashSet<string> DogAllowedFood = new HashSet<string>() { nameof(Meat)}; // Иначе в конст не може да се инициализира ако не е статик
        private const double BaseWeightModifier = 0.40;
        public Dog(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion, DogAllowedFood, BaseWeightModifier)
        {
        }

        public override string ProduceSound()
        {
            return "Woof!";
        }
        public override string ToString()
        {
            return $"{GetType().Name} [{this.Name}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
