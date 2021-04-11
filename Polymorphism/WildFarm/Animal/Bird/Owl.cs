using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Owl : Bird
    {
        private static HashSet<string> OwlAllowedFood = new HashSet<string>() {nameof(Meat)}; // Иначе в конст не може да се инициализира ако не е статик
        private const double BaseWeightModifier = 0.25;
        public Owl(string name, double weight, double wingSize) 
            : base(name, weight, OwlAllowedFood, BaseWeightModifier, wingSize)
        {
        }

        public override string ProduceSound()
        {
            return "Hoot Hoot";
        }
    }
}
