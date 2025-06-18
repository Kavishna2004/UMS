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
        public LecturerForm()
        {
            InitializeComponent();
            lecturerController = new LecturerController();
            courseController = new CourseController();

            LoadLecturer();
            LoadCourse();
        }
        private void LoadLecturer()
        {
            ViewLecturer.DataSource = null;
            ViewLecturer.DataSource = lecturerController.GetAllLecture();

            if (ViewLecturer.Columns.Contains("CourseId"))
            {
                ViewLecturer.Columns["CourseId"].Visible = false;
            }
            ViewLecturer.ClearSelection();
        }
        private void LoadCourse()
        {
            var courses = lecturerController.GetAllLecture();
            cmdCourse.DataSource = courses;
            cmdCourse.DisplayMember = "Name";
            cmdCourse.ValueMember = "Id";
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
            cmdCourse.Items.Add("Web Development");
            cmdCourse.Items.Add("Artificial Intelligent");
            cmdCourse.Items.Add("");
            cmdCourse.Items.Add("C");
            cmdCourse.Items.Add("HTML");
            cmdCourse.Items.Add("Java Script");

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
                MessageBox.Show("Please must fill in all student details.");
                return;
            }
            if (cmdCourse.SelectedValue == null) 
            {
                MessageBox.Show("Please select a course!");
                return;
            }
            var lecturer = new Lecturer 
            {
                LecturerName= lename.Text,
                LecturerNIC= lenic.Text,
                LecturerGender = (UserGender)cmdGender.SelectedItem,
                LecturerAddress = leaddress.Text,
                LecturerPhone = lenumber.Text,
                LecturerEmail=leemail.Text,
                CourseId= (UserCourse)cmdCourse.SelectedValue,
            };
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
                LecturerName = lename.Text,
                LecturerNIC = lenic.Text,
                LecturerGender = (UserGender)cmdGender.SelectedValue,
                LecturerAddress = leaddress.Text,
                LecturerPhone = lenumber.Text,
                LecturerEmail = leemail.Text,
                CourseId = (UserCourse)cmdCourse.SelectedValue,
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
                MessageBox.Show("Please select a student to delete.");
                return;
            }

            var confirmResult = MessageBox.Show("Are you sure to delete this student?", "Confirm Delete", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                lecturerController.DeleteLecturer(selectedLecturerId);
                LoadLecturer();
                ClearForm();
                MessageBox.Show("Student Deleted Successfully");

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void ViewLecturer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)  
            {
                var lecturerView = ViewLecturer.Rows[e.RowIndex].DataBoundItem as Lecturer;
                if (lecturerView != null)
                {
                    selectedLecturerId = lecturerView.Id;  
                    var lecturer = lecturerController.GetLecturerById(selectedLecturerId);  

                    if (lecturer != null)
                    {
                        lename.Text = lecturer.LecturerName;
                        lenic.Text = lecturer.LecturerNIC;
                        cmdGender.SelectedValue = lecturer.LecturerGender;
                        leemail.Text = lecturer.LecturerEmail;
                        leaddress.Text = lecturer.LecturerAddress;
                        lenumber.Text = lecturer.LecturerPhone;
                        cmdCourse.SelectedValue = lecturer.CourseId;
                    }
                }
            }
            else
            {
                ClearInputs();
                selectedLecturerId = -1;
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

        private void cmdGender_SelectedIndexChanged(object sender, EventArgs e)
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
    }
}
/*// Form Load or Initialization
cmdGender.DataSource = Enum.GetValues(typeof(UserGender));

// Assigning selected lecturer details
if (lecturer != null)
{
    lename.Text = lecturer.LecturerName;
    lenic.Text = lecturer.LecturerNIC;
    cmdGender.SelectedItem = lecturer.LecturerGender; // Enum value
    leaddress.Text = lecturer.LecturerAddress;
    lenumber.Text = lecturer.LecturerPhone;
    leemail.Text = lecturer.LecturerEmail;
    cmdCourse.SelectedValue = lecturer.CourseId;
}*/
