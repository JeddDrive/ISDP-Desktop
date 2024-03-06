namespace JeddoreISDPDesktop
{
    partial class EditInventory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditInventory));
            this.picHelp = new System.Windows.Forms.PictureBox();
            this.lblItemID = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.picBullseye = new System.Windows.Forms.PictureBox();
            this.lblLocation = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.grpBasic = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblSiteID = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.toolTipHelp = new System.Windows.Forms.ToolTip(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblName = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblItemLocation = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.nudReorderThreshold = new System.Windows.Forms.NumericUpDown();
            this.nudOptimumThreshold = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.picHelp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBullseye)).BeginInit();
            this.grpBasic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudReorderThreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudOptimumThreshold)).BeginInit();
            this.SuspendLayout();
            // 
            // picHelp
            // 
            this.picHelp.Image = global::JeddoreISDPDesktop.Properties.Resources.help;
            this.picHelp.Location = new System.Drawing.Point(725, 15);
            this.picHelp.Name = "picHelp";
            this.picHelp.Size = new System.Drawing.Size(45, 40);
            this.picHelp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picHelp.TabIndex = 92;
            this.picHelp.TabStop = false;
            this.picHelp.Click += new System.EventHandler(this.picHelp_Click);
            // 
            // lblItemID
            // 
            this.lblItemID.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblItemID.Enabled = false;
            this.lblItemID.Location = new System.Drawing.Point(145, 124);
            this.lblItemID.Name = "lblItemID";
            this.lblItemID.Size = new System.Drawing.Size(133, 34);
            this.lblItemID.TabIndex = 91;
            this.lblItemID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 28);
            this.label3.TabIndex = 90;
            this.label3.Text = "Item ID:";
            // 
            // picBullseye
            // 
            this.picBullseye.Image = global::JeddoreISDPDesktop.Properties.Resources.bullseye_nobackground;
            this.picBullseye.Location = new System.Drawing.Point(1, -1);
            this.picBullseye.Name = "picBullseye";
            this.picBullseye.Size = new System.Drawing.Size(140, 110);
            this.picBullseye.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBullseye.TabIndex = 89;
            this.picBullseye.TabStop = false;
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Location = new System.Drawing.Point(264, 68);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(0, 28);
            this.lblLocation.TabIndex = 88;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(264, 15);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(0, 28);
            this.lblUsername.TabIndex = 87;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(184, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 28);
            this.label1.TabIndex = 86;
            this.label1.Text = "Location:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(214, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 28);
            this.label2.TabIndex = 85;
            this.label2.Text = "User:";
            // 
            // grpBasic
            // 
            this.grpBasic.Controls.Add(this.btnSave);
            this.grpBasic.Controls.Add(this.btnCancel);
            this.grpBasic.Location = new System.Drawing.Point(591, 472);
            this.grpBasic.Name = "grpBasic";
            this.grpBasic.Size = new System.Drawing.Size(179, 191);
            this.grpBasic.TabIndex = 93;
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
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblSiteID
            // 
            this.lblSiteID.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblSiteID.Enabled = false;
            this.lblSiteID.Location = new System.Drawing.Point(145, 187);
            this.lblSiteID.Name = "lblSiteID";
            this.lblSiteID.Size = new System.Drawing.Size(133, 34);
            this.lblSiteID.TabIndex = 95;
            this.lblSiteID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 187);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 28);
            this.label5.TabIndex = 94;
            this.label5.Text = "Site ID:";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1200000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblName
            // 
            this.lblName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblName.Enabled = false;
            this.lblName.Location = new System.Drawing.Point(145, 244);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(392, 34);
            this.lblName.TabIndex = 97;
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 244);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 28);
            this.label4.TabIndex = 96;
            this.label4.Text = "Name:";
            // 
            // lblQuantity
            // 
            this.lblQuantity.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblQuantity.Enabled = false;
            this.lblQuantity.Location = new System.Drawing.Point(543, 124);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(133, 34);
            this.lblQuantity.TabIndex = 99;
            this.lblQuantity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(442, 124);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 28);
            this.label7.TabIndex = 98;
            this.label7.Text = "Quantity:";
            // 
            // lblItemLocation
            // 
            this.lblItemLocation.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblItemLocation.Enabled = false;
            this.lblItemLocation.Location = new System.Drawing.Point(543, 187);
            this.lblItemLocation.Name = "lblItemLocation";
            this.lblItemLocation.Size = new System.Drawing.Size(133, 34);
            this.lblItemLocation.TabIndex = 101;
            this.lblItemLocation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(442, 187);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(94, 28);
            this.label8.TabIndex = 100;
            this.label8.Text = "Location:";
            // 
            // txtDescription
            // 
            this.txtDescription.Enabled = false;
            this.txtDescription.Location = new System.Drawing.Point(145, 305);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(392, 83);
            this.txtDescription.TabIndex = 102;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(30, 308);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(120, 28);
            this.label6.TabIndex = 103;
            this.label6.Text = "Description:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(30, 420);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(185, 28);
            this.label9.TabIndex = 104;
            this.label9.Text = "Reorder Threshold:";
            // 
            // nudReorderThreshold
            // 
            this.nudReorderThreshold.Location = new System.Drawing.Point(210, 418);
            this.nudReorderThreshold.Name = "nudReorderThreshold";
            this.nudReorderThreshold.Size = new System.Drawing.Size(98, 34);
            this.nudReorderThreshold.TabIndex = 0;
            this.nudReorderThreshold.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // nudOptimumThreshold
            // 
            this.nudOptimumThreshold.Location = new System.Drawing.Point(579, 418);
            this.nudOptimumThreshold.Name = "nudOptimumThreshold";
            this.nudOptimumThreshold.Size = new System.Drawing.Size(98, 34);
            this.nudOptimumThreshold.TabIndex = 107;
            this.nudOptimumThreshold.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(381, 420);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(201, 28);
            this.label10.TabIndex = 106;
            this.label10.Text = "Optimum Threshold:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(30, 487);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(71, 28);
            this.label11.TabIndex = 109;
            this.label11.Text = "Notes:";
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(145, 487);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(392, 176);
            this.txtNotes.TabIndex = 1;
            // 
            // EditInventory
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(782, 703);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.nudOptimumThreshold);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.nudReorderThreshold);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblItemLocation);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblSiteID);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.grpBasic);
            this.Controls.Add(this.picHelp);
            this.Controls.Add(this.lblItemID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.picBullseye);
            this.Controls.Add(this.lblLocation);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "EditInventory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bullseye Inventory Management System - Edit Inventory";
            this.Load += new System.EventHandler(this.EditInventory_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EditInventory_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.picHelp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBullseye)).EndInit();
            this.grpBasic.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudReorderThreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudOptimumThreshold)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picHelp;
        private System.Windows.Forms.Label lblItemID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox picBullseye;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox grpBasic;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblSiteID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolTip toolTipHelp;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblItemLocation;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown nudReorderThreshold;
        private System.Windows.Forms.NumericUpDown nudOptimumThreshold;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtNotes;
    }
}