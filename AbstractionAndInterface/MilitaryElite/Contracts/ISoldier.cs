using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Contracts
{
    // Soldier = general class for Soldiers, holding Id, first name and last name
    public interface ISoldier
    {
        string Id { get; }
        string FirstName { get; }
        string LastName { get; }


    }
}
