namespace JeddoreISDPDesktop
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
            this.btnCreateSupplierOrder = new System.Windows.Forms.Button();
            this.btnPrepareOnlineOrder = new System.Windows.Forms.Button();
            this.btnCheckDeliveries = new System.Windows.Forms.Button();
            this.btnPickupAndDeliverOrders = new System.Windows.Forms.Button();
            this.btnFulfillOrder = new System.Windows.Forms.Button();
            this.btnManageOrderItems = new System.Windows.Forms.Button();
            this.btnCreateOrder = new System.Windows.Forms.Button();
            this.btnViewOrders = new System.Windows.Forms.Button();
            this.tabInventory = new System.Windows.Forms.TabPage();
            this.btnViewInventory = new System.Windows.Forms.Button();
            this.btnEditItem = new System.Windows.Forms.Button();
            this.tabLossReturn = new System.Windows.Forms.TabPage();
            this.btnCreateLossReturn = new System.Windows.Forms.Button();
            this.tabReports = new System.Windows.Forms.TabPage();
            this.tabAdmin = new System.Windows.Forms.TabPage();
            this.btnModifyTxnRecords = new System.Windows.Forms.Button();
            this.btnViewSuppliers = new System.Windows.Forms.Button();
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
            this.btnGenerateReports = new System.Windows.Forms.Button();
            this.tabControlDashboard.SuspendLayout();
            this.tabOrders.SuspendLayout();
            this.tabInventory.SuspendLayout();
            this.tabLossReturn.SuspendLayout();
            this.tabReports.SuspendLayout();
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
            this.tabOrders.Controls.Add(this.btnCreateSupplierOrder);
            this.tabOrders.Controls.Add(this.btnPrepareOnlineOrder);
            this.tabOrders.Controls.Add(this.btnCheckDeliveries);
            this.tabOrders.Controls.Add(this.btnPickupAndDeliverOrders);
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
            // btnCreateSupplierOrder
            // 
            this.btnCreateSupplierOrder.Enabled = false;
            this.btnCreateSupplierOrder.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateSupplierOrder.Location = new System.Drawing.Point(524, 352);
            this.btnCreateSupplierOrder.Name = "btnCreateSupplierOrder";
            this.btnCreateSupplierOrder.Size = new System.Drawing.Size(384, 63);
            this.btnCreateSupplierOrder.TabIndex = 29;
            this.btnCreateSupplierOrder.Text = "&Create/Edit New Supplier Order";
            this.btnCreateSupplierOrder.UseVisualStyleBackColor = true;
            this.btnCreateSupplierOrder.Click += new System.EventHandler(this.btnCreateSupplierOrder_Click);
            // 
            // btnPrepareOnlineOrder
            // 
            this.btnPrepareOnlineOrder.Enabled = false;
            this.btnPrepareOnlineOrder.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrepareOnlineOrder.Location = new System.Drawing.Point(39, 352);
            this.btnPrepareOnlineOrder.Name = "btnPrepareOnlineOrder";
            this.btnPrepareOnlineOrder.Size = new System.Drawing.Size(384, 63);
            this.btnPrepareOnlineOrder.TabIndex = 28;
            this.btnPrepareOnlineOrder.Text = "&Prepare and Receive Online Orders";
            this.btnPrepareOnlineOrder.UseVisualStyleBackColor = true;
            this.btnPrepareOnlineOrder.Click += new System.EventHandler(this.btnPrepareOnlineOrder_Click);
            // 
            // btnCheckDeliveries
            // 
            this.btnCheckDeliveries.Enabled = false;
            this.btnCheckDeliveries.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheckDeliveries.Location = new System.Drawing.Point(524, 245);
            this.btnCheckDeliveries.Name = "btnCheckDeliveries";
            this.btnCheckDeliveries.Size = new System.Drawing.Size(384, 63);
            this.btnCheckDeliveries.TabIndex = 27;
            this.btnCheckDeliveries.Text = "C&heck Deliveries";
            this.btnCheckDeliveries.UseVisualStyleBackColor = true;
            this.btnCheckDeliveries.Click += new System.EventHandler(this.btnCheckDeliveries_Click);
            // 
            // btnPickupAndDeliverOrders
            // 
            this.btnPickupAndDeliverOrders.Enabled = false;
            this.btnPickupAndDeliverOrders.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPickupAndDeliverOrders.Location = new System.Drawing.Point(39, 245);
            this.btnPickupAndDeliverOrders.Name = "btnPickupAndDeliverOrders";
            this.btnPickupAndDeliverOrders.Size = new System.Drawing.Size(384, 63);
            this.btnPickupAndDeliverOrders.TabIndex = 26;
            this.btnPickupAndDeliverOrders.Text = "&Pickup and Deliver Store Orders";
            this.btnPickupAndDeliverOrders.UseVisualStyleBackColor = true;
            this.btnPickupAndDeliverOrders.Click += new System.EventHandler(this.btnPickupAndDeliverOrders_Click);
            // 
            // btnFulfillOrder
            // 
            this.btnFulfillOrder.Enabled = false;
            this.btnFulfillOrder.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFulfillOrder.Location = new System.Drawing.Point(524, 138);
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
            this.btnManageOrderItems.Location = new System.Drawing.Point(524, 31);
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
            this.btnCreateOrder.Location = new System.Drawing.Point(39, 31);
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
            this.btnViewOrders.Location = new System.Drawing.Point(39, 138);
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
            this.tabInventory.Controls.Add(this.btnViewInventory);
            this.tabInventory.Controls.Add(this.btnEditItem);
            this.tabInventory.Location = new System.Drawing.Point(4, 37);
            this.tabInventory.Name = "tabInventory";
            this.tabInventory.Padding = new System.Windows.Forms.Padding(3);
            this.tabInventory.Size = new System.Drawing.Size(950, 437);
            this.tabInventory.TabIndex = 1;
            this.tabInventory.Text = "Inventory";
            // 
            // btnViewInventory
            // 
            this.btnViewInventory.Enabled = false;
            this.btnViewInventory.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewInventory.Location = new System.Drawing.Point(254, 246);
            this.btnViewInventory.Name = "btnViewInventory";
            this.btnViewInventory.Size = new System.Drawing.Size(456, 63);
            this.btnViewInventory.TabIndex = 22;
            this.btnViewInventory.Text = "&Edit/Move Inventory";
            this.btnViewInventory.UseVisualStyleBackColor = true;
            this.btnViewInventory.Click += new System.EventHandler(this.btnEditInventory_Click);
            // 
            // btnEditItem
            // 
            this.btnEditItem.Enabled = false;
            this.btnEditItem.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditItem.Location = new System.Drawing.Point(254, 81);
            this.btnEditItem.Name = "btnEditItem";
            this.btnEditItem.Size = new System.Drawing.Size(456, 63);
            this.btnEditItem.TabIndex = 21;
            this.btnEditItem.Text = "&Edit/Add Product Items";
            this.btnEditItem.UseVisualStyleBackColor = true;
            this.btnEditItem.Click += new System.EventHandler(this.btnEditItem_Click);
            // 
            // tabLossReturn
            // 
            this.tabLossReturn.BackColor = System.Drawing.Color.AliceBlue;
            this.tabLossReturn.Controls.Add(this.btnCreateLossReturn);
            this.tabLossReturn.Location = new System.Drawing.Point(4, 37);
            this.tabLossReturn.Name = "tabLossReturn";
            this.tabLossReturn.Size = new System.Drawing.Size(950, 437);
            this.tabLossReturn.TabIndex = 2;
            this.tabLossReturn.Text = "Loss/Return";
            // 
            // btnCreateLossReturn
            // 
            this.btnCreateLossReturn.Enabled = false;
            this.btnCreateLossReturn.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateLossReturn.Location = new System.Drawing.Point(253, 85);
            this.btnCreateLossReturn.Name = "btnCreateLossReturn";
            this.btnCreateLossReturn.Size = new System.Drawing.Size(456, 63);
            this.btnCreateLossReturn.TabIndex = 22;
            this.btnCreateLossReturn.Text = "&Create Loss or Return";
            this.btnCreateLossReturn.UseVisualStyleBackColor = true;
            this.btnCreateLossReturn.Click += new System.EventHandler(this.btnProcessLossReturn_Click);
            // 
            // tabReports
            // 
            this.tabReports.BackColor = System.Drawing.Color.AliceBlue;
            this.tabReports.Controls.Add(this.btnGenerateReports);
            this.tabReports.Location = new System.Drawing.Point(4, 37);
            this.tabReports.Name = "tabReports";
            this.tabReports.Size = new System.Drawing.Size(950, 437);
            this.tabReports.TabIndex = 3;
            this.tabReports.Text = "Reports";
            // 
            // tabAdmin
            // 
            this.tabAdmin.BackColor = System.Drawing.Color.AliceBlue;
            this.tabAdmin.Controls.Add(this.btnModifyTxnRecords);
            this.tabAdmin.Controls.Add(this.btnViewSuppliers);
            this.tabAdmin.Controls.Add(this.btnViewSites);
            this.tabAdmin.Controls.Add(this.btnSetUserPermissions);
            this.tabAdmin.Controls.Add(this.btnViewUsers);
            this.tabAdmin.Location = new System.Drawing.Point(4, 37);
            this.tabAdmin.Name = "tabAdmin";
            this.tabAdmin.Size = new System.Drawing.Size(950, 437);
            this.tabAdmin.TabIndex = 4;
            this.tabAdmin.Text = "Admin";
            // 
            // btnModifyTxnRecords
            // 
            this.btnModifyTxnRecords.Enabled = false;
            this.btnModifyTxnRecords.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModifyTxnRecords.Location = new System.Drawing.Point(32, 340);
            this.btnModifyTxnRecords.Name = "btnModifyTxnRecords";
            this.btnModifyTxnRecords.Size = new System.Drawing.Size(384, 63);
            this.btnModifyTxnRecords.TabIndex = 27;
            this.btnModifyTxnRecords.Text = "&Modify Transaction Records";
            this.btnModifyTxnRecords.UseVisualStyleBackColor = true;
            this.btnModifyTxnRecords.Click += new System.EventHandler(this.btnModifyTxnRecords_Click);
            // 
            // btnViewSuppliers
            // 
            this.btnViewSuppliers.Enabled = false;
            this.btnViewSuppliers.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewSuppliers.Location = new System.Drawing.Point(526, 190);
            this.btnViewSuppliers.Name = "btnViewSuppliers";
            this.btnViewSuppliers.Size = new System.Drawing.Size(384, 63);
            this.btnViewSuppliers.TabIndex = 26;
            this.btnViewSuppliers.Text = "&View and Manage Suppliers";
            this.btnViewSuppliers.UseVisualStyleBackColor = true;
            this.btnViewSuppliers.Click += new System.EventHandler(this.btnViewSuppliers_Click);
            // 
            // btnViewSites
            // 
            this.btnViewSites.Enabled = false;
            this.btnViewSites.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewSites.Location = new System.Drawing.Point(526, 40);
            this.btnViewSites.Name = "btnViewSites";
            this.btnViewSites.Size = new System.Drawing.Size(384, 63);
            this.btnViewSites.TabIndex = 25;
            this.btnViewSites.Text = "&View and Manage Sites";
            this.btnViewSites.UseVisualStyleBackColor = true;
            this.btnViewSites.Click += new System.EventHandler(this.btnViewSites_Click);
            // 
            // btnSetUserPermissions
            // 
            this.btnSetUserPermissions.Enabled = false;
            this.btnSetUserPermissions.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetUserPermissions.Location = new System.Drawing.Point(32, 190);
            this.btnSetUserPermissions.Name = "btnSetUserPermissions";
            this.btnSetUserPermissions.Size = new System.Drawing.Size(384, 63);
            this.btnSetUserPermissions.TabIndex = 24;
            this.btnSetUserPermissions.Text = "&Set User Permissions";
            this.btnSetUserPermissions.UseVisualStyleBackColor = true;
            this.btnSetUserPermissions.Click += new System.EventHandler(this.btnSetUserPermissions_Click);
            // 
            // btnViewUsers
            // 
            this.btnViewUsers.Enabled = false;
            this.btnViewUsers.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewUsers.Location = new System.Drawing.Point(32, 40);
            this.btnViewUsers.Name = "btnViewUsers";
            this.btnViewUsers.Size = new System.Drawing.Size(384, 63);
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
            // btnGenerateReports
            // 
            this.btnGenerateReports.Enabled = false;
            this.btnGenerateReports.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerateReports.Location = new System.Drawing.Point(247, 86);
            this.btnGenerateReports.Name = "btnGenerateReports";
            this.btnGenerateReports.Size = new System.Drawing.Size(456, 63);
            this.btnGenerateReports.TabIndex = 23;
            this.btnGenerateReports.Text = "&Generate Reports";
            this.btnGenerateReports.UseVisualStyleBackColor = true;
            this.btnGenerateReports.Click += new System.EventHandler(this.btnGenerateReports_Click);
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
            this.tabLossReturn.ResumeLayout(false);
            this.tabReports.ResumeLayout(false);
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
        private System.Windows.Forms.Button btnViewInventory;
        private System.Windows.Forms.Button btnViewOrders;
        private System.Windows.Forms.Button btnCreateOrder;
        private System.Windows.Forms.Button btnManageOrderItems;
        private System.Windows.Forms.Button btnFulfillOrder;
        private System.Windows.Forms.Button btnViewSuppliers;
        private System.Windows.Forms.Button btnModifyTxnRecords;
        private System.Windows.Forms.Button btnPickupAndDeliverOrders;
        private System.Windows.Forms.Button btnCheckDeliveries;
        private System.Windows.Forms.Button btnPrepareOnlineOrder;
        private System.Windows.Forms.Button btnCreateLossReturn;
        private System.Windows.Forms.Button btnCreateSupplierOrder;
        private System.Windows.Forms.Button btnGenerateReports;
    }
}