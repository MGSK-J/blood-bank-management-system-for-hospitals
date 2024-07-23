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
using System.Net;
using System.Net.Mail;
using System.Threading;

namespace Blood_Bank
{
    public partial class LabAssistantEditAccount : Form
    {
        public LabAssistantEditAccount()
        {
            InitializeComponent();
        }

        private void LabAssistantEditAccount_Load(object sender, EventArgs e)
        {
            txtEmpID.Text = Clipboard.GetText();
            lbl3.Enabled = false;
            btnGenerateOtp.Enabled = false;
            btnConfirmOtp.Enabled = false;
            txtOtpCode.Enabled = false;
            txt1.Enabled = false;
            txt2.Enabled = false;

            try
            {
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-ILF4RKJ\\MSSQLSERVER01;Initial Catalog=bloodBank;Integrated Security=True");
                string[] clerckArray = new string[9];
                string query = "select NIC,firstName,lastName,userName,userPassword,DOB,empEmail,Telephone,RegDate from employee where UserID ='" + txtEmpID.Text + "'";

                SqlCommand cmd = new SqlCommand(query, con);

                con.Open();

                SqlDataReader rdr = cmd.ExecuteReader();
                rdr.Read();

                clerckArray[0] = Convert.ToString(rdr[0]);
                clerckArray[1] = Convert.ToString(rdr[1]);
                clerckArray[2] = Convert.ToString(rdr[2]);
                clerckArray[3] = Convert.ToString(rdr[3]);
                clerckArray[4] = Convert.ToString(rdr[4]);
                clerckArray[5] = Convert.ToString(rdr[5]);
                clerckArray[6] = Convert.ToString(rdr[6]);
                clerckArray[7] = Convert.ToString(rdr[7]);
                clerckArray[8] = Convert.ToString(rdr[8]);

                con.Close();

                txtFirstName.Text = clerckArray[1];
                txtLastName.Text = clerckArray[2];
                txtUserName.Text = clerckArray[3];
                txtPassword.Text = clerckArray[4];
                dtpDob.Text = clerckArray[5];
                txtEmail.Text = clerckArray[6];
                txtTelephone.Text = clerckArray[7];
                dtpRegDate.Text = clerckArray[8];


                txtEmpID.ReadOnly = true;
                txtFirstName.ReadOnly = true;
                txtLastName.ReadOnly = true;
                txtUserName.ReadOnly = true;
                txtPassword.ReadOnly = true;
                dtpDob.MaxDate = dtpDob.Value;
                dtpDob.MinDate = dtpDob.Value;
                dtpRegDate.MaxDate = dtpRegDate.Value;
                dtpRegDate.MinDate = dtpRegDate.Value;
                txtEmail.ReadOnly = true;
                txtTelephone.ReadOnly = true;
            }
            catch (Exception viewClerck)
            {
                MessageBox.Show(viewClerck.Message);
            }


            cmbEditMenu.Enabled = false;
            txtEditValues.Enabled = false;
            btnEditUpdate.Enabled = false;
            btnEditClear.Enabled = false;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            cmbEditMenu.Enabled = checkBox1.Checked;
        }

