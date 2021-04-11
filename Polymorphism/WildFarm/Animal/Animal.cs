using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public abstract class Animal
    {
        protected Animal(string name, double weight, HashSet<string> allowedFood,double weightModifiear)
        {
            Name = name;
            Weight = weight;
            this.AllowedFoods = allowedFood;
            this.WeightModifier = weightModifiear;
        }
        private double WeightModifier { get; set; }
        private HashSet<string> AllowedFoods { get;  set; }
        public string Name { get; private set; }
        public double Weight { get; private set; }
        public int FoodEaten { get; private set; }

        public abstract string ProduceSound();

        public void Eat (Food food)
        {
            string fooodType = food.GetType().Name;
            //1. Validate the food can eat
            if(!AllowedFoods.Contains(fooodType))
            {
                //•	"{AnimalType} does not eat {FoodType}!"
                throw new InvalidOperationException($"{this.GetType().Name} does not eat {fooodType}!");
            }
            else
            {
            //2. FoodEaten ++
                this.FoodEaten += food.Qunatity;
            }
            //3. Weight ++
            this.Weight += WeightModifier * food.Qunatity;
        }
       
    }
}
