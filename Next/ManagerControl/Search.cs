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

namespace Next.ManagerControl
{
    public partial class Search : UserControl
    {
        public Search()
        {
            InitializeComponent();
        }

        string query = "", connectionString = "Data Source=DESKTOP-KOQ2ITK;Initial Catalog=next_db;" + "Integrated Security=true;";
        SqlConnection sqlConnection;
        SqlDataAdapter adapter, adapter1;
        DataSet ds, ds1;

        private void profile_Click(object sender, EventArgs e)
        {
            bool found = false;
            foreach (DataRow r in ds.Tables["userData"].Rows)
            {
                if (Convert.ToString(r["usrname"]) == userSearch.Text)
                {
                    found = true;
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
                    notFound.Visible = false;
                }
            }
            if (!found)
            {
                notFound.Visible = true;
                id.Text = name.Text = email.Text = phone.Text = age.Text 
                        = expLevel.Text = salary.Text = gender.Text 
                        = role.Text = "";
            }
        }

        private void update_Click(object sender, EventArgs e)
        {
            if (name.Text == "" || email.Text == "" || phone.Text == ""
                || age.Text == "" || expLevel.Text == "" || salary.Text == ""
                || role.Text == "")
            {
                hintUpdate.Text = "missing fields";
                hintUpdate.ForeColor = Color.Red;
                hintUpdate.Visible = true;
            }
            else
            {
                foreach (DataRow r in ds.Tables["userData"].Rows)
                {
                    if (Convert.ToString(r["usrname"]) == userSearch.Text)
                    {
                        r["name"] = Convert.ToString(name.Text);
                        r["email"] = Convert.ToString(email.Text);
                        r["phone"] = Convert.ToString(phone.Text);
                        r["age"] = Convert.ToInt16(age.Text);
                        r["expLevel"] = Convert.ToString(expLevel.Text);
                        r["salary"] = Convert.ToDouble(salary.Text);
                        r["role"] = Convert.ToString(role.Text);
                    }
                }
                try
                {
                    SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                    adapter.Update(ds, "userData");
                    hintUpdate.Text = "Updated successfully";
                    hintUpdate.ForeColor = Color.Green;
                    hintUpdate.Visible = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }            }
        }

        private void fire_Click(object sender, EventArgs e)
        {
            foreach(DataRow r in ds.Tables["userData"].Rows)
            {
                if (Convert.ToString(r["usrname"]) == userSearch.Text)
                {
                    r.Delete();
                    break;
                }
            }
            foreach (DataRow r in ds1.Tables[0].Rows)
            {
                if (Convert.ToString(r["usrname"]) == userSearch.Text)
                {
                    r.Delete();
                    break;
                }
            }
            updateDS();
            try
            {
                SqlCommandBuilder builder = new SqlCommandBuilder(adapter1);
                adapter1.Update(ds1);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void promote_Click(object sender, EventArgs e)
        {
            foreach(DataRow r in ds.Tables["userData"].Rows)
            {
                if (Convert.ToString(r["usrname"]) == userSearch.Text)
                {
                    r["role"] = "manager";
                    break;
                }
            }
            updateDS();
        }

        private void Search_Load(object sender, EventArgs e)
        {
            notFound.Visible = false;
            hintUpdate.Visible = false;
            try
            {
                sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                query = "SELECT * FROM dbo.userData";
                adapter = new SqlDataAdapter(query, sqlConnection);
                ds = new DataSet();
                adapter.Fill(ds, "userData");

                query = "SELECT * FROM dbo.login";
                adapter1 = new SqlDataAdapter(query, sqlConnection);
                ds1 = new DataSet();
                adapter1.Fill(ds1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void updateDS()
        {
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
