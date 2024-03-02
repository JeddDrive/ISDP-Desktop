﻿using JeddoreISDPDesktop.DAO_Classes;
using JeddoreISDPDesktop.Entity_Classes;
using System;
using System.Data;
using System.Windows.Forms;

namespace JeddoreISDPDesktop
{
    public partial class ItemManagement : Form
    {
        //class level/global variable for the employee object from the dashboard
        Employee employee = null;

        public ItemManagement(Employee employeeLoggedIn)
        {
            InitializeComponent();
            employee = employeeLoggedIn;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void picHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This is the item management page. You can read and edit items from here." +
                "\n\nClick on the 'refresh' button to load the items data grid.", "Item Management Help"
                , MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ItemManagement_Load(object sender, EventArgs e)
        {
            //setting the tooltip for the help image
            toolTipHelp.SetToolTip(picHelp, "Click here for help.");

            //display the employee's username and location in this form
            lblUsername.Text = employee.username;
            lblLocation.Text = employee.siteName;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            //create a new bindingsource
            BindingSource bindingSource = new BindingSource();

            //create datatable - getting all items, returned as a datatable
            DataTable dt = ItemAccessor.GetAllItemsDataTable();

            //set the binding source's datasource to the datatable
            bindingSource.DataSource = dt;

            //set the dgv's datasource to the bindingSource
            dgvItems.DataSource = bindingSource;

            //autoresize dgv columns
            dgvItems.AutoResizeColumns();

            //display the binding nav
            bindingNavigator.Visible = true;

            //set the binding source of the binding nav to the binding source created
            bindingNavigator.BindingSource = bindingSource;

            //hiding the description and notes columns - for performance
            dgvItems.Columns["description"].Visible = false;
            dgvItems.Columns["notes"].Visible = false;

            //change the header text of these columns
            dgvItems.Columns["itemID"].HeaderText = "Item ID";
            dgvItems.Columns["name"].HeaderText = "Name";
            dgvItems.Columns["sku"].HeaderText = "SKU";
            //dgvItems.Columns["description"].HeaderText = "Description";
            dgvItems.Columns["category"].HeaderText = "Category";
            dgvItems.Columns["weight"].HeaderText = "Weight";
            dgvItems.Columns["caseSize"].HeaderText = "Case Size";
            dgvItems.Columns["costPrice"].HeaderText = "Cost Price";
            dgvItems.Columns["retailPrice"].HeaderText = "Retail Price";
            dgvItems.Columns["supplierID"].HeaderText = "Supplier ID";
            dgvItems.Columns["active"].HeaderText = "Active";
            //dgvItems.Columns["notes"].HeaderText = "Notes";
            dgvItems.Columns["imageFileLocation"].HeaderText = "Image Location";

            dgvItems.Refresh();

            //enable the search txtbox
            txtSearchItems.Enabled = true;
        }

        private void txtSearchItems_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //want to clear DGV row selection to prevent DGV errors/program from crashing
                //each time the text is changed and if the user clicks on a CRUD btn for example
                dgvItems.ClearSelection();

                //converting the search text to all lower case
                string theSearchText = txtSearchItems.Text.ToLower();

                CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[dgvItems.DataSource];

                foreach (DataGridViewRow row in dgvItems.Rows)
                {
                    //get the cell values for the following columns
                    var nameCellValue = row.Cells["name"].Value;
                    var categoryCellValue = row.Cells["category"].Value;
                    var itemIDCellValue = row.Cells["itemID"].Value;

                    //if txtbox is empty, then just show all the rows and continue
                    if (txtSearchItems.Text.Equals(""))
                    {
                        row.Visible = true;
                        continue;
                    }

                    //if - name cell converted to lower case contains the txtbox text
                    if (nameCellValue != null && nameCellValue.ToString().ToLower().Contains(theSearchText))
                    {
                        row.Visible = true;
                    }

                    //else if - category name cell converted to lower case contains the txtbox text
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

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int selectedRowsCount = dgvItems.SelectedRows.Count;

            //if number of selected rows is not one
            if (selectedRowsCount != 1)
            {
                MessageBox.Show("Must select one row from the data grid in order to edit your selected item.",
                    "Edit Item Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //clear all selected rows from the dgv
                dgvItems.ClearSelection();
            }

            //else - 1 item row is selected
            else
            {
                //get the current row
                DataGridViewRow dgvRow = dgvItems.CurrentRow;

                //get the cell with the selected item's itemID
                int itemID = int.Parse(dgvRow.Cells[0].Value.ToString());

                //can now get the item to edit with just the item ID (primary key)
                Item selectedItem = ItemAccessor.GetOneItem(itemID);

                //want to send the employee obj to the add user form - for the employee logged in
                //and send in the selected item
                EditItem frmEditItem = new EditItem(employee, selectedItem);

                //open the add/edit user form (modal)
                frmEditItem.ShowDialog();
            }
        }

        //timer should close this form after 20 minutes
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ItemManagement_KeyDown(object sender, KeyEventArgs e)
        {
            //if the F1 key is pressed down
            if (e.KeyCode == Keys.F1)
            {
                MessageBox.Show("This is the item management page. You can read and edit items from here." +
                "\n\nClick on the 'refresh' button to load the items data grid.", "Item Management Help"
                , MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
