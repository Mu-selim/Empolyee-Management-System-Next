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
    public partial class login : Form
    {

        string query = "", connectionString = "Data Source=DESKTOP-KOQ2ITK;Initial Catalog=next_db;" + "Integrated Security=true;";
        SqlConnection sqlConnection;
        SqlCommand command;
        SqlDataAdapter adapter;
        DataTable dt;
        SqlDataReader reader;
        public login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Back_Click(object sender, EventArgs e)
        {
            NextApp obj = new NextApp();
            this.Hide();
            obj.Show();
            sqlConnection.Close();
        }

        private void login_Load(object sender, EventArgs e)
        {
            label4.Visible = false;
            try
            {
                sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void buttonStyle1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                label4.Text = "Missing fileds";
                label4.Visible = true;
            }
            else
            {
                bool flag = checkLogin();
                if (flag)
                {
                    if (checkRole())
                    {
                        manger obj = new manger();
                        this.Hide();
                        obj.User = textBox2.Text;
                        obj.Show();
                        sqlConnection.Close();
                    }
                    else
                    {
                        employee obj = new employee();
                        obj.User = textBox2.Text;
                        this.Hide();
                        obj.Show();
                        sqlConnection.Close();
                    }
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private bool checkLogin()
        {
            try
            {
                query = "SELECT * FROM login WHERE usrname = '" + textBox2.Text + "' and password = '" + textBox1.Text + "'";
                SqlCommand command = new SqlCommand(query, sqlConnection);

                // check if there is a user or not
                reader = command.ExecuteReader();
                if (reader.Read())
                {
                    reader.Close();
                    return true;
                }
                else
                {
                    reader.Close();
                    label4.Visible = true;
                    return false;
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
                return false;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (textBox1.UseSystemPasswordChar)
                textBox1.UseSystemPasswordChar = false;
            else
                textBox1.UseSystemPasswordChar = true;
        }

        private bool checkRole()
        {
            try
            {
                // check if this user ia a manager or employee
                query = "SELECT * FROM userData WHERE role = 'manager' and usrname = '" + textBox2.Text + "'";
                command = new SqlCommand(query, sqlConnection);
                reader = command.ExecuteReader();
                if (reader.Read())
                {
                    reader.Close();
                    return true;
                }
                else
                {
                    reader.Close();
                    return false;
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
                return false;
            }
        }
    }
}
