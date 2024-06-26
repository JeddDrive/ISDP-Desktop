﻿using JeddoreISDPDesktop.DAO_Classes;
using JeddoreISDPDesktop.Entity_Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace JeddoreISDPDesktop
{
    public partial class CreateLossReturn : Form
    {
        //class level/global variable for the employee object from the dashboard
        Employee employee = null;

        //global variable for list of items to be processed for loss or return
        List<Inventory> listItems = new List<Inventory>();

        public CreateLossReturn(Employee employeeLoggedIn)
        {
            InitializeComponent();
            employee = employeeLoggedIn;
        }

        private void CreateLossReturn_Load(object sender, EventArgs e)
        {
            //setting the tooltip for the help image
            toolTipHelp.SetToolTip(picHelp, "Click here for help.");

            //display the employee's username and location in this form
            lblUsername.Text = employee.username;
            lblLocation.Text = employee.siteName;
        }

        private void picHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This is the form for creating a loss or processing a return. You can select an inventory item from the data grid on this form, " +
                "then click the appropriate button for creating a loss or return for that item." +
            "\n\nClick on the 'refresh' button to load the inventory data grid for your site.", "Create Loss/Return Help"
        , MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CreateLossReturn_KeyDown(object sender, KeyEventArgs e)
        {
            //if the F1 key is pressed down
            if (e.KeyCode == Keys.F1)
            {
                MessageBox.Show("This is the form for creating a loss or processing a return. You can select an inventory item from the data grid on this form, " +
                "then click the appropriate button for creating a loss or return for that item." +
                "\n\nClick on the 'refresh' button to load the inventory data grid for your site.", "Create Loss/Return Help"
                , MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            //create a new bindingsource
            BindingSource bindingSource = new BindingSource();

            int siteID = 0;

            if (employee.siteID == 3)
            {
                siteID = 2;
            }

            else
            {
                siteID = employee.siteID;
            }

            //create datatable - getting all inventory for a site, returned as a datatable
            DataTable dt = InventoryAccessor.GetAllInventoryBySiteDataTable(siteID);

            //set the binding source's datasource to the datatable
            bindingSource.DataSource = dt;

            //set the dgv's datasource to the bindingSource
            dgvInventory.DataSource = bindingSource;

            //autoresize dgv columns
            dgvInventory.AutoResizeColumns();

            //display the binding nav
            bindingNavigator.Visible = true;

            //set the binding source of the binding nav to the binding source created
            bindingNavigator.BindingSource = bindingSource;

            //hiding the description and notes columns - for performance
            dgvInventory.Columns["description"].Visible = false;
            dgvInventory.Columns["notes"].Visible = false;

            //change the header text of these columns
            dgvInventory.Columns["itemID"].HeaderText = "Item ID";
            dgvInventory.Columns["name"].HeaderText = "Name";
            //dgvItems.Columns["description"].HeaderText = "Description";
            dgvInventory.Columns["siteID"].HeaderText = "Site ID";
            dgvInventory.Columns["siteName"].HeaderText = "Site Name";
            dgvInventory.Columns["quantity"].HeaderText = "Quantity";
            dgvInventory.Columns["itemLocation"].HeaderText = "Item Location";
            dgvInventory.Columns["reorderThreshold"].HeaderText = "Reorder Threshold";
            dgvInventory.Columns["optimumThreshold"].HeaderText = "Optimum Threshold";
            dgvInventory.Columns["category"].HeaderText = "Category";
            dgvInventory.Columns["retailPrice"].HeaderText = "Retail Price";
            //dgvInventory.Columns["notes"].HeaderText = "Notes";

            dgvInventory.Refresh();

            //get the employee's user permissions
            UserPermission employeeUserPermissions = UserPermissionAccessor.GetOneEmployeeUserPermissions(employee.employeeID);

            //enable the search txtbox
            txtSearchInventory.Enabled = true;

            //enable both comboboxes
            cboCategories.Enabled = true;
            cboItems.Enabled = true;

            //enable the add to list btn
            btnAddToList.Enabled = true;

            //enable the clear list btn
            btnClearList.Enabled = true;

            //enable both radiobuttons
            radLoss.Enabled = true;
            radReturn.Enabled = true;

            //check the loss radiobutton by default
            radLoss.Checked = true;

            //enable the nud
            nudQuantity.Enabled = true;

            //check the list for CREATELOSS
            if (employeeUserPermissions.permissionIDList.Contains("CREATELOSS"))
            {
                btnCreateLoss.Enabled = true;
            }

            //check the list for PROCESSRETURN
            if (employeeUserPermissions.permissionIDList.Contains("PROCESSRETURN"))
            {
                btnProcessReturn.Enabled = true;
            }

            //adding all items option to the categories combo box
            cboCategories.Items.Add("All Items");

            //getting a list of all distinct categories
            List<string> categoriesList = ItemAccessor.GetAllCategoriesList();

            foreach (string category in categoriesList)
            {
                //add each category to the combobox
                cboCategories.Items.Add(category);
            }
        }

        private void txtSearchInventory_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //want to clear DGV row selection to prevent DGV errors/program from crashing
                //each time the text is changed and if the user clicks on a CRUD btn for example
                dgvInventory.ClearSelection();

                //converting the search text to all lower case
                string theSearchText = txtSearchInventory.Text.ToLower();

                CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[dgvInventory.DataSource];

                foreach (DataGridViewRow row in dgvInventory.Rows)
                {
                    //get the cell values for the following columns
                    var nameCellValue = row.Cells["name"].Value;
                    var categoryCellValue = row.Cells["category"].Value;
                    var itemIDCellValue = row.Cells["itemID"].Value;

                    //if txtbox is empty, then just show all the rows and continue
                    if (txtSearchInventory.Text.Equals(""))
                    {
                        row.Visible = true;
                        continue;
                    }

                    //if - name cell converted to lower case contains the txtbox text
                    if (nameCellValue != null && nameCellValue.ToString().ToLower().Contains(theSearchText))
                    {
                        row.Visible = true;
                    }

                    //else if - category cell converted to lower case contains the txtbox text
                    else if (categoryCellValue != null && categoryCellValue.ToString().ToLower().Contains(theSearchText))
                    {
                        row.Visible = true;
                    }

                    //else if - item ID cell converted to lower case contains the txtbox text
                    else if (itemIDCellValue != null && itemIDCellValue.ToString().ToLower().Contains(theSearchText))
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

        private void cboCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            int siteID = 0;

            if (employee.siteID == 3)
            {
                siteID = 2;
            }

            else
            {
                siteID = employee.siteID;
            }

            //if the first option is selected - display all items regardless of category
            if (cboCategories.SelectedIndex == 0)
            {
                //create a new bindingsource
                BindingSource bindingSource = new BindingSource();

                //create datatable - getting all inventory for a site, returned as a datatable
                DataTable dt = InventoryAccessor.GetAllInventoryBySiteDataTable(siteID);

                //set the binding source's datasource to the datatable
                bindingSource.DataSource = dt;

                //set the dgv's datasource to the bindingSource
                dgvInventory.DataSource = bindingSource;

                //autoresize dgv columns
                dgvInventory.AutoResizeColumns();

                //display the binding nav
                bindingNavigator.Visible = true;

                //set the binding source of the binding nav to the binding source created
                bindingNavigator.BindingSource = bindingSource;

                //hiding the description and notes columns - for performance
                dgvInventory.Columns["description"].Visible = false;
                dgvInventory.Columns["notes"].Visible = false;

                //change the header text of these columns
                dgvInventory.Columns["itemID"].HeaderText = "Item ID";
                dgvInventory.Columns["name"].HeaderText = "Name";
                //dgvItems.Columns["description"].HeaderText = "Description";
                dgvInventory.Columns["siteID"].HeaderText = "Site ID";
                dgvInventory.Columns["siteName"].HeaderText = "Site Name";
                dgvInventory.Columns["quantity"].HeaderText = "Quantity";
                dgvInventory.Columns["itemLocation"].HeaderText = "Item Location";
                dgvInventory.Columns["reorderThreshold"].HeaderText = "Reorder Threshold";
                dgvInventory.Columns["optimumThreshold"].HeaderText = "Optimum Threshold";
                dgvInventory.Columns["category"].HeaderText = "Category";
                dgvInventory.Columns["retailPrice"].HeaderText = "Retail Price";
                //dgvInventory.Columns["notes"].HeaderText = "Notes";

                dgvInventory.Refresh();
            }

            //else if - a specific category is chosen
            else if (cboCategories.SelectedIndex > 0)
            {
                //create a new bindingsource
                BindingSource bindingSource = new BindingSource();

                //create datatable - getting all inventory for a site, returned as a datatable
                DataTable dt = InventoryAccessor.GetAllInventoryBySiteAndCategoryDataTable(siteID, cboCategories.Text);

                //set the binding source's datasource to the datatable
                bindingSource.DataSource = dt;

                //set the dgv's datasource to the bindingSource
                dgvInventory.DataSource = bindingSource;

                //autoresize dgv columns
                dgvInventory.AutoResizeColumns();

                //display the binding nav
                bindingNavigator.Visible = true;

                //set the binding source of the binding nav to the binding source created
                bindingNavigator.BindingSource = bindingSource;

                //hiding the description and notes columns - for performance
                dgvInventory.Columns["description"].Visible = false;
                dgvInventory.Columns["notes"].Visible = false;

                //change the header text of these columns
                dgvInventory.Columns["itemID"].HeaderText = "Item ID";
                dgvInventory.Columns["name"].HeaderText = "Name";
                //dgvItems.Columns["description"].HeaderText = "Description";
                dgvInventory.Columns["siteID"].HeaderText = "Site ID";
                dgvInventory.Columns["siteName"].HeaderText = "Site Name";
                dgvInventory.Columns["quantity"].HeaderText = "Quantity";
                dgvInventory.Columns["itemLocation"].HeaderText = "Item Location";
                dgvInventory.Columns["reorderThreshold"].HeaderText = "Reorder Threshold";
                dgvInventory.Columns["optimumThreshold"].HeaderText = "Optimum Threshold";
                dgvInventory.Columns["category"].HeaderText = "Category";
                dgvInventory.Columns["retailPrice"].HeaderText = "Retail Price";
                //dgvInventory.Columns["notes"].HeaderText = "Notes";

                dgvInventory.Refresh();

            }
        }

        private void btnCreateLoss_Click(object sender, EventArgs e)
        {
            //if the wrong radiobutton is checked
            if (!radLoss.Checked)
            {
                MessageBox.Show("Must select the Loss radiobutton towards the bottom of this form when creating a loss.",
                "Create Loss Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //clear all selected rows from the dgv
                dgvInventory.ClearSelection();

                return;
            }

            //if the list doesn't contain any items
            if (listItems.Count < 1)
            {
                MessageBox.Show("The list of items for a loss must contain at least one inventory item in order for a loss to be properly created.",
                "Create Loss Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //clear all selected rows from the dgv
                dgvInventory.ClearSelection();

                return;
            }

            //want to send the employee obj to the create loss form - for the employee logged in
            //and send in the inventory item list
            ConfirmLoss frmConfirmLoss = new ConfirmLoss(employee, listItems);

            //open the form (modal)
            frmConfirmLoss.ShowDialog();
        }

        private void dgvInventory_SelectionChanged(object sender, EventArgs e)
        {
            //get the current dgv row
            DataGridViewRow dgvRow = dgvInventory.CurrentRow;

            //get the cell with the selected inventory's quantity
            int quantity = int.Parse(dgvRow.Cells[6].Value.ToString());

            //if quantity of the inventory is 0 then
            if (quantity <= 0 && radLoss.Checked)
            {
                //nudQuantity.Value = 0m;
                nudQuantity.Minimum = 0m;
                nudQuantity.Maximum = 0m;
            }

            //else if - quantity isn't zero
            else if (quantity > 0 && radLoss.Checked)
            {
                nudQuantity.Maximum = (decimal)quantity;
                nudQuantity.Minimum = 1m;
                nudQuantity.Value = 1m;
            }

            //else if
            else if (radReturn.Checked)
            {
                nudQuantity.Minimum = 1m;
                nudQuantity.Maximum = 100m;
            }
        }

        private void btnAddToList_Click(object sender, EventArgs e)
        {
            int selectedRowsCount = dgvInventory.SelectedRows.Count;

            //if number of selected rows is not one
            if (selectedRowsCount != 1)
            {
                MessageBox.Show("Must select one row from the data grid in order to add that inventory item to your loss or return list.",
                    "Add to Loss/Return List Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //clear all selected rows from the dgv
                dgvInventory.ClearSelection();
            }

            //else - 1 item row is selected
            else
            {
                if (nudQuantity.Value > 0 && radLoss.Checked)
                {
                    //get the current row
                    DataGridViewRow dgvRow = dgvInventory.CurrentRow;

                    //get the cell with the selected inventory's itemID
                    int itemID = int.Parse(dgvRow.Cells[0].Value.ToString());

                    //also get the cell with the siteID
                    int siteID = int.Parse(dgvRow.Cells[4].Value.ToString());

                    //can now get the item to edit with just the item ID (primary key)
                    Inventory selectedInventory = InventoryAccessor.GetOneInventoryItem(siteID, itemID);

                    selectedInventory.quantity = (int)nudQuantity.Value;

                    //if at least 1 inventory item in the list
                    if (listItems.Count > 0)
                    {

                        //foreach loop
                        foreach (Inventory inventoryItem in listItems)
                        {
                            if (inventoryItem.itemID == selectedInventory.itemID)
                            {
                                MessageBox.Show("Item has already been added to the loss/return list. Cannot add item again.",
                                    "Unable to Add Item Twice", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                return;
                            }
                        }
                    }

                    //add the inventory item to the global list
                    listItems.Add(selectedInventory);

                    //add the item to the combobox
                    cboItems.Items.Add(selectedInventory.itemID + " - " + selectedInventory.name + " - x" + selectedInventory.quantity);
                }

                else if (radReturn.Checked)
                {
                    //get the current row
                    DataGridViewRow dgvRow = dgvInventory.CurrentRow;

                    //get the cell with the selected inventory's itemID
                    int itemID = int.Parse(dgvRow.Cells[0].Value.ToString());

                    //also get the cell with the siteID
                    int siteID = int.Parse(dgvRow.Cells[4].Value.ToString());

                    //can now get the item to edit with just the item ID (primary key)
                    Inventory selectedInventory = InventoryAccessor.GetOneInventoryItem(siteID, itemID);

                    selectedInventory.quantity = (int)nudQuantity.Value;

                    //if at least 1 inventory item in the list
                    if (listItems.Count > 0)
                    {

                        //foreach loop
                        foreach (Inventory inventoryItem in listItems)
                        {
                            if (inventoryItem.itemID == selectedInventory.itemID)
                            {
                                MessageBox.Show("Item has already been added to the loss/return list. Cannot add item again.",
                                    "Unable to Add Item Twice", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                return;
                            }
                        }
                    }

                    //add the inventory item to the global list
                    listItems.Add(selectedInventory);

                    //add the item to the combobox
                    cboItems.Items.Add(selectedInventory.itemID + " - " + selectedInventory.name + " - x" + selectedInventory.quantity);
                }

                //else
                else
                {
                    MessageBox.Show("Must select an inventory item from the data grid that has at least a quantity of 1 to add it to the list for a loss.",
                   "Add to Loss List Quantity Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //clear all selected rows from the dgv
                    dgvInventory.ClearSelection();
                }
            }
        }

        private void radLoss_CheckedChanged(object sender, EventArgs e)
        {
            //clear the list and combobox
            listItems.Clear();
            cboItems.Items.Clear();

            //get the current dgv row
            DataGridViewRow dgvRow = dgvInventory.CurrentRow;

            //get the cell with the selected inventory's quantity
            int quantity = int.Parse(dgvRow.Cells[6].Value.ToString());

            //if quantity of the inventory is 0 then
            if (quantity <= 0)
            {
                //nudQuantity.Value = 0m;
                nudQuantity.Minimum = 0m;
                nudQuantity.Maximum = 0m;
            }

            //else - quantity isn't zero
            else
            {
                nudQuantity.Maximum = (decimal)quantity;
                nudQuantity.Minimum = 1m;
                nudQuantity.Value = 1m;
            }

        }

        private void radReturn_CheckedChanged(object sender, EventArgs e)
        {
            //clear the list and combobox
            listItems.Clear();
            cboItems.Items.Clear();

            //set the nud min and max to this
            nudQuantity.Minimum = 1m;
            nudQuantity.Maximum = 100m;
        }

        private void btnProcessReturn_Click(object sender, EventArgs e)
        {
            //if the wrong radiobutton is checked
            if (!radReturn.Checked)
            {
                MessageBox.Show("Must select the Return radiobutton towards the bottom of this form when creating and processing a return.",
                "Process Return Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //clear all selected rows from the dgv
                dgvInventory.ClearSelection();

                return;
            }

            //if the list doesn't contain any items
            if (listItems.Count < 1)
            {
                MessageBox.Show("The list of items for a return must contain at least one inventory item in order for a return to be properly created and processed.",
                "Process Return Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //clear all selected rows from the dgv
                dgvInventory.ClearSelection();

                return;
            }

            //want to send the employee obj to the process return form - for the employee logged in
            //and send in the inventory item list
            ConfirmReturn frmConfirmReturn = new ConfirmReturn(employee, listItems);

            //open the form (modal)
            frmConfirmReturn.ShowDialog();
        }

        private void btnClearList_Click(object sender, EventArgs e)
        {
            //if at least one item has been added to the list
            if (listItems.Count > 0)
            {
                //clear the items list and combobox
                listItems.Clear();
                cboItems.Items.Clear();

                MessageBox.Show("The list of inventory items has been successfully cleared.", "List Cleared");
            }

            else
            {
                MessageBox.Show("Unable to clear the list of inventory items since it currently has zero items.", "List Not Cleared",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
