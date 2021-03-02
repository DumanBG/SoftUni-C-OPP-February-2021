using System;

namespace Farm
{
    public class StartUp
    {
        public static void Main(string[] args)
        {



            Dog dog = new Dog();
            dog.Bark();
            dog.Bark();
            dog.Eat();
            Puppy puppy = new Puppy();
            puppy.Eat();
            puppy.Bark();
            puppy.Weep();

            Cat catty = new Cat();
            catty.Eat();

            catty.Meow();
        }
    }
}
