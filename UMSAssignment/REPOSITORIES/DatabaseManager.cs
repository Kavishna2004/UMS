using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using System.Windows.Forms;
using UMSAssignment.DATA;
using UMSAssignment.MODELS;

namespace UMSAssignment.DATA
{
    internal class DatabaseManager
    {
    }
}
🔐 LoginForm - ல் இருக்க வேண்டிய UI கூறுகள் (UI Components)
கூறு	விவரம்
2 Label	- Username என்ற லேபிள்
- Password என்ற லேபிள்
2 TextBox	- txtUsername (username ஐ input பண்ண)
- txtPassword (password ஐ input பண்ண, UseSystemPasswordChar = true வைத்து மறைக்கலாம்)
1 Button	- btnLogin (Login செய்ய பயன்படும் பட்டன்)
1 Label (Optional)	- lblError (தவறான Login என்றால் error message காட்ட)

🧠 Login Logic (Code பக்கம்)
✅ Step 1: Database - ல் Username, Password சேமிக்கப்பட வேண்டும்
(உதாரணமாக Users என்ற அட்டவணையில்):

sql
Copy
Edit
CREATE TABLE Users (
    UserID INTEGER PRIMARY KEY AUTOINCREMENT,
    Username TEXT NOT NULL,
    Password TEXT NOT NULL,
    Role TEXT NOT NULL
);
✅ Step 2: Login Button Click Event
csharp
Copy
Edit
private async void btnLogin_Click(object sender, EventArgs e)
{
    string username = txtUsername.Text.Trim();
    string password = txtPassword.Text.Trim();

    if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
    {
        MessageBox.Show("தயவுசெய்து Username மற்றும் Password ஐ உள்ளிடுங்கள்.");
        return;
    }

    // Database-ல் இந்த user இருக்கிறாரா என்று சோதிக்க
    bool isValidUser = await DatabaseManager.CheckLoginAsync(username, password);

    if (isValidUser)
    {
        // MainForm-க்கு செல்லுங்கள்
        MainForm mainForm = new MainForm();
        this.Hide();
        mainForm.Show();
    }
    else
    {
        MessageBox.Show("தவறான Username அல்லது Password.");
    }
}
✅ Step 3: DatabaseManager - ல் Login சோதனை method
csharp
Copy
Edit
public static async Task<bool> CheckLoginAsync(string username, string password)
{
    using (SQLiteConnection conn = new SQLiteConnection("Data Source=unicomtic.db"))
    {
        await conn.OpenAsync();
        string query = "SELECT COUNT(*) FROM Users WHERE Username=@username AND Password=@password";
        using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
        {
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password); // இதில் hashed password இருந்தால் நல்லது

            long count = (long)await cmd.ExecuteScalarAsync();
            return count > 0;
        }
    }
}
🧑‍💼 Role - Based Access Control(Optional but Recommended)
Users அட்டவணையில் Role (e.g., Admin, Student, Teacher) என்ற புலம் (field) இருந்தால், Login செய்த பின் role-ஐ MainForm-க்கு அனுப்பி, அதன்படி UI-ஐ மாற்றலாம்.

✨ UI Design Tip (Form Designer-ல்)
UI Element	Name	Properties
Label	lblUsername	Text: "Username:"
Label lblPassword	Text: "Password:"
TextBox txtUsername	Name: txtUsername
TextBox	txtPassword	Name: txtPassword, UseSystemPasswordChar = true
Button	btnLogin	Text: "Login"
Label lblError	Text: "", ForeColor: Red, Visible: false

இது ஒரு சுலபமான LoginForm உருவாக்கும் முழு கட்டமைப்பு (structure). இதை விரிவுபடுத்த, Remember Me, Forgot Password, அல்லது Password Hashing போன்ற advanced விஷயங்களையும் சேர்க்கலாம்.

வேண்டுமானால் நான் UI Form Design-ற்கான screenshot structure-ஐ எடுத்துக்கொடுக்கலாம். கூறுங்கள்.




