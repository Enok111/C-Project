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
using Unicom_TIC_Managment_System.Model;
using Unicom_TIC_Managment_System.Reposteries;

namespace Unicom_TIC_Managment_System.Veiw
{
    public partial class Examform : Form
    {
        public Examform()
        {
            InitializeComponent();
        }

        private void Exam_Load(object sender, EventArgs e)
        {
            LoadSubjects();
            LoadExams();

        }

        private void LoadSubjects()
        {
            comboSubject.Items.Clear();
            using (var conn = DbCon.GetConnection())
            {
                var cmd = new SQLiteCommand("SELECT SubjectID, SubjectName FROM Subjects", conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    comboSubject.Items.Add(new ComboBoxItem(reader["SubjectName"].ToString(), reader["SubjectID"].ToString()));
                }
            }
        }

        private void LoadExams()
        {
            dgvExams.Rows.Clear();
            using (var conn = DbCon.GetConnection())
            {
                var cmd = new SQLiteCommand(@"SELECT Exams.ExamID, Exams.ExamName, Subjects.SubjectName, Exams.ExamDate 
                                              FROM Exams 
                                              JOIN Subjects ON Exams.SubjectID = Subjects.SubjectID", conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    dgvExams.Rows.Add(
                        reader["ExamID"],
                        reader["ExamName"],
                        reader["SubjectName"],
                        reader["ExamDate"]
                    );
                }
            }
        }

        private void ClearFields()
        {
            txtExamName.Clear();
            comboSubject.SelectedIndex = -1;
            dateExam.Value = DateTime.Today;
            lblExamID.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtExamName.Text.Trim() == "" || comboSubject.SelectedItem == null)
            {
                MessageBox.Show("Please enter exam name and select subject.");
                return;
            }

            var subject = (ComboBoxItem)comboSubject.SelectedItem;
            using (var conn = DbCon.GetConnection())
            {
                var cmd = new SQLiteCommand("INSERT INTO Exams (ExamName, SubjectID, ExamDate) VALUES (@name, @subjectId, @examDate)", conn);
                cmd.Parameters.AddWithValue("@name", txtExamName.Text.Trim());
                cmd.Parameters.AddWithValue("@subjectId", subject.Value);
                cmd.Parameters.AddWithValue("@examDate", dateExam.Value.ToString("yyyy-MM-dd"));
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Exam added successfully.");
            ClearFields();
            LoadExams();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (lblExamID.Text == "") return;

            var subject = (ComboBoxItem)comboSubject.SelectedItem;

            using (var conn = DbCon.GetConnection())
            {
                var cmd = new SQLiteCommand("UPDATE Exams SET ExamName = @name, SubjectID = @subjectId, ExamDate = @examDate WHERE ExamID = @id", conn);
                cmd.Parameters.AddWithValue("@name", txtExamName.Text.Trim());
                cmd.Parameters.AddWithValue("@subjectId", subject.Value);
                cmd.Parameters.AddWithValue("@examDate", dateExam.Value.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@id", lblExamID.Text);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Exam updated.");
            ClearFields();
            LoadExams();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (lblExamID.Text == "") return;

            var subject = (ComboBoxItem)comboSubject.SelectedItem;

            using (var conn = DbCon.GetConnection())
            {
                var cmd = new SQLiteCommand("UPDATE Exams SET ExamName = @name, SubjectID = @subjectId, ExamDate = @examDate WHERE ExamID = @id", conn);
                cmd.Parameters.AddWithValue("@name", txtExamName.Text.Trim());
                cmd.Parameters.AddWithValue("@subjectId", subject.Value);
                cmd.Parameters.AddWithValue("@examDate", dateExam.Value.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@id", lblExamID.Text);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Exam updated.");
            ClearFields();
            LoadExams();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (lblExamID.Text == "") return;

            using (var conn = DbCon.GetConnection())
            {
                var cmd = new SQLiteCommand("DELETE FROM Exams WHERE ExamID = @id", conn);
                cmd.Parameters.AddWithValue("@id", lblExamID.Text);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Exam deleted.");
            ClearFields();
            LoadExams();
        }

        private void dgvExams_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvExams.Rows[e.RowIndex];
                lblExamID.Text = row.Cells[0].Value.ToString();
                txtExamName.Text = row.Cells[1].Value.ToString();
                comboSubject.Text = row.Cells[2].Value.ToString();
                dateExam.Value = DateTime.Parse(row.Cells[3].Value.ToString());
            }
        }
    }
}
