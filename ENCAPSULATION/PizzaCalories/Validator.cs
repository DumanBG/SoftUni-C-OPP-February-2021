using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
   public class Validator
    {
        //  Validator.ThrowIfNumberIsNotInRange(MinWeight, MaxWeight, value, $"{this.ToppingType} weight should be in the range [{MinWeight}..{MaxWeight}].");
        public static void ThrowIfNumberIsNotInRange(double lower, double max, double number, string exceptMessage)
        {
            if(number < lower || number > max)
            {
                throw new ArgumentException(exceptMessage);
            }
        }
        //Validator.ThrowIfValueIsNotAllowed(new HashSet<string> { "meat", "veggies", "cheese", "sauce" }, value.ToLower(), $"Cannot place {value} on top of your pizza.");
        public static void ThrowIfValueIsNotAllowed (HashSet<string> allowedValues, string value, string  exceptionMessage)
        {
            
            if(!allowedValues.Contains(value))
            {
                throw new ArgumentException(exceptionMessage);
            }
        }
    }
}
