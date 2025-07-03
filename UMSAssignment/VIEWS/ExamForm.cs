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
    public partial class ExamForm : Form
    {
        private int selectedExamId = -1;
        ExamController controller = new ExamController();

        public ExamForm()
        {
            InitializeComponent();

            //LoadFormControls();

            cmbExamName.DataSource = Enum.GetValues(typeof(UserExam));
            cmbSubject.DataSource = Enum.GetValues(typeof(UserSubject));
            dgvExamList.AutoGenerateColumns = true;
            LoadExamGrid();
        }
        private void LoadExamGrid()
        {
            dgvExamList.DataSource = new ExamController().GetAllExams();
        }

        private void ClearForm()
        {
            cmbExamName.SelectedIndex = 0;
            cmbSubject.SelectedIndex = 0;
            selectedExamId = -1;
            dgvExamList.ClearSelection();
        }


        private void btn_add_Click(object sender, EventArgs e)
        {
            try
            {
                var exam = new Exam
                {
                    ExamName = (UserExam)cmbExamName.SelectedItem,
                    SubjectId = (UserSubject)cmbSubject.SelectedItem
                };

                MessageBox.Show(controller.AddExam(exam));
                LoadExamGrid();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Add error: " + ex.Message);
            }
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            if (selectedExamId == -1)
            {
                MessageBox.Show("Please select an option.");
                return;
            }

            try
            {
                var exam = new Exam
                {
                    ExamId = selectedExamId,
                    ExamName = (UserExam)cmbExamName.SelectedItem,
                    SubjectId = (UserSubject)cmbSubject.SelectedItem
                };

                MessageBox.Show(controller.UpdateExam(exam));
                LoadExamGrid();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update error: " + ex.Message);
            }
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void btn_dlt_Click(object sender, EventArgs e)
        {
            if (selectedExamId == -1)
            {
                MessageBox.Show("Please select an option.");
                return;
            }

            try
            {
                MessageBox.Show(controller.DeleteExam(selectedExamId));
                LoadExamGrid();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Delete error: " + ex.Message);
            }
        }

        private void dgvExamList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    var row = dgvExamList.Rows[e.RowIndex];
                    selectedExamId = Convert.ToInt32(row.Cells["ExamId"].Value);
                    cmbExamName.SelectedItem = Enum.Parse(typeof(UserExam), row.Cells["ExamName"].Value.ToString());
                    cmbSubject.SelectedItem = Enum.Parse(typeof(UserSubject), row.Cells["SubjectId"].Value.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Row select error: " + ex.Message);
            }
        }
    }
}
