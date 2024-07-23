using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace Blood_Bank
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Timer timer = new Timer();
            timer.Interval = (10 * 1000); // 10 secs
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            
            string date = DateTime.Now.ToString("yyyy-M-d");
            string query = "select min(TokenNumber) from Token where Status = 'NEW'";
            string maxNewQuery = "select max(TokenNumber) from Token where Status = 'NEW'";
            string servingTokenquery = "select max(TokenNumber) from Token where Status = 'SERVING'";

            try
            {
                int minNew, maxNew;

                SqlConnection connection = new SqlConnection("Data Source=DESKTOP-ILF4RKJ\\MSSQLSERVER01;Initial Catalog=bloodBank;Integrated Security=True");
                //string getIdQuery = "select DonarID from Donar where NIC = '46212'";
                SqlCommand getMinToken = new SqlCommand(query, connection);
                SqlCommand getMaxNewToken = new SqlCommand(maxNewQuery, connection);
                SqlCommand getServingTokenNumber = new SqlCommand(servingTokenquery,connection);
                connection.Open();

                string maxNewString = Convert.ToString(getMaxNewToken.ExecuteScalar());
                string token = Convert.ToString(getMinToken.ExecuteScalar());
                string tokenServing = Convert.ToString(getServingTokenNumber.ExecuteScalar());
                connection.Close();

                minNew = Convert.ToInt32(token);
                maxNew = Convert.ToInt32(maxNewString);
                
                if (token.Length > 0)
                {
                    lblCurrent.Text = token.ToString();
               
                }
                else
                {
                    lblCurrent.Text = "NULL";
                }

                if (tokenServing.Length > 0)
                {
                    lbl3.Text = tokenServing.ToString();
                }
                else
                {
                    lbl3.Text = "NULL";
                }

                

                int nextToken = Convert.ToInt32(token) + 1;

                

                int maxAvailableToken;

                string nextTokenQuery = "select max(TokenNumber) from Token where TokenDate= '" + date + "' and Status ='NEW'";

                SqlCommand nextTokenCommand = new SqlCommand(nextTokenQuery,connection);

                connection.Open();

                maxAvailableToken = Convert.ToInt32(nextTokenCommand.ExecuteScalar());

                connection.Close();

                if(nextToken <= maxAvailableToken)
                {
                    lblNextToken.Text = Convert.ToString(nextToken);
                }
                else
                {
                    lblNextToken.Text = "NULL";
                    
                }
            }
            catch(Exception token)
            {
                this.Close();
                MessageBox.Show("a");
                MessageBox.Show(token.Message);
            }

            

        }

    }
}
