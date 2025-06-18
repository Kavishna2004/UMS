using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMSAssignment.ENUMS;
using UMSAssignment.MODELS;
using UMSAssignment.REPOSITORIE;

namespace UMSAssignment.CONTROLLERS
{
    internal class StudentController
    {
        public StudentController()
        {
        
        }
        public List<Student> GetAllStudents()
        {
            var students = new List<Student>();

            try
            {
                using (var conn = DbConfig.GetConnection())
                {
                    var cmd = new SQLiteCommand(@"
                        SELECT st.Id, st.Name, st.NIC, st.Gender, st.Address, st.Email, st.Phone, st.DOB, st.UserId, st.CourseId, Cou.Name AS CourseName
                        FROM Student St
                        LEFT JOIN Course Cou ON St.CourseId = Cou.Id", conn);

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Student student = new Student
                        {
                            Id = reader.GetInt32(0),
                            StudentName = reader.GetString(1),
                            StudentNIC = reader.GetString(2),
                            StudentGender = (UserGender)reader.GetInt32(3),
                            StudentAddress = reader.GetString(4),
                            StudentEmail = reader.GetString(5),
                            StudentPhone = reader.GetString(6),
                            DOB = reader.GetString(7),
                            CourseId = (UserCourse)reader.GetInt32(8),
                            GroupId = reader.GetInt32(9),
                            UserId = reader.GetInt32(11),
                        };
                        students.Add(student);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in GetAllStudents: " + ex.Message);
            }

            return students;
        }

        public void AddStudent(Student student)
        {
            try
            {
                using (var conn = DbConfig.GetConnection())
                {
                    var command = new SQLiteCommand("INSERT INTO Students (Name, Address, NIC, Gender, Email, Phone, DOB, CourseId) VALUES (@Name, @Address, @NIC, @Gender, @Email, @Phone, @DOB, @CourseId)", conn);
                    command.Parameters.AddWithValue("@Name", student.StudentName);
                    command.Parameters.AddWithValue("@NIC", student.StudentNIC);
                    command.Parameters.AddWithValue("@Gender", student.StudentGender);
                    command.Parameters.AddWithValue("@Address", student.StudentAddress);
                    command.Parameters.AddWithValue("@Email", student.StudentEmail);
                    command.Parameters.AddWithValue("@Phone", student.StudentPhone);
                    command.Parameters.AddWithValue("@DOB", student.DOB);
                    command.Parameters.AddWithValue("@CourseId", student.CourseId);
                    command.Parameters.AddWithValue("@GroupId", student.GroupId);
                    command.Parameters.AddWithValue("@UserId", student.UserId);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in AddStudent: " + ex.Message);
            }
        }
        public void UpdateStudent(Student student)
        {
            try
            {
                using (var conn = DbConfig.GetConnection())
                {
                    var command = new SQLiteCommand("UPDATE Students SET Name = @Name, Address = @Address, NIC = @NIC, Gender = @Gender, Email = @Email, Phone = @Phone, DOB = @DOB, CourseId = @CourseId WHERE Id = @Id", conn);
                    command.Parameters.AddWithValue("@Name", student.StudentName);
                    command.Parameters.AddWithValue("@NIC", student.StudentNIC);
                    command.Parameters.AddWithValue("@Gender", student.StudentGender);
                    command.Parameters.AddWithValue("@Address", student.StudentAddress);
                    command.Parameters.AddWithValue("@Email", student.StudentEmail);
                    command.Parameters.AddWithValue("@Phone", student.StudentPhone);
                    command.Parameters.AddWithValue("@DOB", student.DOB);
                    command.Parameters.AddWithValue("@CourseId", student.Id);
                    command.Parameters.AddWithValue("@GroupId", student.Id);
                    command.Parameters.AddWithValue("@Id", student.Id);
                    command.Parameters.AddWithValue("@UserId", student.Id);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in UpdateStudent: " + ex.Message);
            }
        }
        public void DeleteStudent(int Id)
        {
            try
            {
                using (var conn = DbConfig.GetConnection())
                {
                    var command = new SQLiteCommand("DELETE FROM Students WHERE Id = @Id", conn);
                    command.Parameters.AddWithValue("@Id", Id);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in DeleteStudent: " + ex.Message);
            }
        }


        public Student GetStudentById(int Id)
        {
            try
            {
                using (var conn = DbConfig.GetConnection())
                {
                    var cmd = new SQLiteCommand("SELECT * FROM Students WHERE Id = @Id", conn);
                    cmd.Parameters.AddWithValue("@Id", Id);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Student
                            {
                                Id = reader.GetInt32(0),
                                StudentName = reader.GetString(1),
                                StudentNIC = reader.GetString(2),
                                StudentGender = (UserGender)reader.GetInt32(3),
                                StudentAddress = reader.GetString(4),
                                StudentEmail = reader.GetString(5),
                                StudentPhone = reader.GetString(6),
                                DOB = reader.GetString(7),
                                //CourseId = (UserCourse)reader.GetInt32(8),
                                //GroupId = reader.GetInt32(9),
                                //UserId = reader.GetInt32(11),
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in GetStudentById: " + ex.Message);
            }

            return null;
        }
    }
}
