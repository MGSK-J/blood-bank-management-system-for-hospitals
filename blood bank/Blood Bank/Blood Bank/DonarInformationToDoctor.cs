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
    public partial class DonarInformationToDoctor : Form
    {
        public DonarInformationToDoctor()
        {
            InitializeComponent();
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void DonarInformationToDoctor_Load(object sender, EventArgs e)
        {
            btnDonate.Enabled = false;
            txtEditNic.Text = Clipboard.GetText();
            txtEditNic.Enabled = false;
            btnClear.Enabled = false;
            cmbUpdateBloodType.Enabled = false;
            txtUpdateWeight.Enabled = false;
            txtUpdateTemp.Enabled = false;
            txtUpdatePulses.Enabled = false;
            txtUpdateSy.Enabled = false;
            txtUpdateDi.Enabled = false;
            txtUpdateHemoglobin.Enabled = false;
            
            btnUpdate.Enabled = false;
            chkUpdateConfirm.Enabled = false;

            try
            {
                SqlConnection connectionForDonar = new SqlConnection("Data Source=DESKTOP-ILF4RKJ\\MSSQLSERVER01;Initial Catalog=bloodBank;Integrated Security=True");

                bool isClerk = false;
                bool isDoctor = false;
                string resultFunc1, resultFunc2;

                string checkDonateFunc1 = "select Pre_donationEligibility from DonarEligibility where DonarNIC ='" + txtEditNic.Text + "' and DDate = '" + DateTime.Now.ToString("yyyy-M-d") + "'";
                string checkDonateFunc2 = "select ClerkEligibility from DonarEligibility where DonarNIC ='" + txtEditNic.Text + "' and DDate = '" + DateTime.Now.ToString("yyyy-M-d") + "'";

                SqlCommand func1 = new SqlCommand(checkDonateFunc1,connectionForDonar);
                SqlCommand func2 = new SqlCommand(checkDonateFunc2, connectionForDonar);

                connectionForDonar.Open();

                resultFunc1 = Convert.ToString(func1.ExecuteScalar());
                resultFunc2 = Convert.ToString(func2.ExecuteScalar());

                connectionForDonar.Close();


                if(resultFunc1 == "True")
                {
                    isDoctor = true;
                }
                if(resultFunc2 == "True")
                {
                    isClerk = true;
                }

                if(isClerk && isDoctor)
                {
                    btnDonate.Enabled = true;
                }
                else
                {
                    btnDonate.Enabled = false;
                }

                string[] donarDataArray = new string[7];

                
                string getDonarValuesQuery = "select FirstName,LastName,Telephone,DonarAddress,DOB,Gender,EMail from Donar where NIC ='" + txtEditNic.Text + "'";

                SqlCommand getDonarValues = new SqlCommand(getDonarValuesQuery, connectionForDonar);

                connectionForDonar.Open();

                SqlDataReader readDonar = getDonarValues.ExecuteReader();
                readDonar.Read();

                donarDataArray[0] = Convert.ToString(readDonar[0]);
                donarDataArray[1] = Convert.ToString(readDonar[1]);
                donarDataArray[2] = Convert.ToString(readDonar[2]);
                donarDataArray[3] = Convert.ToString(readDonar[3]);
                donarDataArray[4] = Convert.ToString(readDonar[4]);
                donarDataArray[5] = Convert.ToString(readDonar[5]);
                donarDataArray[6] = Convert.ToString(readDonar[6]);
                connectionForDonar.Close();


                txtEditFirstName.Text = donarDataArray[0];
                txtEditLastName.Text = donarDataArray[1];
                dtpEditDob.Text = donarDataArray[4];
                txtEditAge.Text = donarDataArray[6];

                if (donarDataArray[5] == "M")
                {
                    rbtnEditMale.Checked = true;
                }
                else if (donarDataArray[5] == "F")
                {
                    rbtnEditFemale.Checked = true;
                }
                else
                {
                    rbtnEditMale.Checked = false;
                    rbtnEditFemale.Checked = false;
                }

                //txtEditFirstName.Enabled = false;
                //txtEditLastName.Enabled = false;
                //txtEditValues.Enabled = false;
                //dtpEditDob.Enabled = false;
                rbtnEditMale.Enabled = false;
                rbtnEditFemale.Enabled = false;
                // txtEditEmail.Enabled = false;

                txtEditFirstName.ReadOnly = true;
                txtEditLastName.ReadOnly = true;
                dtpEditDob.MinDate = dtpEditDob.Value;
                dtpEditDob.MaxDate = dtpEditDob.Value;
                txtEditAge.ReadOnly = true;
                txtEditNic.ReadOnly = true;

                string getBirthday = "select DOB from Donar where NIC ='" + txtEditNic.Text + "'";


                SqlConnection con = new SqlConnection("Data Source=DESKTOP-ILF4RKJ\\MSSQLSERVER01;Initial Catalog=bloodBank;Integrated Security=True");
                SqlCommand cmd = new SqlCommand(getBirthday, con);
                con.Open();

                string birthDay = Convert.ToString(cmd.ExecuteScalar());
                DateTime getBirthYear = Convert.ToDateTime(birthDay);
                int donarAge = Convert.ToInt32(DateTime.Now.ToString("yyyy")) - Convert.ToInt32(getBirthYear.Year);

                txtEditAge.Text = Convert.ToString(donarAge);

                con.Close();

                string [] storeEligibilityData = new string[7];
                string getEligibilityData = "select temp,pulses,systolicbp,diastolicbp,dweight,hemoglobin,bloodType from PredonationEligibility where DonarNIC ='" + txtEditNic.Text + "' and DDate = '" + DateTime.Now.ToString("yyyy-M-d") + "'";
                SqlCommand eligibilityCommand = new SqlCommand(getEligibilityData,connectionForDonar);

                connectionForDonar.Open();

                SqlDataReader rdr = eligibilityCommand.ExecuteReader();
                rdr.Read();

                storeEligibilityData[0] = Convert.ToString(rdr[0]);
                storeEligibilityData[1] = Convert.ToString(rdr[1]);
                storeEligibilityData[2] = Convert.ToString(rdr[2]);
                storeEligibilityData[3] = Convert.ToString(rdr[3]);
                storeEligibilityData[4] = Convert.ToString(rdr[4]);
                storeEligibilityData[5] = Convert.ToString(rdr[5]);
                storeEligibilityData[6] = Convert.ToString(rdr[6]);

                connectionForDonar.Close();


                txtTemp.Text = storeEligibilityData[0];
                txtPluses.Text = storeEligibilityData[1];
                txtSbp.Text = storeEligibilityData[2];
                txtDbp.Text = storeEligibilityData[3];
                txtWeight.Text = storeEligibilityData[4];
                txtHemoglobin.Text = storeEligibilityData[5];
                txtBloodType.Text = storeEligibilityData[6];

                txtTemp.ReadOnly = true;
                txtPluses.ReadOnly = true;
                txtSbp.ReadOnly = true;
                txtDbp.ReadOnly = true;
                txtWeight.ReadOnly = true;
                txtHemoglobin.ReadOnly = true;
                txtBloodType.ReadOnly = true;

                string eligibleQuery = "select Pre_donationEligibility from DonarEligibility where DonarNIC ='" + txtEditNic.Text + "' and DDate ='" + DateTime.Now.ToString("yyy-M-d") + "'";
                string status;

                SqlCommand getStatusEligibility = new SqlCommand(eligibleQuery,con);
                con.Open();

                status = Convert.ToString(getStatusEligibility.ExecuteScalar());

                con.Close();

                lblEligibility.Text = status;

            }
            catch(Exception loadDonarDetails)
            {
                MessageBox.Show(loadDonarDetails.Message);
            }

        }

        private void chkUpdate_CheckedChanged(object sender, EventArgs e)
        {
            if(chkUpdate.Checked)
            {
                cmbUpdateBloodType.Enabled = true;
                btnDonate.Enabled = false;
            }
            else
            {
                cmbUpdateBloodType.Enabled = false;
                //btnDonate.Enabled = false;
            }
        }

        private void cmbUpdateBloodType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbUpdateBloodType.SelectedIndex == 0 || cmbUpdateBloodType.SelectedIndex == 1 || cmbUpdateBloodType.SelectedIndex == 2 || cmbUpdateBloodType.SelectedIndex == 3 || cmbUpdateBloodType.SelectedIndex == 4 || cmbUpdateBloodType.SelectedIndex == 5 || cmbUpdateBloodType.SelectedIndex == 6 || cmbUpdateBloodType.SelectedIndex == 7)
            {
                txtUpdateWeight.Enabled = true;
            }
            else
            {
                txtUpdateWeight.Enabled = false;
            }

            if(cmbUpdateBloodType.Text.Length > 0)
            {
                btnClear.Enabled = true;
            }
            else
            {
                btnClear.Enabled = false;
            }

        }

        private void txtUpdateWeight_TextChanged(object sender, EventArgs e)
        {
            if (txtUpdateWeight.TextLength > 0)
            {
                txtUpdateTemp.Enabled = true;
                
            }
            else
            {
                txtUpdateTemp.Enabled = false;
            }
        }

        private void txtUpdateTemp_TextChanged(object sender, EventArgs e)
        {
            if (txtUpdateTemp.TextLength > 0)
            {
                txtUpdatePulses.Enabled = true;
            }
            else
            {
                txtUpdatePulses.Enabled = false;
            }
        }

        private void txtUpdatePulses_TextChanged(object sender, EventArgs e)
        {
            if (txtUpdatePulses.TextLength > 0)
            {
                txtUpdateSy.Enabled = true;
            }
            else
            {
                txtUpdateSy.Enabled = false;
            }
        }

        private void txtUpdateSy_TextChanged(object sender, EventArgs e)
        {
            if (txtUpdateSy.TextLength > 0)
            {
                txtUpdateDi.Enabled = true;
            }
            else
            {
                txtUpdateDi.Enabled = false;
            }
        }

        private void txtUpdateDi_TextChanged(object sender, EventArgs e)
        {
            if (txtUpdateDi.TextLength > 0)
            {
                txtUpdateHemoglobin.Enabled = true;
            }
            else
            {
                txtUpdateHemoglobin.Enabled = false;
            }
        }

        private void txtUpdateHemoglobin_TextChanged(object sender, EventArgs e)
        {
            if (txtUpdateHemoglobin.TextLength > 0)
            {
                chkUpdateConfirm.Enabled = true;
            }
            else
            {
                chkUpdateConfirm.Enabled = false;
            }
        }

        private void chkUpdateConfirm_CheckedChanged(object sender, EventArgs e)
        {
            if (chkUpdateConfirm.Checked)
            {
                btnUpdate.Enabled = true;
            }
            else
            {
                btnUpdate.Enabled = false;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string updateQuery = "update PredonationEligibility set temp='" + txtUpdateTemp.Text + "',pulses='" + txtUpdatePulses.Text + "', systolicbp ='" + txtUpdateSy.Text + "', diastolicbp = '" + txtUpdateDi.Text + "', dweight = '" + txtUpdateWeight.Text + "', hemoglobin ='" + txtUpdateHemoglobin.Text + "', bloodType ='" + cmbUpdateBloodType.Text + "' where DonarNIC = '" + txtEditNic.Text + "' and DDate ='" + DateTime.Now.ToString("yyyy-M-d") + "'";

                SqlConnection con = new SqlConnection("Data Source=DESKTOP-ILF4RKJ\\MSSQLSERVER01;Initial Catalog=bloodBank;Integrated Security=True");
                SqlCommand cmd = new SqlCommand(updateQuery, con);

                con.Open();

                cmd.ExecuteNonQuery();

                con.Close();

                MessageBox.Show("Data Has Updated","System Information",MessageBoxButtons.OK,MessageBoxIcon.Information);

                float hemoglobin = float.Parse(txtUpdateHemoglobin.Text);
                float weight = float.Parse(txtUpdateWeight.Text);

                string preEgiligility = "False";

                

                if (rbtnEditMale.Checked)
                {
                    if (Convert.ToInt32(txtEditAge.Text) > 18 && Convert.ToInt32(txtEditAge.Text) < 60 && Convert.ToInt32(txtUpdateTemp.Text) == 37 && weight >= 45 && Convert.ToInt32(txtUpdatePulses.Text) >= 60 && Convert.ToInt32(txtUpdatePulses.Text) <= 100 && Convert.ToInt32(txtUpdateSy.Text) < 120 && Convert.ToInt32(txtUpdateDi.Text) < 80 && hemoglobin >=13.5 && hemoglobin <= 17.5)
                    {
                        preEgiligility = "True";
                    }
                    else
                    {
                        preEgiligility = "False";
                    }
                }
                
                
                if (rbtnEditFemale.Checked)
                {
                    if (Convert.ToInt32(txtEditAge.Text) > 18 && Convert.ToInt32(txtEditAge.Text) < 60 && Convert.ToInt32(txtUpdateTemp.Text) == 37 && weight >= 45 && Convert.ToInt32(txtUpdatePulses.Text) >= 60 && Convert.ToInt32(txtUpdatePulses.Text) <= 100 && Convert.ToInt32(txtUpdateSy.Text) < 120 && Convert.ToInt32(txtUpdateDi.Text) < 80 && hemoglobin >= 12.0 && hemoglobin <= 15.5)
                    {
                        preEgiligility = "True";
                    }
                    else
                    {
                        preEgiligility = "False";
                    }
                }

                string insertEligibilityQuery = "update DonarEligibility set Pre_donationEligibility = '" + preEgiligility + "' where DonarNIC ='" + txtEditNic.Text + "' and DDate ='" + DateTime.Now.ToString("yyyy-M-d") + "'";

                try
                {
                    SqlCommand insertEligibility = new SqlCommand(insertEligibilityQuery, con);
                    con.Open();

                    insertEligibility.ExecuteNonQuery();

                    con.Close();
                }
                catch (Exception insertEligibilityException)
                {
                    MessageBox.Show(insertEligibilityException.Message);
                }

                

                txtBloodType.Text = cmbUpdateBloodType.Text;
                cmbUpdateBloodType.Enabled = false;
                //cmbUpdateBloodType.SelectedIndex = -1;

                txtTemp.Text = txtUpdateTemp.Text;
                txtUpdateTemp.ReadOnly = true;
                txtUpdateTemp.Enabled = false;

                txtWeight.Text = txtUpdateWeight.Text;
                txtUpdateWeight.ReadOnly = true;
                txtUpdateWeight.Enabled = false;

                txtPluses.Text = txtUpdatePulses.Text;
                txtUpdatePulses.ReadOnly = true;
                txtUpdatePulses.Enabled = false;

                txtSbp.Text = txtUpdateSy.Text;
                txtUpdateSy.ReadOnly = true;
                txtUpdateSy.Enabled = false;

                txtDbp.Text = txtUpdateDi.Text;
                txtUpdateDi.ReadOnly = true;
                txtUpdateDi.Enabled = false;

                txtHemoglobin.Text = txtUpdateHemoglobin.Text;
                txtUpdateHemoglobin.ReadOnly = true;
                txtUpdateHemoglobin.Enabled = false;

                chkUpdateConfirm.Enabled = false;
                chkUpdateConfirm.Checked = false;
                btnUpdate.Enabled = false;

                string valid;
                string getEligibilityValue = "select Pre_donationEligibility from DonarEligibility where DonarNIC ='" + txtEditNic.Text + "' and DDate = '" + DateTime.Now.ToString("yyyy-M-d") + "'";
                SqlCommand getEligibility = new SqlCommand(getEligibilityValue,con);

                con.Open();

                valid = Convert.ToString(getEligibility.ExecuteScalar());

                con.Close();

                if(valid == "True")
                {
                    MessageBox.Show("This Donar Is Eligible for Donate Blood");
                    btnDonate.Enabled = true;
                }
                if (valid == "False")
                {
                    MessageBox.Show("This Donar Is Not Eligible for Donate Blood");
                }
            }
            catch(Exception updateEligibility)
            {
                MessageBox.Show(updateEligibility.Message);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {

            try
            {

                string[] eligibilityStatus = new string[2];

                string getStatusQuery = "select ClerkEligibility,Pre_donationEligibility from DonarEligibility where DonarNIC ='" + txtEditNic.Text + "' and DDate ='" + DateTime.Now.ToString("yyyy-M-d") + "'";
                string mailStatus;

                string[] mailBodyData = new string[10];
                string mailAddress;

                string getMailAddress = "select EMail from Donar where NIC ='" + txtEditNic.Text + "'";

                string getTestReportdata = "select * from PredonationEligibility where DonarNIC ='" + txtEditNic.Text + "' and DDate ='" + DateTime.Now.ToString("yyyy-M-d") + "'";

                SqlConnection connectionForMail = new SqlConnection("Data Source=DESKTOP-ILF4RKJ\\MSSQLSERVER01;Initial Catalog=bloodBank;Integrated Security=True");
                SqlCommand getReport = new SqlCommand(getTestReportdata,connectionForMail);
                SqlCommand email = new SqlCommand(getMailAddress,connectionForMail);
                SqlCommand getStatus = new SqlCommand(getStatusQuery,connectionForMail);

                connectionForMail.Open();

                

                mailAddress = Convert.ToString(email.ExecuteScalar());
                SqlDataReader readDataForMail = getReport.ExecuteReader();
                readDataForMail.Read();

                for(int countValue = 0; countValue < 10; countValue++)
                {
                    mailBodyData[countValue] = Convert.ToString(readDataForMail[countValue]);
                }

                connectionForMail.Close();


                connectionForMail.Open();

                SqlDataReader readStatus = getStatus.ExecuteReader();
                readStatus.Read();

                eligibilityStatus[0] = Convert.ToString(readStatus[0]);
                eligibilityStatus[1] = Convert.ToString(readStatus[1]);

                connectionForMail.Close();


                if (eligibilityStatus[0] == "True" && eligibilityStatus[1] == "True")
                {
                    mailStatus = "You are Eligibility for Donate Blood(*Pass The Test)";
                }
                else
                {
                    mailStatus = "You Are Failed At The Following Test.we recommended you to meet doctor";
                }

                string mailBody = "\tThis is a soft copy of your test\nmake sure you can get hard copy of this one at counter 1\n\n\nDonar NIC : " + mailBodyData[0] + "\nDate : " + mailBodyData[1] + "\nAge   : " + mailBodyData[2] + "\n\n\nTemperature : " + mailBodyData[3] + " °C\nPulses : " + mailBodyData[4] + " per min\nBlood Pressure : " + mailBodyData[5] + " / " + mailBodyData[6] + " mmHg\nWeight : " + mailBodyData[7] + " kg\nHemoglobin : " + mailBodyData[8] + " gm/dL\nBlood Type : " + mailBodyData[9] + "\n\n\nStatus : "+ mailStatus + "\n\n\nMake sure that your test report is available at counter 1\nThank You For Donating Blood\n\tBLOOD BANK-KANDY\n";


                //****************************************************************************************


                string to = Convert.ToString(mailAddress);
                string from = "navodhosts@gmail.com";
                

                MailMessage msg = new MailMessage();
                msg.From = new MailAddress(from);
                msg.To.Add(to);
                msg.Subject = "DIGITAL SIGN NUMBER-This is No Reply Email";
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
                    MessageBox.Show("The Soft Copy Of Test Is Sended!", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                }
                catch (Exception qwe)
                {
                    MessageBox.Show(qwe.Message);
                }



                //****************************************************************************************


            }
            catch (Exception sendEmailTestReports)
            {
                MessageBox.Show(sendEmailTestReports.Message);
            }

            Thread td = new Thread(openDoctorForm);
            td.SetApartmentState(ApartmentState.STA);
            td.Start();
            this.Close();
        }

        private void openDoctorForm()
        {
            Application.Run(new Doctor());
        }

        private void btnClear_Click(object sender, EventArgs e)
        {

            txtBloodType.Text = cmbUpdateBloodType.Text;
            cmbUpdateBloodType.Enabled = false;
            cmbUpdateBloodType.SelectedIndex = -1;

            txtTemp.Text = txtUpdateTemp.Text;
            txtUpdateTemp.Clear();
            txtUpdateTemp.Enabled = false;

            txtWeight.Text = txtUpdateWeight.Text;
            txtUpdateWeight.Clear();
            txtUpdateWeight.Enabled = false;

            txtPluses.Text = txtUpdatePulses.Text;
            txtUpdatePulses.Clear();
            txtUpdatePulses.Enabled = false;

            txtSbp.Text = txtUpdateSy.Text;
            txtUpdateSy.Clear();
            txtUpdateSy.Enabled = false;

            txtDbp.Text = txtUpdateDi.Text;
            txtUpdateDi.Clear();
            txtUpdateDi.Enabled = false;

            txtHemoglobin.Text = txtUpdateHemoglobin.Text;
            txtUpdateHemoglobin.Clear();
            txtUpdateHemoglobin.Enabled = false;

            chkUpdateConfirm.Enabled = false;
            chkUpdateConfirm.Checked = false;
            btnUpdate.Enabled = false;
        }

        private void btnDonate_Click(object sender, EventArgs e)
        {
            string bloodType;

            if(chkUpdate.Checked)
            {
                bloodType = Convert.ToString(cmbUpdateBloodType.Text);
            }
            else
            {
                bloodType = Convert.ToString(txtBloodType.Text);
            }

            // if (chkUpdate.Checked == false)

            try
            {
                string insertDonatedBlood = "insert into bloodunit (DonarNIC,DonatedDate,bloodtype) values ('" + txtEditNic.Text + "','" + DateTime.Now.ToString("yyyy-M-d") + "','" + bloodType + "')";
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-ILF4RKJ\\MSSQLSERVER01;Initial Catalog=bloodBank;Integrated Security=True");
                SqlCommand cmd = new SqlCommand(insertDonatedBlood,con);

                con.Open();

                cmd.ExecuteNonQuery();

                con.Close();

                MessageBox.Show("Blood Bag Was Added to The Bank","System Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            catch(Exception donateE)
            {
                MessageBox.Show(donateE.Message);
            }

            btnDonate.Enabled = false;

            //Thread td = new Thread(openDoctorFormAfterDonate);
            //td.SetApartmentState(ApartmentState.STA);
            //td.Start();
            //this.Close();

        }

        private void openDoctorFormAfterDonate()
        {
            Application.Run(new Doctor());
        }
    }
}
