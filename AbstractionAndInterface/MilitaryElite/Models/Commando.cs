using MilitaryElite.Contracts;
using MilitaryElite.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MilitaryElite.Models
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        private List<IMission> missions;
        public Commando(string id, string firstName, string lastName, decimal salary, Corps corps) 
            : base(id, firstName, lastName, salary, corps)
        {
            this.missions = new List<IMission>();
        }

        public IReadOnlyCollection<IMission> Mission => this.missions.AsReadOnly();

       

        

        public void AddMission(IMission mission)
        {
            missions.Add(mission);
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
          sb.AppendLine(base.ToString());
            sb.AppendLine("Missions:");
            if(missions.Any())
            {
                foreach (var item in missions)
                {
                    sb.AppendLine($"  {item.ToString()}");
                }
            }
            return sb.ToString().TrimEnd();
        }
    }
}
