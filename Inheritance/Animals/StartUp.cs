﻿using System;

namespace Animals
{
   public class StartUp
    {
        public static void Main(string[] args)
        {

            while (true)
            {
                var line = Console.ReadLine();
                var data = Console.ReadLine().Split(" ");
                var name = data[0];
                var age =int.Parse( data[1]);
                var gender = data[2];


                if (line == "Beast!")
                {
                    break;
                }
                if(age <0  || string.IsNullOrEmpty(name) || string.IsNullOrEmpty(gender))
                {
                    Console.WriteLine("Ivalid Input!");
                    continue;
                }
                if(line == "Cat")
                {
                    var cat = new Cat(name, age, gender);
                    Console.WriteLine(cat);
                    Console.WriteLine(cat.ProduceSound());
                }
                else if( line == "Dog")
                {
                    var dog = new Dog(name, age, gender);
                    Console.WriteLine(dog);
                    Console.WriteLine(dog.ProduceSound());
                }
                else if (line == "Frog")
                {
                    var frog = new Frog(name, age, gender);
                    Console.WriteLine(frog);
                    Console.WriteLine(frog.ProduceSound());
                }
                else if (line == "Tomcat")
                {
                    var tomCat = new Tomcat(name, age, gender);
                    Console.WriteLine(tomCat);
                    Console.WriteLine(tomCat.ProduceSound());
                }
                else if (line == "Kitten")
                {
                    var kitten = new Kitten(name, age, gender);
                    Console.WriteLine(kitten);
                    Console.WriteLine(kitten.ProduceSound());
                }
            }
        }
    }
}
