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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = userNameTxt.Text.Trim();
            string password = passwordTxt.Text;

            // Hardcoded credentials
            string validUsername = "admin";
            string validPassword = "admin12345";

            if (username == validUsername && password == validPassword)
            {
                // Success — open MainForm
                UserView userView = new UserView();
                userView.Show();
                this.Hide();
            }
            else
            {
                username = passwordTxt.Text;
                password = validPassword;
                MessageBox.Show("invalid password");
            }
            
             
            

        }

        private void userNameTxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
