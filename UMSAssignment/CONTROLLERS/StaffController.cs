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
    internal class StaffController
    {
        public StaffController()
        {

        }
        public List<Staff> GetAllStaffs()
        {
            var staffs = new List<Staff>();

            try
            {
                using (var conn = DbConfig.GetConnection())
                {
                    var cmd = new SQLiteCommand(@"SELECT * FROM Staffs", conn);
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Staff staff = new Staff
                        {
                            Id = reader.GetInt32(0),
                            StaffName = reader.GetString(1),
                            StaffNIC = reader.GetString(2),
                            StaffGender = (UserGender)reader.GetInt32(3),
                            StaffAddress = reader.GetString(4),
                            StaffTimeslot = reader.GetInt32(5),
                            CourseId = (UserCourse)reader.GetInt32(6),
                            UserId = reader.GetInt32(7),
                        };
                        staffs.Add(staff);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in GetAllStaffs: " + ex.Message);
            }

            return staffs;
        }
        public void AddStaff(Staff staff)
        {
            try
            {
                using (var conn = DbConfig.GetConnection())
                {
                    var command = new SQLiteCommand("INSERT INTO Staffs (Name, NIC, Gender, Address, Timeslot, CourseId, UserId) VALUES (@Name, @NIC, @Gender, @Address, @Timeslot, @CourseId, @UserId)", conn);
                    command.Parameters.AddWithValue("@Name", staff.StaffName);
                    command.Parameters.AddWithValue("@NIC", staff.StaffNIC);
                    command.Parameters.AddWithValue("@Gender", staff.StaffGender);
                    command.Parameters.AddWithValue("@Address", staff.StaffAddress);  
                    command.Parameters.AddWithValue("@Timeslot", staff.StaffTimeslot);
                    command.Parameters.AddWithValue("@CourseId", staff.Id);
                    command.Parameters.AddWithValue("@UserId", staff.Id);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in AddStaff: " + ex.Message);
            }
        }


        public void UpdateStaff(Staff staff)
        {
            try
            {
                using (var conn = DbConfig.GetConnection())
                {
                    var command = new SQLiteCommand("UPDATE Staffs SET Name = @Name, NIC = @NIC, Gender = @Gender, Address = @Address, Timeslot = @Timeslot, CourseId = @CourseId, UserId = @UserId WHERE Id = @Id", conn);
                    command.Parameters.AddWithValue("@Name", staff.StaffName);
                    command.Parameters.AddWithValue("@NIC", staff.StaffNIC);
                    command.Parameters.AddWithValue("@Gender", staff.StaffGender);
                    command.Parameters.AddWithValue("@Address", staff.StaffAddress);
                    command.Parameters.AddWithValue("@Timeslot", staff.StaffTimeslot);
                    command.Parameters.AddWithValue("@CourseId", staff.Id);
                    command.Parameters.AddWithValue("@UserId", staff.Id);
                    command.Parameters.AddWithValue("@Id", staff.Id);  
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in UpdateStaff: " + ex.Message);
            }
        }
        public void DeleteStudent(int staffId)
        {
            try
            {
                using (var conn = DbConfig.GetConnection())
                {
                    var command = new SQLiteCommand("DELETE FROM Staffs WHERE Id = @Id", conn);
                    command.Parameters.AddWithValue("@Id", staffId);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in DeleteStudent: " + ex.Message);
            }
        }
        public Staff GetStaffById(int staffId)
        {
            try
            {
                using (var conn = DbConfig.GetConnection())
                {
                    var cmd = new SQLiteCommand("SELECT * FROM Staffs WHERE Id = @Id", conn);
                    cmd.Parameters.AddWithValue("@Id", staffId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Staff
                            {
                                Id = reader.GetInt32(0),
                                StaffName = reader.GetString(1),
                                StaffNIC = reader.GetString(2),   
                                StaffGender = (UserGender)reader.GetInt32(3),
                                StaffAddress = reader.GetString(4),
                                StaffTimeslot = reader.GetInt32(5),
                                CourseId = (UserCourse)reader.GetInt32(6),
                                UserId = reader.GetInt32(7),
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in GetStaffById: " + ex.Message);
            }

            return null;
        }
    }
}
