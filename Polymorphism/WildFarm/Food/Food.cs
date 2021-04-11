using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
   public abstract class Food
    {
        protected Food(int qunatity)
        {
            Qunatity = qunatity;
        }

        public int Qunatity { get; private set; }
    }
}
