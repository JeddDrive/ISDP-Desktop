namespace JeddoreISDPDesktop
{
    partial class ConfirmOrderDelivery
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfirmOrderDelivery));
            this.picHelp = new System.Windows.Forms.PictureBox();
            this.picBullseye = new System.Windows.Forms.PictureBox();
            this.lblLocation = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.grpBasic = new System.Windows.Forms.GroupBox();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.toolTipHelp = new System.Windows.Forms.ToolTip(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblTxnType = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblDestinationSite = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblTxnID = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblDeliveryID = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.nudDeliveryTime = new System.Windows.Forms.NumericUpDown();
            this.txtSignature = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.lblVehicleType = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picHelp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBullseye)).BeginInit();
            this.grpBasic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDeliveryTime)).BeginInit();
            this.SuspendLayout();
            // 
            // picHelp
            // 
            this.picHelp.Image = global::JeddoreISDPDesktop.Properties.Resources.help;
            this.picHelp.Location = new System.Drawing.Point(525, 15);
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
            // grpBasic
            // 
            this.grpBasic.Controls.Add(this.btnConfirm);
            this.grpBasic.Controls.Add(this.btnCancel);
            this.grpBasic.Location = new System.Drawing.Point(380, 450);
            this.grpBasic.Name = "grpBasic";
            this.grpBasic.Size = new System.Drawing.Size(190, 191);
            this.grpBasic.TabIndex = 69;
            this.grpBasic.TabStop = false;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirm.Location = new System.Drawing.Point(23, 33);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(147, 63);
            this.btnConfirm.TabIndex = 0;
            this.btnConfirm.Text = "C&onfirm";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
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
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1200000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblTxnType
            // 
            this.lblTxnType.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTxnType.Enabled = false;
            this.lblTxnType.Location = new System.Drawing.Point(127, 261);
            this.lblTxnType.Name = "lblTxnType";
            this.lblTxnType.Size = new System.Drawing.Size(233, 34);
            this.lblTxnType.TabIndex = 94;
            this.lblTxnType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 261);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 28);
            this.label6.TabIndex = 93;
            this.label6.Text = "Txn Type:";
            // 
            // lblDestinationSite
            // 
            this.lblDestinationSite.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDestinationSite.Enabled = false;
            this.lblDestinationSite.Location = new System.Drawing.Point(127, 197);
            this.lblDestinationSite.Name = "lblDestinationSite";
            this.lblDestinationSite.Size = new System.Drawing.Size(433, 34);
            this.lblDestinationSite.TabIndex = 92;
            this.lblDestinationSite.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 197);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 28);
            this.label4.TabIndex = 91;
            this.label4.Text = "Destination:";
            // 
            // lblTxnID
            // 
            this.lblTxnID.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTxnID.Enabled = false;
            this.lblTxnID.Location = new System.Drawing.Point(127, 136);
            this.lblTxnID.Name = "lblTxnID";
            this.lblTxnID.Size = new System.Drawing.Size(118, 34);
            this.lblTxnID.TabIndex = 90;
            this.lblTxnID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 28);
            this.label3.TabIndex = 89;
            this.label3.Text = "Txn ID:";
            // 
            // lblDeliveryID
            // 
            this.lblDeliveryID.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDeliveryID.Enabled = false;
            this.lblDeliveryID.Location = new System.Drawing.Point(442, 133);
            this.lblDeliveryID.Name = "lblDeliveryID";
            this.lblDeliveryID.Size = new System.Drawing.Size(118, 34);
            this.lblDeliveryID.TabIndex = 96;
            this.lblDeliveryID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(336, 136);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(117, 28);
            this.label7.TabIndex = 95;
            this.label7.Text = "Delivery ID:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(22, 382);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(545, 25);
            this.label5.TabIndex = 97;
            this.label5.Text = "Estimated Delivery Time - Ex. Enter 1.5 for 90 minute delivery:";
            // 
            // nudDeliveryTime
            // 
            this.nudDeliveryTime.DecimalPlaces = 1;
            this.nudDeliveryTime.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudDeliveryTime.Location = new System.Drawing.Point(27, 421);
            this.nudDeliveryTime.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.nudDeliveryTime.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudDeliveryTime.Name = "nudDeliveryTime";
            this.nudDeliveryTime.Size = new System.Drawing.Size(92, 34);
            this.nudDeliveryTime.TabIndex = 0;
            this.nudDeliveryTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudDeliveryTime.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            // 
            // txtSignature
            // 
            this.txtSignature.Location = new System.Drawing.Point(114, 483);
            this.txtSignature.Multiline = true;
            this.txtSignature.Name = "txtSignature";
            this.txtSignature.Size = new System.Drawing.Size(246, 162);
            this.txtSignature.TabIndex = 1;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(22, 483);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(104, 28);
            this.label13.TabIndex = 100;
            this.label13.Text = "Signature:";
            // 
            // lblVehicleType
            // 
            this.lblVehicleType.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblVehicleType.Enabled = false;
            this.lblVehicleType.Location = new System.Drawing.Point(127, 321);
            this.lblVehicleType.Name = "lblVehicleType";
            this.lblVehicleType.Size = new System.Drawing.Size(233, 34);
            this.lblVehicleType.TabIndex = 102;
            this.lblVehicleType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(22, 324);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(131, 28);
            this.label9.TabIndex = 101;
            this.label9.Text = "Vehicle Type:";
            // 
            // ConfirmOrderDelivery
            // 
            this.AcceptButton = this.btnConfirm;
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(582, 653);
            this.Controls.Add(this.lblVehicleType);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtSignature);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.nudDeliveryTime);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblDeliveryID);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblTxnType);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblDestinationSite);
            this.Controls.Add(this.label4);
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
            this.Name = "ConfirmOrderDelivery";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bullseye Inventory Management System - Confirm Order Delivery";
            this.Load += new System.EventHandler(this.ConfirmOrderDelivery_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ConfirmOrderDelivery_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.picHelp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBullseye)).EndInit();
            this.grpBasic.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudDeliveryTime)).EndInit();
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
        private System.Windows.Forms.GroupBox grpBasic;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ToolTip toolTipHelp;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblTxnType;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblDestinationSite;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblTxnID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblDeliveryID;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nudDeliveryTime;
        private System.Windows.Forms.TextBox txtSignature;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblVehicleType;
        private System.Windows.Forms.Label label9;
    }
}