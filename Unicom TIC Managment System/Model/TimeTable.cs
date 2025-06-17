using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Unicom_TIC_Managment_System.Model
{
    internal class TimeTable
    {
        public int TimeTableId { get; set; }
        public int SubjectId { get; set; }
        public int TimeSlot {  get; set; }
    }
}
//private void OnLogin(object sender, EventArgs e)
//{

//    string username = userNameTxt.Text.Trim();
//    string password = passwordTxt.Text;

//    // Hardcoded credentials
//    string validUsername = "admin";
//    string validPassword = "12345";

//    if (username == validUsername && password == validPassword)
//    {
//        // Success — open MainForm
//        UserView userView = new UserView();
//        userView.Show();
//        this.Hide();
//    }
//    else
//    {
//        Credentials credentials = new Credentials();
//        credentials.Username = username;
//        credentials.Password = password;
//        var result = _userController.Login(credentials);
//        if (result)
//        {
//            UserView userView = new UserView();
//            userView.Show();
//            this.Hide();
//        }
//        else
//        {
//            MessageBox.Show("Invalid username or password", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

//            // Optionally clear fields
//            userNameTxt.Clear();
//            userNameTxt.Focus();
//        }
//    }

//}
//public bool Login(Credentials credentials)
//{
//    try
//    {
//        var user = new AppUser();
//        using (var conn = new SQLiteConnection(ConnectionString))
//        {
//            conn.Open();

//            string query = "SELECT Username, Password  FROM Users WHERE Username = @Username";

//            using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
//            {

//                cmd.Parameters.AddWithValue("@Username", credentials.Username);
//                cmd.Parameters.AddWithValue("@Password", credentials.Password);

//                SQLiteDataReader reader = cmd.ExecuteReader();
//                while (reader.Read())
//                {

//                    user.Username = reader["Username"].ToString();
//                    user.Password = reader["Password"].ToString();
//                }
//            }
//            if (user.Password == credentials.Password)
//            {
//                return true;
//            }
//            else
//            {
//                return false;
//            }
//        };
//    }
//    catch (Exception ex)
//    {
//        return false;
//    }

//}
//    }