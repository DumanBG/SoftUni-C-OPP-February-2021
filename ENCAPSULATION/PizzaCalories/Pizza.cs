using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PizzaCalories
{
	public class Pizza
	{
		private const int MaxTopping = 10;
		private const int MinLenght = 1;
		private const int MaxLenght = 15;
	
		private Dough dough;
		private List<Topping> toppings;
		private string name;
		public Pizza(string name)
		{
			this.Name = name;
			this.toppings = new List<Topping>();
		}

		public string Name
		{
			get { return name; }
			private set
			{
				if (value.Length < 1 || value.Length > MaxLenght)
				{
					throw new Exception($"Pizza name should be between {MinLenght} and {MaxLenght} symbols.");
				}
				name = value;
			}
		}

		public Dough Dough
		{
			get { return dough; }
			set { dough = value; }
		}
		public int Numberoftoppings => this.toppings.Count;

		public double TotalCalories => Totalcalories();

		public void AddToppings(Topping topping)
		{
			if (this.Numberoftoppings == MaxTopping)
			{
				throw new Exception($"Number of toppings should be in range [0..{MaxTopping}].");
			}
			this.toppings.Add(topping);
		}

		private double Totalcalories()
		{
			double total = Dough.TotalCalories;
			for (int i = 0; i < toppings.Count; i++)
			{
				total += toppings[i].TotalCalories;
			}
			return total;
		}
		public override string ToString()
		{
			return $"{this.Name} - {this.TotalCalories:F2} Calories.";
		}
	}
}