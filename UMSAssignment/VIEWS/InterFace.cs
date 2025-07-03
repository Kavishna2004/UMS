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
        private string currentRole;
        public InterFace()
        {
            InitializeComponent();
            //currentRole = Role;
        }
        /*private void LoadControl()
        {
            bool isAdmin = currentRole == "Admin";

            btn_student.Visible = isAdmin;
            btn_lecturer.Visible = isAdmin;
            btn_.Visible = isAdmin;
            lesearch.Visible = isAdmin;

            ViewLecturer.ReadOnly = !isAdmin;
        }
*/
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
            StudentForm form = new StudentForm(currentRole);
            LoadForm(form);
        }

        private void btn_lecturer_Click(object sender, EventArgs e)
        {
            LecturerForm form = new LecturerForm(currentRole);
            LoadForm(form);
        }

        private void btn_staff_Click(object sender, EventArgs e)
        {
            StaffForm form = new StaffForm(currentRole);
            LoadForm(form);
        }

        private void btn_time_Click(object sender, EventArgs e)
        {
            TimetableForm form = new TimetableForm(currentRole);
            LoadForm(form);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*ExamForm form = new ExamForm();
            LoadForm(form);*/
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CourseForm form = new CourseForm(currentRole);
            LoadForm(form);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            /*MarkForm form = new MarkForm();
            LoadForm(form);*/
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            LoginForm form = new LoginForm();
            LoadForm(form);
        }

        private void mainpanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void InterFace_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            SubjectForm form = new SubjectForm(currentRole);
            LoadForm(form);
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            AttendanceForm form = new AttendanceForm(currentRole);
            LoadForm(form);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ExamForm form = new ExamForm();
            LoadForm(form);
        }
    }
}
