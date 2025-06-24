using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UMSAssignment.CONTROLLERS;
using UMSAssignment.ENUMS;
using UMSAssignment.MODELS;
using UMSAssignment.REPOSITORIE;

namespace UMSAssignment.VIEWS
{
    public partial class AttendanceForm : Form
    {
        int selectedId = -1;
        private string currentRole;
        public AttendanceForm(string role)
        {
            InitializeComponent();
            currentRole = role;

            cmbStatus.DataSource = Enum.GetValues(typeof(UserAttendance));

            LoadStudents();
            LoadTimetables();
            LoadControl();

            LoadAttendanceData();
        }
        private void LoadControl()
        {
          
            btn_add.Visible = true;
            btn_update.Visible = true;
            btn_dlt.Visible = true;
            btn_clear.Visible = true;
            ViewAttendance.ReadOnly = true;

           
            if (currentRole != null && currentRole == "Admin")
            {
                btn_add.Visible = true;
                btn_update.Visible = true;
                btn_dlt.Visible = true;
                btn_clear.Visible = true;
                ViewAttendance.ReadOnly = false;
            }
           
            else if (currentRole == "Lecturer" || currentRole == "Student" || currentRole == "Staff")
            {

                ViewAttendance.ReadOnly = true;
            }
        }
        private void LoadStudents()
        {
            try
            {
                using (var conn = DbConfig.GetConnection())
                {
                    string query = "SELECT StudentId, StudentName FROM Students";
                    using (var adapter = new SQLiteDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        cmbStudent.DataSource = dt;
                        cmbStudent.DisplayMember = "StudentName";
                        cmbStudent.ValueMember = "StudentId";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Student load error: " + ex.Message);
            }
        }

        private void LoadTimetables()
        {
            try
            {
                using (var conn = DbConfig.GetConnection())
                {
                    string query = "SELECT TimetableId FROM Timetables"; // Simplified
                    using (var adapter = new SQLiteDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        cmbTimetable.DataSource = dt;
                        cmbTimetable.ValueMember = "TimetableId";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Timetable load error: " + ex.Message);
            }
        }
        private void LoadAttendanceData()
        {
            try
            {
                var controller = new AttendanceController();
                ViewAttendance.AutoGenerateColumns = true;
                ViewAttendance.DataSource = controller.GetAllAttendances();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Load failed: " + ex.Message);
            }
        }
        private void ClearForm()
        {
            dtTimestamp.Value = DateTime.Now;
            cmbStatus.SelectedIndex = 0;
            cmbStudent.SelectedIndex = -1;
            cmbTimetable.SelectedIndex = -1;
            selectedId = -1;
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            try
            {
                var attendance = new Attendance
                {
                    Timestamp = dtTimestamp.Value.ToString("yyyy-MM-dd HH:mm:ss"),
                    Status = (UserAttendance)cmbStatus.SelectedItem,
                    StudentId = Convert.ToInt32(cmbStudent.SelectedValue),
                    TimetableId = Convert.ToInt32(cmbTimetable.SelectedValue)
                };

                var controller = new AttendanceController();
                MessageBox.Show(controller.AddAttendance(attendance));

                LoadAttendanceData();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Add failed: " + ex.Message);
            }
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            if (selectedId == -1)
            {
                MessageBox.Show("Please select a record.");
                return;
            }

            try
            {
                var attendance = new Attendance
                {
                    AttendanceId = selectedId,
                    Timestamp = dtTimestamp.Value.ToString("yyyy-MM-dd HH:mm:ss"),
                    Status = (UserAttendance)cmbStatus.SelectedItem,
                    StudentId = Convert.ToInt32(cmbStudent.SelectedValue),
                    TimetableId = Convert.ToInt32(cmbTimetable.SelectedValue)
                };

                var controller = new AttendanceController();
                MessageBox.Show(controller.UpdateAttendance(attendance));
                LoadAttendanceData();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update failed: " + ex.Message);
            }
        }

        private void btn_dlt_Click(object sender, EventArgs e)
        {
            if (selectedId == -1)
            {
                MessageBox.Show("Please select a record.");
                return;
            }

            try
            {
                var controller = new AttendanceController();
                MessageBox.Show(controller.DeleteAttendance(selectedId));
                LoadAttendanceData();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Delete failed: " + ex.Message);
            }
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {

        }

        private void ViewAttendance_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (ViewAttendance.SelectedRows.Count > 0)
            {
                var row = ViewAttendance.SelectedRows[0];
                selectedId = Convert.ToInt32(row.Cells["AttendanceId"].Value);

                dtTimestamp.Value = Convert.ToDateTime(row.Cells["Timestamp"].Value);
                cmbStatus.SelectedItem = Enum.Parse(typeof(UserAttendance), row.Cells["Status"].Value.ToString());
                cmbStudent.SelectedValue = Convert.ToInt32(row.Cells["StudentId"].Value);
                cmbTimetable.SelectedValue = Convert.ToInt32(row.Cells["TimetableId"].Value);
            }
        }
    }
}
