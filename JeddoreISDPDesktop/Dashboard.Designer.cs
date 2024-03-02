﻿namespace JeddoreISDPDesktop
{
    partial class Dashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dashboard));
            this.tabControlDashboard = new System.Windows.Forms.TabControl();
            this.tabOrders = new System.Windows.Forms.TabPage();
            this.btnFulfillOrder = new System.Windows.Forms.Button();
            this.btnManageOrderItems = new System.Windows.Forms.Button();
            this.btnCreateOrder = new System.Windows.Forms.Button();
            this.btnViewOrders = new System.Windows.Forms.Button();
            this.tabInventory = new System.Windows.Forms.TabPage();
            this.btnEditInventory = new System.Windows.Forms.Button();
            this.btnEditItem = new System.Windows.Forms.Button();
            this.tabLossReturn = new System.Windows.Forms.TabPage();
            this.tabReports = new System.Windows.Forms.TabPage();
            this.tabAdmin = new System.Windows.Forms.TabPage();
            this.btnViewSites = new System.Windows.Forms.Button();
            this.btnSetUserPermissions = new System.Windows.Forms.Button();
            this.btnViewUsers = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblLocation = new System.Windows.Forms.Label();
            this.toolTipHelp = new System.Windows.Forms.ToolTip(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.picBullseye = new System.Windows.Forms.PictureBox();
            this.picHelp = new System.Windows.Forms.PictureBox();
            this.tabControlDashboard.SuspendLayout();
            this.tabOrders.SuspendLayout();
            this.tabInventory.SuspendLayout();
            this.tabAdmin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBullseye)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHelp)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControlDashboard
            // 
            this.tabControlDashboard.Controls.Add(this.tabOrders);
            this.tabControlDashboard.Controls.Add(this.tabInventory);
            this.tabControlDashboard.Controls.Add(this.tabLossReturn);
            this.tabControlDashboard.Controls.Add(this.tabReports);
            this.tabControlDashboard.Controls.Add(this.tabAdmin);
            this.tabControlDashboard.Location = new System.Drawing.Point(12, 130);
            this.tabControlDashboard.Name = "tabControlDashboard";
            this.tabControlDashboard.SelectedIndex = 0;
            this.tabControlDashboard.Size = new System.Drawing.Size(958, 478);
            this.tabControlDashboard.TabIndex = 0;
            // 
            // tabOrders
            // 
            this.tabOrders.BackColor = System.Drawing.Color.AliceBlue;
            this.tabOrders.Controls.Add(this.btnFulfillOrder);
            this.tabOrders.Controls.Add(this.btnManageOrderItems);
            this.tabOrders.Controls.Add(this.btnCreateOrder);
            this.tabOrders.Controls.Add(this.btnViewOrders);
            this.tabOrders.Location = new System.Drawing.Point(4, 37);
            this.tabOrders.Name = "tabOrders";
            this.tabOrders.Padding = new System.Windows.Forms.Padding(3);
            this.tabOrders.Size = new System.Drawing.Size(950, 437);
            this.tabOrders.TabIndex = 0;
            this.tabOrders.Text = "Orders";
            // 
            // btnFulfillOrder
            // 
            this.btnFulfillOrder.Enabled = false;
            this.btnFulfillOrder.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFulfillOrder.Location = new System.Drawing.Point(525, 245);
            this.btnFulfillOrder.Name = "btnFulfillOrder";
            this.btnFulfillOrder.Size = new System.Drawing.Size(384, 63);
            this.btnFulfillOrder.TabIndex = 25;
            this.btnFulfillOrder.Text = "&Fulfill Store Order";
            this.btnFulfillOrder.UseVisualStyleBackColor = true;
            this.btnFulfillOrder.Click += new System.EventHandler(this.btnFulfillOrder_Click);
            // 
            // btnManageOrderItems
            // 
            this.btnManageOrderItems.Enabled = false;
            this.btnManageOrderItems.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManageOrderItems.Location = new System.Drawing.Point(525, 67);
            this.btnManageOrderItems.Name = "btnManageOrderItems";
            this.btnManageOrderItems.Size = new System.Drawing.Size(384, 63);
            this.btnManageOrderItems.TabIndex = 24;
            this.btnManageOrderItems.Text = "&Manage Order Items (Warehouse)";
            this.btnManageOrderItems.UseVisualStyleBackColor = true;
            this.btnManageOrderItems.Click += new System.EventHandler(this.btnManageOrderItems_Click);
            // 
            // btnCreateOrder
            // 
            this.btnCreateOrder.Enabled = false;
            this.btnCreateOrder.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateOrder.Location = new System.Drawing.Point(40, 67);
            this.btnCreateOrder.Name = "btnCreateOrder";
            this.btnCreateOrder.Size = new System.Drawing.Size(384, 63);
            this.btnCreateOrder.TabIndex = 23;
            this.btnCreateOrder.Text = "&Create/Edit New Order (Store)";
            this.btnCreateOrder.UseVisualStyleBackColor = true;
            this.btnCreateOrder.Click += new System.EventHandler(this.btnCreateOrder_Click);
            // 
            // btnViewOrders
            // 
            this.btnViewOrders.Enabled = false;
            this.btnViewOrders.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewOrders.Location = new System.Drawing.Point(40, 245);
            this.btnViewOrders.Name = "btnViewOrders";
            this.btnViewOrders.Size = new System.Drawing.Size(384, 63);
            this.btnViewOrders.TabIndex = 22;
            this.btnViewOrders.Text = "&View Orders";
            this.btnViewOrders.UseVisualStyleBackColor = true;
            this.btnViewOrders.Click += new System.EventHandler(this.btnViewOrders_Click);
            // 
            // tabInventory
            // 
            this.tabInventory.BackColor = System.Drawing.Color.AliceBlue;
            this.tabInventory.Controls.Add(this.btnEditInventory);
            this.tabInventory.Controls.Add(this.btnEditItem);
            this.tabInventory.Location = new System.Drawing.Point(4, 37);
            this.tabInventory.Name = "tabInventory";
            this.tabInventory.Padding = new System.Windows.Forms.Padding(3);
            this.tabInventory.Size = new System.Drawing.Size(950, 437);
            this.tabInventory.TabIndex = 1;
            this.tabInventory.Text = "Inventory";
            // 
            // btnEditInventory
            // 
            this.btnEditInventory.Enabled = false;
            this.btnEditInventory.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditInventory.Location = new System.Drawing.Point(258, 237);
            this.btnEditInventory.Name = "btnEditInventory";
            this.btnEditInventory.Size = new System.Drawing.Size(456, 63);
            this.btnEditInventory.TabIndex = 22;
            this.btnEditInventory.Text = "&Edit Inventory";
            this.btnEditInventory.UseVisualStyleBackColor = true;
            this.btnEditInventory.Click += new System.EventHandler(this.btnEditInventory_Click);
            // 
            // btnEditItem
            // 
            this.btnEditItem.Enabled = false;
            this.btnEditItem.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditItem.Location = new System.Drawing.Point(258, 81);
            this.btnEditItem.Name = "btnEditItem";
            this.btnEditItem.Size = new System.Drawing.Size(456, 63);
            this.btnEditItem.TabIndex = 21;
            this.btnEditItem.Text = "&Edit Item";
            this.btnEditItem.UseVisualStyleBackColor = true;
            this.btnEditItem.Click += new System.EventHandler(this.btnEditItem_Click);
            // 
            // tabLossReturn
            // 
            this.tabLossReturn.BackColor = System.Drawing.Color.AliceBlue;
            this.tabLossReturn.Location = new System.Drawing.Point(4, 37);
            this.tabLossReturn.Name = "tabLossReturn";
            this.tabLossReturn.Size = new System.Drawing.Size(950, 437);
            this.tabLossReturn.TabIndex = 2;
            this.tabLossReturn.Text = "Loss/Return";
            // 
            // tabReports
            // 
            this.tabReports.BackColor = System.Drawing.Color.AliceBlue;
            this.tabReports.Location = new System.Drawing.Point(4, 37);
            this.tabReports.Name = "tabReports";
            this.tabReports.Size = new System.Drawing.Size(950, 437);
            this.tabReports.TabIndex = 3;
            this.tabReports.Text = "Reports";
            // 
            // tabAdmin
            // 
            this.tabAdmin.BackColor = System.Drawing.Color.AliceBlue;
            this.tabAdmin.Controls.Add(this.btnViewSites);
            this.tabAdmin.Controls.Add(this.btnSetUserPermissions);
            this.tabAdmin.Controls.Add(this.btnViewUsers);
            this.tabAdmin.Location = new System.Drawing.Point(4, 37);
            this.tabAdmin.Name = "tabAdmin";
            this.tabAdmin.Size = new System.Drawing.Size(950, 437);
            this.tabAdmin.TabIndex = 4;
            this.tabAdmin.Text = "Admin";
            // 
            // btnViewSites
            // 
            this.btnViewSites.Enabled = false;
            this.btnViewSites.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewSites.Location = new System.Drawing.Point(253, 321);
            this.btnViewSites.Name = "btnViewSites";
            this.btnViewSites.Size = new System.Drawing.Size(456, 63);
            this.btnViewSites.TabIndex = 25;
            this.btnViewSites.Text = "&View and Manage Sites";
            this.btnViewSites.UseVisualStyleBackColor = true;
            this.btnViewSites.Click += new System.EventHandler(this.btnViewSites_Click);
            // 
            // btnSetUserPermissions
            // 
            this.btnSetUserPermissions.Enabled = false;
            this.btnSetUserPermissions.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetUserPermissions.Location = new System.Drawing.Point(253, 170);
            this.btnSetUserPermissions.Name = "btnSetUserPermissions";
            this.btnSetUserPermissions.Size = new System.Drawing.Size(456, 63);
            this.btnSetUserPermissions.TabIndex = 24;
            this.btnSetUserPermissions.Text = "&Set User Permissions";
            this.btnSetUserPermissions.UseVisualStyleBackColor = true;
            this.btnSetUserPermissions.Click += new System.EventHandler(this.btnSetUserPermissions_Click);
            // 
            // btnViewUsers
            // 
            this.btnViewUsers.Enabled = false;
            this.btnViewUsers.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewUsers.Location = new System.Drawing.Point(253, 25);
            this.btnViewUsers.Name = "btnViewUsers";
            this.btnViewUsers.Size = new System.Drawing.Size(456, 63);
            this.btnViewUsers.TabIndex = 21;
            this.btnViewUsers.Text = "View and Manage &Users";
            this.btnViewUsers.UseVisualStyleBackColor = true;
            this.btnViewUsers.Click += new System.EventHandler(this.btnViewUsers_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(214, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 28);
            this.label2.TabIndex = 6;
            this.label2.Text = "User:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(184, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 28);
            this.label1.TabIndex = 7;
            this.label1.Text = "Location:";
            // 
            // btnLogout
            // 
            this.btnLogout.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.Location = new System.Drawing.Point(818, 628);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(147, 63);
            this.btnLogout.TabIndex = 11;
            this.btnLogout.Text = "&Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(264, 18);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(0, 28);
            this.lblUsername.TabIndex = 18;
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Location = new System.Drawing.Point(264, 71);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(0, 28);
            this.lblLocation.TabIndex = 19;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1200000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // picBullseye
            // 
            this.picBullseye.Image = global::JeddoreISDPDesktop.Properties.Resources.bullseye_nobackground;
            this.picBullseye.Location = new System.Drawing.Point(1, 2);
            this.picBullseye.Name = "picBullseye";
            this.picBullseye.Size = new System.Drawing.Size(140, 110);
            this.picBullseye.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBullseye.TabIndex = 20;
            this.picBullseye.TabStop = false;
            // 
            // picHelp
            // 
            this.picHelp.Image = global::JeddoreISDPDesktop.Properties.Resources.help;
            this.picHelp.Location = new System.Drawing.Point(921, 35);
            this.picHelp.Name = "picHelp";
            this.picHelp.Size = new System.Drawing.Size(45, 40);
            this.picHelp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picHelp.TabIndex = 10;
            this.picHelp.TabStop = false;
            this.picHelp.Click += new System.EventHandler(this.picHelp_Click);
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnLogout;
            this.ClientSize = new System.Drawing.Size(982, 703);
            this.Controls.Add(this.picBullseye);
            this.Controls.Add(this.lblLocation);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.picHelp);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tabControlDashboard);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Dashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bullseye Inventory Management System - Dashboard";
            this.Load += new System.EventHandler(this.Dashboard_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Dashboard_KeyDown);
            this.tabControlDashboard.ResumeLayout(false);
            this.tabOrders.ResumeLayout(false);
            this.tabInventory.ResumeLayout(false);
            this.tabAdmin.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBullseye)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHelp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlDashboard;
        private System.Windows.Forms.TabPage tabOrders;
        private System.Windows.Forms.TabPage tabInventory;
        private System.Windows.Forms.TabPage tabLossReturn;
        private System.Windows.Forms.TabPage tabReports;
        private System.Windows.Forms.TabPage tabAdmin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox picHelp;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.PictureBox picBullseye;
        private System.Windows.Forms.Button btnViewUsers;
        private System.Windows.Forms.Button btnEditItem;
        private System.Windows.Forms.Button btnSetUserPermissions;
        private System.Windows.Forms.ToolTip toolTipHelp;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnViewSites;
        private System.Windows.Forms.Button btnEditInventory;
        private System.Windows.Forms.Button btnViewOrders;
        private System.Windows.Forms.Button btnCreateOrder;
        private System.Windows.Forms.Button btnManageOrderItems;
        private System.Windows.Forms.Button btnFulfillOrder;
    }
}