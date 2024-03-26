using JeddoreISDPDesktop.DAO_Classes;
using JeddoreISDPDesktop.Entity_Classes;
using System;
using System.Windows.Forms;

namespace JeddoreISDPDesktop
{
    public partial class ReceiveOnlineOrder : Form
    {
        //class level/global variable for the one employee object and one site object
        Employee employee = null;

        //global variable for the txn sent in
        Txn txn = null;

        public ReceiveOnlineOrder(Employee employeeLoggedIn, Txn txnReceived)
        {
            InitializeComponent();
            employee = employeeLoggedIn;
            txn = txnReceived;
        }

        private void ReceiveOnlineOrder_Load(object sender, EventArgs e)
        {
            //setting the tooltip for the help image
            toolTipHelp.SetToolTip(picHelp, "Click here for help.");

            //display the employee's username and location in this form
            lblUsername.Text = employee.username;
            lblLocation.Text = employee.siteName;

            //populate labels/any other controls
            lblTxnID.Text = txn.txnID.ToString();
            lblTxnType.Text = txn.txnType;

            if (txn.notes != null)
            {
                txtCustomerNotes.Text = txn.notes;
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

        private void picHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This is the form for confirming the receival of an assembled online order. Before confirming the receival of the online order, please enter a valid signature (employee or customer)." +
            "\n\nClick on the 'Confirm Receival' button when you're ready to confirm the order's receival.", "Receive Online Order Help"
            , MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ReceiveOnlineOrder_KeyDown(object sender, KeyEventArgs e)
        {
            //if the F1 key is pressed down
            if (e.KeyCode == Keys.F1)
            {
                MessageBox.Show("This is the form for confirming the receival of an assembled online order. Before confirming the receival of the online order, please enter a valid signature (employee or customer)." +
                "\n\nClick on the 'Confirm Receival' button when you're ready to confirm the order's receival.", "Receive Online Order Help"
                , MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            //var for employee full name
            string fullName = (employee.firstName + " " + employee.lastName).ToLower();

            //doing a signature check for the user that is logged in and for the customer name
            if (txtSignature.Text.ToLower() != fullName &&
                txtSignature.Text.ToLower() != employee.username &&
                !(txn.notes.IndexOf(txtSignature.Text, StringComparison.OrdinalIgnoreCase) >= 0))
            {
                MessageBox.Show("Invalid signature. Employee full name, employee username, or customer name not recognized." +
                    "\n\nFor an order receival signature, please enter your first and last name separated by a space. You can also simply just enter your username if you are an employee.", "Invalid Signature",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtSignature.Focus();

                return;
            }


            DialogResult btnValueReturned = MessageBox.Show("Confirm receival for customer -  " + txn.notes + "?" +
            "\n\nReceival Signature: " + txtSignature.Text, "Confirm Order Receival", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            //if - user selects the yes btn
            if (btnValueReturned == DialogResult.Yes)
            {
                //var for notes signature
                //are going to put this in the txn table
                string notesSignature = " Receival Signature: " + txtSignature.Text;

                //updating the txn's status to Complete
                //and notes as well - adding the receival signature to the end of this field
                txn.status = "Complete";
                txn.notes += notesSignature;

                //now can update the txn as well
                bool orderDeliveredUpdate = TxnAccessor.UpdateTxnStatusAndNotes(txn);

                //if success from both updates
                if (orderDeliveredUpdate)
                {
                    MessageBox.Show("Online order has been confirmed as successfully received. This order is now closed." +
                        "\n\nOrder Receival Signature: " + txtSignature.Text, "Order Receival Confirmed");

                    this.Close();
                }
            }
        }
    }
}
