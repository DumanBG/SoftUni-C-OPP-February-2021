﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballTeamGenerator
{
    public class Team
    {
        private Dictionary<string, Player> playersByName;
        private string name;

        public Team(string name)
        {
            this.Name = name;
            playersByName = new Dictionary<string, Player>();
        }
        public string Name
        {
            get => this.name;
            private set
            {
                Validator.ThrowIfStringIsNullOrWhiteSpace(value, GlobalConstants.InvalidNameErrorMessage);

                this.name = value;
            }
        }
        public double AverageRating
        {
            get
            {
                if(this.playersByName.Count == 0)
                {
                    return 0;
                }
               return Math.Round(this.playersByName.Values.Average(p => p.AverageSkillPoint));
            }
        }

        public void AddPlayer(Player player)
        {
            this.playersByName.Add(player.Name,player);

        }
        public void RemovePlayer(string playerName)
        { 
            if(!this.playersByName.ContainsKey(playerName))
            {
                throw new InvalidOperationException($"Player {playerName} is not in {this.Name} team.");
            }
            this.playersByName.Remove(playerName);
            
            }
    }
}
