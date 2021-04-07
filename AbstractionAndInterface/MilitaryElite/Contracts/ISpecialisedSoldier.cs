using MilitaryElite.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Contracts
{
   public interface ISpecialisedSoldier : IPrivate
    {
        //	SpecialisedSoldier - general class for all specialised Soldiers - holds the corps of the Soldier. The corps can only be one of the following: Airforces or Marines.

       

        Corps Corps { get; } // Вземане на enum AirForce or Marines
    }
}
