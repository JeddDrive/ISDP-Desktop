namespace JeddoreISDPDesktop
{
    partial class AddEditUser
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddEditUser));
            this.lblLocation = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.grpBasic = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cboPosition = new System.Windows.Forms.ComboBox();
            this.cboLocation = new System.Windows.Forms.ComboBox();
            this.lblEmployeeID = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.txtUsername2 = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.toolTipHelp = new System.Windows.Forms.ToolTip(this.components);
            this.chkLocked = new System.Windows.Forms.CheckBox();
            this.picHelp = new System.Windows.Forms.PictureBox();
            this.picEyeHide = new System.Windows.Forms.PictureBox();
            this.picEyeShow = new System.Windows.Forms.PictureBox();
            this.picBullseye = new System.Windows.Forms.PictureBox();
            this.grpBasic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHelp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEyeHide)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEyeShow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBullseye)).BeginInit();
            this.SuspendLayout();
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Location = new System.Drawing.Point(264, 70);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(0, 28);
            this.lblLocation.TabIndex = 30;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(264, 17);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(0, 28);
            this.lblUsername.TabIndex = 29;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(184, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 28);
            this.label1.TabIndex = 28;
            this.label1.Text = "Location:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(214, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 28);
            this.label2.TabIndex = 27;
            this.label2.Text = "User:";
            // 
            // grpBasic
            // 
            this.grpBasic.Controls.Add(this.btnSave);
            this.grpBasic.Controls.Add(this.btnCancel);
            this.grpBasic.Location = new System.Drawing.Point(420, 450);
            this.grpBasic.Name = "grpBasic";
            this.grpBasic.Size = new System.Drawing.Size(200, 191);
            this.grpBasic.TabIndex = 32;
            this.grpBasic.TabStop = false;
            this.grpBasic.Enter += new System.EventHandler(this.grpBasic_Enter);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(29, 33);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(147, 63);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(29, 113);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(147, 63);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(47, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 28);
            this.label3.TabIndex = 33;
            this.label3.Text = "Employee ID:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(47, 182);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 28);
            this.label4.TabIndex = 34;
            this.label4.Text = "Username:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(47, 241);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 28);
            this.label5.TabIndex = 35;
            this.label5.Text = "Password:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(47, 300);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(115, 28);
            this.label6.TabIndex = 36;
            this.label6.Text = "First Name:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(47, 359);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(113, 28);
            this.label7.TabIndex = 37;
            this.label7.Text = "Last Name:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(47, 418);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 28);
            this.label8.TabIndex = 38;
            this.label8.Text = "Email:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(47, 477);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(90, 28);
            this.label9.TabIndex = 39;
            this.label9.Text = "Position:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(47, 536);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(94, 28);
            this.label10.TabIndex = 40;
            this.label10.Text = "Location:";
            // 
            // cboPosition
            // 
            this.cboPosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPosition.FormattingEnabled = true;
            this.cboPosition.Location = new System.Drawing.Point(145, 474);
            this.cboPosition.Name = "cboPosition";
            this.cboPosition.Size = new System.Drawing.Size(248, 36);
            this.cboPosition.TabIndex = 5;
            // 
            // cboLocation
            // 
            this.cboLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLocation.FormattingEnabled = true;
            this.cboLocation.Location = new System.Drawing.Point(145, 536);
            this.cboLocation.Name = "cboLocation";
            this.cboLocation.Size = new System.Drawing.Size(248, 36);
            this.cboLocation.TabIndex = 6;
            // 
            // lblEmployeeID
            // 
            this.lblEmployeeID.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblEmployeeID.Enabled = false;
            this.lblEmployeeID.Location = new System.Drawing.Point(176, 123);
            this.lblEmployeeID.Name = "lblEmployeeID";
            this.lblEmployeeID.Size = new System.Drawing.Size(78, 34);
            this.lblEmployeeID.TabIndex = 43;
            this.lblEmployeeID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPassword
            // 
            this.txtPassword.Enabled = false;
            this.txtPassword.Location = new System.Drawing.Point(176, 241);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(274, 34);
            this.txtPassword.TabIndex = 1;
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(176, 300);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(274, 34);
            this.txtFirstName.TabIndex = 2;
            this.txtFirstName.TextChanged += new System.EventHandler(this.txtFirstName_TextChanged);
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(176, 359);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(274, 34);
            this.txtLastName.TabIndex = 3;
            this.txtLastName.TextChanged += new System.EventHandler(this.txtLastName_TextChanged);
            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            this.chkActive.Checked = true;
            this.chkActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkActive.Location = new System.Drawing.Point(468, 178);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(136, 32);
            this.chkActive.TabIndex = 44;
            this.chkActive.Text = "Active User";
            this.chkActive.UseVisualStyleBackColor = true;
            // 
            // txtUsername2
            // 
            this.txtUsername2.Enabled = false;
            this.txtUsername2.Location = new System.Drawing.Point(176, 182);
            this.txtUsername2.Name = "txtUsername2";
            this.txtUsername2.Size = new System.Drawing.Size(274, 34);
            this.txtUsername2.TabIndex = 47;
            // 
            // txtEmail
            // 
            this.txtEmail.Enabled = false;
            this.txtEmail.Location = new System.Drawing.Point(176, 418);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(274, 34);
            this.txtEmail.TabIndex = 48;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1200000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // chkLocked
            // 
            this.chkLocked.AutoSize = true;
            this.chkLocked.Location = new System.Drawing.Point(468, 125);
            this.chkLocked.Name = "chkLocked";
            this.chkLocked.Size = new System.Drawing.Size(146, 32);
            this.chkLocked.TabIndex = 51;
            this.chkLocked.Text = "Locked User";
            this.chkLocked.UseVisualStyleBackColor = true;
            // 
            // picHelp
            // 
            this.picHelp.Image = global::JeddoreISDPDesktop.Properties.Resources.help;
            this.picHelp.Location = new System.Drawing.Point(575, 17);
            this.picHelp.Name = "picHelp";
            this.picHelp.Size = new System.Drawing.Size(45, 40);
            this.picHelp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picHelp.TabIndex = 50;
            this.picHelp.TabStop = false;
            this.picHelp.Click += new System.EventHandler(this.picHelp_Click);
            // 
            // picEyeHide
            // 
            this.picEyeHide.Image = global::JeddoreISDPDesktop.Properties.Resources.eyeHide;
            this.picEyeHide.Location = new System.Drawing.Point(468, 235);
            this.picEyeHide.Name = "picEyeHide";
            this.picEyeHide.Size = new System.Drawing.Size(45, 40);
            this.picEyeHide.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picEyeHide.TabIndex = 46;
            this.picEyeHide.TabStop = false;
            this.picEyeHide.Visible = false;
            this.picEyeHide.Click += new System.EventHandler(this.picEyeHide_Click);
            // 
            // picEyeShow
            // 
            this.picEyeShow.Image = global::JeddoreISDPDesktop.Properties.Resources.eyeDisplay;
            this.picEyeShow.Location = new System.Drawing.Point(468, 235);
            this.picEyeShow.Name = "picEyeShow";
            this.picEyeShow.Size = new System.Drawing.Size(45, 40);
            this.picEyeShow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picEyeShow.TabIndex = 45;
            this.picEyeShow.TabStop = false;
            this.picEyeShow.Click += new System.EventHandler(this.picEyeShow_Click);
            // 
            // picBullseye
            // 
            this.picBullseye.Image = global::JeddoreISDPDesktop.Properties.Resources.bullseye_nobackground;
            this.picBullseye.Location = new System.Drawing.Point(1, 1);
            this.picBullseye.Name = "picBullseye";
            this.picBullseye.Size = new System.Drawing.Size(140, 110);
            this.picBullseye.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBullseye.TabIndex = 31;
            this.picBullseye.TabStop = false;
            // 
            // AddEditUser
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(632, 653);
            this.Controls.Add(this.chkLocked);
            this.Controls.Add(this.picHelp);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtUsername2);
            this.Controls.Add(this.picEyeHide);
            this.Controls.Add(this.picEyeShow);
            this.Controls.Add(this.chkActive);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblEmployeeID);
            this.Controls.Add(this.cboLocation);
            this.Controls.Add(this.cboPosition);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.grpBasic);
            this.Controls.Add(this.picBullseye);
            this.Controls.Add(this.lblLocation);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "AddEditUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bullseye Inventory Management System - Add/Edit User";
            this.Load += new System.EventHandler(this.AddEditUser_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AddEditUser_KeyDown);
            this.grpBasic.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picHelp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEyeHide)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEyeShow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBullseye)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picBullseye;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox grpBasic;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cboPosition;
        private System.Windows.Forms.ComboBox cboLocation;
        private System.Windows.Forms.Label lblEmployeeID;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.CheckBox chkActive;
        private System.Windows.Forms.PictureBox picEyeShow;
        private System.Windows.Forms.PictureBox picEyeHide;
        private System.Windows.Forms.TextBox txtUsername2;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox picHelp;
        private System.Windows.Forms.ToolTip toolTipHelp;
        private System.Windows.Forms.CheckBox chkLocked;
    }
}