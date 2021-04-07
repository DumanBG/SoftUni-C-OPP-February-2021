using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Contracts
{
   public interface IPrivate : ISoldier 
    {
        //o	Private - lowest base Soldier type, holding the salary(decimal). 

        public decimal Salary { get; }

    }
}
