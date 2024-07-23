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
    public partial class Update_Donar_Details : Form
    {
        public Update_Donar_Details()
        {
            InitializeComponent();
        }

        private void txtFirstName_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Update_Donar_Details_Load(object sender, EventArgs e)
        {

            ckbAddFamilyMember.Checked = false;
            ckbDeleteFamilyMember.Checked = false;
            ckbUpdateValues.Checked = false;

            try
            {
                txtEditNic.Text = Clipboard.GetText();
                txtEditNic.Enabled = false;


                string[] donarDataArray = new string[7];

                SqlConnection connectionForDonar = new SqlConnection("Data Source=DESKTOP-ILF4RKJ\\MSSQLSERVER01;Initial Catalog=bloodBank;Integrated Security=True");

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
                txtEditAddressDonar.Text = donarDataArray[3];
                txtEditTelephoneDonar.Text = donarDataArray[2];
                dtpEditDob.Text = donarDataArray[4];
                txtEditEmail.Text = donarDataArray[6];

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
                txtEditEmail.ReadOnly = true;
                txtEditNic.ReadOnly = true;

                txtEditTelephoneDonar.ReadOnly = true;
                txtEditAddressDonar.ReadOnly = true;

                txtEditValues.Enabled = false;
                cmbEditMenu.Enabled = false;
                btnEditClear.Enabled = false;
                btnEditUpdate.Enabled = false;
                txtEditFamilyMemberID.Enabled = false;
                btnEditClearID.Enabled = false;
                btnEditDeleteMember.Enabled = false;
                txtEditFamilyFirstName.Enabled = false;
                txtEditFamilyLastName.Enabled = false;
                rbtnEditFamilyMale.Enabled = false;
                rbtnEditFamilyFemale.Enabled = false;
                btnEditClearAddFamilyMember.Enabled = false;
                btnEditAddFamilyMember.Enabled = false;

                string dataGridViewQuery = "select * from DonarFamilyMembers";

                SqlDataAdapter adp = new SqlDataAdapter(dataGridViewQuery,connectionForDonar);
                DataTable dataTable = new DataTable();
                adp.Fill(dataTable);
                dgvDonarFamily.DataSource = dataTable;

            }
            catch(Exception loadEvent)
            {
                MessageBox.Show(loadEvent.Message);
            }



        }

        private void groupBox6_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

       

        private void btnEditClear_Click(object sender, EventArgs e)
        {
            cmbEditMenu.SelectedIndex = -1;
            txtEditValues.Clear();
            txtEditValues.Enabled = false;
        }

        private void ckbDeleteFamilyMember_CheckedChanged(object sender, EventArgs e)
        {
            txtEditFamilyMemberID.Enabled = ckbDeleteFamilyMember.Checked;
        }

        private void ckbAddFamilyMember_CheckedChanged(object sender, EventArgs e)
        {
            txtEditFamilyFirstName.Enabled = ckbAddFamilyMember.Checked;
        }

        private void cmbEditMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtEditValues.Clear();
            txtEditValues.Focus();
            if(cmbEditMenu.Text.Length > 0)
            {
                txtEditValues.Enabled = true;
            }
            else
            {
                txtEditValues.Enabled = false;
            }
            if(cmbEditMenu.SelectedIndex == 0)
            {
                txtEditValues.MaxLength = 50;
            }
            if(cmbEditMenu.SelectedIndex == 1)
            {
                txtEditValues.MaxLength = 10;
            }
        }

        private void txtEditValues_TextChanged(object sender, EventArgs e)
        {
            if(txtEditValues.TextLength > 0)
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

        private void txtEditFamilyMemberID_TextChanged(object sender, EventArgs e)
        {
            if(txtEditFamilyMemberID.TextLength > 0)
            {
                btnEditClearID.Enabled = true;
                btnEditDeleteMember.Enabled = true;
            }
            else
            {
                btnEditClearID.Enabled = false;
                btnEditDeleteMember.Enabled = false;
            }
        }

        private void txtEditFamilyFirstName_TextChanged(object sender, EventArgs e)
        {
            if(txtEditFamilyFirstName.TextLength > 0)
            {
                txtEditFamilyLastName.Enabled = true;
            }
            else
            {
                txtEditFamilyLastName.Enabled = false;
            }
        }

        private void txtEditFamilyLastName_TextChanged(object sender, EventArgs e)
        {
            if(txtEditFamilyLastName.TextLength > 0)
            {
                rbtnEditFamilyMale.Enabled = true;
                rbtnEditFamilyFemale.Enabled = true;
            }
            else
            {
                rbtnEditFamilyMale.Enabled = false;
                rbtnEditFamilyFemale.Enabled = false;
            }
        }

        private void rbtnEditFamilyMale_CheckedChanged(object sender, EventArgs e)
        {
            btnEditClearAddFamilyMember.Enabled = rbtnEditFamilyMale.Checked;
            btnEditAddFamilyMember.Enabled = rbtnEditFamilyMale.Checked;

        }

        private void btnEditBack_Click(object sender, EventArgs e)
        {
            Thread goBack = new Thread(openDonarDetailsForm);
            goBack.SetApartmentState(ApartmentState.STA);
            goBack.Start();
            this.Close();
        }

        private void openDonarDetailsForm()
        {
            Application.Run(new Get_Blood_Donator_Details());
        }

        private void btnEditExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEditClearID_Click(object sender, EventArgs e)
        {
            txtEditFamilyMemberID.Clear();
            txtEditFamilyMemberID.Focus();
        }

        private void btnEditClearAddFamilyMember_Click(object sender, EventArgs e)
        {
            txtEditFamilyFirstName.Clear();
            txtEditFamilyLastName.Clear();
            rbtnEditFamilyMale.Checked = false;
            rbtnEditFamilyFemale.Checked = false;

            txtEditFamilyLastName.Enabled = false;
            rbtnEditFamilyMale.Enabled = false;
            rbtnEditFamilyFemale.Enabled = false;
            txtEditFamilyFirstName.Focus();

        }

        private void rbtnEditFamilyFemale_CheckedChanged(object sender, EventArgs e)
        {
            btnEditClearAddFamilyMember.Enabled = rbtnEditFamilyFemale.Checked;
            btnEditAddFamilyMember.Enabled = rbtnEditFamilyFemale.Checked;
        }

        private void txtEditValues_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cmbEditMenu.SelectedIndex == 1)
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
            
        }

        private void txtEditFamilyFirstName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void txtEditFamilyLastName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void txtEditFamilyMemberID_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnEditAddFamilyMember_Click(object sender, EventArgs e)
        {
            string memberGender = "";

            if(rbtnEditFamilyMale.Checked)
            {
                memberGender = "M";
            }
            else if(rbtnEditFamilyFemale.Checked)
            {
                memberGender = "F";
            }

            string insertGrideQuery = "insert into DonarFamilyMembers (DonarNIC,MemberFirstName,MemberLastName,MemberGender) values ('"+txtEditNic.Text+"','"+txtEditFamilyFirstName.Text+"','"+txtEditFamilyLastName.Text+"','"+ memberGender + "')"; 
                

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
                var select = "select * from DonarFamilyMembers where DonarNIC = '" + txtEditNic.Text + "';";
                var c = new SqlConnection("Data Source=DESKTOP-ILF4RKJ\\MSSQLSERVER01;Initial Catalog=bloodBank;Integrated Security=True"); // Your Connection String here
                var dataAdapter = new SqlDataAdapter(select, c);

                var commandBuilder = new SqlCommandBuilder(dataAdapter);
                var ds = new DataSet();
                dataAdapter.Fill(ds);
                dgvDonarFamily.ReadOnly = true;
                dgvDonarFamily.DataSource = ds.Tables[0];

                MessageBox.Show("Data Added Successful", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtEditFamilyFirstName.Clear();
                txtEditFamilyLastName.Clear();
                txtEditFamilyFirstName.Focus();

            }
            catch (Exception showDataGride)
            {
                MessageBox.Show(showDataGride.Message, "System Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditDeleteMember_Click(object sender, EventArgs e)
        {
            string query = "delete from DonarFamilyMembers where ID ='" + Convert.ToInt32(txtEditFamilyMemberID.Text) + "'";

            try
            {
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-ILF4RKJ\\MSSQLSERVER01;Initial Catalog=bloodBank;Integrated Security=True");
                SqlCommand cmd = new SqlCommand(query,con);

                con.Open();

                cmd.ExecuteNonQuery();

                con.Close();

                MessageBox.Show("Member Has Deleted","System Information",MessageBoxButtons.OK,MessageBoxIcon.Information);

                txtEditFamilyMemberID.Clear();
                txtEditFamilyMemberID.Focus();

                SqlDataAdapter adp = new SqlDataAdapter("select * from DonarFamilyMembers",con);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                dgvDonarFamily.DataSource = dt;


            }
            catch(Exception deleteFamilyMember)
            {
                MessageBox.Show(deleteFamilyMember.Message,"System Information",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void btnEditUpdate_Click(object sender, EventArgs e)
        {
            string query1 = "update  Donar set DonarAddress ='" + txtEditValues.Text + "' where NIC = '"+ txtEditNic.Text + "'";
            string query2 = "update  Donar set Telephone ='" + txtEditValues.Text + "' where NIC = '" + txtEditNic.Text + "'";


            SqlConnection con = new SqlConnection("Data Source=DESKTOP-ILF4RKJ\\MSSQLSERVER01;Initial Catalog=bloodBank;Integrated Security=True");

            if(cmbEditMenu.SelectedIndex == 0)
            {
                try
                {
                    SqlCommand addressChanged = new SqlCommand(query1,con);

                    con.Open();

                    addressChanged.ExecuteNonQuery();

                    con.Close();

                    MessageBox.Show("Address Is Updated", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtEditAddressDonar.Text = txtEditValues.Text;
                    txtEditValues.Clear();
                    txtEditValues.Enabled = false;
                }
                catch(Exception updateAddress)
                {
                    MessageBox.Show(updateAddress.Message, "System Information", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }

            if (cmbEditMenu.SelectedIndex == 1)
            {
                try
                {
                    SqlCommand telephoneChange = new SqlCommand(query2, con);

                    con.Open();

                    telephoneChange.ExecuteNonQuery();

                    con.Close();

                    MessageBox.Show("Telephone Is Updated", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtEditTelephoneDonar.Text = txtEditValues.Text;
                    txtEditValues.Clear();
                    txtEditValues.Enabled = false;
                }
                catch (Exception updateAddress)
                {
                    MessageBox.Show(updateAddress.Message, "System Information", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }

        }

        private void ckbUpdateValues_CheckedChanged(object sender, EventArgs e)
        {
            cmbEditMenu.Enabled = ckbUpdateValues.Enabled;
        }
    }
}
