namespace JeddoreISDPDesktop
{
    partial class AddEditOrderItem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddEditOrderItem));
            this.lblItemID = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.picHelp = new System.Windows.Forms.PictureBox();
            this.picBullseye = new System.Windows.Forms.PictureBox();
            this.lblLocation = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.toolTipHelp = new System.Windows.Forms.ToolTip(this.components);
            this.grpBasic = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblCategory = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblCaseSize = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.nudOrderQuantity = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblWarehouseQuantity = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picHelp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBullseye)).BeginInit();
            this.grpBasic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudOrderQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // lblItemID
            // 
            this.lblItemID.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblItemID.Enabled = false;
            this.lblItemID.Location = new System.Drawing.Point(163, 135);
            this.lblItemID.Name = "lblItemID";
            this.lblItemID.Size = new System.Drawing.Size(86, 34);
            this.lblItemID.TabIndex = 66;
            this.lblItemID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(63, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 28);
            this.label3.TabIndex = 65;
            this.label3.Text = "Item ID:";
            // 
            // picHelp
            // 
            this.picHelp.Image = global::JeddoreISDPDesktop.Properties.Resources.help;
            this.picHelp.Location = new System.Drawing.Point(575, 16);
            this.picHelp.Name = "picHelp";
            this.picHelp.Size = new System.Drawing.Size(45, 40);
            this.picHelp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picHelp.TabIndex = 64;
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
            this.picBullseye.TabIndex = 63;
            this.picBullseye.TabStop = false;
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Location = new System.Drawing.Point(263, 69);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(0, 28);
            this.lblLocation.TabIndex = 62;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(263, 16);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(0, 28);
            this.lblUsername.TabIndex = 61;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(183, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 28);
            this.label1.TabIndex = 60;
            this.label1.Text = "Location:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(213, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 28);
            this.label2.TabIndex = 59;
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
            this.grpBasic.Location = new System.Drawing.Point(420, 400);
            this.grpBasic.Name = "grpBasic";
            this.grpBasic.Size = new System.Drawing.Size(200, 191);
            this.grpBasic.TabIndex = 83;
            this.grpBasic.TabStop = false;
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(63, 193);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 28);
            this.label4.TabIndex = 85;
            this.label4.Text = "Name:";
            // 
            // lblName
            // 
            this.lblName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblName.Enabled = false;
            this.lblName.Location = new System.Drawing.Point(163, 193);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(443, 34);
            this.lblName.TabIndex = 86;
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCategory
            // 
            this.lblCategory.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCategory.Enabled = false;
            this.lblCategory.Location = new System.Drawing.Point(163, 253);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(322, 34);
            this.lblCategory.TabIndex = 88;
            this.lblCategory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(63, 253);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 28);
            this.label6.TabIndex = 87;
            this.label6.Text = "Category:";
            // 
            // lblCaseSize
            // 
            this.lblCaseSize.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCaseSize.Enabled = false;
            this.lblCaseSize.Location = new System.Drawing.Point(430, 135);
            this.lblCaseSize.Name = "lblCaseSize";
            this.lblCaseSize.Size = new System.Drawing.Size(62, 34);
            this.lblCaseSize.TabIndex = 90;
            this.lblCaseSize.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(323, 135);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 28);
            this.label7.TabIndex = 89;
            this.label7.Text = "Case Size:";
            // 
            // nudOrderQuantity
            // 
            this.nudOrderQuantity.Location = new System.Drawing.Point(218, 370);
            this.nudOrderQuantity.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.nudOrderQuantity.Name = "nudOrderQuantity";
            this.nudOrderQuantity.ReadOnly = true;
            this.nudOrderQuantity.Size = new System.Drawing.Size(92, 34);
            this.nudOrderQuantity.TabIndex = 91;
            this.nudOrderQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(63, 370);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(153, 28);
            this.label12.TabIndex = 92;
            this.label12.Text = "Order Quantity:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(63, 313);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(203, 28);
            this.label5.TabIndex = 94;
            this.label5.Text = "Warehouse Quantity:";
            // 
            // lblWarehouseQuantity
            // 
            this.lblWarehouseQuantity.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblWarehouseQuantity.Enabled = false;
            this.lblWarehouseQuantity.Location = new System.Drawing.Point(251, 313);
            this.lblWarehouseQuantity.Name = "lblWarehouseQuantity";
            this.lblWarehouseQuantity.Size = new System.Drawing.Size(73, 34);
            this.lblWarehouseQuantity.TabIndex = 95;
            this.lblWarehouseQuantity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(163, 429);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(236, 162);
            this.txtNotes.TabIndex = 82;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(63, 429);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(71, 28);
            this.label13.TabIndex = 83;
            this.label13.Text = "Notes:";
            // 
            // AddEditOrderItem
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(632, 603);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.lblWarehouseQuantity);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.nudOrderQuantity);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.lblCaseSize);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.label4);
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
            this.Name = "AddEditOrderItem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bullseye Inventory Management System - Add/Edit Order Item ";
            this.Load += new System.EventHandler(this.AddEditOrderItem_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AddEditOrderItem_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.picHelp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBullseye)).EndInit();
            this.grpBasic.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudOrderQuantity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblItemID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox picHelp;
        private System.Windows.Forms.PictureBox picBullseye;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolTip toolTipHelp;
        private System.Windows.Forms.GroupBox grpBasic;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblCaseSize;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown nudOrderQuantity;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblWarehouseQuantity;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Label label13;
    }
}