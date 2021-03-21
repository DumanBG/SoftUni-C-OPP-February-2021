using System;
using System.Collections.Generic;
using System.Text;

namespace FootballTeamGenerator
{
    public static class Validator
    {

        public static void  ThrowIfStringIsNullOrWhiteSpace(string value,string exceptMsg)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException(exceptMsg);
            }


        }

        public static void ThrowIfIsNotInRange(int min, int max, int value)
        {
            if(value <min || value >max)
            {
                throw new ArgumentException($"{nameof(value)} should be between {min} and {max}.");
            }

        }
    }
}
