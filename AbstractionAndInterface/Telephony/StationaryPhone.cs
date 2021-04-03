using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    
    public class StationaryPhone : Phone
    {
        private const string CallOrDialing = "Dialing";
        //public StationaryPhone(string phoneNumber) :base(phoneNumber)
        //{

        //}

        public override string Call(string phoneNumber)
        {

            Validator.ThrowIfNumberIsInvalid(phoneNumber);
            return $"{CallOrDialing}... {phoneNumber}";
        }
    }
}
