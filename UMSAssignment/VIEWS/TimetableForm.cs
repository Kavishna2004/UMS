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
using static System.Windows.Forms.AxHost;

namespace UMSAssignment.VIEWS
{
    public partial class TimetableForm : Form
    {
        private TimetableController timetableController = new TimetableController();
        private SubjectController subjectController = new SubjectController();
        private int selectedId = -1;

        private string currentRole;

        public TimetableForm(string role)
        {
            InitializeComponent();
            cmbDay.DataSource = Enum.GetValues(typeof(UserTimeslot));
            cmdRoom.DataSource = Enum.GetValues(typeof(UserRoom));

            currentRole = role;

            LoadTimetables();
            LoadSubjects();
            LoadControl();
        }
        private void LoadSubject()
        {
            ViewTimetable.DataSource = null;
            ViewTimetable.DataSource = subjectController.GetAllSubjects();

            if (ViewTimetable.Columns.Contains("subjectId"))
            {
                ViewTimetable.Columns["subjectId"].Visible = false;
            }
            ViewTimetable.ClearSelection();
            if (cmdSubject.SelectedValue == null)
            {
                MessageBox.Show("Please select a subject!");
                return;
            }
        }
        private void LoadTimetables()
        {
            try
            {
                ViewTimetable.DataSource = null;
                var all = timetableController.GetAllTimetables();

                ViewTimetable.DataSource = all;

                if (ViewTimetable.Columns.Contains("TimetableId"))
                    ViewTimetable.Columns["TimetableId"].Visible = false;

                selectedId = -1;
                cmbDay.SelectedIndex = 0;
                cmdRoom.SelectedIndex = 0;
                selectedId = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Load Error: " + ex.Message);
            }
        }
        private void LoadControl()
        {
            btn_add.Visible = true;
            btn_update.Visible = true;
            btn_dlt.Visible = true;
            ViewTimetable.ReadOnly = true;

            if (currentRole == "Admin")
            {
                btn_add.Visible = true;
                btn_update.Visible = true;
                btn_dlt.Visible = true;
                ViewTimetable.ReadOnly = false;

            }
            else if (currentRole == "Lecturer" || currentRole == "Student" || currentRole == "Staff")
            {
                btn_add.Visible = false;
                btn_update.Visible = false;
                btn_dlt.Visible = false;
                ViewTimetable.ReadOnly = true;
            }
        }
        private void LoadSubjects()
        {
            var courses = subjectController.GetAllSubjects();
            cmdSubject.DataSource = courses;
            cmdSubject.DisplayMember = "CourseName";
            cmdSubject.ValueMember = "CourseId";
        }
        private void btn_add_Click(object sender, EventArgs e)
        {
            try
            {
                UserSubject subject = (UserSubject)cmdSubject.SelectedItem;
                UserTimeslot day = (UserTimeslot)cmbDay.SelectedItem;
                UserRoom room = (UserRoom)cmdRoom.SelectedItem;

                Timetable t = new Timetable
                {
                    SubjectId = subject,
                    Timeslot = day,
                    RoomId = room
                };

                MessageBox.Show(timetableController.AddTimetable(t));
                LoadTimetables();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Add Error: " + ex.Message);
            }
        }
        
        private void btn_update_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedId == -1)
                {
                    MessageBox.Show("Select a timetable first.");
                    return;
                }

                UserSubject subject = (UserSubject)cmdSubject.SelectedItem;
                UserTimeslot day = (UserTimeslot)cmbDay.SelectedItem;
                UserRoom room = (UserRoom)cmdRoom.SelectedItem;

                Timetable t = new Timetable
                {
                    TimetableId = selectedId,
                    SubjectId = subject,
                    Timeslot = day,
                    RoomId = room
                };

                MessageBox.Show(timetableController.UpdateTimetable(t));
                LoadTimetables();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update Error: " + ex.Message);
            }

        }

        private void btn_dlt_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedId == -1)
                {
                    MessageBox.Show("Select a timetable to delete.");
                    return;
                }

                MessageBox.Show(timetableController.DeleteTimetable(selectedId));
                selectedId = -1;
                LoadTimetables();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Delete Error: " + ex.Message);
            }
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

        private void ViewTimetable_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (ViewTimetable.SelectedRows.Count == 0)
                    return;

                DataGridViewRow row = ViewTimetable.SelectedRows[0];

                selectedId = Convert.ToInt32(row.Cells["TimetableId"].Value);
                cmdSubject.SelectedValue = row.Cells["SubjectId"].Value;
                cmbDay.SelectedItem = Enum.Parse(typeof(UserTimeslot), row.Cells["Timeslot"].Value.ToString());
                cmdRoom.SelectedItem = Enum.Parse(typeof(UserRoom), row.Cells["RoomId"].Value.ToString());
            }
            
            catch (Exception ex)
            {
                MessageBox.Show("Selection Error: " + ex.Message);
            }
        }
    }
}
