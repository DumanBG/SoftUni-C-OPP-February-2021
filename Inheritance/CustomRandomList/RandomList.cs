using System;
using System.Collections.Generic;
using System.Text;

namespace CustomRandomList
{
    public class RandomList<T> : List<T>
    {
        private Random rnd;

        public RandomList()
        {
            rnd = new Random();

        }



        public void Add(T el)
        {
            base.Add(el);
            Console.WriteLine($"Added the string {el} and we have custom functionalities");
        }

        //public string RemoveRandomElement()

        //{
        //    int index = rnd.Next(0, this.Count);
        //    string str = this[index];
        //   //  this e стринг RemoveRandomElement
        //    this.RemoveAt(index);
        //    return str;
        //}

        public T RandomString()
        {
            return this[rnd.Next(0, this.Count)];
        }
    }
}
