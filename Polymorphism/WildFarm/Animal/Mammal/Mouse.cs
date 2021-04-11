using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Mouse : Mammal
    {
        private static HashSet<string> MouseAllowedFood = new HashSet<string>() { nameof(Vegetable), nameof(Fruit) }; // Иначе в конст не може да се инициализира ако не е статик
        private const double BaseWeightModifier = 0.10;
        public Mouse(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion, MouseAllowedFood, BaseWeightModifier)
        {
        }

        public override string ProduceSound()
        {
            return "Squeak";
        }
        public override string ToString()
        {
            return $"{GetType().Name} [{this.Name}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
