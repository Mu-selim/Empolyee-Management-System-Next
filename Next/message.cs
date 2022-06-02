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
    public partial class message : Form
    {
        public message()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            NextApp obj = new NextApp();
            this.Hide();
            obj.Show();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Back_Click(object sender, EventArgs e)
        {
            NextApp obj = new NextApp();
            this.Hide();
            obj.Show();
        }
    }
}
