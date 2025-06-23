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
    internal class SubjectController
    {
        private List<Subject> subjects = new List<Subject>();
        private int nextId = 1;

        public string AddSubject(Subject subject)
        {
            try
            {
                using (var conn = DbConfig.GetConnection()) // 👉 connectionString இல்ல, direct GetConnection
                {
                    string query = "INSERT INTO Subjects (SubjectName, CourseId) VALUES (@name, @courseId)";
                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", subject.SubjectName.ToString()); // enum → string
                        cmd.Parameters.AddWithValue("@courseId", subject.CourseId);
                        cmd.ExecuteNonQuery();
                    }
                }
                return "Subject added successfully.";
            }
            catch (Exception ex)
            {
                return $"Error while adding subject: {ex.Message}";
            }
        }
        public string UpdateSubject(Subject subject)
        {
            try
            {
                using (var conn = DbConfig.GetConnection())
                {
                    string query = "UPDATE Subjects SET SubjectName = @name, CourseId = @courseId WHERE SubjectId = @id";
                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", subject.SubjectName.ToString());
                        cmd.Parameters.AddWithValue("@courseId", subject.CourseId);
                        cmd.Parameters.AddWithValue("@id", subject.SubjectId);
                        cmd.ExecuteNonQuery();
                    }
                }
                return "Subject updated successfully.";
            }
            catch (Exception ex)
            {
                return $"Error while updating subject: {ex.Message}";
            }
        }
        public string DeleteSubject(int id)
        {
            try
            {
                using (var conn = DbConfig.GetConnection())
                {
                    string query = "DELETE FROM Subjects WHERE SubjectId = @id";
                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                }
                return "Subject deleted successfully.";
            }
            catch (Exception ex)
            {
                return $"Error while deleting subject: {ex.Message}";
            }
        }
        public Subject GetSubjectById(int id)
        {
            try
            {
                using (var conn = DbConfig.GetConnection())
                {
                    string query = "SELECT SubjectId, SubjectName, CourseId FROM Subjects WHERE SubjectId = @id";
                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new Subject
                                {
                                    SubjectId = reader.GetInt32(0),
                                    SubjectName = (UserSubject)Enum.Parse(typeof(UserSubject), reader.GetString(1)),
                                    CourseId = reader.GetInt32(2)
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("DB Fetch Error: " + ex.Message);
            }

            return null;
        }

        public List<Subject> GetAllSubjects()
        {
            List<Subject> subjectList = new List<Subject>();

            try
            {
                using (var conn = DbConfig.GetConnection())
                {
                    string query = "SELECT SubjectId, SubjectName, CourseId FROM Subjects";
                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                subjectList.Add(new Subject
                                {
                                    SubjectId = reader.GetInt32(0),
                                    SubjectName = (UserSubject)Enum.Parse(typeof(UserSubject), reader.GetString(1)),
                                    CourseId = reader.GetInt32(2)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("DB Read Error: " + ex.Message);
            }

            return subjectList;
        }
        public List<Subject> SearchSubject(string keyword)
        {
            var list = new List<Subject>();
            try
            {
                using (var conn = DbConfig.GetConnection())
                {
                    string query = @"SELECT * FROM Subjects 
                             WHERE SubjectName LIKE @keyword OR SubjectNIC LIKE @keyword";
                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                list.Add(new Subject
                                {
                                    SubjectId = reader.GetInt32(0),
                                    SubjectName = (UserSubject)Enum.Parse(typeof(UserSubject), reader.GetString(1)),
                                    CourseId = reader.GetInt32(2)
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
