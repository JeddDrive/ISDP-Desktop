namespace JeddoreISDPDesktop
{
    partial class EditItem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditItem));
            this.picBullseye = new System.Windows.Forms.PictureBox();
            this.lblLocation = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblItemID = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.grpBasic = new System.Windows.Forms.GroupBox();
            this.btnAddImage = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblSKU = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label10 = new System.Windows.Forms.Label();
            this.picItemImage = new System.Windows.Forms.PictureBox();
            this.txtImageFileLocation = new System.Windows.Forms.TextBox();
            this.picHelp = new System.Windows.Forms.PictureBox();
            this.toolTipHelp = new System.Windows.Forms.ToolTip(this.components);
            this.txtName = new System.Windows.Forms.TextBox();
            this.nudWeight = new System.Windows.Forms.NumericUpDown();
            this.nudCaseSize = new System.Windows.Forms.NumericUpDown();
            this.cboCategories = new System.Windows.Forms.ComboBox();
            this.cboSuppliers = new System.Windows.Forms.ComboBox();
            this.nudCostPrice = new System.Windows.Forms.NumericUpDown();
            this.nudRetailPrice = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.picBullseye)).BeginInit();
            this.grpBasic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picItemImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHelp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCaseSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCostPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRetailPrice)).BeginInit();
            this.SuspendLayout();
            // 
            // picBullseye
            // 
            this.picBullseye.Image = global::JeddoreISDPDesktop.Properties.Resources.bullseye_nobackground;
            this.picBullseye.Location = new System.Drawing.Point(1, 0);
            this.picBullseye.Name = "picBullseye";
            this.picBullseye.Size = new System.Drawing.Size(140, 110);
            this.picBullseye.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBullseye.TabIndex = 36;
            this.picBullseye.TabStop = false;
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Location = new System.Drawing.Point(264, 69);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(0, 28);
            this.lblLocation.TabIndex = 35;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(264, 16);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(0, 28);
            this.lblUsername.TabIndex = 34;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(184, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 28);
            this.label1.TabIndex = 33;
            this.label1.Text = "Location:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(214, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 28);
            this.label2.TabIndex = 32;
            this.label2.Text = "User:";
            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            this.chkActive.Checked = true;
            this.chkActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkActive.Location = new System.Drawing.Point(569, 183);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(137, 32);
            this.chkActive.TabIndex = 2;
            this.chkActive.Text = "Active Item";
            this.chkActive.UseVisualStyleBackColor = true;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(156, 302);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(392, 34);
            this.txtDescription.TabIndex = 1;
            // 
            // lblItemID
            // 
            this.lblItemID.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblItemID.Enabled = false;
            this.lblItemID.Location = new System.Drawing.Point(159, 125);
            this.lblItemID.Name = "lblItemID";
            this.lblItemID.Size = new System.Drawing.Size(133, 34);
            this.lblItemID.TabIndex = 61;
            this.lblItemID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(30, 479);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(101, 28);
            this.label9.TabIndex = 60;
            this.label9.Text = "Case Size:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(30, 420);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 28);
            this.label8.TabIndex = 59;
            this.label8.Text = "Weight:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(30, 361);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(99, 28);
            this.label7.TabIndex = 58;
            this.label7.Text = "Category:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(30, 302);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(120, 28);
            this.label6.TabIndex = 57;
            this.label6.Text = "Description:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 243);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 28);
            this.label5.TabIndex = 56;
            this.label5.Text = "SKU:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 184);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 28);
            this.label4.TabIndex = 55;
            this.label4.Text = "Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 28);
            this.label3.TabIndex = 54;
            this.label3.Text = "Item ID:";
            // 
            // grpBasic
            // 
            this.grpBasic.Controls.Add(this.btnAddImage);
            this.grpBasic.Controls.Add(this.btnSave);
            this.grpBasic.Controls.Add(this.btnCancel);
            this.grpBasic.Location = new System.Drawing.Point(551, 575);
            this.grpBasic.Name = "grpBasic";
            this.grpBasic.Size = new System.Drawing.Size(319, 191);
            this.grpBasic.TabIndex = 53;
            this.grpBasic.TabStop = false;
            // 
            // btnAddImage
            // 
            this.btnAddImage.Font = new System.Drawing.Font("Segoe UI Semibold", 11.4F, System.Drawing.FontStyle.Bold);
            this.btnAddImage.Location = new System.Drawing.Point(166, 33);
            this.btnAddImage.Name = "btnAddImage";
            this.btnAddImage.Size = new System.Drawing.Size(147, 63);
            this.btnAddImage.TabIndex = 2;
            this.btnAddImage.Text = "&Add Item Image";
            this.btnAddImage.UseVisualStyleBackColor = true;
            this.btnAddImage.Click += new System.EventHandler(this.btnAddImageLink_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(6, 33);
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
            this.btnCancel.Location = new System.Drawing.Point(6, 121);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(147, 63);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblSKU
            // 
            this.lblSKU.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblSKU.Enabled = false;
            this.lblSKU.Location = new System.Drawing.Point(159, 243);
            this.lblSKU.Name = "lblSKU";
            this.lblSKU.Size = new System.Drawing.Size(133, 34);
            this.lblSKU.TabIndex = 67;
            this.lblSKU.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(30, 538);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(107, 28);
            this.label11.TabIndex = 72;
            this.label11.Text = "Cost Price:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(30, 597);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(116, 28);
            this.label12.TabIndex = 74;
            this.label12.Text = "Retail Price:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(30, 656);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(118, 28);
            this.label14.TabIndex = 76;
            this.label14.Text = "Supplier ID:";
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(159, 715);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(386, 51);
            this.txtNotes.TabIndex = 6;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(30, 714);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(71, 28);
            this.label13.TabIndex = 79;
            this.label13.Text = "Notes:";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1200000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(460, 434);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(194, 28);
            this.label10.TabIndex = 80;
            this.label10.Text = "Image File Location:";
            // 
            // picItemImage
            // 
            this.picItemImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picItemImage.Location = new System.Drawing.Point(569, 233);
            this.picItemImage.Name = "picItemImage";
            this.picItemImage.Size = new System.Drawing.Size(295, 198);
            this.picItemImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picItemImage.TabIndex = 82;
            this.picItemImage.TabStop = false;
            // 
            // txtImageFileLocation
            // 
            this.txtImageFileLocation.Enabled = false;
            this.txtImageFileLocation.Location = new System.Drawing.Point(465, 473);
            this.txtImageFileLocation.Multiline = true;
            this.txtImageFileLocation.Name = "txtImageFileLocation";
            this.txtImageFileLocation.Size = new System.Drawing.Size(402, 93);
            this.txtImageFileLocation.TabIndex = 83;
            // 
            // picHelp
            // 
            this.picHelp.Image = global::JeddoreISDPDesktop.Properties.Resources.help;
            this.picHelp.Location = new System.Drawing.Point(825, 12);
            this.picHelp.Name = "picHelp";
            this.picHelp.Size = new System.Drawing.Size(45, 40);
            this.picHelp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picHelp.TabIndex = 84;
            this.picHelp.TabStop = false;
            this.picHelp.Click += new System.EventHandler(this.picHelp_Click);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(159, 178);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(392, 34);
            this.txtName.TabIndex = 0;
            // 
            // nudWeight
            // 
            this.nudWeight.DecimalPlaces = 2;
            this.nudWeight.Increment = new decimal(new int[] {
            25,
            0,
            0,
            131072});
            this.nudWeight.Location = new System.Drawing.Point(159, 414);
            this.nudWeight.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.nudWeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nudWeight.Name = "nudWeight";
            this.nudWeight.Size = new System.Drawing.Size(92, 34);
            this.nudWeight.TabIndex = 3;
            this.nudWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudWeight.Value = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            // 
            // nudCaseSize
            // 
            this.nudCaseSize.Location = new System.Drawing.Point(159, 477);
            this.nudCaseSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudCaseSize.Name = "nudCaseSize";
            this.nudCaseSize.Size = new System.Drawing.Size(92, 34);
            this.nudCaseSize.TabIndex = 4;
            this.nudCaseSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudCaseSize.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cboCategories
            // 
            this.cboCategories.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCategories.FormattingEnabled = true;
            this.cboCategories.Location = new System.Drawing.Point(159, 353);
            this.cboCategories.Name = "cboCategories";
            this.cboCategories.Size = new System.Drawing.Size(304, 36);
            this.cboCategories.TabIndex = 2;
            // 
            // cboSuppliers
            // 
            this.cboSuppliers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSuppliers.FormattingEnabled = true;
            this.cboSuppliers.Location = new System.Drawing.Point(159, 653);
            this.cboSuppliers.Name = "cboSuppliers";
            this.cboSuppliers.Size = new System.Drawing.Size(304, 36);
            this.cboSuppliers.TabIndex = 5;
            // 
            // nudCostPrice
            // 
            this.nudCostPrice.DecimalPlaces = 2;
            this.nudCostPrice.Enabled = false;
            this.nudCostPrice.Location = new System.Drawing.Point(159, 532);
            this.nudCostPrice.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            131072});
            this.nudCostPrice.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nudCostPrice.Name = "nudCostPrice";
            this.nudCostPrice.Size = new System.Drawing.Size(133, 34);
            this.nudCostPrice.TabIndex = 85;
            this.nudCostPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudCostPrice.Value = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            // 
            // nudRetailPrice
            // 
            this.nudRetailPrice.DecimalPlaces = 2;
            this.nudRetailPrice.Enabled = false;
            this.nudRetailPrice.Location = new System.Drawing.Point(159, 595);
            this.nudRetailPrice.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            131072});
            this.nudRetailPrice.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nudRetailPrice.Name = "nudRetailPrice";
            this.nudRetailPrice.Size = new System.Drawing.Size(133, 34);
            this.nudRetailPrice.TabIndex = 86;
            this.nudRetailPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudRetailPrice.Value = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            // 
            // EditItem
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(882, 778);
            this.Controls.Add(this.nudRetailPrice);
            this.Controls.Add(this.nudCostPrice);
            this.Controls.Add(this.cboSuppliers);
            this.Controls.Add(this.cboCategories);
            this.Controls.Add(this.nudCaseSize);
            this.Controls.Add(this.nudWeight);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.picHelp);
            this.Controls.Add(this.txtImageFileLocation);
            this.Controls.Add(this.picItemImage);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.lblSKU);
            this.Controls.Add(this.chkActive);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblItemID);
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
            this.Name = "EditItem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "";
            this.Text = "Bullseye Inventory Management System - ";
            this.Load += new System.EventHandler(this.EditItem_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EditItem_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.picBullseye)).EndInit();
            this.grpBasic.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picItemImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHelp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCaseSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCostPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRetailPrice)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picBullseye;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkActive;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblItemID;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox grpBasic;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblSKU;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnAddImage;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.PictureBox picItemImage;
        private System.Windows.Forms.TextBox txtImageFileLocation;
        private System.Windows.Forms.PictureBox picHelp;
        private System.Windows.Forms.ToolTip toolTipHelp;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.NumericUpDown nudWeight;
        private System.Windows.Forms.NumericUpDown nudCaseSize;
        private System.Windows.Forms.ComboBox cboCategories;
        private System.Windows.Forms.ComboBox cboSuppliers;
        private System.Windows.Forms.NumericUpDown nudCostPrice;
        private System.Windows.Forms.NumericUpDown nudRetailPrice;
    }
}