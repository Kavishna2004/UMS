using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UMSAssignment.ENUMS;
using UMSAssignment.MODELS;
using UMSAssignment.REPOSITORIE;

namespace UMSAssignment.CONTROLLERS
{
    internal class CourseController
    {
        public CourseController() 
        {
        
        }
        public List<Course> GetAllLecture()
        {
            var courses = new List<Course>();

            try
            {
                using (var conn = DbConfig.GetConnection())
                {
                    var cmd = new SQLiteCommand("SELECT * FROM Lecturers", conn);
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        courses.Add(new Course
                        {
                            CourseId = reader.GetInt32(0),
                            CourseName = (UserCourse)reader.GetInt32(1),
                            
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in GetAllLecture: " + ex.Message);
            }

            return courses;
        }
        public void AddLecturer(Course course)
        {
            try
            {
                using (var conn = DbConfig.GetConnection())
                {
                    var cmd = new SQLiteCommand("INSERT INTO Lecturers(Name, CourseId) VALUES (@Name, CourseId)", conn);
                    cmd.Parameters.AddWithValue("@Name", course.CourseName);
                    cmd.Parameters.AddWithValue("@CourseId", course.CourseId);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in AddLecturer: " + ex.Message);
            }
        }

        public void UpdateLectuter(Course course)
        {
            try
            {
                using (var conn = DbConfig.GetConnection())
                {
                    var cmd = new SQLiteCommand("UPDATE Lecturers SET Name = @Name, WHERE CourseId = @CourseId", conn);
                    cmd.Parameters.AddWithValue("@Name", course.CourseName);
                    cmd.Parameters.AddWithValue("@CourseId", course.CourseId);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in UpdateLectuter: " + ex.Message);
            }
        }
        public void DeleteLecturer(int Id)
        {
            try
            {
                using (var conn = DbConfig.GetConnection())
                {
                    var command = new SQLiteCommand("DELETE FROM Lecturers WHERE LecturerId = @Id", conn);
                    command.Parameters.AddWithValue("@Id", Id);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in DeleteLecturer: " + ex.Message);
            }
        }

        public Lecturer GetLecturerById(int Id)
        {
            try
            {
                using (var conn = DbConfig.GetConnection())
                {
                    var cmd = new SQLiteCommand("SELECT * FROM Lecturers WHERE LecturerId = @Id", conn);
                    cmd.Parameters.AddWithValue("@Id", Id);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Lecturer
                            {
                                Id = reader.GetInt32(0),
                                LecturerName = reader.GetString(1),
                                LecturerAddress = reader.GetString(2),
                                LecturerNIC = reader.GetString(3),
                                LecturerGender = (UserGender)reader.GetInt32(4),
                                LecturerPhone = reader.GetString(5),
                                LecturerEmail = reader.GetString(6),
                                TimetableId = reader.GetInt32(7),
                                UserId = reader.GetInt32(8),
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in GetLecturerById: " + ex.Message);
            }

            return null;
        }
    }
}
