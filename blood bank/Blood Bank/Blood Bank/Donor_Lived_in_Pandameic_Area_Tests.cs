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

namespace Blood_Bank
{
    public partial class Donor_Lived_in_Pandameic_Area_Tests : Form
    {

        string westeligibility, cytomegoloeligibility, chagaseligibility, ELIGIBILITY;

        public Donor_Lived_in_Pandameic_Area_Tests()
        {
            InitializeComponent();

            txtbloodunitid.Enabled = false;
            btnwesteligibility.Enabled = false;
            btnwestconfirm.Enabled = false;
            btnwestupdate.Enabled = false;
            btnchagasupdate.Enabled = false;
            btnchagasconfirm.Enabled = false;
            btnchagaselibility.Enabled = false;
            btncytomegaloupdate.Enabled = false;
            btncytomegaloconfirm.Enabled = false;
            btncytomegaloeligibility.Enabled = false;

        }

        private void Donor_Lived_in_Pandameic_Area_Tests_Load(object sender, EventArgs e)
        {
            txtbloodunitid.Text = Clipboard.GetText();
        }

        SqlConnection Con = new SqlConnection("Data Source=DESKTOP-ILF4RKJ\\MSSQLSERVER01;Initial Catalog=bloodBank;Integrated Security=True");
        private void btnwestinsert_Click(object sender, EventArgs e)
        {
            if (txtPCRSerum.Text == "")
            {
                if (txtPCRCSF.Text == "")
                {
                    if (txtspIgMSerum.Text == "")
                    {
                        if (txtPCRCSF.Text == "")
                        {
                            MessageBox.Show("Missing Ingormation","System Information",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            else
            {
                try
                { //WEST NILE
                    SqlConnection con = new SqlConnection("Data Source=DESKTOP-ILF4RKJ\\MSSQLSERVER01;Initial Catalog=bloodBank;Integrated Security=True");
                    String qry = "INSERT INTO WESTNILEVIRUS VALUES('" + txtbloodunitid.Text + "'  , " + txtPCRSerum.Text + " , " + txtPCRCSF.Text + "," + txtspIgMSerum.Text + "," + txtspeIgMCSF.Text + ")";
                    SqlCommand cmd = new SqlCommand(qry, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Data is inserted","System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnwestupdate.Enabled = true;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Data is not inserted." + ex.Message, "System Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                btnwesteligibility.Enabled = true;
                btnwestinsert.Enabled = false;
                txtPCRSerum.Enabled = false;
                txtPCRCSF.Enabled = false;
                txtspIgMSerum.Enabled = false;
                txtspeIgMCSF.Enabled = false;
            }
        }

        private void btnwestupdate_Click(object sender, EventArgs e)
        {
            txtPCRSerum.Enabled = true;
            txtPCRCSF.Enabled = true;
            txtspIgMSerum.Enabled = true;
            txtspeIgMCSF.Enabled = true;
            btnwestinsert.Enabled = false;
            btnwestupdate.Enabled = false;
            btnwestconfirm.Enabled = true;
        }

        private void btnwestconfirm_Click(object sender, EventArgs e)
        {
            try
            {
                //WEST Test-update

                SqlConnection con1 = new SqlConnection("Data Source=DESKTOP-ILF4RKJ\\MSSQLSERVER01;Initial Catalog=bloodBank;Integrated Security=True");
                String qry1 = "update WESTNILEVIRUS set PCRSerum = " + txtPCRSerum.Text + ", PCRCSF=" + txtPCRCSF.Text + ",WNVSpecificIgMSerum= " + txtspIgMSerum.Text + ", WNVSpecificIgMCSF= " + txtspeIgMCSF.Text + " where buID= ('" + txtbloodunitid.Text + "')";
                SqlCommand cmd1 = new SqlCommand(qry1, con1);
                con1.Open();
                cmd1.ExecuteNonQuery();
                MessageBox.Show(" Data Updated.", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                con1.Close();




            }
            catch (Exception ex)
            {
                MessageBox.Show(" Data is not updated." + ex.Message, "System Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            btnwestconfirm.Enabled = false;
            txtPCRSerum.Enabled = false;
            txtPCRCSF.Enabled = false;
            txtspIgMSerum.Enabled = false;
            txtspeIgMCSF.Enabled = false;
        }

        private void btnwesteligibility_Click(object sender, EventArgs e)
        {
            //west eligibility test

            int WNV_Specific_IgM_Serum, WNV_Specific_IgM_CSF;

            WNV_Specific_IgM_Serum = int.Parse(txtspIgMSerum.Text);
            WNV_Specific_IgM_CSF = int.Parse(txtspeIgMCSF.Text);



            if (WNV_Specific_IgM_Serum <= 90 && WNV_Specific_IgM_CSF <= 92)
            {
                MessageBox.Show("ELIGIBLE");
                westeligibility = "ELIGIBLE";
            }
            else
            {
                MessageBox.Show(" NOT ELIGIBLE");
                westeligibility = "NOTELIGIBLE";
            }

            lbwest.Text = westeligibility.ToString();
            btnwesteligibility.Enabled = false;

        }

        private void btncytomegaloinsert_Click(object sender, EventArgs e)
        {
            if (cbCMVIgG.SelectedIndex == -1)
            {
                if (cbCMVIgM.SelectedIndex == -1)
                {
                    if (cbCMVIgGAvidity.SelectedIndex == -1)
                    {
                        MessageBox.Show("Please select an option");
                    }
                }
            }
            else
            {
                try
                { //Cytomegal

                    SqlConnection con = new SqlConnection("Data Source=DESKTOP-ILF4RKJ\\MSSQLSERVER01;Initial Catalog=bloodBank;Integrated Security=True");
                    String qry = "INSERT INTO CYTOMEGALOVIRUS VALUES('" + txtbloodunitid.Text + "'  , '" + cbCMVIgG.Text + "' , '" + cbCMVIgM.Text + "','" + cbCMVIgGAvidity.Text + "')";
                    SqlCommand cmd = new SqlCommand(qry, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Data is inserted", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btncytomegaloupdate.Enabled = true;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Data is not inserted." + ex.Message, "System Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                btncytomegaloeligibility.Enabled = true;
                btncytomegaloinsert.Enabled = false;
                cbCMVIgG.Enabled = false;
                cbCMVIgM.Enabled = false;
                cbCMVIgGAvidity.Enabled = false;

            }
        }

        private void btncytomegaloupdate_Click(object sender, EventArgs e)
        {
            cbCMVIgG.Enabled = true;
            cbCMVIgM.Enabled = true;
            cbCMVIgGAvidity.Enabled = true;
            btncytomegaloupdate.Enabled = false;
            btncytomegaloconfirm.Enabled = true;
        }
        private void btncytomegaloconfirm_Click(object sender, EventArgs e)
        {
            try
            {
                //cytomegalo update

                SqlConnection con1 = new SqlConnection("Data Source=DESKTOP-ILF4RKJ\\MSSQLSERVER01;Initial Catalog=bloodBank;Integrated Security=True");
                String qry1 = "update CYTOMEGALOVIRUS set CMVIgG = '" + cbCMVIgG.Text + "', CMVIgM ='" + cbCMVIgM.Text + "', CMVIgG_Avidity= '" + cbCMVIgGAvidity.Text + "' where buID= ('" + txtbloodunitid.Text + "')";
                SqlCommand cmd1 = new SqlCommand(qry1, con1);
                con1.Open();
                cmd1.ExecuteNonQuery();
                MessageBox.Show(" Data Updated.", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                con1.Close();




            }
            catch (Exception ex)
            {
                MessageBox.Show(" Data is not updated." + ex.Message, "System Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            btncytomegaloconfirm.Enabled = false;
            cbCMVIgG.Enabled = false;
            cbCMVIgM.Enabled = false;
            cbCMVIgGAvidity.Enabled = false;
        }



        private void btncytomegaloeligibility_Click(object sender, EventArgs e)
        {
            string var;
            var = cbCMVIgGAvidity.Text;



            if (var == "N/A")
            {
                MessageBox.Show("CMV FACTORS NOT REACTIVE\n ELIGIBLE ");
                cytomegoloeligibility = "ELIGIBLE";

            }
            else if (var == "High Avidity")
            {
                MessageBox.Show("Past Infection , Low Risk For in-utero Transmission\n ELIGIBLE ");
                cytomegoloeligibility = "ELIGIBLE";
            }
            else
            {
                MessageBox.Show("Primary Infection , High Risk For in-utero Transmission\nNOT ELIGIBLE ");
                cytomegoloeligibility = "NOTELIGIBLE";
            }
            lbcyto.Text = cytomegoloeligibility.ToString();
            btncytomegaloeligibility.Enabled = false;
        }



        private void btnchagasinsert_Click(object sender, EventArgs e)
        {
            if (cbMNC.SelectedIndex == -1)
            {
                if (cbTCZ.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select an option", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                try
                { //CHAGAS

                    SqlConnection con = new SqlConnection("Data Source=DESKTOP-ILF4RKJ\\MSSQLSERVER01;Initial Catalog=bloodBank;Integrated Security=True");
                    String qry = "INSERT INTO CHAGAS VALUES('" + txtbloodunitid.Text + "'  , '" + cbMNC.Text + "' , '" + cbTCZ.Text + "')";
                    SqlCommand cmd = new SqlCommand(qry, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Data is inserted", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnchagasupdate.Enabled = true;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Data is not inserted." + ex.Message, "System Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                btnchagaselibility.Enabled = true;
                btnchagasinsert.Enabled = false;
                cbMNC.Enabled = false;
                cbTCZ.Enabled = false;

            }



        }



        private void btnchagasupdate_Click(object sender, EventArgs e)
        {
            cbMNC.Enabled = true;
            cbTCZ.Enabled = true;
            btnchagasconfirm.Enabled = true;
            btnchagasupdate.Enabled = false;
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btnwesteligibility_Click_1(object sender, EventArgs e)
        {
            //west eligibility test

            int WNV_Specific_IgM_Serum, WNV_Specific_IgM_CSF;

            WNV_Specific_IgM_Serum = int.Parse(txtspIgMSerum.Text);
            WNV_Specific_IgM_CSF = int.Parse(txtspeIgMCSF.Text);



            if (WNV_Specific_IgM_Serum <= 90 && WNV_Specific_IgM_CSF <= 92)
            {
                MessageBox.Show("ELIGIBLE");
                westeligibility = "ELIGIBLE";
            }
            else
            {
                MessageBox.Show(" NOT ELIGIBLE");
                westeligibility = "NOTELIGIBLE";
            }

            lbwest.Text = westeligibility.ToString();
            btnwesteligibility.Enabled = false;
        }

        private void btncytomegaloupdate_Click_1(object sender, EventArgs e)
        {
            cbCMVIgG.Enabled = true;
            cbCMVIgM.Enabled = true;
            cbCMVIgGAvidity.Enabled = true;
            btncytomegaloupdate.Enabled = false;
            btncytomegaloconfirm.Enabled = true;
        }

        private void btncytomegaloconfirm_Click_1(object sender, EventArgs e)
        {
            try
            {
                //cytomegalo update

                SqlConnection con1 = new SqlConnection("Data Source=DESKTOP-NAVOD\\SQLEXPRESS;Initial Catalog=bloodBank;Integrated Security=True");
                String qry1 = "update CYTOMEGALOVIRUS set CMVIgG = '" + cbCMVIgG.Text + "', CMVIgM ='" + cbCMVIgM.Text + "', CMVIgG_Avidity= '" + cbCMVIgGAvidity.Text + "' where buID= ('" + txtbloodunitid.Text + "')";
                SqlCommand cmd1 = new SqlCommand(qry1, con1);
                con1.Open();
                cmd1.ExecuteNonQuery();
                MessageBox.Show(" Data Updated.", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                con1.Close();




            }
            catch (Exception ex)
            {
                MessageBox.Show(" Data is not updated." + ex.Message);
            }
            btncytomegaloconfirm.Enabled = false;
            cbCMVIgG.Enabled = false;
            cbCMVIgM.Enabled = false;
            cbCMVIgGAvidity.Enabled = false;
        }

        private void btncytomegaloinsert_Click_1(object sender, EventArgs e)
        {
            if (cbCMVIgG.SelectedIndex == -1)
            {
                if (cbCMVIgM.SelectedIndex == -1)
                {
                    if (cbCMVIgGAvidity.SelectedIndex == -1)
                    {
                        MessageBox.Show("Please select an option", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                try
                { //Cytomegal

                    SqlConnection con = new SqlConnection("Data Source=DESKTOP-ILF4RKJ\\MSSQLSERVER01;Initial Catalog=bloodBank;Integrated Security=True");
                    String qry = "INSERT INTO CYTOMEGALOVIRUS VALUES('" + txtbloodunitid.Text + "'  , '" + cbCMVIgG.Text + "' , '" + cbCMVIgM.Text + "','" + cbCMVIgGAvidity.Text + "')";
                    SqlCommand cmd = new SqlCommand(qry, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Data is inserted", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btncytomegaloupdate.Enabled = true;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Data is not inserted." + ex.Message, "System Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                btncytomegaloeligibility.Enabled = true;
                btncytomegaloinsert.Enabled = false;
                cbCMVIgG.Enabled = false;
                cbCMVIgM.Enabled = false;
                cbCMVIgGAvidity.Enabled = false;

            }
        }

        private void btncytomegaloeligibility_Click_1(object sender, EventArgs e)
        {
            string var;
            var = cbCMVIgGAvidity.Text;



            if (var == "N/A")
            {
                MessageBox.Show("CMV FACTORS NOT REACTIVE\n ELIGIBLE ");
                cytomegoloeligibility = "ELIGIBLE";

            }
            else if (var == "High Avidity")
            {
                MessageBox.Show("Past Infection , Low Risk For in-utero Transmission\n ELIGIBLE ");
                cytomegoloeligibility = "ELIGIBLE";
            }
            else
            {
                MessageBox.Show("Primary Infection , High Risk For in-utero Transmission\nNOT ELIGIBLE ");
                cytomegoloeligibility = "NOTELIGIBLE";
            }
            lbcyto.Text = cytomegoloeligibility.ToString();
            btncytomegaloeligibility.Enabled = false;
        }

        private void btnchagasupdate_Click_1(object sender, EventArgs e)
        {
            cbMNC.Enabled = true;
            cbTCZ.Enabled = true;
            btnchagasconfirm.Enabled = true;
            btnchagasupdate.Enabled = false;
        }

        private void btnchagasconfirm_Click_1(object sender, EventArgs e)
        {
            try
            {
                //cytomegalo update

                SqlConnection con1 = new SqlConnection("Data Source=DESKTOP-ILF4RKJ\\MSSQLSERVER01;Initial Catalog=bloodBank;Integrated Security=True");
                String qry1 = "update CHAGAS set MNCTaqMan = '" + cbMNC.Text + "', TCZTaqMan ='" + cbTCZ.Text + "' where buID= ('" + txtbloodunitid.Text + "')";
                SqlCommand cmd1 = new SqlCommand(qry1, con1);
                con1.Open();
                cmd1.ExecuteNonQuery();
                MessageBox.Show(" Data Updated.", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                con1.Close();




            }
            catch (Exception ex)
            {
                MessageBox.Show(" Data is not updated." + ex.Message);
            }
            btnchagasconfirm.Enabled = false;
            cbMNC.Enabled = false;
            cbTCZ.Enabled = false;
        }

        private void btnchagasinsert_Click_1(object sender, EventArgs e)
        {
            if (cbMNC.SelectedIndex == -1)
            {
                if (cbTCZ.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select an option", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                try
                { //CHAGAS

                    SqlConnection con = new SqlConnection("Data Source=DESKTOP-ILF4RKJ\\MSSQLSERVER01;Initial Catalog=bloodBank;Integrated Security=True");
                    String qry = "INSERT INTO CHAGAS VALUES('" + txtbloodunitid.Text + "'  , '" + cbMNC.Text + "' , '" + cbTCZ.Text + "')";
                    SqlCommand cmd = new SqlCommand(qry, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Data is inserted", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnchagasupdate.Enabled = true;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Data is not inserted." + ex.Message);
                }
                btnchagaselibility.Enabled = true;
                btnchagasinsert.Enabled = false;
                cbMNC.Enabled = false;
                cbTCZ.Enabled = false;

            }
        }

        private void btnchagaselibility_Click_1(object sender, EventArgs e)
        {
            string var1, var2;

            var1 = cbMNC.Text;
            var2 = cbTCZ.Text;

            if (var1 == "POSITIVE(22)" && var2 == "POSITIVE(17)")
            {
                MessageBox.Show("NOT ELIGIBLE");
                chagaseligibility = "NOTELIGIBLE";
            }
            else if (var1 == "POSITIVE(21)" && var2 == "POSITIVE(17)")
            {
                MessageBox.Show("NOT ELIGIBLE ");
                chagaseligibility = "NOTELIGIBLE";
            }
            else
            {
                MessageBox.Show("ELIGIBLE ");
                chagaseligibility = "ELIGIBLE";
            }


            lbchagas.Text = chagaseligibility.ToString();
            btnchagaselibility.Enabled = false;
        }

        private void btnchagasconfirm_Click(object sender, EventArgs e)
        {
            try
            {
                //cytomegalo update

                SqlConnection con1 = new SqlConnection("Data Source=DESKTOP-ILF4RKJ\\MSSQLSERVER01;Initial Catalog=bloodBank;Integrated Security=True");
                String qry1 = "update CHAGAS set MNCTaqMan = '" + cbMNC.Text + "', TCZTaqMan ='" + cbTCZ.Text + "' where buID= ('" + txtbloodunitid.Text + "')";
                SqlCommand cmd1 = new SqlCommand(qry1, con1);
                con1.Open();
                cmd1.ExecuteNonQuery();
                MessageBox.Show(" Data Updated.", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                con1.Close();




            }
            catch (Exception ex)
            {
                MessageBox.Show(" Data is not updated." + ex.Message);
            }
            btnchagasconfirm.Enabled = false;
            cbMNC.Enabled = false;
            cbTCZ.Enabled = false;

        }

        private void btnchagaselibility_Click(object sender, EventArgs e)
        {
            string var1, var2;

            var1 = cbMNC.Text;
            var2 = cbTCZ.Text;

            if (var1 == "POSITIVE(22)" && var2 == "POSITIVE(17)")
            {
                MessageBox.Show("NOT ELIGIBLE");
                chagaseligibility = "NOTELIGIBLE";
            }
            else if (var1 == "POSITIVE(21)" && var2 == "POSITIVE(17)")
            {
                MessageBox.Show("NOT ELIGIBLE ");
                chagaseligibility = "NOTELIGIBLE";
            }
            else
            {
                MessageBox.Show("ELIGIBLE ");
                chagaseligibility = "ELIGIBLE";
            }


            lbchagas.Text = chagaseligibility.ToString();
            btnchagaselibility.Enabled = false;


        }
        private void label25_Click(object sender, EventArgs e)
        {
            if (chagaseligibility == "ELIGIBLE" && cytomegoloeligibility == "ELIGIBLE" && westeligibility == "ELIGIBLE")
            {
                ELIGIBILITY = "ELIGIBLE";
                label25.Text = ELIGIBILITY.ToString();

            }
            else
            {
                ELIGIBILITY = "NOTELIGIBLE";
                label25.Text = ELIGIBILITY.ToString();

            }
            Clipboard.SetText(ELIGIBILITY);


        }

    }
}
