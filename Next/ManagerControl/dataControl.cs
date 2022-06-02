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

namespace Next.ManagerControl
{
    public partial class dataControl : UserControl
    {
        string query = "", connectionString = "Data Source=DESKTOP-KOQ2ITK;Initial Catalog=next_db;" + "Integrated Security=true;";
        SqlConnection sqlConnection;
        SqlDataAdapter adapter;
        DataTable dt;

        private void dataControl_Load(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = true;
            try
            {
                sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                query = "SELECT * FROM dbo.userData";
                adapter = new SqlDataAdapter(query, sqlConnection);
                dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
                sqlConnection.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
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
                phone.Text = dataGridView1.Rows[rowIndex].Cells[3].Value.ToString();
                age.Text = dataGridView1.Rows[rowIndex].Cells[4].Value.ToString();
                expLevel.Text = dataGridView1.Rows[rowIndex].Cells[5].Value.ToString();
                salary.Text = dataGridView1.Rows[rowIndex].Cells[6].Value.ToString();
                gender.Text = dataGridView1.Rows[rowIndex].Cells[7].Value.ToString();
                role.Text = dataGridView1.Rows[rowIndex].Cells[8].Value.ToString();
                usrname.Text = dataGridView1.Rows[rowIndex].Cells[9].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public dataControl()
        {
            InitializeComponent();
        }
    }
}
