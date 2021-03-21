using System;
using System.Collections.Generic;
using System.Text;

namespace FootballTeamGenerator
{
    public class Player
    {
        private const int MinStat = 0;
        private const int MaxStat = 100;
     
        private string name;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        //•	"Add;{TeamName};{PlayerName};{Endurance};{Sprint};{Dribble};{Passing};{Shooting}
        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            this.Name = name;
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
        }
        public string Name { get => this.name;
            private set
            {
                Validator.ThrowIfStringIsNullOrWhiteSpace(value, GlobalConstants.InvalidNameErrorMessage);
                this.name = value;
            }
        }
        public int Endurance
        {
            get => this.endurance;
            private set
            {
                Validator.ThrowIfIsNotInRange(MinStat, MaxStat, value);
                this.endurance = value;
            }
        }
        public int Sprint { get => this.sprint;

            private set
            {
                Validator.ThrowIfIsNotInRange(MinStat, MaxStat, value);
                this.sprint = value;
            }
        }
        public int Dribble
        {
            get => this.dribble;

            private set
            {
                Validator.ThrowIfIsNotInRange(MinStat, MaxStat, value);
                this.dribble = value;
            }
        }
        public int Passing
        {
            get => this.passing;

            private set
            {
                Validator.ThrowIfIsNotInRange(MinStat, MaxStat, value);
                this.passing = value;
            }
        }
        public int Shooting
        {
            get => this.shooting;

            private set
            {
                Validator.ThrowIfIsNotInRange(MinStat, MaxStat, value);
                this.shooting = value;
            }
        }


        public double AverageSkillPoint => Math.Round((this.Endurance + this.Sprint + this.Dribble + this.Passing + this.Shooting) / 5.0);

        //private  void CheckValueInRange(int value)
        //{
        //    if (value < MinStat || value > MaxStat)
        //    {
        //        throw new ArgumentException($"{nameof(value)} should be between {MinStat} and {MaxStat}.");
        //    }
        //}


        private int CalculateAverageStat()
        {
            ///{ Endurance};
            //{ Sprint};
            //{ Dribble};
            //{ Passing};
            //{ Shooting}
            double average = 0;
            average = (this.Endurance + this.Sprint + this.Dribble + this.Passing + this.Shooting);
            average = Math.Round(average / 5);
            int result = (int)average;
    
        return result;
        }
    }
}
