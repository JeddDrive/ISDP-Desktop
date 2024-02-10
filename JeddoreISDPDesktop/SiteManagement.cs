using JeddoreISDPDesktop.DAO_Classes;
using JeddoreISDPDesktop.Entity_Classes;
using System;
using System.Data;
using System.Windows.Forms;

namespace JeddoreISDPDesktop
{
    public partial class SiteManagement : Form
    {
        //class level/global variable for the employee object from the dashboard
        Employee employee = null;

        public SiteManagement(Employee employeeLoggedIn)
        {
            InitializeComponent();
            employee = employeeLoggedIn;
        }

        private void SiteManagement_Load(object sender, EventArgs e)
        {
            //setting the tooltip for the help image
            toolTipHelp.SetToolTip(picHelp, "Click here for help.");

            //display the employee's username and location in this form
            lblUsername.Text = employee.username;
            lblLocation.Text = employee.siteName;

            //get the employee's user permissions
            UserPermission employeeUserPermissions = UserPermissionAccessor.GetOneEmployeeUserPermissions(employee.employeeID);

            //add and edit site btns should be disabled on form load
            //below - are enabling those btns based on if permission IDs are present in the list or not
            //checking the list for ADDSITE
            if (employeeUserPermissions.permissionIDList.Contains("ADDSITE"))
            {
                btnAddSite.Enabled = true;
            }

            //check the list for EDITSITE
            if (employeeUserPermissions.permissionIDList.Contains("EDITSITE"))
            {
                btnEditSite.Enabled = true;
            }
        }

        //timer to close this form after 20 minutes
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void picHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This is the site management page. You can read, add, and edit sites from here." +
            "\n\nClick on the 'refresh' button to load the sites data grid.", "Site Management Help"
            , MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void SiteManagement_KeyDown(object sender, KeyEventArgs e)
        {
            //if F1 key is pressed down
            if (e.KeyCode == Keys.F1)
            {
                MessageBox.Show("This is the site management page. You can read, add, and edit sites from here." +
                "\n\nClick on the 'refresh' button to load the sites data grid.", "Site Management Help"
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

            //create datatable - getting all sites, returned as a datatable
            DataTable dt = SiteAccessor.GetAllSitesDataTable();

            //set the binding source's datasource to the datatable
            bindingSource.DataSource = dt;

            //set the dgv's datasource to the bindingSource
            dgvSites.DataSource = bindingSource;

            //autoresize dgv columns
            dgvSites.AutoResizeColumns();

            //display the binding nav
            bindingNavigator.Visible = true;

            //set the binding source of the binding nav to the binding source created
            bindingNavigator.BindingSource = bindingSource;

            //change the header text of these columns
            dgvSites.Columns["siteID"].HeaderText = "Site ID";
            dgvSites.Columns["provinceID"].HeaderText = "Province ID";
            dgvSites.Columns["name"].HeaderText = "Name";
            dgvSites.Columns["address"].HeaderText = "Address";
            dgvSites.Columns["address2"].HeaderText = "Address 2";
            dgvSites.Columns["city"].HeaderText = "City";
            dgvSites.Columns["country"].HeaderText = "Country";
            dgvSites.Columns["postalCode"].HeaderText = "Postal Code";
            dgvSites.Columns["phone"].HeaderText = "Phone";
            dgvSites.Columns["dayOfWeek"].HeaderText = "Day of Week";
            dgvSites.Columns["distanceFromWH"].HeaderText = "Distance from WH";
            dgvSites.Columns["notes"].HeaderText = "Notes";
            dgvSites.Columns["active"].HeaderText = "Active";

            dgvSites.Refresh();

            //enable the textbox for user search
            txtSearchSites.Enabled = true;
        }

        private void btnEditSite_Click(object sender, EventArgs e)
        {
            int selectedRowsCount = dgvSites.SelectedRows.Count;

            //if number of selected rows is not one
            if (selectedRowsCount != 1)
            {
                MessageBox.Show("Must select one row from the data grid in order to edit your selected site.",
                    "Edit Site Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                //clear all selected rows from the dgv
                dgvSites.ClearSelection();
            }

            //else - 1 site row is selected
            else
            {
                //get the current row
                DataGridViewRow dgvRow = dgvSites.CurrentRow;

                //get the cell with the selected site's site ID
                int siteID = int.Parse(dgvRow.Cells[0].Value.ToString());

                //now get the site to edit, based on the unique site ID
                Site siteSelected = SiteAccessor.GetOneSite(siteID);

                //want to send the site obj to the add/edit site form - also the employee logged in
                AddEditSite frmEditSite = new AddEditSite(employee, siteSelected);

                //update the form's text to be accurate - editing an user
                frmEditSite.Text = "Bullseye Inventory Management System - Edit Site";

                //open the add/edit user form (modal)
                frmEditSite.ShowDialog();
            }
        }

        private void txtSearchUsers_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //want to clear DGV row selection to prevent DGV errors/program from crashing
                //each time the text is changed and if the user clicks on a CRUD btn for example
                dgvSites.ClearSelection();

                CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[dgvSites.DataSource];

                foreach (DataGridViewRow row in dgvSites.Rows)
                {
                    //get the cell values for the following columns
                    var siteIDCellValue = row.Cells["siteID"].Value;
                    var nameCellValue = row.Cells["name"].Value;
                    var cityCellValue = row.Cells["city"].Value;
                    var addressCellValue = row.Cells["address"].Value;

                    //if txtbox is empty, then just show all the rows and continue
                    if (txtSearchSites.Text.Equals(""))
                    {
                        row.Visible = true;
                        continue;
                    }

                    //if - site ID converted to string contains the txtbox text
                    if (siteIDCellValue != null && siteIDCellValue.ToString().Contains(txtSearchSites.Text))
                    {
                        row.Visible = true;
                    }

                    //else if - name cell converted to lower case contains the txtbox text
                    else if (nameCellValue != null && nameCellValue.ToString().ToLower().Contains(txtSearchSites.Text))
                    {
                        row.Visible = true;
                    }

                    //else if - city cell...
                    else if (cityCellValue != null && cityCellValue.ToString().ToLower().Contains(txtSearchSites.Text))
                    {
                        row.Visible = true;
                    }

                    //else if - address cell...
                    else if (addressCellValue != null && addressCellValue.ToString().ToLower().Contains(txtSearchSites.Text))
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

        private void btnAddSite_Click(object sender, EventArgs e)
        {
            //want to send the employee obj to the add site form - for the employee logged in
            AddEditSite frmAddSite = new AddEditSite(employee);

            //update the form's text to be accurate - adding a site
            frmAddSite.Text = "Bullseye Inventory Management System - Add Site";

            //open the add/edit site form (modal)
            frmAddSite.ShowDialog();
        }
    }
}
