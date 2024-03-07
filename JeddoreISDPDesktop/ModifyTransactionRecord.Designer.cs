namespace JeddoreISDPDesktop
{
    partial class ModifyTransactionRecord
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModifyTransactionRecord));
            this.picHelp = new System.Windows.Forms.PictureBox();
            this.picBullseye = new System.Windows.Forms.PictureBox();
            this.lblLocation = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.toolTipHelp = new System.Windows.Forms.ToolTip(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.grpBasic = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblTxnID = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboDestinationSites = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cboOriginSites = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboTxnTypes = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboTxnStatuses = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboDeliveryIDs = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.chkEmergency = new System.Windows.Forms.CheckBox();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.dtpShipDateTime = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.dtpShipDate = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.picHelp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBullseye)).BeginInit();
            this.grpBasic.SuspendLayout();
            this.SuspendLayout();
            // 
            // picHelp
            // 
            this.picHelp.Image = global::JeddoreISDPDesktop.Properties.Resources.help;
            this.picHelp.Location = new System.Drawing.Point(625, 15);
            this.picHelp.Name = "picHelp";
            this.picHelp.Size = new System.Drawing.Size(45, 40);
            this.picHelp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picHelp.TabIndex = 68;
            this.picHelp.TabStop = false;
            this.picHelp.Click += new System.EventHandler(this.picHelp_Click);
            // 
            // picBullseye
            // 
            this.picBullseye.Image = global::JeddoreISDPDesktop.Properties.Resources.bullseye_nobackground;
            this.picBullseye.Location = new System.Drawing.Point(0, -1);
            this.picBullseye.Name = "picBullseye";
            this.picBullseye.Size = new System.Drawing.Size(140, 110);
            this.picBullseye.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBullseye.TabIndex = 67;
            this.picBullseye.TabStop = false;
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Location = new System.Drawing.Point(263, 68);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(0, 28);
            this.lblLocation.TabIndex = 66;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(263, 15);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(0, 28);
            this.lblUsername.TabIndex = 65;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(183, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 28);
            this.label1.TabIndex = 64;
            this.label1.Text = "Location:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(213, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 28);
            this.label2.TabIndex = 63;
            this.label2.Text = "User:";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1200000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // grpBasic
            // 
            this.grpBasic.Controls.Add(this.btnSave);
            this.grpBasic.Controls.Add(this.btnCancel);
            this.grpBasic.Location = new System.Drawing.Point(480, 550);
            this.grpBasic.Name = "grpBasic";
            this.grpBasic.Size = new System.Drawing.Size(190, 191);
            this.grpBasic.TabIndex = 69;
            this.grpBasic.TabStop = false;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(23, 33);
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
            this.btnCancel.Location = new System.Drawing.Point(23, 112);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(147, 63);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblTxnID
            // 
            this.lblTxnID.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTxnID.Enabled = false;
            this.lblTxnID.Location = new System.Drawing.Point(182, 137);
            this.lblTxnID.Name = "lblTxnID";
            this.lblTxnID.Size = new System.Drawing.Size(96, 34);
            this.lblTxnID.TabIndex = 96;
            this.lblTxnID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(145, 28);
            this.label3.TabIndex = 95;
            this.label3.Text = "Transaction ID:";
            // 
            // cboDestinationSites
            // 
            this.cboDestinationSites.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDestinationSites.FormattingEnabled = true;
            this.cboDestinationSites.Location = new System.Drawing.Point(188, 265);
            this.cboDestinationSites.Name = "cboDestinationSites";
            this.cboDestinationSites.Size = new System.Drawing.Size(230, 36);
            this.cboDestinationSites.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(44, 268);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(161, 28);
            this.label8.TabIndex = 101;
            this.label8.Text = "Destination Site:";
            // 
            // cboOriginSites
            // 
            this.cboOriginSites.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOriginSites.FormattingEnabled = true;
            this.cboOriginSites.Location = new System.Drawing.Point(188, 200);
            this.cboOriginSites.Name = "cboOriginSites";
            this.cboOriginSites.Size = new System.Drawing.Size(230, 36);
            this.cboOriginSites.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(44, 203);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 28);
            this.label4.TabIndex = 103;
            this.label4.Text = "Origin Site:";
            // 
            // cboTxnTypes
            // 
            this.cboTxnTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTxnTypes.FormattingEnabled = true;
            this.cboTxnTypes.Location = new System.Drawing.Point(188, 330);
            this.cboTxnTypes.Name = "cboTxnTypes";
            this.cboTxnTypes.Size = new System.Drawing.Size(230, 36);
            this.cboTxnTypes.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(44, 333);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(168, 28);
            this.label5.TabIndex = 105;
            this.label5.Text = "Transaction Type:";
            // 
            // cboTxnStatuses
            // 
            this.cboTxnStatuses.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTxnStatuses.FormattingEnabled = true;
            this.cboTxnStatuses.Location = new System.Drawing.Point(188, 396);
            this.cboTxnStatuses.Name = "cboTxnStatuses";
            this.cboTxnStatuses.Size = new System.Drawing.Size(230, 36);
            this.cboTxnStatuses.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(44, 399);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(180, 28);
            this.label6.TabIndex = 107;
            this.label6.Text = "Transaction Status:";
            // 
            // cboDeliveryIDs
            // 
            this.cboDeliveryIDs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDeliveryIDs.FormattingEnabled = true;
            this.cboDeliveryIDs.Location = new System.Drawing.Point(188, 461);
            this.cboDeliveryIDs.Name = "cboDeliveryIDs";
            this.cboDeliveryIDs.Size = new System.Drawing.Size(188, 36);
            this.cboDeliveryIDs.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(44, 464);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(117, 28);
            this.label7.TabIndex = 109;
            this.label7.Text = "Delivery ID:";
            // 
            // chkEmergency
            // 
            this.chkEmergency.AutoSize = true;
            this.chkEmergency.Location = new System.Drawing.Point(436, 139);
            this.chkEmergency.Name = "chkEmergency";
            this.chkEmergency.Size = new System.Drawing.Size(214, 32);
            this.chkEmergency.TabIndex = 8;
            this.chkEmergency.Text = "Emergency Delivery";
            this.chkEmergency.UseVisualStyleBackColor = true;
            // 
            // txtBarcode
            // 
            this.txtBarcode.Location = new System.Drawing.Point(188, 524);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(230, 34);
            this.txtBarcode.TabIndex = 5;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(44, 524);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(99, 28);
            this.label9.TabIndex = 112;
            this.label9.Text = "Bar Code:";
            // 
            // dtpShipDateTime
            // 
            this.dtpShipDateTime.CustomFormat = "";
            this.dtpShipDateTime.Font = new System.Drawing.Font("Tahoma", 13F);
            this.dtpShipDateTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpShipDateTime.Location = new System.Drawing.Point(49, 676);
            this.dtpShipDateTime.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.dtpShipDateTime.MinDate = new System.DateTime(2018, 1, 1, 0, 0, 0, 0);
            this.dtpShipDateTime.Name = "dtpShipDateTime";
            this.dtpShipDateTime.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtpShipDateTime.ShowUpDown = true;
            this.dtpShipDateTime.Size = new System.Drawing.Size(271, 34);
            this.dtpShipDateTime.TabIndex = 7;
            this.dtpShipDateTime.Value = new System.DateTime(2024, 2, 28, 9, 0, 0, 0);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(44, 583);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(411, 28);
            this.label10.TabIndex = 114;
            this.label10.Text = "Update Ship Date and Time For Transaction:";
            // 
            // dtpShipDate
            // 
            this.dtpShipDate.CustomFormat = "MMMMdd,  yyyy";
            this.dtpShipDate.Font = new System.Drawing.Font("Tahoma", 13F);
            this.dtpShipDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpShipDate.Location = new System.Drawing.Point(49, 625);
            this.dtpShipDate.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.dtpShipDate.MinDate = new System.DateTime(2018, 1, 1, 0, 0, 0, 0);
            this.dtpShipDate.Name = "dtpShipDate";
            this.dtpShipDate.Size = new System.Drawing.Size(271, 34);
            this.dtpShipDate.TabIndex = 6;
            this.dtpShipDate.Value = new System.DateTime(2024, 3, 2, 17, 27, 12, 0);
            // 
            // ModifyTransactionRecord
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(682, 753);
            this.Controls.Add(this.dtpShipDateTime);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.dtpShipDate);
            this.Controls.Add(this.txtBarcode);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.chkEmergency);
            this.Controls.Add(this.cboDeliveryIDs);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cboTxnStatuses);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cboTxnTypes);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cboOriginSites);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboDestinationSites);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblTxnID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.grpBasic);
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
            this.Name = "ModifyTransactionRecord";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bullseye Inventory Management System - Modify Transaction Record";
            this.Load += new System.EventHandler(this.ModifyTransactionRecord_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ModifyTransactionRecord_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.picHelp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBullseye)).EndInit();
            this.grpBasic.ResumeLayout(false);
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
        private System.Windows.Forms.GroupBox grpBasic;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblTxnID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboDestinationSites;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboOriginSites;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboTxnTypes;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboTxnStatuses;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboDeliveryIDs;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox chkEmergency;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtpShipDateTime;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dtpShipDate;
    }
}