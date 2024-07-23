using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blood_Bank
{
    class Person
    {
        protected string userID;
        protected string firstName;
        protected string lastName;
        protected string userName;
        protected string userPassword;
        protected string userStage;

        public void setFirstName(string value)
        {
            this.firstName = value;
        }
        public void setLastName(string value)
        {
            this.lastName = value;
        }
        public void setUserName(string value)
        {
            this.userName = value;
        }
        public void setUserPassword(string value)
        {
            this.userPassword = value;
        }
        public void setUserStage(string value)
        {
            this.userStage = value;
        }
        //setters
        public string getUserName() { return userName; }
        public string getPassword() { return userPassword; }
        public string getFirstName() { return firstName; }
        public string getLastName() { return lastName; }
        public string getUserStage() { return userStage; }
        public string getUserID() { return userID; }
        public virtual bool userLogin(string value1, string value2) { return false; }
        public virtual bool userLogin(string value1, string value2, string value3) { return false; }
    }
}
