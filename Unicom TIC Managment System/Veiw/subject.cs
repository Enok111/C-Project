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
using Unicom_TIC_Managment_System.Reposteries;
using Unicom_TIC_Managment_System.Model;

namespace Unicom_TIC_Managment_System.Veiw
{
    public partial class SubjectForm : Form
    {
        SQLiteConnection conn = new SQLiteConnection("Data Source=unicom.db;Version=3;");
        SQLiteCommand cmd;
        SQLiteDataAdapter adapter;
        DataTable dt = new DataTable();

        public SubjectForm()
        {
            InitializeComponent();
            LoadCourses();            
            LoadSubjects();
        }

        private void SubjectForm_Load(object sender, EventArgs e)
        {

        }

        void LoadCourses()
        {
            comboCourse.Items.Clear();
            using (var conn = DbCon.GetConnection())
            {
                var cmd = new SQLiteCommand("SELECT CourseID, CourseName FROM Courses", conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    comboCourse.Items.Add(new ComboBoxItem(reader["CourseName"].ToString(), reader["CourseID"].ToString()));
                }
            }
        }

        void LoadSubjects()
        {
            dt.Clear();
            conn.Open();
            adapter = new SQLiteDataAdapter("SELECT * FROM Subjects", conn);
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        void ClearFields()
        {
            txtSubjectName.Clear();
            comboCourse.SelectedIndex = -1;
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtSubjectName.Text == "" || comboCourse.Text == "" )
            {
                MessageBox.Show("Please fill all fields.");
                return;
            }

            conn.Open();
            cmd = new SQLiteCommand("INSERT INTO Subjects (SubjectName,Course) VALUES (@Name, @Course )", conn);
            cmd.Parameters.AddWithValue("@Name", txtSubjectName.Text);
            cmd.Parameters.AddWithValue("@Course", comboCourse.Text);          
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Subject Added!");
            LoadSubjects();
            ClearFields();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Please select a subject to update.");
                return;
            }

            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["SubjectID"].Value);
            conn.Open();
            cmd = new SQLiteCommand("UPDATE Subjects SET SubjectName=@Name, Course=@Course,  WHERE SubjectID=@ID", conn);
            cmd.Parameters.AddWithValue("@Name", txtSubjectName.Text);
            cmd.Parameters.AddWithValue("@Course", comboCourse.Text);            
            cmd.Parameters.AddWithValue("@ID", id);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Subject Updated!");
            LoadSubjects();
            ClearFields();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Please select a subject to delete.");
                return;
            }

            //int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["SubjectID"].Value);
            conn.Open();
            cmd = new SQLiteCommand("DELETE FROM Subjects WHERE SubjectID=@ID", conn);
           // cmd.Parameters.AddWithValue("@ID", id);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Subject Deleted!");
            LoadSubjects();
            ClearFields();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                txtSubjectName.Text = row.Cells["SubjectName"].Value.ToString();
                comboCourse.Text = row.Cells["Course"].Value.ToString();
                txtSubjectId.Text = row.Cells["Id"].Value.ToString();
            }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboCourse_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            UserView mainForm = new UserView();
            mainForm.Show();
        }
    }
}
