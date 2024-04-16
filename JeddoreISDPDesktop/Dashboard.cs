using JeddoreISDPDesktop.DAO_Classes;
using JeddoreISDPDesktop.Entity_Classes;
using System;
using System.Windows.Forms;
using Site = JeddoreISDPDesktop.Entity_Classes.Site;

namespace JeddoreISDPDesktop
{
    public partial class Dashboard : Form
    {
        //class level/global variable for the employee object from the login form
        Employee employee = null;

        public Dashboard(Employee employeeLoggedIn)
        {
            InitializeComponent();
            employee = employeeLoggedIn;
        }

        private void picHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Welcome, you are now logged into the Bullseye dashboard. Click on a tab " +
                "below, and then a button inside one of those tabs to do that specific task.", "Dashboard Help"
                , MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            //setting the tooltip for the help image
            toolTipHelp.SetToolTip(picHelp, "Click here for help.");

            //display the employee's username and location in this form
            lblUsername.Text = employee.username;
            lblLocation.Text = employee.siteName;

            //set the default tab control on form load to the orders tab, for now
            //NOTE: may update this again in sprint 3
            tabControlDashboard.SelectedTab = tabOrders;

            //get the employee's user permissions
            UserPermission employeeUserPermissions = UserPermissionAccessor.GetOneEmployeeUserPermissions(employee.employeeID);

            //all btns in the tabs should be disabled (in properties) on dashboard load
            //below - are enabling btns based on if permission IDs are present in the list or not
            //checking the list for READERUSER
            if (employeeUserPermissions.permissionIDList.Contains("READUSER"))
            {
                btnViewUsers.Enabled = true;
            }

            //check the list for SETPERMISSION
            if (employeeUserPermissions.permissionIDList.Contains("SETPERMISSION"))
            {
                btnSetUserPermissions.Enabled = true;
            }

            //check the list for EDITITEM, EDITPRODUCT, or ADDNEWPRODUCT
            if (employeeUserPermissions.permissionIDList.Contains("EDITITEM") ||
                employeeUserPermissions.permissionIDList.Contains("EDITPRODUCT") ||
                employeeUserPermissions.permissionIDList.Contains("ADDNEWPRODUCT"))
            {
                btnEditItem.Enabled = true;
            }

            //check the list for VIEWSITE
            if (employeeUserPermissions.permissionIDList.Contains("VIEWSITE"))
            {
                btnViewSites.Enabled = true;
            }

            //check the list for VIEWINVENTORY
            if (employeeUserPermissions.permissionIDList.Contains("VIEWINVENTORY"))
            {
                btnViewInventory.Enabled = true;
            }

            //check the list for VIEWORDERS
            if (employeeUserPermissions.permissionIDList.Contains("VIEWORDERS"))
            {
                btnViewOrders.Enabled = true;
            }

            //check the list for CREATESTOREORDER
            if (employeeUserPermissions.permissionIDList.Contains("CREATESTOREORDER"))
            {
                btnCreateOrder.Enabled = true;
            }

            //check the list for PREPARESTOREORDER
            if (employeeUserPermissions.permissionIDList.Contains("PREPARESTOREORDER"))
            {
                btnManageOrderItems.Enabled = true;
            }

            //check the list for FULFILSTOREORDER
            if (employeeUserPermissions.permissionIDList.Contains("FULFILSTOREORDER"))
            {
                btnFulfillOrder.Enabled = true;
            }

            //check the list for ADDSUPPLIER or EDITSUPPLIER
            if (employeeUserPermissions.permissionIDList.Contains("ADDSUPPLIER") ||
                employeeUserPermissions.permissionIDList.Contains("EDITSUPPLIER"))
            {
                btnViewSuppliers.Enabled = true;
            }

            //check the list for MODIFYRECORD
            if (employeeUserPermissions.permissionIDList.Contains("MODIFYRECORD"))
            {
                btnModifyTxnRecords.Enabled = true;
            }

            //check the list for PICKUPSTOREORDER or DELIVERSTOREORDER
            if (employeeUserPermissions.permissionIDList.Contains("PICKUPSTOREORDER") ||
                employeeUserPermissions.permissionIDList.Contains("DELIVERSTOREORDER"))
            {
                btnPickupAndDeliverOrders.Enabled = true;
            }

