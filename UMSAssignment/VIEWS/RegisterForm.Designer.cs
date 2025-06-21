namespace UMSAssignment.VIEWS
{
    partial class RegisterForm
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
            this.Username = new System.Windows.Forms.Label();
            this.rusername = new System.Windows.Forms.TextBox();
            this.rpassword = new System.Windows.Forms.TextBox();
            this.rrole = new System.Windows.Forms.ComboBox();
            this.btn_summit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(280, 393);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Role :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(280, 326);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "Password :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(389, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(174, 28);
            this.label4.TabIndex = 3;
            this.label4.Text = "REGISTRATION";
            // 
            // Username
            // 
            this.Username.AutoSize = true;
            this.Username.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Username.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Username.Location = new System.Drawing.Point(280, 243);
            this.Username.Name = "Username";
            this.Username.Size = new System.Drawing.Size(78, 18);
            this.Username.TabIndex = 0;
            this.Username.Text = "Username :";
            // 
            // rusername
            // 
            this.rusername.Location = new System.Drawing.Point(455, 239);
            this.rusername.Name = "rusername";
            this.rusername.Size = new System.Drawing.Size(192, 20);
            this.rusername.TabIndex = 4;
            // 
            // rpassword
            // 
            this.rpassword.Location = new System.Drawing.Point(455, 322);
            this.rpassword.Name = "rpassword";
            this.rpassword.Size = new System.Drawing.Size(192, 20);
            this.rpassword.TabIndex = 5;
            // 
            // rrole
            // 
            this.rrole.FormattingEnabled = true;
            this.rrole.Location = new System.Drawing.Point(455, 388);
            this.rrole.Name = "rrole";
            this.rrole.Size = new System.Drawing.Size(192, 21);
            this.rrole.TabIndex = 6;
            this.rrole.SelectedIndexChanged += new System.EventHandler(this.rrole_SelectedIndexChanged);
            // 
            // btn_summit
            // 
            this.btn_summit.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_summit.Location = new System.Drawing.Point(434, 501);
            this.btn_summit.Name = "btn_summit";
            this.btn_summit.Size = new System.Drawing.Size(112, 30);
            this.btn_summit.TabIndex = 7;
            this.btn_summit.Text = "SUMMIT";
            this.btn_summit.UseVisualStyleBackColor = true;
            this.btn_summit.Click += new System.EventHandler(this.btn_summit_Click);
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(847, 563);
            this.Controls.Add(this.btn_summit);
            this.Controls.Add(this.rrole);
            this.Controls.Add(this.rpassword);
            this.Controls.Add(this.rusername);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Username);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RegisterForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label Username;
        private System.Windows.Forms.TextBox rusername;
        private System.Windows.Forms.TextBox rpassword;
        private System.Windows.Forms.ComboBox rrole;
        private System.Windows.Forms.Button btn_summit;
    }
}