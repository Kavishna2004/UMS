using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UMSAssignment.CONTROLLERS;
using UMSAssignment.ENUMS;
using UMSAssignment.MODELS;

namespace UMSAssignment.VIEWS
{
    public partial class TimetableForm_cs : Form
    {
        private readonly TimetableController timetableController;
        private readonly CourseController courseController;
        private readonly SubjectController subjectController;
        private int selectedTimetableId = -1;

        public TimetableForm_cs()
        {
            InitializeComponent();
            timetableController = new TimetableController();
            courseController = new CourseController();
            subjectController = new SubjectController();

            LoadTimetable();
            LoadSubject();
            LoadCourse();
        }
        private void LoadSubject()
        {
            ViewTimetable.DataSource = null;
            ViewTimetable.DataSource = timetableController.GetAllTSubjects();

            if (ViewTimetable.Columns.Contains("SubjectId"))
            {
                ViewTimetable.Columns["SubjectId"].Visible = false;
            }
            ViewTimetable.ClearSelection();
            if (cmdCSubject.SelectedValue == null)
            {
                MessageBox.Show("Please select a Subject!");
                return;
            }
        }
        private void LoadCourse()
        {
            var courses = courseController.GetAllCourse();
            cmdCourse.DataSource = courses;
            cmdCourse.DisplayMember = "CourseName";
            cmdCourse.ValueMember = "CourseId";
        }
        private void LoadTimetable()
        {
            var timetables = timetableController.GetAllTimetables();
            cmdCourse.DataSource = timetables;
            cmdCourse.DisplayMember = "SubjectName";
            cmdCourse.ValueMember = "SubjectId";
        }
        private void ClearForm()
        {
            ttime.Clear();
            cmdCourse.DataSource = null;
            cmdSubject.DataSource = null;
        }
        private void TimetableForm_cs_Load(object sender, EventArgs e)
        {

        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ttime.Text) || string.IsNullOrWhiteSpace(cmdCourse.Text) || string.IsNullOrWhiteSpace(cmdSubject.Text))
            {
                MessageBox.Show("Please must fill in all Timeta details.");
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

    }

    private void btn_update_Click(object sender, EventArgs e)
        {

        }

        private void btn_dlt_Click(object sender, EventArgs e)
        {

        }

        private void cmdSubject_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmdRoom_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ViewTimetable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
