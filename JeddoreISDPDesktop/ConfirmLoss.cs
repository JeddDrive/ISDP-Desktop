using JeddoreISDPDesktop.DAO_Classes;
using JeddoreISDPDesktop.Entity_Classes;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Site = JeddoreISDPDesktop.Entity_Classes.Site;

namespace JeddoreISDPDesktop
{
    public partial class ConfirmLoss : Form
    {
        //class level/global variable for the employee object from the dashboard
        Employee employee = null;

        //global variable for the inventory list sent into this form
        List<Inventory> listItems = new List<Inventory>();

        public ConfirmLoss(Employee employeeLoggedIn, List<Inventory> listItemsSentIn)
        {
            InitializeComponent();
            employee = employeeLoggedIn;
            listItems = listItemsSentIn;
        }

        private void ConfirmLoss_Load(object sender, EventArgs e)
        {
            //setting the tooltip for the help image
            toolTipHelp.SetToolTip(picHelp, "Click here for help.");

            //display the employee's username and location in this form
            lblUsername.Text = employee.username;
            lblLocation.Text = employee.siteName;

            //select the loss radiobutton by default
            radLoss.Checked = true;

            //if the list of items is not null - this shouldn't be an issue
            //but are doing a check just in case to prevent any possible exceptions
            if (listItems != null)
            {
                //foreach loop - populate the combobox
                foreach (Inventory inventoryItem in listItems)
                {
                    //add the item to the combobox
                    cboItems.Items.Add(inventoryItem.itemID + " - " + inventoryItem.name + " - x" + inventoryItem.quantity);
                }
            }

            //getting the last/most recent txn
            Txn lastTxn = TxnAccessor.GetLastTxn();

            //putting what should be the most recent txn/loss ID + 1 in the label
            lblTxnID.Text = (lastTxn.txnID + 1).ToString();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //timer to close this form after 20 minutes
            this.Close();
        }

        private void picHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This is the form for creating and confirming a loss/damage transaction. You can review the items selected for a loss/damage on this form using the combobox. " +
            "Please use the radiobuttons on this form to confirm if this transaction is for lost or damaged items." +
            "\n\nClick on the 'Save' button to finally save your Loss or Damage transaction.", "Confirm Loss Help"
            , MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ConfirmLoss_KeyDown(object sender, KeyEventArgs e)
        {
            //if the F1 key is pressed down
            if (e.KeyCode == Keys.F1)
            {
                MessageBox.Show("This is the form for creating and confirming a loss/damage transaction. You can review the items selected for a loss/damage on this form using the combobox. " +
                "Please use the radiobuttons on this form to confirm if this transaction is for lost or damaged items." +
                "\n\nClick on the 'Save' button to finally save your Loss or Damage transaction.", "Confirm Loss Help"
                , MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //if neither radiobutton is checked
            if (!radLoss.Checked && !radDamage.Checked)
            {
                MessageBox.Show("Plese select and confirm a valid transaction type (Loss or Damage) by clicking on " +
                    "one of those radiobuttons.", "No Transaction Type Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }

            //if the notes length is too short or empty
            if (txtNotes.Text.Length < 3)
            {
                MessageBox.Show("Please type in a valid note for your loss/damage transaction that is at least three characters long.",
                    "Invalid Loss/Damage Note", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtNotes.Focus();

                return;
            }

            //txn object - for the most recent txn (mostly just want the last barcode)
            Txn mostRecentTxn = TxnAccessor.GetLastTxn();

            //converting the barcode to an int
            long mostRecentBarcode = long.Parse(mostRecentTxn.barCode);

            //new barcode will be most recent barcode plus 1
            string newBarcode = (mostRecentBarcode + 1).ToString();

            string txnType = "";

            //now can insert the loss/damage transaction
            //if txn is a loss
            if (radLoss.Checked)
            {
                txnType = "Loss";

            }

            //else - it's a damage
            else
            {
                txnType = "Damage";
            }

            //create new txn object
            Txn newTxn = new Txn(mostRecentTxn.txnID + 1, employee.siteID, employee.siteID, "Complete",
                DateTime.Now, DateTime.Now, txnType, newBarcode, txtNotes.Text);

            //insert the store order txn
            bool successTxnInsert = TxnAccessor.InsertNewLossOrReturn(newTxn);

            //get the employee's site
            Site site = SiteAccessor.GetOneSite(employee.siteID);

            bool goodInsertTxnItems = false;

            //foreach loop
            foreach (Inventory inventoryItem in listItems)
            {
                TxnItems txnItem = new TxnItems(mostRecentTxn.txnID + 1, inventoryItem.itemID,
                    inventoryItem.quantity, txtNotes.Text);

                goodInsertTxnItems = TxnItemsAccessor.InsertNewTxnItem(txnItem);
            }

            //if success
            if (successTxnInsert && goodInsertTxnItems)
            {
                MessageBox.Show(txnType + " transaction for site - " + site.name + " successfully created and completed." +
                    "\n\nYour site inventory should now be updated to reflect the item(s) that were lost or damaged."
                    , txnType + " Transaction Created");

                //close this form
                this.Close();
            }
        }
    }
}
