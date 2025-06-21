using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMSAssignment.MODELS;
using UMSAssignment.REPOSITORIE;

namespace UMSAssignment.CONTROLLERS
{
    internal class ExamController
    {
        public ExamController()
        {

        }
        public List<Exam> GetAllExam()
        {
            var exams = new List<Exam>();

            try
            {
                using (var conn = DbConfig.GetConnection())
                {
                    var cmd = new SQLiteCommand("SELECT * FROM Exams", conn);
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Exam exam = new Exam
                        {
                            ExamId = reader.GetInt32(0),
                            ExamName = reader.GetString(1),
                            SubjectId = reader.GetInt32(2),
                        };
                        exams.Add(exam);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in GetAllExam: " + ex.Message);
            }

            return exams;
        }
        public void AddExam(Exam exam)
        {
            try
            {
                using (var conn = DbConfig.GetConnection())
                {
                    var cmd = new SQLiteCommand("INSERT INTO Exams (ExamName, SubjectId) VALUES (@Name, @Id)", conn);
                    cmd.Parameters.AddWithValue("@Name", exam.ExamName);
                    cmd.Parameters.AddWithValue("@SubjectId", exam.ExamId);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in AddExam: " + ex.Message);
            }
        }

        public void UpdateExam(Exam exam)
        {
            try
            {
                using (var conn = DbConfig.GetConnection())
                {
                    var cmd = new SQLiteCommand("UPDATE Exams SET ExamName = @Name, SubjectId = @SubjectId WHERE Id = @Id", conn);
                    cmd.Parameters.AddWithValue("@Name", exam.ExamName);
                    cmd.Parameters.AddWithValue("@SubjectId", exam.SubjectId);
                    cmd.Parameters.AddWithValue("@Id", exam.ExamId);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in UpdateExam: " + ex.Message);
            }
        }
        public void DeleteExam(int Id)
        {
            try
            {
                using (var conn = DbConfig.GetConnection())
                {
                    var command = new SQLiteCommand("DELETE FROM Exams WHERE ExamId = @Id", conn);
                    command.Parameters.AddWithValue("@Id", Id);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in DeleteExam: " + ex.Message);
            }
        }

    }
}