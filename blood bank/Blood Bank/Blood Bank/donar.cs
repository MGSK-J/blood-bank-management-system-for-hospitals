using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blood_Bank
{
    class donar
    {
        public string nic;
        public string firstName;
        public string lastName;
        public string telephone;
        public string address;
        public string eMail;
        public string dob;

        public void setDonarValues(string firstName, string lastName, string telephone, string address, string eMail, string dob)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.telephone = telephone;
            this.address = address;
            this.eMail = eMail;
            this.dob = dob;
        }

    }
}
