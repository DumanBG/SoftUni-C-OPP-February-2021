using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Tiger : Feline
    {
        private static HashSet<string> TigerAllowedFood = new HashSet<string>() { nameof(Meat) }; // Иначе в конст не може да се инициализира ако не е статик
        private const double BaseWeightModifier = 1.00;
        public Tiger(string name, double weight, string livingRegion, string breed)

            : base(name, weight, livingRegion, TigerAllowedFood, BaseWeightModifier, breed)
        {
        }

        public override string ProduceSound()
        {
            return "ROAR!!!";
        }
    }
}
