using PersonInfo;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonInfo
{
    public class Citizen : IPerson
    {

        string name;
        int age;
        
        string id;
        // IIdentifiable identifiable = new Citizen(name, age, id, birthdate);
        //IBirthable birthable = new Citizen(name, age, id, birthdate);
        public Citizen(string name, int age, string id)
        {
            this.Name = name;
            this.Age = age;
            
            this.Id = id;
        }
        public string Name { get => this.name; private set => this.name = value; }
        public int Age { get => this.age; private set => this.age = value; }

        

        public string Id { get => this.id; private set => this.id = value; }
    }
}
