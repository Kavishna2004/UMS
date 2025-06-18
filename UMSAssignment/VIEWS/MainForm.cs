using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UMSAssignment.MODELS;

namespace UMSAssignment.VIEWS
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            /*LoadForm(new MainForm());*/
        }

        public void LoadForm(object formObject) 
        {
            if (this.MainPanel.Controls.Count > 0)
            {
                this.MainPanel.Controls.RemoveAt(0);
            }

            Form form = formObject as Form;
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            this.MainPanel.Controls.Add(form);
            this.MainPanel.Tag = form;
            form.Show();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_register_Click(object sender, EventArgs e)
        {
            LoadForm(new RegisterForm());
            //MessageBox.Show("Registation Successfull!");
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            LoadForm(new LoginForm());
            //MessageBox.Show("Login Successfull!");
        }
    }
}
