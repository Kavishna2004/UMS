using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
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

        public UserController()
        {

        }
        //iwe Users=======================================================================================================================================
        public List<UserDto> GetAllUsers()
        {
            var users = new List<UserDto>();
            try
            {
                using (var conn = DbConfig.GetConnection())
                {
                    using (var cmd = new SQLiteCommand("SELECT * FROM Users", conn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var user = new User
                                {
                                    UserId = Convert.ToInt32(reader["UserId"]),
                                    UserName = reader["UserName"].ToString(),
                                    UserEmail = reader["UserEmail"].ToString(),
                                    Role = (UserRole)Convert.ToInt32(reader["Role"]),
                                    PasswordHash = reader["PasswordHash"].ToString()
                                };
                                users.Add(UserMapper.ToDto(user));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in GetAllUsers: " + ex.Message);
            }
            return users;
        }
        //=================================================================================================================================================


        //Get user=========================================================================================================================================
        public UserDto GetUserById(int id)
        {
            try
            {
                using (var conn = DbConfig.GetConnection())
                {
                    
                    using (var cmd = new SQLiteCommand("SELECT * FROM Users WHERE UserId = @Id", conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", id);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                var user = new User
                                {
                                    UserId = Convert.ToInt32(reader["UserId"]),
                                    UserName = reader["UserName"].ToString(),
                                    UserEmail = reader["UserEmail"].ToString(),
                                    Role = (UserRole)Convert.ToInt32(reader["Role"]),
                                    PasswordHash = reader["PasswordHash"].ToString()
                                };
                                return UserMapper.ToDto(user);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in GetUserById: " + ex.Message);
            }
            return null;
        }
        //===============================================================================================================================================


        //Add user=======================================================================================================================================
        public bool AddUser(UserDto userDto, string passwordHash)
        {
            try
            {
                var user = UserMapper.ToEntity(userDto, passwordHash);
                using (var conn = DbConfig.GetConnection())
                {
                    conn.Open();
                    string query = "INSERT INTO Users (UserName, UserEmail, Role, PasswordHash) VALUES (@UserName, @UserEmail, @Role, @PasswordHash)";
                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserName", user.UserName);
                        cmd.Parameters.AddWithValue("@UserEmail", user.UserEmail);
                        cmd.Parameters.AddWithValue("@Role", (int)user.Role);
                        cmd.Parameters.AddWithValue("@PasswordHash", user.PasswordHash);

                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in AddUser: " + ex.Message);
                return false;
            }
        }
        //============================================================================================================================================


        //Update User=================================================================================================================================
        public bool UpdateUser(UserDto userDto)
        {
            try
            {
                var user = UserMapper.ToEntity(userDto);
                using (var conn = DbConfig.GetConnection())
                {
                    conn.Open();
                    string query = "UPDATE Users SET UserName=@UserName, UserEmail=@UserEmail, Role=@Role WHERE UserId=@UserId";
                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserName", user.UserName);
                        cmd.Parameters.AddWithValue("@UserEmail", user.UserEmail);
                        cmd.Parameters.AddWithValue("@Role", (int)user.Role);
                        cmd.Parameters.AddWithValue("@UserId", user.UserId);

                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in UpdateUser: " + ex.Message);
                return false;
            }
        }
        //=============================================================================================================================================


        //Delete user==================================================================================================================================
        public bool DeleteUser(int id)
        {
            try
            {
                using (var conn = DbConfig.GetConnection())
                {
                    conn.Open();
                    string query = "DELETE FROM Users WHERE UserId=@UserId";
                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserId", id);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in DeleteUser: " + ex.Message);
                return false;
            }
        }
        //============================================================================================================================================


        //Login=======================================================================================================================================
        private bool AuthenticateUser(string username, string password)
        {
            try
            {
                using (var conn = DbConfig.GetConnection())
                {
                    conn.Open();

                    string query = "SELECT * FROM Users WHERE UserName = @Username AND Password = @Password";
                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@Password", password);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string role = reader["Role"].ToString();

                                switch (role.ToLower())
                                {
                                    case "admin":
                                        MessageBox.Show("Admin login successful (form not implemented)", "Success");
                                        break;

                                    case "student":
                                        new StudentForm().Show();
                                        break;

                                    case "lecturer":
                                        new LecturerForm().Show();
                                        break;

                                    case "staff":
                                        MessageBox.Show("Staff login successful (form not implemented)", "Success");
                                        break;

                                    default:
                                        MessageBox.Show("Unknown role.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return false;
                                }

                                return true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }
        //=======================================================================================================================================
    }


}
        /*// ADD USER =========================================================================================
         * 

        public void AddUser(UserDto userDto, string plainPassword)
        {
            string passwordHash = HashPassword(plainPassword);

            using (var conn = DbConfig.GetConnection())
            {
                string query = @"INSERT INTO Users (UserName, UserEmail, PasswordHash, Role) 
                         VALUES (@name, @email, @passwordHash, @role);";

                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@name", userDto.UserName);
                    cmd.Parameters.AddWithValue("@email", userDto.UserEmail);
                    cmd.Parameters.AddWithValue("@passwordHash", passwordHash);
                    cmd.Parameters.AddWithValue("@role", userDto.Role.ToString());

                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Dummy hash function - replace with real hashing!
        private string HashPassword(string password)
        {
            return Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(password));
        }


        // ==================================================================================================

        // GET ALL USER RECORD ==============================================================================

        public List<UserDto> GetAllUsers()
        {
            var users = new List<UserDto>();

            using (var conn = DbConfig.GetConnection())
            {
                string query = "SELECT UserId, UserName, UserEmail, PasswordHash, Role FROM Users";

                using (var cmd = new SQLiteCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var user = new User
                        {
                            UserId = reader.GetInt32(0),
                            UserName = reader.GetString(1),
                            UserEmail = reader.GetString(2),
                            PasswordHash = reader.GetString(3),
                            Role = (UserRole)reader.GetInt32(4)
                        };
                        users.Add(UserMapper.ToDto(user));  // mapping here
                    }
                }
            }

            return users;
        }
    }
}
*/

// ===============================================================================================




/* public List<UserDto> ReadAllUsers()
 {
     var users = new List<UserDto>();
     using (var conn = new SQLiteConnection(ConnectionString))
     {
         conn.Open();
         using (var command = new SQLiteCommand("SELECT Id, FullName, Email, Status FROM Users", conn))
         {
             using (var reader = command.ExecuteReader())
             {
                 while (reader.Read())
                 {
                     var statusString = !reader.IsDBNull(3) ? reader.GetString(3) : null;
                     var role = UserRole.Student;
                     if (statusString != null)
                     {
                         Enum.TryParse(statusString, out role);
                     }

                     users.Add(new UserDto
                     {
                         DtoId = !reader.IsDBNull(0) ? reader.GetInt32(0) : 0,
                         DtoName = !reader.IsDBNull(1) ? reader.GetString(1) : string.Empty,
                         DtoEmail = !reader.IsDBNull(2) ? reader.GetString(2) : string.Empty,
                         Role = role
                     });
                 }
             }
         }
     }
     return users;
 }*/

/*   public void UpdateUser(UserDto userDto)
   {
       using (var conn = new SQLiteConnection(ConnectionString))
       {
           conn.Open();
           using (var command = new SQLiteCommand(
               "UPDATE Users SET Name = @Username, Email = @UserEmail, Role = @Role WHERE Id = @UserId",
               conn))
           {
               command.Parameters.AddWithValue("@UserId", userDto.DtoId);
               command.Parameters.AddWithValue("@Username", userDto.DtoName);
               command.Parameters.AddWithValue("@UserEmail", userDto.DtoEmail);
               command.Parameters.AddWithValue("@Status", userDto.Role.ToString());
               command.ExecuteNonQuery();
           }
       }
   }
   public void DeleteUser(int id)
   {
       using (var conn = new SQLiteConnection(ConnectionString))
       {
           conn.Open();
           using (var command = new SQLiteCommand(
               "DELETE FROM Users WHERE Id = @Id",
               conn))
           {
               command.Parameters.AddWithValue("@Id", id);
               command.ExecuteNonQuery();
           }
       }
   }
   public UserDto ReadUser(int id)
   {
       using (var connection = new SQLiteConnection(ConnectionString))
       {
           connection.Open();
           using (var command = new SQLiteCommand(
               "SELECT Id, FullName, Email, Role FROM Users WHERE Id = @Id",
               connection))
           {
               command.Parameters.AddWithValue("@Id", id);
               using (var reader = command.ExecuteReader())
               {
                   if (reader.Read())
                   {
                       var roleString = !reader.IsDBNull(3) ? reader.GetString(3) : null;
                       var role = UserRole.Student;
                       if (roleString != null)
                       {
                           Enum.TryParse(roleString, out role);
                       }

                       return new UserDto
                       {
                           DtoId = !reader.IsDBNull(0) ? reader.GetInt32(0) : 0,
                           DtoName = !reader.IsDBNull(1) ? reader.GetString(1) : string.Empty,
                           DtoEmail = !reader.IsDBNull(2) ? reader.GetString(2) : string.Empty,
                           Role = role
                       };
                   }
               }
           }
           return null;
       }
   } //Idhukkana codinga ah kekkNum sir da
}
}

                   */