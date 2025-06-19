using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Unicom_TIC_Managment_System.Veiw
{
    public partial class CourseForm : Form
    {
        SQLiteConnection conn = new SQLiteConnection("Data Source=unicom.db;Version=3;");
        SQLiteCommand cmd;
        SQLiteDataAdapter adapter;
        DataTable dt = new DataTable();

        public CourseForm()
        {
            InitializeComponent();
            LoadCourses();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Please select a course to delete.");
                return;
            }

            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["CourseID"].Value);
            conn.Open();
            cmd = new SQLiteCommand("DELETE FROM Courses WHERE CourseID=@ID", conn);
            cmd.Parameters.AddWithValue("@ID", id);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Course deleted!");
            LoadCourses();
            ClearFields();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        void LoadCourses()
        {
            dt.Clear();
            conn.Open();
            adapter = new SQLiteDataAdapter("SELECT * FROM Courses", conn);
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        void ClearFields()
        {
            txtCourseName.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtCourseName.Text == "")
            {
                MessageBox.Show("Please enter course name.");
                return;
            }

            conn.Open();
            cmd = new SQLiteCommand("INSERT INTO Courses(CourseName) VALUES (@CourseName)", conn);
            cmd.Parameters.AddWithValue("@CourseName", txtCourseName.Text);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Course added successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            conn.Close();
            LoadCourses();
            ClearFields();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Please select a course to update.");
                return;
            }

            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["CourseID"].Value);
            conn.Open();
            cmd = new SQLiteCommand("UPDATE Courses SET CourseName=@CourseName WHERE CourseID=@ID", conn);
            cmd.Parameters.AddWithValue("@CourseName", txtCourseName.Text);
            cmd.Parameters.AddWithValue("@ID", id);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Course updated successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            conn.Close();
            LoadCourses();
            ClearFields();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                txtCourseName.Text = row.Cells["CourseName"].Value.ToString();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide(); 
            UserView mainForm = new UserView(); 
            mainForm.Show(); // show main form again
        }

        private void CourseForm_Load(object sender, EventArgs e)
        {

        }
    }

}
