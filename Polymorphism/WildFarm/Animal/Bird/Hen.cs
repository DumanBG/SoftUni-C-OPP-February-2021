using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Hen : Bird
    {
        private static HashSet<string> HenAllowedFood = new HashSet<string>() { nameof(Meat),nameof(Seeds),nameof(Fruit),nameof(Vegetable) }; // Иначе в конст не може да се инициализира ако не е статик
        private const double BaseWeightModifier = 0.35;
        public Hen(string name, double weight, double wingSize)
            : base(name, weight, HenAllowedFood, BaseWeightModifier, wingSize)
        {
        }

        public override string ProduceSound()
        {
            return "Cluck";
        }
    }
}
