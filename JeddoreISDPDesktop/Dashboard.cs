using JeddoreISDPDesktop.DAO_Classes;
using JeddoreISDPDesktop.Entity_Classes;
using System;
using System.Windows.Forms;

namespace JeddoreISDPDesktop
{
    public partial class Dashboard : Form
    {
        //class level/global variable for the employee object from the login form
        Employee employee = null;

        public Dashboard(Employee employeeLoggedIn)
        {
            InitializeComponent();
            employee = employeeLoggedIn;
        }

        private void picHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Welcome, you are now logged into the Bullseye dashboard. Click on a tab " +
                "below, and then a button inside one of those tabs to do that specific task.", "Dashboard Help"
                , MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            //setting the tooltip for the help image
            toolTipHelp.SetToolTip(picHelp, "Click here for help.");

            //display the employee's username and location in this form
            lblUsername.Text = employee.username;
            lblLocation.Text = employee.siteName;

            //set the default tab control on form load to the admin tab - for now
            //NOTE: will likely update this in sprint 2 or 3
            tabControlDashboard.SelectedTab = tabAdmin;

            //get the employee's user permissions
            UserPermission employeeUserPermissions = UserPermissionAccessor.GetOneEmployeeUserPermissions(employee.employeeID);

            //all btns in the tabs should be disabled (in properties) on dashboard load
            //below - are enabling btns based on if permission IDs are present in the list or not
            //checking the list for READERUSER
            if (employeeUserPermissions.permissionIDList.Contains("READUSER"))
            {
                btnViewUsers.Enabled = true;
            }

            //check the list for SETPERMISSION
            if (employeeUserPermissions.permissionIDList.Contains("SETPERMISSION"))
            {
                btnSetUserPermissions.Enabled = true;
            }

            //check the list for EDITITEM
            if (employeeUserPermissions.permissionIDList.Contains("EDITITEM"))
            {
                btnEditItem.Enabled = true;
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            //then the dashboard
            this.Close();
        }

        private void btnViewUsers_Click(object sender, EventArgs e)
        {
            //want to send the employee obj to the user management form
            UserManagement frmUserManagement = new UserManagement(employee);

            //open the user management form (modal)
            frmUserManagement.ShowDialog();
        }

        private void btnSetUserPermissions_Click(object sender, EventArgs e)
        {
            //want to send the employee obj to the user permissions form
            UserPermissions frmUserPermissions = new UserPermissions(employee);

            //open the user management form (modal)
            frmUserPermissions.ShowDialog();
        }

        private void btnEditItem_Click(object sender, EventArgs e)
        {
            //want to send the employee obj to the item management form
            ItemManagement frmItemManagement = new ItemManagement(employee);

            //open the item management form (modal)
            frmItemManagement.ShowDialog();
        }

        //timer should close this form after 20 minutes
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Dashboard_KeyDown(object sender, KeyEventArgs e)
        {
            //if the F1 key is pressed down
            if (e.KeyCode == Keys.F1)
            {
                MessageBox.Show("Welcome, you are now logged into the Bullseye dashboard. Click on a tab " +
               "below, and then a button inside one of those tabs to do that specific task.", "Dashboard Help"
               , MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
