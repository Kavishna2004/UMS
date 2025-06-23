namespace UMSAssignment.VIEWS
{
    partial class LecturerForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btn_add = new System.Windows.Forms.Button();
            this.btn_update = new System.Windows.Forms.Button();
            this.btn_dlt = new System.Windows.Forms.Button();
            this.ViewLecturer = new System.Windows.Forms.DataGridView();
            this.cmdCourse = new System.Windows.Forms.ComboBox();
            this.lename = new System.Windows.Forms.TextBox();
            this.leaddress = new System.Windows.Forms.TextBox();
            this.lenumber = new System.Windows.Forms.TextBox();
            this.lenic = new System.Windows.Forms.TextBox();
            this.leemail = new System.Windows.Forms.TextBox();
            this.cmdGender = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.lesearch = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.ViewLecturer)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(343, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "LECTURER REGISTRATION";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(106, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(106, 156);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Gender";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(481, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "NIC";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(481, 156);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Email";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label6.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(102, 201);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 16);
            this.label6.TabIndex = 5;
            this.label6.Text = "Address";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label7.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(106, 243);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 16);
            this.label7.TabIndex = 6;
            this.label7.Text = "PH.Number";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label8.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(481, 212);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 16);
            this.label8.TabIndex = 7;
            this.label8.Text = "Course";
            // 
            // btn_add
            // 
            this.btn_add.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_add.Location = new System.Drawing.Point(699, 303);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(75, 23);
            this.btn_add.TabIndex = 8;
            this.btn_add.Text = "Add";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // btn_update
            // 
            this.btn_update.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_update.Location = new System.Drawing.Point(699, 369);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(75, 23);
            this.btn_update.TabIndex = 9;
            this.btn_update.Text = "Update";
            this.btn_update.UseVisualStyleBackColor = true;
            this.btn_update.Click += new System.EventHandler(this.btn_update_Click);
            // 
            // btn_dlt
            // 
            this.btn_dlt.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_dlt.Location = new System.Drawing.Point(699, 439);
            this.btn_dlt.Name = "btn_dlt";
            this.btn_dlt.Size = new System.Drawing.Size(75, 23);
            this.btn_dlt.TabIndex = 10;
            this.btn_dlt.Text = "Delete";
            this.btn_dlt.UseVisualStyleBackColor = true;
            this.btn_dlt.Click += new System.EventHandler(this.btn_dlt_Click);
            // 
            // ViewLecturer
            // 
            this.ViewLecturer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ViewLecturer.Location = new System.Drawing.Point(109, 303);
            this.ViewLecturer.Name = "ViewLecturer";
            this.ViewLecturer.Size = new System.Drawing.Size(554, 174);
            this.ViewLecturer.TabIndex = 11;
            this.ViewLecturer.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ViewLecturer_CellContentClick);
            this.ViewLecturer.SelectionChanged += new System.EventHandler(this.ViewLecturer_SelectionChanged);
            // 
            // cmdCourse
            // 
            this.cmdCourse.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdCourse.FormattingEnabled = true;
            this.cmdCourse.Location = new System.Drawing.Point(574, 205);
            this.cmdCourse.Name = "cmdCourse";
            this.cmdCourse.Size = new System.Drawing.Size(219, 24);
            this.cmdCourse.TabIndex = 12;
            this.cmdCourse.SelectedIndexChanged += new System.EventHandler(this.cmdCourse_SelectedIndexChanged);
            // 
            // lename
            // 
            this.lename.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lename.Location = new System.Drawing.Point(225, 102);
            this.lename.Name = "lename";
            this.lename.Size = new System.Drawing.Size(209, 23);
            this.lename.TabIndex = 13;
            // 
            // leaddress
            // 
            this.leaddress.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.leaddress.Location = new System.Drawing.Point(225, 197);
            this.leaddress.Name = "leaddress";
            this.leaddress.Size = new System.Drawing.Size(209, 23);
            this.leaddress.TabIndex = 15;
            this.leaddress.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // lenumber
            // 
            this.lenumber.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lenumber.Location = new System.Drawing.Point(225, 234);
            this.lenumber.Name = "lenumber";
            this.lenumber.Size = new System.Drawing.Size(209, 23);
            this.lenumber.TabIndex = 16;
            // 
            // lenic
            // 
            this.lenic.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lenic.Location = new System.Drawing.Point(584, 99);
            this.lenic.Name = "lenic";
            this.lenic.Size = new System.Drawing.Size(209, 23);
            this.lenic.TabIndex = 17;
            // 
            // leemail
            // 
            this.leemail.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.leemail.Location = new System.Drawing.Point(584, 147);
            this.leemail.Name = "leemail";
            this.leemail.Size = new System.Drawing.Size(209, 23);
            this.leemail.TabIndex = 18;
            // 
            // cmdGender
            // 
            this.cmdGender.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdGender.FormattingEnabled = true;
            this.cmdGender.Location = new System.Drawing.Point(225, 156);
            this.cmdGender.Name = "cmdGender";
            this.cmdGender.Size = new System.Drawing.Size(209, 24);
            this.cmdGender.TabIndex = 19;
            this.cmdGender.SelectedIndexChanged += new System.EventHandler(this.cmdGender_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label9.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(110, 276);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(43, 16);
            this.label9.TabIndex = 20;
            this.label9.Text = "Search";
            // 
            // lesearch
            // 
            this.lesearch.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lesearch.Location = new System.Drawing.Point(225, 269);
            this.lesearch.Name = "lesearch";
            this.lesearch.Size = new System.Drawing.Size(209, 23);
            this.lesearch.TabIndex = 21;
            this.lesearch.TextChanged += new System.EventHandler(this.lesearch_TextChanged);
            // 
            // LecturerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 544);
            this.Controls.Add(this.lesearch);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cmdGender);
            this.Controls.Add(this.leemail);
            this.Controls.Add(this.lenic);
            this.Controls.Add(this.lenumber);
            this.Controls.Add(this.leaddress);
            this.Controls.Add(this.lename);
            this.Controls.Add(this.cmdCourse);
            this.Controls.Add(this.ViewLecturer);
            this.Controls.Add(this.btn_dlt);
            this.Controls.Add(this.btn_update);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LecturerForm";
            this.Text = "LecturerForm";
            this.Load += new System.EventHandler(this.LecturerForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ViewLecturer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.Button btn_update;
        private System.Windows.Forms.Button btn_dlt;
        private System.Windows.Forms.DataGridView ViewLecturer;
        private System.Windows.Forms.ComboBox cmdCourse;
        private System.Windows.Forms.TextBox lename;
        private System.Windows.Forms.TextBox leaddress;
        private System.Windows.Forms.TextBox lenumber;
        private System.Windows.Forms.TextBox lenic;
        private System.Windows.Forms.TextBox leemail;
        private System.Windows.Forms.ComboBox cmdGender;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox lesearch;
    }
}