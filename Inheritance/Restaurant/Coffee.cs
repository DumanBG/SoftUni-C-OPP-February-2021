using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        private const double DefaultMililiters = 50.0;
        private const decimal DefaultPrice = 3.50M;


        public Coffee(string name, double caffeine) 
            : base(name, DefaultPrice, DefaultMililiters)  // 3.50M . 50
        {
            this.Caffeine = caffeine;
        }

        public double Caffeine { get; set; }



    }
}
