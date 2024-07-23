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

namespace Blood_Bank
{
    public partial class Doctor : Form
    {
        public Doctor()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void btnCheck_Click(object sender, EventArgs e)
        {

            bool isDonated = true;
            try
            {
                string systemDate = DateTime.Now.ToString("yyyy-M-d");
                string checkQuery = "select ClerkEligibility from DonarEligibility where DDate = '" + systemDate + "' and DonarNIC ='" + txtDonarNIC.Text + "'";
                bool isValid = false;
                string result;

                string tokenExpireQuery = "update  Token set Status ='SERVING' where NIC = '" + txtDonarNIC.Text + "' and TokenDate = '" + systemDate + "'";

                SqlConnection con = new SqlConnection("Data Source=DESKTOP-ILF4RKJ\\MSSQLSERVER01;Initial Catalog=bloodBank;Integrated Security=True");
                SqlCommand cmd = new SqlCommand(checkQuery, con);
                SqlCommand tokenExpire = new SqlCommand(tokenExpireQuery,con);
                con.Open();

                tokenExpire.ExecuteNonQuery();

                result = Convert.ToString(cmd.ExecuteScalar());

                con.Close();

                if (result == "True")
                {
                    isValid = true;

                    string checkStatus = "select Pre_donationEligibility from DonarEligibility where DonarNIC ='" + txtDonarNIC.Text + "' and DDate ='" + systemDate + "'";
                    string status;
                    SqlCommand statusCommand = new SqlCommand(checkStatus,con);
                    con.Open();
                    status = Convert.ToString(statusCommand.ExecuteScalar());
                    con.Close();

                    if(status == "NOTCHECKED")
                    {
                        isDonated = false;
                    }
                    else
                    {
                        isDonated = true;
                    }

                }
                else
                {
                    isValid = false;
                }
                //MessageBox.Show(Convert.ToString(isDonated));
                //MessageBox.Show("result "+ result);
                if (isValid && !isDonated)
                {

                    string[] donarDataArray = new string[13];

                    string fillQueary = "select Diabetes,Pressure,HIV,Heart_Disease,COVID19,Kidney_Disease,Donated_Blood_Before,Had_Surgery,Liver_Disease,Vaccinated,Dengue,Cancer,Athor_Illness from DonarExpression where DonatedDate ='" + systemDate + "' and DonarNIC ='" + txtDonarNIC.Text + "'";


                    SqlConnection connectionForDonar = new SqlConnection("Data Source=DESKTOP-ILF4RKJ\\MSSQLSERVER01;Initial Catalog=bloodBank;Integrated Security=True");

                    //string getDonarValuesQuery = "select FirstName,LastName,Telephone,DonarAddress,DOB,Gender,EMail from Donar where NIC ='" + txtEditNic.Text + "'";

                    SqlCommand getDonarValues = new SqlCommand(fillQueary, connectionForDonar);

                    connectionForDonar.Open();

                    SqlDataReader readDonar = getDonarValues.ExecuteReader();
                    readDonar.Read();

                    
                    for(int countValue = 0; countValue < 13; countValue++)
                    {
                        donarDataArray[countValue] = Convert.ToString(readDonar[countValue]);
                    }


                    

                    con.Close();

                    for (int x = 0; x < 13; x++)
                    {
                       string status = donarDataArray[x];
                        switch (status)
                       {
                            case "YES":
                                cblExpression.SetItemChecked(x ,true);
                                break;
                            case "NO":
                                cblExpression.SetItemChecked(x, false);
                                break;

                        }
                    }




                    try
                    {
                        string fullName;
                        string firstName;
                        string lastName;
                        string donarID;
                        int tokenNumber;
                        int countTokenNumber;
                        string gender;

                        //string getNameQuery = "select DonarID,FirstName,LastName from Donar where NIC = '" + txtDonarNIC.Text + "'";
                        //string getIDQuery = "select DonarId from Donar where NIC = '" + txtDonarNIC.Text + "'";
                        string getFirstName = "select FirstName from Donar where NIC ='" + txtDonarNIC.Text + "'";
                        string getLastName = "select LastName from Donar where NIC ='" + txtDonarNIC.Text + "'";
                        string getTokenNumber = "select TokenNumber from Token where NIC ='" + txtDonarNIC.Text + "' and TokenDate = '" + DateTime.Now.ToString("yyyy-M-d") + "'";
                        string countNumberOfRegistration = "select count(TokenNumber) from Token where NIC ='" + txtDonarNIC.Text + "'";
                        string getGender = "select Gender from Donar where NIC ='" + txtDonarNIC.Text + "'";

                        //SqlConnection con = new SqlConnection("Data Source=DESKTOP-NAVOD\\SQLEXPRESS;Initial Catalog=bloodBank;Integrated Security=True");

                        //SqlCommand getID = new SqlCommand(getIDQuery, con);
                        SqlCommand getToken = new SqlCommand(getTokenNumber, con);
                        SqlCommand getCount = new SqlCommand(countNumberOfRegistration, con);
                        SqlCommand firstNameCommand = new SqlCommand(getFirstName, con);
                        SqlCommand lastNameCommand = new SqlCommand(getLastName,con);
                        SqlCommand getGenderCommand = new SqlCommand(getGender,con);

                        con.Open();

                        //SqlDataReader rdr = nameID.ExecuteReader();
                        //fullName = Convert.ToString(rdr[1] + " " + rdr[2]);
                        //donarID = Convert.ToString(getID.ExecuteNonQuery());
                        // because of reader does not work here 

                        firstName = Convert.ToString(firstNameCommand.ExecuteScalar());
                        lastName = Convert.ToString(lastNameCommand.ExecuteScalar());
                        tokenNumber = Convert.ToInt32(getToken.ExecuteScalar());
                        countTokenNumber = Convert.ToInt32(getCount.ExecuteScalar());
                        gender = Convert.ToString(getGenderCommand.ExecuteScalar());

                        con.Close();

                        fullName = firstName + " " + lastName;


                        string connectionString = "Data Source=DESKTOP-ILF4RKJ\\MSSQLSERVER01;Initial Catalog=bloodBank;Integrated Security=True";
                        string query = "select DonarId from Donar where NIC = '" + txtDonarNIC.Text + "'";

                        SqlConnection checkConnection = new SqlConnection(connectionString);
                        SqlCommand checkCommand = new SqlCommand(query, checkConnection);

                        checkConnection.Open();
                        donarID = Convert.ToString(checkCommand.ExecuteScalar());
                        checkConnection.Close();


                        lblShowDonarIDResult.Text = donarID;
                        lblName.Text = fullName;
                        lblToken.Text = Convert.ToString(tokenNumber);
                        lblCount.Text = Convert.ToString(countTokenNumber - 1);

                        if(gender == "M")
                        {
                            lblGender.Text = "Male";
                        }
                        if(gender == "F")
                        {
                            lblGender.Text = "Female";
                        }

                        cbBloodType.Enabled = true;


                    }
                    catch (Exception getData)
                    {
                        MessageBox.Show(getData.Message);
                    }




                }
                else if (isValid && isDonated)
                {
                    MessageBox.Show("Registered Donar Is Not Allow To Donate Blood\n[1]- Donated \n[2]-Clerk Eligibility Is Failed", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    cbBloodType.Enabled = false;

                    Thread td = new Thread(openDoctorFormAgain);
                    td.SetApartmentState(ApartmentState.STA);
                    td.Start();
                    this.Close();

                }
                else if(!isValid)
                {
                    MessageBox.Show("Following Donar Has Failed At Clerck Eligibility","System Information",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    Thread tdd = new Thread(openExistFormAgain);
                    tdd.SetApartmentState(ApartmentState.STA);
                    tdd.Start();
                }
                else
                {
                    MessageBox.Show("Cant Continue The Process","System Information",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }
            }
            catch(Exception errorHandle)
            {
                MessageBox.Show(errorHandle.Message);
            }

        }

        private void openExistFormAgain()
        {
            Application.Run(new Doctor());
        }

        private void openDoctorFormAgain()
        {
            Application.Run(new Doctor());
        }

        private void Doctor_Load(object sender, EventArgs e)
        {
            btnCheck.Enabled = true;
            cblExpression.Enabled = false;
            btnUpdate.Enabled = false;
            cbBloodType.Enabled = false;
            txtWeight.Enabled = false;
            txtTemp.Enabled = false;
            txtPluses.Enabled = false;
            txtSbp.Enabled = false;
            txtDbp.Enabled = false;
            txtHemoglobin.Enabled = false;

            

        }

        private void openTokenForm()
        {
            Application.Run(new Form2());
        }

        private void txtDonarNIC_TextChanged(object sender, EventArgs e)
        {
            if(txtDonarNIC.TextLength > 0)
            {
                btnCheck.Enabled = true;
            }
            else
            {
                btnCheck.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thread td = new Thread(openTokenFormDisplay);
            td.SetApartmentState(ApartmentState.STA);
            td.Start();
        }

        private void openTokenFormDisplay()
        {
            Application.Run(new Form2());
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            txtDonarNIC.Clear();
            txtDonarNIC.Focus();
            try
            {
                /*
                string tokenExpireQuery = "update  Token set Status ='EXPIRE' where NIC = '" + txtDonarNIC.Text + "' and TokenDate = '" + DateTime.Now.ToString("yyyy-M-d") + "'";

                SqlConnection con = new SqlConnection("Data Source=DESKTOP-NAVOD\\SQLEXPRESS;Initial Catalog=bloodBank;Integrated Security=True");

                SqlCommand tokenExpire = new SqlCommand(tokenExpireQuery, con);
                con.Open();

                tokenExpire.ExecuteNonQuery();

                con.Close();*/
            }
            catch (Exception updateToExpire)
            {
                MessageBox.Show("b");
                MessageBox.Show(updateToExpire.Message);
            }
        }

        private void viewAndEditAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(openDoctorLoginForm);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
            this.Close();
        }

        private void openDoctorLoginForm()
        {
            Application.Run(new Doctor_Account_View());
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

        private void cbBloodType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbBloodType.SelectedIndex == 0 || cbBloodType.SelectedIndex == 1 || cbBloodType.SelectedIndex == 2 || cbBloodType.SelectedIndex == 3 || cbBloodType.SelectedIndex == 4 || cbBloodType.SelectedIndex == 5 || cbBloodType.SelectedIndex == 6 || cbBloodType.SelectedIndex == 7)
            {
                txtWeight.Enabled = true;
            }
            else
            {
                txtWeight.Enabled = false;
            }
            if(cbBloodType.Text.Length > 0)
            {
                btnClear.Enabled = true;
            }
            else
            {
                btnClear.Enabled = false;
            }
        }

        private void txtWeight_TextChanged(object sender, EventArgs e)
        {
            if(txtWeight.TextLength > 0)
            {
                txtTemp.Enabled = true;
            }
            else
            {
                txtTemp.Enabled = false;
            }
        }

        private void txtTemp_TextChanged(object sender, EventArgs e)
        {
            if(txtTemp.TextLength > 0)
            {
                txtPluses.Enabled = true;
            }
            else
            {
                txtPluses.Enabled = false;
            }
        }

        private void txtPluses_TextChanged(object sender, EventArgs e)
        {
            if(txtPluses.TextLength > 0)
            {
                txtSbp.Enabled = true;
            }
            else
            {
                txtSbp.Enabled = false;
            }
        }

        private void txtSbp_TextChanged(object sender, EventArgs e)
        {
            if(txtSbp.TextLength > 0)
            {
                txtDbp.Enabled = true;
            }
            else
            {
                txtDbp.Enabled = false;
            }
        }

        private void txtDbp_TextChanged(object sender, EventArgs e)
        {
            if(txtDbp.TextLength > 0)
            {
                txtHemoglobin.Enabled = true;
            }
            else
            {
                txtHemoglobin.Enabled = false;
            }
        }

        private void txtHemoglobin_TextChanged(object sender, EventArgs e)
        {
            if(txtHemoglobin.TextLength > 0)
            {
                chkbConfirmByDoctor.Enabled = true;
            }
            else
            {
                chkbConfirmByDoctor.Enabled = false;
            }
        }

        private void chkbConfirmByDoctor_CheckedChanged(object sender, EventArgs e)
        {
            if(chkbConfirmByDoctor.Checked)
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
                Clipboard.SetText(txtDonarNIC.Text);

                string getBirthday = "select DOB from Donar where NIC ='" + txtDonarNIC.Text + "'";


                SqlConnection con = new SqlConnection("Data Source=DESKTOP-ILF4RKJ\\MSSQLSERVER01;Initial Catalog=bloodBank;Integrated Security=True");
                SqlCommand cmd = new SqlCommand(getBirthday, con);
                con.Open();

                string birthDay = Convert.ToString(cmd.ExecuteScalar());
                DateTime getBirthYear = Convert.ToDateTime(birthDay);
                int donarAge = Convert.ToInt32(DateTime.Now.ToString("yyyy")) - Convert.ToInt32(getBirthYear.Year);

                con.Close();

                float hemoglobin = float.Parse(txtHemoglobin.Text);
                float weight = float.Parse(txtWeight.Text);

                string insertQuery = "insert into PredonationEligibility values ('" + txtDonarNIC.Text + "','" + DateTime.Now.ToString("yyyy-M-d") + "','" + donarAge + "','" + Convert.ToInt32(txtTemp.Text) + "','" + Convert.ToInt32(txtPluses.Text) + "','" + Convert.ToInt32(txtSbp.Text) + "','" + Convert.ToInt32(txtDbp.Text) + "','" + Convert.ToDecimal(txtWeight.Text) + "','" + Convert.ToDecimal(txtHemoglobin.Text) + "','" + Convert.ToString(cbBloodType.Text) + "')";
                SqlCommand insertData = new SqlCommand(insertQuery, con);

                con.Open();

                insertData.ExecuteNonQuery();

                con.Close();

                string preEgiligility = "False";

                if(lblGender.Text == "Male")
                {
                    if (donarAge >= 18 && donarAge <= 60 && Convert.ToInt32(txtTemp.Text) == 37 && weight >= 45 && Convert.ToInt32(txtPluses.Text) >= 60 && Convert.ToInt32(txtPluses.Text) <= 100 && Convert.ToInt32(txtSbp.Text) < 120 && Convert.ToInt32(txtDbp.Text) < 80 && hemoglobin >= 13.5 && hemoglobin < 17.5)
                    {
                        preEgiligility = "True";
                    }
                    else
                    {
                        preEgiligility = "False";
                    }
                }
                if(lblGender.Text == "Female")
                {
                    if (donarAge >= 18 && donarAge <= 60 && Convert.ToInt32(txtTemp.Text) == 37 && weight >= 45 && Convert.ToInt32(txtPluses.Text) >= 60 && Convert.ToInt32(txtPluses.Text) <= 100 && Convert.ToInt32(txtSbp.Text) < 120 && Convert.ToInt32(txtDbp.Text) < 80 && hemoglobin >= 12.0 && hemoglobin < 15.5)
                    {
                        preEgiligility = "True";
                    }
                    else
                    {
                        preEgiligility = "False";
                    }
                }

                string insertEligibilityQuery = "update DonarEligibility set Pre_donationEligibility = '" + preEgiligility + "' where DonarNIC ='" + txtDonarNIC.Text + "' and DDate = '" + DateTime.Now.ToString("yyyy-M-d") + "'";

                try
                {
                    SqlCommand insertEligibility = new SqlCommand(insertEligibilityQuery,con);
                    con.Open();

                    insertEligibility.ExecuteNonQuery();

                    con.Close();
                }
                catch(Exception insertEligibilityException)
                {
                    MessageBox.Show(insertEligibilityException.Message);
                }

                MessageBox.Show("Data Has Added", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                if(preEgiligility == "True")
                {
                    MessageBox.Show("This Donar Is Eligible", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("This Donar Is Not Eligible", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                Thread td = new Thread(openConfirmForm);
                td.SetApartmentState(ApartmentState.STA);
                td.Start();
                this.Close();

            }
            catch(Exception testedByDoctor)
            {
                MessageBox.Show(testedByDoctor.Message);
            }
        }

        private void openConfirmForm()
        {
            Application.Run(new DonarInformationToDoctor());
        }

        private void viewDonarsReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void viewTokenWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread td = new Thread(openTokenWindow);
            td.SetApartmentState(ApartmentState.STA);
            td.Start();
        }

        private void openTokenWindow()
        {
            Application.Run(new Form2());
        }

        private void viewDonarsReportsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Thread openDonar = new Thread(openDonarTestDoctor);
            openDonar.SetApartmentState(ApartmentState.STA);
            openDonar.Start();
        }

        private void openDonarTestDoctor()
        {
            Application.Run(new ViewAllDonarsPreEligibilityData());
        }

        private void btnClear_Click(object sender, EventArgs e)
        {

            
            cbBloodType.Enabled = false;
            cbBloodType.SelectedIndex = -1;

            
            txtTemp.Clear();
            txtTemp.Enabled = false;

            txtWeight.Clear();
            txtWeight.Enabled = false;


            txtPluses.Clear();
            txtPluses.Enabled = false;


            txtSbp.Clear();
            txtSbp.Enabled = false;


            txtDbp.Clear();
            txtDbp.Enabled = false;


            txtHemoglobin.Clear();
            txtHemoglobin.Enabled = false;

            btnUpdate.Enabled = false;
            btnClear.Enabled = false;
        }

        private void checkUserManualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread td = new Thread(openDoctorManualForm);
            td.SetApartmentState(ApartmentState.STA);
            td.Start();
        }

        private void openDoctorManualForm()
        {
            Application.Run(new Doctor_Manual());
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
    }
}
