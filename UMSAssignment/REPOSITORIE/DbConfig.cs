using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;
using System.Web.UI.MobileControls;
using UMSAssignment.DTOS;
using UMSAssignment.MAPPERS;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;
using System.Runtime.ConstrainedExecution;
using System.Windows.Forms;
using System.Xml.Linq;
using UMSAssignment.MODELS;
using System.Drawing;

namespace UMSAssignment.REPOSITORIE
{
    public static class DbConfig
    {
        private static string ConnectionString = "Data Source = unicomticDB.db;Version=3;";

        public static SQLiteConnection GetConnection()
        {
            var conn = new SQLiteConnection(ConnectionString);
            conn.Open();
            return conn;
        }
    }
}
/*Field Name	Type	Use
👤 Student Name	text	மாணவரின் பெயர்
🆔 Student ID / Register No	text/number	மாணவரின் பதிவு எண்
📚 Subject	select (dropdown)	பாடப்பிரிவு தேர்வு
📆 Exam Date	date	தேர்வு நடந்த தேதி
📝 Marks Scored	number	பெற்ற மதிப்பெண்கள்
🏅 Grade (optional)	text or auto-calculate	தரம் (A/B/C)*/
/*
| Control Type | Purpose / Use case                      | Example Name |
| ------------------ | --------------------------------------- | -------------------------------- |
| **TextBox * *        | மாணவரின் பெயர்(Student Name) | txtStudentName |
| **TextBox * *        | மாணவரின் ID / Roll Number | txtStudentID |
| **TextBox * *        | Subject Marks(Maths, Science, English) | txtMaths, txtScience, txtEnglish |
| **Label * *          | Field title / description | lblStudentName, lblMaths |
| **Button * *         | Data save பண்ண Button | btnSave |
| **Button * *         | Data clear பண்ண Button | btnClear |
| **Button * *         | Form close பண்ண Button | btnClose |
| **ComboBox * *       | Exam Type(Midterm, Final) | cmbExamType |
| **DateTimePicker * * | Exam Date | dtpExamDate |

        Summary(சுருக்கம்):
TextBoxes: Student name, ID, marks per subject

ComboBox: Exam type

Date picker: Exam date

Buttons: Save, Clear, Close

*/