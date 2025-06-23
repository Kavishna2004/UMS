using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using UMSAssignment.CONTROLLERS;
using UMSAssignment.DTOS;
using UMSAssignment.ENUMS;
using UMSAssignment.REPOSITORIE;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace UMSAssignment.VIEWS
{
    public partial class RegisterForm : Form
    {
        
        public RegisterForm()
        {
            InitializeComponent();

            rrole.DataSource = Enum.GetValues(typeof(UserRole));
        }

        private void btn_summit_Click(object sender, EventArgs e)
        {
            string username = rusername.Text.Trim();
            string password = rpassword.Text.Trim();
            var selectedRole = rrole.SelectedItem;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) || selectedRole == null)
            {
                MessageBox.Show("Please fill all fields.");
                return;
            }

            try
            {
                using (var conn = DbConfig.GetConnection())
                {
                    // Check if username already exists
                    string checkQuery = "SELECT COUNT(*) FROM Users WHERE Username = @Username";
                    using (var checkCmd = new SQLiteCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@Username", username);
                        long userExists = (long)checkCmd.ExecuteScalar();

                        if (userExists > 0)
                        {
                            MessageBox.Show("Username already exists. Choose another.");
                            return;
                        }
                    }

                    // Proceed with insert
                    string insertQuery = "INSERT INTO Users (Username, Password, Role) VALUES (@Username, @Password, @Role)";
                    using (var cmd = new SQLiteCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@Password", password);
                        cmd.Parameters.AddWithValue("@Role", selectedRole.ToString());

                        int rows = cmd.ExecuteNonQuery();

                        if (rows > 0)
                        {
                            MessageBox.Show("User Registered Successfully.");
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Registration failed.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Registration Error: " + ex.Message);
            }
        }
        private void rrole_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
