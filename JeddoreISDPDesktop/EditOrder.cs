using JeddoreISDPDesktop.DAO_Classes;
using JeddoreISDPDesktop.Entity_Classes;
using System;
using System.Data;
using System.Windows.Forms;

namespace JeddoreISDPDesktop
{
    public partial class EditOrder : Form
    {
        //class level/global variable for the employee object from the dashboard
        Employee employee = null;

        //global variable for the txn/order object
        Txn newOrder = new Txn();

        public EditOrder(Employee employeeLoggedIn)
        {
            InitializeComponent();
            employee = employeeLoggedIn;

            //get current store OR emergency order for a store that is NEW, based on the employee's siteID
            newOrder = TxnAccessor.GetOneNewOrder(employee.siteID);
        }

        private void EditOrder_Load(object sender, EventArgs e)
        {
            //setting the tooltip for the help image
            toolTipHelp.SetToolTip(picHelp, "Click here for help.");

            //display the employee's username and location in this form
            lblUsername.Text = employee.username;
            lblLocation.Text = employee.siteName;
            lblOrderID.Text = newOrder.txnID.ToString();

            //if txn is a store order
            if (newOrder.txnType == "Store Order")
            {
                lblMain.Text += newOrder.txnType;
            }

            //else if - is an emergency orer
            else if (newOrder.txnType == "Emergency")
            {
                lblMain.Text += " Emergency Order";
            }
        }

