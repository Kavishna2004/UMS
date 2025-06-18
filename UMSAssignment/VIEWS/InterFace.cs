using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UMSAssignment.VIEWS;

namespace UMSAssignment.VIEWS
{
    public partial class InterFace : Form
    {
        public InterFace()
        {
            InitializeComponent();
        }

        public void LoadForm(object formObject)
        {
            if (this.mainpanel2.Controls.Count > 0)
            {
                this.mainpanel2.Controls.RemoveAt(0);
            }

            Form form = formObject as Form;
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            this.mainpanel2.Controls.Add(form);
            this.mainpanel2.Tag = form;
            form.Show();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btn_student_Click(object sender, EventArgs e)
        {
            //StudentForm form = new StudentForm();
            //LoadForm(form);
            LoadForm(new StudentForm());
        }

        private void btn_lecturer_Click(object sender, EventArgs e)
        {
            LecturerForm form = new LecturerForm();
            LoadForm(form);
        }

        private void btn_staff_Click(object sender, EventArgs e)
        {
            StaffForm form = new StaffForm();
            LoadForm(form);
        }

        private void btn_time_Click(object sender, EventArgs e)
        {
            TimetableForm form = new TimetableForm();
            LoadForm(form);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ExamForm form = new ExamForm();
            LoadForm(form);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CourseForm form = new CourseForm();
            LoadForm(form);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MarkForm form = new MarkForm();
            LoadForm(form);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            LoginForm form = new LoginForm();
            LoadForm(form);
        }

        private void mainpanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void InterFace_Load(object sender, EventArgs e)
        {

        }
    }
}
/*Step - by - step:
1.StudentForm உருவாக்குங்க
உங்க project-ல் StudentForm என்று ஒரு புதிய Form add பண்ணுங்க.

csharp
Copy
Edit
public partial class StudentForm : Form
{
    public StudentForm()
    {
        InitializeComponent();
    }

    // உங்கள் Student form UI மற்றும் logic இங்கே எழுதுங்கள்
}
2.MainForm - ல் Button Create பண்ணி, Click Event Handle பண்ணுங்க
MainForm-ல் ஒரு button வைங்க (எ.கா: btn_studentManagement).

Designer-ல் button drag & drop பண்ணி, அல்லது code-ல் add பண்ணி, click event attach பண்ணுங்க:

csharp
Copy
Edit
private void btn_studentManagement_Click(object sender, EventArgs e)
{
    LoadForm(new StudentForm());
}
3.LoadForm method இதுதான் உங்களுக்கு உதவும்:
csharp
Copy
Edit
public void LoadForm(object formObject)
{
    if (this.MainPanel.Controls.Count > 0)
    {
        this.MainPanel.Controls.RemoveAt(0);
    }

    Form form = formObject as Form;
    form.TopLevel = false;
    form.Dock = DockStyle.Fill;
    this.MainPanel.Controls.Add(form);
    this.MainPanel.Tag = form;
    form.Show();
}
Short summary:
StudentForm உருவாக்கு.

MainForm - ல் button click event-ல் LoadForm(new StudentForm()) call பண்ணு.

StudentForm MainPanel-ல் show ஆகும்.

உதவி வேண்டுமா?
நீங்கள் StudentForm-ல என்ன data காட்சிப்படுத்த விரும்புகிறீர்கள்? Table? Entry forms? சொல்லுங்க, code உதவித் தரலாம்னு!

*/


