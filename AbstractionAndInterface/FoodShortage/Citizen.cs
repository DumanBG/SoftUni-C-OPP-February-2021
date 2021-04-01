using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage
{
    public class Citizen : Person, IBirthable, IIdentifiable
    {
        private string name;
        private int age;
        private string id;
        private int food;
        private string birthdate;

        public Citizen(string name, int age, string birthdate, string id ) : base(name, age)
        {
           
            this.Id = id;
            this.Birthdate = birthdate;
         //   this.Food = 0; // не е нужно

        }
        //public string Name { get => this.name; private set => this.name = value; }

        //public int Age { get => this.age; private set => this.age = value; }
        public string Id { get => this.id; private set => this.id = value; }

        public string Birthdate { get => this.birthdate; private set => this.birthdate = value; }

       // public int Food { get => this.food; private set => this.food = value; }


        public override void BuyFood()
        {
            this.Food += 10;
        }
    }
}
