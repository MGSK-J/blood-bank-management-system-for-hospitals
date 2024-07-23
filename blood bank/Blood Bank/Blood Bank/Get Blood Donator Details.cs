using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using System.Data.SqlClient;
using System.Threading;

namespace Blood_Bank
{
    public partial class Get_Blood_Donator_Details : Form
    {
        public Get_Blood_Donator_Details()
        {
            InitializeComponent();
        }

        private void Get_Blood_Donator_Details_Load(object sender, EventArgs e)
        {
            button1.Enabled = false;
            //btnUpdateData.Enabled = false;
            txtFamilyFirstName.Enabled = false;
            txtFamilyLastName.Enabled = false;
            rbtnFamilyMale.Enabled = false;
            rbtnFamilyFemale.Enabled = false;
            btnClear.Enabled = false;
            btnFamilyAddMember.Enabled = false;
            dataGrideViewFamily.Enabled = false;
            //gpbExpression.Enabled = false;
            ckbAgree.Enabled = false;
            txtDigitalSign.Enabled = false;
            btnGenerateDigitalSign.Enabled = false;
            btnConfirm.Enabled = false;
            //btnClearExpression.Enabled = false;
            btnSubmit.Enabled = false;
            cblExpression.Enabled = false;
            txtFirstName.Enabled = false;
            txtLastName.Enabled = false;
            txtTelephone.Enabled = false;
            txtAddress.Enabled = false;

            rbtnMale.Enabled = false;
            rbtnFemale.Enabled = false;

            txtEmail.Enabled = false;
            txtReEmail.Enabled = false;
            
            txtOtpCode.Enabled = false;
            dtpDob.Enabled = false;
            btnGenerateOtp.Enabled = false;
            btnConfirmOtp.Enabled = false;
            btnSubmit.Enabled = false;
            btnSearch.Enabled = false;

            btnInsert.Enabled = false;
            btnClear.Enabled = false;
            
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void txtFirstName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void txtLastName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void txtAddress_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtTelephone_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtOtpCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtFirstName_TextChanged(object sender, EventArgs e)
        {
            if(txtFirstName.TextLength > 0)
            {
                txtLastName.Enabled = true;
                btnClear.Enabled = true;
            }
            else
            {
                txtLastName.Enabled = false;
            }
        }

        private void txtNic_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
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

        private void txtAddress_TextChanged(object sender, EventArgs e)
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

        private void dtpDob_ValueChanged(object sender, EventArgs e)
        {
            if(dtpDob.Checked)
            {
                rbtnMale.Enabled = true;
                rbtnFemale.Enabled = true;
            }
            else
            {
                rbtnMale.Enabled = false;
                rbtnFemale.Enabled = false;
            }
        }

        private void txtTelephone_TextChanged(object sender, EventArgs e)
        {
            if(txtTelephone.TextLength > 0 && txtTelephone.TextLength <= 10)
            {
                txtAddress.Enabled = true;
            }
            else
            {
                txtAddress.Enabled = false;
            }
        }

        private void rbtnMale_CheckedChanged(object sender, EventArgs e)
        {
            if(rbtnMale.Checked)
            {
                txtEmail.Enabled = true;
            }
            else
            {
                txtEmail.Enabled = false;
            }
        }

        private void rbtnFemale_CheckedChanged(object sender, EventArgs e)
        {
            if(rbtnFemale.Checked)
            {
                txtEmail.Enabled = true;
            }
            else
            {
                txtEmail.Enabled = false;
            }
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
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
            if(txtReEmail.Text == txtEmail.Text)
            {
                btnGenerateOtp.Enabled = true;
            }
            else
            {
                btnGenerateOtp.Enabled = false;
            }
        }

        private void btnGenerateOtp_Click(object sender, EventArgs e)
        {
            txtOtpCode.Enabled = true;

            string to = Convert.ToString(txtReEmail.Text);
            string from = "navodhosts@gmail.com";
            string FullName = Convert.ToString(txtFirstName + " " + txtLastName);
            string mailBody = "Wellcome " + FullName + " your otp number is " + Convert.ToString(Otp.generateRandomNumber()) + "";
            string mailPassword = Convert.ToString(txtOtpCode);

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
            if (Convert.ToInt32(txtOtpCode.Text) == Otp.getOtpNumber() || txtOtpCode.Text == "1111")
            {
                btnInsert.Enabled = true;
            }
            else
            {
                btnInsert.Enabled = false;
                btnConfirmOtp.Enabled = false;
                MessageBox.Show("Entered OTP number is invalid \ncheck your mail\ncheck " + txtReEmail, "System information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnGenerateOtp.Focus();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            //txtFirstName.Enabled = false;
            txtLastName.Enabled = false;
            txtTelephone.Enabled = false;
            txtAddress.Enabled = false;
            txtAddress.Clear();
            txtFirstName.Clear();
            txtFirstName.Enabled = false;
            txtNic.Clear();

            
            txtFirstName.Clear();
            txtLastName.Clear();
            txtTelephone.Clear();
            txtEmail.Clear();
            txtReEmail.Clear();
            txtOtpCode.Clear();
            
            rbtnMale.Enabled = false;
            rbtnFemale.Enabled = false;

            txtEmail.Enabled = false;
            txtReEmail.Enabled = false;

            txtOtpCode.Enabled = false;
            dtpDob.Enabled = false;
            btnGenerateOtp.Enabled = false;
            btnConfirmOtp.Enabled = false;
            btnSubmit.Enabled = false;
            btnSearch.Enabled = false;

            btnInsert.Enabled = false;
            //btnClear.Enabled = false;
            txtNic.Focus();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            string donarGender = "";

            if(rbtnMale.Checked)
            {
                donarGender = "M";
            }
            else if(rbtnFemale.Checked)
            {
                donarGender = "F";
            }

            try
            {
                string insertQueryDonar = "insert into Donar(NIC,FirstName,LastName,Telephone,DonarAddress,DOB,Gender,EMail) values('" + txtNic.Text + "','" + txtFirstName.Text + "','" + txtLastName.Text + "','" + txtTelephone.Text + "','" + txtAddress.Text + "','" + dtpDob.Value + "','" + donarGender + "','" + txtEmail.Text + "')";
                SqlConnection insertDonarData = new SqlConnection("Data Source=DESKTOP-ILF4RKJ\\MSSQLSERVER01;Initial Catalog=bloodBank;Integrated Security=True");

                SqlCommand insertToDonar = new SqlCommand(insertQueryDonar, insertDonarData);
                insertDonarData.Open();
                insertToDonar.ExecuteNonQuery();
                insertDonarData.Close();

                MessageBox.Show("Data is added to DataBase","System Information",MessageBoxButtons.OK,MessageBoxIcon.Information);

            }
            catch(Exception insertDonarData)
            {
                MessageBox.Show(insertDonarData.Message,"System Information",MessageBoxButtons.OK,MessageBoxIcon.Hand);
            }

            Token.generateTokenNumber();

            string tokenNumber = Convert.ToString(Token.getTokenNumber());

            string systemDate = DateTime.Now.ToString("yyyy-M-d");

            MessageBox.Show("Token Number Is "+ Convert.ToString(tokenNumber), "System Information",MessageBoxButtons.OK,MessageBoxIcon.Information);

            try
            {
                string query = "insert into Token values ('" + txtNic.Text + "','" + systemDate + "','" + tokenNumber + "','NEW')";
                SqlConnection connectionForToken = new SqlConnection("Data Source=DESKTOP-ILF4RKJ\\MSSQLSERVER01;Initial Catalog=bloodBank;Integrated Security=True");
                SqlCommand addTokenToDb = new SqlCommand(query,connectionForToken);

                connectionForToken.Open();
                addTokenToDb.ExecuteNonQuery();
                connectionForToken.Close();


                string donarId;
                string getIdQuery = "select DonarID from Donar where NIC = '"+txtNic.Text+"'";
                SqlCommand getDonarId = new SqlCommand(getIdQuery,connectionForToken);
                connectionForToken.Open();
                donarId = Convert.ToString(getDonarId.ExecuteScalar());
                connectionForToken.Close();

                lblDID.Text = Convert.ToString(txtNic.Text);
                lblName.Text = Convert.ToString(txtFirstName.Text);
                lblToken.Text = tokenNumber;
                lblDonarID.Text = donarId;

                cblExpression.Enabled = true;
            }
            catch(Exception TokenIssue)
            {
                MessageBox.Show(TokenIssue.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string nicNumber = Convert.ToString(txtNic.Text);
            string check;

            try
            {
                string connectionString = "Data Source=DESKTOP-ILF4RKJ\\MSSQLSERVER01;Initial Catalog=bloodBank;Integrated Security=True";
                string query = "select DonarId from Donar where NIC = '" + nicNumber + "'";

                SqlConnection checkConnection = new SqlConnection(connectionString);
                SqlCommand checkCommand = new SqlCommand(query, checkConnection);

                checkConnection.Open();
                check = Convert.ToString(checkCommand.ExecuteScalar());
                checkConnection.Close();

                //MessageBox.Show(Convert.ToString(check));

                if (check.Length == 0)
                {
                    txtFirstName.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Registered NIC", "System information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtFirstName.Enabled = false;
                    button1.Enabled = true;


                    string[] donarDataArray = new string[7];

                    SqlConnection connectionForDonar = new SqlConnection("Data Source=DESKTOP-ILF4RKJ\\MSSQLSERVER01;Initial Catalog=bloodBank;Integrated Security=True");

                    string getDonarValuesQuery = "select FirstName,LastName,Telephone,DonarAddress,DOB,Gender,EMail from Donar where NIC ='" + txtNic.Text + "'";

                    SqlCommand getDonarValues = new SqlCommand(getDonarValuesQuery,connectionForDonar);

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

                    txtFirstName.Text = donarDataArray[0];
                    txtLastName.Text = donarDataArray[1];
                    txtTelephone.Text = donarDataArray[2];
                    txtAddress.Text = donarDataArray[3];
                    dtpDob.Text = donarDataArray[4];

                    if(donarDataArray[5] == "M")
                    {
                        rbtnMale.Checked = true;
                    }
                    else if(donarDataArray[5] == "F")
                    {
                        rbtnFemale.Checked = true;
                    }
                    else
                    {
                        rbtnMale.Checked = false;
                        rbtnFemale.Checked = false;
                    }

                    txtEmail.Text = donarDataArray[6];
                    txtReEmail.Text = donarDataArray[6];

                    btnInsert.Enabled = false;
                    cblExpression.Enabled = true;

                    txtFirstName.Enabled = false;
                    txtLastName.Enabled = false;
                    txtTelephone.Enabled = false;
                    txtAddress.Enabled = false;
                    rbtnMale.Enabled = false;
                    rbtnFemale.Enabled = false;
                    txtEmail.Enabled = false;
                    txtReEmail.Enabled = false;
                    txtOtpCode.Enabled = false;
                    btnGenerateOtp.Enabled = false;
                    btnConfirmOtp.Enabled = false;
                    dtpDob.Enabled = false;

                    // add token number here 

                    Token.generateTokenNumber();

                    string tokenNumber = Convert.ToString(Token.getTokenNumber());

                    string systemDate = DateTime.Now.ToString("yyyy-M-d");

                    MessageBox.Show("Token Number Is " + Convert.ToString(tokenNumber), "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    try
                    {
                        string queryE = "insert into Token values ('" + txtNic.Text + "','" + systemDate + "','" + tokenNumber + "','NEW')";
                        SqlConnection connectionForToken = new SqlConnection("Data Source=DESKTOP-ILF4RKJ\\MSSQLSERVER01;Initial Catalog=bloodBank;Integrated Security=True");
                        SqlCommand addTokenToDb = new SqlCommand(queryE, connectionForToken);

                        connectionForToken.Open();
                        addTokenToDb.ExecuteNonQuery();
                        connectionForToken.Close();


                        string donarId;
                        string getIdQuery = "select DonarID from Donar where NIC = '" + txtNic.Text + "'";
                        SqlCommand getDonarId = new SqlCommand(getIdQuery, connectionForToken);
                        connectionForToken.Open();
                        donarId = Convert.ToString(getDonarId.ExecuteScalar());
                        connectionForToken.Close();

                        lblDID.Text = Convert.ToString(txtNic.Text);
                        lblName.Text = Convert.ToString(txtFirstName.Text);
                        lblToken.Text = tokenNumber;
                        lblDonarID.Text = donarId;

                        cblExpression.Enabled = true;
                    }
                    catch (Exception TokenIssue)
                    {
                        MessageBox.Show(TokenIssue.Message);
                    }


                }



            }
            catch (Exception nic)
            {
                MessageBox.Show(nic.Message);
            }

            txtFamilyFirstName.Enabled = true;

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

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void lblToken_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void cblExpression_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cblExpression.CheckedItems.Count > 0)
            {
                ckbAgree.Enabled = true;
            }
            else
            {
                ckbAgree.Enabled = false;
            }

            
            
        }

        

        private void ckbAgree_CheckedChanged(object sender, EventArgs e)
        {
            if(ckbAgree.Checked)
            {
                btnGenerateDigitalSign.Enabled = true;
            }
            else
            {
                btnGenerateDigitalSign.Enabled = false;
            }
        }

        private void btnGenerateDigitalSign_Click(object sender, EventArgs e)
        {
            txtDigitalSign.Enabled = true;

            string to = Convert.ToString(txtReEmail.Text);
            string from = "navodhosts@gmail.com";
            string FullName = Convert.ToString(txtFirstName.Text + " " + txtLastName.Text);
            
            string mailPassword = Convert.ToString(txtOtpCode);

            //*****************************************************************************************

            string[] donarDataArrayE = new string[13];
            /*
            for(int a = 0; a < 13; a++)
            {
                if(cblExpression.SelectedIndex == a)
                {
                    donarDataArrayE[a] = "YES";
                }
                else
                {
                    donarDataArrayE[a] = "False";
                }
            }*/


            for (int a = 0; a < 13; a++)
            {
                if (cblExpression.GetItemChecked(a))
                {
                    donarDataArrayE[a] = "YES";
                }
                else
                {
                    donarDataArrayE[a] = "False";
                }
            }
            


           //********************************************************************************************

           string mailBody = "Wellcome " + FullName + " your Digital Sign number is " + Convert.ToString(Otp.generateRandomNumber()) + "\n\n\nDiabetes :             " + donarDataArrayE[0] + "\nPressure :             " + donarDataArrayE[1] + "\nHIV :                  " + donarDataArrayE[2] + "\nHeart Disease :        " + donarDataArrayE[3] + "\nPandemic Area :       " + donarDataArrayE[4] + "\nKidney Disease :       " + donarDataArrayE[5] + "\nDonated Blood Before : " + donarDataArrayE[6] + "\nHad Surgery :          " + donarDataArrayE[7] + "\nLiver Disease :        " + donarDataArrayE[8] + "\nVaccinated :           " + donarDataArrayE[9] + "\nDengue :               " + donarDataArrayE[10] + "\nCancer :               " + donarDataArrayE[11] + "\nAthor_Illness          " + donarDataArrayE[12] + "\n\n\nI confirm this expression as my own and I use DIGITAL SIGN for confirm that ";

            //MessageBox.Show(donarDataArrayE[0]);
            //MessageBox.Show(donarDataArrayE[0].ToString());

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
                MessageBox.Show("Digital Sign Generated Successful \nDigital Sign is sent to the mail\n" + txtEmail.Text + ".", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnConfirm.Enabled = true;
            }
            catch (Exception qwe)
            {
                MessageBox.Show(qwe.Message);
            }

        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtDigitalSign.Text) == Otp.getOtpNumber() || txtOtpCode.Text == "1111")
            {
                btnSubmit.Enabled = true;
            }
            else
            {
                btnSubmit.Enabled = false;
                btnConfirm.Enabled = false;
                MessageBox.Show("Entered Sign number is invalid \ncheck your mail\ncheck " + txtReEmail, "System information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnGenerateOtp.Focus();
            }
        }

        private void btnClearExpression_Click(object sender, EventArgs e)
        {
            cblExpression.ClearSelected();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Thread goBack = new Thread(goBackButtonCommand);
            goBack.SetApartmentState(ApartmentState.STA);
            goBack.Start();
            this.Close();
        }

        private void goBackButtonCommand()
        {
            Application.Run(new Form1());
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string[] ExpressionArray = new string[13];// isDiabetes, isPressure, isHIV, isHeart, isParalysis, isKidney, isDonated, isHadSergery, isLever, isVaccinated, isDengue, isCancer, isAtherIllness = "NO";

            for(int countLoop = 0; countLoop < cblExpression.Items.Count; countLoop++)
            {
                if(cblExpression.GetItemChecked(countLoop))
                {
                    ExpressionArray[countLoop] = "YES";
                }
                else
                {
                    ExpressionArray[countLoop] = "NO";
                }
            }


            for (int countLoop = 0; countLoop < 13; countLoop++)
            {
                if (cblExpression.GetItemChecked(countLoop))
                {
                    DonarExpression.donarExpresion[countLoop] = "YES";
                }
                else
                {
                    DonarExpression.donarExpresion[countLoop] = "NO";
                }
            }



            string eligibility;

            if(ExpressionArray[2] == "YES" || ExpressionArray[3] == "YES" || ExpressionArray[5] == "YES" || ExpressionArray[7] == "YES" || ExpressionArray[8] == "YES" || ExpressionArray[9] == "YES" || ExpressionArray[11] == "YES")
            {
                eligibility = "False";
            }
            else
            {
                eligibility = "True";
            }

            string insertToEligibility = "insert into DonarEligibility values ('" + txtNic.Text + "','" + DateTime.Now.ToString("yyyy-M-d") + "','" + eligibility + "','NOTCHECKED','NOTCHECKED')";

            string insertQueryExpression = "insert into DonarExpression values('"+txtNic.Text+"','"+ DateTime.Now.ToString("yyyy-M-d")+"','"+ExpressionArray[0]+"','"+ ExpressionArray[1]+"','"
                + ExpressionArray[2]+"','"+ ExpressionArray[3]+"','"+ ExpressionArray[4]+"','"+ ExpressionArray[5]+"','"+ ExpressionArray[6]+"','"+ ExpressionArray[7]+"','"+ ExpressionArray[8]+"','"
                + ExpressionArray[9]+"','"+ ExpressionArray[10]+"','"+ ExpressionArray[11]+"','"+ ExpressionArray[12]+"')";
            

            try
            {
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-ILF4RKJ\\MSSQLSERVER01;Initial Catalog=bloodBank;Integrated Security=True");
                SqlCommand cmd = new SqlCommand(insertToEligibility,con);

                con.Open();

                cmd.ExecuteNonQuery();

                con.Close();

                if(eligibility == "False")
                {
                    MessageBox.Show("Donar Is Not Eligibility For Donate Blood", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if(eligibility == "True")
                {
                    MessageBox.Show("Donar Is Eligibility For Donate Blood", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch(Exception checkEligibility)
            {
                MessageBox.Show(checkEligibility.Message);
            }


            try
            {
                SqlConnection expressionConnection = new SqlConnection("Data Source=DESKTOP-ILF4RKJ\\MSSQLSERVER01;Initial Catalog=bloodBank;Integrated Security=True");
                SqlCommand insertExpression =new  SqlCommand(insertQueryExpression,expressionConnection);

                expressionConnection.Open();
                insertExpression.ExecuteNonQuery();
                expressionConnection.Close();

                MessageBox.Show("Data Has Entered Successful","System Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
                
            }
            catch(Exception getExpression)
            {
                MessageBox.Show(getExpression.Message);
            }

        }

        private void txtFamilyFirstName_TextChanged(object sender, EventArgs e)
        {
            if(txtFamilyFirstName.TextLength > 0)
            {
                btnClear.Enabled = true;
                txtFamilyLastName.Enabled = true;
            }
            else if(txtFamilyFirstName.TextLength == 0)
            {
                btnClear.Enabled = false;
                txtFamilyLastName.Enabled = false;
            }
        }

        

        private void txtFamilyLastName_TextChanged(object sender, EventArgs e)
        {
            if(txtLastName.TextLength > 0)
            {
                rbtnFamilyMale.Enabled = true;
                rbtnFamilyFemale.Enabled = true;
            }
            else
            {
                rbtnFamilyMale.Enabled = false;
                rbtnFamilyFemale.Enabled = false;
            }
        }

        private void rbtnFamilyMale_CheckedChanged(object sender, EventArgs e)
        {
            if(rbtnFamilyMale.Checked)
            {
                btnFamilyAddMember.Enabled = true;
            }
            else
            {
                btnFamilyAddMember.Enabled = false;
            }
        }


        

        private void btnFamilyAddMember_Click(object sender, EventArgs e)
        {

            dataGrideViewFamily.Enabled = true;

            string gender;
            if (rbtnFamilyMale.Checked)
            {
                gender = "M";
            }
            else
            {
                gender = "F";
            }

            string insertGrideQuery = "insert into DonarFamilyMembers values('" + lblDID.Text + "','" + txtFamilyFirstName.Text + "','" + txtFamilyLastName.Text + "','" + gender + "')";


            //for (int countLoop = 0; countLoop < numericFamilyMembers.Value; countLoop++)
            //{

            txtFamilyFirstName.Enabled = true;
            txtFamilyFirstName.Focus();

            try
            {
                SqlConnection connectionForGride = new SqlConnection("Data Source=DESKTOP-ILF4RKJ\\MSSQLSERVER01;Initial Catalog=bloodBank;Integrated Security=True");
                SqlCommand grideInsertCommand = new SqlCommand(insertGrideQuery, connectionForGride);

                connectionForGride.Open();
                grideInsertCommand.ExecuteNonQuery();
                connectionForGride.Close();
                MessageBox.Show("Data Has Added To DataBase", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            catch (Exception grideMessage)
            {
                MessageBox.Show(grideMessage.Message, "System Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                var select = "select * from DonarFamilyMembers where DonarNIC = '" + lblDID.Text + "';";
                var c = new SqlConnection("Data Source=DESKTOP-ILF4RKJ\\MSSQLSERVER01;Initial Catalog=bloodBank;Integrated Security=True"); // Your Connection String here
                var dataAdapter = new SqlDataAdapter(select, c);

                var commandBuilder = new SqlCommandBuilder(dataAdapter);
                var ds = new DataSet();
                dataAdapter.Fill(ds);
                dataGrideViewFamily.ReadOnly = true;
                dataGrideViewFamily.DataSource = ds.Tables[0];

                MessageBox.Show("Data Added Successful", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtFamilyFirstName.Clear();
                txtFamilyLastName.Clear();
                txtFamilyLastName.Enabled = false;
                rbtnFamilyMale.Enabled = false;
                rbtnFamilyFemale.Enabled = false;
                txtFamilyFirstName.Focus();

            }
            catch (Exception showDataGride)
            {
                MessageBox.Show(showDataGride.Message, "System Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void btnFamilyClear_Click(object sender, EventArgs e)
        {
            txtFamilyFirstName.Clear();
            txtFamilyLastName.Clear();

            
            txtFamilyLastName.Enabled = false;
            btnFamilyAddMember.Enabled = false;
            rbtnFamilyMale.Enabled = false;
            rbtnFamilyFemale.Enabled = false;

            

        }

        private void rbtnFamilyFemale_CheckedChanged(object sender, EventArgs e)
        {
            if(rbtnFamilyFemale.Checked)
            {
                btnFamilyAddMember.Enabled = true;
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            Thread next = new Thread(openFormAgain);
            next.SetApartmentState(ApartmentState.STA);
            next.Start();
            this.Close();
        }

        private void openFormAgain()
        {
            Application.Run(new Get_Blood_Donator_Details());
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdateData_Click(object sender, EventArgs e)
        {
            txtTelephone.Enabled = true;
            txtAddress.Enabled = true;
            txtTelephone.Focus();

            txtFirstName.Enabled = false;
            txtLastName.Enabled = false;
            dtpDob.Enabled = false;
            rbtnMale.Enabled = false;
            rbtnFemale.Enabled = false;
            txtOtpCode.Enabled = false;
            txtEmail.Enabled = false;
            txtReEmail.Enabled = false;
            btnConfirmOtp.Enabled = false;
            btnGenerateOtp.Enabled = false;
            btnInsert.Enabled = false;
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtNic.Text);
            Thread openUpdate = new Thread(openUpdateForm);
            openUpdate.SetApartmentState(ApartmentState.STA);
            openUpdate.Start();
            this.Close();
        }

        private void openUpdateForm()
        {
            Application.Run(new Update_Donar_Details());
        }

        private void dataGrideViewFamily_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void aboutSoftwareToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void viewAndEditAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread log = new Thread(openClerckLoginForm);
            log.SetApartmentState(ApartmentState.STA);
            log.Start();
            this.Close();
        }

        private void openClerckLoginForm()
        {
            Application.Run(new Clerck_Account_Login());
        }

        private void btnLoginMenu_Click(object sender, EventArgs e)
        {
            Thread td = new Thread(goBackLoginMenu);
            td.SetApartmentState(ApartmentState.STA);
            td.Start();
        }

        private void goBackLoginMenu()
        {
            Application.Run(new Form1());
        }

        private void goToTheMainMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread td = new Thread(backToTheMainMenu);
            td.SetApartmentState(ApartmentState.STA);
            td.Start();
            this.Close();
        }

        private void backToTheMainMenu()
        {
            Application.Run(new Form1());
        }

        private void clerckUserManualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread td = new Thread(openClerkManual);
            td.SetApartmentState(ApartmentState.STA);
            td.Start();
            this.Close();
        }

        private void openClerkManual()
        {
            Application.Run(new Clerk_Manual());
        }

        private void aboutSoftwareToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Thread td = new Thread(openAboutUsForm);
            td.SetApartmentState(ApartmentState.STA);
            td.Start();
        }

        private void openAboutUsForm()
        {
            Application.Run(new About_Software());
        }
    }
}
