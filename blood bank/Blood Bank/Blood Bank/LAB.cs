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
using System.Data.SqlClient;

namespace Blood_Bank
{
    public partial class LAB : Form
    {
        bool flag = false;

        string DDate, hiveligibility, hepatitiseligibility, syphiliseligibility, buID, paneligibility, labeli, hivN, hepN, sypN, panN;

        string bloodBagID;

        public LAB()
        {
            InitializeComponent();


            groupBox1.Enabled = false;
            groupBox2.Enabled = false;
            groupBox3.Enabled = false;
            groupBox4.Enabled = false;
            groupBox6.Enabled = false;
            txtDNIC.Enabled = false;
            txtDDate.Enabled = false;
            txtbtype.Enabled = false;
            btnupdateBtype.Enabled = false;
            label29.Enabled = false;
            label30.Enabled = false;
            label31.Enabled = false;
            txtDNIC.Enabled = false;
            txtDDate.Enabled = false;
            txtbtype.Enabled = false;
            btnbtconfirm.Enabled = false;
            btnlipidconfirm.Enabled = false;
            btnlipidupdate.Enabled = false;
            btnhivupdate.Enabled = false;
            btnhivconfirm.Enabled = false;
            btnhiveligibility.Enabled = false;
            btnhepatitisupdate.Enabled = false;
            btnhepatitisconfirm.Enabled = false;
            btnhepatitiseligibility.Enabled = false;
            btnsyphilisconfirm.Enabled = false;
            btnsyphilisisupdate.Enabled = false;
            btnsyphiliseligibility.Enabled = false;
            txtpan.Enabled = false;
            button20.Enabled = false;

        }

        SqlConnection Con = new SqlConnection("Data Source=DESKTOP-ILF4RKJ\\MSSQLSERVER01;Initial Catalog=bloodBank;Integrated Security=True");
        //getting blood unit id from the user

        private void viewAndEditAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread td = new Thread(openLoginForLAB);
            td.SetApartmentState(ApartmentState.STA);
            td.Start();
            this.Close();
        }

        private void openLoginForLAB()
        {
            Application.Run(new LabAssistantLoginForm());
        }

