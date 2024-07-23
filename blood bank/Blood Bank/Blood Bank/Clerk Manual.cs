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

namespace Blood_Bank
{
    public partial class Clerk_Manual : Form
    {
        public Clerk_Manual()
        {
            InitializeComponent();
        }

        private void Clerk_Manual_Load(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thread td = new Thread(backGetDonarDetailsForm);
            td.SetApartmentState(ApartmentState.STA);
            td.Start();
            this.Close();
        }

        private void backGetDonarDetailsForm()
        {
            Application.Run(new Get_Blood_Donator_Details());
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
