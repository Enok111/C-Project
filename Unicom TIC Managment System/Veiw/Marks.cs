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
    public partial class MarksForm : Form
    {
        SQLiteConnection conn = new SQLiteConnection("Data Source=unicom.db;Version=3;");
        SQLiteCommand cmd;
        SQLiteDataAdapter adapter;
        DataTable dt = new DataTable();

        public MarksForm()
        {
            InitializeComponent();
            LoadStudentIDs();
            LoadExamIDs();
            LoadMarks();
        }

        private void MarksForm_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        void LoadStudentIDs()
        {
            comboStudentID.Items.Clear();
            conn.Open();
            cmd = new SQLiteCommand("SELECT StudentID FROM Students", conn);
            SQLiteDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                comboStudentID.Items.Add(reader["StudentID"].ToString());
            }
            conn.Close();
        }

        void LoadExamIDs()
        {
            comboExamID.Items.Clear();
            conn.Open();
            cmd = new SQLiteCommand("SELECT ExamID FROM Exams", conn);
            SQLiteDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                comboExamID.Items.Add(reader["ExamID"].ToString());
            }
            conn.Close();
        }

        void LoadMarks()
        {
            dt.Clear();
            conn.Open();
            adapter = new SQLiteDataAdapter("SELECT * FROM Marks", conn);
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        void ClearFields()
        {
            comboStudentID.SelectedIndex = -1;
            comboExamID.SelectedIndex = -1;
            txtScore.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboStudentID.Text == "" || comboExamID.Text == "" || txtScore.Text == "")
            {
                MessageBox.Show("Fill all fields!");
                return;
            }

            int score = int.Parse(txtScore.Text);
            if (score < 0 || score > 100)
            {
                MessageBox.Show("Score must be between 0 and 100.");
                return;
            }

            conn.Open();
            cmd = new SQLiteCommand("INSERT INTO Marks(StudentID, ExamID, Score) VALUES (@StudentID, @ExamID, @Score)", conn);
            cmd.Parameters.AddWithValue("@StudentID", comboStudentID.Text);
            cmd.Parameters.AddWithValue("@ExamID", comboExamID.Text);
            cmd.Parameters.AddWithValue("@Score", score);
            cmd.ExecuteNonQuery();
            conn.Close();

            MessageBox.Show("Mark Added!");
            LoadMarks();
            ClearFields();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Select a row to update.");
                return;
            }

            int markID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["MarkID"].Value);
            int score = int.Parse(txtScore.Text);

            if (score < 0 || score > 100)
            {
                MessageBox.Show("Score must be between 0 and 100.");
                return;
            }

            conn.Open();
            cmd = new SQLiteCommand("UPDATE Marks SET StudentID=@StudentID, ExamID=@ExamID, Score=@Score WHERE MarkID=@ID", conn);
            cmd.Parameters.AddWithValue("@StudentID", comboStudentID.Text);
            cmd.Parameters.AddWithValue("@ExamID", comboExamID.Text);
            cmd.Parameters.AddWithValue("@Score", score);
            cmd.Parameters.AddWithValue("@ID", markID);
            cmd.ExecuteNonQuery();
            conn.Close();

            MessageBox.Show("Mark Updated!");
            LoadMarks();
            ClearFields();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Select a row to delete.");
                return;
            }

            int markID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["MarkID"].Value);

            conn.Open();
            cmd = new SQLiteCommand("DELETE FROM Marks WHERE MarkID=@ID", conn);
            cmd.Parameters.AddWithValue("@ID", markID);
            cmd.ExecuteNonQuery();
            conn.Close();

            MessageBox.Show("Mark Deleted!");
            LoadMarks();
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
                comboStudentID.Text = row.Cells["StudentID"].Value.ToString();
                comboExamID.Text = row.Cells["ExamID"].Value.ToString();
                txtScore.Text = row.Cells["Score"].Value.ToString();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide(); // hide the current ExamForm
            UserView mainForm = new UserView(); // create instance of MainForm
            mainForm.Show(); // show the main form again
        }
    }

}
