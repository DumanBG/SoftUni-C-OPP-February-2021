using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public abstract class Feline : Mammal
    {
        
        protected Feline(string name, double weight, string livingRegion, HashSet<string> allowedFood, double weightModifiear, string breed) 
            : base(name, weight, livingRegion, allowedFood, weightModifiear)
        {

           this.Breed = breed;
        }



        public string Breed { get;private set; }

        public override string ToString()
        {
            return $"{GetType().Name} [{this.Name}, {this.Breed}, {this.Weight}, {this.LivingRegion}, {FoodEaten}]";
        }
    }
}
