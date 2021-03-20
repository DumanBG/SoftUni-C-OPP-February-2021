using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
	public class Dough
	{
		private const double MinWeight = 1;
		private const double MaxWeight = 200;
		private const double caloriespergram = 2;
		private const string InvalidTypeDoughtExeption = "Invalid baking technique";
		private string flour;
		private string bakingtechnique;
		private double weight;
		public Dough(string flour, string bakingTechnique, double weight)
		{
			Flour = flour;
			BakingTechnique = bakingTechnique;
			Weight = weight;
		}

		public string Flour
		{
			get { return flour; }
			private set
			{
				Validator.ThrowIfValueIsNotAllowed(new HashSet<string> { "white", "wholegrain" }, value.ToLower(), InvalidTypeDoughtExeption);
				
					this.flour = value;
				
			}
		}

		public string BakingTechnique
		{
			get { return bakingtechnique; }
			private set
			{
				Validator.ThrowIfValueIsNotAllowed(new HashSet<string> { "crispy", "chewy", "homemade" }, value.ToLower(), InvalidTypeDoughtExeption);
				
					this.bakingtechnique = value;
				
			}
		}

		public double Weight
		{
			get { return weight; }
			private set
			{
				Validator.ThrowIfNumberIsNotInRange(MinWeight, MaxWeight, value, $"Dough weight should be in the range [{MinWeight}..{MaxWeight}].");
				
				this.weight = value;
			}
		}

		public double TotalCalories => Totalcalories();

		private double Totalcalories()
		{
			var flourcalories = 0.0;
			var bakingtechniquecalories = 0.0;
			switch (this.Flour.ToLower())
			{
				case "white":
					flourcalories = 1.5;
					break;
				case "wholegrain":
					flourcalories = 1;
					break;
			}
			switch (this.BakingTechnique.ToLower())
			{
				case "crispy":
					bakingtechniquecalories = 0.9;
					break;
				case "chewy":
					bakingtechniquecalories = 1.1;
					break;
				case "homemade":
					bakingtechniquecalories = 1;
					break;

			}
			double Totalcalories = (caloriespergram * Weight) * flourcalories * bakingtechniquecalories;
			return Totalcalories;
		}
	}
}
