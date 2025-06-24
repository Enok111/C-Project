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
using System.Xml.Linq;
using Unicom_TIC_Managment_System.Model;
using Unicom_TIC_Managment_System.Reposteries;

namespace Unicom_TIC_Managment_System.Veiw
{
    public partial class StudentForm : Form
    {
        
        public StudentForm()
        {
            InitializeComponent();
            
        }

        private void StudentForm_Load(object sender, EventArgs e)
        {
            LoadCourses();
            LoadStudents();
        }
        private void LoadCourses()
        {
            using (var conn = DbCon.GetConnection())
            {
                var cmd = new SQLiteCommand("SELECT CourseID, CourseName FROM Courses", conn);
                var adapter = new SQLiteDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                comboCourse.DisplayMember = "CourseName";
                comboCourse.ValueMember = "CourseID";
                comboCourse.DataSource = dt;
            }

        }
        private void LoadStudents()
        {
            using (var conn = DbCon.GetConnection())
            {
                var query = @"SELECT s.StudentID, s.Name, c.CourseName 
                              FROM Students s
                              JOIN Courses c ON s.CourseID = c.CourseID";

                var cmd = new SQLiteCommand(query, conn);
                var adapter = new SQLiteDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();

            if (string.IsNullOrEmpty(name) || comboCourse.SelectedIndex == -1)
            {
                MessageBox.Show("Please enter student name and select a course.");
                return;
            }

            int courseId = Convert.ToInt32(comboCourse.SelectedValue);

            using (var conn = DbCon.GetConnection())
            {
                var cmd = new SQLiteCommand("INSERT INTO Students (Name, CourseID) VALUES (@Name, @CourseID)", conn);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@CourseID", courseId);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Student added successfully!");
            LoadStudents();
            ClearFields();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(hiddenStudentID.Text))
            {
                MessageBox.Show("Please select a student to update.");
                return;
            }

            string name = txtName.Text.Trim();
            int courseId = Convert.ToInt32(comboCourse.SelectedValue);
            int studentId = Convert.ToInt32(hiddenStudentID.Text);

            using (var conn = DbCon.GetConnection())
            {
                var cmd = new SQLiteCommand("UPDATE Students SET Name=@Name, CourseID=@CourseID WHERE StudentID=@StudentID", conn);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@CourseID", courseId);
                cmd.Parameters.AddWithValue("@StudentID", studentId);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Student updated successfully.");
            LoadStudents();
            ClearFields();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                hiddenStudentID.Text = dataGridView1.Rows[e.RowIndex].Cells["StudentID"].Value.ToString();
                txtName.Text = dataGridView1.Rows[e.RowIndex].Cells["Name"].Value.ToString();
                comboCourse.Text = dataGridView1.Rows[e.RowIndex].Cells["CourseName"].Value.ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(hiddenStudentID.Text))
            {
                MessageBox.Show("Please select a student to update.");
                return;
            }

            string name = txtName.Text.Trim();
            int courseId = Convert.ToInt32(comboCourse.SelectedValue);
            int studentId = Convert.ToInt32(hiddenStudentID.Text);

            using (var conn = DbCon.GetConnection())
            {
                var cmd = new SQLiteCommand("UPDATE Students SET Name=@Name, CourseID=@CourseID WHERE StudentID=@StudentID", conn);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@CourseID", courseId);
                cmd.Parameters.AddWithValue("@StudentID", studentId);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Student updated successfully.");
            LoadStudents();
            ClearFields();
        }

        private void ClearFields()
        {
            txtName.Clear();
            comboCourse.SelectedIndex = -1;
            hiddenStudentID.Text = "";
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }

}

