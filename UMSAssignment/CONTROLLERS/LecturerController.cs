using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.MobileControls;
using System.Windows.Forms;
using UMSAssignment.ENUMS;
using UMSAssignment.MODELS;
using UMSAssignment.REPOSITORIE;
using static System.Collections.Specialized.BitVector32;

namespace UMSAssignment.CONTROLLERS
{
    internal class LecturerController
    {
        public LecturerController() 
        {
        
        }
        public List<Lecturer> GetAllLecture()
        {
            var lecturers = new List<Lecturer>();

            try
            {
                using (var conn = DbConfig.GetConnection())
                {
                    var cmd = new SQLiteCommand("SELECT * FROM Lecturers", conn);
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Lecturer lecturer = new Lecturer
                        {
                            LecturerId = reader.GetInt32(0),
                            LecturerName = reader.GetString(1),
                            LecturerNIC = reader.GetString(2),
                            LecturerGender = Enum.TryParse<UserGender>(reader.GetString(4), out var gender) ? gender : UserGender.Male,
                            LecturerAddress = reader.GetString(4),
                            LecturerPhone = reader.GetString(5),
                            LecturerEmail = reader.GetString(6),
                            CourseId = reader.GetInt32(7),
                            TimetableId = reader.GetInt32(8),
                            UserId = reader.GetInt32(9),
                            
                        };
                        lecturers.Add(lecturer);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in GetAllLecture: " + ex.Message);
                throw;
            }

            return lecturers;
        }
        public void AddLecturer(Lecturer lecturer)
        {
            try
            {
                string query= "INSERT INTO Lecturers(LecturerName, LecturerNIC, LecturerGender, LecturerAddress, LecturerPhone, LecturerEmail, CourseId, TimetableId, UserId)" +
                    " VALUES (@Name, @NIC, @Gender, @Address, @Phone, @Email, @CourseId, @TimetableId, @UserId)";
                using (var conn = DbConfig.GetConnection())
                {
                    var cmd = new SQLiteCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Name", lecturer.LecturerName);
                    cmd.Parameters.AddWithValue("@NIC", lecturer.LecturerNIC);
                    cmd.Parameters.AddWithValue("@Gender", lecturer.LecturerGender);
                    cmd.Parameters.AddWithValue("@Address", lecturer.LecturerAddress);
                    cmd.Parameters.AddWithValue("@Phone", lecturer.LecturerPhone);
                    cmd.Parameters.AddWithValue("@Email", lecturer.LecturerEmail);
                    cmd.Parameters.AddWithValue("@CourseId", lecturer.CourseId);
                    cmd.Parameters.AddWithValue("@TimetableId", lecturer.TimetableId);
                    cmd.Parameters.AddWithValue("@UserId", lecturer.UserId);
                    cmd.Parameters.AddWithValue("@LecturerId", lecturer.LecturerId);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in AddLecturer: " + ex.Message);
               
            }
        }

        public void UpdateLectuter(Lecturer lecturer)
        {
            try
            {
                using (var conn = DbConfig.GetConnection())
                {
                    var cmd = new SQLiteCommand("UPDATE Lecturers SET LecturerName = @Name, LecturerNIC = @NIC, LecturerGender = @Gender,  LecturerAddress = @Address,LecturerPhone = @Phone," +
                        " LecturerEmail = @Email, CourseId = @CourseId, TimetableId = @TimetableId, UserId = @UserId WHERE LecturerId = @LecturerId", conn);
                    cmd.Parameters.AddWithValue("@Name", lecturer.LecturerName);
                    cmd.Parameters.AddWithValue("@NIC", lecturer.LecturerNIC);
                    cmd.Parameters.AddWithValue("@Gender", lecturer.LecturerGender);
                    cmd.Parameters.AddWithValue("@Address", lecturer.LecturerAddress);
                    cmd.Parameters.AddWithValue("@Phone", lecturer.LecturerPhone);
                    cmd.Parameters.AddWithValue("@Email", lecturer.LecturerEmail);
                    cmd.Parameters.AddWithValue("@CourseId", lecturer.CourseId);
                    cmd.Parameters.AddWithValue("@TimetableId", lecturer.TimetableId);
                    cmd.Parameters.AddWithValue("@UserId", lecturer.UserId);
                    cmd.Parameters.AddWithValue("@LecturerId", lecturer.LecturerId);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                    {
                        MessageBox.Show("Update failed: No matching lecturer found.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in UpdateLectuter: " + ex.Message);
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
                                LecturerId = reader.GetInt32(0),
                                LecturerName = reader.GetString(1),
                                LecturerNIC = reader.GetString(2),
                                LecturerGender = (UserGender)reader.GetInt32(3),
                                LecturerAddress = reader.GetString(4),
                                LecturerPhone = reader.GetString(5),
                                LecturerEmail = reader.GetString(6),
                                CourseId = reader.GetInt32(7),
                                TimetableId = reader.GetInt32(8),
                                UserId = reader.GetInt32(9),
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
