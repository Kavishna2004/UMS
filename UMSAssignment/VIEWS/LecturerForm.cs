using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using UMSAssignment.CONTROLLERS;
using UMSAssignment.ENUMS;
using UMSAssignment.MODELS;
using static System.Windows.Forms.AxHost;

namespace UMSAssignment.VIEWS
{
    public partial class LecturerForm : Form
    {
        private readonly LecturerController lecturerController;
        private readonly CourseController courseController;
        private int selectedLecturerId = -1;

        private string currentRole;

        public LecturerForm(string role)
        {
            InitializeComponent();
            lecturerController = new LecturerController();
            courseController = new CourseController();

            currentRole = role;

            cmdGender.DataSource = Enum.GetValues(typeof(UserGender));

            LoadLecturer();
            LoadCourse();
            LoadControl();
        }
        private void LoadControl()
        {
            btn_add.Visible = false;
            btn_update.Visible = false;
            btn_dlt.Visible = false;
            lesearch.Visible = false;
            ViewLecturer.ReadOnly = true;


            if (currentRole != null && currentRole.ToLower() == "admin")
            {
                btn_add.Visible = true;
                btn_update.Visible = true;
                btn_dlt.Visible = true;
                lesearch.Visible = true;
                ViewLecturer.ReadOnly = false;
            }

            else if (currentRole.ToLower() == "lecturer" || currentRole.ToLower() == "student" || currentRole.ToLower() == "staff")
            {

                ViewLecturer.ReadOnly = true;
            }
        }
        private void LoadLecturer()
        {
            try
            {
                var lecturers = lecturerController.GetAllLecture();

                if (lecturers == null || lecturers.Count == 0)
                {
                    MessageBox.Show("No lecturers found.");
                    ViewLecturer.DataSource = null;
                    return;
                }

                ViewLecturer.DataSource = null;
                ViewLecturer.DataSource = lecturers;

              
                if (ViewLecturer.Columns.Contains("CourseId"))
                    ViewLecturer.Columns["CourseId"].Visible = false;

                if (ViewLecturer.Columns.Contains("GroupId"))
                    ViewLecturer.Columns["GroupId"].Visible = false;

                if (ViewLecturer.Columns.Contains("UserId"))
                    ViewLecturer.Columns["UserId"].Visible = false;

                ViewLecturer.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading lecturers: " + ex.Message);
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
            lename.Clear();
            lenic.Clear();
            cmdGender.SelectedIndex = -1;
            leaddress.Clear();
            lenumber.Clear();
            leemail.Clear();
            cmdCourse.SelectedIndex = -1;
            selectedLecturerId = -1;
        }
       
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void LecturerForm_Load(object sender, EventArgs e)
        {
          
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btn_add_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(lename.Text) || string.IsNullOrWhiteSpace(lenic.Text) || string.IsNullOrWhiteSpace(cmdGender.Text) ||
                 string.IsNullOrWhiteSpace(leaddress.Text) || string.IsNullOrWhiteSpace(lenumber.Text) ||
                string.IsNullOrWhiteSpace(leemail.Text) || string.IsNullOrWhiteSpace(cmdCourse.Text))
            {
                MessageBox.Show("Please must fill in all lecturer details.");
                return;
            }
            if (cmdCourse.SelectedValue == null)
            {
                MessageBox.Show("Please select a course!");
                return;
            }
            if ((UserGender)cmdGender.SelectedValue == (UserGender)(-1))
            {
                MessageBox.Show("Please select your gender.");
                return;
            }
            var lecturer = new Lecturer
            {
                LecturerName = lename.Text,
                LecturerNIC = lenic.Text,
                LecturerGender = (UserGender)cmdGender.SelectedItem,
                LecturerAddress = leaddress.Text,
                LecturerPhone = lenumber.Text,
                LecturerEmail = leemail.Text,
                CourseId = (int)cmdCourse.SelectedValue,
                TimetableId = 1,
                UserId = 1
            };

            Console.WriteLine("Insert Student: " + lecturer.LecturerName);
            Console.WriteLine("Gender: " + lecturer.LecturerGender);
            Console.WriteLine("CourseId: " + lecturer.CourseId);
            Console.WriteLine("UserId: " + lecturer.UserId);

            lecturerController.AddLecturer(lecturer);
            LoadLecturer();
            ClearForm();
            MessageBox.Show("Lecturer Added Successfully");
        }
        private void ClearInputs() 
        {
            lename.Text = "";
            lenic.Text = "";
            cmdCourse.Text = "";
            leaddress.Text = "";
            lenumber.Text = "";
            leemail.Text = "";
        }
        private void btn_update_Click(object sender, EventArgs e)
        {
            if (selectedLecturerId == -1)
            {
                MessageBox.Show("Please select a lecturer to update.");
                return;
            }

            if (string.IsNullOrWhiteSpace(lename.Text) || string.IsNullOrWhiteSpace(lenic.Text) || string.IsNullOrWhiteSpace(cmdGender.Text) ||
                string.IsNullOrWhiteSpace(leaddress.Text) || string.IsNullOrWhiteSpace(lenumber.Text) ||
                string.IsNullOrWhiteSpace(leemail.Text) || string.IsNullOrWhiteSpace(cmdCourse.Text))
            {
                MessageBox.Show("Please must fill in all lecturer details.");
                return;
            }

            var lecturer = new Lecturer
            {
                LecturerId = selectedLecturerId,
                LecturerName = lename.Text,
                LecturerNIC = lenic.Text,
                LecturerGender = (UserGender)cmdGender.SelectedValue,
                LecturerAddress = leaddress.Text,
                LecturerPhone = lenumber.Text,
                LecturerEmail = leemail.Text,
                CourseId = (int)cmdCourse.SelectedValue,
                TimetableId = 1,
                UserId = 2
            };

            lecturerController.UpdateLectuter(lecturer);
            LoadLecturer();
            ClearForm();
            MessageBox.Show("Lecturer Updated Successfully");

        }