            //check the list for DELIVERY
            if (employeeUserPermissions.permissionIDList.Contains("DELIVERY"))
            {
                btnCheckDeliveries.Enabled = true;
            }

            //check the list for PREPAREONLINEORDER
            if (employeeUserPermissions.permissionIDList.Contains("PREPAREONLINEORDER"))
            {
                btnPrepareOnlineOrder.Enabled = true;
            }

            //check the list for CREATESUPPLIERORDER
            if (employeeUserPermissions.permissionIDList.Contains("CREATESUPPLIERORDER"))
            {
                btnCreateSupplierOrder.Enabled = true;
            }

            //check the list for CREATELOSS or PROCESSRETURN
            if (employeeUserPermissions.permissionIDList.Contains("CREATELOSS") ||
                employeeUserPermissions.permissionIDList.Contains("PROCESSRETURN"))
            {
                btnCreateLossReturn.Enabled = true;
            }

            //check the list for CREATEREPORT
            if (employeeUserPermissions.permissionIDList.Contains("CREATEREPORT"))
            {
                btnGenerateReports.Enabled = true;
            }

            //if employee is a store manager OR warehouse manager
            if (employee.positionID == 3 || employee.positionID == 4)
            {
                //see if a new order exists for the employee's site
                Txn newOrder = TxnAccessor.GetOneNewOrder(employee.siteID);

                //if newOrder is not null - so a new order exists
                if (newOrder != null)
                {
                    //get the count of items
                    long numTxnItems = TxnItemsAccessor.GetCountOfItemsInTxn(newOrder.txnID);

                    //order's ship date
                    DateTime shipDate = newOrder.shipDate;

                    //get the day 2 days before the ship date (or 48 hours)
                    DateTime twoDaysBeforeShipDate = shipDate.AddDays(-2);

                    //get the current date and time
                    DateTime currentDateTime = DateTime.Now;

                    //if current datetime now is after two days before the scheduled ship date, then submit the NEW order automatically
                    if (currentDateTime > twoDaysBeforeShipDate)
                    {
                        //check if order is an emergency order and if it contains invalid number of items
                        if (newOrder.txnType == "Emergency" && (numTxnItems > 5 || numTxnItems < 1))
                        {
                            //update the status property of this new order
                            newOrder.status = "Rejected";

                            //change the order's status from New to Submitted
                            bool rejectedSuccess = TxnAccessor.UpdateTxnStatus(newOrder);

                            //if success, display success message and close the form
                            if (rejectedSuccess)
                            {
                                MessageBox.Show("Your emergency order with the status of 'New' has been rejected since it did not contain between 1 and 5 items.", "Emergency Order Rejected");
                            }
                        }

                        //check if order is a store order and contains less than 1 item
                        else if (newOrder.txnType == "Store Order" && numTxnItems < 1)
                        {
                            //update the status property of this new order
                            newOrder.status = "Rejected";

                            //change the order's status from New to Submitted
                            bool rejectedSuccess = TxnAccessor.UpdateTxnStatus(newOrder);

                            //if success, display success message and close the form
                            if (rejectedSuccess)
                            {
                                MessageBox.Show("Your store order with the status of 'New' has been automatically rejected since it did not contain any items.", "Store Order Rejected");
                            }
                        }

                        //check if order is a supplier order and contains less than 1 item
                        else if (newOrder.txnType == "Supplier Order" && numTxnItems < 1)
                        {
                            //update the status property of this new order
                            newOrder.status = "Rejected";

                            //change the order's status from New to Submitted
                            bool rejectedSuccess = TxnAccessor.UpdateTxnStatus(newOrder);

                            //if success, display success message and close the form
                            if (rejectedSuccess)
                            {
                                MessageBox.Show("Your supplier order with the status of 'New' has been automatically rejected since it did not contain any items.", "Supplier Order Rejected");
                            }
                        }

                        //else - order should be good for an automatic submission
                        else
                        {
                            //update the status property of this new order
                            newOrder.status = "Submitted";

                            //change the order's status from New to Submitted
                            bool success = TxnAccessor.UpdateTxnStatus(newOrder);

                            //if success, display success message and close the form
                            if (success)
                            {
                                MessageBox.Show("Your order with the status of 'New' has been automatically submitted since the ship date for the order is in less than 48 hours.", "Automatic Order Submission");
                            }
                        }
                    }
                }
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            //then the dashboard
            this.Close();
        }

