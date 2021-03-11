using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Cake : Dessert
    {
        private const decimal DeffaultPrice = 5M;
        private const double DeffaultGrams = 250;
        private const double DeffaultCaloriers = 1000;
        public Cake(string name) 
            : base(name, DeffaultPrice, DeffaultGrams, DeffaultCaloriers)
        {
        }
    }
}
