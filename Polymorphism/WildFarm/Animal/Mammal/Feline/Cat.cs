using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Cat : Feline
    {
        private static HashSet<string> CatAllowerFood = new HashSet<string>() { nameof(Meat), nameof(Vegetable), }; // Иначе в конст не може да се инициализира ако не е статик
        private const double BaseWeightModifier = 0.30;
        public Cat(string name, double weight, string livingRegion, string breed) 
            
            : base(name, weight, livingRegion, CatAllowerFood, BaseWeightModifier, breed)
        {
        }

        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}
