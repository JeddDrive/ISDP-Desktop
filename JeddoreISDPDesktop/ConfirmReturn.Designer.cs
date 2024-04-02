namespace JeddoreISDPDesktop
{
    partial class ConfirmReturn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfirmReturn));
            this.label7 = new System.Windows.Forms.Label();
            this.cboItems = new System.Windows.Forms.ComboBox();
            this.lblTxnID = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.picHelp = new System.Windows.Forms.PictureBox();
            this.picBullseye = new System.Windows.Forms.PictureBox();
            this.lblLocation = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.grpBasic = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.chkGoodCondition = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.toolTipHelp = new System.Windows.Forms.ToolTip(this.components);
            this.btnMarkItem = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picHelp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBullseye)).BeginInit();
            this.grpBasic.SuspendLayout();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(41, 190);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(227, 25);
            this.label7.TabIndex = 114;
            this.label7.Text = "Inventory List for Return:";
            // 
            // cboItems
            // 
            this.cboItems.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboItems.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.cboItems.FormattingEnabled = true;
            this.cboItems.Location = new System.Drawing.Point(46, 230);
            this.cboItems.Name = "cboItems";
            this.cboItems.Size = new System.Drawing.Size(625, 33);
            this.cboItems.TabIndex = 0;
            this.cboItems.SelectedIndexChanged += new System.EventHandler(this.cboItems_SelectedIndexChanged);
            // 
            // lblTxnID
            // 
            this.lblTxnID.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTxnID.Enabled = false;
            this.lblTxnID.Location = new System.Drawing.Point(129, 130);
            this.lblTxnID.Name = "lblTxnID";
            this.lblTxnID.Size = new System.Drawing.Size(96, 34);
            this.lblTxnID.TabIndex = 112;
            this.lblTxnID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 28);
            this.label3.TabIndex = 111;
            this.label3.Text = "Return ID:";
            // 
            // picHelp
            // 
            this.picHelp.Image = global::JeddoreISDPDesktop.Properties.Resources.help;
            this.picHelp.Location = new System.Drawing.Point(625, 14);
            this.picHelp.Name = "picHelp";
            this.picHelp.Size = new System.Drawing.Size(45, 40);
            this.picHelp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picHelp.TabIndex = 110;
            this.picHelp.TabStop = false;
            this.picHelp.Click += new System.EventHandler(this.picHelp_Click);
            // 
            // picBullseye
            // 
            this.picBullseye.Image = global::JeddoreISDPDesktop.Properties.Resources.bullseye_nobackground;
            this.picBullseye.Location = new System.Drawing.Point(-1, -2);
            this.picBullseye.Name = "picBullseye";
            this.picBullseye.Size = new System.Drawing.Size(140, 110);
            this.picBullseye.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBullseye.TabIndex = 109;
            this.picBullseye.TabStop = false;
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Location = new System.Drawing.Point(262, 67);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(0, 28);
            this.lblLocation.TabIndex = 108;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(262, 14);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(0, 28);
            this.lblUsername.TabIndex = 107;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(182, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 28);
            this.label1.TabIndex = 106;
            this.label1.Text = "Location:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(212, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 28);
            this.label2.TabIndex = 105;
            this.label2.Text = "User:";
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(102, 463);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(341, 178);
            this.txtNotes.TabIndex = 3;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(40, 463);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(71, 28);
            this.label13.TabIndex = 117;
            this.label13.Text = "Notes:";
            // 
            // grpBasic
            // 
            this.grpBasic.Controls.Add(this.btnSave);
            this.grpBasic.Controls.Add(this.btnCancel);
            this.grpBasic.Location = new System.Drawing.Point(480, 450);
            this.grpBasic.Name = "grpBasic";
            this.grpBasic.Size = new System.Drawing.Size(190, 191);
            this.grpBasic.TabIndex = 115;
            this.grpBasic.TabStop = false;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold);
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
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold);
            this.btnCancel.Location = new System.Drawing.Point(23, 112);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(147, 63);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // chkGoodCondition
            // 
            this.chkGoodCondition.AutoSize = true;
            this.chkGoodCondition.Location = new System.Drawing.Point(45, 319);
            this.chkGoodCondition.Name = "chkGoodCondition";
            this.chkGoodCondition.Size = new System.Drawing.Size(408, 32);
            this.chkGoodCondition.TabIndex = 1;
            this.chkGoodCondition.Text = "Item Marked as being in Good Condition";
            this.chkGoodCondition.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(40, 279);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(609, 25);
            this.label4.TabIndex = 119;
            this.label4.Text = "Please click the button below if the selected item is in good condition:";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1200000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnMarkItem
            // 
            this.btnMarkItem.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.btnMarkItem.Location = new System.Drawing.Point(46, 369);
            this.btnMarkItem.Name = "btnMarkItem";
            this.btnMarkItem.Size = new System.Drawing.Size(359, 63);
            this.btnMarkItem.TabIndex = 2;
            this.btnMarkItem.Text = "&Mark Item as being in Good Condition";
            this.btnMarkItem.UseVisualStyleBackColor = true;
            this.btnMarkItem.Click += new System.EventHandler(this.btnMarkItem_Click);
            // 
            // ConfirmReturn
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(682, 653);
            this.Controls.Add(this.btnMarkItem);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.chkGoodCondition);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.grpBasic);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cboItems);
            this.Controls.Add(this.lblTxnID);
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
            this.Name = "ConfirmReturn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bullseye Inventory Management system - Confirm Return";
            this.Load += new System.EventHandler(this.ConfirmReturn_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ConfirmReturn_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.picHelp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBullseye)).EndInit();
            this.grpBasic.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboItems;
        private System.Windows.Forms.Label lblTxnID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox picHelp;
        private System.Windows.Forms.PictureBox picBullseye;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox grpBasic;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckBox chkGoodCondition;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolTip toolTipHelp;
        private System.Windows.Forms.Button btnMarkItem;
    }
}