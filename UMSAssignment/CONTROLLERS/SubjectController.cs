using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMSAssignment.ENUMS;
using UMSAssignment.MODELS;
using UMSAssignment.REPOSITORIE;

namespace UMSAssignment.CONTROLLERS
{
    internal class SubjectController
    {
        public SubjectController() 
        {
        
        }
        public List<Subject> GetAllSubjects()
        {
            var subjects = new List<Subject>();

            try
            {
                using (var conn = DbConfig.GetConnection())
                {
                    var cmd = new SQLiteCommand("SELECT * FROM Subjects", conn);
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        subjects.Add(new Subject
                        {
                            SubjectId = reader.GetInt32(0),
                            SubjectName = reader.GetString(1),
                            CourseId = reader.GetInt32(2) 
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in GetAllSubjects: " + ex.Message);
            }

            return subjects;
        }


        public void AddSubject(Subject subject)
        {
            try
            {
                using (var conn = DbConfig.GetConnection())
                {
                    var command = new SQLiteCommand("INSERT INTO Subjects (Nam, CourseId, SubjectId) VALUES (@Name, @CourseId, @SubjectId)", conn);
                    command.Parameters.AddWithValue("@Name", subject.SubjectName);
                    command.Parameters.AddWithValue("@NIC", subject.CourseId);
                    command.Parameters.AddWithValue("@SubjectId", subject.SubjectId);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in AddSubject: " + ex.Message);
            }
        }
        public void UpdateSubject(Subject subject)
        {
            try
            {
                using (var conn = DbConfig.GetConnection())
                {
                    var command = new SQLiteCommand("UPDATE Subjects SET Name = @Name, CourseId = @CourseId WHERE SubjectId = @SubjectId", conn);
                    command.Parameters.AddWithValue("@Name", subject.SubjectName);
                    command.Parameters.AddWithValue("@NIC", subject.CourseId);
                    command.Parameters.AddWithValue("@SubjectId", subject.SubjectId);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in UpdateSubject: " + ex.Message);
            }
        }
        public void DeleteSubject(int subjectId)
        {
            try
            {
                using (var conn = DbConfig.GetConnection())
                {
                    var command = new SQLiteCommand("DELETE FROM Subjects WHERE SubjectId = @SubjectId", conn);
                    command.Parameters.AddWithValue("@SubjectId", subjectId);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in DeleteSubject: " + ex.Message);
            }
        }


        public Subject GetSubjectById(int subjectId)
        {
            try
            {
                using (var conn = DbConfig.GetConnection())
                {
                    var cmd = new SQLiteCommand("SELECT * FROM Subjects WHERE Id = @Id", conn);
                    cmd.Parameters.AddWithValue("@Id", subjectId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Subject
                            {
                                SubjectId = reader.GetInt32(0),
                                SubjectName = reader.GetString(1),
                                CourseId = reader.GetInt32(2),
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in GetSubjectById: " + ex.Message);
            }

            return null;
        }
    }
}
