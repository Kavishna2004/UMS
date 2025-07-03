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
    internal class ExamController
    {
        public string AddExam(Exam exam)
        {
            try
            {
                using (var conn = DbConfig.GetConnection())
                {
                    string query = @"INSERT INTO Exams (ExamName, SubjectId) VALUES (@ExamName, @SubjectId)";
                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ExamName", exam.ExamName.ToString());
                        cmd.Parameters.AddWithValue("@SubjectId", exam.SubjectId.ToString());
                        cmd.ExecuteNonQuery();
                    }
                    return " Exam added successfully!";
                }
            }
            catch (Exception ex)
            {
                return " Failed to add exam: " + ex.Message;
            }
        }

        public string UpdateExam(Exam exam)
        {
            try
            {
                using (var conn = DbConfig.GetConnection())
                {
                    string query = @"UPDATE Exams SET ExamName=@ExamName, SubjectId=@SubjectId WHERE ExamId=@ExamId";
                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ExamName", exam.ExamName.ToString());
                        cmd.Parameters.AddWithValue("@SubjectID", exam.SubjectId.ToString());
                        cmd.Parameters.AddWithValue("@ExamId", exam.ExamId);
                        cmd.ExecuteNonQuery();
                    }
                    return "Exam updated.";
                }
            }
            catch (Exception ex)
            {
                return " Update failed: " + ex.Message;
            }
        }

        public string DeleteExam(int id)
        {
            try
            {
                using (var conn = DbConfig.GetConnection())
                {
                    string query = "DELETE FROM Exams WHERE ExamId=@ExamId";
                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ExamId", id);
                        cmd.ExecuteNonQuery();
                    }
                    return " Exam deleted.";
                }
            }
            catch (Exception ex)
            {
                return " Delete failed: " + ex.Message;
            }
        }

        public List<Exam> GetAllExams()
        {
            var exams = new List<Exam>();
            try
            {
                using (var conn = DbConfig.GetConnection())
                {
                    string query = "SELECT * FROM Exams";
                    using (var cmd = new SQLiteCommand(query, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            exams.Add(new Exam
                            {
                                ExamId = Convert.ToInt32(reader["ExamId"]),
                                ExamName = (UserExam)Enum.Parse(typeof(UserExam), reader["ExamName"].ToString()),
                                SubjectId = (UserSubject)Enum.Parse(typeof(UserSubject), reader["SubjectId"].ToString())

                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Fetch error: " + ex.Message);
            }
            return exams;
        }

        public Exam GetExamById(int id)
        {
            try
            {
                using (var conn = DbConfig.GetConnection())
                {
                    string query = "SELECT * FROM Exams WHERE ExamId = @id";
                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new Exam
                                {
                                    ExamId = Convert.ToInt32(reader["ExamId"]),
                                    ExamName = (UserExam)Enum.Parse(typeof(UserExam), reader["ExamName"].ToString()),
                                    SubjectId = (UserSubject)Enum.Parse(typeof(UserSubject), reader["SubjectId"].ToString())

                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("GetById error: " + ex.Message);
            }
            return null;
        }
    }
}