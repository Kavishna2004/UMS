using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.MobileControls;
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
                        lecturers.Add(new Lecturer
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
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in GetAllLecture: " + ex.Message);
            }

            return lecturers;
        }
        public void AddLecturer(Lecturer lecturer)
        {
            try
            {
                using (var conn = DbConfig.GetConnection())
                {
                    var cmd = new SQLiteCommand("INSERT INTO Lecturers(Name, Address, NIC, Gender, Phone, Email, TimetableId, UserId) VALUES (@Name, @Address, @NIC, @Gender, @Phone, @Email, @TimetableId, @UserId)", conn);
                    cmd.Parameters.AddWithValue("@Name", lecturer.LecturerName);
                    cmd.Parameters.AddWithValue("@Address", lecturer.LecturerAddress);  
                    cmd.Parameters.AddWithValue("@NIC", lecturer.LecturerNIC);
                    cmd.Parameters.AddWithValue("@Gender", lecturer.LecturerGender);
                    cmd.Parameters.AddWithValue("@Phone", lecturer.LecturerPhone);
                    cmd.Parameters.AddWithValue("@Email", lecturer.LecturerEmail);
                    cmd.Parameters.AddWithValue("@TimetableId", lecturer.Id);
                    cmd.Parameters.AddWithValue("@UserId", lecturer.Id);
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
                    var cmd = new SQLiteCommand("UPDATE Lecturers SET Name = @Name, Address = @Address, NIC = @NIC, Gender = @Gender, Phone = @Phone, Email = @Email, TimetableId = @TimetableId WHERE LecturerId = @LecturerId", conn);
                    cmd.Parameters.AddWithValue("@Name", lecturer.LecturerName);
                    cmd.Parameters.AddWithValue("@Address", lecturer.LecturerAddress);
                    cmd.Parameters.AddWithValue("@NIC", lecturer.LecturerNIC);
                    cmd.Parameters.AddWithValue("@Gender", lecturer.LecturerGender);
                    cmd.Parameters.AddWithValue("@Phone", lecturer.LecturerPhone);
                    cmd.Parameters.AddWithValue("@Email", lecturer.LecturerEmail);
                    cmd.Parameters.AddWithValue("@TimetableId", lecturer.Id);
                    cmd.Parameters.AddWithValue("@LecturerId", lecturer.Id);
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
