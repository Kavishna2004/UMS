namespace UMSAssignment.VIEWS
{
    partial class TimetableForm_cs
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
            this.cmdSubject = new System.Windows.Forms.ComboBox();
            this.ttime = new System.Windows.Forms.TextBox();
            this.cmdRoom = new System.Windows.Forms.ComboBox();
            this.ViewTimetable = new System.Windows.Forms.DataGridView();
            this.btn_add = new System.Windows.Forms.Button();
            this.btn_update = new System.Windows.Forms.Button();
            this.btn_dlt = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ViewTimetable)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(165, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "TimeTable Id :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(165, 158);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Room Id :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(165, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "Subject Id :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(247, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 22);
            this.label4.TabIndex = 3;
            this.label4.Text = "TIMETABLE ";
            // 
            // cmdSubject
            // 
            this.cmdSubject.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSubject.FormattingEnabled = true;
            this.cmdSubject.Location = new System.Drawing.Point(313, 117);
            this.cmdSubject.Name = "cmdSubject";
            this.cmdSubject.Size = new System.Drawing.Size(222, 24);
            this.cmdSubject.TabIndex = 4;
            this.cmdSubject.SelectedIndexChanged += new System.EventHandler(this.cmdSubject_SelectedIndexChanged);
            // 
            // ttime
            // 
            this.ttime.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ttime.Location = new System.Drawing.Point(313, 76);
            this.ttime.Name = "ttime";
            this.ttime.Size = new System.Drawing.Size(222, 23);
            this.ttime.TabIndex = 5;
            // 
            // cmdRoom
            // 
            this.cmdRoom.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdRoom.FormattingEnabled = true;
            this.cmdRoom.Location = new System.Drawing.Point(313, 158);
            this.cmdRoom.Name = "cmdRoom";
            this.cmdRoom.Size = new System.Drawing.Size(222, 24);
            this.cmdRoom.TabIndex = 6;
            this.cmdRoom.SelectedIndexChanged += new System.EventHandler(this.cmdRoom_SelectedIndexChanged);
            // 
            // ViewTimetable
            // 
            this.ViewTimetable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ViewTimetable.Location = new System.Drawing.Point(127, 231);
            this.ViewTimetable.Name = "ViewTimetable";
            this.ViewTimetable.Size = new System.Drawing.Size(444, 194);
            this.ViewTimetable.TabIndex = 7;
            this.ViewTimetable.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ViewTimetable_CellContentClick);
            // 
            // btn_add
            // 
            this.btn_add.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_add.Location = new System.Drawing.Point(619, 231);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(86, 33);
            this.btn_add.TabIndex = 8;
            this.btn_add.Text = "Add";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // btn_update
            // 
            this.btn_update.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_update.Location = new System.Drawing.Point(619, 289);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(81, 31);
            this.btn_update.TabIndex = 9;
            this.btn_update.Text = "Update";
            this.btn_update.UseVisualStyleBackColor = true;
            this.btn_update.Click += new System.EventHandler(this.btn_update_Click);
            // 
            // btn_dlt
            // 
            this.btn_dlt.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_dlt.Location = new System.Drawing.Point(615, 355);
            this.btn_dlt.Name = "btn_dlt";
            this.btn_dlt.Size = new System.Drawing.Size(85, 26);
            this.btn_dlt.TabIndex = 10;
            this.btn_dlt.Text = "Delete";
            this.btn_dlt.UseVisualStyleBackColor = true;
            this.btn_dlt.Click += new System.EventHandler(this.btn_dlt_Click);
            // 
            // TimetableForm_cs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_dlt);
            this.Controls.Add(this.btn_update);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.ViewTimetable);
            this.Controls.Add(this.cmdRoom);
            this.Controls.Add(this.ttime);
            this.Controls.Add(this.cmdSubject);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "TimetableForm_cs";
            this.Text = "TimetableForm_cs";
            this.Load += new System.EventHandler(this.TimetableForm_cs_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ViewTimetable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmdSubject;
        private System.Windows.Forms.TextBox ttime;
        private System.Windows.Forms.ComboBox cmdRoom;
        private System.Windows.Forms.DataGridView ViewTimetable;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.Button btn_update;
        private System.Windows.Forms.Button btn_dlt;
    }
}