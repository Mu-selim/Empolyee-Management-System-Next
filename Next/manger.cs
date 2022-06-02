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

namespace Next
{
    public partial class manger : Form
    {
        public manger()
        {
            InitializeComponent();
        }

        public string User { get; set; }

        string query = "", connectionString = "Data Source=DESKTOP-KOQ2ITK;Initial Catalog=next_db;" + "Integrated Security=true;";
        SqlConnection sqlConnection;
        SqlCommand command;

        private void manger_Load(object sender, EventArgs e)
        {
            try
            {
                sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                query = "SELECT name FROM userData WHERE usrname = '"+User+"'";
                command = new SqlCommand(query, sqlConnection);
                string temp = "";
                SqlDataReader reader = command.ExecuteReader(); 
                if (reader.Read())
                {
                    temp = reader.GetString(0);
                    temp = temp.Replace('_', ' ');
                    label2.Text = temp;
                    reader.Close();
                }
                else
                {
                    label2.Text = "";
                    reader.Close();
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            NextApp nextApp = new NextApp();
            this.Hide();
            nextApp.Show();
            sqlConnection.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonStyle1_Click(object sender, EventArgs e)
        {
            ManagerControl.dataControl dc = new ManagerControl.dataControl();
            addManagerControl(dc);
        }

        private void buttonStyle2_Click(object sender, EventArgs e)
        {
            ManagerControl.dashboard dashboard = new ManagerControl.dashboard();
            addManagerControl(dashboard);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void profile_Click(object sender, EventArgs e)
        {
            ManagerControl.Profile profile = new ManagerControl.Profile();
            profile.Usrname = User;
            addManagerControl(profile);
        }

        private void buttonStyle3_Click(object sender, EventArgs e)
        {
            ManagerControl.Search search = new ManagerControl.Search();
            addManagerControl(search);
        }

        private void buttonStyle5_Click(object sender, EventArgs e)
        {
            ManagerControl.Hiring hiring = new ManagerControl.Hiring();
            addManagerControl(hiring);
        }

        private void panelContainer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void addManagerControl(UserControl userControl)
        {
            userControl.Dock =DockStyle.Fill;
            panelContainer.Controls.Clear();
            panelContainer.Controls.Add(userControl);
            userControl.BringToFront();
        }
    }
}
