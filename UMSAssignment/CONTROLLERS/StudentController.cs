using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
                    var cmd = new SQLiteCommand("SELECT * FROM Students", conn);

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Student student = new Student
                        {
                            StudentId = reader.GetInt32(0),
                            StudentName = reader.GetString(1),
                            StudentAddress = reader.GetString(2),
                            StudentNIC = reader.GetString(3),
                            StudentGender = Enum.TryParse<UserGender>(reader.GetString(4), out var gender) ? gender : UserGender.Male,
                            StudentEmail = reader.GetString(5),
                            StudentPhone = reader.GetString(6),
                            StudentDOB = reader.GetString(7),
                            CourseId = reader.GetInt32(8),
                            GroupId = reader.GetInt32(9),
                            UserId = reader.GetInt32(10),
                        };
                        students.Add(student);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in GetAllStudents: " + ex.Message);
                throw;
            }

            return students;
        }

        public void AddStudent(Student student)
        {
            try
            {
                using (var conn = DbConfig.GetConnection())
                {
                    var command = new SQLiteCommand("INSERT INTO Students (StudentName, StudentAddress, StudentNIC, StudentGender, StudentEmail, StudentPhone, StudentDOB, CourseId, GroupId, UserId) VALUES (@Name, @Address, @NIC, @Gender, @Email, @Phone, @DOB, @CourseId, @GroupId, @UserId)", conn);
                    command.Parameters.AddWithValue("@Name", student.StudentName);
                    command.Parameters.AddWithValue("@Address", student.StudentAddress);
                    command.Parameters.AddWithValue("@NIC", student.StudentNIC);
                    command.Parameters.AddWithValue("@Gender", student.StudentGender.ToString());
                    command.Parameters.AddWithValue("@Email", student.StudentEmail);
                    command.Parameters.AddWithValue("@Phone", student.StudentPhone);
                    command.Parameters.AddWithValue("@DOB", student.StudentDOB);
                    command.Parameters.AddWithValue("@CourseId", student.CourseId);
                    command.Parameters.AddWithValue("@GroupId", student.GroupId);
                    command.Parameters.AddWithValue("@UserId", student.UserId);
                    command.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in AddStudent: " + ex.Message);
                MessageBox.Show("Add Error: " + ex.Message);
            }
        }
        public void UpdateStudent(Student student)
        {
            try
            {
                using (var conn = DbConfig.GetConnection())
                {
                    var command = new SQLiteCommand("UPDATE Students SET StudentName = @Name, StudentAddress = @Address, StudentNIC = @NIC, StudentGender = @Gender, StudentEmail = @Email, StudentPhone = @Phone, StudentDOB = @DOB, CourseId = @CourseId, GroupId = @GroupId, UserId = @UserId WHERE StudentId = @StudentId", conn);
                    command.Parameters.AddWithValue("@Name", student.StudentName);
                    command.Parameters.AddWithValue("@Address", student.StudentAddress);
                    command.Parameters.AddWithValue("@NIC", student.StudentNIC);
                    command.Parameters.AddWithValue("@Gender", student.StudentGender.ToString());
                    command.Parameters.AddWithValue("@Email", student.StudentEmail);
                    command.Parameters.AddWithValue("@Phone", student.StudentPhone);
                    command.Parameters.AddWithValue("@DOB", student.StudentDOB);
                    command.Parameters.AddWithValue("@CourseId", student.CourseId);
                    command.Parameters.AddWithValue("@GroupId", student.GroupId);
                    command.Parameters.AddWithValue("@UserId", student.UserId);
                    command.Parameters.AddWithValue("@StudentId", student.StudentId);
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
                    var command = new SQLiteCommand("DELETE FROM Students WHERE StudentId = @StudentId", conn);
                    command.Parameters.AddWithValue("@StudentId", Id);
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
                    var cmd = new SQLiteCommand("SELECT * FROM Students WHERE StudentId = @StudentId", conn);
                    cmd.Parameters.AddWithValue("@StudentId", Id);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Student
                            {
                                StudentId = reader.GetInt32(0),
                                StudentName = reader.GetString(1),
                                StudentAddress = reader.GetString(2),
                                StudentNIC = reader.GetString(3),
                                StudentGender = Enum.TryParse<UserGender>(reader.GetString(4), out var gender) ? gender : UserGender.Male,
                                StudentEmail = reader.GetString(5),
                                StudentPhone = reader.GetString(6),
                                StudentDOB = reader.GetString(7),
                                CourseId = reader.GetInt32(8),
                                GroupId = reader.GetInt32(9),
                                UserId = reader.GetInt32(10),
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
        public List<Student> SearchStudents(string keyword)
        {
            var list = new List<Student>();
            try
            {
                using (var conn = DbConfig.GetConnection())
                {
                    string query = @"SELECT * FROM Students 
                             WHERE StudentName LIKE @keyword OR StudentNIC LIKE @keyword";
                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                list.Add(new Student
                                {
                                    StudentId = reader.GetInt32(0),
                                    StudentName = reader.GetString(1),
                                    StudentAddress = reader.GetString(2),
                                    StudentNIC = reader.GetString(3),
                                    StudentGender = Enum.TryParse<UserGender>(reader.GetString(4), out var gender) ? gender : UserGender.Male,
                                    StudentEmail = reader.GetString(5),
                                    StudentPhone = reader.GetString(6),
                                    StudentDOB = reader.GetString(7),
                                    CourseId = reader.GetInt32(8),
                                    GroupId = reader.GetInt32(9),
                                    UserId = reader.GetInt32(10),
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Search Error: " + ex.Message);
            }

            return list;
        }
    }
}
