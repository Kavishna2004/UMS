using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UMSAssignment.CONTROLLERS;
using UMSAssignment.ENUMS;
using UMSAssignment.MODELS;

namespace UMSAssignment.VIEWS
{
    public partial class SubjectForm : Form
    {
        private SubjectController subjectController = new SubjectController();
        private CourseController courseController = new CourseController();
        private int selectedId = -1;

        private string currentRole;
        public SubjectForm(string role)
        {
            InitializeComponent();
            currentRole = role;

            cmbSubjectName.DataSource = Enum.GetValues(typeof(UserSubject));

            LoadCourse();
            LoadSubject();
            LoadControl();
        }
        private void LoadControl()
        {

            btn_add.Visible = true;
            btn_update.Visible = true;
            btn_dlt.Visible = true;
            subsearch.Visible = true;
            dataGridView1.ReadOnly = true;

            if (currentRole == "Admin")
            {
                btn_add.Visible = true;
                btn_update.Visible = true;
                btn_dlt.Visible = true;
                subsearch.Visible = true;
                dataGridView1.ReadOnly = false;

            }
            else if (currentRole == "Lecturer" || currentRole == "Student" || currentRole == "Staff")
            {
                btn_add.Visible = false;
                btn_update.Visible = false;
                btn_dlt.Visible = false;
                subsearch.Visible = false;
                dataGridView1.ReadOnly = true;
            }
        }
        private void LoadCourse()
        {
            try
            {
                var courseList = courseController.GetAllCourses();
                cmbCourse.DisplayMember = "CourseName";
                cmbCourse.ValueMember = "CourseId";
                cmbCourse.DataSource = courseList;
                cmbCourse.Visible = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Course Load Error: " + ex.Message);
            }
        }
        private void LoadSubject()
        {
            try
            {
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();

                dataGridView1.Columns.Add("SubjectId", "ID");
                dataGridView1.Columns.Add("SubjectName", "Name");
                dataGridView1.Columns.Add("CourseName", "Course ");

                dataGridView1.Columns["SubjectId"].ReadOnly = true;
                //dataGridView1.Columns["CourseName"].Visible= true;

                var allSubject = subjectController.GetAllSubjects();
                var allCourse = courseController.GetAllCourses();
                foreach (var sb in allSubject)
                {
                    var courseName = allCourse.FirstOrDefault(cou => cou.CourseId == sb.CourseId)?.CourseName ?? "Unknown";
                    dataGridView1.Rows.Add(sb.SubjectId, sb.SubjectName, courseName); // ✅ Replace sb.CourseName with courseName variable

                    //var courseName = allCourse.FirstOrDefault(cou => cou.CourseId == sb.CourseId)?.CourseName ?? "Unknown";
                    //dataGridView1.Rows.Add(sb.SubjectId, sb.SubjectName, sb.CourseName);
                }

                cmbSubjectName.SelectedIndex = 0;
                cmbCourse.SelectedIndex = 0;
                selectedId = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Load Grid Error: " + ex.Message);
            }
        }



        private void subsearch_TextChanged(object sender, EventArgs e)
        {
            var subjectController = new SubjectController();
            dataGridView1.DataSource = subjectController.SearchSubject(subsearch.Text.Trim());
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            try
            {
                UserSubject subjectName = (UserSubject)cmbSubjectName.SelectedItem;
                int courseId = (int)cmbCourse.SelectedValue;

                Subject s = new Subject
                {
                    SubjectName = subjectName,
                    CourseId = courseId
                };

                MessageBox.Show(subjectController.AddSubject(s));
                LoadSubject();
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
                    MessageBox.Show("Select a subject to update.");
                    return;
                }

                UserSubject subjectName = (UserSubject)cmbSubjectName.SelectedItem;
                int courseId = (int)cmbCourse.SelectedValue;

                Subject s = new Subject
                {
                    SubjectId = selectedId,
                    SubjectName = subjectName,
                    CourseId = courseId
                };

                MessageBox.Show(subjectController.UpdateSubject(s));
                LoadSubject();
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
                    MessageBox.Show("Select a subject to delete.");
                    return;
                }

                MessageBox.Show(subjectController.DeleteSubject(selectedId));
                selectedId = -1;
                LoadSubject();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Delete Error: " + ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count == 0) return;

                DataGridViewRow row = dataGridView1.SelectedRows[0];
                selectedId = Convert.ToInt32(row.Cells["SubjectId"].Value);
                cmbSubjectName.SelectedItem = Enum.Parse(typeof(UserSubject), row.Cells["SubjectName"].Value.ToString());
                cmbCourse.SelectedValue = Convert.ToInt32(row.Cells["CourseId"].Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Selection Error: " + ex.Message);
            }
        }

        private void cmbSubjectName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
