﻿using JeddoreISDPDesktop.DAO_Classes;
using JeddoreISDPDesktop.Entity_Classes;
using JeddoreISDPDesktop.Helper_Classes;
using System;
using System.Collections.Generic;
using System.Data;
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
            MessageBox.Show("This is the form for confirming orders that are picked up or delivered. You can select a store order here in the first tab, then confirm them for either pick up or delivery in the second and third tabs respectively." +
            "\n\nClick on the 'refresh' button in the first tab to load the store orders data grid.", "Pickup and Deliver Orders Help"
            , MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void PickupAndDeliverOrders_KeyDown(object sender, KeyEventArgs e)
        {
            //if the F1 key is pressed down
            if (e.KeyCode == Keys.F1)
            {
                MessageBox.Show("This is the form for confirming orders that are picked up or delivered. You can select a store order here in the first tab, then confirm them for either pick up or delivery in the second and third tabs respectively." +
                "\n\nClick on the 'refresh' button in the first tab to load the store orders data grid.", "Pickup and Deliver Orders Help"
                , MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dtpShipDate_ValueChanged(object sender, EventArgs e)
        {
            DateTime selectedShipDate = dtpShipDate.Value;

            //get list of txns (store orders) with a ship date of the value of the DTP
            List<Txn> listOrdersOnShipDate = TxnAccessor.GetAllOrdersListForShipDate(selectedShipDate);

            //get the weight of all the store orders on the ship date
            decimal weightOnShipDate = TxnItemsAccessor.GetTxnWeightForShipDate(selectedShipDate);

            //clear the listbox and store orders list
            lstPickedUpOrders.Items.Clear();
            storeOrdersList.Clear();

            //update the vehicle type label in the second tab to this
            lblVehicleType1.Text = "Needed Vehicle for Delivery on " + selectedShipDate.ToShortDateString() + ":";

            //update this label as well
            lblNumOrdersScheduled1.Text = "Number of Orders Scheduled for Pick Up on " + selectedShipDate.ToShortDateString() + ":";

            lblNumOrdersScheduled2.Text = listOrdersOnShipDate.Count.ToString();

            lblNumOrdersPickedUp.Text = lstPickedUpOrders.Items.Count.ToString();

            lblEstimatedDeliveryWeight.Text = weightOnShipDate.ToString();

            //get the recommended/needed vehicle type based on the weight on the ship date
            string vehicleType = DeliveryCalculator.GetRecommendedVehicleType(weightOnShipDate);

            //put the vehicle type in it's label as well
            lblVehicleType2.Text = vehicleType;
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

        }
    }
}
