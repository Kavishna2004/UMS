namespace UMSAssignment.VIEWS
{
    partial class LoginForm
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
            this.Username = new System.Windows.Forms.Label();
            this.Password = new System.Windows.Forms.Label();
            this.tusername = new System.Windows.Forms.TextBox();
            this.tpassword = new System.Windows.Forms.TextBox();
            this.btn_login = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdRole = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // Username
            // 
            this.Username.AutoSize = true;
            this.Username.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Username.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Username.Location = new System.Drawing.Point(241, 190);
            this.Username.Name = "Username";
            this.Username.Size = new System.Drawing.Size(78, 18);
            this.Username.TabIndex = 0;
            this.Username.Text = "Username :";
            // 
            // Password
            // 
            this.Password.AutoSize = true;
            this.Password.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Password.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Password.Location = new System.Drawing.Point(241, 276);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(75, 18);
            this.Password.TabIndex = 1;
            this.Password.Text = "Password :";
            // 
            // tusername
            // 
            this.tusername.Location = new System.Drawing.Point(387, 188);
            this.tusername.Name = "tusername";
            this.tusername.Size = new System.Drawing.Size(193, 20);
            this.tusername.TabIndex = 2;
            // 
            // tpassword
            // 
            this.tpassword.Location = new System.Drawing.Point(387, 272);
            this.tpassword.Name = "tpassword";
            this.tpassword.PasswordChar = '*';
            this.tpassword.Size = new System.Drawing.Size(193, 20);
            this.tpassword.TabIndex = 3;
            // 
            // btn_login
            // 
            this.btn_login.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_login.Location = new System.Drawing.Point(396, 447);
            this.btn_login.Name = "btn_login";
            this.btn_login.Size = new System.Drawing.Size(127, 41);
            this.btn_login.TabIndex = 4;
            this.btn_login.Text = "LOGIN";
            this.btn_login.UseVisualStyleBackColor = true;
            this.btn_login.Click += new System.EventHandler(this.btn_login_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(244, 351);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 18);
            this.label1.TabIndex = 5;
            this.label1.Text = "Role :";
            // 
            // cmdRole
            // 
            this.cmdRole.FormattingEnabled = true;
            this.cmdRole.Location = new System.Drawing.Point(387, 351);
            this.cmdRole.Name = "cmdRole";
            this.cmdRole.Size = new System.Drawing.Size(193, 21);
            this.cmdRole.TabIndex = 6;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(947, 639);
            this.Controls.Add(this.cmdRole);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_login);
            this.Controls.Add(this.tpassword);
            this.Controls.Add(this.tusername);
            this.Controls.Add(this.Password);
            this.Controls.Add(this.Username);
            this.Name = "LoginForm";
            this.Text = "LoginForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Username;
        private System.Windows.Forms.Label Password;
        private System.Windows.Forms.TextBox tusername;
        private System.Windows.Forms.TextBox tpassword;
        private System.Windows.Forms.Button btn_login;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmdRole;
    }
}