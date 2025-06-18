using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using UMSAssignment.CONTROLLERS;
using UMSAssignment.ENUMS;
using UMSAssignment.MODELS;

namespace UMSAssignment.VIEWS
{
    public partial class StudentForm : Form
    {
        private readonly StudentController studentController;
        private readonly CourseController courseController;
        private int selectedStudentId = -1;

        public StudentForm()
        {
            InitializeComponent();
            studentController = new StudentController();
            courseController = new CourseController();

            LoadStudent();
            LoadCourse();
        }
        private void LoadStudent() 
        {
            ViewStudents.DataSource = null;
            ViewStudents.DataSource = studentController.GetAllStudents();

            if (ViewStudents.Columns.Contains("CourseId")) 
            {
                ViewStudents.Columns["CourseId"].Visible = false;
            }
            ViewStudents.ClearSelection();
            if (cmdCourse.SelectedValue == null)
            {
                MessageBox.Show("Please select a course!");
                return;
            }
        }
        private void LoadCourse() 
        {
            var courses = courseController.GetAllCourse();
            cmdCourse.DataSource = courses;
            cmdCourse.DisplayMember = "Name";
            cmdCourse.ValueMember = "Id";
        }
        private void ClearForm() 
        {
            stname.Clear();
            stnic.Clear();
            stemail.Clear();
            staddress.Clear();
            stnumber.Clear();
            stdob.Clear();
            cmdCourse.DataSource = null;
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            if (selectedStudentId == -1)
            {
                MessageBox.Show("Please select a student to update hear.");
                return;
            }

            if (string.IsNullOrWhiteSpace(stname.Text) || string.IsNullOrWhiteSpace(stnic.Text) || string.IsNullOrWhiteSpace(cmdGender.Text) ||
                string.IsNullOrWhiteSpace(staddress.Text) || string.IsNullOrWhiteSpace(stemail.Text) || string.IsNullOrWhiteSpace(stnumber.Text) ||
                string.IsNullOrWhiteSpace(stdob.Text) || string.IsNullOrWhiteSpace(cmdCourse.Text))
            {
                MessageBox.Show("Please must fill in all student details.");
                return;
            }

            var student = new Student
            {
                StudentName = stname.Text,
                StudentNIC = stnic.Text,
                StudentGender = (UserGender)cmdGender.SelectedValue,
                StudentAddress = staddress.Text,
                StudentEmail = stemail.Text,
                StudentPhone = stnumber.Text,
                DOB = stdob.Text,
                CourseId = (UserCourse)cmdCourse.SelectedValue
            };

            studentController.UpdateStudent(student);
            LoadStudent();
            ClearForm(); ;
            MessageBox.Show("Student Updated Successfully");

        }

        private void btn_dlt_Click(object sender, EventArgs e)
        {
            if (selectedStudentId == -1)
            {
                MessageBox.Show("Please select a student to delete.");
                return;
            }

            var confirmResult = MessageBox.Show("Are you sure to delete this student?", "Confirm Delete", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                studentController.DeleteStudent(selectedStudentId);
                LoadStudent();
                ClearForm();
                MessageBox.Show("Student Deleted Successfully");
            }
        }

        private void cmdCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            {
                cmdGender.Items.Clear();
                cmdGender.Items.Add("Select Gender");
                foreach (var gender in Enum.GetValues(typeof(UserGender)))
                {
                    cmdGender.Items.Add(gender);
                }
                cmdGender.SelectedIndex = 0;
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(stname.Text) || string.IsNullOrWhiteSpace(stnic.Text) ||   string.IsNullOrWhiteSpace(cmdGender.Text) ||
                string.IsNullOrWhiteSpace(staddress.Text) || string.IsNullOrWhiteSpace(stemail.Text) || string.IsNullOrWhiteSpace(stnumber.Text) ||
                string.IsNullOrWhiteSpace(stdob.Text) || string.IsNullOrWhiteSpace(cmdCourse.Text))
            {
                MessageBox.Show("Please must fill in all student details.");
                return;
            }

            if (cmdCourse.SelectedValue == null)
            {
                MessageBox.Show("Please select a section.");
                return;
            }

            var student = new Student
            {
                StudentName = stname.Text,
                StudentNIC = stnic.Text,
                StudentGender = (UserGender)cmdGender.SelectedValue,
                StudentAddress = staddress.Text,
                StudentEmail = stemail.Text,
                StudentPhone = stnumber.Text,
                DOB = stdob.Text,
                CourseId = (UserCourse)cmdCourse.SelectedValue
            };

            studentController.AddStudent(student);
            LoadStudent();
            ClearForm();
            MessageBox.Show("Student Added Successfully");
        }

        private void ViewStudents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void ClearInputs()
        {
            stname.Text = "";
            stnic.Text = "";
            cmdGender.Text = "";
            staddress.Text = "";
            stemail.Text = "";
            stnumber.Text = "";
            stdob.Text = "";
            cmdCourse.Text = "";
        }

        private void stnumber_TextChanged(object sender, EventArgs e)
        {

        }

        private void StudentForm_Load(object sender, EventArgs e)
        {

        }

        private void ViewStudents_SelectionChanged(object sender, EventArgs e)
        {
            if (ViewStudents.SelectedRows.Count > 0)
            {
                var row = ViewStudents.SelectedRows[0];
                var studentView = row.DataBoundItem as Student;

                if (studentView is Student student)
                {
                    selectedStudentId = studentView.StudentId;

                    var students = studentController.GetStudentById(selectedStudentId);
                    if (students != null)
                    {
                        stname.Text = student.StudentName;
                        stnic.Text = student.StudentNIC;
                        cmdGender.SelectedValue = student.StudentGender;
                        stemail.Text = student.StudentEmail;
                        staddress.Text = student.StudentAddress;
                        stnumber.Text = student.StudentPhone;
                        stdob.Text = student.DOB;
                        cmdCourse.SelectedValue = student.CourseId;
                    }
                }
            }
            else
            {
                ClearInputs();
                selectedStudentId = -1;
            }
        }
    }
}
