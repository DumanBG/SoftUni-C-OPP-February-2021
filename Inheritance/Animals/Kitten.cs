using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Kitten : Cat
    {
        private const string DeffaultGender = "Female";
        public Kitten(string name, int age, string gender) 
            : base(name, age, DeffaultGender)
        {
        }
        public Kitten(string name, int age)
           : base(name, age, DeffaultGender)
        {
            
        }
        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}
