﻿using JeddoreISDPDesktop.DAO_Classes;
using JeddoreISDPDesktop.Entity_Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace JeddoreISDPDesktop
{
    public partial class ViewOrders : Form
    {
        //class level/global variable for the employee object from the dashboard
        Employee employee = null;

        public ViewOrders(Employee employeeLoggedIn)
        {
            InitializeComponent();
            employee = employeeLoggedIn;
        }

        private void ViewOrders_Load(object sender, EventArgs e)
        {
            //setting the tooltip for the help image
            toolTipHelp.SetToolTip(picHelp, "Click here for help.");

            //display the employee's username and location in this form
            lblUsername.Text = employee.username;
            lblLocation.Text = employee.siteName;

            //add ALL OPEN as first item in the combobox
            cboOrderTypes.Items.Add("ALL OPEN");

            //get a list of all of the txn statuses
            List<TxnStatus> txnStatusesList = TxnStatusAccessor.GetAllTxnStatusesList();

            //foreach txnStatus in this list, add to the combobox
            foreach (TxnStatus txnStatus in txnStatusesList)
            {
                cboOrderTypes.Items.Add(txnStatus.statusName);
            }

            //get the employee's user permissions
            UserPermission employeeUserPermissions = UserPermissionAccessor.GetOneEmployeeUserPermissions(employee.employeeID);

            //check the list for RECEIVESTOREORDER
            if (employeeUserPermissions.permissionIDList.Contains("RECEIVESTOREORDER"))
            {
                btnReceive.Enabled = true;
            }

            //check the list for REJECTORDER
            if (employeeUserPermissions.permissionIDList.Contains("REJECTORDER"))
            {
                btnReject.Enabled = true;
            }

            //check the list for ACCEPTSTOREORDER
            if (employeeUserPermissions.permissionIDList.Contains("ACCEPTSTOREORDER"))
            {
                btnAccept.Enabled = true;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
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
            MessageBox.Show("This is the page for viewing store and emergency orders. You can read orders from here, as well as filter by order type and search by fields such as status, created date, and ship date." +
            "\n\nClick on the 'refresh' button to load the orders data grid.", "View Orders Help"
            , MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ViewOrders_KeyDown(object sender, KeyEventArgs e)
        {
            //if F1 key is pressed down
            if (e.KeyCode == Keys.F1)
            {
                MessageBox.Show("This is the page for viewing store and emergency orders. You can read orders from here, as well as filter by order type and search by fields such as status, created date, and ship date." +
                "\n\nClick on the 'refresh' button to load the orders data grid.", "View Orders Help"
                , MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            //call show default orders ftn
            ShowDefaultOrders();

            //enable the textbox for user search
            txtSearchOrders.Enabled = true;

            //enable the combobox
            cboOrderTypes.Enabled = true;

            //enable the btn for view order items
            btnViewItems.Enabled = true;
        }

        //Show Default Orders - to display default orders meaning ones that are active and not complete, cancelled, etc.
        private void ShowDefaultOrders()
        {
            //create a new bindingsource
            BindingSource bindingSource = new BindingSource();

            DataTable dt = null;

            //if the employee logged in has admin or warehouse manager privileges, then show all orders regardless of site
            if (employee.positionID == 99999999 || employee.positionID == 4)
            {
                //create datatable - getting all orders regardless of site, returned as a datatable
                dt = TxnAccessor.GetAllOrdersDataTable();
            }

            //else - employee logged in is not an admin (Ex. store manager) then
            else
            {
                //create datatable - getting all orders by employee's site, returned as a datatable
                dt = TxnAccessor.GetAllOrdersBySiteDataTable(employee.siteID);
            }

            //set the binding source's datasource to the datatable
            bindingSource.DataSource = dt;

            //set the dgv's datasource to the bindingSource
            dgvOrders.DataSource = bindingSource;

            //autoresize dgv columns
            dgvOrders.AutoResizeColumns();

            //display the binding nav
            bindingNavigator.Visible = true;

            //set the binding source of the binding nav to the binding source created
            bindingNavigator.BindingSource = bindingSource;

            //hide the following columns
            dgvOrders.Columns["siteIDTo"].Visible = false;
            dgvOrders.Columns["siteIDFrom"].Visible = false;
            dgvOrders.Columns["deliveryID"].Visible = false;

            //change the header text of these columns
            dgvOrders.Columns["txnID"].HeaderText = "Order ID";
            dgvOrders.Columns["originSite"].HeaderText = "Origin Site";
            dgvOrders.Columns["destinationSite"].HeaderText = "Destination Site";
            dgvOrders.Columns["status"].HeaderText = "Status";
            dgvOrders.Columns["shipDate"].HeaderText = "Ship Date";
            dgvOrders.Columns["txnType"].HeaderText = "Order Type";
            dgvOrders.Columns["barCode"].HeaderText = "Bar Code";
            dgvOrders.Columns["createdDate"].HeaderText = "Created Date";
            //dgvOrders.Columns["deliveryID"].HeaderText = "Delivery ID";
            dgvOrders.Columns["emergencyDelivery"].HeaderText = "Emergency Order";
            dgvOrders.Columns["notes"].HeaderText = "Notes";

            dgvOrders.Refresh();
        }

        //Show Orders by Status - to display orders by status selected in the combobox
        private void ShowOrdersByStatus()
        {
            //create a new bindingsource
            BindingSource bindingSource = new BindingSource();

            DataTable dt = null;

            //if the employee logged in has admin OR warehouse manager privileges, then show all orders regardless of site
            if (employee.positionID == 99999999 || employee.positionID == 4)
            {
                //create datatable - getting all orders by status regardless of site, returned as a datatable
                dt = TxnAccessor.GetAllOrdersByStatusDataTable(cboOrderTypes.Text);
            }

            //else - employee logged in is not an admin or warehouse manager (ex. store manager) then
            else
            {
                //create datatable - getting all orders by employee's site AND status, returned as a datatable
                dt = TxnAccessor.GetAllOrdersByStatusAndSiteDataTable(cboOrderTypes.Text, employee.siteID);
            }

            //set the binding source's datasource to the datatable
            bindingSource.DataSource = dt;

            //set the dgv's datasource to the bindingSource
            dgvOrders.DataSource = bindingSource;

            //autoresize dgv columns
            dgvOrders.AutoResizeColumns();

            //display the binding nav
            bindingNavigator.Visible = true;

            //set the binding source of the binding nav to the binding source created
            bindingNavigator.BindingSource = bindingSource;

            //hide the following columns
            dgvOrders.Columns["siteIDTo"].Visible = false;
            dgvOrders.Columns["siteIDFrom"].Visible = false;
            dgvOrders.Columns["deliveryID"].Visible = false;

            //change the header text of these columns
            dgvOrders.Columns["txnID"].HeaderText = "Order ID";
            dgvOrders.Columns["originSite"].HeaderText = "Origin Site";
            dgvOrders.Columns["destinationSite"].HeaderText = "Destination Site";
            dgvOrders.Columns["status"].HeaderText = "Status";
            dgvOrders.Columns["shipDate"].HeaderText = "Ship Date";
            dgvOrders.Columns["txnType"].HeaderText = "Order Type";
            dgvOrders.Columns["barCode"].HeaderText = "Bar Code";
            dgvOrders.Columns["createdDate"].HeaderText = "Created Date";
            //dgvOrders.Columns["deliveryID"].HeaderText = "Delivery ID";
            dgvOrders.Columns["emergencyDelivery"].HeaderText = "Emergency Order";
            dgvOrders.Columns["notes"].HeaderText = "Notes";

            dgvOrders.Refresh();
        }

        private void cboOrderTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboOrderTypes.SelectedIndex == 0)
            {
                //call show default orders ftn
                ShowDefaultOrders();
            }

            //else
            else
            {
                //call orders by status ftn
                ShowOrdersByStatus();
            }
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

                    //else if - txn type cell converted to lower case contains the txtbox text
                    /* else if (txnTypeCellValue != null && txnTypeCellValue.ToString().ToLower().Contains(txtSearchOrders.Text))
                    {
                        row.Visible = true;
                    } */

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

        private void btnReceive_Click(object sender, EventArgs e)
        {
            int selectedRowsCount = dgvOrders.SelectedRows.Count;

            //if number of selected rows is not one
            if (selectedRowsCount != 1)
            {
                MessageBox.Show("Must select one row from the data grid in order to receive that specific order.",
                    "Order Receival Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
                Txn theTxn = TxnAccessor.GetOneTxn(txnID);

                //if the status of the txn is NOT submitted then
                if (theTxn.status != "Submitted")
                {
                    MessageBox.Show("The status of your selected order is: " + theTxn.status + "." +
                        "\n\nOnly orders with the status of 'Submitted' can be received by the warehouse for order assembly.",
                        "Unsuccessful Receival", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    dgvOrders.ClearSelection();
                }

                //else - the status is new then
                else
                {
                    //update the txn's status to assembling
                    theTxn.status = "Assembling";

                    //send the txn obj to the accessor
                    bool success = TxnAccessor.UpdateTxnStatus(theTxn);

                    //if success
                    if (success)
                    {
                        MessageBox.Show("Order for " + theTxn.destinationSite + " has been successfully received for assembly. It's status has been updated to " + theTxn.status + ".",
                            "Order Received");
                    }
                }
            }
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            int selectedRowsCount = dgvOrders.SelectedRows.Count;

            //if number of selected rows is not one
            if (selectedRowsCount != 1)
            {
                MessageBox.Show("Must select one row from the data grid in order to reject that specific order.",
                    "Order Rejection Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
                Txn theTxn = TxnAccessor.GetOneTxn(txnID);

                //if the status of the txn is submitted, rejected, or cancelled then
                if (theTxn.status == "Submitted" || theTxn.status == "Rejected" || theTxn.status == "Cancelled")
                {
                    MessageBox.Show("The status of your selected order is: " + theTxn.status + "." +
                        "\n\nOnly active orders which are not already submitted, rejected, or cancelled can be rejected.",
                        "Unsuccessful Rejection", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    dgvOrders.ClearSelection();
                }

                //else - the status is new then
                else
                {
                    //update the txn's status to rejected
                    theTxn.status = "Rejected";

                    //send the txn obj to the accessor
                    bool success = TxnAccessor.UpdateTxnStatus(theTxn);

                    //if success
                    if (success)
                    {
                        MessageBox.Show("Order for " + theTxn.destinationSite + " has been successfully rejected.",
                            "Order Recjected");
                    }
                }
            }
        }

        private void btnViewItems_Click(object sender, EventArgs e)
        {
            int selectedRowsCount = dgvOrders.SelectedRows.Count;

            //if number of selected rows is not one
            if (selectedRowsCount != 1)
            {
                MessageBox.Show("Must select one row from the data grid in order to reject that specific order.",
                    "Order Rejection Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
                Txn theTxn = TxnAccessor.GetOneOrder(txnID);

                //ope the view order items form, sending in the employee and txn objects
                ViewOrderItems frmViewOrderItems = new ViewOrderItems(employee, txnID);

                //open the view order items form (modal)
                frmViewOrderItems.ShowDialog();

            }
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            int selectedRowsCount = dgvOrders.SelectedRows.Count;

            //if number of selected rows is not one
            if (selectedRowsCount != 1)
            {
                MessageBox.Show("Must select one row from the data grid in order to accept that specific order for your store and accepted into it's inventory.",
                    "Order Acceptance Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
                Txn theTxn = TxnAccessor.GetOneTxn(txnID);

                //if the status of the txn is delivered or In progress then
                if (theTxn.status == "Delivered" || theTxn.status == "In progress")
                {
                    //update the txn's status to Complete
                    theTxn.status = "Complete";

                    //send the txn obj to the accessor
                    bool success = TxnAccessor.UpdateTxnStatus(theTxn);

                    //if success
                    if (success)
                    {
                        MessageBox.Show("Order for " + theTxn.destinationSite + " has been successfully completed and is no longer active. It's status has been updated to " + theTxn.status + "." +
                            "\n\nYour store's inventory should now be updated with the items and their quantities that were present in that order.",
                            "Order Accepted and Completed");
                    }
                }

                //else - the status is NOT either Delivered or In progress then
                else
                {
                    MessageBox.Show("The status of your selected order is: " + theTxn.status + "." +
                    "\n\nOnly orders with the status of 'Delivered' or 'In progress' can be accepted by your store and accepted into your inventory.",
                    "Unsuccessful Acceptance", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    dgvOrders.ClearSelection();
                }
            }
        }
    }
}
