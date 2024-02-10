namespace JeddoreISDPDesktop
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.label1 = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblForgotPassword = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.toolTipHelp = new System.Windows.Forms.ToolTip(this.components);
            this.picEyeShow = new System.Windows.Forms.PictureBox();
            this.picHelp = new System.Windows.Forms.PictureBox();
            this.picBullseye = new System.Windows.Forms.PictureBox();
            this.picEyeHide = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picEyeShow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHelp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBullseye)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEyeHide)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(343, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 50);
            this.label1.TabIndex = 1;
            this.label1.Text = "Login";
            // 
            // btnLogin
            // 
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.Location = new System.Drawing.Point(130, 320);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(161, 63);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "&Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnExit
            // 
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(495, 320);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(161, 63);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "&Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblForgotPassword
            // 
            this.lblForgotPassword.AutoSize = true;
            this.lblForgotPassword.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblForgotPassword.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lblForgotPassword.Location = new System.Drawing.Point(317, 408);
            this.lblForgotPassword.Name = "lblForgotPassword";
            this.lblForgotPassword.Size = new System.Drawing.Size(178, 28);
            this.lblForgotPassword.TabIndex = 4;
            this.lblForgotPassword.Text = "&Forgot Password?";
            this.lblForgotPassword.Click += new System.EventHandler(this.lblForgotPassword_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(185, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 28);
            this.label2.TabIndex = 5;
            this.label2.Text = "Username:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(189, 215);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 28);
            this.label3.TabIndex = 6;
            this.label3.Text = "Password:";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(297, 133);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(283, 34);
            this.txtUsername.TabIndex = 0;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(297, 212);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(283, 34);
            this.txtPassword.TabIndex = 1;
            // 
            // picEyeShow
            // 
            this.picEyeShow.Image = global::JeddoreISDPDesktop.Properties.Resources.eyeDisplay;
            this.picEyeShow.Location = new System.Drawing.Point(611, 206);
            this.picEyeShow.Name = "picEyeShow";
            this.picEyeShow.Size = new System.Drawing.Size(45, 40);
            this.picEyeShow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picEyeShow.TabIndex = 19;
            this.picEyeShow.TabStop = false;
            this.picEyeShow.Click += new System.EventHandler(this.picEyeShow_Click_1);
            // 
            // picHelp
            // 
            this.picHelp.Image = global::JeddoreISDPDesktop.Properties.Resources.help;
            this.picHelp.Location = new System.Drawing.Point(725, 29);
            this.picHelp.Name = "picHelp";
            this.picHelp.Size = new System.Drawing.Size(45, 40);
            this.picHelp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picHelp.TabIndex = 9;
            this.picHelp.TabStop = false;
            this.picHelp.Click += new System.EventHandler(this.picHelp_Click);
            // 
            // picBullseye
            // 
            this.picBullseye.Image = global::JeddoreISDPDesktop.Properties.Resources.bullseye_nobackground;
            this.picBullseye.Location = new System.Drawing.Point(1, 1);
            this.picBullseye.Name = "picBullseye";
            this.picBullseye.Size = new System.Drawing.Size(140, 110);
            this.picBullseye.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBullseye.TabIndex = 0;
            this.picBullseye.TabStop = false;
            // 
            // picEyeHide
            // 
            this.picEyeHide.Image = global::JeddoreISDPDesktop.Properties.Resources.eyeHide;
            this.picEyeHide.Location = new System.Drawing.Point(611, 206);
            this.picEyeHide.Name = "picEyeHide";
            this.picEyeHide.Size = new System.Drawing.Size(45, 40);
            this.picEyeHide.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picEyeHide.TabIndex = 20;
            this.picEyeHide.TabStop = false;
            this.picEyeHide.Visible = false;
            this.picEyeHide.Click += new System.EventHandler(this.picEyeHide_Click);
            // 
            // Login
            // 
            this.AcceptButton = this.btnLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(782, 453);
            this.Controls.Add(this.picEyeShow);
            this.Controls.Add(this.picHelp);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblForgotPassword);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picBullseye);
            this.Controls.Add(this.picEyeHide);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bullseye Inventory Management System - Login";
            this.Activated += new System.EventHandler(this.Login_Activated);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Login_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.picEyeShow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHelp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBullseye)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEyeHide)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picBullseye;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblForgotPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.PictureBox picHelp;
        private System.Windows.Forms.ToolTip toolTipHelp;
        private System.Windows.Forms.PictureBox picEyeShow;
        private System.Windows.Forms.PictureBox picEyeHide;
    }
}

