namespace UMSAssignment.VIEWS
{
    partial class StaffForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_add = new System.Windows.Forms.Button();
            this.btn_update = new System.Windows.Forms.Button();
            this.btn_dlt = new System.Windows.Forms.Button();
            this.ViewStaffs = new System.Windows.Forms.DataGridView();
            this.staname = new System.Windows.Forms.TextBox();
            this.stanic = new System.Windows.Forms.TextBox();
            this.staaddress = new System.Windows.Forms.TextBox();
            this.cmdz = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmdCourse = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ViewStaffs)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(211, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(224, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "NIC";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(202, 191);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Gender";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(200, 244);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Address";
            // 
            // btn_add
            // 
            this.btn_add.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_add.Location = new System.Drawing.Point(705, 449);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(75, 23);
            this.btn_add.TabIndex = 5;
            this.btn_add.Text = "Add";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // btn_update
            // 
            this.btn_update.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_update.Location = new System.Drawing.Point(705, 520);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(75, 23);
            this.btn_update.TabIndex = 6;
            this.btn_update.Text = "Update";
            this.btn_update.UseVisualStyleBackColor = true;
            this.btn_update.Click += new System.EventHandler(this.btn_update_Click);
            // 
            // btn_dlt
            // 
            this.btn_dlt.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_dlt.Location = new System.Drawing.Point(705, 578);
            this.btn_dlt.Name = "btn_dlt";
            this.btn_dlt.Size = new System.Drawing.Size(75, 23);
            this.btn_dlt.TabIndex = 7;
            this.btn_dlt.Text = "Delete";
            this.btn_dlt.UseVisualStyleBackColor = true;
            this.btn_dlt.Click += new System.EventHandler(this.btn_dlt_Click);
            // 
            // ViewStaffs
            // 
            this.ViewStaffs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ViewStaffs.Location = new System.Drawing.Point(153, 385);
            this.ViewStaffs.Name = "ViewStaffs";
            this.ViewStaffs.Size = new System.Drawing.Size(526, 254);
            this.ViewStaffs.TabIndex = 8;
            this.ViewStaffs.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ViewStaffs_CellContentClick);
            this.ViewStaffs.SelectionChanged += new System.EventHandler(this.ViewStaffs_SelectionChanged);
            // 
            // staname
            // 
            this.staname.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.staname.Location = new System.Drawing.Point(331, 84);
            this.staname.Name = "staname";
            this.staname.Size = new System.Drawing.Size(281, 21);
            this.staname.TabIndex = 9;
            // 
            // stanic
            // 
            this.stanic.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stanic.Location = new System.Drawing.Point(331, 137);
            this.stanic.Name = "stanic";
            this.stanic.Size = new System.Drawing.Size(281, 21);
            this.stanic.TabIndex = 10;
            // 
            // staaddress
            // 
            this.staaddress.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.staaddress.Location = new System.Drawing.Point(331, 242);
            this.staaddress.Name = "staaddress";
            this.staaddress.Size = new System.Drawing.Size(281, 21);
            this.staaddress.TabIndex = 11;
            this.staaddress.TextChanged += new System.EventHandler(this.staaddress_TextChanged);
            // 
            // cmdz
            // 
            this.cmdz.FormattingEnabled = true;
            this.cmdz.Location = new System.Drawing.Point(331, 191);
            this.cmdz.Name = "cmdz";
            this.cmdz.Size = new System.Drawing.Size(281, 21);
            this.cmdz.TabIndex = 12;
            this.cmdz.SelectedIndexChanged += new System.EventHandler(this.cmdz_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(202, 296);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 16);
            this.label6.TabIndex = 13;
            this.label6.Text = "Course";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // cmdCourse
            // 
            this.cmdCourse.FormattingEnabled = true;
            this.cmdCourse.Location = new System.Drawing.Point(331, 291);
            this.cmdCourse.Name = "cmdCourse";
            this.cmdCourse.Size = new System.Drawing.Size(281, 21);
            this.cmdCourse.TabIndex = 14;
            this.cmdCourse.SelectedIndexChanged += new System.EventHandler(this.cmdCourse_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft YaHei UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(304, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(267, 28);
            this.label7.TabIndex = 15;
            this.label7.Text = "COURSE REGISTRATION";
            // 
            // StaffForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(962, 651);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmdCourse);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmdz);
            this.Controls.Add(this.staaddress);
            this.Controls.Add(this.stanic);
            this.Controls.Add(this.staname);
            this.Controls.Add(this.ViewStaffs);
            this.Controls.Add(this.btn_dlt);
            this.Controls.Add(this.btn_update);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Name = "StaffForm";
            this.Text = "StaffForm";
            this.Load += new System.EventHandler(this.StaffForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ViewStaffs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.Button btn_update;
        private System.Windows.Forms.Button btn_dlt;
        private System.Windows.Forms.DataGridView ViewStaffs;
        private System.Windows.Forms.TextBox staname;
        private System.Windows.Forms.TextBox stanic;
        private System.Windows.Forms.TextBox staaddress;
        private System.Windows.Forms.ComboBox cmdz;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmdCourse;
        private System.Windows.Forms.Label label7;
    }
}