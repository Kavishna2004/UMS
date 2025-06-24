using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
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
using UMSAssignment.REPOSITORIE;
using UMSAssignment.VIEWS;

namespace UMSAssignment.VIEWS
{
    public partial class StaffForm : Form
    {
        private int selectedStaffId = -1;
        private string currentRole;

        public StaffForm(string role)
        {
            InitializeComponent();
            currentRole = role;

            cmdz.DataSource = Enum.GetValues(typeof(UserGender));

            LoadStaff();
            LoadCourse();
            LoadControl();
        }
        private void LoadControl()
        {
            btn_add.Visible = false;
            btn_update.Visible = false;
            btn_dlt.Visible = false;
            btn_clear.Visible = false;
            stasearch.Visible = false;
            ViewStaffs.ReadOnly = true;


            if (currentRole != null && currentRole.ToLower() == "admin")
            {
                btn_add.Visible = true;
                btn_update.Visible = true;
                btn_dlt.Visible = true;
                btn_clear.Visible = true;
                stasearch.Visible = true;
                ViewStaffs.ReadOnly = false;
            }

            else if (currentRole.ToLower() == "lecturer" || currentRole.ToLower() == "student" || currentRole.ToLower() == "staff")
            {

                ViewStaffs.ReadOnly = true;
            }
        }
        private void LoadStaff()
        {
            var staffController = new StaffController();
            ViewStaffs.DataSource = staffController.GetAllStaffs();
        }
        private void LoadCourse()
        {
            try
            {
                using (var conn = DbConfig.GetConnection())
                {
                    string query = "SELECT CourseId, CourseName FROM Courses";
                    using (var adapter = new SQLiteDataAdapter(query, conn))
                    {
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        cmdCourse.DisplayMember = "CourseName";
                        cmdCourse.ValueMember = "CourseId";
                        cmdCourse.DataSource = table;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Course load failed: " + ex.Message);
            }
        }
        private void ClearForm() 
        {
            selectedStaffId = -1;
            staname.Clear();
            stanic.Clear();
            staaddress.Clear();
            stasearch.Clear();
            cmdz.SelectedIndex = -1;
            cmdCourse.SelectedIndex = -1;
        }
        private void StaffForm_Load(object sender, EventArgs e)
        {

        }

        private void btn_dlt_Click(object sender, EventArgs e)
        {
            if (selectedStaffId == -1)
            {
                MessageBox.Show("Please select a staff from the table to delete.");
                return;
            }

            var staffController = new StaffController();
            MessageBox.Show(staffController.DeleteStaff(selectedStaffId));
            LoadStaff();
            ClearForm();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            var staff = new Staff
            {
                StaffName = staname.Text,
                StaffNIC = stanic.Text,
                StaffGender = (UserGender)cmdz.SelectedItem,
                StaffAddress = staaddress.Text,
                CourseId = Convert.ToInt32(cmdCourse.SelectedValue),
                //UserId = int.Parse(txtUserId.Text)
            };

            var staffController = new StaffController();
            MessageBox.Show(staffController.AddStaff(staff));
            LoadStaff();
            ClearForm();
        }
       
        private void btn_update_Click(object sender, EventArgs e)
        {
            if (selectedStaffId == -1)
            {
                MessageBox.Show("Please select a staff from the table to update.");
                return;
            }

            var staff = new Staff
            {
                StaffId = selectedStaffId,
                StaffName = staname.Text,
                StaffNIC = stanic.Text,
                StaffGender = (UserGender)cmdz.SelectedItem,
                StaffAddress = staaddress.Text,
                CourseId = Convert.ToInt32(cmdCourse.SelectedValue),
                //UserId = int.Parse(txtUserId.Text)
            };

            var staffController = new StaffController();
            MessageBox.Show(staffController.UpdateStaff(staff));
            LoadStaff();
            ClearForm();

        }

        private void staaddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmdz_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void cmdCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
           
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
                selectedStaffId = Convert.ToInt32(row.Cells["StaffId"].Value);

                staname.Text = row.Cells["StaffName"].Value.ToString();
                stanic.Text = row.Cells["StaffNIC"].Value.ToString();
                cmdz.SelectedItem = Enum.Parse(typeof(UserGender), row.Cells["StaffGender"].Value.ToString());
                staaddress.Text = row.Cells["StaffAddress"].Value.ToString();
                cmdCourse.SelectedValue = Convert.ToInt32(row.Cells["CourseId"].Value);
                //txtUserId.Text = row.Cells["UserId"].Value.ToString();
            }
        }

        private void stasearch_TextChanged(object sender, EventArgs e)
        {
            var staffController = new StaffController();
            ViewStaffs.DataSource = staffController.SearchStaffs(stasearch.Text.Trim());
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }
    }
    
}