        private void viewAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void backToTheMainMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread td = new Thread(openMainMenu);
            td.SetApartmentState(ApartmentState.STA);
            td.Start();
            this.Close();
        }

        private void openMainMenu()
        {
            Application.Run(new Form1());
        }

        private void btncheck_Click(object sender, EventArgs e)
        {
            if (txtbloodunitid.Text == "")
            {
                MessageBox.Show("Please Enter the Blood unit ID", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Con.Open();
                SqlCommand cmd = new SqlCommand("Select * from bloodunit where bloodunitId='" + txtbloodunitid.Text + "' AND LabEligibility ='NOTCHECKED'", Con);
                SqlDataReader rdr;
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    if (rdr[1].ToString() == txtbloodunitid.Text)
                    {
                        flag = true;
                        break;


                    }
                }
                Con.Close();


               

                if (flag == true)
                {
                    label29.Enabled = true;
                    label30.Enabled = true;
                    label31.Enabled = true;
                    txtDNIC.Enabled = true;
                    txtDDate.Enabled = true;
                    txtbtype.Enabled = true;
                    btnupdateBtype.Enabled = true;
                    groupBox4.Enabled = true;
                    //get donor related data and blood type
                    Con.Open();
                    string query = "Select * from bloodunit where bloodunitId='" + txtbloodunitid.Text + "' ";
                    SqlCommand cmd1 = new SqlCommand(query, Con);
                    DataTable dt = new DataTable();
                    SqlDataAdapter sda = new SqlDataAdapter(cmd1);
                    sda.Fill(dt);
                    foreach (DataRow dr in dt.Rows)
                    {
                        txtDNIC.Text = dr["DonarNIC"].ToString();
                        DDate = dr["DonatedDate"].ToString();
                        txtbtype.Text = dr["bloodtype"].ToString();


                    }
                    Con.Close();
                    DateTime dDate = DateTime.Parse(DDate);
                    txtDDate.Text = dDate.ToString("yyyy-MM-dd");

                }


                else
                {
                    MessageBox.Show("The entered data are incorrect or \nThis blood unit has been already checked for eligibility.", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                getpan();


            }
        }


        private void getpan()
        {
            Con.Open();
            string query = "Select * from DonarExpression where DonarNIC = '" + txtDNIC.Text + "' AND DonatedDate = '" + txtDDate.Text + "'";
            SqlCommand cmd1 = new SqlCommand(query, Con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd1);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                txtpan.Text = dr["COVID19"].ToString();


            }
            Con.Close();

            if (txtpan.Text == "YES")
            {
                button20.Enabled = true;
            }
        }



        private void btnupdateBtype_Click(object sender, EventArgs e)
        {
            txtbtype.Enabled = true;
            btnbtconfirm.Enabled = true;
            btnupdateBtype.Enabled = false;
        }

        private void btnbtconfirm_Click(object sender, EventArgs e)
        {
            try
            {
                //2nd blood type checking test - lab test
                SqlConnection con1 = new SqlConnection("Data Source=DESKTOP-ILF4RKJ\\MSSQLSERVER01;Initial Catalog=bloodBank;Integrated Security=True");
                String qry1 = "update bloodunit set bloodtype = '" + txtbtype.Text + "' where bloodunitId= ('" + txtbloodunitid.Text + "') ";
                SqlCommand cmd1 = new SqlCommand(qry1, con1);
                con1.Open();
                cmd1.ExecuteNonQuery();
                MessageBox.Show(" Data Updated.");
                con1.Close();
                txtbtype.Enabled = false;
                btnbtconfirm.Enabled = false;



            }
            catch (Exception ex)
            {
                MessageBox.Show(" Data is not updated." + ex.Message);
            }
        }

        private void btnlipidinsert_Click(object sender, EventArgs e)
        {
            //LIPID PROFILE Test
            if (txtcholesterol.Text == "")
            {
                if (txtTriglycerides.Text == "")
                {
                    if (txtCHDL.Text == "")
                    {
                        if (txtCNonHDL.Text == "")
                        {
                            if (txtCLDL.Text == "")
                            {
                                if (txtCVLDL.Text == "")
                                {
                                    if (txtLDLHDL.Text == "")
                                    {
                                        if (txtCHOLHDL.Text == "")
                                        {
                                            MessageBox.Show("Missing Ingormation", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                try
                { //LIPID PROFILE Test-insert
                  // This test Does not check eligibility
                    SqlConnection con = new SqlConnection("Data Source=DESKTOP-ILF4RKJ\\MSSQLSERVER01;Initial Catalog=bloodBank;Integrated Security=True");
                    String qry = "INSERT INTO LIPID_PROFILE VALUES('" + txtbloodunitid.Text + "' , '" + txtDDate.Text + "' , " + txtcholesterol.Text + " , " + txtTriglycerides.Text + "," + txtCHDL.Text + "," + txtCNonHDL.Text + "," + txtCLDL.Text + "," + txtCVLDL.Text + "," + txtCHOLHDL.Text + ",'" + txtLDLHDL.Text + "')";
                    SqlCommand cmd = new SqlCommand(qry, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Data is inserted", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnlipidupdate.Enabled = true;



                }
                catch (Exception ex)
                {
                    MessageBox.Show("Data is not inserted." + ex.Message);
                }

                btnlipidinsert.Enabled = false;
                txtcholesterol.Enabled = false;
                txtTriglycerides.Enabled = false;
                txtCHDL.Enabled = false;
                txtCNonHDL.Enabled = false;
                txtCLDL.Enabled = false;
                txtCVLDL.Enabled = false;
                txtCHOLHDL.Enabled = false;
                txtLDLHDL.Enabled = false;
                groupBox1.Enabled = true;

            }

        }

        private void btnlipidupdate_Click(object sender, EventArgs e)
        {
            btnlipidconfirm.Enabled = true;
            txtcholesterol.Enabled = true;
            txtTriglycerides.Enabled = true;
            txtCHDL.Enabled = true;
            txtCNonHDL.Enabled = true;
            txtCLDL.Enabled = true;
            txtCVLDL.Enabled = true;
            txtCHOLHDL.Enabled = true;
            txtLDLHDL.Enabled = true;
            btnlipidupdate.Enabled = false;

        }

        private void btnlipidconfirm_Click(object sender, EventArgs e)
        {
            try
            {
                //LIPID PROFILE Test-update

                SqlConnection con1 = new SqlConnection("Data Source=DESKTOP-ILF4RKJ\\MSSQLSERVER01;Initial Catalog=bloodBank;Integrated Security=True");
                String qry1 = "update LIPID_PROFILE set SerumCholesterolTotal = " + txtcholesterol.Text + ", SerumTriglycerides=" + txtTriglycerides.Text + ", CholesterolDL= " + txtCHDL.Text + ",CholesterolNonHDL= " + txtCNonHDL.Text + ", CholesterolLDL= " + txtCLDL.Text + ", CholesterolVLDL= " + txtCVLDL.Text + ", CHOLHDL= " + txtCHOLHDL.Text + ",LDLHDL =" + txtLDLHDL.Text + " where buID= ('" + txtbloodunitid.Text + "')";
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
            btnlipidconfirm.Enabled = false;
            txtcholesterol.Enabled = false;
            txtTriglycerides.Enabled = false;
            txtCHDL.Enabled = false;
            txtCNonHDL.Enabled = false;
            txtCLDL.Enabled = false;
            txtCVLDL.Enabled = false;
            txtCHOLHDL.Enabled = false;
            txtLDLHDL.Enabled = false;

        }

        private void btnhivinsert_Click(object sender, EventArgs e)
        {
            //HIV Test
            // Does check eligibility
            if (txtGRF.Text == "")
            {
                if (txthiv1.Text == "")
                {
                    if (txthiv2.Text == "")
                    {
                        if (txthivrna.Text == "")
                        {
                            MessageBox.Show("Missing Ingormation", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            else
            {
                try
                { //HIV Test-Insert
                    SqlConnection con = new SqlConnection("Data Source=DESKTOP-ILF4RKJ\\MSSQLSERVER01;Initial Catalog=bloodBank;Integrated Security=True");
                    String qry = "INSERT INTO HIV VALUES('" + txtbloodunitid.Text + "' , '" + txtDDate.Text + "' , " + txtGRF.Text + " , " + txthiv1.Text + "," + txthiv2.Text + "," + txthivrna.Text + ")";
                    SqlCommand cmd = new SqlCommand(qry, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Data is inserted", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnhivupdate.Enabled = true;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Data is not inserted." + ex.Message);
                }
                btnhiveligibility.Enabled = true;
                btnhivinsert.Enabled = false;
                txtGRF.Enabled = false;
                txthiv1.Enabled = false;
                txthiv2.Enabled = false;
                txthivrna.Enabled = false;

            }
        }

        private void btnhivupdate_Click(object sender, EventArgs e)
        {

            txtGRF.Enabled = true;
            txthiv1.Enabled = true;
            txthiv2.Enabled = true;
            txthivrna.Enabled = true;
            btnhivconfirm.Enabled = true;
            btnhivupdate.Enabled = false;
            btnhiveligibility.Enabled = true;

        }

        private void btnhivconfirm_Click(object sender, EventArgs e)
        {
            try
            {
                //HIV Test-update

                SqlConnection con1 = new SqlConnection("Data Source=DESKTOP-ILF4RKJ\\MSSQLSERVER01;Initial Catalog=bloodBank;Integrated Security=True");
                String qry1 = "update HIV set GFREstimated = " + txtGRF.Text + ", HIV1=" + txthiv1.Text + ", HIV2= " + txthiv2.Text + ", HIVRNA= " + txthivrna.Text + " where buID= ('" + txtbloodunitid.Text + "')";
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
            btnhivconfirm.Enabled = false;
            txtGRF.Enabled = false;
            txthiv1.Enabled = false;
            txthiv2.Enabled = false;
            txthivrna.Enabled = false;


        }



        private void btnhiveligibility_Click(object sender, EventArgs e)
        {
            //HIV ELIGIBILITY CHECK
            int HIV1, HIV2, GFREstimated, HIVRNA;

            HIV1 = int.Parse(txthiv1.Text);
            HIV2 = int.Parse(txthiv2.Text);
            GFREstimated = int.Parse(txtGRF.Text);
            HIVRNA = int.Parse(txthivrna.Text);

            if ((HIV1 == 0 && HIV2 == 0 && GFREstimated < 60 && HIVRNA == 0))
            {
                MessageBox.Show("ELIGIBLE");
                hiveligibility = "ELIGIBLE";
                hivN = "YES";
            }
            else
            {
                MessageBox.Show(" NOT ELIGIBLE");
                hiveligibility = "NOTELIGIBLE";
                hivN = "NO";

            }

            btnhiveligibility.Enabled = false;
            lbhiv.Text = hiveligibility.ToString();
            groupBox2.Enabled = true;
        }



        private void btnhepatitisinsert_Click(object sender, EventArgs e)
        {
            //HepatitisB test
            //Does check for eligibility
            if (cbHepatitis.SelectedIndex == -1)
            {
                MessageBox.Show("Please Select an option", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                try
                { //HepatitisB Test-Insert
                    SqlConnection con = new SqlConnection("Data Source=DESKTOP-ILF4RKJ\\MSSQLSERVER01;Initial Catalog=bloodBank;Integrated Security=True");
                    String qry = "INSERT INTO HEPATITISB VALUES('" + txtbloodunitid.Text + "' , '" + txtDDate.Text + "' , '" + cbHepatitis.Text + "')";
                    SqlCommand cmd = new SqlCommand(qry, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Data is inserted");
                    btnhepatitisupdate.Enabled = true;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Data is not inserted." + ex.Message);
                }
                btnhepatitiseligibility.Enabled = true;
                btnhepatitisinsert.Enabled = false;
                cbHepatitis.Enabled = false;
            }

        }



        private void btnhepatitisupdate_Click(object sender, EventArgs e)
        {
            cbHepatitis.Enabled = true;
            btnhepatitisconfirm.Enabled = true;
            btnhepatitisupdate.Enabled = false;
            btnhepatitiseligibility.Enabled = true;
        }



        private void btnhepatitisconfirm_Click(object sender, EventArgs e)
        {
            try
            {
                //HEPATITISB Test-update

                SqlConnection con1 = new SqlConnection("Data Source=DESKTOP-ILF4RKJ\\MSSQLSERVER01;Initial Catalog=bloodBank;Integrated Security=True");
                String qry1 = "update HEPATITISB set HBSurfaceAntigen = '" + cbHepatitis.Text + "' where buID= ('" + txtbloodunitid.Text + "')";
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
            btnhepatitisconfirm.Enabled = false;
            cbHepatitis.Enabled = false;
        }

        private void Lab_Eligibility_Load(object sender, EventArgs e)
        {

        }

        private void LAB_Load(object sender, EventArgs e)
        {
            button2.Enabled = false;
        }

        private void btnlipidinsert_Click_1(object sender, EventArgs e)
        {
            //LIPID PROFILE Test
            if (txtcholesterol.Text == "")
            {
                if (txtTriglycerides.Text == "")
                {
                    if (txtCHDL.Text == "")
                    {
                        if (txtCNonHDL.Text == "")
                        {
                            if (txtCLDL.Text == "")
                            {
                                if (txtCVLDL.Text == "")
                                {
                                    if (txtLDLHDL.Text == "")
                                    {
                                        if (txtCHOLHDL.Text == "")
                                        {
                                            MessageBox.Show("Missing Ingormation");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                try
                { //LIPID PROFILE Test-insert
                  // This test Does not check eligibility
                    SqlConnection con = new SqlConnection("Data Source=DESKTOP-ILF4RKJ\\MSSQLSERVER01;Initial Catalog=bloodBank;Integrated Security=True");
                    String qry = "INSERT INTO LIPID_PROFILE VALUES('" + txtbloodunitid.Text + "' , '" + txtDDate.Text + "' , " + txtcholesterol.Text + " , " + txtTriglycerides.Text + "," + txtCHDL.Text + "," + txtCNonHDL.Text + "," + txtCLDL.Text + "," + txtCVLDL.Text + "," + txtCHOLHDL.Text + ",'" + txtLDLHDL.Text + "')";
                    SqlCommand cmd = new SqlCommand(qry, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Data is inserted", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnlipidupdate.Enabled = true;



                }
                catch (Exception ex)
                {
                    MessageBox.Show("Data is not inserted." + ex.Message);
                }

                btnlipidinsert.Enabled = false;
                txtcholesterol.Enabled = false;
                txtTriglycerides.Enabled = false;
                txtCHDL.Enabled = false;
                txtCNonHDL.Enabled = false;
                txtCLDL.Enabled = false;
                txtCVLDL.Enabled = false;
                txtCHOLHDL.Enabled = false;
                txtLDLHDL.Enabled = false;
                groupBox1.Enabled = true;

            }
        }

        private void btnhivinsert_Click_1(object sender, EventArgs e)
        {
            //HIV Test
            // Does check eligibility
            if (txtGRF.Text == "")
            {
                if (txthiv1.Text == "")
                {
                    if (txthiv2.Text == "")
                    {
                        if (txthivrna.Text == "")
                        {
                            MessageBox.Show("Missing Ingormation", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            else
            {
                try
                { //HIV Test-Insert
                    SqlConnection con = new SqlConnection("Data Source=DESKTOP-ILF4RKJ\\MSSQLSERVER01;Initial Catalog=bloodBank;Integrated Security=True");
                    String qry = "INSERT INTO HIV VALUES('" + txtbloodunitid.Text + "' , '" + txtDDate.Text + "' , " + txtGRF.Text + " , " + txthiv1.Text + "," + txthiv2.Text + "," + txthivrna.Text + ")";
                    SqlCommand cmd = new SqlCommand(qry, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Data is inserted");
                    btnhivupdate.Enabled = true;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Data is not inserted." + ex.Message);
                }
                btnhiveligibility.Enabled = true;
                btnhivinsert.Enabled = false;
                txtGRF.Enabled = false;
                txthiv1.Enabled = false;
                txthiv2.Enabled = false;
                txthivrna.Enabled = false;

            }
        }

        private void btnhepatitisinsert_Click_1(object sender, EventArgs e)
        {
            //HepatitisB test
            //Does check for eligibility
            if (cbHepatitis.SelectedIndex == -1)
            {
                MessageBox.Show("Please Select an option", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                try
                { //HepatitisB Test-Insert
                    SqlConnection con = new SqlConnection("Data Source=DESKTOP-ILF4RKJ\\MSSQLSERVER01;Initial Catalog=bloodBank;Integrated Security=Truee");
                    String qry = "INSERT INTO HEPATITISB VALUES('" + txtbloodunitid.Text + "' , '" + txtDDate.Text + "' , '" + cbHepatitis.Text + "')";
                    SqlCommand cmd = new SqlCommand(qry, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Data is inserted");
                    btnhepatitisupdate.Enabled = true;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Data is not inserted." + ex.Message);
                }
                btnhepatitiseligibility.Enabled = true;
                btnhepatitisinsert.Enabled = false;
                cbHepatitis.Enabled = false;
            }
        }

        private void btnlipidconfirm_Click_1(object sender, EventArgs e)
        {
            try
            {
                //LIPID PROFILE Test-update

                SqlConnection con1 = new SqlConnection("Data Source=DESKTOP-ILF4RKJ\\MSSQLSERVER01;Initial Catalog=bloodBank;Integrated Security=True");
                String qry1 = "update LIPID_PROFILE set SerumCholesterolTotal = " + txtcholesterol.Text + ", SerumTriglycerides=" + txtTriglycerides.Text + ", CholesterolDL= " + txtCHDL.Text + ",CholesterolNonHDL= " + txtCNonHDL.Text + ", CholesterolLDL= " + txtCLDL.Text + ", CholesterolVLDL= " + txtCVLDL.Text + ", CHOLHDL= " + txtCHOLHDL.Text + ",LDLHDL =" + txtLDLHDL.Text + " where buID= ('" + txtbloodunitid.Text + "')";
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
            btnlipidconfirm.Enabled = false;
            txtcholesterol.Enabled = false;
            txtTriglycerides.Enabled = false;
            txtCHDL.Enabled = false;
            txtCNonHDL.Enabled = false;
            txtCLDL.Enabled = false;
            txtCVLDL.Enabled = false;
            txtCHOLHDL.Enabled = false;
            txtLDLHDL.Enabled = false;
        }

        private void btnlipidupdate_Click_1(object sender, EventArgs e)
        {
            btnlipidconfirm.Enabled = true;
            txtcholesterol.Enabled = true;
            txtTriglycerides.Enabled = true;
            txtCHDL.Enabled = true;
            txtCNonHDL.Enabled = true;
            txtCLDL.Enabled = true;
            txtCVLDL.Enabled = true;
            txtCHOLHDL.Enabled = true;
            txtLDLHDL.Enabled = true;
            btnlipidupdate.Enabled = false;
        }

        private void btnhivupdate_Click_1(object sender, EventArgs e)
        {
            txtGRF.Enabled = true;
            txthiv1.Enabled = true;
            txthiv2.Enabled = true;
            txthivrna.Enabled = true;
            btnhivconfirm.Enabled = true;
            btnhivupdate.Enabled = false;
            btnhiveligibility.Enabled = true;
        }

        private void btnhivconfirm_Click_1(object sender, EventArgs e)
        {
            try
            {
                //HIV Test-update

                SqlConnection con1 = new SqlConnection("Data Source=DESKTOP-ILF4RKJ\\MSSQLSERVER01;Initial Catalog=bloodBank;Integrated Security=True");
                String qry1 = "update HIV set GFREstimated = " + txtGRF.Text + ", HIV1=" + txthiv1.Text + ", HIV2= " + txthiv2.Text + ", HIVRNA= " + txthivrna.Text + " where buID= ('" + txtbloodunitid.Text + "')";
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
            btnhivconfirm.Enabled = false;
            txtGRF.Enabled = false;
            txthiv1.Enabled = false;
            txthiv2.Enabled = false;
            txthivrna.Enabled = false;
        }

        private void btnhiveligibility_Click_1(object sender, EventArgs e)
        {
            //HIV ELIGIBILITY CHECK
            int HIV1, HIV2, GFREstimated, HIVRNA;

            HIV1 = int.Parse(txthiv1.Text);
            HIV2 = int.Parse(txthiv2.Text);
            GFREstimated = int.Parse(txtGRF.Text);
            HIVRNA = int.Parse(txthivrna.Text);

            if ((HIV1 == 0 && HIV2 == 0 && GFREstimated < 60 && HIVRNA == 0))
            {
                MessageBox.Show("ELIGIBLE");
                hiveligibility = "ELIGIBLE";
                hivN = "YES";
            }
            else
            {
                MessageBox.Show(" NOT ELIGIBLE");
                hiveligibility = "NOTELIGIBLE";
                hivN = "NO";

            }

            btnhiveligibility.Enabled = false;
            lbhiv.Text = hiveligibility.ToString();
            groupBox2.Enabled = true;
        }

        private void btnupdateBtype_Click_1(object sender, EventArgs e)
        {
            txtbtype.Enabled = true;
            btnbtconfirm.Enabled = true;
            btnupdateBtype.Enabled = false;
        }

        private void btnbtconfirm_Click_1(object sender, EventArgs e)
        {
            try
            {
                //2nd blood type checking test - lab test
                SqlConnection con1 = new SqlConnection("Data Source=DESKTOP-ILF4RKJ\\MSSQLSERVER01;Initial Catalog=bloodBank;Integrated Security=True");
                String qry1 = "update bloodunit set bloodtype = '" + txtbtype.Text + "' where bloodunitId= ('" + txtbloodunitid.Text + "') ";
                SqlCommand cmd1 = new SqlCommand(qry1, con1);
                con1.Open();
                cmd1.ExecuteNonQuery();
                MessageBox.Show(" Data Updated.", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                con1.Close();
                txtbtype.Enabled = false;
                btnbtconfirm.Enabled = false;



            }
            catch (Exception ex)
            {
                MessageBox.Show(" Data is not updated." + ex.Message);
            }
        }

        private void btnhepatitisupdate_Click_1(object sender, EventArgs e)
        {
            cbHepatitis.Enabled = true;
            btnhepatitisconfirm.Enabled = true;
            btnhepatitisupdate.Enabled = false;
            btnhepatitiseligibility.Enabled = true;
        }

        private void btnhepatitisconfirm_Click_1(object sender, EventArgs e)
        {
            try
            {
                //HEPATITISB Test-update

                SqlConnection con1 = new SqlConnection("Data Source=DESKTOP-ILF4RKJ\\MSSQLSERVER01;Initial Catalog=bloodBank;Integrated Security=True");
                String qry1 = "update HEPATITISB set HBSurfaceAntigen = '" + cbHepatitis.Text + "' where buID= ('" + txtbloodunitid.Text + "')";
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
            btnhepatitisconfirm.Enabled = false;
            cbHepatitis.Enabled = false;
        }

        private void btnhepatitiseligibility_Click_1(object sender, EventArgs e)
        {
            string result;
            result = cbHepatitis.Text;

            if (result == "Reactive")
            {
                MessageBox.Show("NOT ELIGIBLE");
                hepatitiseligibility = "NOTELIGIBLE";
                hepN = "NO";
            }
            else
            {
                MessageBox.Show("ELIGIBLE");
                hepatitiseligibility = "ELIGIBLE";
                hepN = "YES";

            }
            btnhepatitiseligibility.Enabled = false;
            lbhepatitis.Text = hepatitiseligibility.ToString();
            groupBox3.Enabled = true;
        }

        private void btnsyphilisisupdate_Click_1(object sender, EventArgs e)
        {
            cbnonsperdr.Enabled = true;
            cbsperdr.Enabled = true;
            btnsyphilisconfirm.Enabled = true;
            btnsyphilisisupdate.Enabled = false;
            btnsyphiliseligibility.Enabled = true;
        }

        private void btnsyphilisconfirm_Click_1(object sender, EventArgs e)
        {
            try
            {
                //SYPHILIS Test-update

                SqlConnection con1 = new SqlConnection("Data Source=DESKTOP-ILF4RKJ\\MSSQLSERVER01;Initial Catalog=bloodBank;Integrated Security=True");
                String qry1 = "update SYPHILIS set NONSPECIFICRDR = '" + cbnonsperdr.Text + "',SPECIFICRDR = '" + cbsperdr.Text + "' where buID= ('" + txtbloodunitid.Text + "')";
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
            btnsyphilisconfirm.Enabled = false;
            cbnonsperdr.Enabled = false;
            cbsperdr.Enabled = false;
        }

        private void btnsyphilisinsert_Click_1(object sender, EventArgs e)
        {
            //SYPHILIS test
            //Does check for eligibility
            if (cbnonsperdr.SelectedIndex == -1)
            {
                if (cbsperdr.SelectedIndex == -1)
                {
                    MessageBox.Show("Please Select an option");
                }
            }
            else
            {
                try
                { //SYPHILIS Test-Insert
                    SqlConnection con = new SqlConnection("Data Source=DESKTOP-ILF4RKJ\\MSSQLSERVER01;Initial Catalog=bloodBank;Integrated Security=True");
                    String qry = "INSERT INTO SYPHILIS VALUES('" + txtbloodunitid.Text + "' , '" + txtDDate.Text + "' , '" + cbnonsperdr.Text + "', '" + cbsperdr.Text + "')";
                    SqlCommand cmd = new SqlCommand(qry, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Data is inserted", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnsyphilisisupdate.Enabled = true;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Data is not inserted." + ex.Message);
                }
                btnsyphiliseligibility.Enabled = true;
                btnsyphilisinsert.Enabled = false;
                cbnonsperdr.Enabled = false;
                cbsperdr.Enabled = false;
            }
        }

        private void btnsyphiliseligibility_Click_1(object sender, EventArgs e)
        {
            string var1, var2;
            var1 = cbnonsperdr.Text;

            var2 = cbsperdr.Text;



            if (var1 == "NonReactive" && var2 == "NonReactive")
            {
                MessageBox.Show("No Syphilis\nIncubating Syphilis\nELIGIBLE");
                syphiliseligibility = "ELIGIBLE";
                sypN = "YES";

            }
            else if (var1 == "Reactive" && var2 == "Reactive")
            {
                MessageBox.Show("Syphilis(Old and New)\nOther treponemal infection\nNOT ELIGIBLE ");
                syphiliseligibility = "NOTELIGIBLE";
                sypN = "NO";

            }
            else if (var1 == "NonReactive" && var2 == "Reactive")
            {
                MessageBox.Show("Treated Syphilis\nEarly Primary Syphilis\nProzone Reactive\nNOT ELIGIBLE ");
                syphiliseligibility = "NOTELIGIBLE";
                sypN = "NO";
            }
            else
            {
                MessageBox.Show("False Reactive RPR\nFalse Negative Specific Test\nELIGIBLE");
                syphiliseligibility = "ELIGIBLE";
                sypN = "YES";
            }
            btnsyphiliseligibility.Enabled = false;
            lbsyphilis.Text = syphiliseligibility.ToString();
            groupBox6.Enabled = true;
        }

        private void button20_Click_1(object sender, EventArgs e)
        {
            buID = txtbloodunitid.Text;
            Clipboard.SetText(buID);
            Donor_Lived_in_Pandameic_Area_Tests DL = new Donor_Lived_in_Pandameic_Area_Tests();
            DL.Show();
        }

        private void finalEligibility_Click_1(object sender, EventArgs e)
        {
            paneligibility = Clipboard.GetText();
            if (txtpan.Text == "NO")
            {
                if (hiveligibility == "ELIGIBLE" && hepatitiseligibility == "ELIGIBLE" && syphiliseligibility == "ELIGIBLE")
                {
                    label25.Text = "ELIGIBLE, APPROVED FOR TRANSFERRING";
                    labeli = "YES";
                    upbut();
                    updon();
                }
                else
                {
                    label25.Text = "NOT ELIGIBLE, NOT APPROVED FOR TRANSFERRING ";
                    labeli = "NO";
                    upbut();
                    updon();
                }
                panN = "NOTNEEDED";
                insert();
            }
            else
            {
                if (hiveligibility == "ELIGIBLE" && hepatitiseligibility == "ELIGIBLE" && syphiliseligibility == "ELIGIBLE" && paneligibility == "ELIGIBLE")
                {
                    label25.Text = "ELIGIBLE, APPROVED FOR TRANSFERRING";
                    labeli = "YES";
                    panN = "YES";
                    upbut();
                    updon();

                }
                else
                {
                    label25.Text = "NOT ELIGIBLE, NOT APPROVED FOR TRANSFERRING ";
                    labeli = "NO";
                    panN = "NO";
                    upbut();
                    updon();
                }
                insert();
            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            Thread td = new Thread(openLabFormRefreshed);
            td.SetApartmentState(ApartmentState.STA);
            td.Start();
            this.Close();
        }

        private void openLabFormRefreshed()
        {
            Application.Run(new LAB());
        }

        private void getBloodBagsDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            try
            {
                string getIDQuery = "select bloodunitId from bloodunit where LabEligibility ='NOTCHECKED'";
                SqlCommand cmdForGetID = new SqlCommand(getIDQuery, Con);

                Con.Open();

                bloodBagID = Convert.ToString(cmdForGetID.ExecuteScalar());

                Con.Close();

                Clipboard.SetText(bloodBagID);
                button2.Enabled = true;
            }
            catch(Exception copyPBloodBagID)
            {
                MessageBox.Show("There Are No More Blood Bags- All Are Checked","System Information",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtbloodunitid.Text = Clipboard.GetText();
            button2.Enabled = false;
        }

        private void userManualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread td = new Thread(openLABManualForm);
            td.SetApartmentState(ApartmentState.STA);
            td.Start();
        }

        private void openLABManualForm()
        {
            Application.Run(new LAB_Manual());
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

        private void btnhepatitiseligibility_Click(object sender, EventArgs e)
        {
            string result;
            result = cbHepatitis.Text;

            if (result == "Reactive")
            {
                MessageBox.Show("NOT ELIGIBLE");
                hepatitiseligibility = "NOTELIGIBLE";
                hepN = "NO";
            }
            else
            {
                MessageBox.Show("ELIGIBLE");
                hepatitiseligibility = "ELIGIBLE";
                hepN = "YES";

            }
            btnhepatitiseligibility.Enabled = false;
            lbhepatitis.Text = hepatitiseligibility.ToString();
            groupBox3.Enabled = true;

        }


        private void btnsyphilisinsert_Click(object sender, EventArgs e)
        {
            //SYPHILIS test
            //Does check for eligibility
            if (cbnonsperdr.SelectedIndex == -1)
            {
                if (cbsperdr.SelectedIndex == -1)
                {
                    MessageBox.Show("Please Select an option", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                try
                { //SYPHILIS Test-Insert
                    SqlConnection con = new SqlConnection("Data Source=DESKTOP-ILF4RKJ\\MSSQLSERVER01;Initial Catalog=bloodBank;Integrated Security=True");
                    String qry = "INSERT INTO SYPHILIS VALUES('" + txtbloodunitid.Text + "' , '" + txtDDate.Text + "' , '" + cbnonsperdr.Text + "', '" + cbsperdr.Text + "')";
                    SqlCommand cmd = new SqlCommand(qry, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Data is inserted", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnsyphilisisupdate.Enabled = true;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Data is not inserted." + ex.Message);
                }
                btnsyphiliseligibility.Enabled = true;
                btnsyphilisinsert.Enabled = false;
                cbnonsperdr.Enabled = false;
                cbsperdr.Enabled = false;
            }
        }





        private void btnsyphilisisupdate_Click(object sender, EventArgs e)
        {
            cbnonsperdr.Enabled = true;
            cbsperdr.Enabled = true;
            btnsyphilisconfirm.Enabled = true;
            btnsyphilisisupdate.Enabled = false;
            btnsyphiliseligibility.Enabled = true;
        }



        private void btnsyphilisconfirm_Click(object sender, EventArgs e)
        {
            try
            {
                //SYPHILIS Test-update

                SqlConnection con1 = new SqlConnection("Data Source=DESKTOP-ILF4RKJ\\MSSQLSERVER01;Initial Catalog=bloodBank;Integrated Security=True");
                String qry1 = "update SYPHILIS set NONSPECIFICRDR = '" + cbnonsperdr.Text + "',SPECIFICRDR = '" + cbsperdr.Text + "' where buID= ('" + txtbloodunitid.Text + "')";
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
            btnsyphilisconfirm.Enabled = false;
            cbnonsperdr.Enabled = false;
            cbsperdr.Enabled = false;
        }
        private void btnsyphiliseligibility_Click(object sender, EventArgs e)
        {
            string var1, var2;
            var1 = cbnonsperdr.Text;

            var2 = cbsperdr.Text;



            if (var1 == "NonReactive" && var2 == "NonReactive")
            {
                MessageBox.Show("No Syphilis\nIncubating Syphilis\nELIGIBLE");
                syphiliseligibility = "ELIGIBLE";
                sypN = "YES";

            }
            else if (var1 == "Reactive" && var2 == "Reactive")
            {
                MessageBox.Show("Syphilis(Old and New)\nOther treponemal infection\nNOT ELIGIBLE ");
                syphiliseligibility = "NOTELIGIBLE";
                sypN = "NO";

            }
            else if (var1 == "NonReactive" && var2 == "Reactive")
            {
                MessageBox.Show("Treated Syphilis\nEarly Primary Syphilis\nProzone Reactive\nNOT ELIGIBLE ");
                syphiliseligibility = "NOTELIGIBLE";
                sypN = "NO";
            }
            else
            {
                MessageBox.Show("False Reactive RPR\nFalse Negative Specific Test\nELIGIBLE");
                syphiliseligibility = "ELIGIBLE";
                sypN = "YES";
            }
            btnsyphiliseligibility.Enabled = false;
            lbsyphilis.Text = syphiliseligibility.ToString();
            groupBox6.Enabled = true;

        }

        private void finalEligibility_Click(object sender, EventArgs e)
        {
            paneligibility = Clipboard.GetText();
            if (txtpan.Text == "NO")
            {
                if (hiveligibility == "ELIGIBLE" && hepatitiseligibility == "ELIGIBLE" && syphiliseligibility == "ELIGIBLE")
                {
                    label25.Text = "ELIGIBLE, APPROVED FOR TRANSFERRING";
                    labeli = "YES";
                    upbut();
                    updon();
                }
                else
                {
                    label25.Text = "NOT ELIGIBLE, NOT APPROVED FOR TRANSFERRING ";
                    labeli = "NO";
                    upbut();
                    updon();
                }
                panN = "NOTNEEDED";
                insert();
            }
            else
            {
                if (hiveligibility == "ELIGIBLE" && hepatitiseligibility == "ELIGIBLE" && syphiliseligibility == "ELIGIBLE" && paneligibility == "ELIGIBLE")
                {
                    label25.Text = "ELIGIBLE, APPROVED FOR TRANSFERRING";
                    labeli = "YES";
                    panN = "YES";
                    upbut();
                    updon();

                }
                else
                {
                    label25.Text = "NOT ELIGIBLE, NOT APPROVED FOR TRANSFERRING ";
                    labeli = "NO";
                    panN = "NO";
                    upbut();
                    updon();
                }
                insert();
            }

        }
        private void upbut()
        {
            SqlConnection con1 = new SqlConnection("Data Source=DESKTOP-ILF4RKJ\\MSSQLSERVER01;Initial Catalog=bloodBank;Integrated Security=True");
            String qry1 = "update bloodunit set LabEligibility  = '" + labeli + "' where bloodunitId= ('" + txtbloodunitid.Text + "')";
            SqlCommand cmd1 = new SqlCommand(qry1, con1);
            con1.Open();
            cmd1.ExecuteNonQuery();
            MessageBox.Show(" Blood unit Data Updated.", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            con1.Close();
        }

        private void updon()
        {
            SqlConnection con1 = new SqlConnection("Data Source=DESKTOP-ILF4RKJ\\MSSQLSERVER01;Initial Catalog=bloodBank;Integrated Security=True");
            String qry1 = "update DonarEligibility set LabEligibility  = '" + labeli + "' where DonarNIC= ('" + txtDNIC.Text + "') AND DDate= ('" + txtDDate.Text + "')";
            SqlCommand cmd1 = new SqlCommand(qry1, con1);
            con1.Open();
            cmd1.ExecuteNonQuery();
            MessageBox.Show(" Donor Data Updated.", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            con1.Close();
        }

        private void insert()//didn't check this one
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-NAVOD\\SQLEXPRESS;Initial Catalog=bloodBank;Integrated Security=True");
                String qry = "INSERT INTO Labtest VALUES('" + txtbloodunitid.Text + "', '" + txtDNIC.Text + "' , '" + txtDDate.Text + "' ,' " + hivN + " ',' " + hepN + "', '" + sypN + "','" + panN + "')";
                SqlCommand cmd = new SqlCommand(qry, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Data is inserted", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnlipidupdate.Enabled = true;



            }
            catch (Exception ex)
            {
                MessageBox.Show("Data is not inserted." + ex.Message);
            }
        }
        private void button20_Click(object sender, EventArgs e)
        {
            buID = txtbloodunitid.Text;
            Clipboard.SetText(buID);
            Donor_Lived_in_Pandameic_Area_Tests DL = new Donor_Lived_in_Pandameic_Area_Tests();
            DL.Show();

            
        }

        
    }
}
 