using System;

namespace Animals
{
    public class StartUp
    {
        public static void Main()
        {
            {
                Animal animal = new Cat("Koti", "negativni emocii");
                Console.WriteLine(animal.ExplainSelf());

                animal = new Dog("Kuchi", "pozitivni emocii i salam");
                Console.WriteLine(animal.ExplainSelf());
            }
        }
    }
}
//        {
//            int pointsToBreak = 0;
//                AnimalAbsClass animal = null;  // трябва да е нулл в началото преди да му предадем стойност  pri abstractClass
//            IAnimal polimorphic = null; // move da e dog, cat ili fish ili vsi4ko koeto go nasledqva

//            while (true)
//            {
//                string type = Console.ReadLine();

//                if (type == nameof(Dog))
//                {
//                    //  Dog dog = new Dog();
//                    animal = new Dog();
//                    //animal.Talk();
//                    polimorphic = new Dog();  // през IAnimal
//                }

//                else if (type == nameof(Cat))
//                {
//                    animal = new Cat();
//                    //animal.Talk();
//                    polimorphic = new Dog();  // през IAnimal
//                }
//                else if (type == nameof(Fish))
//                {
//                    animal = new Fish();
                  
//                    Fish fish = new Fish(); /// ne se vijdat v abstrakciata IAnimal i abs klass a samo v riba
//                    fish.Jump();
//                    polimorphic = new Dog();  // през IAnimal

//                }
//                else
//                {
//                    pointsToBreak++;
//                    if (pointsToBreak == 3)
//                    {
//                        break;
//                    }
//                    else
//                    {
//                        continue;

//                    }
//                }
//                animal.Talk(); // горе трябва да е нулл или да има If, else if  i nakraq Else;
//            }
//        }
//    }
//}

