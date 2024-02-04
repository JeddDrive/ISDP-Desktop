using JeddoreISDPDesktop.DAO_Classes;
using JeddoreISDPDesktop.Entity_Classes;
using System;
using System.Data;
using System.Windows.Forms;

namespace JeddoreISDPDesktop
{
    public partial class UserPermissions : Form
    {
        //class level/global variable for the employee object from the dashboard
        Employee employee = null;

        public UserPermissions(Employee employeeLoggedIn)
        {
            InitializeComponent();
            employee = employeeLoggedIn;
        }

        private void UserPermissions_Load(object sender, EventArgs e)
        {
            //setting the tooltip for the help image
            toolTipHelp.SetToolTip(picHelp, "Click here for help.");

            //display the employee's username and location in this form
            lblUsername.Text = employee.username;
            lblLocation.Text = employee.siteName;
        }

        private void picHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This is the user permissions page. You can add and remove individual user permissions from here." +
                "\n\nClick on the 'refresh' button to load both data grids.", "User Permissions Help"
                , MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            //create a new bindingsource
            BindingSource bindingSource = new BindingSource();

            //create datatable - getting all employees, returned as a datatable
            DataTable dt = EmployeeAccessor.GetAllEmployeesDataTable();

            //set the binding source's datasource to the datatable
            bindingSource.DataSource = dt;

            //set the dgv's datasource to the bindingSource
            dgvUsers.DataSource = bindingSource;

            //autoresize dgv columns
            dgvUsers.AutoResizeColumns();

            //display the binding nav
            bindingNavigator1.Visible = true;

            //set the binding source of the binding nav to the binding source created
            bindingNavigator1.BindingSource = bindingSource;

            //hide these columns in the DGV
            dgvUsers.Columns["password"].Visible = false;
            dgvUsers.Columns["loginAttempts"].Visible = false;
            dgvUsers.Columns["madeFirstLogin"].Visible = false;
            dgvUsers.Columns["positionID"].Visible = false;
            dgvUsers.Columns["siteID"].Visible = false;
            dgvUsers.Columns["username"].Visible = false;
            dgvUsers.Columns["active"].Visible = false;
            dgvUsers.Columns["locked"].Visible = false;
            dgvUsers.Columns["notes"].Visible = false;
            dgvUsers.Columns["email"].Visible = false;

            //change the header text of these columns
            dgvUsers.Columns["firstName"].HeaderText = "First Name";
            dgvUsers.Columns["lastName"].HeaderText = "Last Name";
            dgvUsers.Columns["employeeID"].HeaderText = "Employee ID";
            dgvUsers.Columns["name"].HeaderText = "Location";
            dgvUsers.Columns["permissionLevel"].HeaderText = "Position";

            dgvUsers.Refresh();

            //and enable the two textboxes for search
            txtSearchUsers.Enabled = true;
            txtSearchPermissions.Enabled = true;
        }

        private void txtSearchUsers_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[dgvUsers.DataSource];

