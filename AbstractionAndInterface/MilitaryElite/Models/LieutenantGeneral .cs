

using MilitaryElite.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MilitaryElite.Models
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        private List<IPrivate> privates;
        //	LieutenantGeneral - holds a set of Privates under his command.
        public LieutenantGeneral(string id, string firstName, string lastName, decimal salary)
            : base(id, firstName, lastName, salary)
        {

            this.privates = new List<IPrivate>();
        }

        public IReadOnlyCollection<IPrivate> Privates { get =>this.privates.AsReadOnly() ; }

        public void AddPrivate(IPrivate @private)
        {
            this.privates.Add(@private);
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString()); // Salary go vzema ot Private
                sb.AppendLine("Privates:");
            if(privates.Any())
            {
                foreach (var @private in this.privates)
                {
                    sb.AppendLine($"  {@private}");
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}
