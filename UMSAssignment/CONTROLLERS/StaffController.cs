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
                    using (var reader = cmd.ExecuteReader()) 
                    {
                        while (reader.Read())
                        {
                            staffs.Add(new Staff
                            {
                                StaffId = reader.GetInt32(0),
                                StaffName = reader.GetString(1),
                                StaffNIC = reader.GetString(2),
                                StaffGender = (UserGender)Enum.Parse(typeof(UserGender), reader.GetString(3)),
                                StaffAddress = reader.GetString(4),
                                Timeslot = (UserTimeslot)Enum.Parse(typeof(UserTimeslot), reader.GetString(5)),
                                CourseId = reader.GetInt32(6),
                                UserId = reader.GetInt32(7)
                            });
                        }
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
                    var command = new SQLiteCommand("INSERT INTO Staffs (StaffName, StaffNIC, StaffGender, StaffAddress, Timeslot, CourseId, UserId)" +
                        " VALUES (@Name, @NIC, @Gender, @Address, @Timeslot, @CourseId, @UserId)", conn);
                    command.Parameters.AddWithValue("@Name", staff.StaffName);
                    command.Parameters.AddWithValue("@NIC", staff.StaffNIC);
                    command.Parameters.AddWithValue("@Gender", staff.StaffGender.ToString());
                    command.Parameters.AddWithValue("@Address", staff.StaffAddress);
                    command.Parameters.AddWithValue("@Timeslot", staff.Timeslot.ToString());
                    command.Parameters.AddWithValue("@CourseId", staff.CourseId);
                    command.Parameters.AddWithValue("@UserId", staff.UserId);
                    int rowsAffected = command.ExecuteNonQuery();
                    Console.WriteLine("Rows Inserted: " + rowsAffected);

                   /* if (rowsAffected == 0)
                    {
                        MessageBox.Show("Insert failed: No rows affected.");
                    }
                    else
                    {
                        MessageBox.Show("Insert success!");
                    }*/
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in AddStaff: " + ex.Message);
                //throw;
            }
        }


        public void UpdateStaff(Staff staff)
        {
            try
            {
                using (var conn = DbConfig.GetConnection())
                {
                    var command = new SQLiteCommand("UPDATE Staffs SET StaffName = @Name, StaffNIC = @NIC, StaffGender = @Gender, StaffAddress = @Address," +
                        " Timeslot = @Timeslot, CourseId = @CourseId, UserId = @UserId WHERE StaffId = @StaffId", conn);
                    command.Parameters.AddWithValue("@Name", staff.StaffName);
                    command.Parameters.AddWithValue("@NIC", staff.StaffNIC);
                    command.Parameters.AddWithValue("@Gender", staff.StaffGender);
                    command.Parameters.AddWithValue("@Address", staff.StaffAddress);
                    command.Parameters.AddWithValue("@Timeslot", staff.Timeslot);
                    command.Parameters.AddWithValue("@CourseId", staff.CourseId);
                    command.Parameters.AddWithValue("@UserId", staff.UserId);
                    command.Parameters.AddWithValue("@StaffId", staff.StaffId);  
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in UpdateStaff: " + ex.Message);
            }
        }
        public void DeleteStaff(int staffId)
        {
            try
            {
                using (var conn = DbConfig.GetConnection())
                {
                    var command = new SQLiteCommand("DELETE FROM Staffs WHERE StaffId = @Id", conn);
                    command.Parameters.AddWithValue("@Id", staffId);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in DeleteStaff: " + ex.Message);
            }
        }
        public Staff GetStaffById(int staffId)
        {
            try
            {
                using (var conn = DbConfig.GetConnection())
                {
                    var cmd = new SQLiteCommand("SELECT * FROM Staffs WHERE StaffId = @Id", conn);
                    cmd.Parameters.AddWithValue("@Id", staffId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Staff
                            {
                                StaffId = reader.GetInt32(0),
                                StaffName = reader.GetString(1),
                                StaffNIC = reader.GetString(2),
                                StaffGender = (UserGender)Enum.Parse(typeof(UserGender), reader.GetString(3)),
                                StaffAddress = reader.GetString(4),
                                Timeslot = (UserTimeslot)Enum.Parse(typeof(UserTimeslot), reader.GetString(5)),
                                CourseId = reader.GetInt32(6),
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
