using JeddoreISDPDesktop.DAO_Classes;
using JeddoreISDPDesktop.Entity_Classes;
using JeddoreISDPDesktop.Helper_Classes;
using System;
using System.Windows.Forms;

namespace JeddoreISDPDesktop
{
    public partial class CreateNewOrder : Form
    {
        //class level/global variable for the employee object from the dashboard
        Employee employee = null;

        public CreateNewOrder(Employee employeeLoggedIn)
        {
            InitializeComponent();
            employee = employeeLoggedIn;
        }

        private void CreateNewOrder_Load(object sender, EventArgs e)
        {
            //setting the tooltip for the help image
            toolTipHelp.SetToolTip(picHelp, "Click here for help.");

            //display the employee's username and location in this form
            lblUsername.Text = employee.username;
            lblLocation.Text = employee.siteName;
        }

        private void picHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This is the page for creating a new order for your site. You can create orders of the following types from here:\n\n1. Store\n\n2. Emergency (Limit of 5 items)" +
            "\n\nSelect an order type, then click on the 'create' button to create your order.", "Create New Order Help"
            , MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CreateNewOrder_KeyDown(object sender, KeyEventArgs e)
        {
            //if F1 key is pressed down
            if (e.KeyCode == Keys.F1)
            {
                MessageBox.Show("This is the page for creating a new order for your site. You can create orders of the following types from here:\n\n1. Store\n\n2. Emergency (Limit of 5 items)" +
                "\n\nSelect an order type, then click on the 'create' button to create your order.", "Create New Order Help"
                , MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //timer to close this form after 20 minutes
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            //txn object - for the most recent txn (mostly just want the last barcode)
            Txn mostRecentTxn = TxnAccessor.GetLastTxn();

            //converting the barcode to an int
            long mostRecentBarcode = long.Parse(mostRecentTxn.barCode);

            //new barcode will be most recent barcode plus 1
            string newBarcode = (mostRecentBarcode + 1).ToString();

            //get the employee's site
            Site site = SiteAccessor.GetOneSite(employee.siteID);

            DayOfWeek shipDayOfWeek = DayOfWeek.Saturday;

            //switch - for the site's day of week order property
            switch (site.dayOfWeek)
            {
                case "SUNDAY":
                    shipDayOfWeek = DayOfWeek.Sunday;
                    break;
                case "MONDAY":
                    shipDayOfWeek = DayOfWeek.Monday;
                    break;
                case "TUESDAY":
                    shipDayOfWeek = DayOfWeek.Tuesday;
                    break;
                case "WEDNESDAY":
                    shipDayOfWeek = DayOfWeek.Wednesday;
                    break;
                case "THURSDAY":
                    shipDayOfWeek = DayOfWeek.Thursday;
                    break;
                case "FRIDAY":
                    shipDayOfWeek = DayOfWeek.Friday;
                    break;
                case "SATURDAY":
                    shipDayOfWeek = DayOfWeek.Saturday;
                    break;
            }

            //get the next ship date for the employee's site
            DateTime shipDate = DayOfWeekCalculator.getNextShipDate(shipDayOfWeek);

            //if the store order radio btn is selected
            if (radStoreOrder.Checked)
            {
                //byte var for emergency delivery
                byte emergencyDelivery = 0;

                //create new txn object
                Txn newTxn = new Txn(mostRecentTxn.txnID + 1, employee.siteID, 2, "New",
                    shipDate, "Store Order", newBarcode, DateTime.Now, emergencyDelivery);

                //insert the store order txn
                bool success = TxnAccessor.InsertNewTxn(newTxn);

                //if success
                if (success)
                {
                    MessageBox.Show("Store Order for site - " + site.name + " successfully created." +
                        "\n\nEstimated Shipping Date: " + shipDate, "Store Order Created");

                    //close this form
                    this.Close();
                }

            }

            //else - the emergency order radio btn is selected
            else
            {
                //byte var for emergency delivery
                byte emergencyDelivery = 1;

                //create new txn object
                Txn newTxn = new Txn(mostRecentTxn.txnID + 1, employee.siteID, 2, "New",
                    shipDate, "Emergency", newBarcode, DateTime.Now, emergencyDelivery);

                //insert the emergency order txn
                bool success = TxnAccessor.InsertNewTxn(newTxn);

                //if success
                if (success)
                {
                    MessageBox.Show("Emergency Order for site - " + site.name + " successfully created." +
                        "\n\nEstimated Shipping Date: " + shipDate, "Emergency Order Created");

                    //close this form
                    this.Close();
                }
            }
        }
    }
}
