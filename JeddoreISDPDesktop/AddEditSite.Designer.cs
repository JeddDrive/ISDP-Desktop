namespace JeddoreISDPDesktop
{
    partial class AddEditSite
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddEditSite));
            this.lblLocation = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.toolTipHelp = new System.Windows.Forms.ToolTip(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblSiteID = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cboProvinces = new System.Windows.Forms.ComboBox();
            this.cboCountries = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPostalCode = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cboDeliveryDays = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.nudDistance = new System.Windows.Forms.NumericUpDown();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.grpBasic = new System.Windows.Forms.GroupBox();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.picHelp = new System.Windows.Forms.PictureBox();
            this.picBullseye = new System.Windows.Forms.PictureBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudDistance)).BeginInit();
            this.grpBasic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHelp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBullseye)).BeginInit();
            this.SuspendLayout();
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Location = new System.Drawing.Point(263, 69);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(0, 28);
            this.lblLocation.TabIndex = 54;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(263, 16);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(0, 28);
            this.lblUsername.TabIndex = 53;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(183, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 28);
            this.label1.TabIndex = 52;
            this.label1.Text = "Location:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(213, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 28);
            this.label2.TabIndex = 51;
            this.label2.Text = "User:";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1200000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblSiteID
            // 
            this.lblSiteID.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblSiteID.Enabled = false;
            this.lblSiteID.Location = new System.Drawing.Point(178, 135);
            this.lblSiteID.Name = "lblSiteID";
            this.lblSiteID.Size = new System.Drawing.Size(62, 34);
            this.lblSiteID.TabIndex = 58;
            this.lblSiteID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(63, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 28);
            this.label3.TabIndex = 57;
            this.label3.Text = "Site ID:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(178, 186);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(274, 34);
            this.txtName.TabIndex = 0;
            // 
            // txtCity
            // 
            this.txtCity.Location = new System.Drawing.Point(178, 304);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(274, 34);
            this.txtCity.TabIndex = 2;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(178, 245);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(274, 34);
            this.txtAddress.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(63, 304);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 28);
            this.label6.TabIndex = 63;
            this.label6.Text = "City:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(63, 245);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 28);
            this.label5.TabIndex = 62;
            this.label5.Text = "Address:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(63, 186);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 28);
            this.label4.TabIndex = 61;
            this.label4.Text = "Name:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(63, 361);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 28);
            this.label7.TabIndex = 65;
            this.label7.Text = "Province:";
            // 
            // cboProvinces
            // 
            this.cboProvinces.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProvinces.FormattingEnabled = true;
            this.cboProvinces.Location = new System.Drawing.Point(178, 361);
            this.cboProvinces.Name = "cboProvinces";
            this.cboProvinces.Size = new System.Drawing.Size(99, 36);
            this.cboProvinces.TabIndex = 3;
            // 
            // cboCountries
            // 
            this.cboCountries.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCountries.FormattingEnabled = true;
            this.cboCountries.Location = new System.Drawing.Point(417, 361);
            this.cboCountries.Name = "cboCountries";
            this.cboCountries.Size = new System.Drawing.Size(203, 36);
            this.cboCountries.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(312, 361);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(90, 28);
            this.label8.TabIndex = 67;
            this.label8.Text = "Country:";
            // 
            // txtPostalCode
            // 
            this.txtPostalCode.Location = new System.Drawing.Point(178, 424);
            this.txtPostalCode.Name = "txtPostalCode";
            this.txtPostalCode.Size = new System.Drawing.Size(99, 34);
            this.txtPostalCode.TabIndex = 5;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(48, 424);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(124, 28);
            this.label9.TabIndex = 70;
            this.label9.Text = "Postal Code:";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(417, 424);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(203, 34);
            this.txtPhone.TabIndex = 6;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(312, 424);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(76, 28);
            this.label10.TabIndex = 72;
            this.label10.Text = "Phone:";
            // 
            // cboDeliveryDays
            // 
            this.cboDeliveryDays.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDeliveryDays.FormattingEnabled = true;
            this.cboDeliveryDays.Location = new System.Drawing.Point(178, 487);
            this.cboDeliveryDays.Name = "cboDeliveryDays";
            this.cboDeliveryDays.Size = new System.Drawing.Size(133, 36);
            this.cboDeliveryDays.TabIndex = 7;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(48, 488);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(131, 28);
            this.label11.TabIndex = 73;
            this.label11.Text = "Delivery Day:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(317, 490);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(152, 28);
            this.label12.TabIndex = 75;
            this.label12.Text = "Distance (kms):";
            // 
            // nudDistance
            // 
            this.nudDistance.Increment = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.nudDistance.Location = new System.Drawing.Point(472, 490);
            this.nudDistance.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.nudDistance.Name = "nudDistance";
            this.nudDistance.Size = new System.Drawing.Size(92, 34);
            this.nudDistance.TabIndex = 8;
            this.nudDistance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            // grpBasic
            // 
            this.grpBasic.Controls.Add(this.btnSave);
            this.grpBasic.Controls.Add(this.btnCancel);
            this.grpBasic.Location = new System.Drawing.Point(420, 530);
            this.grpBasic.Name = "grpBasic";
            this.grpBasic.Size = new System.Drawing.Size(200, 191);
            this.grpBasic.TabIndex = 82;
            this.grpBasic.TabStop = false;
            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            this.chkActive.Checked = true;
            this.chkActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkActive.Location = new System.Drawing.Point(484, 131);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(129, 32);
            this.chkActive.TabIndex = 10;
            this.chkActive.Text = "Active Site";
            this.chkActive.UseVisualStyleBackColor = true;
            // 
            // picHelp
            // 
            this.picHelp.Image = global::JeddoreISDPDesktop.Properties.Resources.help;
            this.picHelp.Location = new System.Drawing.Point(575, 16);
            this.picHelp.Name = "picHelp";
            this.picHelp.Size = new System.Drawing.Size(45, 40);
            this.picHelp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picHelp.TabIndex = 56;
            this.picHelp.TabStop = false;
            this.picHelp.Click += new System.EventHandler(this.picHelp_Click);
            // 
            // picBullseye
            // 
            this.picBullseye.Image = global::JeddoreISDPDesktop.Properties.Resources.bullseye_nobackground;
            this.picBullseye.Location = new System.Drawing.Point(0, 0);
            this.picBullseye.Name = "picBullseye";
            this.picBullseye.Size = new System.Drawing.Size(140, 110);
            this.picBullseye.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBullseye.TabIndex = 55;
            this.picBullseye.TabStop = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(59, 557);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(71, 28);
            this.label13.TabIndex = 81;
            this.label13.Text = "Notes:";
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(166, 554);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(236, 162);
            this.txtNotes.TabIndex = 9;
            // 
            // AddEditSite
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(632, 728);
            this.Controls.Add(this.chkActive);
            this.Controls.Add(this.grpBasic);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.nudDistance);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.cboDeliveryDays);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtPostalCode);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cboCountries);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cboProvinces);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtCity);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblSiteID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.picHelp);
            this.Controls.Add(this.picBullseye);
            this.Controls.Add(this.lblLocation);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "AddEditSite";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bullseye Inventory Management System - Add/Edit Site";
            this.Load += new System.EventHandler(this.AddEditSite_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AddEditSite_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.nudDistance)).EndInit();
            this.grpBasic.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picHelp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBullseye)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picHelp;
        private System.Windows.Forms.PictureBox picBullseye;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolTip toolTipHelp;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblSiteID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboProvinces;
        private System.Windows.Forms.ComboBox cboCountries;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtPostalCode;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cboDeliveryDays;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown nudDistance;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox grpBasic;
        private System.Windows.Forms.CheckBox chkActive;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtNotes;
    }
}