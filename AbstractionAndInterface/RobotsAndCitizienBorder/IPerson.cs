using System;
using System.Collections.Generic;
using System.Text;

namespace PersonInfo
{
   public interface IPerson : IIdentifiable
    {

        string Name { get; } // Само през Ctor-a да се имплементира
        int Age { get; }
    }
}