                foreach (DataGridViewRow row in dgvUsers.Rows)
                {
                    //get the cell values for the following columns
                    var firstNameCellValue = row.Cells["firstName"].Value;
                    var lastNameCellValue = row.Cells["lastName"].Value;
                    var locationCellValue = row.Cells["name"].Value;
                    var positionCellValue = row.Cells["permissionLevel"].Value;
                    var employeeIDCellValue = row.Cells["employeeID"].Value;

                    //if txtbox is empty, then just show all the rows and continue
                    if (txtSearchUsers.Text.Equals(""))
                    {
                        row.Visible = true;
                        continue;
                    }

                    //if - first name cell converted to lower case contains the txtbox text
                    if (firstNameCellValue != null && firstNameCellValue.ToString().ToLower().Contains(txtSearchUsers.Text))
                    {
                        row.Visible = true;
                    }

                    //else if - last name cell converted to lower case contains the txtbox text
                    else if (lastNameCellValue != null && lastNameCellValue.ToString().ToLower().Contains(txtSearchUsers.Text))
                    {
                        row.Visible = true;
                    }

                    //else if - location name cell converted to lower case contains the txtbox text
                    else if (locationCellValue != null && locationCellValue.ToString().ToLower().Contains(txtSearchUsers.Text))
                    {
                        row.Visible = true;
                    }

                    //else if - position cell converted to lower case contains the txtbox text
                    else if (positionCellValue != null && positionCellValue.ToString().ToLower().Contains(txtSearchUsers.Text))
                    {
                        row.Visible = true;
                    }

                    //else if - employee ID cell converted to lower case contains the txtbox text
                    else if (employeeIDCellValue != null && employeeIDCellValue.ToString().ToLower().Contains(txtSearchUsers.Text))
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

        private void dgvUsers_SelectionChanged(object sender, EventArgs e)
        {
            //get the current row
            DataGridViewRow dgvRow = dgvUsers.CurrentRow;

            //get the cell with the employee ID
            string employeeID = dgvRow.Cells[0].Value.ToString();

            DataTable dt = UserPermissionAccessor.GetOneEmployeeUserPermissionsDataTable(int.Parse(employeeID));

            //create a new bindingsource
            BindingSource bindingSource = new BindingSource();

            //set the binding source's datasource to the datatable
            bindingSource.DataSource = dt;

            //set the dgv's datasource to the bindingSource
            dgvUserPermissions.DataSource = bindingSource;

            //autoresize dgv columns
            dgvUserPermissions.AutoResizeColumns();

            //display the binding nav
            bindingNavigator2.Visible = true;

            //set the binding source of the binding nav to the binding source created
            bindingNavigator2.BindingSource = bindingSource;

            //hide the employeeID column
            dgvUserPermissions.Columns["employeeID"].Visible = false;

            //change the header text of these columns
            dgvUserPermissions.Columns["permissionID"].HeaderText = "Permission";
            dgvUserPermissions.Columns["hasPermission"].HeaderText = "Has Permission";

            dgvUserPermissions.Refresh();

        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            int selectedRowsCount = dgvUserPermissions.SelectedRows.Count;

            //if number of selected rows is not one in dgvUserPermissions
            if (selectedRowsCount != 1)
            {
                MessageBox.Show("Must select one row from the data grid in order to add or remove that user permission.",
                    "Multiple Rows Selected Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                //clear all selected rows from the dgv
                dgvUserPermissions.ClearSelection();
            }

            //else - is 1 row selected
            else
            {
                //get the current row from dgvUserPermissions
                DataGridViewRow dgvUserPermissionsRow = dgvUserPermissions.CurrentRow;

                //get the current row from dgvUsers
                DataGridViewRow dgvUsersRow = dgvUsers.CurrentRow;

                //get the cell with the employee ID from dgvUsers
                string employeeID = dgvUsersRow.Cells[0].Value.ToString();

                //get the cells with the permission ID and hasPermission from dgvUserPermissions
                string permissionID = dgvUserPermissionsRow.Cells[1].Value.ToString();
                bool hasPermission = Convert.ToBoolean(dgvUserPermissionsRow.Cells[2].Value);

                //if hasPermission is true, then want to remove that permission
                if (hasPermission)
                {
                    DialogResult btnValueReturned = MessageBox.Show("Confirm you wish to remove permission " +
                        permissionID + " for employee " + employeeID + "?", "Confirm User Permission Removal",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    //if - user selects the yes btn
                    if (btnValueReturned == DialogResult.Yes)
                    {
                        bool goodUpdate = UserPermissionAccessor.RemoveUserPermission(int.Parse(employeeID), permissionID);

                        //if successful
                        if (goodUpdate)
                        {
                            MessageBox.Show("User permission has been removed from the system.", "Successful User Permission Removal");

                            dgvUserPermissions.Refresh();
                        }
                    }
                }

                //else - want to add that permission
                else
                {
                    DialogResult btnValueReturned = MessageBox.Show("Confirm you wish to add permission " +
                        permissionID + " for employee " + employeeID + "?", "Confirm User Permission Addition",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    //if - user selects the yes btn
                    if (btnValueReturned == DialogResult.Yes)
                    {
                        bool goodUpdate = UserPermissionAccessor.AddUserPermission(int.Parse(employeeID), permissionID);

                        //if successful
                        if (goodUpdate)
                        {
                            MessageBox.Show("User permission has been added from the system.", "Successful User Permission Addition");

                            dgvUserPermissions.Refresh();
                        }
                    }
                }

                //reset the text in the two textboxes
                txtSearchUsers.ResetText();
                txtSearchPermissions.ResetText();
            }
        }

        private void txtSearchPermissions_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[dgvUserPermissions.DataSource];

                foreach (DataGridViewRow row in dgvUserPermissions.Rows)
                {
                    //get the cell values from just the one column
                    var permissionIDCellValue = row.Cells["permissionID"].Value;

                    //if txtbox is empty, then just show all the rows and continue
                    if (txtSearchPermissions.Text.Equals(""))
                    {
                        row.Visible = true;
                        continue;
                    }

                    //if - first name cell converted to lower case contains the txtbox text
                    if (permissionIDCellValue != null && permissionIDCellValue.ToString().ToLower().Contains(txtSearchPermissions.Text))
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

        //timer should close this form after 20 minutes
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UserPermissions_KeyDown(object sender, KeyEventArgs e)
        {
            //if the F1 key is pressed down
            if (e.KeyCode == Keys.F1)
            {
                MessageBox.Show("This is the user permissions page. You can add and remove individual user permissions from here." +
                "\n\nClick on the 'refresh' button to load both data grids.", "User Permissions Help"
                , MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
