using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using System.Net.Mail;
using System.Data.SqlClient;

namespace Blood_Bank
{
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
                try
                {
                string connectionString = "Data Source=DESKTOP-ILF4RKJ\\MSSQLSERVER01;Initial Catalog=bloodBank;Integrated Security=True";
                string insertQuery = "insert into employee (NIC,firstName,lastName,userName,userPassword,empMode,DOB,empEmail,Telephone,RegDate) values ('" + txtNic.Text + "','" + txtFirstName.Text + "','" + txtLastName.Text + "','" + txtUserName.Text + "','" + txtPassword.Text + "','" + cmbEmployeeMode.Text + "','" + dtpDob.Value + "','" + txtReEmail.Text + "','" + txtTelephone.Text + "','" + DateTime.Now.ToString("yyyy-M-d") + "')";

                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand insertCommand = new SqlCommand(insertQuery, connection);

                connection.Open();
                insertCommand.ExecuteNonQuery();
                connection.Close();

                MessageBox.Show("Data Record Is Added", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
                catch(Exception ex)
                {
                MessageBox.Show(ex.Message);
                this.Close();
                Thread errorTread = new Thread(errorOccuredThread);
                errorTread.SetApartmentState(ApartmentState.STA);
                errorTread.Start();
                }

            string query = "select UserID from employee where NIC = '"+txtNic.Text+"';";

            SqlConnection con = new SqlConnection("Data Source=Data Source=DESKTOP-ILF4RKJ\\MSSQLSERVER01;Initial Catalog=bloodBank;Integrated Security=True");
            SqlCommand cmd = new SqlCommand(query,con);

            con.Open();
            string empId = Convert.ToString(cmd.ExecuteScalar());
            string sendingID = Convert.ToString(empId);
            con.Close();
            string to = Convert.ToString(txtReEmail.Text);
            string from = "navodhosts@gmail.com";
            string FullName = Convert.ToString(txtFirstName.Text + " " + txtLastName.Text);
            string mailPassword = Convert.ToString(txtPassword.Text);

            string mailBody = "Welcome MR/Mss" + FullName + ".\nEMPLOYEE ID : " +empId+ "\nPASSWORD : "+mailPassword+"\nYou Have Registered";

            MessageBox.Show(empId);
            MessageBox.Show(sendingID.ToString());
           

            try
            {

                MailMessage msg = new MailMessage();
                msg.From = new MailAddress(from);
                msg.To.Add(to);
                msg.Subject = "No Reply Message";
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


                smt.Send(msg);
                //smtp.Send(message);
                MessageBox.Show("Your Mail is sended","System Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            catch(Exception qwe)
            {
                MessageBox.Show(qwe.Message);
            }

            Thread td = new Thread(openAdminFormAgain);
            td.SetApartmentState(ApartmentState.STA);
            td.Start();
            this.Close();
        }

        private void openAdminFormAgain()
        {
            Application.Run(new AdminForm());
        }

        private void closeAppError()
        {
            Application.Run(new AdminForm());
        }

        private void errorOccuredThread()
        {
            AdminForm openNew = new AdminForm();
            Application.Run(new AdminForm());
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            btnDelete.Enabled = false;
            cmbEmployeeMode.Enabled = false;
            btnSubmit.Enabled = false;
            txtFirstName.Enabled = false;
            txtLastName.Enabled = false;
            txtTelephone.Enabled = false;
            txtUserName.Enabled = false;
            txtPassword.Enabled = false;
            txtEmail.Enabled = false;
            txtReEmail.Enabled = false;
            txtRePassword.Enabled = false;
            txtOtpCode.Enabled = false;
            dtpDob.Enabled = false;
            btnGenerateOtp.Enabled = false;
            btnConfirmOtp.Enabled = false;
            btnSubmit.Enabled = false;
            btnSearch.Enabled = false;
            btnCheck.Enabled = false;
        }

        private void txtFirstName_TextChanged(object sender, EventArgs e)
        {

            if (txtFirstName.TextLength > 0)
            {
                txtLastName.Enabled = true;
            }
            else
            {
                txtLastName.Enabled = false;
            }



        }

        private void cmbEmployeeMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbEmployeeMode.Text.Length > 0)
            {
                txtFirstName.Enabled = true;
            }
            else
            {
                txtFirstName.Enabled = false;
            }
        }

        private void txtLastName_TextChanged(object sender, EventArgs e)
        {
            if(txtLastName.TextLength > 0)
            {
                txtTelephone.Enabled = true;
            }
            else
            {
                txtTelephone.Enabled = false;
            }
        }

        private void txtTelephone_TextChanged(object sender, EventArgs e)
        {
            if(txtTelephone.TextLength > 0)
            {
                dtpDob.Enabled = true;
            }
            else
            {
                dtpDob.Enabled = false;
            }
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
            if(txtUserName.TextLength > 0)
            {
                btnCheck.Enabled = true;
            }
            else
            {
                btnCheck.Enabled = false;
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            if(txtPassword.TextLength > 0)
            {
                txtRePassword.Enabled = true;
            }
            else
            {
                txtRePassword.Enabled = false;
            }
        }

        private void txtFirstName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void txtLastName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void txtTelephone_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            txtReEmail.Clear();

            if(txtEmail.TextLength > 0)
            {
                txtReEmail.Enabled = true;
            }
            else
            {
                txtReEmail.Enabled = false;
            }
        }

        private void txtReEmail_TextChanged(object sender, EventArgs e)
        {
            if(txtEmail.Text == txtReEmail.Text)
            {
                btnGenerateOtp.Enabled = true;
            }
            else
            {
                btnGenerateOtp.Enabled = false;
            }
        }

        private void txtRePassword_TextChanged(object sender, EventArgs e)
        {
            if(txtPassword.Text ==txtRePassword.Text)
            {
                btnSubmit.Enabled = true;
            }
            else
            {
                btnSubmit.Enabled = false;
            }
        }

        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void txtReEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!this.txtEmail.Text.Contains('@') || !this.txtEmail.Text.Contains('.'))
            {
                MessageBox.Show("Please Enter A Valid Email", "Invalid Email", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmail.Clear();
                txtReEmail.Clear();
                txtEmail.Focus();
                txtReEmail.Enabled = false;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
            Thread newForm1 = new Thread(openFormLogin);
            newForm1.SetApartmentState(ApartmentState.STA);
            newForm1.Start();
        }

        private void openFormLogin()
        {
            Application.Run(new Form1());
        }

        

        private void txtMailPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnGenerateOtp_Click(object sender, EventArgs e)
        {
            txtOtpCode.Enabled = true;

            // mail send part

            string to = Convert.ToString(txtReEmail.Text);
            string from = "navodhosts@gmail.com";
            string FullName = Convert.ToString(txtFirstName + " " + txtLastName);
            string mailBody = "Wellcome " + FullName + " your otp number is "+Convert.ToString(Otp.generateRandomNumber()) + "";
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
                MessageBox.Show("OTP Generated Successful \nOTP is sent to the mail\n"+txtEmail.Text+".","System Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            catch (Exception qwe)
            {
                MessageBox.Show(qwe.Message);
            }

        }

        private void txtOtpCode_TextChanged(object sender, EventArgs e)
        {
            if(txtOtpCode.TextLength > 0)
            {
                btnConfirmOtp.Enabled = true;
            }
            else
            {
                btnConfirmOtp.Enabled = false;
            }
        }

        private void btnConfirmOtp_Click(object sender, EventArgs e)
        {
            if(Convert.ToInt32(txtOtpCode.Text) == Otp.getOtpNumber())
            {
                txtUserName.Enabled = true;
            }
            else
            {
                txtUserName.Enabled = false;
                btnConfirmOtp.Enabled = false;
                MessageBox.Show("Entered OTP number is invalid \ncheck your mail\ncheck "+txtReEmail,"System information",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                btnGenerateOtp.Focus();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtNic.Focus();
            cmbEmployeeMode.SelectedIndex = -1;
            txtFirstName.Clear();
            txtLastName.Clear();
            txtTelephone.Clear();
            txtEmail.Clear();
            txtReEmail.Clear();
            txtOtpCode.Clear();
            txtUserName.Clear();
            txtPassword.Clear();
            txtRePassword.Clear();
            txtNic.Clear();

            txtFirstName.Enabled = false;
            txtLastName.Enabled = false;
            txtTelephone.Enabled = false;
            txtEmail.Enabled = false;
            txtReEmail.Enabled = false;
            txtOtpCode.Enabled = false;
            txtUserName.Enabled = false;
            txtPassword.Enabled = false;
            txtRePassword.Enabled = false;
            dtpDob.Enabled = false;
            cmbEmployeeMode.Enabled = false;

            btnGenerateOtp.Enabled = false;
            btnConfirmOtp.Enabled = false;
            btnSearch.Enabled = false;
        }

        private void dtpDob_ValueChanged(object sender, EventArgs e)
        {
            if(dtpDob.Checked)
            {
                txtEmail.Enabled = true;
            }
            else
            {
                txtEmail.Enabled = false;
            }
        }

        

        private void txtNic_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string nicNumber = Convert.ToString(txtNic.Text);
            string check;

            try
            {
                string connectionString = "Data Source=DESKTOP-ILF4RKJ\\MSSQLSERVER01;Initial Catalog=bloodBank;Integrated Security=True";
                string query = "select UserID from employee where NIC = '"+nicNumber+"'";

                SqlConnection checkConnection = new SqlConnection(connectionString);
                SqlCommand checkCommand = new SqlCommand(query, checkConnection);

                checkConnection.Open();
                check = Convert.ToString(checkCommand.ExecuteScalar());
                checkConnection.Close();

                //MessageBox.Show(Convert.ToString(check));

                if (check.Length == 0)
                {
                    cmbEmployeeMode.Enabled = true;
                }
                else
                {
                    btnDelete.Enabled = true;
                    MessageBox.Show("Registered NIC", "System information",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    cmbEmployeeMode.Enabled = false;
                }



            }
            catch(Exception nic)
            {
                MessageBox.Show(nic.Message);
            }
        }

        private void txtNic_TextChanged(object sender, EventArgs e)
        {
            if(txtNic.TextLength > 0)
            {
                btnSearch.Enabled = true;
            }
            else
            {
                btnSearch.Enabled = false;
            }
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {

            string localUserName = Convert.ToString(txtUserName.Text);
            string empId;

            try
            {
                SqlConnection checkUsername = new SqlConnection("Data Source=DESKTOP-ILF4RKJ\\MSSQLSERVER01;Initial Catalog=bloodBank;Integrated Security=True");
                string query = "select UserID from employee where userName = '" + localUserName + "'";

                SqlCommand userName = new SqlCommand(query, checkUsername);
                checkUsername.Open();
                empId = Convert.ToString(userName.ExecuteScalar());
                checkUsername.Close();

                if (empId.Length == 0)
                {
                    txtPassword.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Following username is taken", "system information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUserName.Clear();
                    btnCheck.Enabled = false;
                }
            }
            catch(Exception checkUserName)
            {
                MessageBox.Show(checkUserName.Message,"system Infomation",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {

                string[] empData = new string[4];

                string getEmpDetails = "select UserID,firstName,lastName,empMode from employee where NIC ='" + txtNic.Text + "'";
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-ILF4RKJ\\MSSQLSERVER01;Initial Catalog=bloodBank;Integrated Security=True");
                SqlCommand cmd = new SqlCommand(getEmpDetails,con);
                con.Open();

                SqlDataReader readEmpData = cmd.ExecuteReader();
                readEmpData.Read();

                for(int countLoop = 0; countLoop < 4; countLoop++)
                {
                    empData[countLoop] = Convert.ToString(readEmpData[countLoop]);
                }

                con.Close();
                
                string insertDataToDeletedAccounts = "insert into DeletedAccounts (UserID,NIC,firstName,lastName,empMode) values ('" + empData[0] + "','" + txtNic.Text + "','" + empData[1] + "','" + empData[2] + "','" + empData[3] + "')";
                SqlCommand insertCommand = new SqlCommand(insertDataToDeletedAccounts,con);
                con.Open();

                insertCommand.ExecuteNonQuery();

                con.Close();

                string deleteTuppleQuery = "delete from employee where NIC ='" + txtNic.Text + "'";
                SqlCommand deleteTupple = new SqlCommand(deleteTuppleQuery,con);
                con.Open();

                deleteTupple.ExecuteNonQuery();

                con.Close();

                MessageBox.Show("Following userAccount Has Deleted!","System Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
                btnDelete.Enabled = false;

                Clipboard.SetText(empData[0]);

                Thread td = new Thread(openDescriptionForm);
                td.SetApartmentState(ApartmentState.STA);
                td.Start();
                this.Close();
                
            }
            catch(Exception deleteAndUpdateTable)
            {
                MessageBox.Show(deleteAndUpdateTable.Message,"System Information",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void openDescriptionForm()
        {
            Application.Run(new Description_Form());
        }
    }
}
