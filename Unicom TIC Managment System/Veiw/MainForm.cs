using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Unicom_TIC_Managment_System.Veiw
{
    public partial class UserView : Form
    {
        public UserView()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SubjectForm subjectForm = new SubjectForm();
            subjectForm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StudentForm studentForm = new StudentForm();
            studentForm.ShowDialog();
        }

        private void butcs_Click(object sender, EventArgs e)
        {
            CourseForm courseForm = new CourseForm();
            courseForm.ShowDialog();

        }

        private void btnmk_Click(object sender, EventArgs e)
        {
            MarksForm marksForm = new MarksForm();
            marksForm.ShowDialog();
        }

        private void btnem_Click(object sender, EventArgs e)
        {
            Examform examForm = new Examform();
            examForm.ShowDialog();
        }

        private void btntm_Click(object sender, EventArgs e)
        {
            TimeTablesform timetableForm = new TimeTablesform();
            timetableForm.ShowDialog();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string role = comboRole.SelectedItem?.ToString();
            MessageBox.Show("You selected: " + role);



            if (role == "Admin")
            {
                // Open Admin Panel
            }
            else if (role == "Staff")
            {
                // Open Staff Panel
            }
            else if (role == "Lecturer")
            {
                // Open Lecturer Panel
            }
            else if (role == "Student") ;

            if (role == "Student")
            {
                // Only allow view access to Student, Course, Subject, Timetable, Marks
                butcs.Visible = true;  // Course
                btnst.Visible = true;  // Subject
                btnsub.Visible = true;  // Student
                btnmk.Visible = false; // Exam - HIDE
                btnem.Visible = true;  // Marks
                btntm.Visible = true;  // Timetable
                button7.Visible = false; // Admin-only or other
            }
            else
            {
                // If not student, show all buttons (or based on each role)
                butcs.Visible = true;
                btnst.Visible = true;
                btnsub.Visible = true;
                btnmk.Visible = true;
                btnem.Visible = true;
                btntm.Visible = true;
                button7.Visible = true;
            }
            if (role == "Lecture")
            {
                butcs.Visible = false;
                btnst.Visible = false;
                btnsub.Visible = false;
                btnmk.Visible = true;
                btnem.Visible = false;
                btntm.Visible = false;
                button7.Visible = true;
            }
            else
            {
                butcs.Visible = true;
                btnst.Visible = true;
                btnsub.Visible = true;
                btnmk.Visible = true;
                btnem.Visible = true;
                btntm.Visible = true;
                button7.Visible = true;
            }
        }
            
              
        private void UserView_Load(object sender, EventArgs e)
        {
            comboRole.Items.Clear();
            comboRole.Items.Add("Admin");
            comboRole.Items.Add("Staff");
            comboRole.Items.Add("Lecturer");
            comboRole.Items.Add("Student");
            comboRole.SelectedIndex = 0;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to logout?", "Confirm Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Hide(); // Hide the main form
                LoginForm loginForm = new LoginForm(); // Replace with your actual login form class name
                loginForm.Show();
            }
        }
    }
}

