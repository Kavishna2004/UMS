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
        private readonly TimetableController timetableController;
        private readonly SubjectController subjectController;
        private readonly RoomController roomController;
        private int selectedTimetabletId = -1;
        public TimetableForm()
        {
            InitializeComponent();
            timetableController = new TimetableController();
            subjectController = new SubjectController();
            roomController = new RoomController();

            LoadSubject();
            LoadRoom();

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
        private void LoadRoom()
        {
            var rooms = roomController.GetAllRooms();
            cmdRoom.DataSource = rooms;
            cmdRoom.DisplayMember = "RoomName";
            cmdRoom.ValueMember = "roomId";
        }
        private void ClearForm()
        {
            cmdRoom.DataSource = null;
            cmdSubject.DataSource = null;
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmdSubject.Text) || string.IsNullOrWhiteSpace(cmdRoom.Text) || string.IsNullOrWhiteSpace(ttime.Text))
            {
                MessageBox.Show("Please must fill in all Timetable details.");
                return;
            }

            if (cmdSubject.SelectedValue == null)
            {
                MessageBox.Show("Please select a subject.");
                return;
            }

            if (cmdRoom.SelectedValue == null)
            {
                MessageBox.Show("Please select a Room.");
                return;
            }

            var timetable = new Timetable
            {
                SubjectId = (UserSubject)cmdSubject.SelectedValue,
                RoomId = (UserRoom)cmdRoom.SelectedValue,
                TimeSlot = ttime.Text,
            };

            timetableController.AddTimetable(timetable);
            LoadSubject();
            LoadRoom();
            ClearForm();
            MessageBox.Show("Timetable Added Successfully");
        }
        private void ClearInputs()
        {
            cmdSubject.Text = "";
            cmdRoom.Text = "";
            ttime.Text = "";
        }


        private void btn_update_Click(object sender, EventArgs e)
        {
            if (selectedTimetabletId == -1)
            {
                MessageBox.Show("Please select a timetable to update hear.");
                return;
            }

            if (string.IsNullOrWhiteSpace(cmdSubject.Text) || string.IsNullOrWhiteSpace(cmdRoom.Text) || string.IsNullOrWhiteSpace(ttime.Text))
            {
                MessageBox.Show("Please must fill in all timetable details.");
                return;
            }

            var timetable = new Timetable
            {
                SubjectId = (UserSubject)cmdSubject.SelectedValue,
                RoomId = (UserRoom)cmdRoom.SelectedValue,
                TimeSlot = ttime.Text,
            };

            timetableController.UpdateTimetable(timetable);
            LoadSubject();
            LoadRoom();
            ClearForm(); 
            MessageBox.Show("Timetable Updated Successfully");

        }

        private void btn_dlt_Click(object sender, EventArgs e)
        {
            if (selectedTimetabletId == -1)
            {
                MessageBox.Show("Please select a timetable to delete.");
                return;
            }

            var confirmResult = MessageBox.Show("Are you sure to delete this student?", "Confirm Delete", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                timetableController.DeleteTimetable(selectedTimetabletId);
                LoadSubject();
                LoadRoom();
                ClearForm();
                MessageBox.Show("Timetable Deleted Successfully");
            }
        }

        private void cmdSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            {
                cmdSubject.Items.Clear();
                cmdSubject.Items.Add("Select Subject");
                foreach (var subject in Enum.GetValues(typeof(UserSubject)))
                {
                    cmdSubject.Items.Add(subject);
                }
                cmdSubject.SelectedIndex = 0;
            }
        }
        private void cmdRoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            {
                cmdRoom.Items.Clear();
                cmdRoom.Items.Add("Select Room");
                foreach (var room in Enum.GetValues(typeof(UserRoom)))
                {
                    cmdRoom.Items.Add(room);
                }
                cmdRoom.SelectedIndex = 0;
            }
        }

        private void ViewTimetable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (ViewTimetable.SelectedRows.Count > 0)
            {
                var row = ViewTimetable.SelectedRows[0];
                var timetableView = row.DataBoundItem as Timetable;

                if (timetableView is Timetable timetable)
                {
                    selectedTimetabletId = timetableView.TimetableId;

                    var timetables = timetableController.GetTimetableById(selectedTimetabletId);
                    if (timetables != null)
                    {
                        ttime.Text = timetables.Timeslot;
                        cmdSubject.SelectedValue = (UserSubject)timetables.SubjectId;
                        cmdRoom.SelectedValue = (UserRoom)timetables.RoomId;
                    }
                }
            }
            else
            {
                ClearInputs();
                selectedTimetabletId = -1;
            }
        }
    }
}
