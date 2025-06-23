namespace UMSAssignment.VIEWS
{
    partial class TimetableForm
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
            this.btn_add = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_update = new System.Windows.Forms.Button();
            this.btn_dlt = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmdSubject = new System.Windows.Forms.ComboBox();
            this.cmdRoom = new System.Windows.Forms.ComboBox();
            this.ViewTimetable = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbDay = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.ViewTimetable)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_add
            // 
            this.btn_add.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_add.Location = new System.Drawing.Point(630, 265);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(85, 35);
            this.btn_add.TabIndex = 0;
            this.btn_add.Text = "Add";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(820, 472);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(8, 8);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btn_update
            // 
            this.btn_update.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_update.Location = new System.Drawing.Point(630, 340);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(85, 35);
            this.btn_update.TabIndex = 2;
            this.btn_update.Text = "Update";
            this.btn_update.UseVisualStyleBackColor = true;
            this.btn_update.Click += new System.EventHandler(this.btn_update_Click);
            // 
            // btn_dlt
            // 
            this.btn_dlt.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_dlt.Location = new System.Drawing.Point(630, 403);
            this.btn_dlt.Name = "btn_dlt";
            this.btn_dlt.Size = new System.Drawing.Size(85, 35);
            this.btn_dlt.TabIndex = 3;
            this.btn_dlt.Text = "Delete";
            this.btn_dlt.UseVisualStyleBackColor = true;
            this.btn_dlt.Click += new System.EventHandler(this.btn_dlt_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(200, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 18);
            this.label1.TabIndex = 4;
            this.label1.Text = "Subject Name :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(200, 145);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 18);
            this.label2.TabIndex = 5;
            this.label2.Text = "Room Name: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(200, 194);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 18);
            this.label3.TabIndex = 6;
            this.label3.Text = "Date :";
            // 
            // cmdSubject
            // 
            this.cmdSubject.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSubject.FormattingEnabled = true;
            this.cmdSubject.Location = new System.Drawing.Point(350, 94);
            this.cmdSubject.Name = "cmdSubject";
            this.cmdSubject.Size = new System.Drawing.Size(233, 24);
            this.cmdSubject.TabIndex = 7;
            this.cmdSubject.SelectedIndexChanged += new System.EventHandler(this.cmdSubject_SelectedIndexChanged);
            // 
            // cmdRoom
            // 
            this.cmdRoom.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdRoom.FormattingEnabled = true;
            this.cmdRoom.Location = new System.Drawing.Point(350, 139);
            this.cmdRoom.Name = "cmdRoom";
            this.cmdRoom.Size = new System.Drawing.Size(233, 24);
            this.cmdRoom.TabIndex = 8;
            this.cmdRoom.SelectedIndexChanged += new System.EventHandler(this.cmdRoom_SelectedIndexChanged);
            // 
            // ViewTimetable
            // 
            this.ViewTimetable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ViewTimetable.Location = new System.Drawing.Point(95, 265);
            this.ViewTimetable.Name = "ViewTimetable";
            this.ViewTimetable.Size = new System.Drawing.Size(504, 188);
            this.ViewTimetable.TabIndex = 11;
            this.ViewTimetable.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ViewTimetable_CellContentClick);
            this.ViewTimetable.SelectionChanged += new System.EventHandler(this.ViewTimetable_SelectionChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(389, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(138, 28);
            this.label4.TabIndex = 12;
            this.label4.Text = "TIMETABLE ";
            // 
            // cmbDay
            // 
            this.cmbDay.FormattingEnabled = true;
            this.cmbDay.Location = new System.Drawing.Point(350, 191);
            this.cmbDay.Name = "cmbDay";
            this.cmbDay.Size = new System.Drawing.Size(233, 21);
            this.cmbDay.TabIndex = 16;
            // 
            // TimetableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 583);
            this.Controls.Add(this.cmbDay);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ViewTimetable);
            this.Controls.Add(this.cmdRoom);
            this.Controls.Add(this.cmdSubject);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_dlt);
            this.Controls.Add(this.btn_update);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_add);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TimetableForm";
            this.Text = "TimetableForm";
            ((System.ComponentModel.ISupportInitialize)(this.ViewTimetable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_update;
        private System.Windows.Forms.Button btn_dlt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmdSubject;
        private System.Windows.Forms.ComboBox cmdRoom;
        private System.Windows.Forms.DataGridView ViewTimetable;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbDay;
    }
}