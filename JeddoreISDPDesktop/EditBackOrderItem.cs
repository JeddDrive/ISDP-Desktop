using JeddoreISDPDesktop.DAO_Classes;
using JeddoreISDPDesktop.Entity_Classes;
using System;
using System.Windows.Forms;

namespace JeddoreISDPDesktop
{
    public partial class EditBackOrderItem : Form
    {
        //class level/global variable for the one employee object and one item object
        Employee employee = null;
        Item item = null;
        Inventory inventoryItem = null;

        //global variable for the txn/back order object
        Txn newBackOrder = new Txn();

        //global variable for quantity sent in from other form
        int quantity = 0;

        //global variable for the site to/destination site
        int employeeSite = 0;

        public EditBackOrderItem(Employee employeeLoggedIn, Item itemSelected, Inventory inventoryItemSelected, int currentQuantity, int siteIDTo, int txnID)
        {
            InitializeComponent();

            employee = employeeLoggedIn;
            item = itemSelected;
            inventoryItem = inventoryItemSelected;

            employeeSite = siteIDTo;

            //get current back order for a store that is new, based on the siteIDTo sent in (destination site)
            newBackOrder = TxnAccessor.GetOneBackOrder(siteIDTo);

            //get the current quantity from the other form
            quantity = currentQuantity;
        }

        private void EditBackOrderItem_Load(object sender, EventArgs e)
        {
            //setting the tooltip for the help image
            toolTipHelp.SetToolTip(picHelp, "Click here for help.");

            //display the employee's username and location in this form
            lblUsername.Text = employee.username;
            lblLocation.Text = employee.siteName;

            //set the increment of the nud to be the item's case size
            nudOrderQuantity.Increment = item.caseSize;

            //the nud minimum should also be 1 case size of the item
            nudOrderQuantity.Minimum = item.caseSize;

            //populate the labels using the item's properties
            lblItemID.Text = item.itemID.ToString();
            lblName.Text = item.name;
            lblCategory.Text = item.category;
            lblCaseSize.Text = item.caseSize.ToString();
            lblWarehouseQty.Text = inventoryItem.quantity.ToString();
            lblOrderQty.Text = quantity.ToString();

            //put the current item quantity from the order into the nud as it's value
            nudOrderQuantity.Value = quantity;
        }

        //timer to close this form after 20 minutes
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void picHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This is the page for adding or editing a back order item." +
                "\n\nItem quantity for a back order is incremented or decremented by that item's full case size.",
                "Edit Back Order Item Help"
            , MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void EditBackOrderItem_KeyDown(object sender, KeyEventArgs e)
        {
            //if user presses the F1 key
            if (e.KeyCode == Keys.F1)
            {
                MessageBox.Show("This is the page for adding or editing a back order item." +
                "\n\nItem quantity for a back order is incremented or decremented by that item's full case size.",
                "Edit Back Order Item Help"
                , MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //if quantity in the backorder has been increased
            if (nudOrderQuantity.Value > quantity)
            {
                //create a txnitems obj to send to the accessor for an update
                TxnItems updatedItem = new TxnItems(newBackOrder.txnID, item.itemID,
                    int.Parse(nudOrderQuantity.Value.ToString()), txtNotes.Text);

                //update the quantity and notes of the item
                bool success = TxnItemsAccessor.UpdateTxnItem(updatedItem);

                //if success, then display msg and close the form
                if (success)
                {
                    MessageBox.Show("Quantity of item in back order has been increased from " + quantity.ToString() + " to " +
                        nudOrderQuantity.Value.ToString() + ".", "Successful Quantity Update");

                    this.Close();
                }
            }

            //else if quantity in the order has been decreased
            else if (nudOrderQuantity.Value < quantity)
            {
                //create a txnitems obj to send to the accessor for an update
                TxnItems updatedItem = new TxnItems(newBackOrder.txnID, item.itemID,
                    int.Parse(nudOrderQuantity.Value.ToString()), txtNotes.Text);

                //update the quantity and notes of the item
                bool success = TxnItemsAccessor.UpdateTxnItem(updatedItem);

                //if success, then display msg and close the form
                if (success)
                {
                    MessageBox.Show("Quantity of item in back order has been decreased from " + quantity.ToString() + " to " +
                        nudOrderQuantity.Value.ToString() + ".", "Successful Quantity Update");

                    this.Close();
                }
            }

            //else - no quantity update
            else
            {
                //display msg and close the form
                MessageBox.Show("No update made to quantity for item already in back order.", "No Update Made");

                this.Close();
            }
        }
    }
}