        private void btnViewUsers_Click(object sender, EventArgs e)
        {
            //want to send the employee obj to the user management form
            UserManagement frmUserManagement = new UserManagement(employee);

            //open the user management form (modal)
            frmUserManagement.ShowDialog();
        }

        private void btnSetUserPermissions_Click(object sender, EventArgs e)
        {
            //want to send the employee obj to the user permissions form
            UserPermissions frmUserPermissions = new UserPermissions(employee);

            //open the user management form (modal)
            frmUserPermissions.ShowDialog();
        }

        private void btnEditItem_Click(object sender, EventArgs e)
        {
            //want to send the employee obj to the item management form
            ItemManagement frmItemManagement = new ItemManagement(employee);

            //open the item management form (modal)
            frmItemManagement.ShowDialog();
        }

        //timer should close this form after 20 minutes
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Dashboard_KeyDown(object sender, KeyEventArgs e)
        {
            //if the F1 key is pressed down
            if (e.KeyCode == Keys.F1)
            {
                MessageBox.Show("Welcome, you are now logged into the Bullseye dashboard. Click on a tab " +
               "below, and then a button inside one of those tabs to do that specific task.", "Dashboard Help"
               , MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnViewSites_Click(object sender, EventArgs e)
        {
            //want to send the employee obj to the site management form
            SiteManagement frmSiteManagement = new SiteManagement(employee);

            //open the site management form (modal)
            frmSiteManagement.ShowDialog();
        }

        private void btnEditInventory_Click(object sender, EventArgs e)
        {
            //want to send the employee obj to the inventory management form
            InventoryManagement frmInventoryManagement = new InventoryManagement(employee);

            //open the inventory management form (modal)
            frmInventoryManagement.ShowDialog();
        }

        private void btnViewOrders_Click(object sender, EventArgs e)
        {
            //want to send the employee obj to the view orders form
            ViewOrders frmViewOrders = new ViewOrders(employee);

            //open the view orders form (modal)
            frmViewOrders.ShowDialog();
        }

        private void btnCreateOrder_Click(object sender, EventArgs e)
        {
            //checking the number of active/open NEW orders only for the manager's site
            long numActiveNewOrders = TxnAccessor.GetCountOfActiveNewOrdersForSite(employee.siteID);

            Txn newOrder = TxnAccessor.GetOneNewOrder(employee.siteID);

            //if number of active NEW orders is 0 then, take the user to the create new order form
            if (numActiveNewOrders == 0)
            {
                //want to send the employee obj to the create new order form
                CreateNewOrder frmCreateOrder = new CreateNewOrder(employee);

                //open the create new order form (modal)
                frmCreateOrder.ShowDialog();
            }

            //else if - one active NEW order likely already exists and newOrder is NOT null
            else if (numActiveNewOrders > 0 && newOrder != null)
            {
                //then display the edit order form for the manager/user
                //sending in the employee obj
                EditOrder frmEditOrder = new EditOrder(employee);

                //open the edit order form (modal)
                frmEditOrder.ShowDialog();
            }
        }

        private void btnManageOrderItems_Click(object sender, EventArgs e)
        {
            //want to send the employee obj to the order items management form
            OrderItemsManagement frmOrderItemsMgmt = new OrderItemsManagement(employee);

            //open the order items management form (modal)
            frmOrderItemsMgmt.ShowDialog();
        }

        private void btnFulfillOrder_Click(object sender, EventArgs e)
        {
            //want to send the employee obj to the fulfill orders form
            FulfillOrders frmFulfillOrders = new FulfillOrders(employee);

            //open the fulfill orders form (modal)
            frmFulfillOrders.ShowDialog();
        }

        private void btnViewSuppliers_Click(object sender, EventArgs e)
        {
            //want to send the employee obj to the supplier management form
            SupplierManagement frmSupplierManagement = new SupplierManagement(employee);

            //open the supplier management form (modal)
            frmSupplierManagement.ShowDialog();
        }

        private void btnModifyTxnRecords_Click(object sender, EventArgs e)
        {
            //want to send the employee obj to the modify txn records form
            TransactionManagement frmModifyTxnRecords = new TransactionManagement(employee);

            //open the modify txn records form (modal)
            frmModifyTxnRecords.ShowDialog();
        }

        private void btnPickupAndDeliverOrders_Click(object sender, EventArgs e)
        {
            //want to send the employee obj to the pickup and deliver store orders form
            PickupAndDeliverOrders frmPickupDeliverOrders = new PickupAndDeliverOrders(employee);

            //open the form (modal)
            frmPickupDeliverOrders.ShowDialog();
        }

        private void btnCheckDeliveries_Click(object sender, EventArgs e)
        {
            //want to send the employee obj to the check deliveries form
            CheckDeliveries frmCheckDeliveries = new CheckDeliveries(employee);

            //open the form (modal)
            frmCheckDeliveries.ShowDialog();
        }

        private void btnPrepareOnlineOrder_Click(object sender, EventArgs e)
        {
            //want to send the employee obj to the prepare and receive online form
            PrepareOnlineOrders frmPrepareOnlineOrders = new PrepareOnlineOrders(employee);

            //open the form (modal)
            frmPrepareOnlineOrders.ShowDialog();
        }

        private void btnProcessLossReturn_Click(object sender, EventArgs e)
        {
            //want to send the employee obj to the create loss/return form
            CreateLossReturn frmCreateLossReturn = new CreateLossReturn(employee);

            //open the form (modal)
            frmCreateLossReturn.ShowDialog();
        }

        private void btnCreateSupplierOrder_Click(object sender, EventArgs e)
        {
            //checking the number of active/open NEW orders only for the manager's site
            long numActiveNewSupplierOrders = TxnAccessor.GetCountOfActiveNewSupplierOrdersForSite(employee.siteID);

            Txn newOrder = TxnAccessor.GetOneNewOrder(employee.siteID);

            //if number of active NEW supplier orders is 0 then, create a supplier order for the user's site
            if (numActiveNewSupplierOrders == 0)
            {
                //txn object - for the most recent txn (mostly just want the last barcode)
                Txn mostRecentTxn = TxnAccessor.GetLastTxn();

                //get the employee's site
                Site site = SiteAccessor.GetOneSite(employee.siteID);

                //converting the barcode to an int
                long mostRecentBarcode = long.Parse(mostRecentTxn.barCode);

                //new barcode will be most recent barcode plus 1
                string newBarcode = (mostRecentBarcode + 1).ToString();

                //ship date will be 7 days from the created/current date
                DateTime shipDate = DateTime.Now.AddDays(7);

                //byte var for emergency delivery
                byte emergencyDelivery = 0;

                //create new txn object
                Txn newTxn = new Txn(mostRecentTxn.txnID + 1, employee.siteID, 1, "New",
                    shipDate, "Supplier Order", newBarcode, DateTime.Now, emergencyDelivery);

                //insert the store order txn
                bool success = TxnAccessor.InsertNewTxn(newTxn);

                //if success
                if (success)
                {
                    MessageBox.Show("Supplier Order for site - " + site.name + " successfully created." +
                        "\n\nEstimated Shipping Date: " + shipDate, "Supplier Order Created");

                    //open the edit supplier order form
                    // sending in the employee obj and newTxn object

                }
            }

            //else if - one active NEW order likely already exists and newOrder is NOT null
            else if (numActiveNewSupplierOrders > 0 && newOrder != null)
            {
                //then open and display the edit supplier order form for the manager/user
                //sending in the employee obj and newOrder object
                EditSupplierOrder frmEditSupplierOrder = new EditSupplierOrder(employee, newOrder);

                //open the edit supplier order form (modal)
                frmEditSupplierOrder.ShowDialog();
            }
        }

        private void btnGenerateReports_Click(object sender, EventArgs e)
        {
            //opening the MicroStrategy Workstation .exe on my local C drive
            System.Diagnostics.Process.Start(@"C:\Program Files\MicroStrategy\Workstation\Workstation.exe");
        }
    }
}
