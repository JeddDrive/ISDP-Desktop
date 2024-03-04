namespace JeddoreISDPDesktop
{
    partial class MoveInventory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MoveInventory));
            this.picHelp = new System.Windows.Forms.PictureBox();
            this.picBullseye = new System.Windows.Forms.PictureBox();
            this.lblLocation = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.toolTipHelp = new System.Windows.Forms.ToolTip(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label11 = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblSiteNameLocation = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblSiteID = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.grpBasic = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblItemID = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblItemLocation = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.cboSiteLocations = new System.Windows.Forms.ComboBox();
            this.cboItemLocations = new System.Windows.Forms.ComboBox();
            this.lblSiteQuantity = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.nudQuantityToMove = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.lblCaseSize = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picHelp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBullseye)).BeginInit();
            this.grpBasic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantityToMove)).BeginInit();
            this.SuspendLayout();
            // 
            // picHelp
            // 
            this.picHelp.Image = global::JeddoreISDPDesktop.Properties.Resources.help;
            this.picHelp.Location = new System.Drawing.Point(724, 16);
            this.picHelp.Name = "picHelp";
            this.picHelp.Size = new System.Drawing.Size(45, 40);
            this.picHelp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picHelp.TabIndex = 98;
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
            this.picBullseye.TabIndex = 97;
            this.picBullseye.TabStop = false;
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Location = new System.Drawing.Point(263, 69);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(0, 28);
            this.lblLocation.TabIndex = 96;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(263, 16);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(0, 28);
            this.lblUsername.TabIndex = 95;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(183, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 28);
            this.label1.TabIndex = 94;
            this.label1.Text = "Location:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(213, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 28);
            this.label2.TabIndex = 93;
            this.label2.Text = "User:";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1200000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(29, 550);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(71, 28);
            this.label11.TabIndex = 128;
            this.label11.Text = "Notes:";
            // 
            // txtNotes
            // 
            this.txtNotes.Enabled = false;
            this.txtNotes.Location = new System.Drawing.Point(144, 550);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(392, 176);
            this.txtNotes.TabIndex = 111;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(29, 490);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(189, 28);
            this.label10.TabIndex = 126;
            this.label10.Text = "New Item Location:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(29, 424);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(181, 28);
            this.label9.TabIndex = 125;
            this.label9.Text = "New Site Location:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(29, 309);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(120, 28);
            this.label6.TabIndex = 124;
            this.label6.Text = "Description:";
            // 
            // txtDescription
            // 
            this.txtDescription.Enabled = false;
            this.txtDescription.Location = new System.Drawing.Point(144, 306);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(392, 83);
            this.txtDescription.TabIndex = 123;
            // 
            // lblSiteNameLocation
            // 
            this.lblSiteNameLocation.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblSiteNameLocation.Enabled = false;
            this.lblSiteNameLocation.Location = new System.Drawing.Point(543, 125);
            this.lblSiteNameLocation.Name = "lblSiteNameLocation";
            this.lblSiteNameLocation.Size = new System.Drawing.Size(161, 34);
            this.lblSiteNameLocation.TabIndex = 122;
            this.lblSiteNameLocation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(343, 125);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(208, 28);
            this.label8.TabIndex = 121;
            this.label8.Text = "Current Site Location:";
            // 
            // lblName
            // 
            this.lblName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblName.Enabled = false;
            this.lblName.Location = new System.Drawing.Point(144, 245);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(392, 34);
            this.lblName.TabIndex = 118;
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 245);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 28);
            this.label4.TabIndex = 117;
            this.label4.Text = "Name:";
            // 
            // lblSiteID
            // 
            this.lblSiteID.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblSiteID.Enabled = false;
            this.lblSiteID.Location = new System.Drawing.Point(144, 188);
            this.lblSiteID.Name = "lblSiteID";
            this.lblSiteID.Size = new System.Drawing.Size(133, 34);
            this.lblSiteID.TabIndex = 116;
            this.lblSiteID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 188);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 28);
            this.label5.TabIndex = 115;
            this.label5.Text = "Site ID:";
            // 
            // grpBasic
            // 
            this.grpBasic.Controls.Add(this.btnSave);
            this.grpBasic.Controls.Add(this.btnCancel);
            this.grpBasic.Location = new System.Drawing.Point(591, 550);
            this.grpBasic.Name = "grpBasic";
            this.grpBasic.Size = new System.Drawing.Size(179, 191);
            this.grpBasic.TabIndex = 114;
            this.grpBasic.TabStop = false;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(16, 33);
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
            this.btnCancel.Location = new System.Drawing.Point(16, 122);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(147, 63);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblItemID
            // 
            this.lblItemID.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblItemID.Enabled = false;
            this.lblItemID.Location = new System.Drawing.Point(144, 125);
            this.lblItemID.Name = "lblItemID";
            this.lblItemID.Size = new System.Drawing.Size(133, 34);
            this.lblItemID.TabIndex = 113;
            this.lblItemID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 28);
            this.label3.TabIndex = 112;
            this.label3.Text = "Item ID:";
            // 
            // lblItemLocation
            // 
            this.lblItemLocation.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblItemLocation.Enabled = false;
            this.lblItemLocation.Location = new System.Drawing.Point(543, 182);
            this.lblItemLocation.Name = "lblItemLocation";
            this.lblItemLocation.Size = new System.Drawing.Size(161, 34);
            this.lblItemLocation.TabIndex = 130;
            this.lblItemLocation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(343, 182);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(216, 28);
            this.label12.TabIndex = 129;
            this.label12.Text = "Current Item Location:";
            // 
            // cboSiteLocations
            // 
            this.cboSiteLocations.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSiteLocations.FormattingEnabled = true;
            this.cboSiteLocations.Location = new System.Drawing.Point(207, 424);
            this.cboSiteLocations.Name = "cboSiteLocations";
            this.cboSiteLocations.Size = new System.Drawing.Size(203, 36);
            this.cboSiteLocations.TabIndex = 0;
            // 
            // cboItemLocations
            // 
            this.cboItemLocations.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboItemLocations.FormattingEnabled = true;
            this.cboItemLocations.Location = new System.Drawing.Point(207, 490);
            this.cboItemLocations.Name = "cboItemLocations";
            this.cboItemLocations.Size = new System.Drawing.Size(203, 36);
            this.cboItemLocations.TabIndex = 1;
            // 
            // lblSiteQuantity
            // 
            this.lblSiteQuantity.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblSiteQuantity.Enabled = false;
            this.lblSiteQuantity.Location = new System.Drawing.Point(607, 427);
            this.lblSiteQuantity.Name = "lblSiteQuantity";
            this.lblSiteQuantity.Size = new System.Drawing.Size(92, 34);
            this.lblSiteQuantity.TabIndex = 136;
            this.lblSiteQuantity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(446, 427);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(182, 28);
            this.label7.TabIndex = 135;
            this.label7.Text = "Available Quantity:";
            // 
            // nudQuantityToMove
            // 
            this.nudQuantityToMove.Location = new System.Drawing.Point(607, 488);
            this.nudQuantityToMove.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.nudQuantityToMove.Name = "nudQuantityToMove";
            this.nudQuantityToMove.ReadOnly = true;
            this.nudQuantityToMove.Size = new System.Drawing.Size(92, 34);
            this.nudQuantityToMove.TabIndex = 2;
            this.nudQuantityToMove.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(446, 490);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(179, 28);
            this.label13.TabIndex = 134;
            this.label13.Text = "Quantity To Move:";
            // 
            // lblCaseSize
            // 
            this.lblCaseSize.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCaseSize.Enabled = false;
            this.lblCaseSize.Location = new System.Drawing.Point(630, 245);
            this.lblCaseSize.Name = "lblCaseSize";
            this.lblCaseSize.Size = new System.Drawing.Size(92, 34);
            this.lblCaseSize.TabIndex = 138;
            this.lblCaseSize.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(542, 245);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(101, 28);
            this.label15.TabIndex = 137;
            this.label15.Text = "Case Size:";
            // 
            // MoveInventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 753);
            this.Controls.Add(this.lblCaseSize);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.lblSiteQuantity);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.nudQuantityToMove);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.cboItemLocations);
            this.Controls.Add(this.cboSiteLocations);
            this.Controls.Add(this.lblItemLocation);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblSiteNameLocation);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblSiteID);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.grpBasic);
            this.Controls.Add(this.lblItemID);
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
            this.Name = "MoveInventory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bullseye Inventory Management System - Move Inventory";
            this.Load += new System.EventHandler(this.MoveInventory_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MoveInventory_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.picHelp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBullseye)).EndInit();
            this.grpBasic.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantityToMove)).EndInit();
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
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblSiteNameLocation;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblSiteID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox grpBasic;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblItemID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblItemLocation;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cboSiteLocations;
        private System.Windows.Forms.ComboBox cboItemLocations;
        private System.Windows.Forms.Label lblSiteQuantity;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown nudQuantityToMove;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblCaseSize;
        private System.Windows.Forms.Label label15;
    }
}