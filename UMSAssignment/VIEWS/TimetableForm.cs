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
        private TimetableController tc = new TimetableController();
        private int selectedId = -1;
        //private string currentRole;

        private bool isLoadingSelection = false; 

        public TimetableForm(string role)
        {
            InitializeComponent();
            //currentRole = role;

            cmdSubject.DataSource = Enum.GetValues(typeof(UserSubject));
            cmbDay.DataSource = Enum.GetValues(typeof(UserTimeslot));
            cmdRoom.DataSource = Enum.GetValues(typeof(UserRoom));

            //LoadControl();
            LoadSubjects();
            RefreshGrid();

            ViewTimetable.SelectionChanged += ViewTimetable_SelectionChanged;
        }

        private void LoadSubjects()
        {
            try
            {
                cmdSubject.DataSource = Enum.GetValues(typeof(UserSubject));
            }
            catch (Exception ex)
            {
                MessageBox.Show("LoadSubjects Error: " + ex.Message);
            }
        }
        private void RefreshGrid()
        {
            try
            {
                ViewTimetable.SelectionChanged -= ViewTimetable_SelectionChanged;

                var dt = tc.GetTimetableWithNames();
                ViewTimetable.AutoGenerateColumns = true;
                ViewTimetable.DataSource = dt;

                foreach (DataGridViewColumn col in ViewTimetable.Columns)
                {
                    col.Visible = true;
                }

                MessageBox.Show("🟢 Rows loaded: " + dt.Rows.Count);

                if (ViewTimetable.Columns["TimetableId"] != null)
                    ViewTimetable.Columns["TimetableId"].Visible = false;

                ViewTimetable.ClearSelection();
                selectedId = -1;

                ViewTimetable.SelectionChanged += ViewTimetable_SelectionChanged;
            }
            catch (Exception ex)
            {
                MessageBox.Show("RefreshGrid Error: " + ex.Message);
            }
        }



        /*private void LoadControl()
        {
            if (currentRole == "Admin")
            {
                btn_add.Visible = true;
                btn_update.Visible = true;
                btn_dlt.Visible = true;
                ViewTimetable.ReadOnly = true;
            }

            else if (currentRole == "Lecturer" || currentRole == "Student" || currentRole == "Staff")
            {
                btn_add.Visible = false;
                btn_update.Visible = false;
                btn_dlt.Visible = false;
                ViewTimetable.ReadOnly = true;

            }
        }*/

        private void btn_add_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmdSubject.SelectedItem == null)
                {
                    MessageBox.Show("Please select a subject.");
                    return;
                }
                UserSubject selectedSubject = (UserSubject)cmdSubject.SelectedItem;

                var newT = new Timetable
                {
                    SubjectId = selectedSubject,
                    Timeslot = (UserTimeslot)cmbDay.SelectedItem,
                    RoomId = (UserRoom)cmdRoom.SelectedItem
                };

                MessageBox.Show(tc.AddTimetable(newT));
                RefreshGrid();
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
                    MessageBox.Show("Select a timetable to update.");
                    return;
                }
                if (cmdSubject.SelectedIndex == -1) 
                {
                    MessageBox.Show("Select a subject to update.");
                    return;
                }
                UserSubject selectedSubject = (UserSubject)cmdSubject.SelectedIndex;

                var t = new Timetable
                {
                    TimetableId = selectedId,
                    SubjectId = selectedSubject,
                    Timeslot = (UserTimeslot)cmbDay.SelectedItem,
                    RoomId = (UserRoom)cmdRoom.SelectedItem
                };

                MessageBox.Show(tc.UpdateTimetable(t));
                RefreshGrid();
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

                MessageBox.Show(tc.DeleteTimetable(selectedId));
                RefreshGrid();
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
                {
                    selectedId = -1;
                    return;
                }

                var row = ViewTimetable.SelectedRows[0];

                if (row.Cells["TimetableId"].Value == null)
                {
                    selectedId = -1;
                    return;
                }

                selectedId = Convert.ToInt32(row.Cells["TimetableId"].Value);

                var subjVal = row.Cells["SubjectId"].Value;
                if (subjVal != null && Enum.TryParse(subjVal.ToString(), out UserSubject us))
                {
                    cmdSubject.SelectedItem = us;
                }

                var tsVal = row.Cells["Timeslot"].Value;
                if (tsVal != null && Enum.TryParse(tsVal.ToString(), out UserTimeslot ut))
                {
                    cmbDay.SelectedItem = ut;
                }

                var roomVal = row.Cells["RoomId"].Value;
                if (roomVal != null && Enum.TryParse(roomVal.ToString(), out UserRoom ur))
                {
                    cmdRoom.SelectedItem = ur;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("SelectionChanged Error: " + ex.Message);
            }
        }
    }
}
