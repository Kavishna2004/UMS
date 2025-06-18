using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMSAssignment.ENUMS;
using UMSAssignment.REPOSITORIE;

namespace UMSAssignment.CONTROLLERS
{
    internal class LoginController
    {
        public LoginController()
        {
        
        }
        public void EnsureAdminExists() 
        {
            try
            {
                using (var conn = DbConfig.GetConnection())
                {
                    conn.Open();

                    string query = "SELECT COUNT(*) FROM Users WHERE Role = @Role";
                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Role", (int)UserRole.Admin);
                        long admincount = (long)cmd.ExecuteScalar();

                        if (admincount == 0)
                        {
                            //string insertQuery = "INSERT INTO Users (UserName, PasswordHash, Role) VALUES (@Username, @Password, @Role)";
                            string insertQuery = "INSERT INTO Users (UserName, Password, Role) VALUES (@Username, @Password, @Role)";
                            using (var insertCmd = new SQLiteCommand(insertQuery, conn))
                            {
                                insertCmd.Parameters.AddWithValue("@Username", "admin");
                                insertCmd.Parameters.AddWithValue("@Password", "admin123");
                                insertCmd.Parameters.AddWithValue("@Role", (int)UserRole.Admin);

                                insertCmd.ExecuteNonQuery();
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in EnsureAdminExists: " + ex.Message);
            }
        }
    }
}
