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

        private string currentRole;

        public StudentForm(string role)
        {
            InitializeComponent();
            studentController = new StudentController();
            courseController = new CourseController();

            currentRole = role;

            cmdGender.DataSource = Enum.GetValues(typeof(UserGender));

            LoadStudent();
            LoadCourse();
            LoadControl();
        }
        private void LoadControl()
        {
            btn_add.Visible = false;
            btn_update.Visible = false;
            btn_dlt.Visible = false;
            stsearch.Visible = false;
            ViewStudents.ReadOnly = true;

            if (currentRole == "Admin")
            {
                btn_add.Visible = true;
                btn_update.Visible = true;
                btn_dlt.Visible = true;
                stsearch.Visible = true;
                ViewStudents.ReadOnly = false;

            }
            else if (currentRole == "Lecturer" || currentRole == "Student" || currentRole == "Staff") 
            {
                btn_add.Visible = false;
                btn_update.Visible = false;
                btn_dlt.Visible = false;
                stsearch.Visible = false;
                ViewStudents.ReadOnly = true;
            }
        }

        private void LoadStudent()
        {
            try
            {
                var students = studentController.GetAllStudents();

                if (students == null || students.Count == 0)
                {
                    MessageBox.Show("No students found.");
                    ViewStudents.DataSource = null;
                    return;
                }

                ViewStudents.DataSource = null;
                ViewStudents.DataSource = students;

                // Hide unnecessary columns
                if (ViewStudents.Columns.Contains("CourseId"))
                    ViewStudents.Columns["CourseId"].Visible = false;

                if (ViewStudents.Columns.Contains("GroupId"))
                    ViewStudents.Columns["GroupId"].Visible = false;

                if (ViewStudents.Columns.Contains("UserId"))
                    ViewStudents.Columns["UserId"].Visible = false;

                ViewStudents.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading students: " + ex.Message);
            }
        }
    

        private void LoadCourse()
        {
            var courses = courseController.GetAllCourses();
            cmdCourse.DataSource = courses;
            cmdCourse.DisplayMember = "CourseName";
            cmdCourse.ValueMember = "CourseId";
        }

        private void ClearForm()
        {
            stname.Clear();
            stnic.Clear();
            stemail.Clear();
            staddress.Clear();
            stnumber.Clear();
            stdob.Clear();
            stsearch.Clear();
            cmdCourse.SelectedIndex = -1;
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
                StudentId = selectedStudentId,
                StudentName = stname.Text,
                StudentNIC = stnic.Text,
                StudentGender = (UserGender)cmdGender.SelectedValue,
                StudentAddress = staddress.Text,
                StudentEmail = stemail.Text,
                StudentPhone = stnumber.Text,
                StudentDOB = stdob.Text,
                CourseId = (int)cmdCourse.SelectedValue,
                UserId = 1
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
            
        }

        private void label4_Click(object sender, EventArgs e)
        {
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(stname.Text) || string.IsNullOrWhiteSpace(stnic.Text) || string.IsNullOrWhiteSpace(cmdGender.Text) ||
                          string.IsNullOrWhiteSpace(staddress.Text) || string.IsNullOrWhiteSpace(stemail.Text) || string.IsNullOrWhiteSpace(stnumber.Text) ||
                          string.IsNullOrWhiteSpace(stdob.Text) || string.IsNullOrWhiteSpace(cmdCourse.Text))
            {
                MessageBox.Show("Please must fill in all student details.");
                return;
            }

            if (cmdCourse.SelectedValue == null)
            {
                MessageBox.Show("Please select a Course.");
                return;
            }

            if ((UserGender)cmdGender.SelectedValue == (UserGender)(-1))
            {
                MessageBox.Show("Please select your gender.");
                return;
            }


            var student = new Student
            {
                StudentName = stname.Text,
                StudentNIC = stnic.Text,
                StudentGender = (UserGender)cmdGender.SelectedItem,
                StudentAddress = staddress.Text,
                StudentEmail = stemail.Text,
                StudentPhone = stnumber.Text,
                StudentDOB = stdob.Text,
                CourseId = (int)cmdCourse.SelectedValue,
                GroupId = 0,
                UserId = 1
            };
            Console.WriteLine("Insert Student: " + student.StudentName);
            Console.WriteLine("Gender: " + student.StudentGender);
            Console.WriteLine("CourseId: " + student.CourseId);
            Console.WriteLine("GroupId: " + student.GroupId);
            Console.WriteLine("UserId: " + student.UserId);


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
            //cmdGender.DataSource = Enum.GetValues(typeof(UserGender));
        }

        private void ViewStudents_SelectionChanged(object sender, EventArgs e)
        {
            if (ViewStudents.SelectedRows.Count > 0)
            {
                var row = ViewStudents.SelectedRows[0];
                var studentView = row.DataBoundItem as Student;

                if (studentView != null)
                {
                    selectedStudentId = studentView.StudentId;
                    stname.Text = studentView.StudentName;
                    stnic.Text = studentView.StudentNIC;
                    cmdGender.SelectedItem = studentView.StudentGender;
                    stemail.Text = studentView.StudentEmail;
                    staddress.Text = studentView.StudentAddress;
                    stnumber.Text = studentView.StudentPhone;
                    stdob.Text = studentView.StudentDOB;
                    cmdCourse.SelectedValue = studentView.CourseId;
                }

            }

            else
            {
                ClearInputs();
                selectedStudentId = -1;
            }
        }

        private void stsearch_TextChanged(object sender, EventArgs e)
        {
            var studentController = new StudentController();
            ViewStudents.DataSource = studentController.SearchStudents(stsearch.Text.Trim());
        }
    }
}
               