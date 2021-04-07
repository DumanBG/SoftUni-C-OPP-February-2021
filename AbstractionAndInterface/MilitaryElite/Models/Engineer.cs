using MilitaryElite.Contracts;
using MilitaryElite.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MilitaryElite.Models
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {

        private List<IRepair> repairs;
        public Engineer(string id, string firstName, string lastName, decimal salary, Corps corps) 
            : base(id, firstName, lastName, salary, corps)
        {
            this.repairs = new List<IRepair>();
        }

        public IReadOnlyCollection<IRepair> Repairs => this.repairs.AsReadOnly();

        

        public void AddRepair(IRepair repair)
        {
            repairs.Add(repair);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
           sb.AppendLine(base.ToString());

                sb.AppendLine("Repairs:");
            if(repairs.Any())
            {
                foreach (var item in repairs)
                {
                    sb.AppendLine($"  {item}");
                }
            }
            return sb.ToString().TrimEnd();
        }
    }
}
