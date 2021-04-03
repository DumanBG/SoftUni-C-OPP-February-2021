using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Telephony
{
    public class Smartphone : Phone, IBrowsable
    {
        private const string CallOrDialing = "Calling";

        //public Smartphone(string phoneNumber) :base(phoneNumber)
        //{

        //}

        public override string Call(string phoneNumber)
        {
            Validator.ThrowIfNumberIsInvalid(phoneNumber);
           string result =$"{CallOrDialing}... {phoneNumber}";
            return result;
        }

        

        public string Browse(string url)
        {
            Validator.ThrowIfUrlIsInvalid(url);
          return $"Browsing: {url}!";
        }
    }
}
