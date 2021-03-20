using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Topping
    {

        private const double MinWeight = 1;
        private const double MaxWeight = 50;
        private const double caloriespergram = 2;

        private double weight;
        private string toppingType;

        public Topping(string toppingType, double weight)
        {
            this.ToppingType = toppingType;
            this.Weight = weight;
        }

        public string ToppingType
        {
            get => this.toppingType;
            private set
            {
                Validator.ThrowIfValueIsNotAllowed(new HashSet<string> { "meat", "veggies", "cheese", "sauce" }, value.ToLower(), $"Cannot place {value} on top of your pizza.");

                toppingType = value;
            }
        }

        public double Weight
        {
            get => this.weight;
            private set
            {
                Validator.ThrowIfNumberIsNotInRange(MinWeight, MaxWeight, value, $"{this.ToppingType} weight should be in the range [{MinWeight}..{MaxWeight}].");

                weight = value;
            }
        }



        public double TotalCalories => Totalcalories();
        private double Totalcalories()
        {
            double toppingcalories = 0;
            switch (this.ToppingType.ToLower())
            {
                case "meat":
                    toppingcalories = 1.2;
                    break;
                case "veggies":
                    toppingcalories = 0.8;
                    break;
                case "cheese":
                    toppingcalories = 1.1;
                    break;
                case "sauce":
                    toppingcalories = 0.9;
                    break;
            }
            double totalcalories = (caloriespergram * this.Weight) * toppingcalories;
            return totalcalories;
        }
    }
}
