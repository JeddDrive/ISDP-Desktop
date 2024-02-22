namespace JeddoreISDPDesktop
{
    partial class CreateNewOrder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateNewOrder));
            this.grpBasic = new System.Windows.Forms.GroupBox();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.radStoreOrder = new System.Windows.Forms.RadioButton();
            this.radEmergencyOrder = new System.Windows.Forms.RadioButton();
            this.toolTipHelp = new System.Windows.Forms.ToolTip(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.picHelp = new System.Windows.Forms.PictureBox();
            this.picBullseye = new System.Windows.Forms.PictureBox();
            this.lblLocation = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.grpBasic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHelp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBullseye)).BeginInit();
            this.SuspendLayout();
            // 
            // grpBasic
            // 
            this.grpBasic.Controls.Add(this.btnCreate);
            this.grpBasic.Controls.Add(this.btnCancel);
            this.grpBasic.Location = new System.Drawing.Point(188, 310);
            this.grpBasic.Name = "grpBasic";
            this.grpBasic.Size = new System.Drawing.Size(421, 131);
            this.grpBasic.TabIndex = 83;
            this.grpBasic.TabStop = false;
            // 
            // btnCreate
            // 
            this.btnCreate.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreate.Location = new System.Drawing.Point(256, 33);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(147, 63);
            this.btnCreate.TabIndex = 0;
            this.btnCreate.Text = "&Create";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(18, 33);
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
            this.label3.Location = new System.Drawing.Point(183, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(478, 28);
            this.label3.TabIndex = 84;
            this.label3.Text = "Please choose an order type to create for your site:";
            // 
            // radStoreOrder
            // 
            this.radStoreOrder.AutoSize = true;
            this.radStoreOrder.Checked = true;
            this.radStoreOrder.Location = new System.Drawing.Point(322, 188);
            this.radStoreOrder.Name = "radStoreOrder";
            this.radStoreOrder.Size = new System.Drawing.Size(138, 32);
            this.radStoreOrder.TabIndex = 0;
            this.radStoreOrder.TabStop = true;
            this.radStoreOrder.Text = "Store Order";
            this.radStoreOrder.UseVisualStyleBackColor = true;
            // 
            // radEmergencyOrder
            // 
            this.radEmergencyOrder.AutoSize = true;
            this.radEmergencyOrder.Location = new System.Drawing.Point(322, 240);
            this.radEmergencyOrder.Name = "radEmergencyOrder";
            this.radEmergencyOrder.Size = new System.Drawing.Size(191, 32);
            this.radEmergencyOrder.TabIndex = 1;
            this.radEmergencyOrder.Text = "Emergency Order";
            this.radEmergencyOrder.UseVisualStyleBackColor = true;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1200000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // picHelp
            // 
            this.picHelp.Image = global::JeddoreISDPDesktop.Properties.Resources.help;
            this.picHelp.Location = new System.Drawing.Point(725, 16);
            this.picHelp.Name = "picHelp";
            this.picHelp.Size = new System.Drawing.Size(45, 40);
            this.picHelp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picHelp.TabIndex = 90;
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
            this.picBullseye.TabIndex = 89;
            this.picBullseye.TabStop = false;
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Location = new System.Drawing.Point(263, 69);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(0, 28);
            this.lblLocation.TabIndex = 88;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(263, 16);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(0, 28);
            this.lblUsername.TabIndex = 87;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(183, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 28);
            this.label1.TabIndex = 86;
            this.label1.Text = "Location:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(213, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 28);
            this.label2.TabIndex = 85;
            this.label2.Text = "User:";
            // 
            // CreateNewOrder
            // 
            this.AcceptButton = this.btnCreate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(782, 453);
            this.Controls.Add(this.picHelp);
            this.Controls.Add(this.picBullseye);
            this.Controls.Add(this.lblLocation);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.radEmergencyOrder);
            this.Controls.Add(this.radStoreOrder);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.grpBasic);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "CreateNewOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bullseye Inventory Management System - Create New Order";
            this.Load += new System.EventHandler(this.CreateNewOrder_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CreateNewOrder_KeyDown);
            this.grpBasic.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picHelp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBullseye)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox grpBasic;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton radStoreOrder;
        private System.Windows.Forms.RadioButton radEmergencyOrder;
        private System.Windows.Forms.ToolTip toolTipHelp;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox picHelp;
        private System.Windows.Forms.PictureBox picBullseye;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}