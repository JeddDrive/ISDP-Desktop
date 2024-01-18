using JeddoreISDPDesktop.Entity_Classes;
using System;
using System.Windows.Forms;

namespace JeddoreISDPDesktop
{
    public partial class Dashboard : Form
    {
        //class level/global variable for the employee object from the login form
        Employee employeeLoggedIn = null;

        public Dashboard(Employee employee)
        {
            InitializeComponent();
            employeeLoggedIn = employee;
        }

        private void picHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Welcome, you are now logged into the Bullseye dashboard. Click on a tab " +
                "below, and a button inside one of those tabs to do that task", "Dashboard Help");
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            //display the employee's username and location in this form
            lblUsername.Text = employeeLoggedIn.username;
            lblLocation.Text = employeeLoggedIn.siteName;
        }
    }
}
