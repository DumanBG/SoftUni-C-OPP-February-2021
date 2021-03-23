using PersonInfo;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonInfo
{
    public class Citizen : IPerson, IBirthable, IIdentifiable
    {

        string name;
        int age;
        string birthdate;
        string id;
        // IIdentifiable identifiable = new Citizen(name, age, id, birthdate);
        //IBirthable birthable = new Citizen(name, age, id, birthdate);
        public Citizen(string name, int age, string id, string birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.Birthdate = birthdate;
            this.Id = id;
        }
        public string Name { get => this.name; private set => this.name = value; }
        public int Age { get => this.age; private set => this.age = value; }

        public string Birthdate { get => this.birthdate; private set => this.birthdate = value; }

        public string Id { get => this.id; private set => this.id = value; }
    }
}
