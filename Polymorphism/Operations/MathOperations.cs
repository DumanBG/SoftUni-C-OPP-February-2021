using System;
using System.Collections.Generic;
using System.Text;

namespace Operations
{
    public class MathOperations
    {

        public MathOperations()
        {

        }

        public int A { get; set; }
        public int B { get; set; }

        public  int  Add(int a, int b)
        {
            return a + b;
        }
        public  double Add(double a, double b, double c)
        {
            return a + b;
        }
        public decimal  Add(decimal a, decimal b, decimal c)
        {
            return a + b+c;
        }
    }
}
