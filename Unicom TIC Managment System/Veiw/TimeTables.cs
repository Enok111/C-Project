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
    public partial class TimeTablesform : Form
    {
        SQLiteConnection con = new SQLiteConnection("Data Source=unicom.db;Version=3;");
        SQLiteCommand cmd;
        SQLiteDataAdapter da;
        DataTable dt;

        public TimeTablesform()
        {
            InitializeComponent();
            LoadSubjects();
            LoadRooms();
            LoadTimetables();
        }

        private void TimeTablesform_Load(object sender, EventArgs e)
        {

        }

        private void LoadSubjects()
        {
            try
            {
                con.Open();
                cmd = new SQLiteCommand("SELECT SubjectID, SubjectName FROM Subjects", con);
                SQLiteDataReader dr = cmd.ExecuteReader();
                DataTable subjDt = new DataTable();
                subjDt.Load(dr);

                cmbSubject.DisplayMember = "SubjectName";
                cmbSubject.ValueMember = "SubjectID";
                cmbSubject.DataSource = subjDt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading subjects: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
            


        private void LoadRooms()
        {
            con.Open();
            cmd = new SQLiteCommand("SELECT RoomID, RoomName FROM Rooms", con);
            SQLiteDataReader dr = cmd.ExecuteReader();
            DataTable roomDt = new DataTable();
            roomDt.Load(dr);
            cmbRoom.DisplayMember = "RoomName";
            cmbRoom.ValueMember = "RoomID";
            cmbRoom.DataSource = roomDt;
            con.Close();
        }

        private void LoadTimetables()
        {
            con.Open();
            string query = @"
                SELECT t.TimetableID, s.SubjectName, r.RoomName, t.TimeSlot 
                FROM Timetables t
                JOIN Subjects s ON t.SubjectID = s.SubjectID
                JOIN Rooms r ON t.RoomID = r.RoomID";
            da = new SQLiteDataAdapter(query, con);
            dt = new DataTable();
            //da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd = new SQLiteCommand("INSERT INTO Timetables (SubjectID, TimeSlot, RoomID) VALUES (@subjectID, @timeslot, @roomID)", con);
            cmd.Parameters.AddWithValue("@subjectID", cmbSubject.SelectedValue);
            cmd.Parameters.AddWithValue("@timeslot", textBox1.Text);
            cmd.Parameters.AddWithValue("@roomID", cmbRoom.SelectedValue);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Timetable Added Successfully");
            LoadTimetables();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["TimetableID"].Value);
                con.Open();
                cmd = new SQLiteCommand("UPDATE Timetables SET SubjectID=@subjectID, TimeSlot=@timeslot, RoomID=@roomID WHERE TimetableID=@id", con);
                cmd.Parameters.AddWithValue("@subjectID", cmbSubject.SelectedValue);
                cmd.Parameters.AddWithValue("@timeslot", textBox1.Text);
                cmd.Parameters.AddWithValue("@roomID", cmbRoom.SelectedValue);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Timetable Updated Successfully");
                LoadTimetables();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["TimetableID"].Value);
                con.Open();
                cmd = new SQLiteCommand("DELETE FROM Timetables WHERE TimetableID=@id", con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Timetable Deleted Successfully");
                LoadTimetables();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                cmbSubject.Text = dataGridView1.CurrentRow.Cells["SubjectName"].Value.ToString();
                cmbRoom.Text = dataGridView1.CurrentRow.Cells["RoomName"].Value.ToString();
                textBox1.Text = dataGridView1.CurrentRow.Cells["TimeSlot"].Value.ToString();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            UserView mainForm = new UserView();
            mainForm.Show(); // show main form again
        }
    }
}
