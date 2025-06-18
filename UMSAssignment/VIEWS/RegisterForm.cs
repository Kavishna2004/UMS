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
using UMSAssignment.ENUMS;
using UMSAssignment.REPOSITORIE;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace UMSAssignment.VIEWS
{
    public partial class RegisterForm : Form
    {
        private readonly string ConnectionString;

        public object cmd { get; private set; }

        public RegisterForm()
        {
            InitializeComponent();
            //rpassword.PasswordChar = '*';
            rrole.DataSource = Enum.GetValues(typeof(UserRole))
                .Cast<Enum>()
                .Select(e => new
                {
                    Description = e.GetType()
                        .GetField(e.ToString())
                        .GetCustomAttributes(typeof(DescriptionAttribute), false)
                        .Cast<DescriptionAttribute>()
                        .FirstOrDefault()?.Description ?? e.ToString(),
                    Value = e
                })
                .ToList();
            rrole.DisplayMember = "Description";
            rrole.ValueMember = "Value";

        }

        private void btn_summit_Click(object sender, EventArgs e)
        {
            string username = rusername.Text;
            string password = rpassword.Text;
            //string role = rrole.SelectedItem.ToString();
            var selectedRole = rrole.SelectedItem.ToString();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(selectedRole))
            {
                MessageBox.Show("Please enter both Usrename, password and Role.");
                return;
            }
            //if (password.Length < 8)
            //{
            //    MessageBox.Show("Password must be at least 8 characters long.");
            //    return;
            //}

            //if (!char.IsUpper(password[0]))
            //{
            //    MessageBox.Show("The first letter of the password must be a capital letter (A-Z).");
            //    return;
            //}
            //string rest = password.Substring(1);
            //if (!rest.All(c => char.IsLower(c) || c == '@'))
            //{
            //    MessageBox.Show("From the second character onward, all characters in the password must be lowercase letters (a-z) or the '@' symbol");
            //}

            //if (!password.Contains("@"))
            //{
            //    MessageBox.Show("The password must contain the '@' symbol at least once.");
            //    return;
            //}

            using (var conn = DbConfig.GetConnection())
            {
                string query = "INSERT INTO Users (Username, Password, Role) VALUES (@Username, @Password, @Role)";
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password);
                cmd.Parameters.AddWithValue("@Role", selectedRole);

                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                {
                    MessageBox.Show("User Registered Successfully.");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Registration failed. Please try again.");
                }
            }

        }
        private void rrole_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        /*private void rpassword_TextChanged(object sender, EventArgs e)
        {
            if (rusername.Text != " " && rpassword.Text != "")
            {
                MessageBox.Show("Login Attempt Successfull!");
            }
        }*/
    }
}
