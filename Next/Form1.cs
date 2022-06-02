using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Next
{
    public partial class NextApp : Form
    {
        public NextApp()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void login_Click(object sender, EventArgs e)
        {
            login obj = new login();
            this.Hide();
            obj.Show();
        }

        private void register_Click(object sender, EventArgs e)
        {
            register obj = new register();
            this.Hide();
            obj.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
