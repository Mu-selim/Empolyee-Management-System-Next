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

namespace Next.EmployeeControl
{
    public partial class Profile : UserControl
    {
        public Profile()
        {
            InitializeComponent();
        }

        public string Usrname { get; set; }

        string query = "", connectionString = "Data Source=DESKTOP-KOQ2ITK;Initial Catalog=next_db;" + "Integrated Security=true;";
        SqlConnection sqlConnection;
        SqlDataAdapter adapter;
        DataSet ds;

        private void save_Click(object sender, EventArgs e)
        {
            foreach (DataRow r in ds.Tables["userData"].Rows)
            {
                if (Convert.ToString(r["usrname"]) == Usrname)
                {
                    MemoryStream memoryStream = new MemoryStream();
                    pictureBox1.Image.Save(memoryStream, ImageFormat.Bmp);
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

        private void change_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files|*.bmp;*.gif;*.jpg;*.png;*.jpeg;*.tif|All files|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
                pictureBox1.Image = Image.FromFile(openFileDialog.FileName);
        }

        private void Profile_Load(object sender, EventArgs e)
        {
            try
            {
                sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                query = "SELECT * FROM dbo.userData";
                adapter = new SqlDataAdapter(query, sqlConnection);
                ds = new DataSet();
                adapter.Fill(ds, "userData");

                foreach (DataRow r in ds.Tables["userData"].Rows)
                {
                    if (Convert.ToString(r["usrname"]) == Usrname)
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
                        pictureBox1.Image = bitmap;
                    }
                }
            }
            catch (Exception err)
            {
                missingPic.Visible = true;
            }
        }
    }
}
