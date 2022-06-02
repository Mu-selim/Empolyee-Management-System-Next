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
using System.IO;
using System.Drawing.Imaging;

namespace Next
{
    public partial class register : Form
    {
        string query = "", connectionString = "Data Source=DESKTOP-KOQ2ITK;Initial Catalog=next_db;" + "Integrated Security=true;";
        SqlConnection sqlConnection;
        SqlCommand command;
        SqlDataReader reader;
        SqlDataAdapter adapter;
        DataSet ds;
        public register()
        {
            InitializeComponent();
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
            sqlConnection.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void register_Load(object sender, EventArgs e)
        {
            label4.Visible = false;
            label7.Visible = false;
            label10.Visible = false;
            radioButton1.Checked = true;
            missingPic.Visible = false;

            try
            {
                sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                query = "SELECT * FROM dbo.register";
                adapter = new SqlDataAdapter(query, sqlConnection);
                ds = new DataSet();
                adapter.Fill(ds, "register");
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (textBox5.UseSystemPasswordChar)
                textBox5.UseSystemPasswordChar = false;
            else
                textBox5.UseSystemPasswordChar = true;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (textBox4.UseSystemPasswordChar)
                textBox4.UseSystemPasswordChar = false;
            else
                textBox4.UseSystemPasswordChar = true;
        }

        private void login_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text.ToString();
            name = name.Replace(' ', '_');
            string email = textBox2.Text.ToString();
            string username = textBox3.Text.ToString();
            string password = textBox5.Text.ToString();
            string birthday = dateTimePicker1.Text.ToString();
            birthday = birthday.Replace(',', '_');
            birthday = birthday.Replace(' ', '_');
            string gender;
            if (radioButton1.Checked)
                gender = "male";
            else
                gender = "female";

            bool flag1 = true, flag2 = true, flag3 = false;

            if (!checkFilled())
            {
                label10.Visible = true;
                flag1 = false;
            }
            if (!userAvailable())
            {
                label4.Visible = true;
                flag2 = false;
            }
            if (checkPass())
            {
                label7.Visible = false;
                flag3 = true;
            }
            
            if (flag1 && flag2 && flag3)
            {
                DataRow r = ds.Tables["register"].NewRow();

                r["name"] = name;
                r["email"] = email;
                r["usrname"] = username;
                r["password"] = password;
                r["date"] = birthday;
                r["gender"] = gender;

                try
                {
                    MemoryStream memoryStream = new MemoryStream();
                    pictureBox3.Image.Save(memoryStream, ImageFormat.Bmp);
                    byte[] array = memoryStream.ToArray();
                    r["imagefile"] = array;
                    ds.Tables["register"].Rows.Add(r);
                    missingPic.Visible = false;

                    SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                    adapter.Update(ds, "register");
                    message obj = new message();
                    this.Hide();
                    obj.Show();
                    sqlConnection.Close();
                }
                catch (Exception ex)
                {
                    missingPic.Visible = true;
                }
            }
        }

        private bool checkFilled()
        {
            if (textBox1.Text == "" || textBox2.Text == "" ||
                textBox3.Text == "" || textBox4.Text == "" ||
                textBox5.Text == "")
                return false;
            label10.Visible = false;
            return true;
        }

        private bool checkPass()
        {
            if (textBox4.Text == textBox5.Text)
                return true;
            else
            {
                label7.Visible = true;
                return false;
            }
        }

        private void buttonStyle1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files|*.bmp;*.gif;*.jpg;*.png;*.tif|All files|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
                pictureBox3.Image = Image.FromFile(openFileDialog.FileName);
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private bool userAvailable()
        {
            try
            {
                query = "SELECT * FROM login WHERE usrname = '" + textBox3.Text + "'";
                command = new SqlCommand(query, sqlConnection);
                reader = command.ExecuteReader();
                if (reader.Read())
                {
                    reader.Close();
                    return false;
                }
                reader.Close();
                query = "SELECT * FROM register WHERE usrname = '" + textBox3.Text + "'";
                command = new SqlCommand(query, sqlConnection);
                reader = command.ExecuteReader();
                if (reader.Read())
                {
                    reader.Close();
                    return false;
                }
                else
                {
                    reader.Close();
                    label4.Visible = false;
                    return true;
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
                return true;
            }
        }
    }
}
