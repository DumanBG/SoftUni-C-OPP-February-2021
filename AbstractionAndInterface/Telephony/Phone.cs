using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    
    public abstract class Phone : ICallable
    {

        //public Phone(string phoneNumber)
        //{
        //    this.PhoneNumber = phoneNumber;
        //}
        //protected string PhoneNumber { get; }



        public abstract string Call(string number);

       
    }
}