        private void picHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This is the page for editing your current order. You can add and remove items to and from your order from here." +
            "\n\nClick on the 'refresh' button to load both data grids." +
            "\n\nClick on the 'submit' button to submit your order to the warehouse.", "Edit Order Help"
            , MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void EditOrder_KeyDown(object sender, KeyEventArgs e)
        {
            //if user presses the F1 key
            if (e.KeyCode == Keys.F1)
            {
                MessageBox.Show("This is the page for editing your current order. You can add and remove items to and from your order from here." +
                "\n\nClick on the 'refresh' button to load both data grids." +
                "\n\nClick on the 'submit' button to submit your order to the warehouse.", "Edit Order Help"
                , MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //timer to close this form after 20 minutes
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            //setting up the order DGV
            //create a new bindingsource
            BindingSource bindingSource1 = new BindingSource();

            //create datatable - getting all txnitems, returned as a datatable
            DataTable dt = TxnItemsAccessor.GetAllTxnItemsByTxnIDDataTable(newOrder.txnID);

            //set the binding source's datasource to the datatable
            bindingSource1.DataSource = dt;

            //set the dgv's datasource to the bindingSource
            dgvOrder.DataSource = bindingSource1;

            //autoresize dgv columns
            dgvOrder.AutoResizeColumns();

            //display the binding nav
            bindingNavigator1.Visible = true;

            //set the binding source of the binding nav to the binding source created
            bindingNavigator1.BindingSource = bindingSource1;

            //hide these columns in the DGV
            dgvOrder.Columns["notes"].Visible = false;
            dgvOrder.Columns["txnID"].Visible = false;

            //change the header text of these columns
            //dgvOrder.Columns["txnID"].HeaderText = "Txn ID";
            dgvOrder.Columns["itemID"].HeaderText = "Item ID";
            dgvOrder.Columns["name"].HeaderText = "Name";
            dgvOrder.Columns["description"].HeaderText = "Description";
            dgvOrder.Columns["quantity"].HeaderText = "Quantity";
            dgvOrder.Columns["caseSize"].HeaderText = "Case Size";
            dgvOrder.Columns["weight"].HeaderText = "Weight";
            dgvOrder.Columns["notes"].HeaderText = "Notes";

            dgvOrder.Refresh();

            //setting up the inventory DGV
            //create a new bindingsource
            BindingSource bindingSource2 = new BindingSource();

            //create datatable - getting all inventory from the warehouse, returned as a datatable
            DataTable dt2 = InventoryAccessor.GetAllInventoryBySiteDataTable(2);

            //set the binding source's datasource to the datatable
            bindingSource2.DataSource = dt2;

            //set the dgv's datasource to the bindingSource
            dgvInventory.DataSource = bindingSource2;

            //autoresize dgv columns
            dgvInventory.AutoResizeColumns();

            //display the binding nav
            bindingNavigator2.Visible = true;

            //set the binding source of the binding nav to the binding source created
            bindingNavigator2.BindingSource = bindingSource2;

            //hiding the description and notes columns - for performance
            //dgvInventory.Columns["description"].Visible = false;
            dgvInventory.Columns["notes"].Visible = false;
            dgvInventory.Columns["reorderThreshold"].Visible = false;
            dgvInventory.Columns["optimumThreshold"].Visible = false;
            dgvInventory.Columns["itemLocation"].Visible = false;

            //change the header text of these columns
            dgvInventory.Columns["itemID"].HeaderText = "Item ID";
            dgvInventory.Columns["name"].HeaderText = "Name";
            dgvInventory.Columns["description"].HeaderText = "Description";
            dgvInventory.Columns["siteID"].HeaderText = "Site ID";
            dgvInventory.Columns["quantity"].HeaderText = "Quantity";
            //dgvInventory.Columns["itemLocation"].HeaderText = "Item Location";
            //dgvInventory.Columns["reorderThreshold"].HeaderText = "Reorder Threshold";
            //dgvInventory.Columns["optimumThreshold"].HeaderText = "Optimum Threshold";
            //dgvInventory.Columns["notes"].HeaderText = "Notes";

            dgvInventory.Refresh();

            //clear selections in both DGVs
            dgvOrder.ClearSelection();
            dgvInventory.ClearSelection();

            //and enable the two textboxes for search
            txtSearchOrder.Enabled = true;
            txtSearchInventory.Enabled = true;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            //if order is an emergency order, ensure items are 5 or less
            if (newOrder.txnType == "Emergency")
            {
                //get the count of items
                long numTxnItems = TxnItemsAccessor.GetCountOfItemsInTxn(newOrder.txnID);

                if (numTxnItems > 5 || numTxnItems < 1)
                {
                    MessageBox.Show("Emerency Orders must contain between 1 and 5 items." +
                        "You have " + numTxnItems.ToString() + " items. Please review your emergency order items.", "Emergency Order Not Submitted",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    //focus on txtbox
                    txtSearchOrder.Focus();

                    return;
                }

                //else - are between 1 and 5 items then
                else
                {
                    //update the status property of this new order
                    newOrder.status = "Submitted";

                    //change the order's status from New to Submitted
                    bool success = TxnAccessor.UpdateTxnStatus(newOrder);

                    //if success, display success message and close the form
                    if (success)
                    {
                        MessageBox.Show("Your order has been successfully submitted to the warehouse.", "Successful Order Submission");

                        this.Close();
                    }
                }
            }

            //else - order is a store order, which have no item limit
            else
            {
                //get the count of items
                long numTxnItems = TxnItemsAccessor.GetCountOfItemsInTxn(newOrder.txnID);

                if (numTxnItems < 1)
                {
                    MessageBox.Show("Store orders must contain at least one one item." +
                        "You have " + numTxnItems.ToString() + " items. Please review your store order items.", "Store Order Not Submitted",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    //focus on txtbox
                    txtSearchOrder.Focus();

                    return;
                }

                //update the status property of this new order
                newOrder.status = "Submitted";

                //change the order's status from New to Submitted
                bool success = TxnAccessor.UpdateTxnStatus(newOrder);

                //if success, display success message and close the form
                if (success)
                {
                    MessageBox.Show("Your order has been successfully submitted to the warehouse.", "Successful Order Submission");

                    this.Close();
                }
            }
        }

        private void txtSearchOrder_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //want to clear DGV row selection to prevent DGV errors/program from crashing
                //each time the text is changed and if the user clicks on a CRUD btn for example
                dgvOrder.ClearSelection();
                dgvInventory.ClearSelection();

                //converting the search text to all lower case
                string theSearchText = txtSearchOrder.Text.ToLower();

                CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[dgvOrder.DataSource];

                foreach (DataGridViewRow row in dgvOrder.Rows)
                {
                    //get the cell values for the following columns
                    var nameCellValue = row.Cells["name"].Value;
                    var descriptionCellValue = row.Cells["description"].Value;
                    var itemIDCellValue = row.Cells["itemID"].Value;

                    //if txtbox is empty, then just show all the rows and continue
                    if (txtSearchOrder.Text.Equals(""))
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

        private void txtSearchInventory_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //want to clear DGV row selection to prevent DGV errors/program from crashing
                //each time the text is changed and if the user clicks on a CRUD btn for example
                dgvOrder.ClearSelection();
                dgvInventory.ClearSelection();

                //converting the search text to all lower case
                string theSearchText = txtSearchInventory.Text.ToLower();

                CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[dgvInventory.DataSource];

                foreach (DataGridViewRow row in dgvInventory.Rows)
                {
                    //get the cell values for the following columns
                    var nameCellValue = row.Cells["name"].Value;
                    var descriptionCellValue = row.Cells["description"].Value;
                    var itemIDCellValue = row.Cells["itemID"].Value;

                    //if txtbox is empty, then just show all the rows and continue
                    if (txtSearchInventory.Text.Equals(""))
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int selectedRowsCount = dgvInventory.SelectedRows.Count;

            //if number of selected rows is not one
            if (selectedRowsCount != 1)
            {
                MessageBox.Show("Must select one row from the warehouse inventory data grid in order to add that inventory item to your order.",
                    "Inventory Item Addition Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                //clear all selected rows from the dgv
                dgvInventory.ClearSelection();
            }

            //else - 1 inventory item row is selected
            else
            {
                //get the current row
                DataGridViewRow dgvRow = dgvInventory.CurrentRow;

                //get the cell with the selected item's itemID in the order DGV
                int itemID = int.Parse(dgvRow.Cells[0].Value.ToString());

                //get an item object based on the itemID
                Item selectedItem = ItemAccessor.GetOneItem(itemID);

                //get an inventory object based on the itemID and site ID for the warehouse (2)
                Inventory warehouseInventoryItem = InventoryAccessor.GetOneInventoryItem(2, itemID);

                //see if the item already exists in the order with this method
                //should be 1 or 0
                long numItemInOrder = TxnItemsAccessor.GetCountOfSpecificItemInTxn(newOrder.txnID, itemID);

                //if item is NOT in the order then
                if (numItemInOrder == 0)
                {
                    //want to send the 3 objs to the add/edit order item form
                    AddEditOrderItem frmAddEditOrderItem = new AddEditOrderItem(employee, selectedItem,
                        warehouseInventoryItem);

                    //open the add/edit user form (modal)
                    frmAddEditOrderItem.ShowDialog();
                }

                //else - item is already in the order
                else
                {
                    MessageBox.Show("Item is already in your order. If you wish to update that item's quantity in your order, please click on the 'update' button while that item is selected in the order data grid instead.",
                    "Item Already in Order", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    //clear all selected rows from the dgv
                    dgvInventory.ClearSelection();
                }
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            int selectedRowsCount = dgvOrder.SelectedRows.Count;

            //if number of selected rows is not one
            if (selectedRowsCount != 1)
            {
                MessageBox.Show("Must select one row from the order items data grid in order to remove your selected item.",
                    "Item Removal Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                //clear all selected rows from the dgv
                dgvOrder.ClearSelection();
            }

            //else - 1 item row is selected
            else
            {
                //get the current row
                DataGridViewRow dgvRow = dgvOrder.CurrentRow;

                //get the cell with the selected item's itemID in the order DGV
                int itemID = int.Parse(dgvRow.Cells[1].Value.ToString());

                //get the txnItem based on the table's two PKs
                TxnItems theTxnItem = TxnItemsAccessor.GetOneTxnItem(newOrder.txnID, itemID);

                DialogResult btnValueReturned = MessageBox.Show("Are you sure you want to remove item of ID and name: " +
                theTxnItem.itemID + " - " + theTxnItem.name + " from your order?", "Confirm Item Removal",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                //if - user selects the yes btn
                if (btnValueReturned == DialogResult.Yes)
                {

                    //attempt to remove the item from the order
                    bool success = TxnItemsAccessor.DeleteTxnItem(theTxnItem);

                    if (success)
                    {
                        MessageBox.Show("Item of ID and name: " + theTxnItem.itemID + " - " + theTxnItem.name + " has been fully removed from your order.",
                            "Successful Item Removal");

                        dgvOrder.ClearSelection();
                    }
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int selectedRowsCount = dgvOrder.SelectedRows.Count;

            //if number of selected rows is not one
            if (selectedRowsCount != 1)
            {
                MessageBox.Show("Must select one row from the order items data grid in order to update that's item's quantity in the order.",
                    "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                //clear all selected rows from the dgv
                dgvOrder.ClearSelection();
            }

            //else - 1 order item row is selected
            else
            {
                //get the current row
                DataGridViewRow dgvRow = dgvOrder.CurrentRow;

                //get the cell with the selected item's itemID in the order DGV
                int itemID = int.Parse(dgvRow.Cells[1].Value.ToString());

                //also get the cell with the selected item's current quantity in the order DGV
                int quantity = int.Parse(dgvRow.Cells[4].Value.ToString());

                //get an item object based on the itemID
                Item selectedItem = ItemAccessor.GetOneItem(itemID);

                //get an inventory object based on the itemID and site ID for the warehouse (2)
                Inventory warehouseInventoryItem = InventoryAccessor.GetOneInventoryItem(2, itemID);

                //want to send the 3 objs to the add/edit order item form
                AddEditOrderItem frmAddEditOrderItem = new AddEditOrderItem(employee, selectedItem,
                    warehouseInventoryItem, quantity);

                //open the add/edit user form (modal)
                frmAddEditOrderItem.ShowDialog();
            }
        }
    }
}
