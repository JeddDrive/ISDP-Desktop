using JeddoreISDPDesktop.DAO_Classes;
using JeddoreISDPDesktop.Entity_Classes;
using JeddoreISDPDesktop.Helper_Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace JeddoreISDPDesktop
{
    public partial class PickupAndDeliverOrders : Form
    {
        //class level/global variable for the employee object from the dashboard
        Employee employee = null;

        //global list to track the txns (store orders) that are picked up in a delivery
        List<Txn> storeOrdersList = new List<Txn>();

        public PickupAndDeliverOrders(Employee employeeLoggedIn)
        {
            InitializeComponent();
            employee = employeeLoggedIn;
        }

        private void PickupAndDeliverOrders_Load(object sender, EventArgs e)
        {
            //setting the tooltip for the help image
            toolTipHelp.SetToolTip(picHelp, "Click here for help.");

            //display the employee's username and location in this form
            lblUsername.Text = employee.username;
            lblLocation.Text = employee.siteName;

            //set the value for the ship date DTP to today (now)
            dtpShipDate.Value = DateTime.Now;

            //get the employee's user permissions
            UserPermission employeeUserPermissions = UserPermissionAccessor.GetOneEmployeeUserPermissions(employee.employeeID);

            //check the list for PICKUPSTOREORDER
            if (employeeUserPermissions.permissionIDList.Contains("PICKUPSTOREORDER"))
            {
                btnSetOrderPickedUp.Enabled = true;
            }

            //check the list for DELIVERSTOREORDER
            if (employeeUserPermissions.permissionIDList.Contains("DELIVERSTOREORDER"))
            {
                btnSetOrderDelivered.Enabled = true;
            }

            //get the last delivery - mainly to get it's ID
            Delivery lastDelivery = DeliveryAccessor.GetLastDelivery();

            //populate the delivery ID label
            lblDeliveryID.Text = (lastDelivery.deliveryID + 1).ToString();

            //get a list of all vehicles
            List<Vehicle> vehiclesList = VehicleAccessor.GetAllVehiclesList();

            //loop thru, populating the combobox for vehicle type
            foreach (Vehicle vehicle in vehiclesList)
            {
                //want to exclude the courier option
                if (vehicle.vehicleType != "Courier")
                {
                    cboVehicles.Items.Add(vehicle.vehicleType);
                }
            }

            //select the last option in the cbo (van)
            cboVehicles.SelectedIndex = cboVehicles.Items.Count - 1;

            //first item in the listbox is this - like a header
            lstPickedUpOrders.Items.Add("Txn ID     Destination Site                Ship Date               Status");
        }

        private void btnExitOrders_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExit2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //timer to close this form after 20 minutes
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void picHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This is the form for confirming orders that are picked up or delivered. You can select a store order here in the first tab, then confirm them for pickup in the second tab on this form. Confirming an order's delivery will take you to a new form." +
            "\n\nClick on the 'refresh' button in the first tab to load the store orders data grid.", "Pickup and Deliver Orders Help"
            , MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void PickupAndDeliverOrders_KeyDown(object sender, KeyEventArgs e)
        {
            //if the F1 key is pressed down
            if (e.KeyCode == Keys.F1)
            {
                MessageBox.Show("This is the form for confirming orders that are picked up or delivered. You can select a store order here in the first tab, then confirm them for pickup in the second tab on this form. Confirming an order's delivery will take you to a new form." +
                "\n\nClick on the 'refresh' button in the first tab to load the store orders data grid.", "Pickup and Deliver Orders Help"
                , MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dtpShipDate_ValueChanged(object sender, EventArgs e)
        {
            /* DateTime selectedShipDate = dtpShipDate.Value;

            //get list of txns (store orders) with a ship date of the value of the DTP
            List<Txn> listOrdersOnShipDate = TxnAccessor.GetAllOrdersListForShipDate(selectedShipDate);

            //get the weight of all the store orders on the ship date
            decimal weightOnShipDate = TxnItemsAccessor.GetTxnWeightForShipDate(selectedShipDate);

            //clear the listbox and store orders list
            lstPickedUpOrders.Items.Clear();
            storeOrdersList.Clear();

            //adding back the first item in the listbox is this - like a header
            lstPickedUpOrders.Items.Add("Txn ID         Destination Site                Ship Date               Status");

            //update the vehicle type label in the second tab to this
            lblVehicleType1.Text = "Needed Vehicle for Delivery on " + selectedShipDate.ToShortDateString() + ":";

            //update this label as well
            lblNumOrdersScheduled1.Text = "Number of Orders Scheduled for Pick Up on " + selectedShipDate.ToShortDateString() + ":";

            lblNumOrdersScheduled2.Text = listOrdersOnShipDate.Count.ToString();

            lblNumOrdersPickedUp.Text = storeOrdersList.Count.ToString();

            lblEstimatedDeliveryWeight.Text = weightOnShipDate.ToString();

            //get the recommended/needed vehicle type based on the weight on the ship date
            string vehicleType = DeliveryCalculator.GetRecommendedVehicleType(weightOnShipDate);

            //put the vehicle type in it's label as well
            lblVehicleType2.Text = vehicleType;

            //clear out the signature textbox
            txtSignature.ResetText(); */
        }

        private void btnRefreshOrders_Click(object sender, EventArgs e)
        {
            //create a new bindingsource
            BindingSource bindingSource = new BindingSource();

            DataTable dt = null;

            //create datatable - getting all store orders based on the ship date from the DTP
            dt = TxnAccessor.GetAllOrdersForShipDate(dtpShipDate.Value);

            //set the binding source's datasource to the datatable
            bindingSource.DataSource = dt;

            //set the dgv's datasource to the bindingSource
            dgvOrders.DataSource = bindingSource;

            //autoresize dgv columns
            dgvOrders.AutoResizeColumns();

            //display the binding nav
            bindingNavigator1.Visible = true;

            //set the binding source of the binding nav to the binding source created
            bindingNavigator1.BindingSource = bindingSource;

            //hide the following columns
            dgvOrders.Columns["siteIDTo"].Visible = false;
            dgvOrders.Columns["siteIDFrom"].Visible = false;
            //dgvOrders.Columns["deliveryID"].Visible = false;

            //change the header text of these columns
            dgvOrders.Columns["txnID"].HeaderText = "Order ID";
            dgvOrders.Columns["originSite"].HeaderText = "Origin Site";
            dgvOrders.Columns["destinationSite"].HeaderText = "Destination Site";
            dgvOrders.Columns["status"].HeaderText = "Status";
            dgvOrders.Columns["shipDate"].HeaderText = "Ship Date";
            dgvOrders.Columns["txnType"].HeaderText = "Order Type";
            dgvOrders.Columns["barCode"].HeaderText = "Bar Code";
            dgvOrders.Columns["createdDate"].HeaderText = "Created Date";
            dgvOrders.Columns["deliveryID"].HeaderText = "Delivery ID";
            dgvOrders.Columns["emergencyDelivery"].HeaderText = "Emergency Order";
            dgvOrders.Columns["notes"].HeaderText = "Notes";

            //loop thru the dgv
            //adding lightgreen backcolor to rows selected for pickup
            foreach (DataGridViewRow row in dgvOrders.Rows)
            {
                foreach (Txn txn in storeOrdersList)
                {
                    //if the txnID is a match then
                    if (Convert.ToInt32(row.Cells[0].Value) == txn.txnID)
                    {
                        //add this color to the row
                        row.DefaultCellStyle.BackColor = Color.LightGreen;
                    }
                }
            }

            dgvOrders.Refresh();

            //enable the textbox for search
            txtSearchOrders.Enabled = true;

            DateTime selectedShipDate = dtpShipDate.Value;

            //get list of txns (store orders) with a ship date of the value of the DTP
            //List<Txn> listOrdersOnShipDate = TxnAccessor.GetAllOrdersListForShipDate(selectedShipDate);

            //get the weight of all the store orders on the ship date
            decimal weightOnShipDate = TxnItemsAccessor.GetTxnWeightForShipDate(selectedShipDate);

            //clear both the listbox and store orders list
            lstPickedUpOrders.Items.Clear();
            storeOrdersList.Clear();

            //adding back the first item in the listbox is this - like a header
            lstPickedUpOrders.Items.Add("Txn ID     Destination Site                Ship Date               Status");

            //update the vehicle type label in the second tab to this
            lblVehicleType1.Text = "Needed Vehicle for Delivery on " + selectedShipDate.ToShortDateString() + ":";

            //update this label as well
            lblNumOrdersScheduled1.Text = "Number of Orders Scheduled for Pick Up on " + selectedShipDate.ToShortDateString() + ":";

            if (dgvOrders.Rows.Count > 0)
            {
                lblNumOrdersScheduled2.Text = dgvOrders.Rows.Count.ToString();
            }

            else
            {
                lblNumOrdersScheduled2.Text = 0.ToString();
            }

            lblNumOrdersPickedUp.Text = storeOrdersList.Count.ToString();

            lblEstimatedDeliveryWeight.Text = weightOnShipDate.ToString();

            //get the recommended/needed vehicle type based on the weight on the ship date
            string vehicleType = DeliveryCalculator.GetRecommendedVehicleType(weightOnShipDate);

            //put the vehicle type in it's label as well
            lblVehicleType2.Text = vehicleType;

            //clear out the signature textbox
            txtSignature.ResetText();

            //disable these controls on tab 2 - just in case
            //disable the btns in the next tab
            btnExit2.Enabled = false;
            btnRemoveOrder.Enabled = false;
            btnMarkOrderPickedUp.Enabled = false;

            //disable the signature textbox
            txtSignature.Enabled = false;

            //disable the combobox
            cboVehicles.Enabled = false;
        }

        private void txtSearchOrders_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //want to clear DGV row selection to prevent DGV errors/program from crashing
                //each time the text is changed and if the user clicks on a CRUD btn for example
                dgvOrders.ClearSelection();

                //converting the search text to all lower case
                string theSearchText = txtSearchOrders.Text.ToLower();

                CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[dgvOrders.DataSource];

                foreach (DataGridViewRow row in dgvOrders.Rows)
                {
                    //get the cell values for the following columns
                    var originSiteCellValue = row.Cells["originSite"].Value;
                    var destinationSiteCellValue = row.Cells["destinationSite"].Value;
                    var statusCellValue = row.Cells["status"].Value;
                    var txnTypeCellValue = row.Cells["txnType"].Value;
                    var createdDateCellValue = row.Cells["createdDate"].Value;
                    var shippedDateCellValue = row.Cells["shipDate"].Value;

                    //if txtbox is empty, then just show all the rows and continue
                    if (txtSearchOrders.Text.Equals(""))
                    {
                        row.Visible = true;
                        continue;
                    }

                    //else if - origin site cell converted to string contains the txtbox text
                    else if (originSiteCellValue != null && originSiteCellValue.ToString().ToLower().Contains(theSearchText))
                    {
                        row.Visible = true;
                    }

                    //else if - destination site cell converted to string contains the txtbox text
                    else if (destinationSiteCellValue != null && destinationSiteCellValue.ToString().ToLower().Contains(theSearchText))
                    {
                        row.Visible = true;
                    }

                    //if - status cell converted to string contains the txtbox text
                    else if (statusCellValue != null && statusCellValue.ToString().ToLower().Contains(theSearchText))
                    {
                        row.Visible = true;
                    }

                    //else if - created date cell converted to lower case contains the txtbox text
                    else if (createdDateCellValue != null && createdDateCellValue.ToString().ToLower().Contains(theSearchText))
                    {
                        row.Visible = true;
                    }

                    //else if - shipped date cell converted to lower case contains the txtbox text
                    else if (shippedDateCellValue != null && shippedDateCellValue.ToString().ToLower().Contains(theSearchText))
                    {
                        row.Visible = true;
                    }

                    //else - no text contains match in any of the above cells then
                    else
                    {
                        //need to suspend and resume binding before and after row visibilty is false
                        //or else will get an error
                        currencyManager1.SuspendBinding();
                        row.Visible = false;
                        currencyManager1.ResumeBinding();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSetOrderPickedUp_Click(object sender, EventArgs e)
        {
            int selectedRowsCount = dgvOrders.SelectedRows.Count;

            //if number of selected rows is not one
            if (selectedRowsCount != 1)
            {
                MessageBox.Show("Must select one row from the orders data grid in order to pickup that order for delivery.",
                    "Order Pickup Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //clear all selected rows from the dgv
                dgvOrders.ClearSelection();
            }

            //else - 1 order item row is selected
            else
            {
                //get the current row
                DataGridViewRow dgvRow = dgvOrders.CurrentRow;

                //get the cell with the selected row's txnID in the orders DGV
                int txnID = int.Parse(dgvRow.Cells[0].Value.ToString());

                //get the transaction
                Txn selectedTxn = TxnAccessor.GetOneOrder(txnID);

                //checking if the txn already exists in the list
                foreach (Txn txn in storeOrdersList)
                {
                    if (txn.txnID == txnID)
                    {
                        MessageBox.Show("Store order " + txnID + " for " + txn.destinationSite + " has already been selected for pick up in this delivery.",
                            "Order Already Selected for Pick Up", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        dgvOrders.ClearSelection();

                        return;
                    }
                }

                //checking the status of the txn/store order
                if (selectedTxn.status != "Assembled")
                {
                    MessageBox.Show("Status of selected store order is: " + selectedTxn.status +
                        "\n\nCannot move an order onto a truck for delivery until it's status is Assembled in the warehouse bay.",
                        "Selected Order Not Assembled", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    dgvOrders.ClearSelection();
                }

                //else - it's status is Assembled
                else
                {
                    //add the txn to the global list
                    storeOrdersList.Add(selectedTxn);

                    //enable the btns in the next tab
                    btnExit2.Enabled = true;
                    btnRemoveOrder.Enabled = true;
                    btnMarkOrderPickedUp.Enabled = true;

                    //enable the signature textbox
                    txtSignature.Enabled = true;

                    //enable the combobox
                    cboVehicles.Enabled = true;

                    //add txn details to the listbox
                    lstPickedUpOrders.Items.Add(selectedTxn.txnID + "         " + selectedTxn.destinationSite + "                             " + selectedTxn.shipDate.ToShortDateString() +
                        "                     " + selectedTxn.status);

                    //update this label
                    lblNumOrdersPickedUp.Text = storeOrdersList.Count.ToString();

                    MessageBox.Show("Store order " + selectedTxn.txnID.ToString() + " for " +
                    selectedTxn.destinationSite + " has been selected for delivery pickup. You can confirm pickup for this store order " +
                    "in the next tab as well as add any further orders for " + dtpShipDate.Value.ToShortDateString() + " if needed from here.", "Store Order Selected for Pickup",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //loop thru the dgv
                    //adding lightgreen backcolor to rows selected for pickup
                    foreach (DataGridViewRow row in dgvOrders.Rows)
                    {
                        //if itemID is a match then
                        if (Convert.ToInt32(row.Cells[0].Value) == selectedTxn.txnID)
                        {
                            //add this color to the row
                            row.DefaultCellStyle.BackColor = Color.LightGreen;
                        }
                    }
                }
            }
        }

        private void btnRemoveOrder_Click(object sender, EventArgs e)
        {
            //if - no item selected in the listbox
            if (lstPickedUpOrders.SelectedIndex == -1 || lstPickedUpOrders.SelectedItems.Count != 1)
            {
                MessageBox.Show("Must select one store order in the listbox in order to remove it from being picked up in the delivery.", "Store Order Removal Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                //clear selected listbox items
                lstPickedUpOrders.ClearSelected();
            }

            //else - 1 item is selected in the listbox and its not the first index
            else if (lstPickedUpOrders.SelectedIndex > 0)
            {
                //get the text from the lstbox for the selected order
                string orderText = lstPickedUpOrders.GetItemText(lstPickedUpOrders.SelectedItem);

                //split the string at each empty space
                string[] splitArray = orderText.Split(' ');

                //get the txnID from the array
                int txnID = int.Parse(splitArray[0]);

                //foreach loop thru the store orders list
                foreach (Txn txn in storeOrdersList)
                {
                    //if txnID is a match then
                    if (txn.txnID == txnID)
                    {
                        //remove txn from the list
                        storeOrdersList.Remove(txn);

                        //display msg, clear the dgv, and exit the loop
                        MessageBox.Show("Store order " + txnID + " for " + txn.destinationSite + " has been removed from being picked up in this delivery.", "Order Removed From Delivery Pickup",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        break;
                    }
                }

                //loop thru the dgv
                foreach (DataGridViewRow row in dgvOrders.Rows)
                {
                    //if txnID is a match then
                    if (Convert.ToInt32(row.Cells[0].Value) == txnID)
                    {
                        //add this color (white) back to the row
                        row.DefaultCellStyle.BackColor = Color.White;
                    }
                }

                //remove from the listbox at the selected index
                lstPickedUpOrders.Items.RemoveAt(lstPickedUpOrders.SelectedIndex);

                //add back the first item in the listbox is this - like a header
                //lstPickedUpOrders.Items.Add("Txn ID     Destination Site                Ship Date               Status");

                //now check the number of items in the listbox
                //if less than 2 items in the listbox then
                if (lstPickedUpOrders.Items.Count < 2)
                {
                    //disable these btns again
                    btnExit2.Enabled = false;
                    btnRemoveOrder.Enabled = false;
                    btnMarkOrderPickedUp.Enabled = false;

                    //disable the signature textbox again
                    txtSignature.Enabled = false;

                    //disable the combobox again too
                    cboVehicles.Enabled = false;

                    //update this label again
                    lblNumOrdersPickedUp.Text = storeOrdersList.Count.ToString();
                }
            }
        }

        private void btnMarkOrderPickedUp_Click(object sender, EventArgs e)
        {
            DateTime selectedShipDate = dtpShipDate.Value;

            //get list of txns (store orders) with a ship date of the value of the DTP
            //List<Txn> listOrdersOnShipDate = TxnAccessor.GetAllOrdersListForShipDate(selectedShipDate);
            int ordersCountOnShipDate = dgvOrders.Rows.Count;

            //if no orders selected (so store orders list amount is 0) then
            if (storeOrdersList.Count < 1)
            {
                MessageBox.Show("Must have at least one order selected for delivery pickup in order to confirm it and update it's status to In Transit.",
                    "No Order(s) Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //clear any selections in the listbox and dgv
                lstPickedUpOrders.ClearSelected();
                dgvOrders.ClearSelection();

                return;
            }

            //var for employee full name
            string fullName = (employee.firstName + " " + employee.lastName).ToLower();

            //doing a signature check for the user that is logged in
            if (txtSignature.Text.ToLower() != fullName &&
                txtSignature.Text.ToLower() != employee.username)
            {
                MessageBox.Show("Invalid signature, user name not recognized." +
                    "\n\nFor a delivery pickup signature, please enter your first and last name separated by a space, or your username.", "Invalid Signature",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtSignature.Focus();

                return;
            }

            //if count of orders scheduled for shipping on the date doesn't match the count of the list, then display msg
            if (ordersCountOnShipDate != storeOrdersList.Count)
            {
                DialogResult btnValueReturned = MessageBox.Show("Number of assembled store orders selected for pickup does not " +
                    "match the number of orders scheduled for pickup on " + selectedShipDate.ToShortDateString() + "." +
                    "\n\nConfirm order(s) pickup for delivery anyway?" +
                    "\n\nNumber of Orders Scheduled: " + lblNumOrdersScheduled2.Text +
                    "\nNumber of Orders Selected for Pickup: " + lblNumOrdersPickedUp.Text, "Confirm Order Pickup", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                //if - user selects the yes btn
                if (btnValueReturned == DialogResult.Yes)
                {
                    //var for notes signature
                    string notesSignature = "Pickup Signature: " + txtSignature.Text;

                    //create a delivery object
                    //delivery's distance cost will be updated at the time of site/store delivery
                    Delivery delivery = new Delivery(int.Parse(lblDeliveryID.Text), 0.0m, cboVehicles.Text, notesSignature);

                    //need to insert a delivery record now
                    bool insertSuccess = DeliveryAccessor.InsertNewDelivery(delivery);

                    if (insertSuccess)
                    {
                        //loop thru the store orders list
                        foreach (Txn txn in storeOrdersList)
                        {
                            //change the txn's status to In Transit
                            txn.status = "In Transit";

                            //change/add a deliveryID to the txn as well
                            txn.deliveryID = delivery.deliveryID;

                            //updating the siteID From (Ex. from 2 to 1)
                            txn.siteIDFrom = 1;

                            //send the txn object to be updated in the accessor
                            bool success = TxnAccessor.UpdateTxnStatusAndDeliveryIDAndSiteIDFrom(txn);

                            //if success
                            if (success)
                            {
                                MessageBox.Show("Delivery pickup for store order " + txn.txnID + " for " + txn.destinationSite + " has been successfully confirmed. It's status is now In Transit.",
                                    "Order Pickup Confirmed");
                            }
                        }

                        //can now close the form
                        this.Close();
                    }
                }
            }

            //else - count of orders is a match, can display a different message then
            else
            {
                DialogResult btnValueReturned = MessageBox.Show("Number of assembled store orders selected for pickup matches " +
                "the exact number of orders scheduled for pickup on " + selectedShipDate.ToShortDateString() + "." +
                "\n\nConfirm order(s) pickup for delivery?", "Confirm Order Pickup", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                //if - user selects the yes btn
                if (btnValueReturned == DialogResult.Yes)
                {
                    //var for notes signature
                    string notesSignature = "Pickup Signature: " + txtSignature.Text;

                    //create a delivery object
                    //delivery's distance cost will be updated at the time of site/store delivery
                    Delivery delivery = new Delivery(int.Parse(lblDeliveryID.Text), 0.0m, cboVehicles.Text, notesSignature);

                    //need to insert a delivery record now
                    bool insertSuccess = DeliveryAccessor.InsertNewDelivery(delivery);

                    //if insert success for the delivery record
                    if (insertSuccess)
                    {
                        //loop thru the store orders list
                        foreach (Txn txn in storeOrdersList)
                        {
                            //change the txn's status to In Transit
                            txn.status = "In Transit";

                            //change/add a deliveryID to the txn as well
                            txn.deliveryID = delivery.deliveryID;

                            //updating the siteID From (Ex. from 2 to 1)
                            txn.siteIDFrom = 1;

                            //send the txn object to be updated in the accessor
                            bool success = TxnAccessor.UpdateTxnStatusAndDeliveryIDAndSiteIDFrom(txn);

                            //if success
                            if (success)
                            {
                                MessageBox.Show("Delivery pickup for store order " + txn.txnID + " for " + txn.destinationSite + " has been successfully confirmed. It's status is now In Transit.",
                                    "Order Pickup Confirmed");
                            }
                        }

                        //can now close the form
                        this.Close();
                    }
                }
            }
        }

        private void btnSetOrderDelivered_Click(object sender, EventArgs e)
        {
            int selectedRowsCount = dgvOrders.SelectedRows.Count;

            //if number of selected rows is not one
            if (selectedRowsCount != 1)
            {
                MessageBox.Show("Must select one row from the orders data grid in order to confirm delivery of a store order.",
                    "Order Delivery Confirmation Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //clear all selected rows from the dgv
                dgvOrders.ClearSelection();
            }

            //else - 1 order item row is selected
            else
            {
                //get the current row
                DataGridViewRow dgvRow = dgvOrders.CurrentRow;

                //get the cell with the selected row's txnID in the orders DGV
                int txnID = int.Parse(dgvRow.Cells[0].Value.ToString());

                //get the transaction
                Txn selectedTxn = TxnAccessor.GetOneOrderInclDeliveryID(txnID);

                //getting a site object too
                Site employeeSite = SiteAccessor.GetOneSite(employee.siteID);

                //checking the siteIDTo of the txn to the employee's siteID
                if (selectedTxn.siteIDTo != employee.siteID && employee.siteID != 1 &&
                    employee.siteID != 3)
                {
                    MessageBox.Show("Destination site for this store order is " + selectedTxn.destinationSite +
                        "." + " You cannot confirm delivery of orders for any sites other than your own - " + employeeSite.name + ".",
                        "Invalid Site Order Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //clear all selected rows from dgv
                    dgvOrders.ClearSelection();

                    return;
                }

                //checking the status of the txn/store order
                if (selectedTxn.status != "In Transit")
                {
                    MessageBox.Show("Status of selected store order is: " + selectedTxn.status +
                        "\n\nCannot confirm delivery of an order that is currently not in transit.",
                        "Selected Order Not In Transit", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //clear all selected rows from the dgv
                    dgvOrders.ClearSelection();
                }

                //else - the order's status is In Transit
                else
                {
                    //want to send the employee and txn objects to the confirm order delivery form
                    ConfirmOrderDelivery frmCondirmOrderDelivery = new ConfirmOrderDelivery(employee, selectedTxn);

                    //open the form (modal)
                    frmCondirmOrderDelivery.ShowDialog();
                }
            }
        }
    }
}
