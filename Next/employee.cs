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
    public partial class employee : Form
    {
        public employee()
        {
            InitializeComponent();
        }

        public string User { get; set; }
        string query = "", connectionString = "Data Source=DESKTOP-KOQ2ITK;Initial Catalog=next_db;" + "Integrated Security=true;";
        SqlConnection sqlConnection;
        SqlDataAdapter adapter;
        DataSet ds;

        private void employee_Load(object sender, EventArgs e)
        {
            try
            {
                sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                query = "SELECT name FROM userData WHERE usrname = '" + User + "'";
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

            try
            {
                query = "SELECT * FROM userData";
                adapter = new SqlDataAdapter(query, sqlConnection);
                ds = new DataSet();
                adapter.Fill(ds, "userData");

                foreach (DataRow r in ds.Tables["userData"].Rows)
                {
                    if (Convert.ToString(r["usrname"]) == User)
                    {
                        id.Text = Convert.ToString(r["id"]);
                        string temp = Convert.ToString(r["name"]);
                        name.Text = temp.Replace('_', ' ');
                        email.Text = Convert.ToString(r["email"]);
                        phone.Text = Convert.ToString(r["phone"]);
                        age.Text = Convert.ToString(r["age"]);
                        expLevel.Text = Convert.ToString(r["expLevel"]);
                        salary.Text = Convert.ToString(r["salary"]);
                        gender.Text = Convert.ToString(r["gender"]);
                        role.Text = Convert.ToString(r["role"]);
                        usrname.Text = Convert.ToString(r["usrname"]);
                        missingPic.Visible = false;

                        byte[] arr = (byte[])(r["personImage"]);
                        MemoryStream stream = new MemoryStream(arr);
                        Bitmap bitmap = new Bitmap(stream);
                        pictureBox2.Image = bitmap;
                    }
                }
            }
            catch (Exception err)
            {
                missingPic.Visible = true;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            NextApp nextApp = new NextApp();
            this.Hide();
            nextApp.Show();
        }

        SqlCommand command;

        private void change_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files|*.bmp;*.gif;*.jpg;*.png;*.jpeg;*.tif|All files|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
                pictureBox2.Image = Image.FromFile(openFileDialog.FileName);
        }

        private void save_Click(object sender, EventArgs e)
        {
            foreach (DataRow r in ds.Tables["userData"].Rows)
            {
                if (Convert.ToString(r["usrname"]) == User)
                {
                    MemoryStream memoryStream = new MemoryStream();
                    pictureBox2.Image.Save(memoryStream, ImageFormat.Bmp);
                    byte[] array = memoryStream.ToArray();
                    r["personImage"] = array;

                    try
                    {
                        SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                        adapter.Update(ds, "userData");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void panelContainer_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
