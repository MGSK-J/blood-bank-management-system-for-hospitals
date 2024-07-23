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
    public partial class ViewAllDonarsPreEligibilityData : Form
    {
        public ViewAllDonarsPreEligibilityData()
        {
            InitializeComponent();
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            try
            {
                string[] validness = new string[2];
                string queryForValidness = "select ClerkEligibility,Pre_donationEligibility from DonarEligibility where DonarNIC ='" + txtDonarNIC.Text + "' and DDate ='" + DateTime.Now.ToString("yyyy-M-d") + "'";

                SqlConnection con = new SqlConnection("Data Source=DESKTOP-ILF4RKJ\\MSSQLSERVER01;Initial Catalog=bloodBank;Integrated Security=True");
                SqlCommand cmd = new SqlCommand(queryForValidness,con);

                con.Open();

                SqlDataReader readValidness = cmd.ExecuteReader();
                readValidness.Read();

                validness[0] = Convert.ToString(readValidness[0]);
                validness[1] = Convert.ToString(readValidness[1]);

                con.Close();

                if((validness[0] == "True" && validness[1] == "True") ||(validness[0] == "True" && validness[1] == "False"))
                {



                    string[] donarDataArray = new string[13];
                    string fillQueary = "select Diabetes,Pressure,HIV,Heart_Disease,COVID19,Kidney_Disease,Donated_Blood_Before,Had_Surgery,Liver_Disease,Vaccinated,Dengue,Cancer,Athor_Illness from DonarExpression where DonatedDate ='" + DateTime.Now.ToString("yyyy-M-d") + "' and DonarNIC ='" + txtDonarNIC.Text + "'";
                    SqlConnection connectionForDonar = new SqlConnection("Data Source=DESKTOP-ILF4RKJ\\MSSQLSERVER01;Initial Catalog=bloodBank;Integrated Security=True");

                    //string getDonarValuesQuery = "select FirstName,LastName,Telephone,DonarAddress,DOB,Gender,EMail from Donar where NIC ='" + txtEditNic.Text + "'";

                    SqlCommand getDonarValues = new SqlCommand(fillQueary, connectionForDonar);

                    connectionForDonar.Open();

                    SqlDataReader readDonar = getDonarValues.ExecuteReader();
                    readDonar.Read();


                    for (int countValue = 0; countValue < 13; countValue++)
                    {
                        donarDataArray[countValue] = Convert.ToString(readDonar[countValue]);
                    }




                    con.Close();

                    for (int x = 0; x < 13; x++)
                    {
                        string statusE = donarDataArray[x];
                        switch (statusE)
                        {
                            case "YES":
                                cblExpression.SetItemChecked(x, true);
                                break;
                            case "NO":
                                cblExpression.SetItemChecked(x, false);
                                break;

                        }
                    }

                    //*********************************************************************


                    string[] fillDonarDetails = new string[7];

                    string getDonarValuesQuery = "select FirstName,LastName,Telephone,DonarAddress,DOB,Gender,EMail from Donar where NIC ='" + txtDonarNIC.Text + "'";

                    SqlCommand getDonarValuesE = new SqlCommand(getDonarValuesQuery, con);

                    con.Open();

                    SqlDataReader readDonarDetails = getDonarValuesE.ExecuteReader();
                    readDonarDetails.Read();

                    for(int countvalue =0; countvalue < 7; countvalue++)
                    {
                        fillDonarDetails[countvalue] = Convert.ToString(readDonarDetails[countvalue]);
                    }

                    con.Close();

                    if(fillDonarDetails[5] == "M")
                    {
                        rbtnEditMale.Checked = true;
                    }
                    else if(fillDonarDetails[5] == "F")
                    {
                        rbtnEditFemale.Checked = true;
                    }

                    txtEditNic.Text = txtDonarNIC.Text;
                    txtEditFirstName.Text = fillDonarDetails[0];
                    txtEditLastName.Text = fillDonarDetails[1];
                    
                    dtpEditDob.Value = Convert.ToDateTime(fillDonarDetails[4]);
                    //dtpEditDob.MinDate = dtpEditDob.Value;
                    //dtpEditDob.MaxDate = dtpEditDob.Value;


                    string getBirthday = "select DOB from Donar where NIC ='" + txtEditNic.Text + "'";


                    
                    SqlCommand catchBirthDay = new SqlCommand(getBirthday, con);
                    con.Open();

                    string birthDay = Convert.ToString(catchBirthDay.ExecuteScalar());
                    DateTime getBirthYear = Convert.ToDateTime(birthDay);
                    int donarAge = Convert.ToInt32(DateTime.Now.ToString("yyyy")) - Convert.ToInt32(getBirthYear.Year);

                    txtEditAge.Text = Convert.ToString(donarAge);

                    con.Close();


                    string[] storeEligibilityData = new string[7];
                    string getEligibilityData = "select temp,pulses,systolicbp,diastolicbp,dweight,hemoglobin,bloodType from PredonationEligibility where DonarNIC ='" + txtEditNic.Text + "' and DDate = '" + DateTime.Now.ToString("yyyy-M-d") + "'";
                    SqlCommand eligibilityCommand = new SqlCommand(getEligibilityData, con);

                    con.Open();

                    SqlDataReader readTestdata = eligibilityCommand.ExecuteReader();
                    readTestdata.Read();

                    for(int countLoop = 0; countLoop < 7;countLoop++)
                    {
                        storeEligibilityData[countLoop] = Convert.ToString(readTestdata[countLoop]);
                    }
                    con.Close();

                    txtLoadTemp.Text = storeEligibilityData[0];
                    txtLoadPulses.Text = storeEligibilityData[1];
                    txtLoadS.Text = storeEligibilityData[2];
                    txtLoadD.Text = storeEligibilityData[3];
                    txtLoadWeight.Text = storeEligibilityData[4];
                    txtLoadHemoglobin.Text = storeEligibilityData[5];
                    txtLoadBloodType.Text = storeEligibilityData[6];

                    //*********************************************************************


                    txtLoadTemp.ReadOnly = true;
                    txtLoadPulses.ReadOnly = true;
                    txtLoadS.ReadOnly = true;
                    txtLoadD.ReadOnly = true;
                    txtLoadWeight.ReadOnly = true;
                    txtLoadHemoglobin.ReadOnly = true;
                    txtLoadBloodType.ReadOnly = true;

                    txtEditNic.ReadOnly = true;
                    txtEditFirstName.ReadOnly = true;
                    txtEditLastName.ReadOnly = true;
                    txtEditAge.ReadOnly = true;

                }
                else
                {
                    MessageBox.Show("This Donar is not complete the whole process or not available");
                }

            }
            catch(Exception checkAvailable)
            {
                MessageBox.Show(checkAvailable.Message);
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void ViewAllDonarsPreEligibilityData_Load(object sender, EventArgs e)
        {

        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }
    }
}
