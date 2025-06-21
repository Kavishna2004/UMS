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
        public List<Course> GetAllCourses()
        {
            var courses = new List<Course>();

            try
            {
                using (var conn = DbConfig.GetConnection())
                {
                    var cmd = new SQLiteCommand("SELECT * FROM Courses", conn);
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        courses.Add(new Course
                        {
                            CourseId = reader.GetInt32(0),
                            CourseName = reader.GetString(1),
                            
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in GetAllcourse: " + ex.Message);
            }

            return courses;
        }
        public void AddCourse(Course course)
        {
            try
            {
                string query = "INSERT INTO Courses(CourseName) VALUES (@Name)";
                using (var conn = DbConfig.GetConnection())
                {
                    var cmd = new SQLiteCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Name", course.CourseName);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in AddCourse: " + ex.Message);
            }
        }


        public void UpdateCourse(Course course)
        {
            try
            {
                using (var conn = DbConfig.GetConnection())
                {
                    var cmd = new SQLiteCommand("UPDATE Courses SET CourseName = @CourseName WHERE CourseId = @CourseId", conn);
                    cmd.Parameters.AddWithValue("@CourseName", course.CourseName);
                    cmd.Parameters.AddWithValue("@CourseId", course.CourseId);
                    cmd.ExecuteNonQuery ();

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in UpdateCourse: " + ex.Message);
            }
        }
        public void DeleteCourse(int CourseId)
        {
            try
            {
                using (var conn = DbConfig.GetConnection())
                {
                    var command = new SQLiteCommand("DELETE FROM Courses WHERE CourseId = @Id", conn);
                    command.Parameters.AddWithValue("@Id", CourseId);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in DeleteCourse: " + ex.Message);
            }
        }

        public Course GetCourseById(int Id)
        {
            try
            {
                using (var conn = DbConfig.GetConnection())
                {
                    var cmd = new SQLiteCommand("SELECT * FROM Courses WHERE CourseId = @Id", conn);
                    cmd.Parameters.AddWithValue("@Id", Id);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Course
                            {
                                CourseId = reader.GetInt32(0),
                                CourseName = reader.GetString(1),
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in GetCourseyId: " + ex.Message);
            }

            return null;
        }
    }
}
