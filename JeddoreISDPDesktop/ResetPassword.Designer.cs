namespace JeddoreISDPDesktop
{
    partial class ResetPassword
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
            this.txtPasswordConfirm = new System.Windows.Forms.TextBox();
            this.txtPasswordNew = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnResetPassword = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.picEyeConfirmShow = new System.Windows.Forms.PictureBox();
            this.picEyeNewShow = new System.Windows.Forms.PictureBox();
            this.picHelp = new System.Windows.Forms.PictureBox();
            this.picBullseye = new System.Windows.Forms.PictureBox();
            this.picEyeNewHide = new System.Windows.Forms.PictureBox();
            this.picEyeConfirmHide = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picEyeConfirmShow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEyeNewShow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHelp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBullseye)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEyeNewHide)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEyeConfirmHide)).BeginInit();
            this.SuspendLayout();
            // 
            // txtPasswordConfirm
            // 
            this.txtPasswordConfirm.Location = new System.Drawing.Point(307, 262);
            this.txtPasswordConfirm.Name = "txtPasswordConfirm";
            this.txtPasswordConfirm.PasswordChar = '*';
            this.txtPasswordConfirm.Size = new System.Drawing.Size(283, 34);
            this.txtPasswordConfirm.TabIndex = 1;
            // 
            // txtPasswordNew
            // 
            this.txtPasswordNew.Location = new System.Drawing.Point(307, 183);
            this.txtPasswordNew.Name = "txtPasswordNew";
            this.txtPasswordNew.PasswordChar = '*';
            this.txtPasswordNew.Size = new System.Drawing.Size(283, 34);
            this.txtPasswordNew.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(120, 268);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(181, 28);
            this.label3.TabIndex = 10;
            this.label3.Text = "Confirm Password:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(152, 183);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 28);
            this.label2.TabIndex = 9;
            this.label2.Text = "New Password:";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(518, 354);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(152, 71);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnResetPassword
            // 
            this.btnResetPassword.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetPassword.Location = new System.Drawing.Point(125, 354);
            this.btnResetPassword.Name = "btnResetPassword";
            this.btnResetPassword.Size = new System.Drawing.Size(152, 71);
            this.btnResetPassword.TabIndex = 2;
            this.btnResetPassword.Text = "&Reset Password";
            this.btnResetPassword.UseVisualStyleBackColor = true;
            this.btnResetPassword.Click += new System.EventHandler(this.btnResetPassword_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(299, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(259, 50);
            this.label1.TabIndex = 12;
            this.label1.Text = "Reset Password";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(192, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 28);
            this.label4.TabIndex = 16;
            this.label4.Text = "Username:";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(302, 110);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(0, 28);
            this.lblUsername.TabIndex = 17;
            // 
            // picEyeConfirmShow
            // 
            this.picEyeConfirmShow.Image = global::JeddoreISDPDesktop.Properties.Resources.eyeDisplay;
            this.picEyeConfirmShow.Location = new System.Drawing.Point(625, 256);
            this.picEyeConfirmShow.Name = "picEyeConfirmShow";
            this.picEyeConfirmShow.Size = new System.Drawing.Size(45, 40);
            this.picEyeConfirmShow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picEyeConfirmShow.TabIndex = 19;
            this.picEyeConfirmShow.TabStop = false;
            this.picEyeConfirmShow.Click += new System.EventHandler(this.picEyeConfirmShow_Click);
            // 
            // picEyeNewShow
            // 
            this.picEyeNewShow.Image = global::JeddoreISDPDesktop.Properties.Resources.eyeDisplay;
            this.picEyeNewShow.Location = new System.Drawing.Point(625, 177);
            this.picEyeNewShow.Name = "picEyeNewShow";
            this.picEyeNewShow.Size = new System.Drawing.Size(45, 40);
            this.picEyeNewShow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picEyeNewShow.TabIndex = 18;
            this.picEyeNewShow.TabStop = false;
            this.picEyeNewShow.Click += new System.EventHandler(this.picEyeNewShow_Click);
            // 
            // picHelp
            // 
            this.picHelp.Image = global::JeddoreISDPDesktop.Properties.Resources.help;
            this.picHelp.Location = new System.Drawing.Point(725, 25);
            this.picHelp.Name = "picHelp";
            this.picHelp.Size = new System.Drawing.Size(45, 40);
            this.picHelp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picHelp.TabIndex = 15;
            this.picHelp.TabStop = false;
            this.picHelp.Click += new System.EventHandler(this.picHelp_Click);
            // 
            // picBullseye
            // 
            this.picBullseye.Image = global::JeddoreISDPDesktop.Properties.Resources.bullseye_nobackground;
            this.picBullseye.Location = new System.Drawing.Point(0, 3);
            this.picBullseye.Name = "picBullseye";
            this.picBullseye.Size = new System.Drawing.Size(140, 110);
            this.picBullseye.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBullseye.TabIndex = 11;
            this.picBullseye.TabStop = false;
            // 
            // picEyeNewHide
            // 
            this.picEyeNewHide.Image = global::JeddoreISDPDesktop.Properties.Resources.eyeHide;
            this.picEyeNewHide.Location = new System.Drawing.Point(625, 177);
            this.picEyeNewHide.Name = "picEyeNewHide";
            this.picEyeNewHide.Size = new System.Drawing.Size(45, 40);
            this.picEyeNewHide.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picEyeNewHide.TabIndex = 20;
            this.picEyeNewHide.TabStop = false;
            this.picEyeNewHide.Click += new System.EventHandler(this.picEyeNewHide_Click);
            // 
            // picEyeConfirmHide
            // 
            this.picEyeConfirmHide.Image = global::JeddoreISDPDesktop.Properties.Resources.eyeHide;
            this.picEyeConfirmHide.Location = new System.Drawing.Point(625, 256);
            this.picEyeConfirmHide.Name = "picEyeConfirmHide";
            this.picEyeConfirmHide.Size = new System.Drawing.Size(45, 40);
            this.picEyeConfirmHide.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picEyeConfirmHide.TabIndex = 21;
            this.picEyeConfirmHide.TabStop = false;
            this.picEyeConfirmHide.Click += new System.EventHandler(this.picEyeConfirmHide_Click);
            // 
            // ResetPassword
            // 
            this.AcceptButton = this.btnResetPassword;
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(782, 453);
            this.Controls.Add(this.picEyeConfirmShow);
            this.Controls.Add(this.picEyeNewShow);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.picHelp);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnResetPassword);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picBullseye);
            this.Controls.Add(this.txtPasswordConfirm);
            this.Controls.Add(this.txtPasswordNew);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.picEyeNewHide);
            this.Controls.Add(this.picEyeConfirmHide);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ResetPassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bullseye Inventory Management System - Reset Password";
            ((System.ComponentModel.ISupportInitialize)(this.picEyeConfirmShow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEyeNewShow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHelp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBullseye)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEyeNewHide)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEyeConfirmHide)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPasswordConfirm;
        private System.Windows.Forms.TextBox txtPasswordNew;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox picHelp;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnResetPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox picBullseye;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.PictureBox picEyeNewShow;
        private System.Windows.Forms.PictureBox picEyeConfirmShow;
        private System.Windows.Forms.PictureBox picEyeNewHide;
        private System.Windows.Forms.PictureBox picEyeConfirmHide;
    }
}