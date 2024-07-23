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
    public partial class Description_Form : Form
    {
        public Description_Form()
        {
            InitializeComponent();
        }

        private void Description_Form_Load(object sender, EventArgs e)
        {

            lblUserID.Text = Clipboard.GetText();

            btnInsert.Enabled = false;
            btnClear.Enabled = false;
            chkbConfirm.Enabled = false;
        }

        private void rtxtDescriptin_TextChanged(object sender, EventArgs e)
        {
            lblCount.Text = Convert.ToString(rtxtDescriptin.TextLength);

            if (rtxtDescriptin.TextLength > 5)
            {
                chkbConfirm.Checked = false;
                chkbConfirm.Enabled = true;
                btnClear.Enabled = true;
            }
            else
            {
                chkbConfirm.Checked = false;
                chkbConfirm.Enabled = false;
                btnClear.Enabled = false;
            }
        }

        private void chkbConfirm_CheckedChanged(object sender, EventArgs e)
        {
            if(chkbConfirm.Checked)
            {
                btnInsert.Enabled = true;
            }
            else
            {
                btnInsert.Enabled = false;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            rtxtDescriptin.Clear();
            chkbConfirm.Checked = false;
            chkbConfirm.Enabled = false;
            btnInsert.Enabled = false;
            btnClear.Enabled = false;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                string updateDescriptionColumn = "update DeletedAccounts set description ='" + rtxtDescriptin.Text + "' where UserID ='" + lblUserID.Text + "'";
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-ILF4RKJ\\MSSQLSERVER01;Initial Catalog=bloodBank;Integrated Security=True");
                SqlCommand cmd = new SqlCommand(updateDescriptionColumn,con);
                con.Open();

                cmd.ExecuteNonQuery();

                con.Close();

                MessageBox.Show("Description Has Added Successfully","System Information",MessageBoxButtons.OK,MessageBoxIcon.Information);


                Thread td = new Thread(openAdminForm);
                td.SetApartmentState(ApartmentState.STA);
                td.Start();
                this.Close();

            }
            catch(Exception insertDescriptionData)
            {
                MessageBox.Show(insertDescriptionData.Message);
            }
        }

        private void openAdminForm()
        {
            Application.Run(new AdminForm());
        }
    }
}