        private void cmbEditMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbEditMenu.SelectedIndex == 1)
            {
                lbl1.Text = "E-Mail";
                lbl2.Text = "ReEnter E-Mail";
                txt1.Enabled = true;
                lbl1.Enabled = true;
                txtEditValues.Clear();
                txtEditValues.Visible = false;
                txt1.Focus();
                txt1.Clear();
                txt2.Clear();
                txt2.Enabled = false;
                lbl2.Enabled = false;
                txt2.UseSystemPasswordChar = false;
                txtEditValues.Enabled = false;
            }
            else if (cmbEditMenu.SelectedIndex == 0)
            {
                txtEditValues.Visible = true;
                txtEditValues.Focus();
                txtEditValues.Enabled = true;
                txt1.Enabled = false;
                txt2.Enabled = false;
                lbl1.Enabled = false;
                lbl2.Enabled = false;
                txtEditValues.Clear();
                txt2.UseSystemPasswordChar = false;
            }
            else if (cmbEditMenu.SelectedIndex == 2)
            {
                lbl1.Text = "Password";
                lbl2.Text = "ReEnter Password";
                txtEditValues.Clear();
                txtEditValues.Visible = false;
                txt1.Enabled = true;
                lbl1.Enabled = true;
                txt1.Focus();
                txtEditValues.Enabled = false;
                txt1.Clear();
                txt2.Clear();
                txt2.Enabled = false;
                lbl2.Enabled = false;
                btnGenerateOtp.Enabled = false;
                btnEditUpdate.Enabled = false;
                txt2.UseSystemPasswordChar = true;
            }
            else
            {
                lbl1.Text = "";
                lbl2.Text = "";
            }
        }

        private void txtEditValues_TextChanged(object sender, EventArgs e)
        {
            if (txtEditValues.TextLength > 0)
            {
                btnEditClear.Enabled = true;
                btnEditUpdate.Enabled = true;
            }
            else
            {
                btnEditClear.Enabled = false;
                btnEditUpdate.Enabled = false;
            }
        }

        private void txt1_TextChanged(object sender, EventArgs e)
        {
            if (txt1.TextLength > 0)
            {
                lbl2.Enabled = true;
                txt2.Enabled = true;
            }
            else
            {
                lbl2.Enabled = false;
                txt2.Clear();
                txt2.Enabled = false;
            }
        }

        private void txt2_TextChanged(object sender, EventArgs e)
        {
            if (txt2.TextLength > 0 && cmbEditMenu.SelectedIndex == 1 && txt1.Text == txt2.Text)
            {
                btnGenerateOtp.Enabled = true;
                btnConfirmOtp.Enabled = false;
                btnEditUpdate.Enabled = false;
            }
            else if (txt2.TextLength > 0 && cmbEditMenu.SelectedIndex == 2)
            {
                btnGenerateOtp.Enabled = false;
                btnConfirmOtp.Enabled = false;
                btnEditUpdate.Enabled = true;

            }
            else
            {
                btnConfirmOtp.Enabled = false;
                btnEditUpdate.Enabled = false;
                btnGenerateOtp.Enabled = false;
            }
        }

        private void txtOtpCode_TextChanged(object sender, EventArgs e)
        {
            if (txtOtpCode.TextLength > 0)
            {
                btnConfirmOtp.Enabled = true;
            }
            else
            {
                btnConfirmOtp.Enabled = false;
            }
        }

        private void btnGenerateOtp_Click(object sender, EventArgs e)
        {
            // mail send part

            string to = Convert.ToString(txt2.Text);
            string from = "navodhosts@gmail.com";
            string FullName = Convert.ToString(txtFirstName + " " + txtLastName);
            string mailBody = "Wellcome " + FullName + " your otp number is " + Convert.ToString(Otp.generateRandomNumber()) + "";
            string mailPassword = Convert.ToString(txtOtpCode.Text);

            MailMessage msg = new MailMessage();
            msg.From = new MailAddress(from);
            msg.To.Add(to);
            msg.Subject = "This is No Reply Email";
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
                MessageBox.Show("OTP Generated Successful \nOTP is sent to the mail\n" + txtEmail.Text + ".", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtOtpCode.Enabled = true;
            }
            catch (Exception qwe)
            {
                MessageBox.Show(qwe.Message);
            }

        }

        private void btnConfirmOtp_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtOtpCode.Text) == Otp.getOtpNumber())
            {
                btnEditUpdate.Enabled = true;
            }
            else
            {
                btnEditUpdate.Enabled = false;
                btnConfirmOtp.Enabled = false;
                btnGenerateOtp.Enabled = true;
                txtOtpCode.Enabled = false;
                txtOtpCode.Clear();
                MessageBox.Show("Entered OTP number is invalid \ncheck your mail\ncheck " + txt2.Text, "System information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnGenerateOtp.Focus();
            }
        }

        private void btnEditClear_Click(object sender, EventArgs e)
        {
            txtEditValues.Clear();
            txt1.Clear();
            txt2.Clear();
            btnEditUpdate.Enabled = false;
            cmbEditMenu.SelectedIndex = -1;
            //btnEditClear.Enabled = false;
            txtOtpCode.Enabled = false;
            txtOtpCode.Clear();
            txt1.Enabled = false;
            txt2.Enabled = false;
            txtEditValues.Enabled = false;
        }

        private void btnEditUpdate_Click(object sender, EventArgs e)
        {
            if (cmbEditMenu.SelectedIndex == 1 && txt1.Text == txt2.Text)
            {
                try
                {
                    //string updateTelephoneQuery = "update employee set Telephone ='" + txtEditValues.Text + "' where UserID ='" + txtEmpID.Text + "'";
                    string updateEmailQuery = "update employee set empEmail ='" + txt2.Text + "' where UserID ='" + txtEmpID.Text + "'";
                    //string updatePasswordQuery = "update employee set userPassword ='" + txt2.Text + "' where UserID ='" + txtEmpID.Text + "'";

                    SqlConnection con = new SqlConnection("Data Source=DESKTOP-ILF4RKJ\\MSSQLSERVER01;Initial Catalog=bloodBank;Integrated Security=True");
                    SqlCommand cmd = new SqlCommand(updateEmailQuery, con);

                    con.Open();

                    cmd.ExecuteNonQuery();

                    con.Close();

                    txtEmail.Text = txt2.Text;
                    MessageBox.Show("Email Was Changed", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbEditMenu.SelectedIndex = -1;
                    txt1.Clear();
                    txt1.Enabled = false;
                    txt2.Clear();
                    txt2.Enabled = false;
                    txtOtpCode.Clear();
                    txtOtpCode.Enabled = false;
                }
                catch (Exception changeEmail)
                {
                    MessageBox.Show(changeEmail.Message);
                }
            }

            if (cmbEditMenu.SelectedIndex == 2 && txt1.Text == txt2.Text)
            {
                string query = "update employee set userPassword ='" + txt2.Text + "' where UserID ='" + txtEmpID.Text + "'";
                try
                {
                    SqlConnection con = new SqlConnection("Data Source=DESKTOP-ILF4RKJ\\MSSQLSERVER01;Initial Catalog=bloodBank;Integrated Security=True");
                    SqlCommand cmd = new SqlCommand(query, con);
                    con.Open();

                    cmd.ExecuteNonQuery();

                    con.Close();

                    MessageBox.Show("Password Was Changed", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbEditMenu.SelectedIndex = -1;
                    txtPassword.Text = txt2.Text;
                    txt1.Clear();
                    txt2.Clear();
                    txt1.Enabled = false;
                    txt2.Enabled = false;
                    btnEditUpdate.Enabled = false;
                }
                catch (Exception changePassword)
                {
                    MessageBox.Show(changePassword.Message);
                }
            }


            else if (cmbEditMenu.SelectedIndex == 0 && txtEditValues.TextLength > 0)
            {
                string updateTelephoneQuery = "update employee set Telephone ='" + txtEditValues.Text + "' where UserID ='" + txtEmpID.Text + "'";
                try
                {
                    SqlConnection con = new SqlConnection("Data Source=DESKTOP-ILF4RKJ\\MSSQLSERVER01;Initial Catalog=bloodBank;Integrated Security=True");
                    SqlCommand cmd = new SqlCommand(updateTelephoneQuery, con);
                    con.Open();

                    cmd.ExecuteNonQuery();

                    con.Close();

                    MessageBox.Show("Telephone Number Was Changed", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbEditMenu.SelectedIndex = -1;
                    txtTelephone.Text = txtEditValues.Text;
                    txtEditValues.Clear();
                    txtEditValues.Enabled = false;
                    txt1.Clear();
                    txt2.Clear();
                    txt1.Enabled = false;
                    txt2.Enabled = false;
                    btnEditUpdate.Enabled = false;
                }
                catch (Exception changePassword)
                {
                    MessageBox.Show(changePassword.Message);
                }
            }
            else
            {

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Thread td = new Thread(goBackLabForm);
            td.SetApartmentState(ApartmentState.STA);
            td.Start();
            this.Close();
        }

        private void goBackLabForm()
        {
            Application.Run(new LAB());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
