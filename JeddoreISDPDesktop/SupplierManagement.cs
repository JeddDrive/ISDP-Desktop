using JeddoreISDPDesktop.DAO_Classes;
using JeddoreISDPDesktop.Entity_Classes;
using System;
using System.Data;
using System.Windows.Forms;

namespace JeddoreISDPDesktop
{
    public partial class SupplierManagement : Form
    {
        //class level/global variable for the employee object from the dashboard
        Employee employee = null;

        public SupplierManagement(Employee employeeLoggedIn)
        {
            InitializeComponent();
            employee = employeeLoggedIn;
        }

        private void SupplierManagement_Load(object sender, EventArgs e)
        {
            //setting the tooltip for the help image
            toolTipHelp.SetToolTip(picHelp, "Click here for help.");

            //display the employee's username and location in this form
            lblUsername.Text = employee.username;
            lblLocation.Text = employee.siteName;

            //get the employee's user permissions
            UserPermission employeeUserPermissions = UserPermissionAccessor.GetOneEmployeeUserPermissions(employee.employeeID);

            //add and edit supplier btns should be disabled on form load
            //below - are enabling those btns based on if permission IDs are present in the list or not
            //checking the list for ADDSUPPLIER
            if (employeeUserPermissions.permissionIDList.Contains("ADDSUPPLIER"))
            {
                btnAddSupplier.Enabled = true;
            }

            //check the list for EDITSUPPLIER
            if (employeeUserPermissions.permissionIDList.Contains("EDITSUPPLIER"))
            {
                btnEditSupplier.Enabled = true;
            }
        }

        private void picHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This is the supplier management page. You can read, add, and edit suppliers from here." +
            "\n\nClick on the 'refresh' button to load the suppliers data grid.", "Supplier Management Help"
            , MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void SupplierManagement_KeyDown(object sender, KeyEventArgs e)
        {
            //if the F1 key is pressed down
            if (e.KeyCode == Keys.F1)
            {
                MessageBox.Show("This is the supplier management page. You can read, add, and edit suppliers from here." +
                "\n\nClick on the 'refresh' button to load the suppliers data grid.", "Supplier Management Help"
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

            //create datatable - getting all sites, returned as a datatable
            DataTable dt = SupplierAccessor.GetAllSuppliersDataTable();

            //set the binding source's datasource to the datatable
            bindingSource.DataSource = dt;

            //set the dgv's datasource to the bindingSource
            dgvSuppliers.DataSource = bindingSource;

            //autoresize dgv columns
            dgvSuppliers.AutoResizeColumns();

            //display the binding nav
            bindingNavigator.Visible = true;

            //set the binding source of the binding nav to the binding source created
            bindingNavigator.BindingSource = bindingSource;

            //change the header text of these columns
            dgvSuppliers.Columns["supplierID"].HeaderText = "Supplier ID";
            dgvSuppliers.Columns["name"].HeaderText = "Name";
            dgvSuppliers.Columns["address1"].HeaderText = "Address 1";
            dgvSuppliers.Columns["address2"].HeaderText = "Address 2";
            dgvSuppliers.Columns["province"].HeaderText = "Province";
            dgvSuppliers.Columns["city"].HeaderText = "City";
            dgvSuppliers.Columns["country"].HeaderText = "Country";
            dgvSuppliers.Columns["postalcode"].HeaderText = "Postal Code";
            dgvSuppliers.Columns["phone"].HeaderText = "Phone";
            dgvSuppliers.Columns["contact"].HeaderText = "Contact";
            dgvSuppliers.Columns["notes"].HeaderText = "Notes";
            dgvSuppliers.Columns["active"].HeaderText = "Active";

            dgvSuppliers.Refresh();

            //enable the textbox for user search
            txtSearchSuppliers.Enabled = true;
        }

        private void txtSearchSuppliers_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //want to clear DGV row selection to prevent DGV errors/program from crashing
                //each time the text is changed and if the user clicks on a CRUD btn for example
                dgvSuppliers.ClearSelection();

                //converting the search text to all lower case
                string theSearchText = txtSearchSuppliers.Text.ToLower();

                CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[dgvSuppliers.DataSource];

                foreach (DataGridViewRow row in dgvSuppliers.Rows)
                {
                    //get the cell values for the following columns
                    var supplierIDCellValue = row.Cells["supplierID"].Value;
                    var nameCellValue = row.Cells["name"].Value;
                    var cityCellValue = row.Cells["city"].Value;
                    var provinceCellValue = row.Cells["province"].Value;
                    var address1CellValue = row.Cells["address1"].Value;
                    var contactCellValue = row.Cells["contact"].Value;

                    //if txtbox is empty, then just show all the rows and continue
                    if (txtSearchSuppliers.Text.Equals(""))
                    {
                        row.Visible = true;
                        continue;
                    }

                    //if - site ID converted to string contains the txtbox text
                    if (supplierIDCellValue != null && supplierIDCellValue.ToString().Contains(theSearchText))
                    {
                        row.Visible = true;
                    }

                    //else if - name cell converted to lower case contains the txtbox text
                    else if (nameCellValue != null && nameCellValue.ToString().ToLower().Contains(theSearchText))
                    {
                        row.Visible = true;
                    }

                    //else if - city cell...
                    else if (cityCellValue != null && cityCellValue.ToString().ToLower().Contains(theSearchText))
                    {
                        row.Visible = true;
                    }

                    //else if - province cell...
                    else if (provinceCellValue != null && provinceCellValue.ToString().ToLower().Contains(theSearchText))
                    {
                        row.Visible = true;
                    }

                    //else if - address cell...
                    else if (address1CellValue != null && address1CellValue.ToString().ToLower().Contains(theSearchText))
                    {
                        row.Visible = true;
                    }

                    //else if - contact cell...
                    else if (contactCellValue != null && contactCellValue.ToString().ToLower().Contains(theSearchText))
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

        private void btnAddSupplier_Click(object sender, EventArgs e)
        {
            //want to send the employee obj to the add supplier form - for the employee logged in
            AddEditSupplier frmAddSupplier = new AddEditSupplier(employee);

            //update the form's text to be accurate - adding a supplier
            frmAddSupplier.Text = "Bullseye Inventory Management System - Add Supplier";

            //open the add/edit supplier form (modal)
            frmAddSupplier.ShowDialog();
        }

        private void btnEditSupplier_Click(object sender, EventArgs e)
        {
            int selectedRowsCount = dgvSuppliers.SelectedRows.Count;

            //if number of selected rows is not one
            if (selectedRowsCount != 1)
            {
                MessageBox.Show("Must select one row from the data grid in order to edit your selected supplier",
                    "Edit Supplier Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //clear all selected rows from the dgv
                dgvSuppliers.ClearSelection();
            }

            //else - 1 supplier row is selected
            else
            {
                //get the current row
                DataGridViewRow dgvRow = dgvSuppliers.CurrentRow;

                //get the cell with the selected site's site ID
                int supplierID = int.Parse(dgvRow.Cells[0].Value.ToString());

                //now get the supplier to edit, based on the unique supplier ID
                Supplier supplierSelected = SupplierAccessor.GetOneSupplier(supplierID);

                //want to send the supplier obj to the add/edit supplier form - also the employee logged in
                AddEditSupplier frmEditSupplier = new AddEditSupplier(employee, supplierSelected);

                //update the form's text to be accurate - editing a supplier
                frmEditSupplier.Text = "Bullseye Inventory Management System - Edit Supplier";

                //open the add/edit supplier form (modal)
                frmEditSupplier.ShowDialog();
            }
        }
    }
}