        private void btn_dlt_Click(object sender, EventArgs e)
        {
            if (selectedLecturerId == -1)
            {
                MessageBox.Show("Please select a lecturer to delete.");
                return;
            }

            var confirmResult = MessageBox.Show("Are you sure to delete this lecturer?", "Confirm Delete", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                lecturerController.DeleteLecturer(selectedLecturerId);
                LoadLecturer();
                ClearForm();
                MessageBox.Show("Lecturer Deleted Successfully");

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void ViewLecturer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

           //Can't use
        }

        private void cmdCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void cmdGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void ViewLecturer_SelectionChanged(object sender, EventArgs e)
        {
            if (ViewLecturer.SelectedRows.Count > 0)
            {
                var row = ViewLecturer.SelectedRows[0];
                var letrureView = row.DataBoundItem as Lecturer;

                if (letrureView != null)
                {
                    selectedLecturerId = letrureView.LecturerId;
                    lename.Text = letrureView.LecturerName;
                    lenic.Text = letrureView.LecturerNIC;
                    cmdGender.SelectedItem = letrureView.LecturerGender;
                    leemail.Text = letrureView.LecturerEmail;
                    leaddress.Text = letrureView.LecturerAddress;
                    lenumber.Text = letrureView.LecturerPhone;
                    //cmdCourse.SelectedValue = letrureView.CourseId;

                    if (cmdCourse.ValueMember != "" && cmdCourse.Items.Count > 0)
                    {
                        cmdCourse.SelectedValue = letrureView.CourseId;
                    }
                }
            }
            else
            {
                ClearInputs();
                selectedLecturerId = -1;
            }
        }

        private void lesearch_TextChanged(object sender, EventArgs e)
        {
            var lecturerController = new LecturerController();
            ViewLecturer.DataSource = lecturerController.SearchLecturer(lesearch.Text.Trim());
        }
    }
}

