using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Telephony
{
    public static class Validator
    {
        public static void ThrowIfNumberIsInvalid(string phoneNumber)
        {
            if (phoneNumber.Any(x => !char.IsDigit(x)))
            {
                throw new InvalidOperationException("Invalid number!");
            }
        }

        public static void ThrowIfUrlIsInvalid(string url)
        {
            if (url.Any(char.IsNumber))
            {

                throw new InvalidOperationException("Invalid URL!");
            }

        }
    }
}
