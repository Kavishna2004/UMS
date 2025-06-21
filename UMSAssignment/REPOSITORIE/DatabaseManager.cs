using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using UMSAssignment.MODELS;

namespace UMSAssignment.REPOSITORIE
{
    public static class DatabaseManager
    {
        public static void CreateTables()
        {
            using (var conn = DbConfig.GetConnection())
            {
                string createTableQuery = @"
                    CREATE TABLE IF NOT EXISTS Courses (
                        CourseId INTEGER PRIMARY KEY AUTOINCREMENT,
                        CourseName TEXT NOT NULL
                    );

                    CREATE TABLE IF NOT EXISTS Users(
                        UserId INTEGER PRIMARY KEY AUTOINCREMENT,
                        UserName TEXT NOT NULL,
                        Password TEXT NOT NULL,
                        Role TEXT NOT NULL
                    );

                    CREATE TABLE IF NOT EXISTS Rooms(
                        RoomId INTEGER PRIMARY KEY AUTOINCREMENT,
                        RoomName TEXT NOT NULL,
                        RoomType TEXT NOT NULL
                    );

                    CREATE TABLE IF NOT EXISTS Groups(
                        GroupId INTEGER PRIMARY KEY AUTOINCREMENT,
                        GroupName TEXT NOT NULL
                    );

                    CREATE TABLE IF NOT EXISTS Subjects(
                        SubjectId INTEGER PRIMARY KEY AUTOINCREMENT,
                        SubjectName TEXT NOT NULL,
                        CourseId INTEGER,
                        FOREIGN KEY (CourseId) REFERENCES Courses(CourseId)
                    );

                    CREATE TABLE IF NOT EXISTS Lecturers(
                        LecturerId INTEGER PRIMARY KEY AUTOINCREMENT,
                        LecturerName TEXT NOT NULL,
                        LecturerNIC TEXT NOT NULL,
                        LecturerGender TEXT NOT NULL,
                        LecturerAddress TEXT NOT NULL,
                        LecturerPhone TEXT NOT NULL,
                        LecturerEmail TEXT NOT NULL,
                        CourseId INTEGER,
                        TimetableId INTEGER,
                        UserId INTEGER,
                        FOREIGN KEY (CourseId) REFERENCES Courses(CourseId),
                        FOREIGN KEY (TimetableId) REFERENCES Timetables(TimetableId),
                        FOREIGN KEY (UserId) REFERENCES Users(UserId)
                    );

                    CREATE TABLE IF NOT EXISTS Students(
                        StudentId INTEGER PRIMARY KEY AUTOINCREMENT,
                        StudentName TEXT NOT NULL,
                        StudentAddress TEXT NOT NULL,
                        StudentNIC TEXT NOT NULL,
                        StudentGender TEXT NOT NULL,
                        StudentEmail TEXT NOT NULL,
                        StudentPhone TEXT NOT NULL,
                        StudentDOB TEXT NOT NULL,
                        CourseId INTEGER,
                        GroupId INTEGER,
                        UserId INTEGER,
                        FOREIGN KEY (CourseId) REFERENCES Courses(CourseId),
                        FOREIGN KEY (GroupId) REFERENCES Groups(GroupId),
                        FOREIGN KEY (UserId) REFERENCES Users(UserId)
                    );

                    CREATE TABLE IF NOT EXISTS StudentLectures(
                        StudentId INTEGER,
                        LecturerId INTEGER,
                        PRIMARY KEY (StudentId, LecturerId),
                        FOREIGN KEY (StudentId) REFERENCES Students(StudentId),
                        FOREIGN KEY (LecturerId) REFERENCES Lecturers(LecturerId)
                    );

                    CREATE TABLE IF NOT EXISTS SubjectLectures(
                        SubjectId INTEGER,
                        LecturerId INTEGER,
                        PRIMARY KEY (SubjectId, LecturerId),
                        FOREIGN KEY (SubjectId) REFERENCES Subjects(SubjectId),
                        FOREIGN KEY (LecturerId) REFERENCES Lecturers(LecturerId)
                    );

                    CREATE TABLE IF NOT EXISTS CourseLectures(
                        CourseId INTEGER,
                        LecturerId INTEGER,
                        PRIMARY KEY (CourseId, LecturerId),
                        FOREIGN KEY (CourseId) REFERENCES Courses(CourseId),
                        FOREIGN KEY (LecturerId) REFERENCES Lecturers(LecturerId)
                    );

                    CREATE TABLE IF NOT EXISTS Exams(
                        ExamId INTEGER PRIMARY KEY AUTOINCREMENT,
                        ExamName TEXT NOT NULL,
                        SubjectId INTEGER,
                        FOREIGN KEY (SubjectId) REFERENCES Subjects(SubjectId)
                    );

                    CREATE TABLE IF NOT EXISTS TimetableLectures(
                        TimetableId INTEGER,
                        LecturerId INTEGER,
                        PRIMARY KEY (TimetableId, LecturerId),
                        FOREIGN KEY (TimetableId) REFERENCES Timetables(TimetableId),
                        FOREIGN KEY (LecturerId) REFERENCES Lecturers(LecturerId)
                    );

                    CREATE TABLE IF NOT EXISTS ExamLectures(
                        ExamId INTEGER,
                        LecturerId INTEGER,
                        PRIMARY KEY (ExamId, LecturerId),
                        FOREIGN KEY (ExamId) REFERENCES Exams(ExamId),
                        FOREIGN KEY (LecturerId) REFERENCES Lecturers(LecturerId)
                    );

                    CREATE TABLE IF NOT EXISTS Attendances(
                        AttendanceId INTEGER PRIMARY KEY AUTOINCREMENT,
                        Timestamp TEXT NOT NULL,
                        Status TEXT NOT NULL,
                        StudentId INTEGER,
                        TimetableId INTEGER,
                        FOREIGN KEY (StudentId) REFERENCES Students(StudentId),
                        FOREIGN KEY (TimetableId) REFERENCES Timetables(TimetableId)
                    );
                        
                    CREATE TABLE IF NOT EXISTS Timetables (
                        TimetableId INTEGER PRIMARY KEY AUTOINCREMENT,
                        SubjectId INTEGER NOT NULL,
                        RoomId INTEGER NOT NULL,
                        TimeSlot TEXT NOT NULL
                    );

                    CREATE TABLE IF NOT EXISTS Staffs(
                        StaffId INTEGER PRIMARY KEY AUTOINCREMENT,
                        StaffName TEXT NOT NULL,
                        StaffNIC TEXT NOT NULL,
                        StaffGender TEXT NOT NULL,
                        StaffAddress TEXT NOT NULL,
                        StaffTimeslot TEXT NOT NULL,
                        CourseId INTEGER,
                        UserId INTEGER,
                        FOREIGN KEY (CourseId) REFERENCES Courses(CourseId),
                        FOREIGN KEY (UserId) REFERENCES Users(UserId)
                    );
                ";
                using (var cmd = new SQLiteCommand(createTableQuery, conn))
                {
                    cmd.ExecuteNonQuery();
                }

            }
        }
    }
}
