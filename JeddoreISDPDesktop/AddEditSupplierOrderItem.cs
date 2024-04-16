using JeddoreISDPDesktop.DAO_Classes;
using JeddoreISDPDesktop.Entity_Classes;
using System;
using System.Windows.Forms;

namespace JeddoreISDPDesktop
{
    public partial class AddEditSupplierOrderItem : Form
    {
        //class level/global variable for the one employee object and one item object
        Employee employee = null;
        Item item = null;
        Inventory inventoryItem = null;

        //global variable for the txn/order object
        Txn newOrder = new Txn();

        //global variable for quantity sent in from other form
        int quantity = 0;

        //global variable for the site to/destination site
        int employeeSite = 0;

        //constructor #1 - called when inserting item into order
        public AddEditSupplierOrderItem(Employee employeeLoggedIn, Item itemSelected, Inventory inventoryItemSelected)
        {
            InitializeComponent();
            employee = employeeLoggedIn;
            item = itemSelected;
            inventoryItem = inventoryItemSelected;

            employeeSite = employee.siteID;

            //get current store OR emergency order for a store that is new, based on the employee's siteID
            newOrder = TxnAccessor.GetOneNewOrder(employeeSite);
        }

        //constructor #2 - called when updating item quantity
        public AddEditSupplierOrderItem(Employee employeeLoggedIn, Item itemSelected, Inventory inventoryItemSelected, int currentQuantity)
        {
            InitializeComponent();
            employee = employeeLoggedIn;
            item = itemSelected;
            inventoryItem = inventoryItemSelected;

            employeeSite = employee.siteID;

            //get current store OR emergency order for a store that is new, based on the employee's siteID
            newOrder = TxnAccessor.GetOneNewOrder(employeeSite);

            //get the current quantity from the other form
            quantity = currentQuantity;
        }

        private void AddEditSupplierOrderItem_Load(object sender, EventArgs e)
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

            //if quantity is not 0, meaning that an item quantity is being updated and NOT inserted then
            if (quantity != 0)
            {
                //put the current item quantity from the order into the nud as it's value
                //nudOrderQuantity.Minimum = quantity;
                nudOrderQuantity.Value = quantity;
                this.Text += "Edit Supplier Order Item";
            }

            //else - quantity is 0, meaning that are doing an insert then
            else
            {
                this.Text += "Add Supplier Order Item";
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

        private void AddEditSupplierOrderItem_KeyDown(object sender, KeyEventArgs e)
        {
            //if user presses the F1 key
            if (e.KeyCode == Keys.F1)
            {
                MessageBox.Show("This is the page for adding or editing a supplier order item." +
                "\n\nItem quantity for a supplier order is incremented or decremented by that item's full case size." +
                "\n\nClick the 'Save' button when you wish to save your needed quantity for the item in your supplier order.",
                "Add/Edit Supplier Order Item Help"
            , MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void picHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This is the page for adding or editing a supplier order item." +
            "\n\nItem quantity for a supplier order is incremented or decremented by that item's full case size." +
            "\n\nClick the 'Save' button when you wish to save your needed quantity for the item in your supplier order.",
            "Add/Edit Supplier Order Item Help"
            , MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //if - are doing an item insert
            //this global quantity variable should be 0 if doing an insert
            if (quantity == 0)
            {
                //create txnitem object - to be added to the store/emergency order
                TxnItems txnItemForOrder = new TxnItems(newOrder.txnID, item.itemID,
                        int.Parse(nudOrderQuantity.Value.ToString()), txtNotes.Text);

                //then can add this txn item to the store/emergency order txn
                bool success = TxnItemsAccessor.InsertNewTxnItem(txnItemForOrder);

                //if success
                if (success)
                {
                    MessageBox.Show("Requested inventory item quantity added to your order.", "Inventory Item Addition Successful");

                    this.Close();
                }
            }

            //else - are doing a quantity update
            else
            {
                //if no change in quantity in the nud, then can simply close this form
                if (nudOrderQuantity.Value == quantity)
                {
                    //then display msg and close the form
                    MessageBox.Show("No update made to quantity for item already in order.", "No Update Made");

                    this.Close();
                }

                //else if - the quantity in the order has been decreased
                else if (nudOrderQuantity.Value < quantity)
                {
                    //create a txnitems obj to send to the accessor for an update
                    TxnItems updatedItem = new TxnItems(newOrder.txnID, item.itemID,
                        int.Parse(nudOrderQuantity.Value.ToString()), txtNotes.Text);

                    //update the quantity and notes of the item
                    bool success = TxnItemsAccessor.UpdateTxnItem(updatedItem);

                    //if success, then display msg and close the form
                    if (success)
                    {
                        MessageBox.Show("Quantity of item in order has been decreased from " + quantity + " to " +
                            nudOrderQuantity.Value.ToString() + ".", "Successful Quantity Update");

                        this.Close();
                    }
                }

                //else if - quantity in the order has been increased and is equal to or under the amount available in the warehouse
                else if (nudOrderQuantity.Value > quantity)
                {
                    //create a txnitems obj to send to the accessor for an update
                    TxnItems updatedItem = new TxnItems(newOrder.txnID, item.itemID,
                        int.Parse(nudOrderQuantity.Value.ToString()), txtNotes.Text);

                    //update the quantity and notes of the item
                    bool success = TxnItemsAccessor.UpdateTxnItem(updatedItem);

                    //if success, then display msg and close the form
                    if (success)
                    {
                        MessageBox.Show("Quantity of item in order has been increased from " + quantity.ToString() + " to " +
                            nudOrderQuantity.Value.ToString() + ".", "Successful Quantity Update");

                        this.Close();
                    }
                }
            }
        }
    }
}
