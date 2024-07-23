using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Threading;
using System.Net;
using System.Net.Mail;

namespace Blood_Bank
{
    public partial class Director_Form : Form
    {
        public Director_Form()
        {
            InitializeComponent();
        }

        private void viewAdnEditAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread td = new Thread(openDirectorLoginForm);
            td.SetApartmentState(ApartmentState.STA);
            td.Start();
            this.Close();
        }

        public void Wait(int time)
        {
            Thread thread = new Thread(delegate ()
            {
                System.Threading.Thread.Sleep(time);
            });
            thread.Start();
            while (thread.IsAlive)
                Application.DoEvents();
        }

        private void openDirectorLoginForm()
        {
            Application.Run(new Director_Login_Form());
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Thread td = new Thread(goBackLoginForm);
            td.SetApartmentState(ApartmentState.STA);
            td.Start();
            this.Close();
        }

        private void goBackLoginForm()
        {
            Application.Run(new Form1());
        }

        private void backToTheMainMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread td = new Thread(backToMainMenu);
            td.SetApartmentState(ApartmentState.STA);
            td.Start();
            this.Close();
        }

        private void backToMainMenu()
        {
            Application.Run(new Form1());
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            //Wait(6000);
            try
            {
                int availableBloodUnit;
                string checkQuery = "select BloodStock from BloodTable where bloodType ='" + cmbBloodType.Text + "'";
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-ILF4RKJ\\MSSQLSERVER01;Initial Catalog=bloodBank;Integrated Security=True");
                SqlCommand cmd = new SqlCommand(checkQuery, con);
                con.Open();

                availableBloodUnit = Convert.ToInt32(cmd.ExecuteScalar());
                
                con.Close();
                MessageBox.Show(Convert.ToString(availableBloodUnit));

                if(cmbBloodType.SelectedIndex == 0)
                {
                    afterTransfered = availableBloodUnit - aP;
                }
                else if(cmbBloodType.SelectedIndex == 1)
                {
                    afterTransfered = availableBloodUnit - aN;
                }
                else if(cmbBloodType.SelectedIndex == 2)
                {
                    afterTransfered = availableBloodUnit - bP;
                }
                else if (cmbBloodType.SelectedIndex == 3)
                {
                    afterTransfered = availableBloodUnit - bN;
                }
                else if (cmbBloodType.SelectedIndex == 4)
                {
                    afterTransfered = availableBloodUnit - abP;
                }
                else if (cmbBloodType.SelectedIndex == 5)
                {
                    afterTransfered = availableBloodUnit - abN;
                }
                else if (cmbBloodType.SelectedIndex == 6)
                {
                    afterTransfered = availableBloodUnit - oP;
                }
                else if (cmbBloodType.SelectedIndex == 7)
                {
                    afterTransfered = availableBloodUnit - oN;
                }


                if (requestedBloodUnits.Value < availableBloodUnit)
                {

                    string insertQueryForTransfer = "insert into HospitalTransfer values ('" + cmbHospital.Text + "','" + cmbBloodType.Text + "'," + requestedBloodUnits.Value + ",'" + DateTime.Now.ToString("yyyy-M-d") + "')";
                    SqlCommand insertHospitalTransfer = new SqlCommand(insertQueryForTransfer,con);
                    con.Open();

                    insertHospitalTransfer.ExecuteNonQuery();

                    con.Close();

                    int minID = 0;
                   
                    string getMinID = "select min(ID) from bloodunit where bloodtype ='" + cmbBloodType.Text + "' and Transfered ='NO' and LabEligibility = 'YES'";
                    SqlCommand getIDCmd = new SqlCommand(getMinID,con);

                    for (int countLoop = 0; countLoop < requestedBloodUnits.Value; countLoop++)
                    {
                        con.Open();


                        //{
                        minID = Convert.ToInt32(getIDCmd.ExecuteScalar());

                        MessageBox.Show(Convert.ToString(minID));

                        //}




                        con.Close();

                        con.Open();
                        string updateQuery = "update bloodunit set Transfered ='YES' where ID =" + Convert.ToString(minID) + "";
                        SqlCommand updateCmd = new SqlCommand(updateQuery, con);
                        string getBloodBagIdQuery = "select bloodunitId from bloodunit where ID = " + Convert.ToString(minID) + "";
                        SqlCommand idCmd = new SqlCommand(getBloodBagIdQuery, con);
                        updateCmd.ExecuteNonQuery();

                        con.Close();
                    }
                    MessageBox.Show("Blood Transfered Was Successfully\nThose Blood Bags Sended To "+cmbHospital.Text+" and "+Convert.ToString(requestedBloodUnits.Value)+" Blood Bag//s were There\nSpecial Mail Has Sended To The Director Board","System Information",MessageBoxButtons.OK,MessageBoxIcon.Information);

                    


                }
                else
                {
                    MessageBox.Show("No more bloodBags for transfer","System Information",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    Thread td = new Thread(openDirectorForm);
                    td.SetApartmentState(ApartmentState.STA);
                    td.Start();
                    this.Close();
                }


                string sendMail;

                if(cmbHospital.SelectedIndex == 0)
                {
                    sendMail = "bloodbankproject555@gmail.com";
                }
                else if(cmbHospital.SelectedIndex == 1)
                {
                    sendMail = "chathushi2k17@gmail.com";
                }
                else if (cmbHospital.SelectedIndex == 2)
                {
                    sendMail = "Induwaraniudara@gmail.com";
                }
                else if (cmbHospital.SelectedIndex == 3)
                {
                    sendMail = "Thedanind@gmail.com";
                }
                else
                {
                    sendMail = "sonalijayarathne97@gmail.com";
                }


                string to = Convert.ToString(sendMail);
                string from = "navodhosts@gmail.com";


                string mailBody = "Director\n" + cmbHospital.Text + "\n\n\nDepends on your request we transfer " + cmbBloodType.Text + " " + Convert.ToString(requestedBloodUnits.Value) + " BLOOD BAGS \n\n\nDirector\nBlood Bank Kandy";
                //MessageBox.Show(donarDataArrayE[0]);
                //MessageBox.Show(donarDataArrayE[0].ToString());

                MailMessage msg = new MailMessage();
                msg.From = new MailAddress(from);
                msg.To.Add(to);
                msg.Subject = "BLOOD BANK KANDY | ABOUT TRANSFERING BLOOD BAGS";
                msg.Body = mailBody;

                SmtpClient smt = new SmtpClient();
                smt.Host = "smtp.gmail.com";
                smt.UseDefaultCredentials = true;
                System.Net.NetworkCredential ntcd = new NetworkCredential();
                ntcd.UserName = from;
                ntcd.Password = "ewxwkbzytywrpqjn";
                smt.Credentials = ntcd;
                smt.EnableSsl = true;
                smt.Port = 587;
                //smt.Send(msg);

                //MessageBox.Show("Your Mail is sended");

                try
                {
                    smt.Send(msg);
                    //smtp.Send(message);
                    MessageBox.Show("Email has sent to "+Convert.ToString(sendMail)+"");
                    
                }
                catch (Exception qwe)
                {
                    MessageBox.Show(qwe.Message);
                }

            }
            catch (Exception bloodTransferProcess)
            {
                MessageBox.Show(bloodTransferProcess.Message);
            }
        }

        private void openDirectorForm()
        {
            Application.Run(new Director_Form());
        }

        private void Director_Form_Load(object sender, EventArgs e)
        {

            cmbBloodType.Enabled = false;
            requestedBloodUnits.Enabled = false;
            btnTransfer.Enabled = false;
            btnClear.Enabled = false;

            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = (5 * 1000); // 10 secs
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }

        public int aP, aN, bP, bN, abP, abN, oP, oN, afterTransfered;

        private void userManualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread td = new Thread(openDirectorManualForm);
            td.SetApartmentState(ApartmentState.STA);
            td.Start();
        }

        private void openDirectorManualForm()
        {
            Application.Run(new Director_Manual());
        }

        private void aboutSoftwareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread td = new Thread(openAboutUSForm);
            td.SetApartmentState(ApartmentState.STA);
            td.Start();
        }

        private void openAboutUSForm()
        {
            Application.Run(new About_Software());
        }

        private void requestedBloodUnits_ValueChanged(object sender, EventArgs e)
        {
            if(requestedBloodUnits.Value > 0)
            {
                btnTransfer.Enabled = true;
            }
            else
            {
                btnTransfer.Enabled = false;
            }
        }

        private void cmbBloodType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbBloodType.Text.Length >0)
            {
                requestedBloodUnits.Enabled = true;
            }
            else
            {
                requestedBloodUnits.Enabled = false;
            }
        }

        private void cmbHospital_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbHospital.Text.Length >0)
            {
                cmbBloodType.Enabled = true;
                btnClear.Enabled = true;
            }
            else
            {
                cmbBloodType.Enabled = false;
                btnClear.Enabled = false;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cmbBloodType.SelectedIndex = -1;
            cmbHospital.SelectedIndex = -1;
            requestedBloodUnits.Value = 0;
            cmbHospital.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (var series in bloodUnitChart.Series)
            {
                series.Points.Clear();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bloodUnitChart.Series["Series1"].Points.AddXY("A+", 100);
            bloodUnitChart.Series["Series1"].Points.AddXY("A-", 45);
            bloodUnitChart.Series["Series1"].Points.AddXY("B+", 85);
            bloodUnitChart.Series["Series1"].Points.AddXY("A+", 67);
            bloodUnitChart.Series["Series1"].Points.AddXY("A+", 125);
            bloodUnitChart.Series["Series1"].Points.AddXY("A+", 100);
            bloodUnitChart.Series["Series1"].Points.AddXY("A+", 159);
            bloodUnitChart.Series["Series1"].Points.AddXY("A+", 132);

        }

        private void timer_Tick(object sender, EventArgs e)
        {
            
            try
            {
                string getAPBloodUnits = "select count(bloodunitId) from bloodunit where bloodType = 'A+' and Transfered = 'NO' and LabEligibility ='YES'";
                string getANBloodUnits = "select count(bloodunitId) from bloodunit where bloodType = 'A-' and Transfered = 'NO' and LabEligibility ='YES'";
                string getBPBloodUnits = "select count(bloodunitId) from bloodunit where bloodType = 'B+' and Transfered = 'NO' and LabEligibility ='YES'";
                string getBNBloodUnits = "select count(bloodunitId) from bloodunit where bloodType = 'B-' and Transfered = 'NO' and LabEligibility ='YES'";
                string getABPBloodUnits = "select count(bloodunitId) from bloodunit where bloodType = 'AB+' and Transfered = 'NO' and LabEligibility ='YES'";
                string getABNBloodUnits = "select count(bloodunitId) from bloodunit where bloodType = 'AB-' and Transfered = 'NO' and LabEligibility ='YES'";
                string getOPBloodUnits = "select count(bloodunitId) from bloodunit where bloodType = 'O+' and Transfered = 'NO' and LabEligibility ='YES'";
                string getONBloodUnits = "select count(bloodunitId) from bloodunit where bloodType = 'O-' and Transfered = 'NO' and LabEligibility ='YES'";

                SqlConnection con = new SqlConnection("Data Source=DESKTOP-ILF4RKJ\\MSSQLSERVER01;Initial Catalog=bloodBank;Integrated Security=True");
                SqlCommand aPC = new SqlCommand(getAPBloodUnits, con);
                SqlCommand aNC = new SqlCommand(getANBloodUnits, con);
                SqlCommand bPC = new SqlCommand(getBPBloodUnits, con);
                SqlCommand bNC = new SqlCommand(getBNBloodUnits, con);
                SqlCommand abPC = new SqlCommand(getABPBloodUnits, con);
                SqlCommand abNC = new SqlCommand(getABNBloodUnits, con);
                SqlCommand oPC = new SqlCommand(getOPBloodUnits, con);
                SqlCommand oNC = new SqlCommand(getONBloodUnits, con);

                con.Open();

                aP = Convert.ToInt32(aPC.ExecuteScalar());
                aN = Convert.ToInt32(aNC.ExecuteScalar());
                bP = Convert.ToInt32(bPC.ExecuteScalar());
                bN = Convert.ToInt32(bNC.ExecuteScalar());
                abP = Convert.ToInt32(abPC.ExecuteScalar());
                abN = Convert.ToInt32(abNC.ExecuteScalar());
                oP = Convert.ToInt32(oPC.ExecuteScalar());
                oN = Convert.ToInt32(oNC.ExecuteScalar());

                string updateAP = "update BloodTable set BloodStock =" + aP + "where bloodType ='A+'";
                string updateAN = "update BloodTable set BloodStock =" + aN + "where bloodType ='A-'";
                string updateBP = "update BloodTable set BloodStock =" + bP + "where bloodType ='B+'";
                string updateBN = "update BloodTable set BloodStock =" + bN + "where bloodType ='B-'";
                string updateABP = "update BloodTable set BloodStock =" + abP + "where bloodType ='AB+'";
                string updateABN = "update BloodTable set BloodStock =" + abN + "where bloodType ='AB-'";
                string updateOP = "update BloodTable set BloodStock =" + oP + "where bloodType ='O+'";
                string updateON = "update BloodTable set BloodStock =" + oN + "where bloodType ='O-'";

                SqlCommand cmd1 = new SqlCommand(updateAP,con);
                SqlCommand cmd2 = new SqlCommand(updateAN,con);
                SqlCommand cmd3 = new SqlCommand(updateBP,con);
                SqlCommand cmd4 = new SqlCommand(updateBN,con);
                SqlCommand cmd5 = new SqlCommand(updateABP,con);
                SqlCommand cmd6 = new SqlCommand(updateABN,con);
                SqlCommand cmd7 = new SqlCommand(updateOP,con);
                SqlCommand cmd8 = new SqlCommand(updateON,con);

                cmd1.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();
                cmd3.ExecuteNonQuery();
                cmd4.ExecuteNonQuery();
                cmd5.ExecuteNonQuery();
                cmd6.ExecuteNonQuery();
                cmd7.ExecuteNonQuery();
                cmd8.ExecuteNonQuery();

                con.Close();

                foreach (var series in bloodUnitChart.Series)
                {
                    series.Points.Clear();
                }

                bloodUnitChart.Series["Series1"].Points.AddXY("A+", aP);
                bloodUnitChart.Series["Series1"].Points.AddXY("A-", aN);
                bloodUnitChart.Series["Series1"].Points.AddXY("B+", bP);
                bloodUnitChart.Series["Series1"].Points.AddXY("B-", bN);
                bloodUnitChart.Series["Series1"].Points.AddXY("AB+", abP);
                bloodUnitChart.Series["Series1"].Points.AddXY("AB-", abN);
                bloodUnitChart.Series["Series1"].Points.AddXY("O+", oP);
                bloodUnitChart.Series["Series1"].Points.AddXY("O+", oN);

                string fillHospitalQuery = "select * from HospitalTransfer";
                SqlDataAdapter adp = new SqlDataAdapter(fillHospitalQuery,con);

                DataTable td = new DataTable();
                adp.Fill(td);

                dataGridView1.DataSource = td;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;



                string fillBloodUnitsQuery = "select * from BloodTable";
                SqlDataAdapter adp1 = new SqlDataAdapter(fillBloodUnitsQuery, con);

                DataTable td1 = new DataTable();
                adp1.Fill(td1);

                dataGridView2.DataSource = td1;
                dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


            }
            catch(Exception updateRuntime)
            {
                MessageBox.Show(updateRuntime.Message);
            }

        }
    }
}
