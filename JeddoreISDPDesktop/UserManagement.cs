using JeddoreISDPDesktop.DAO_Classes;
using System;
using System.Data;
using System.Windows.Forms;

namespace JeddoreISDPDesktop.Entity_Classes
{
    public partial class UserManagement : Form
    {
        //class level/global variable for the employee object from the dashboard
        Employee employee = null;

        public UserManagement(Employee employeeLoggedIn)
        {
            InitializeComponent();
            employee = employeeLoggedIn;
        }

        private void UserManagement_Load(object sender, EventArgs e)
        {
            //setting the tooltip for the help image
            toolTipHelp.SetToolTip(picHelp, "Click here for help.");

            //display the employee's username and location in this form
            lblUsername.Text = employee.username;
            lblLocation.Text = employee.siteName;

            //get the employee's user permissions
            UserPermission employeeUserPermissions = UserPermissionAccessor.GetOneEmployeeUserPermissions(employee.employeeID);

            //add, edit, and delete user btns should be disabled on form load
            //below - are enabling those btns based on if permission IDs are present in the list or not
            //checking the list for ADDUSER
            if (employeeUserPermissions.permissionIDList.Contains("ADDUSER"))
            {
                btnAddUser.Enabled = true;
            }

            //check the list for EDITUSER
            if (employeeUserPermissions.permissionIDList.Contains("EDITUSER"))
            {
                btnEditUser.Enabled = true;
            }

            //check the list for DELETEUSER
            if (employeeUserPermissions.permissionIDList.Contains("DELETEUSER"))
            {
                btnDeleteUser.Enabled = true;
            }
        }

        private void picHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This is the user management page. You can read, add, edit, and delete users from here." +
                "\n\nClick on the 'refresh' button to load the users data grid.", "User Management Help"
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
            bindingNavigator.Visible = true;

            //set the binding source of the binding nav to the binding source created
            bindingNavigator.BindingSource = bindingSource;

            //hide these columns in the DGV
            dgvUsers.Columns["password"].Visible = false;
            dgvUsers.Columns["loginAttempts"].Visible = false;
            dgvUsers.Columns["madeFirstLogin"].Visible = false;

            //change the header text of these columns
            dgvUsers.Columns["firstName"].HeaderText = "First Name";
            dgvUsers.Columns["lastName"].HeaderText = "Last Name";
            dgvUsers.Columns["positionID"].HeaderText = "Position ID";
            dgvUsers.Columns["employeeID"].HeaderText = "Employee ID";
            dgvUsers.Columns["siteID"].HeaderText = "Site ID";
            dgvUsers.Columns["username"].HeaderText = "Username";
            dgvUsers.Columns["name"].HeaderText = "Location";
            dgvUsers.Columns["active"].HeaderText = "Active";
            dgvUsers.Columns["locked"].HeaderText = "Locked";
            dgvUsers.Columns["notes"].HeaderText = "Notes";
            dgvUsers.Columns["permissionLevel"].HeaderText = "Position";

            dgvUsers.Refresh();

            //enable the textbox for user search
            txtSearchUsers.Enabled = true;
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            int selectedRowsCount = dgvUsers.SelectedRows.Count;

            //if number of selected rows is not one
            if (selectedRowsCount != 1)
            {
                MessageBox.Show("Must select one row from the data grid in order to remove that selected user.",
                    "Remove User Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                //clear all selected rows from the dgv
                dgvUsers.ClearSelection();
            }

            //else - 1 row is selected
            else
            {
                //get the current row
                DataGridViewRow dgvRow = dgvUsers.CurrentRow;

                //get the cells with the employee ID, username and location
                string employeeID = dgvRow.Cells[0].Value.ToString();
                string username = dgvRow.Cells[9].Value.ToString();
                string location = dgvRow.Cells[13].Value.ToString();

                DialogResult btnValueReturned = MessageBox.Show("Confirm you wish to remove user from system?\n\n" +
                    "User: " + username + "\nLocation: " + location, "Confirm User Removal",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                //if - user selects the yes btn
                if (btnValueReturned == DialogResult.Yes)
                {
                    //attempt to update that employee to now be inactive
                    bool goodUpdate = EmployeeAccessor.UpdateEmployeeToInactive(int.Parse(employeeID));

                    //if successful
                    if (goodUpdate)
                    {
                        MessageBox.Show("User has been removed from the system.", "Successful User Removal");
                    }
                }
            }
        }

        private void btnEditUser_Click(object sender, EventArgs e)
        {
            int selectedRowsCount = dgvUsers.SelectedRows.Count;

            //if number of selected rows is not one
            if (selectedRowsCount != 1)
            {
                MessageBox.Show("Must select one row from the data grid in order to edit your selected user.",
                    "Edit User Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                //clear all selected rows from the dgv
                dgvUsers.ClearSelection();
            }

            //else - 1 employee row is selected
            else
            {
                //get the current row
                DataGridViewRow dgvRow = dgvUsers.CurrentRow;

                //get the cell with the selected employee's username
                string username = dgvRow.Cells[9].Value.ToString();

                //can now get the employee to edit with just the employee ID (primary key)
                Employee selectedEmployee = EmployeeAccessor.GetOneEmployee(username);

                //want to send the employee obj to the add user form - for the employee logged in
                AddEditUser frmEditUser = new AddEditUser(employee, selectedEmployee);

                //update the form's text to be accurate - editing an user
                frmEditUser.Text = "Bullseye Inventory Management System - Edit User";

                //open the add/edit user form (modal)
                frmEditUser.ShowDialog();
            }
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            //want to send the employee obj to the add user form - for the employee logged in
            AddEditUser frmAddUser = new AddEditUser(employee);

            //update the form's text to be accurate - adding an user
            frmAddUser.Text = "Bullseye Inventory Management System - Add User";

            //open the add/edit user form (modal)
            frmAddUser.ShowDialog();
        }

        //timer should close this form after 20 minutes
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UserManagement_KeyDown(object sender, KeyEventArgs e)
        {
            //if the F1 key is pressed down
            if (e.KeyCode == Keys.F1)
            {
                MessageBox.Show("This is the user management page. You can read, add, edit, and delete users from here." +
                "\n\nClick on the 'refresh' button to load the users data grid.", "User Management Help"
                , MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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
                    var usernameCellValue = row.Cells["username"].Value;

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

                    //else if - username cell converted to lower case contains the txtbox text
                    else if (usernameCellValue != null && usernameCellValue.ToString().ToLower().Contains(txtSearchUsers.Text))
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
