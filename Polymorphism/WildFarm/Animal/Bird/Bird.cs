using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public abstract class Bird : Animal
    {
        protected Bird(string name, double weight, HashSet<string> allowedFood, double weightModifiear,double wingSize) 
            : base(name, weight, allowedFood, weightModifiear)
        {
            this.WingSize = wingSize;
        }

        public double WingSize { get;private set; }

        public override string ToString()
        {
            return $"{GetType().Name} [{this.Name}, {this.WingSize}, {this.Weight}, {this.FoodEaten}]";
        }
    }
}
