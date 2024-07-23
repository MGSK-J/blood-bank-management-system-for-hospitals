using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blood_Bank
{
    class Admin : Person
    {
        private void setUserNamePassword()
        {
            setUserName("RooT");
            setUserPassword("TooR");
        }

        public Admin()
        {
            setUserNamePassword();
        }

        public override bool userLogin(string userName, string password)
        {
            if (userName == getUserName() && password == getPassword())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
