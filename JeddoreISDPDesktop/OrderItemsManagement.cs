using JeddoreISDPDesktop.DAO_Classes;
using JeddoreISDPDesktop.Entity_Classes;
using System;
using System.Data;
using System.Windows.Forms;

namespace JeddoreISDPDesktop
{
    public partial class OrderItemsManagement : Form
    {
        //class level/global variable for the employee object from the dashboard
        Employee employee = null;

        public OrderItemsManagement(Employee employeeLoggedIn)
        {
            InitializeComponent();
            employee = employeeLoggedIn;
        }

        private void OrderItemsManagement_Load(object sender, System.EventArgs e)
        {
            //setting the tooltip for the help image
            toolTipHelp.SetToolTip(picHelp, "Click here for help.");

            //display the employee's username and location in this form
            lblUsername.Text = employee.username;
            lblLocation.Text = employee.siteName;

            //set the value for the date DTP to today (now)
            dtpShipDate.Value = DateTime.Now;
        }

        private void picHelp_Click(object sender, System.EventArgs e)
        {
            MessageBox.Show("This is the page for managing items and their quantities for active store and back orders. You can update and remove item quantities from a selected order here. The ship date for orders can also be updated here." +
            "\n\nClick on the 'refresh' button to load both data grids.", "Order Items Management Help"
            , MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void OrderItemsManagement_KeyDown(object sender, KeyEventArgs e)
        {
            //if the F1 key is pressed down
            if (e.KeyCode == Keys.F1)
            {
                MessageBox.Show("This is the page for managing items and their quantities for active store and back orders. You can update and remove item quantities from a selected order here. The ship date for orders can also be updated here." +
                "\n\nClick on the 'refresh' button to load both data grids.", "Order Items Management Help"
                , MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnExit_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, System.EventArgs e)
        {
            //timer to close this form after 20 minutes
            this.Close();
        }

        private void btnRefresh_Click(object sender, System.EventArgs e)
        {
            //create a new bindingsource
            BindingSource bindingSource = new BindingSource();

            DataTable dt = null;

            //create datatable - getting all orders regardless of site, returned as a datatable
            dt = TxnAccessor.GetAllOrdersDataTable();

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

            //clear selections in both DGVs
            dgvOrders.ClearSelection();
            dgvOrderItems.ClearSelection();

            //and enable the two textboxes for search
            txtSearchOrders.Enabled = true;
            txtSearchOrderItems.Enabled = true;
        }

        private void dgvOrders_SelectionChanged(object sender, System.EventArgs e)
        {
            //get the current row
            DataGridViewRow dgvRow = dgvOrders.CurrentRow;

            //get the cell with the txn ID (primary key)
            int txnID = int.Parse(dgvRow.Cells[0].Value.ToString());

            DataTable dt = TxnItemsAccessor.GetAllTxnItemsByTxnIDDataTable(txnID);

            //create a new bindingsource
            BindingSource bindingSource = new BindingSource();

            //set the binding source's datasource to the datatable
            bindingSource.DataSource = dt;

            //set the dgv's datasource to the bindingSource
            dgvOrderItems.DataSource = bindingSource;

            //autoresize dgv columns
            dgvOrderItems.AutoResizeColumns();

            //display the binding nav
            bindingNavigator2.Visible = true;

            //set the binding source of the binding nav to the binding source created
            bindingNavigator2.BindingSource = bindingSource;

            //hide these columns in the DGV
            dgvOrderItems.Columns["notes"].Visible = false;
            dgvOrderItems.Columns["txnID"].Visible = false;

            //change the header text of these columns
            //dgvOrder.Columns["txnID"].HeaderText = "Txn ID";
            dgvOrderItems.Columns["itemID"].HeaderText = "Item ID";
            dgvOrderItems.Columns["name"].HeaderText = "Name";
            dgvOrderItems.Columns["description"].HeaderText = "Description";
            dgvOrderItems.Columns["quantity"].HeaderText = "Quantity";
            dgvOrderItems.Columns["caseSize"].HeaderText = "Case Size";
            dgvOrderItems.Columns["weight"].HeaderText = "Weight";
            dgvOrderItems.Columns["notes"].HeaderText = "Notes";

            dgvOrderItems.Refresh();
        }

        private void txtSearchOrderItems_TextChanged(object sender, System.EventArgs e)
        {
            try
            {
                //want to clear DGV row selection to prevent DGV errors/program from crashing
                //each time the text is changed and if the user clicks on a CRUD btn for example
                //dgvOrders.ClearSelection();
                dgvOrderItems.ClearSelection();

                //converting the search text to all lower case
                string theSearchText = txtSearchOrderItems.Text.ToLower();

                CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[dgvOrderItems.DataSource];

                foreach (DataGridViewRow row in dgvOrderItems.Rows)
                {
                    //get the cell values for the following columns
                    var nameCellValue = row.Cells["Name"].Value;
                    var descriptionCellValue = row.Cells["description"].Value;
                    var itemIDCellValue = row.Cells["itemID"].Value;

                    //if txtbox is empty, then just show all the rows and continue
                    if (txtSearchOrderItems.Text.Equals(""))
                    {
                        row.Visible = true;
                        continue;
                    }

                    //if - first name cell converted to lower case contains the txtbox text
                    if (nameCellValue != null && nameCellValue.ToString().ToLower().Contains(theSearchText))
                    {
                        row.Visible = true;
                    }

                    //else if - last name cell converted to lower case contains the txtbox text
                    else if (descriptionCellValue != null && descriptionCellValue.ToString().ToLower().Contains(theSearchText))
                    {
                        row.Visible = true;
                    }

                    //else if - item ID cell contains the txtbox text
                    else if (itemIDCellValue != null && itemIDCellValue.ToString().Contains(theSearchText))
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

        private void txtSearchOrders_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //want to clear DGV row selection to prevent DGV errors/program from crashing
                //each time the text is changed and if the user clicks on a CRUD btn for example
                dgvOrders.ClearSelection();
                //dgvOrderItems.ClearSelection();

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

                    //else if - status cell converted to string contains the txtbox text
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

        private void btnRemove_Click(object sender, EventArgs e)
        {
            int selectedRowsCount = dgvOrderItems.SelectedRows.Count;

            //if number of selected rows is not one
            if (selectedRowsCount != 1)
            {
                MessageBox.Show("Must select one row from the order items data grid in order to completely remove your selected item from an order.",
                    "Item Removal Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                //clear all selected rows from the dgv
                dgvOrderItems.ClearSelection();
            }

            //else - 1 item row is selected
            else
            {
                //get the current row - order items
                DataGridViewRow dgvRowOrderItems = dgvOrderItems.CurrentRow;

                //get the current row - orders
                DataGridViewRow dgvRowOrders = dgvOrders.CurrentRow;

                //get the cell with the selected item's itemID in the order items DGV
                int itemID = int.Parse(dgvRowOrderItems.Cells[1].Value.ToString());

                //get the cell with the txnID in the order DGV
                int txnID = int.Parse(dgvRowOrders.Cells[0].Value.ToString());

                //also get the cell with the status
                string status = dgvRowOrders.Cells[5].Value.ToString();

                if (status != "New" && status != "Submitted" && status != "Assembling")
                {
                    MessageBox.Show("Item can't be completely removed from an order that is already " + status + "." +
                        "\n\nOrder must be new, submitted, or assembling for item removal.",
                        "Unable to Remove", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    return;
                }

                //get the txnItem based on the table's two PKs
                TxnItems theTxnItem = TxnItemsAccessor.GetOneTxnItem(txnID, itemID);

                DialogResult btnValueReturned = MessageBox.Show("Are you sure you want to completely remove item of ID and name: " +
                theTxnItem.itemID + " - " + theTxnItem.name + " from this order?", "Confirm Item Removal",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                //if - user selects the yes btn
                if (btnValueReturned == DialogResult.Yes)
                {
                    //attempt to remove the item from the order
                    bool success = TxnItemsAccessor.DeleteTxnItem(theTxnItem);

                    if (success)
                    {
                        MessageBox.Show("Item of ID and name: " + theTxnItem.itemID + " - " + theTxnItem.name + " has been completely removed from the order.",
                            "Successful Item Removal");

                        dgvOrderItems.ClearSelection();
                    }
                }
            }
        }

        private void btnUpdateQuantity_Click(object sender, EventArgs e)
        {
            int selectedRowsCount = dgvOrderItems.SelectedRows.Count;

            //if number of selected rows is not one
            if (selectedRowsCount != 1)
            {
                MessageBox.Show("Must select one row from the order items data grid in order to update that's item's quantity in the order.",
                    "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //clear all selected rows from the dgv
                dgvOrderItems.ClearSelection();
            }

            //else - 1 order item row is selected
            else
            {
                //get the current row - order items
                DataGridViewRow dgvRowOrderItems = dgvOrderItems.CurrentRow;

                //get the current row - orders
                DataGridViewRow dgvRowOrders = dgvOrders.CurrentRow;

                //also get the cell with the status
                string status = dgvRowOrders.Cells[5].Value.ToString();

                if (status != "New" && status != "Submitted" && status != "Assembling")
                {
                    MessageBox.Show("Quantity can't be updated for an order that is already " + status + "." +
                        "\n\nOrder must be new, submitted, or assembling to update item quantities.",
                        "Unable to Update Quantity", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    return;
                }

                //get the cell with the selected order's txnID in the order DGV
                int txnID = int.Parse(dgvRowOrders.Cells[0].Value.ToString());

                //get the cell with the selected item's itemID in the order DGV
                int itemID = int.Parse(dgvRowOrderItems.Cells[1].Value.ToString());

                //also get the cell with the selected item's current quantity in the order DGV
                int quantity = int.Parse(dgvRowOrderItems.Cells[4].Value.ToString());

                //also get the cell with the siteIDTo (destination site ID)
                int siteIDTo = int.Parse(dgvRowOrders.Cells[3].Value.ToString());

                //also need to get the cell with the txn/order type
                string txnType = dgvRowOrders.Cells[7].Value.ToString();

                //get an item object based on the itemID
                Item selectedItem = ItemAccessor.GetOneItem(itemID);

                //get an inventory object based on the itemID and site ID for the warehouse (2)
                Inventory warehouseInventoryItem = InventoryAccessor.GetOneInventoryItem(2, itemID);

                //if the txnType is a store order or emergency then
                //can open the form for adding or editing an item in a store order
                if (txnType == "Store Order" || txnType == "Emergency")
                {
                    //want to send the 3 objs to the add/edit order item form
                    AddEditOrderItem frmAddEditOrderItem = new AddEditOrderItem(employee, selectedItem,
                        warehouseInventoryItem, quantity, siteIDTo);

                    //open the add/edit user form (modal)
                    frmAddEditOrderItem.ShowDialog();
                }

                //else - txnType is a back order, then
                //need to open the other form for adding or updating an item in a Back Order
                //NOTE: this form still needs to be created
                else
                {
                    //want to send the 3 objs to the edit back order item form
                    EditBackOrderItem frmEditBackOrderItem = new EditBackOrderItem(employee, selectedItem,
                        warehouseInventoryItem, quantity, siteIDTo, txnID);

                    //open the add/edit user form (modal)
                    frmEditBackOrderItem.ShowDialog();
                }
            }
        }

        private void btnUpdateShipDate_Click(object sender, EventArgs e)
        {
            int selectedRowsCount = dgvOrders.SelectedRows.Count;

            //if number of selected rows is not one
            if (selectedRowsCount != 1)
            {
                MessageBox.Show("Must select one row from the orders data grid in order to manually update that order's ship date.",
                    "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //clear all selected rows from the dgv
                dgvOrders.ClearSelection();
            }

            //else - 1 order item row is selected
            else
            {
                //get the current row - orders
                DataGridViewRow dgvRowOrders = dgvOrders.CurrentRow;

                //get the cell with the selected order's txnID in the order DGV
                int txnID = int.Parse(dgvRowOrders.Cells[0].Value.ToString());

                //get the cell with the siteIDTo
                int siteIDTo = int.Parse(dgvRowOrders.Cells[3].Value.ToString());

                //get the cell with the txnType
                string txnType = dgvRowOrders.Cells[7].Value.ToString();

                //also get the cell with the status
                string status = dgvRowOrders.Cells[5].Value.ToString();

                if (status == "Delivered")
                {
                    MessageBox.Show("Ship date can't be updated for an order that is already " + status + ".",
                    "Unable to Update Ship Date", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    return;
                }

                //if txnType is a store or emergency order
                if (txnType == "Store Order" || txnType == "Emergency")
                {
                    //get the store or emergency order based on the siteIDTo
                    Txn order = TxnAccessor.GetOneOrder(txnID);

                    //store the old ship date in this var
                    DateTime oldShipDate = order.shipDate;

                    //getting just the date from the dtp for the date
                    DateTime dateOnly = dtpShipDate.Value.Date;

                    //getting just the time from the dtp for the time
                    //TimeOfDay returns a TimeSpan
                    TimeSpan timeOnly = dtpShipDateTime.Value.TimeOfDay;

                    //add the timespan obj to the date for the combined date
                    DateTime combinedShipDate = dateOnly.Date.Add(timeOnly);

                    //update the txn object's ship date
                    order.shipDate = combinedShipDate;

                    //send the object into the accessor
                    bool success = TxnAccessor.UpdateTxnShipDate(order);

                    if (success)
                    {
                        MessageBox.Show("Ship date for the order for " + order.destinationSite +
                            " has been changed from " + oldShipDate + " to " + order.shipDate + ".",
                            "Ship Date Updated");
                    }
                }

                //else if - it is a back order
                else if (txnType == "Back Order")
                {
                    //get the back order based on the siteIDTo
                    Txn backOrder = TxnAccessor.GetOneBackOrder(txnID);

                    //store the old ship date in this var
                    DateTime oldShipDate = backOrder.shipDate;

                    //getting the date from the dtp for the date
                    DateTime dateOnly = dtpShipDate.Value.Date;

                    //getting the time from the dtp for the time
                    TimeSpan timeOnly = dtpShipDateTime.Value.TimeOfDay;

                    DateTime combinedShipDate = dateOnly.Date.Add(timeOnly);

                    //update the txn object's ship date
                    backOrder.shipDate = combinedShipDate;

                    //send the object into the accessor
                    bool success = TxnAccessor.UpdateTxnShipDate(backOrder);

                    if (success)
                    {
                        MessageBox.Show("Ship date for the back order for " + backOrder.destinationSite +
                            " has been changed from " + oldShipDate + " to " + backOrder.shipDate + ".",
                            "Ship Date Updated");
                    }
                }
            }
        }
    }
}
