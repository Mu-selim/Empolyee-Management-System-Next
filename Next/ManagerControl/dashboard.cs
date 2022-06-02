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
    public partial class dashboard : UserControl
    {
        public dashboard()
        {
            InitializeComponent();
        }

        string query = "", connectionString = "Data Source=DESKTOP-KOQ2ITK;Initial Catalog=next_db;" + "Integrated Security=true;";
        SqlConnection sqlConnection;
        SqlCommand command;
        SqlDataReader reader;

        private void dashboard_Load(object sender, EventArgs e)
        {
            connect();
            percentGender();
            experienceLevel();
            buttons();
            disconnect();
        }

        private void connect()
        {
            try
            {
                sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void percentGender()
        {
            try
            {
                query = "SELECT COUNT(gender) FROM userData WHERE gender = 'male'";
                command = new SqlCommand(query, sqlConnection);
                int male = 0, female = 0, total = 0;
                reader = command.ExecuteReader();
                if (reader.Read())
                {
                    male = reader.GetInt32(0);
                    reader.Close();
                }

                query = "SELECT COUNT(gender) FROM userData WHERE gender = 'female'";
                command = new SqlCommand(query, sqlConnection);
                reader = command.ExecuteReader();
                if (reader.Read())
                {
                    female = reader.GetInt32(0);
                    reader.Close();
                }

                query = "SELECT COUNT(gender) FROM userData";
                command = new SqlCommand(query, sqlConnection);
                reader = command.ExecuteReader();
                if (reader.Read())
                {
                    total = reader.GetInt32(0);
                    reader.Close();
                }
                double malePer = 0, femalePer = 0;
                try
                {
                    malePer = Math.Round((Double)(male * 100) / (total * 1.0), 2);
                    femalePer = Math.Round((Double)(female * 100) / (total * 1.0), 2);
                }
                catch { }
                reader.Close();

                chartGenderPie.Series["genderPercentage"].Points.Add(male);
                chartGenderPie.Series["genderPercentage"].Points[0].AxisLabel = $"Male {malePer}%";
                chartGenderPie.Series["genderPercentage"].Points[0].LegendText = "Male";

                chartGenderPie.Series["genderPercentage"].Points.Add(female);
                chartGenderPie.Series["genderPercentage"].Points[1].AxisLabel = $"Female {femalePer}%";
                chartGenderPie.Series["genderPercentage"].Points[1].LegendText = "Female";
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void experienceLevel()
        {
            try
            {
                query = "SELECT COUNT(expLevel) FROM userData WHERE expLevel = 'junior'";
                command = new SqlCommand(query, sqlConnection);
                int junior = 0, senior = 0, team_leader = 0;
                reader = command.ExecuteReader();
                if (reader.Read())
                {
                    junior = reader.GetInt32(0);
                    reader.Close();
                }

                query = "SELECT COUNT(expLevel) FROM userData WHERE expLevel = 'senior'";
                command = new SqlCommand(query, sqlConnection);
                reader = command.ExecuteReader();
                if (reader.Read())
                {
                    senior = reader.GetInt32(0);
                    reader.Close();
                }

                query = "SELECT COUNT(expLevel) FROM userData WHERE expLevel = 'team_leader'";
                command = new SqlCommand(query, sqlConnection);
                reader = command.ExecuteReader();
                if (reader.Read())
                {
                    team_leader = reader.GetInt32(0);
                    reader.Close();
                }
                reader.Close();

                chartExperienceLevel.Series["Experience Level"].Points.Add(junior);
                chartExperienceLevel.Series["Experience Level"].Points[0].AxisLabel = "junior";
                chartExperienceLevel.Series["Experience Level"].Points[0].LegendText = "junior";

                chartExperienceLevel.Series["Experience Level"].Points.Add(senior);
                chartExperienceLevel.Series["Experience Level"].Points[1].AxisLabel = "senior";
                chartExperienceLevel.Series["Experience Level"].Points[1].LegendText = "senior";

                chartExperienceLevel.Series["Experience Level"].Points.Add(team_leader);
                chartExperienceLevel.Series["Experience Level"].Points[2].AxisLabel = "Team Leader";
                chartExperienceLevel.Series["Experience Level"].Points[2].LegendText = "Team Leader";

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void buttons()
        {
            try
            {
                query = "SELECT SUM(salary) FROM userData";
                command = new SqlCommand(query, sqlConnection);
                double sum = 0, avg = 0, max = 0, min = 0;
                reader = command.ExecuteReader();
                if (reader.Read())
                {
                    sum = reader.GetDouble(0);
                    reader.Close();
                }
                totalSalary.Text = $"{sum} $";

                query = "SELECT AVG(salary) FROM userData";
                command = new SqlCommand(query, sqlConnection);
                reader = command.ExecuteReader();
                if (reader.Read())
                {
                    avg = reader.GetDouble(0);
                    reader.Close();
                }
                avgSalary.Text = $"{Math.Round((Double) avg, 2)} $";

                query = "SELECT MAX(salary) FROM userData";
                command = new SqlCommand(query, sqlConnection);
                reader = command.ExecuteReader();
                if (reader.Read())
                {
                    max = reader.GetDouble(0);
                    reader.Close();
                }
                maxSalary.Text = $"{max} $";

                query = "SELECT MIN(salary) FROM userData";
                command = new SqlCommand(query, sqlConnection);
                reader = command.ExecuteReader();
                if (reader.Read())
                {
                    min = reader.GetDouble(0);
                    reader.Close();
                }
                minSalary.Text = $"{min} $";

                reader.Close();

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void buttonStyle1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void buttonStyle1_Click_1(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void disconnect()
        {
            try
            {
                sqlConnection.Close();
            }
            catch { }
        }
    }
}
