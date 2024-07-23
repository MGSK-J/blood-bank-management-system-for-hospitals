using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Blood_Bank
{
    class Doctor_Login : Person
    {
        public override bool userLogin(string textUserId, string textPassword, string textUserName)
        {
            string dbUserName;
            string dbPassword;
            string empMode;
            string getUserPasswordQuery = "select userPassword from employee where UserID = '" + textUserId + "'";
            string getUserUserNameQuery = "select userName from employee where UserID = '" + textUserId + "'";
            string getEmpModeQuery = "select empMode from employee where  UserID = '" + textUserId + "'";

            SqlConnection loginConnection = new SqlConnection("Data Source=DESKTOP-ILF4RKJ\\MSSQLSERVER01;Initial Catalog=bloodBank;Integrated Security=True");
            SqlCommand loginPasswordCommand = new SqlCommand(getUserPasswordQuery, loginConnection);
            SqlCommand loginUserNameCommand = new SqlCommand(getUserUserNameQuery, loginConnection);
            SqlCommand empModeCommand = new SqlCommand(getEmpModeQuery, loginConnection);

            loginConnection.Open();
            dbPassword = Convert.ToString(loginPasswordCommand.ExecuteScalar());
            dbUserName = Convert.ToString(loginUserNameCommand.ExecuteScalar());
            empMode = Convert.ToString(empModeCommand.ExecuteScalar());
            loginConnection.Close();

            if (dbPassword.Length == 0 || dbUserName.Length == 0)
            {
                return false;
            }
            else if (dbPassword == textPassword && dbUserName == textUserName && empMode == "Doctor")
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
