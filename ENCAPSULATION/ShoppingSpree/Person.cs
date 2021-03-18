using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> products;

        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.products = new List<Product>();
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                this.name = value;
            }
        }

        public decimal Money
        {
            get { return this.money; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                this.money = value;
            }
        }
        public IList<Product> GetProducts()
        {
            return this.products.AsReadOnly();
        }

        public void BuyProduct(Product product)
        {
            if (this.Money < product.Price)
            {
                throw new InvalidOperationException($"{this.Name} can't afford {product.Name}");
            }

            this.products.Add(product);
            this.money -= product.Price;
        }

        public override string ToString()
        {
            if(this.products.Count ==0)
            {
                return $"{this.Name} - Nothing bought";
            }
            return $"{this.Name} - {string.Join(", ",this.products.Select(p=>p.Name))}".TrimEnd();
        }

    }
}