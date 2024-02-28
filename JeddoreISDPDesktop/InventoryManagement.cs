using JeddoreISDPDesktop.DAO_Classes;
using JeddoreISDPDesktop.Entity_Classes;
using System;
using System.Data;
using System.Windows.Forms;

namespace JeddoreISDPDesktop
{
    public partial class InventoryManagement : Form
    {
        //class level/global variable for the employee object from the dashboard
        Employee employee = null;

        public InventoryManagement(Employee employeeLoggedIn)
        {
            InitializeComponent();
            employee = employeeLoggedIn;
        }

        private void InventoryManagement_Load(object sender, EventArgs e)
        {
            //setting the tooltip for the help image
            toolTipHelp.SetToolTip(picHelp, "Click here for help.");

            //display the employee's username and location in this form
            lblUsername.Text = employee.username;
            lblLocation.Text = employee.siteName;
        }

        private void picHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This is the inventory management page. You can read and edit inventory items from here." +
            "\n\nClick on the 'refresh' button to load the inventory data grid for your site.", "Inventory Management Help"
            , MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //close this form after 20 minutes
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void InventoryManagement_KeyDown(object sender, KeyEventArgs e)
        {
            //if the F1 key is pressed down
            if (e.KeyCode == Keys.F1)
            {
                MessageBox.Show("This is the inventory management page. You can read and edit inventory items from here." +
                "\n\nClick on the 'refresh' button to load the inventory data grid for your site.", "Inventory Management Help"
                 , MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            //create a new bindingsource
            BindingSource bindingSource = new BindingSource();

            //create datatable - getting all inventory for a site, returned as a datatable
            DataTable dt = InventoryAccessor.GetAllInventoryBySiteDataTable(employee.siteID);

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
            dgvInventory.Columns["quantity"].HeaderText = "Quantity";
            dgvInventory.Columns["itemLocation"].HeaderText = "Item Location";
            dgvInventory.Columns["reorderThreshold"].HeaderText = "Reorder Threshold";
            dgvInventory.Columns["optimumThreshold"].HeaderText = "Optimum Threshold";
            //dgvInventory.Columns["notes"].HeaderText = "Notes";

            dgvInventory.Refresh();

            //enable the search txtbox
            txtSearchInventory.Enabled = true;
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
            int selectedRowsCount = dgvInventory.SelectedRows.Count;

            //if number of selected rows is not one
            if (selectedRowsCount != 1)
            {
                MessageBox.Show("Must select one row from the data grid in order to edit your selected inventory item.",
                    "Edit Inventory Item Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                //clear all selected rows from the dgv
                dgvInventory.ClearSelection();
            }

            //else - 1 item row is selected
            else
            {
                //get the current row
                DataGridViewRow dgvRow = dgvInventory.CurrentRow;

                //get the cell with the selected inventory's itemID
                int itemID = int.Parse(dgvRow.Cells[0].Value.ToString());

                //also get the cell with the siteID
                int siteID = int.Parse(dgvRow.Cells[3].Value.ToString());

                //can now get the item to edit with just the item ID (primary key)
                Inventory selectedInventory = InventoryAccessor.GetOneInventoryItem(siteID, itemID);

                //want to send the employee obj to the add user form - for the employee logged in
                //and send in the selected item
                EditInventory frmEditInventory = new EditInventory(employee, selectedInventory);

                //open the add/edit user form (modal)
                frmEditInventory.ShowDialog();
            }
        }
    }
}
