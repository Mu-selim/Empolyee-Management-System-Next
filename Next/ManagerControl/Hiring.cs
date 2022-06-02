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
    public partial class Hiring : UserControl
    {
        public Hiring()
        {
            InitializeComponent();
        }

        string query = "", connectionString = "Data Source=DESKTOP-KOQ2ITK;Initial Catalog=next_db;" + "Integrated Security=true;";
        SqlConnection sqlConnection;
        SqlDataAdapter adapter1, adapter2, adapter3;
        DataSet ds1, ds2, ds3;
        DataRow rowLogin, rowData;

        private void accept_Click(object sender, EventArgs e)
        {
            if (expLevel.Text == "" || salary.Text == "" || age.Text == "")
            {
                missingFields.Visible = true;
            }
            else
            {
                bool state = false;
                missingFields.Visible = false;
                foreach (DataRow r in ds1.Tables[0].Rows)
                {
                    if (Convert.ToString(r["usrname"]) == usrname.Text)
                    {
                        rowLogin = ds2.Tables[0].NewRow();
                        rowLogin[0] = r["usrname"];
                        rowLogin[1] = r["password"];

                        rowData = ds3.Tables[0].NewRow();
                        rowData["name"] = r["name"];
                        rowData["email"] = r["email"];
                        rowData["phone"] = phone.Text;
                        rowData["age"] = Convert.ToInt32(age.Text);
                        rowData["expLevel"] = expLevel.Text.Replace(' ', '_');
                        rowData["salary"] = salary.Text;
                        rowData["gender"] = r["gender"];
                        rowData["role"] = "employee";
                        rowData["usrname"] = r["usrname"];
                        rowData["personImage"] = r["imagefile"];

                        r.Delete();
                    }
                }
                try
                {
                    ds2.Tables[0].Rows.Add(rowLogin);
                    SqlCommandBuilder builder = new SqlCommandBuilder(adapter2);
                    adapter2.Update(ds2);

                    ds3.Tables[0].Rows.Add(rowData);
                    builder = new SqlCommandBuilder(adapter3);
                    adapter3.Update(ds3);

                    builder = new SqlCommandBuilder(adapter1);
                    adapter1.Update(ds1);

                    MessageBox.Show("Accepted successfully");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void reject_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataRow r in ds1.Tables[0].Rows)
                {
                    if (Convert.ToString(r["usrname"]) == usrname.Text)
                    {
                        r.Delete();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            try
            {
                SqlCommandBuilder builder = new SqlCommandBuilder(adapter1);
                adapter1.Update(ds1);
                MessageBox.Show("Rejected successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            try
            {
                int rowIndex = dataGridView1.CurrentCell.RowIndex;
                string temp = "";

                id.Text = dataGridView1.Rows[rowIndex].Cells[0].Value.ToString();
                temp = dataGridView1.Rows[rowIndex].Cells[1].Value.ToString();
                name.Text = temp.Replace('_', ' ');
                email.Text = dataGridView1.Rows[rowIndex].Cells[2].Value.ToString();
                usrname.Text = dataGridView1.Rows[rowIndex].Cells[3].Value.ToString();
                gender.Text = dataGridView1.Rows[rowIndex].Cells[5].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Hiring_Load(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = true;
            missingFields.Visible = false;
            try
            {
                sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();

                query = "SELECT * FROM dbo.register";
                adapter1 = new SqlDataAdapter(query, sqlConnection);
                ds1 = new DataSet();
                adapter1.Fill(ds1);
                dataGridView1.DataSource = ds1.Tables[0];

                query = "SELECT * FROM dbo.login";
                adapter2 = new SqlDataAdapter(query, sqlConnection);
                ds2 = new DataSet();
                adapter2.Fill(ds2);

                query = "SELECT * FROM dbo.userData";
                adapter3 = new SqlDataAdapter(query, sqlConnection);
                ds3 = new DataSet();
                adapter3.Fill(ds3);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
    }
}
