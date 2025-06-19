using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unicom_TIC_Managment_System.Reposteries
{
    public static class DatabaseManager
    {
      
        public static void CreateTables()
        {
            using (var conn = DbCon.GetConnection())
            {

                

                    var cmd = conn.CreateCommand();
                    cmd.CommandText = @"CREATE TABLE IF NOT EXISTS Users (
                    UserID INTEGER PRIMARY KEY AUTOINCREMENT,
                    Username TEXT NOT NULL UNIQUE,
                    Password TEXT NOT NULL,
                    Role TEXT NOT NULL
                );
                CREATE TABLE IF NOT EXISTS Courses (
                    CourseID INTEGER PRIMARY KEY AUTOINCREMENT,
                    CourseName TEXT NOT NULL
                );
                CREATE TABLE IF NOT EXISTS Subjects (
                    StudentID INTEGER PRIMARY KEY AUTOINCREMENT,
                    SubjectName TEXT NOT NULL,
                    Course TEXT,
                    FOREIGN KEY(Course) REFERENCES Courses
                );
                CREATE TABLE IF NOT EXISTS Students (
                    StudentID INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name TEXT NOT NULL,
                    CourseID INTEGER,
                    FOREIGN KEY(CourseID) REFERENCES Courses
                );
                CREATE TABLE IF NOT EXISTS Exams (
                    ExamID INTEGER PRIMARY KEY AUTOINCREMENT,
                    ExamName TEXT NOT NULL,
                    SubjectID INTEGER,
                    FOREIGN KEY(SubjectID) REFERENCES Subjects
                );
                CREATE TABLE IF NOT EXISTS Marks (
                    MarkID INTEGER PRIMARY KEY AUTOINCREMENT,
                    StudentID INTEGER,
                    ExamID INTEGER,
                    Score INTEGER,
                    FOREIGN KEY(StudentID) REFERENCES Students,
                    FOREIGN KEY(ExamID) REFERENCES Exams
                );
                CREATE TABLE IF NOT EXISTS Rooms (
                    RoomID INTEGER PRIMARY KEY AUTOINCREMENT,
                    RoomName TEXT NOT NULL,
                    RoomType TEXT NOT NULL
                );
                CREATE TABLE IF NOT EXISTS Timetables (
                    TimetableID INTEGER PRIMARY KEY AUTOINCREMENT,
                    SubjectID INTEGER,
                    TimeSlot TEXT NOT NULL,
                    RoomID INTEGER,
                    FOREIGN KEY(SubjectID) REFERENCES Subjects,
                    FOREIGN KEY(RoomID) REFERENCES Rooms
                );"
                ;
                    cmd.ExecuteNonQuery();
                }

                //    foreach (var command in tableCommands)
                //    {
                //        SQLiteCommand cmd = new SQLiteCommand(command, connection)
                //        cmd.ExecuteNonQuery();
                //    }

                //    // Insert dummy users
                //    SQLiteCommand insertUsers = new SQLiteCommand(
                //        "INSERT INTO Users (Username, Password, Role) VALUES " +
                //        "('admin', 'admin123', 'Admin')," +
                //        "('staff1', 'staff123', 'Staff')," +
                //        "('student1', 'stud123', 'Student')," +
                //        "('lect1', 'lect123', 'Lecturer');", connection);
                //    insertUsers.ExecuteNonQuery();
                //}
            }
        

    }
} 
    


