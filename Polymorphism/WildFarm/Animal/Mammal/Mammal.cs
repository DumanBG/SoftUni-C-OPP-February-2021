using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public abstract class Mammal : Animal
    {
        protected Mammal(string name, double weight, string livingRegion, HashSet<string> allowedFood, double weightModifiear) 
            : base(name, weight, allowedFood, weightModifiear)
        {
            this.LivingRegion = livingRegion;
        }

        public string LivingRegion { get; private set; }


    }
}
