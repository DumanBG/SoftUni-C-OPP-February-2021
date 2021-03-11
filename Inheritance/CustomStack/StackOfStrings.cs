using System;
using System.Collections.Generic;
using System.Text;

namespace CustomStack
{
   public class StackOfStrings<T> :Stack<T>
    {

   

        //TODO  check if Stack is Empty
        public bool IsEmpty()
        {
            return this.Count == 0;
        }

        public Stack<T> AddRange(IEnumerable<T> range) /// Т  стак от всичко
            // IEnumrable - тоест приема всяка една Ienum колекция List, [],  и  oт нея push-ва всеки елемент към customStack-a
        {

            foreach (var item in range)
            {
                this.Push(item);
            }

            return this;
            // return customStack-a
        }
    }
}
