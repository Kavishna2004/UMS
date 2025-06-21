using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
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

            cmdz.DataSource = Enum.GetValues(typeof(UserGender));
            cmdTime.DataSource = Enum.GetValues(typeof(UserTimeslot));

            LoadStaff();
            LoadCourse();
        }
        private void LoadStaff()
        {
            var staffs = staffController.GetAllStaffs();
            ViewStaffs.DataSource = staffs;

            MessageBox.Show("Staffs count: " + staffs.Count);

            ViewStaffs.DataSource = null;
            ViewStaffs.DataSource = staffs;
            //ViewStaffs.Columns.Clear();
            //ViewStaffs.DataSource = staffController.GetAllStaffs();/*
            
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
            var courses = courseController.GetAllCourses();
            cmdCourse.DataSource = courses;
            cmdCourse.DisplayMember = "CourseName";
            cmdCourse.ValueMember = "CourseId";
        }
        private void ClearForm() 
        {
            staname.Clear();
            stanic.Clear();
            staaddress.Clear();
            cmdCourse.SelectedIndex = -1;
            cmdTime.SelectedIndex = -1;
            cmdz.SelectedIndex = -1;
            selectedStaffId = -1;
           

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
                staffController.DeleteStaff(selectedStaffId);
                LoadStaff();
                ClearForm();
                MessageBox.Show("Staff Deleted Successfully");

            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(staname.Text) || string.IsNullOrWhiteSpace(stanic.Text) || string.IsNullOrWhiteSpace(cmdz.Text) ||
               string.IsNullOrWhiteSpace(staaddress.Text) || string.IsNullOrWhiteSpace(cmdTime.Text))
            {
                MessageBox.Show("Please must fill in all staff details.");
                return;
            }

            if (cmdz.SelectedValue == null)
            {
                MessageBox.Show("Please select a course.");
                return;
            }

            var staff = new Staff
            {
                StaffName = staname.Text,
                StaffNIC = stanic.Text,
                StaffAddress = staaddress.Text,
                StaffGender = (UserGender)cmdz.SelectedValue,
                Timeslot = (UserTimeslot)cmdTime.SelectedValue,
                CourseId = (int)cmdCourse.SelectedValue,
                UserId = 3
                
            };

            Console.WriteLine("Inserted Staff: " + staff.StaffName);
            Console.WriteLine("Gender: " + (int)staff.StaffGender);
            Console.WriteLine("Timeslot: " + (int)staff.Timeslot);
            Console.WriteLine("CourseId: " + staff.CourseId);
            Console.WriteLine("UserId: " + staff.UserId);



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
                Timeslot = (UserTimeslot)cmdTime.SelectedValue,
                CourseId = (int)cmdCourse.SelectedValue,
                UserId = 3
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
            /*{
                cmdz.Items.Clear();
                cmdz.Items.Add("Select Gender");
                foreach (var gender in Enum.GetValues(typeof(UserGender)))
                {
                    cmdz.Items.Add(gender);
                }
                cmdz.SelectedIndex = 0;
            }*/
        }

               

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void cmdCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*{
                cmdCourse.Items.Clear();
                cmdCourse.Items.Add("Select Your Course");
                foreach (var course in Enum.GetValues(typeof(UserCourse)))
                {
                    cmdCourse.Items.Add(course);
                }
                cmdCourse.SelectedIndex = 0;
            }
*/
        }

        private void ViewStaffs_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           // Can't use
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
                        cmdTime.SelectedValue = staff.Timeslot;
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
