using System;
using System.Collections.Generic;
using System.Text;

namespace CustomRandomList
{
   public class RandomList :List<string>
    {
        private Random rnd;
      
        public RandomList()
        {
            rnd = new Random();
      
        }



        public void Add(string el)
        {
            base.Add(el);
            Console.WriteLine($"Added the string {el} and we have custom functionalities");
        }

        public string RemoveRandomElement()
        {
            int index = rnd.Next(0, this.Count);
            string str = this[index];
            //this e  стринг RemoveRandomElement
            this.RemoveAt(index);
            return str;
        }

        public string RandomString()
        {
            return this[rnd.Next(0, this.Count)];
        }
    }
}
