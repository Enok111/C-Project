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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Unicom_TIC_Managment_System.Veiw
{
    public partial class Examform : Form
    {
        SQLiteConnection conn = new SQLiteConnection("Data Source=unicom.db;Version=3;");
        SQLiteCommand cmd;
        SQLiteDataAdapter adapter;
        DataTable dt = new DataTable();

        public Examform()
        {
            InitializeComponent();
            LoadSubjects();
            LoadExams();

        }

        private void Examform_Load(object sender, EventArgs e)
        {

        }

        void LoadSubjects()
        {
            comboSubject.Items.Clear();
            conn.Open();
            cmd = new SQLiteCommand("SELECT SubjectID FROM Subjects", conn); // Or load SubjectName if you prefer
            SQLiteDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                comboSubject.Items.Add(reader["SubjectID"].ToString());
            }
            conn.Close();
        }

        void LoadExams()
        {
            dt.Clear();
            conn.Open();
            adapter = new SQLiteDataAdapter("SELECT * FROM Exams", conn);
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();

        }

        void ClearFields()
        {
            txtExamName.Clear();
            comboSubject.SelectedIndex = -1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtExamName.Text == "" || comboSubject.Text == "")
            {
                MessageBox.Show("Please fill all fields.");
                return;
            }

            conn.Open();
            cmd = new SQLiteCommand("INSERT INTO Exams(ExamName, SubjectID) VALUES (@Name, @SubjectID)", conn);
            cmd.Parameters.AddWithValue("@Name", txtExamName.Text);
            cmd.Parameters.AddWithValue("@SubjectID", comboSubject.Text);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Exam Added!");
            LoadExams();
            ClearFields();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Please select an exam to update.");
                return;
            }

            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ExamID"].Value);
            conn.Open();
            cmd = new SQLiteCommand("UPDATE Exams SET ExamName=@Name, SubjectID=@SubjectID WHERE ExamID=@ID", conn);
            cmd.Parameters.AddWithValue("@Name", txtExamName.Text);
            cmd.Parameters.AddWithValue("@SubjectID", comboSubject.Text);
            cmd.Parameters.AddWithValue("@ID", id);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Exam Updated!");
            LoadExams();
            ClearFields();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Please select an exam to delete.");
                return;
            }

            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ExamID"].Value);
            conn.Open();
            cmd = new SQLiteCommand("DELETE FROM Exams WHERE ExamID=@ID", conn);
            cmd.Parameters.AddWithValue("@ID", id);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Exam Deleted!");
            LoadExams();
            ClearFields();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                txtExamName.Text = row.Cells["ExamName"].Value.ToString();
                comboSubject.Text = row.Cells["SubjectID"].Value.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide(); // hide the current ExamForm
            UserView mainForm = new UserView(); // create instance of MainForm
            mainForm.Show(); // show the main form again
        }

        private void comboSubject_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboSubject_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    }
}


