using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Blood_Bank
{
    static class Token
    {
        private static int tokenNumber;

        public static int getTokenNumber()
        {
            return tokenNumber;
        }

        public static void generateTokenNumber()
        {
            
            try
            {
                string dateToday = DateTime.Now.ToString("yyyy-M-d");
                int todayToken = 0;
                string checkToken = "select max(TokenNumber) from Token where TokenDate ='" + dateToday + "'";
                //string getMaxToken = "select max(TokenNumber) from Token";
                

                SqlConnection con = new SqlConnection("Data Source=DESKTOP-ILF4RKJ\\MSSQLSERVER01;Initial Catalog=bloodBank;Integrated Security=True");
                SqlCommand cmd = new SqlCommand(checkToken, con);
                //SqlCommand getCurrentToken = new SqlCommand(getMaxToken,con);
                con.Open();

                todayToken = Convert.ToInt32(cmd.ExecuteScalar());
                //currentToken = Convert.ToInt32(getCurrentToken.ExecuteScalar());

                con.Close();

                if (todayToken == 0)
                {
                    tokenNumber = 1;
                }
                else if (todayToken > 0)
                {
                    tokenNumber = todayToken + 1;
                }

                
            }
            catch(Exception e)
            {

            }

        }
    }
}
