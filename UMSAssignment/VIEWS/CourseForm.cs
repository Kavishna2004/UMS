using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using UMSAssignment.CONTROLLERS;
using UMSAssignment.ENUMS;
using UMSAssignment.MODELS;

namespace UMSAssignment.VIEWS
{
    public partial class CourseForm : Form
    {
        private readonly CourseController courseController;
        private int selectedCourseId = -1;

        private string currentRole;

        public CourseForm(string role)
        {
            InitializeComponent();
            courseController = new CourseController();
            currentRole = role;

            LoadCourse();
            LoadControl();
        }

        private void LoadCourse()
        {
            var list = courseController.GetAllCourses();
            ViewCourse.AutoGenerateColumns = true;  
            ViewCourse.DataSource = null;          
            ViewCourse.DataSource = list;

        }
        private void LoadControl()
        {
            if ( currentRole == "Admin")
            {
                btn_add.Visible = true;
                btn_update.Visible = true;
                btn_dlt.Visible = true;
                csearch.Visible = true;
                ViewCourse.ReadOnly = true;
            }

            else if (currentRole == "Lecturer" || currentRole == "Student" || currentRole == "Staff")
            {
                btn_add.Visible = false;
                btn_update.Visible = false;
                btn_dlt.Visible = false;
                csearch.Visible = false;
                ViewCourse.ReadOnly = true;
             
            }
        }

        private void ViewCourse_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        private void ClearForm()
        {
            cname.Clear();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cname.Text))
            {
                MessageBox.Show("Please must fill in all course details.");
                return;
            }
           
            var course = new Course
            {
                CourseName = cname.Text,
            };

            courseController.AddCourse(course);
            LoadCourse();
            ClearForm();
            MessageBox.Show("Course Added Successfully");
        }
        private void ClearInputs()
        {
            cname.Text = "";
        }
        private void btn_update_Click(object sender, EventArgs e)
        {
            if (selectedCourseId == -1)
            {
                MessageBox.Show("Please select a course to update.");
                return;
            }

            if (string.IsNullOrWhiteSpace(cname.Text))
            {
                MessageBox.Show("Please must fill in all course details.");
                return;
            }

            var course = new Course
            {
                CourseId = selectedCourseId,   
                CourseName = cname.Text
            };


            courseController.UpdateCourse(course);
            LoadCourse();
            ClearForm();
            MessageBox.Show("Course Updated Successfully");

        }
        private void btn_dlt_Click(object sender, EventArgs e)
        {
            if (selectedCourseId == -1)
            {
                MessageBox.Show("Please select a Course to delete.");
                return;
            }

            var confirmResult = MessageBox.Show("Are you sure to delete this Course?", "Confirm Delete", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                courseController.DeleteCourse(selectedCourseId);
                LoadCourse();
                ClearForm();
                MessageBox.Show("Course Deleted Successfully");

            }

        }

        private void cmdCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        private void ViewCourse_SelectionChanged(object sender, EventArgs e)
        {
            if (ViewCourse.SelectedRows.Count > 0)
            {
                var row = ViewCourse.SelectedRows[0];
                var courseView = row.DataBoundItem as Course;

                if (courseView != null)
                {
                    selectedCourseId = courseView.CourseId;
                    cname.Text = courseView.CourseName;

                }
            }
            else
            {
                ClearInputs();
                selectedCourseId = -1;
            }
        }

        private void csearch_TextChanged(object sender, EventArgs e)
        {
            var courseController = new CourseController();
            ViewCourse.DataSource = courseController.SearchCourse(csearch.Text.Trim());
        }
    }
}
