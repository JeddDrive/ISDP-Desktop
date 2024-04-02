using JeddoreISDPDesktop.DAO_Classes;
using JeddoreISDPDesktop.Entity_Classes;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace JeddoreISDPDesktop
{
    public partial class ConfirmReturn : Form
    {
        //class level/global variable for the employee object from the dashboard
        Employee employee = null;

        //global variable for the inventory list sent into this form
        List<Inventory> listItems = new List<Inventory>();

        //list to keep track of the items marked as being in good condition
        //List<bool> listItemConditions = new List<bool>();

        //array to keep track of the items marked as being in good condition
        bool[] arrayItemConditions = null;

        public ConfirmReturn(Employee employeeLoggedIn, List<Inventory> listItemsSentIn)
        {
            InitializeComponent();
            employee = employeeLoggedIn;
            listItems = listItemsSentIn;
        }

        private void ConfirmReturn_Load(object sender, EventArgs e)
        {
            //setting the tooltip for the help image
            toolTipHelp.SetToolTip(picHelp, "Click here for help.");

            //display the employee's username and location in this form
            lblUsername.Text = employee.username;
            lblLocation.Text = employee.siteName;

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

            //just to be sure, uncheck the checkbox
            chkGoodCondition.Checked = false;

            //also disable the checkbox
            chkGoodCondition.Enabled = false;

            //set the length of this boolean array to the total count of list items
            arrayItemConditions = new bool[listItems.Count];

            //for loop thru the array
            for (int i = 0; i < arrayItemConditions.Length; i++)
            {
                //setting each boolean item of this array to false on form load
                arrayItemConditions[i] = false;
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
            MessageBox.Show("This is the form for creating and confirming a return transaction. You can review the items selected for a return on this form using the combobox. " +
        "Please check the 'Item in Good Condition' box on this form if any item(s) in the combobox for the return are in good condition, so they can be automatically added back to your site's inventory." +
        "\n\nClick on the 'Save' button to finally save your Return transaction.", "Confirm Return Help"
        , MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ConfirmReturn_KeyDown(object sender, KeyEventArgs e)
        {
            //if the F1 key is pressed down
            if (e.KeyCode == Keys.F1)
            {
                MessageBox.Show("This is the form for creating and confirming a return transaction. You can review the items selected for a return on this form using the combobox. " +
                "Please check the 'Item in Good Condition' box on this form if any item(s) in the combobox for the return are in good condition, so they can be automatically added back to your site's inventory." +
                "\n\nClick on the 'Save' button to finally save your Return transaction.", "Confirm Return Help"
                , MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cboItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            //uncheck the checkbox and enable the mark item btn
            //chkGoodCondition.Enabled = false;
            //btnMarkItem.Enabled = true;

            //if the checkbox is checked, then unselect it
            /* if (chkGoodCondition.Checked)
            {
                chkGoodCondition.Checked = false;
            } */

            if (arrayItemConditions[cboItems.SelectedIndex] == true)
            {
                //check the checkbox and disable the mark item btn
                //chkGoodCondition.Enabled = false;
                chkGoodCondition.Checked = true;
                btnMarkItem.Enabled = false;
            }

            else
            {
                chkGoodCondition.Checked = false;
                btnMarkItem.Enabled = true;
            }
        }

        private void btnMarkItem_Click(object sender, EventArgs e)
        {
            if (cboItems.SelectedIndex > -1)
            {
                arrayItemConditions[cboItems.SelectedIndex] = true;

                //get the selected inventory item
                Inventory selectedInventory = listItems[cboItems.SelectedIndex];

                MessageBox.Show("Item " + selectedInventory.itemID + " - " + selectedInventory.name +
                    " has been marked as being in good condition for this return.", "Good Condition Item Confirmed",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                //disable the checkbox and mark item btn
                //chkGoodCondition.Enabled = false;
                btnMarkItem.Enabled = false;
                chkGoodCondition.Checked = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //if the notes length is too short or empty
            if (txtNotes.Text.Length < 3)
            {
                MessageBox.Show("Please type in a valid note for your return transaction that is at least three characters long.",
                    "Invalid Return Note", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtNotes.Focus();

                return;
            }

            //txn object - for the most recent txn (mostly just want the last barcode)
            Txn mostRecentTxn = TxnAccessor.GetLastTxn();

            //converting the barcode to an int
            long mostRecentBarcode = long.Parse(mostRecentTxn.barCode);

            //new barcode will be most recent barcode plus 1
            string newBarcode = (mostRecentBarcode + 1).ToString();

            //create new txn object
            Txn newTxn = new Txn(mostRecentTxn.txnID + 1, employee.siteID, employee.siteID, "Complete",
                DateTime.Now, DateTime.Now, "Return", newBarcode, txtNotes.Text);

            //insert the store order txn
            bool successTxnInsert = TxnAccessor.InsertNewLossOrReturn(newTxn);

            //get the employee's site
            Site site = SiteAccessor.GetOneSite(employee.siteID);

            bool goodInsertTxnItems = false;

            int counter = 0;

            //foreach loop
            foreach (Inventory inventoryItem in listItems)
            {
                TxnItems txnItem = null;

                if (arrayItemConditions[counter] == true)
                {
                    txnItem = new TxnItems(mostRecentTxn.txnID + 1, inventoryItem.itemID,
                        inventoryItem.quantity, "Good Condition Item Return: " + txtNotes.Text);
                }

                else
                {
                    txnItem = new TxnItems(mostRecentTxn.txnID + 1, inventoryItem.itemID,
                        inventoryItem.quantity, "Bad Condition Item Return: " + txtNotes.Text);
                }

                goodInsertTxnItems = TxnItemsAccessor.InsertNewTxnItem(txnItem);

                //add 1 to the counter - for the array
                counter++;
            }

            //if success
            if (successTxnInsert && goodInsertTxnItems)
            {
                MessageBox.Show("Return transaction for site - " + site.name + " successfully created and completed." +
                    "\n\nYour site inventory should now be updated to reflect any item(s) that were returned and marked as being in good condition"
                    , "Return Transaction Created");

                //close this form
                this.Close();
            }
        }
    }
}
