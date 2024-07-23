using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blood_Bank
{
    static class Otp
    {
        private static int otpNumber;


        public static int getOtpNumber()
        {
            return otpNumber;
        }

        public static int generateRandomNumber()
        {
            Random randomNumber = new Random();
            otpNumber = randomNumber.Next(0,9999);
            return otpNumber;
        }
    }
}
