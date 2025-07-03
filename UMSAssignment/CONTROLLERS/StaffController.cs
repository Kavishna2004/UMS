using System;
using System.Collections.Generic;
using System.Data;
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
        public string AddStaff(Staff staff)
        {
            try
            {
                using (var conn = DbConfig.GetConnection())
                {
                    string query = @"INSERT INTO Staffs (StaffName, StaffNIC, StaffGender, StaffAddress, CourseId, UserId) 
                                     VALUES (@name, @nic, @gender, @address, @courseId, @userId)";
                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", staff.StaffName);
                        cmd.Parameters.AddWithValue("@nic", staff.StaffNIC);
                        cmd.Parameters.AddWithValue("@gender", staff.StaffGender.ToString());
                        cmd.Parameters.AddWithValue("@address", staff.StaffAddress);
                        cmd.Parameters.AddWithValue("@courseId", staff.CourseId);
                        cmd.Parameters.AddWithValue("@userId", staff.UserId);

                        int rows = cmd.ExecuteNonQuery();

                        if (rows > 0)
                            return "Staff added successfully.";
                        else
                            return "Staff insert failed : No rows affected.";
                    }
                }
            }
            catch (Exception ex)
            {
                return "Add Staff Error: " + ex.Message;
            }
        }
        public string UpdateStaff(Staff staff)
        {
            try
            {
                using (var conn = DbConfig.GetConnection())
                {
                    string query = @"UPDATE Staffs SET 
                                     StaffName = @name,
                                     StaffNIC = @nic,
                                     StaffGender = @gender,
                                     StaffAddress = @address,
                                     CourseId = @courseId,
                                     UserId = @userId
                                     WHERE StaffId = @id";
                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", staff.StaffName);
                        cmd.Parameters.AddWithValue("@nic", staff.StaffNIC);
                        cmd.Parameters.AddWithValue("@gender", staff.StaffGender.ToString());
                        cmd.Parameters.AddWithValue("@address", staff.StaffAddress);
                        cmd.Parameters.AddWithValue("@courseId", staff.CourseId);
                        cmd.Parameters.AddWithValue("@userId", staff.UserId);
                        cmd.Parameters.AddWithValue("@id", staff.StaffId);
                        cmd.ExecuteNonQuery();
                    }
                }
                return "Staff updated successfully.";
            }
            catch (Exception ex)
            {
                return "Update Staff Error: " + ex.Message;
            }
        }

        public string DeleteStaff(int id)
        {
            try
            {
                using (var conn = DbConfig.GetConnection())
                {
                    string query = "DELETE FROM Staffs WHERE StaffId = @id";
                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                }
                return "Staff deleted successfully.";
            }
            catch (Exception ex)
            {
                return "Delete Staff Error: " + ex.Message;
            }
        }

        public Staff GetStaffById(int id)
        {
            try
            {
                using (var conn = DbConfig.GetConnection())
                {
                    string query = "SELECT * FROM Staffs WHERE StaffId = @id";
                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
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
                                    CourseId = reader.GetInt32(5),
                                    UserId = reader.GetInt32(6)
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Get Staff Error: " + ex.Message);
            }
            return null;
        }
        public List<Staff> GetAllStaffs()
        {
            var staffList = new List<Staff>();

            try
            {
                using (var conn = DbConfig.GetConnection())
                {
                    string query = "SELECT * FROM Staffs";

                    var cmd = new SQLiteCommand(query, conn);
                    var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection); 

                    while (reader.Read())
                    {
                        var staff = new Staff
                        {
                            StaffId = reader["StaffId"] != DBNull.Value ? Convert.ToInt32(reader["StaffId"]) : 0,
                            StaffName = reader["StaffName"]?.ToString(),
                            StaffNIC = reader["StaffNIC"]?.ToString(),
                            StaffGender = Enum.TryParse(reader["StaffGender"]?.ToString(), out UserGender gender) ? gender : UserGender.Male,
                            StaffAddress = reader["StaffAddress"]?.ToString(),
                            CourseId = reader["CourseId"] != DBNull.Value ? Convert.ToInt32(reader["CourseId"]) : 0,
                            UserId = reader["UserId"] != DBNull.Value ? Convert.ToInt32(reader["UserId"]) : 0
                        };

                        staffList.Add(staff);
                    }

                    reader.Close(); 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading staff list: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return staffList;
        }


        public List<Staff> SearchStaffs(string keyword)
        {
            var list = new List<Staff>();
            try
            {
                using (var conn = DbConfig.GetConnection())
                {
                    string query = @"SELECT * FROM Staffs 
                             WHERE StaffName LIKE @keyword OR StaffNIC LIKE @keyword";
                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                list.Add(new Staff
                                {
                                    StaffId = reader.GetInt32(0),
                                    StaffName = reader.GetString(1),
                                    StaffNIC = reader.GetString(2),
                                    StaffGender = (UserGender)Enum.Parse(typeof(UserGender), reader.GetString(3)),
                                    StaffAddress = reader.GetString(4),
                                    CourseId = reader.GetInt32(5),
                                    UserId = reader.GetInt32(6)
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
