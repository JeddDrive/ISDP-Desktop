using JeddoreISDPDesktop.DAO_Classes;
using JeddoreISDPDesktop.Entity_Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace JeddoreISDPDesktop
{
    public partial class FulfillOrders : Form
    {
        //class level/global variable for the employee object from the dashboard
        Employee employee = null;

        //global variable for the txn object - selected for fulfillment
        //Txn selectedTxn = new Txn();

        //global variable for the selected txnID
        int selectedTxnID = 0;

        //global list to track the txn items that are fulfilled
        List<TxnItems> txnItemsList = new List<TxnItems>();

        public FulfillOrders(Employee employeeLoggedIn)
        {
            InitializeComponent();
            employee = employeeLoggedIn;
        }

        private void FulfillOrders_Load(object sender, EventArgs e)
        {
            //setting the tooltip for the help image
            toolTipHelp.SetToolTip(picHelp, "Click here for help.");

            //display the employee's username and location in this form
            lblUsername.Text = employee.username;
            lblLocation.Text = employee.siteName;

            //disable the order items tab on form load
            ((Control)this.tabOrderItems).Enabled = false;

            //add first item to the listbox - for info purposes
            lstFulfilledItems.Items.Add("Item ID                Name                        Quantity");
        }

        //timer to close this form after 20 mins
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExitOrders_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void picHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This is the page for fulfilling an order that is in assembly. You can select an order here in the first tab, then click on order items to confirm their fulfillment in the second tab." +
                "\n\nClick on the 'refresh' button in either tab to load the appropriate data grid.", "Fulfill Orders Help"
                , MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void FulfillOrders_KeyDown(object sender, KeyEventArgs e)
        {
            //if F1 key is pressed down
            if (e.KeyCode == Keys.F1)
            {
                MessageBox.Show("This is the page for fulfilling an order that is in assembly. You can select an order here in the first tab, then click on order items to confirm their fulfillment in the second tab." +
                "\n\nClick on the 'refresh' button in either tab to load the appropriate data grid.", "Fulfill Orders Help"
                , MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnRefreshOrders_Click(object sender, EventArgs e)
        {
            //create a new bindingsource
            BindingSource bindingSource = new BindingSource();

            DataTable dt = null;

            //create datatable - getting all orders by employee's site AND status, returned as a datatable
            //Should be getting orders only with the status of "Assembling" in the warehouse (siteID of 2)
            dt = TxnAccessor.GetAllOrdersByStatusAndSiteFromDataTable("Assembling", 2);

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

            //clear dgv selection
            dgvOrders.ClearSelection();

            //enable the textbox for user search
            txtSearchOrders.Enabled = true;
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

        private void btnSelectOrder_Click(object sender, EventArgs e)
        {
            int selectedRowsCount = dgvOrders.SelectedRows.Count;

            //if number of selected rows is not one
            if (selectedRowsCount != 1)
            {
                MessageBox.Show("Must select one row from the orders data grid in order to start fulfilling that specific order.",
                    "Order Fulfillment Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

                //also assign the txnID to this global var
                selectedTxnID = txnID;

                //if txnID's are a match
                if (selectedTxn.txnID == txnID)
                {
                    //enable the order items tab
                    ((Control)this.tabOrderItems).Enabled = true;

                    //enable the refresh and exit btns on the next tabpage
                    btnRefreshOrderItems.Enabled = true;
                    btnExitOrderItems.Enabled = true;

                    MessageBox.Show("Order " + selectedTxn.txnID.ToString() + " for " +
                        selectedTxn.destinationSite + " has been selected for fulfillment. You can start " +
                        "adding items as they are assembled for this order in the next tab.", "Order Selected for Fulfillment",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void tabOrders_Click(object sender, EventArgs e)
        {
            //if user goes back to the orders tab, then disable the order items tab
            ((Control)this.tabOrderItems).Enabled = false;
        }

        private void btnExitOrderItems_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRefreshOrderItems_Click(object sender, EventArgs e)
        {
            //get the selected transaction
            Txn selectedTxn = TxnAccessor.GetOneOrder(selectedTxnID);

            //get all the txn items for the txn, based on the txnID for the selecte txn
            DataTable dt = TxnItemsAccessor.GetAllTxnItemsByTxnIDDataTable(selectedTxn.txnID);

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

            //enable the search txtbox
            txtSearchOrderItems.Enabled = true;

            //enable these 3 btns
            btnAddItem.Enabled = true;
            btnRemoveItem.Enabled = true;
            btnOrderFulfilled.Enabled = true;

            //clear selection in the dgv
            dgvOrderItems.ClearSelection();

            //loop thru the dgv
            foreach (DataGridViewRow row in dgvOrderItems.Rows)
            {
                //inner loop thru the txn items list
                foreach (TxnItems txnItem in txnItemsList)
                {
                    //if itemID is a match then
                    if (Convert.ToInt32(row.Cells[1].Value) == txnItem.itemID)
                    {
                        //add this color to the row
                        row.DefaultCellStyle.BackColor = Color.LightGreen;
                    }
                }
            }
        }

        private void btnRemoveItem_Click(object sender, EventArgs e)
        {
            //if - no item selected in the listbox
            if (lstFulfilledItems.SelectedIndex == -1 || lstFulfilledItems.SelectedItems.Count != 1)
            {
                MessageBox.Show("Must select one item in the listbox in order to remove it from being fulfilled for the order.", "Item Removal Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                //clear selected listbox items
                lstFulfilledItems.ClearSelected();
            }

            //else - 1 item is selected in the listbox and its not the first index
            else if (lstFulfilledItems.SelectedIndex > 0)
            {
                //get the text from the lstbox for the selected item
                string itemText = lstFulfilledItems.GetItemText(lstFulfilledItems.SelectedItem);

                //split the string at each empty space
                string[] splitArray = itemText.Split(' ');

                //get the itemID from the array
                int itemID = int.Parse(splitArray[0]);

                //foreach loop thru the txnItems list
                foreach (TxnItems item in txnItemsList)
                {
                    //if itemID is a match then
                    if (item.itemID == itemID)
                    {
                        //remove item from the list
                        txnItemsList.Remove(item);

                        //display msg, clear the dgv, and exit the event
                        MessageBox.Show("Item " + item.itemID + " - " + item.name + " has been removed from being fulfilled in this order.", "Item Removed From Fulfillment",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        break;
                    }
                }

                //loop thru the dgv
                foreach (DataGridViewRow row in dgvOrderItems.Rows)
                {
                    //if itemID is a match then
                    if (Convert.ToInt32(row.Cells[1].Value) == itemID)
                    {
                        //add this color to the row
                        row.DefaultCellStyle.BackColor = Color.White;
                    }
                }

                //remove from the listbox at the selected index
                lstFulfilledItems.Items.RemoveAt(lstFulfilledItems.SelectedIndex);
            }
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            int selectedRowsCount = dgvOrderItems.SelectedRows.Count;

            //if number of selected rows is not one
            if (selectedRowsCount != 1)
            {
                MessageBox.Show("Must select one row from the order items data grid in order to account for it being fulfilled in the order.",
                    "Item Addition Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //clear all selected rows from the dgv
                dgvOrderItems.ClearSelection();
            }

            //else - 1 order item row is selected
            else
            {
                //get the current row
                DataGridViewRow dgvRow = dgvOrderItems.CurrentRow;

                //get the cell with the itemID
                int itemID = int.Parse(dgvRow.Cells[1].Value.ToString());

                //now get the txnitem using the txnID and itemID
                TxnItems txnItem = TxnItemsAccessor.GetOneTxnItem(selectedTxnID, itemID);

                //foreach loop thru the txnItems list
                foreach (TxnItems item in txnItemsList)
                {
                    //if itemID is a match
                    if (item.itemID == txnItem.itemID)
                    {
                        //display msg, clear the dgv, and exit the event
                        MessageBox.Show("Item is already assembled for this order, and therefore it can't be added again.", "Item Already Assembled",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        dgvOrderItems.ClearSelection();

                        return;
                    }
                }

                //add the txnItem to the global list
                txnItemsList.Add(txnItem);

                //add the item to the listbox
                lstFulfilledItems.Items.Add(txnItem.itemID + " " + txnItem.name + " " + txnItem.quantity);

                //loop thru the dgv
                foreach (DataGridViewRow row in dgvOrderItems.Rows)
                {
                    //if itemID is a match then
                    if (Convert.ToInt32(row.Cells[1].Value) == txnItem.itemID)
                    {
                        //add this color to the row
                        row.DefaultCellStyle.BackColor = Color.LightGreen;
                    }
                }

                //display msg, clear the dgv, and exit the event
                MessageBox.Show("Item " + txnItem.itemID + " - " + txnItem.name + " has been accounted for in fulfillment for this order.", "Item Added to Order For Fulfillment",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                //clear selections in the dgv and listbox
                dgvOrderItems.ClearSelection();
                lstFulfilledItems.ClearSelected();

                //get the real num of items in the order/txn
                long numItemsInOrder = TxnItemsAccessor.GetCountOfItemsInTxn(selectedTxnID);

                //if the real num of items in the order now equals the 
                //count of the list of txnitems then
                if (numItemsInOrder == txnItemsList.Count)
                {
                    DialogResult btnValueReturned = MessageBox.Show("All items in this order are accounted for now. Set order as being assembled now?",
                        "All Items Now in Order", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    //if - user selects the yes btn
                    if (btnValueReturned == DialogResult.Yes)
                    {
                        //get the selected transaction
                        Txn selectedTxn = TxnAccessor.GetOneOrder(selectedTxnID);

                        //update the txn's status property to Assembled
                        selectedTxn.status = "Assembled";

                        //send the txn obj to the accessor
                        bool success = TxnAccessor.UpdateTxnStatus(selectedTxn);

                        //if success
                        if (success)
                        {
                            MessageBox.Show("Order for " + selectedTxn.destinationSite + " has been successfully fulfilled and is ready for delivery pickup. It's status has been updated to " + selectedTxn.status + ".",
                                "Order Fulfilled");

                            //and close the form
                            this.Close();
                        }
                    }
                }
            }
        }

        private void btnOrderFulfilled_Click(object sender, EventArgs e)
        {
            //get the real num of items in the order/txn
            long numItemsInOrder = TxnItemsAccessor.GetCountOfItemsInTxn(selectedTxnID);

            //if the rela num of items in the order does not equal the 
            //count of the list of txnitems then
            if (numItemsInOrder != txnItemsList.Count)
            {
                MessageBox.Show("Not all items accounted for in this order. Number of items required for this order is " +
                    numItemsInOrder.ToString() + ", while the number of items currently fulfilled in this order is " + txnItemsList.Count.ToString() + ".",
                    "Order is Missing Items", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                //clear selections in the dgv and listbox
                dgvOrderItems.ClearSelection();
                lstFulfilledItems.ClearSelected();
            }

            //else - is a match then
            else
            {
                //get the selected transaction
                Txn selectedTxn = TxnAccessor.GetOneOrder(selectedTxnID);

                //update the txn's status property to Assembled
                selectedTxn.status = "Assembled";

                //send the txn obj to the accessor
                bool success = TxnAccessor.UpdateTxnStatus(selectedTxn);

                //if success
                if (success)
                {
                    MessageBox.Show("Order for " + selectedTxn.destinationSite + " has been successfully fulfilled and is ready for delivery pickup. It's status has been updated to " + selectedTxn.status + ".",
                        "Order Fulfilled");

                    //and close the form
                    this.Close();
                }
            }
        }

        private void txtSearchOrderItems_TextChanged_1(object sender, EventArgs e)
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
    }
}
