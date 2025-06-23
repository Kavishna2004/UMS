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
            
        }
        public void SetUserRole(string role) 
        {
            
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            string username = tusername.Text.Trim();
            string password = tpassword.Text.Trim();

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter Username and Password.");
                return;
            }

            try
            {
                // Admin is hardcoded 
                if (username == "Admin" && password == "Admin123")
                {
                    MessageBox.Show("Login successful as Admin");
                    this.Hide();

                    string role = "Admin";
                    InterFace form = new InterFace();
                    form.Show();
                    return;
                }

                // Others are validated db
                using (var conn = DbConfig.GetConnection())
                {
                    string query = "SELECT Role FROM Users WHERE Username = @Username AND Password = @Password";
                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@Password", password);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string role = reader["Role"].ToString();
                                MessageBox.Show($"Login successful as {role}");
                                this.Hide();

                                InterFace form = new InterFace();
                                form.Show();
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
                MessageBox.Show("Login Error: " + ex.Message);
            }
        }
    }
}

       