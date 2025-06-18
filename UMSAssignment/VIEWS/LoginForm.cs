using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UMSAssignment.CONTROLLERS;
using UMSAssignment.ENUMS;
using UMSAssignment.REPOSITORIE;

namespace UMSAssignment.VIEWS
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            var controller = new LoginController();
            controller.EnsureAdminExists();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            string UserName;
            try
            {
                using (var conn = DbConfig.GetConnection())
                {
                    string query = "SELECT * FROM Users WHERE UserName = @Username AND Password = @Password AND Role = @Role";
                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", Username);
                        cmd.Parameters.AddWithValue("@Password", Password);
                       /* cmd.Parameters.AddWithValue("@Role", Role);*/

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string Role = ((UserRole)Convert.ToInt32(reader["Role"])).ToString();
                                MessageBox.Show($"Login successful as {Role}");

                                this.Hide();
                                new InterFace().Show();
                            }
                            else
                            {
                                MessageBox.Show("Invalid username or password.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }


           /* string username = tusername.Text.Trim();
            string password = tpassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.");
                return;
            }

            bool success = AuthenticateUser(username, password);

            if (success)
            {
                this.Hide();

            }
            else
            {
                MessageBox.Show("Invalid username or password.");
            }*/

        }
        
    }
}

        //private bool AuthenticateUser(string username, string password)
        //    {
        //        try
        //        {
        //            using (var conn = DbConfig.GetConnection())
        //            {

        //                string query = "SELECT * FROM Users WHERE UserName = @Username AND Password = @Password";
        //                using (var cmd = new SQLiteCommand(query, conn))
        //                {
        //                    cmd.Parameters.AddWithValue("@Username", username);
        //                    cmd.Parameters.AddWithValue("@Password", password);

        //                    using (var reader = cmd.ExecuteReader())
        //                    {
        //                        if (reader.Read())
        //                        {
        //                            // role value read பண்ணி string-a convert பண்ணி switch case
        //                            string role = ((UserRole)Convert.ToInt32(reader["Role"])).ToString();

        //                            switch (role)
        //                            {
        //                                //case "Admin":
        //                                //    new Admin().Show();
        //                                //    break;
        //                                case "Student":
        //                                    new StudentForm().Show();
        //                                    break;
        //                                case "Lectrurer":
        //                                    new LecturerForm().Show();
        //                                    break;
        //                                default:
        //                                    MessageBox.Show("Unknown role");
        //                                    break;
        //                            }

        //                            this.Hide();

        //                            return true;
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show("Error: " + ex.Message);
        //        }
        //        return false;
        //    }


        /* string username = tusername.Text;
         string password = tpassword.Text;

         bool success = AuthenticateUser(username, password);

         if (success)
         {
             MessageBox.Show("Login Successful");
         }
         else
         {
             MessageBox.Show("Login Failed");
         }
     }

     private bool AuthenticateUser(string username, string password)
     {
         if (username == "admin" && password == "1234")
         {
             return true;
         }
         return false;
     }*/


