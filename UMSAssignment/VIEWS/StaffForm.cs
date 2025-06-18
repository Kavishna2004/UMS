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
using UMSAssignment.VIEWS;

namespace UMSAssignment.VIEWS
{
    public partial class StaffForm : Form
    {
        private readonly StaffController staffController;
        private readonly CourseController courseController;
        private int selectedStaffId = -1;

        public StaffForm()
        {
            InitializeComponent();
            staffController = new StaffController();
            courseController = new CourseController();

            LoadStaff();
            LoadCourse();
        }
        private void LoadStaff()
        {
            ViewStaffs.DataSource = null;
            ViewStaffs.DataSource = staffController.GetAllStaffs();

            if (ViewStaffs.Columns.Contains("CourseId"))
            {
                ViewStaffs.Columns["CourseId"].Visible = false;
            }
            ViewStaffs.ClearSelection();
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
            staname.Clear();
            stanic.Clear();
            staaddress.Clear();
            cmdz.SelectedIndex = -1;
            selectedStaffId = -1;
            cmdCourse.SelectedIndex = -1;

        }
        private void StaffForm_Load(object sender, EventArgs e)
        {

        }

        private void btn_dlt_Click(object sender, EventArgs e)
        {
            if (selectedStaffId == -1) 
            {
                MessageBox.Show("Please select a staff to delete.");
                return;
            }
            var confirmResult = MessageBox.Show("Are you sure to delete this staff?", "Confirm Delete", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                staffController.DeleteStudent(selectedStaffId);
                LoadStaff();
                ClearForm();
                MessageBox.Show("Student Deleted Successfully");

            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(staname.Text) || string.IsNullOrWhiteSpace(stanic.Text) || string.IsNullOrWhiteSpace(cmdz.Text) ||
               string.IsNullOrWhiteSpace(staaddress.Text))
            {
                MessageBox.Show("Please must fill in all staff details.");
                return;
            }

            if (cmdz.SelectedValue == null)
            {
                MessageBox.Show("Please select a section.");
                return;
            }

            var staff = new Staff
            {
                StaffName = staname.Text,
                StaffNIC = stanic.Text,
                StaffAddress = staaddress.Text,
                StaffGender = (UserGender)cmdz.SelectedValue,
                CourseId = (UserCourse)cmdCourse.SelectedValue,
                
            };

            staffController.AddStaff(staff);
            LoadStaff();
            ClearForm();
            MessageBox.Show("Staff Added Successfully");
        }
        private void ClearInputs() 
        {
            staname.Text = "";
            stanic.Text = "";
            staaddress.Text = "";
            

        }
        private void btn_update_Click(object sender, EventArgs e)
        {
            if (selectedStaffId == -1)
            {
                MessageBox.Show("Please select a staff to update.");
                return;
            }

            if (string.IsNullOrWhiteSpace(staname.Text) || string.IsNullOrWhiteSpace(stanic.Text) || string.IsNullOrWhiteSpace(cmdz.Text) ||
               string.IsNullOrWhiteSpace(staaddress.Text))
            {
                MessageBox.Show("Please enter the Details!.");
                return;
            }

            var staff = new Staff
            {
                StaffName = staname.Text,
                StaffNIC = stanic.Text,
                StaffAddress = staaddress.Text,
                StaffGender = (UserGender)cmdz.SelectedValue,
                CourseId = (UserCourse)cmdCourse.SelectedValue,
            };

            staffController.UpdateStaff(staff);
            LoadStaff();
            ClearForm();
            MessageBox.Show("Staff Updated Successfully");

        }

        private void staaddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmdz_SelectedIndexChanged(object sender, EventArgs e)
        {
            {
                cmdz.Items.Clear();
                cmdz.Items.Add("Select Gender");
                foreach (var gender in Enum.GetValues(typeof(UserGender)))
                {
                    cmdz.Items.Add(gender);
                }
                cmdz.SelectedIndex = 0;
        }
            }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void cmdCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            {
                cmdCourse.Items.Clear();
                cmdCourse.Items.Add("Select Your Course");
                foreach (var course in Enum.GetValues(typeof(UserCourse)))
                {
                    cmdCourse.Items.Add(course);
                }
                cmdCourse.SelectedIndex = 0;
            }

        }

        private void ViewStaffs_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void ViewStaffs_SelectionChanged(object sender, EventArgs e)
        {
            if (ViewStaffs.SelectedRows.Count > 0)
            {
                var row = ViewStaffs.SelectedRows[0];
                var staffView = row.DataBoundItem as Staff;

                if (staffView != null)
                {
                    selectedStaffId = staffView.StaffId;

                    var staff = staffController.GetStaffById(selectedStaffId);
                    if (staff != null)
                    {
                        staname.Text = staff.StaffName;
                        staaddress.Text = staff.StaffAddress;
                        cmdz.SelectedValue = staff.StaffGender;
                        cmdCourse.SelectedValue = staff.CourseId;
                    }
                }
            }
            else
            {
                ClearInputs();
                selectedStaffId = -1;
            }
        }

    }
    
}
