using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UMSAssignment.DTOS;
using UMSAssignment.ENUMS;
using UMSAssignment.MAPPERS;
using UMSAssignment.MODELS;
using UMSAssignment.REPOSITORIE;
using UMSAssignment.VIEWS;

namespace UMSAssignment.CONTROLLERS
{
    internal class UserController
    {
        private readonly string ConnectionString;

        private List<User> users = new List<User>();
        private int nextId = 1;

        public string AddUser(UserDto dto, string password)
        {
            try
            {
                using (var conn = DbConfig.GetConnection())
                {
                    string query = "INSERT INTO Users (UserName, Password, Role) VALUES (@name, @pass, @role)";
                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", dto.UserName);
                        //cmd.Parameters.AddWithValue("@email", dto.UserEmail);
                        cmd.Parameters.AddWithValue("@pass", password);
                        cmd.Parameters.AddWithValue("@role", dto.Role.ToString());
                        cmd.ExecuteNonQuery();
                    }
                }
                return "User added successfully.";
            }
            catch (Exception ex)
            {
                return $"Add User DB Error: {ex.Message}";
            }
        }
        //=================================================================================================================================================


        public string UpdateUser(UserDto dto)
        {
            try
            {
                using (var conn = DbConfig.GetConnection())
                {
                    string query = "UPDATE Users SET UserName = @name, Role = @role WHERE UserId = @id";
                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", dto.UserName);
                        //cmd.Parameters.AddWithValue("@email", dto.UserEmail);
                        cmd.Parameters.AddWithValue("@role", dto.Role.ToString());
                        cmd.Parameters.AddWithValue("@id", dto.UserId);
                        cmd.ExecuteNonQuery();
                    }
                }
                return "User updated successfully.";
            }
            catch (Exception ex)
            {
                return $"Update User DB Error: {ex.Message}";
            }
        }
        public string DeleteUser(int id)
        {
            try
            {
                using (var conn = DbConfig.GetConnection())
                {
                    string query = "DELETE FROM Users WHERE UserId = @id";
                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                }
                return "User deleted successfully.";
            }
            catch (Exception ex)
            {
                return $"Delete User DB Error: {ex.Message}";
            }
        }

        public UserDto GetUserById(int id)
        {
            try
            {
                using (var conn = DbConfig.GetConnection())
                {
                    string query = "SELECT UserId, UserName, Role FROM Users WHERE UserId = @id";
                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new UserDto
                                {
                                    UserId = reader.GetInt32(0),
                                    UserName = reader.GetString(1),
                                    //UserEmail = reader.GetString(2),
                                    Role = (UserRole)Enum.Parse(typeof(UserRole), reader.GetString(2))
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Get User Error: " + ex.Message);
            }

            return null;

        }
        public List<UserDto> GetAllUsers()
        {
            List<UserDto> list = new List<UserDto>();
            try
            {
                using (var conn = DbConfig.GetConnection())
                {
                    string query = "SELECT UserId, UserName, Role FROM Users";
                    using (var cmd = new SQLiteCommand(query, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new UserDto
                            {
                                UserId = reader.GetInt32(0),
                                UserName = reader.GetString(1),
                                //UserEmail = reader.GetString(2),
                                Role = (UserRole)Enum.Parse(typeof(UserRole), reader.GetString(2))
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("List User Error: " + ex.Message);
            }
            return list;
        }

        //Login=======================================================================================================================================

        public void EnsureAdminExists()
        {
            try
            {
                using (var conn = DbConfig.GetConnection())
                {
                    string checkQuery = "SELECT COUNT(*) FROM Users WHERE Username = 'Admin'";
                    using (var checkCmd = new SQLiteCommand(checkQuery, conn))
                    {
                        long count = (long)checkCmd.ExecuteScalar();

                        if (count == 0)
                        {
                            string insertQuery = "INSERT INTO Users (Username, Password, Role) VALUES (@username, @password, @role)";
                            using (var insertCmd = new SQLiteCommand(insertQuery, conn))
                            {
                                insertCmd.Parameters.AddWithValue("@username", "Admin");
                                insertCmd.Parameters.AddWithValue("@password", "Admin123");
                                insertCmd.Parameters.AddWithValue("@role", UserRole.Admin.ToString());
                                insertCmd.ExecuteNonQuery();
                            }

                            MessageBox.Show("Default Admin created: Username = Admin, Password = Admin123");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while ensuring default Admin: " + ex.Message);
            }
        }
    }
}