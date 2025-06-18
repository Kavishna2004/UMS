using SchoolManageSystem.Controllers;
using SchoolManageSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace SchoolManageSystem
{
    public partial class StudentForm : Form
    {
        private readonly StudentController _studentController;
        private readonly SectionController _sectionController;
        private int selectedStudentId = -1;

        public StudentForm()
        {
            InitializeComponent();
            _studentController = new StudentController();
            _sectionController = new SectionController();

            LoadStudents();
            LoadSections();
        }

        private void LoadStudents()
        {
            dgvStudents.DataSource = null;
            dgvStudents.DataSource = _studentController.GetAllStudents();

            // Hide the SectionId column if it exists
            if (dgvStudents.Columns.Contains("SectionId"))
            {
                dgvStudents.Columns["SectionId"].Visible = false;
            }

            dgvStudents.ClearSelection();
        }

        private void LoadSections()
        {
            var sections = _sectionController.GetAllSections();
            cmbSection.DataSource = sections;
            cmbSection.DisplayMember = "Name";
            cmbSection.ValueMember = "Id";
        }

        private void ClearForm()
        {
            name.Clear();
            address.Clear();
            cmbSection.SelectedIndex = -1;
            selectedStudentId = -1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(name.Text) || string.IsNullOrWhiteSpace(address.Text))
            {
                MessageBox.Show("Please enter both Name and Address.");
                return;
            }

            if (cmbSection.SelectedValue == null)
            {
                MessageBox.Show("Please select a section.");
                return;
            }

            var student = new Student
            {
                Name = name.Text,
                Address = address.Text,
                SectionId = (int)cmbSection.SelectedValue
            };

            _studentController.AddStudent(student);
            LoadStudents();
            ClearForm();
            MessageBox.Show("Student Added Successfully");            

        }


        private void ClearInputs()
        {
            name.Text = "";
            address.Text = "";
        }

        private void dgvStudents_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvStudents.SelectedRows.Count > 0)
            {
                var row = dgvStudents.SelectedRows[0];
                var studentView = row.DataBoundItem as Student;

                if (studentView != null)
                {
                    selectedStudentId = studentView.Id;
                    
                    var student = _studentController.GetStudentById(selectedStudentId);
                    if (student != null)
                    {
                        name.Text = student.Name;
                        address.Text = student.Address;
                        cmbSection.SelectedValue = student.SectionId;
                    }
                }
            }
            else
            {
                ClearInputs();
                selectedStudentId = -1;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (selectedStudentId == -1)
            {
                MessageBox.Show("Please select a student to update.");
                return;
            }

            if (string.IsNullOrWhiteSpace(name.Text) || string.IsNullOrWhiteSpace(address.Text))
            {
                MessageBox.Show("Please enter both Name and Address.");
                return;
            }

            var student = new Student
            {
                Id = selectedStudentId,
                Name = name.Text,
                Address = address.Text,
                SectionId = (int)cmbSection.SelectedValue
            };

            _studentController.UpdateStudent(student);
            LoadStudents();
            ClearForm();
            MessageBox.Show("Student Updated Successfully");
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (selectedStudentId == -1)
            {
                MessageBox.Show("Please select a student to delete.");
                return;
            }

            var confirmResult = MessageBox.Show("Are you sure to delete this student?", "Confirm Delete", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                _studentController.DeleteStudent(selectedStudentId);
                LoadStudents();
                ClearForm();
                MessageBox.Show("Student Deleted Successfully");
                
            }
        }

        private void dgvStudents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
