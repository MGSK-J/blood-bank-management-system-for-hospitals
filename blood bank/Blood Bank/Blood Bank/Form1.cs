using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;


namespace Blood_Bank
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUserName.Clear();
            txtPassword.Clear();
            cmbLogin.SelectedIndex = -1;
            txtEmpId.Clear();

            txtEmpId.Enabled = false;
            txtUserName.Enabled = false;
            txtPassword.Enabled = false;
            btnLogin.Enabled = false;

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Admin obj = new Admin();
            Clerk clerkLogin = new Clerk();
            Doctor_Login doctorLogin = new Doctor_Login();
            Lab_Assistant labAssistant = new Lab_Assistant();
            Director dir = new Director();
            
            try
            {
                if(cmbLogin.SelectedIndex == 1)
                {
                    if (clerkLogin.userLogin(Convert.ToString(txtEmpId.Text), Convert.ToString(txtPassword.Text), Convert.ToString(txtUserName.Text)))
                    {
                        this.Close();
                        Thread openFormForDonator = new Thread(openForm);
                        openFormForDonator.SetApartmentState(ApartmentState.STA);
                        openFormForDonator.Start();
                    }
                    else
                    {
                        MessageBox.Show("Entered UserName Or Password Is Incorrect", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        cmbLogin.SelectedIndex = -1;
                        txtEmpId.Clear();
                        txtEmpId.Enabled = false;
                        txtUserName.Clear();
                        txtUserName.Enabled = false;
                        txtPassword.Clear();
                        txtPassword.Enabled = false;
                        btnClear.Enabled = false;
                        btnLogin.Enabled = false;
                    }
                }
                else if(cmbLogin.SelectedIndex == 0)
                {
                    if (doctorLogin.userLogin(Convert.ToString(txtEmpId.Text), Convert.ToString(txtPassword.Text), Convert.ToString(txtUserName.Text)))
                    {
                        Thread td = new Thread(openDoctorForm);
                        td.SetApartmentState(ApartmentState.STA);
                        td.Start();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Entered UserName Or Password Is Incorrect", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        cmbLogin.SelectedIndex = -1;
                        txtEmpId.Clear();
                        txtEmpId.Enabled = false;
                        txtUserName.Clear();
                        txtUserName.Enabled = false;
                        txtPassword.Clear();
                        txtPassword.Enabled = false;
                        btnClear.Enabled = false;
                        btnLogin.Enabled = false;
                    }
                }
                else if (cmbLogin.SelectedIndex == 2)
                {
                    if (dir.userLogin(Convert.ToString(txtEmpId.Text), Convert.ToString(txtPassword.Text), Convert.ToString(txtUserName.Text)))
                    {
                        Thread dirForm = new Thread(openDirectorForm);
                        dirForm.SetApartmentState(ApartmentState.STA);
                        dirForm.Start();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Entered UserName Or Password Is Incorrect", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        cmbLogin.SelectedIndex = -1;
                        txtEmpId.Clear();
                        txtEmpId.Enabled = false;
                        txtUserName.Clear();
                        txtUserName.Enabled = false;
                        txtPassword.Clear();
                        txtPassword.Enabled = false;
                        btnClear.Enabled = false;
                        btnLogin.Enabled = false;
                    }
                }
                else if (cmbLogin.SelectedIndex == 4)
                {
                    if (labAssistant.userLogin(Convert.ToString(txtEmpId.Text), Convert.ToString(txtPassword.Text), Convert.ToString(txtUserName.Text)))
                    {
                        Thread lab = new Thread(openLabSheetForm);
                        lab.SetApartmentState(ApartmentState.STA);
                        lab.Start();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Entered UserName Or Password Is Incorrect", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        cmbLogin.SelectedIndex = -1;
                        txtEmpId.Clear();
                        txtEmpId.Enabled = false;
                        txtUserName.Clear();
                        txtUserName.Enabled = false;
                        txtPassword.Clear();
                        txtPassword.Enabled = false;
                        btnClear.Enabled = false;
                        btnLogin.Enabled = false;
                    }
                }
                else if(cmbLogin.SelectedIndex == 3)
                {
                    if (obj.userLogin(txtUserName.Text, txtPassword.Text))
                    {
                        MessageBox.Show("You Have Loged In!", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                        Thread newThread = new Thread(openAdminForm);
                        newThread.SetApartmentState(ApartmentState.STA);
                        newThread.Start();
                    }
                    else
                    {
                        MessageBox.Show("UserName Or Password is incorrect!", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cmbLogin.SelectedIndex = -1;
                        txtEmpId.Clear();
                        txtEmpId.Enabled = false;
                        txtUserName.Clear();
                        txtUserName.Enabled = false;
                        txtPassword.Clear();
                        txtPassword.Enabled = false;
                        btnClear.Enabled = false;
                        btnLogin.Enabled = false;
                    }
                }
                else
                {
                    // empty
                }
            }
            catch(Exception allLoginProcess)
            {
                MessageBox.Show(allLoginProcess.Message);
            }

        }

        private void openDirectorForm()
        {
            Application.Run(new Director_Form());
        }

        private void openLabSheetForm()
        {
            Application.Run(new LAB());
        }

        private void openDoctorForm()
        {
            Application.Run(new Doctor());
        }

        private void openForm()
        {
            Application.Run(new Get_Blood_Donator_Details());
        }

        private void openAdminForm()
        {
            Application.Run(new AdminForm());
        }

        private void cmbLogin_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbLogin.SelectedIndex == 3)
            {
                txtUserName.Enabled = true;
                txtEmpId.Clear();
                txtEmpId.Enabled = false;
                txtPassword.Clear();
                txtPassword.Enabled = false;
            }
            else if(cmbLogin.SelectedIndex == 1 || cmbLogin.SelectedIndex == 4 || cmbLogin.SelectedIndex == 2)
            {
                txtEmpId.Enabled = true;
                txtEmpId.Clear();
            }
            else if(cmbLogin.SelectedIndex == 0)
            {
                txtEmpId.Clear();
                txtEmpId.Enabled = true;
                txtPassword.Clear();
                txtUserName.Clear();
                btnClear.Enabled = false;
                btnLogin.Enabled = false;
            }
            else
            {
                txtUserName.Enabled = false;
            }

            

        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
            if(txtUserName.Text.Length > 0)
            {
                txtPassword.Enabled = true;
                btnClear.Enabled = true;
            }
            else
            {
                txtPassword.Enabled = false;
                btnClear.Enabled = false;
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            if(txtPassword.Text.Length > 0)
            {
                btnLogin.Enabled = true;
            }
            else
            {
                btnLogin.Enabled = false;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnClear.Enabled = false;
            txtUserName.Enabled = false;
            txtPassword.Enabled = false;
            txtEmpId.Enabled = false;
            btnLogin.Enabled = false;
        }

        private void txtPassword_TextChanged_1(object sender, EventArgs e)
        {
            if(txtPassword.Text.Length > 0)
            {
                btnLogin.Enabled = true;
                btnClear.Enabled = true;
            }
            else
            {
                btnLogin.Enabled = false;
                btnClear.Enabled = false;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();            
        }

        private void txtEmpId_TextChanged(object sender, EventArgs e)
        {
            if(txtEmpId.TextLength > 0)
            {
                txtUserName.Enabled = true;
                btnClear.Enabled = true;
            }
            else
            {
                txtUserName.Enabled = false;
                btnClear.Enabled = false;
            }
        }
    }
}
