using JeddoreISDPDesktop.DAO_Classes;
using JeddoreISDPDesktop.Entity_Classes;
using JeddoreISDPDesktop.Helper_Classes;
using System;
using System.Windows.Forms;

namespace JeddoreISDPDesktop
{
    public partial class AddEditOrderItem : Form
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
        public AddEditOrderItem(Employee employeeLoggedIn, Item itemSelected, Inventory inventoryItemSelected)
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
        public AddEditOrderItem(Employee employeeLoggedIn, Item itemSelected, Inventory inventoryItemSelected, int currentQuantity)
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

        //constructor #3 - called from the order items management form
        public AddEditOrderItem(Employee employeeLoggedIn, Item itemSelected, Inventory inventoryItemSelected, int currentQuantity, int siteIDTo)
        {
            InitializeComponent();
            employee = employeeLoggedIn;
            item = itemSelected;
            inventoryItem = inventoryItemSelected;

            employeeSite = siteIDTo;

            //get current store OR emergency order for a store that is new, based on the siteIDTo sent in (destination site)
            newOrder = TxnAccessor.GetOneNewOrder(siteIDTo);

            //get the current quantity from the other form
            quantity = currentQuantity;
        }

        private void AddEditOrderItem_Load(object sender, EventArgs e)
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
            lblWarehouseQuantity.Text = inventoryItem.quantity.ToString();
            lblWarehouseQty.Text = inventoryItem.quantity.ToString();
            lblOrderQty.Text = quantity.ToString();

            //if quantity is not 0, meaning that an item quantity is being updated and NOT inserted then
            if (quantity != 0)
            {
                //put the current item quantity from the order into the nud as it's value
                nudOrderQuantity.Minimum = quantity;
                nudOrderQuantity.Value = quantity;
                lblWarehouseQuantity.Text = (inventoryItem.quantity + quantity).ToString();
            }
        }

        private void picHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This is the page for adding or editing an order item." +
                "\n\nItem quantity for an order is incremented or decremented by that item's full case size." +
                "\n\nIf more quantity of an item needs to be ordered than what is currently available in the warehouse, then that unavailable quantity will be added to a backorder for your site.",
                "Add/Edit Order Item Help"
            , MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void AddEditOrderItem_KeyDown(object sender, KeyEventArgs e)
        {
            //if user presses the F1 key
            if (e.KeyCode == Keys.F1)
            {
                MessageBox.Show("This is the page for adding or editing an order item." +
                "\n\nItem quantity for an order is incremented or decremented by that item's full case size." +
                "\n\nIf more quantity of an item is needed than what is currently available in the warehouse, then that unavailable quantity will be added to a backorder for your site.",
                "Add/Edit Order Item Help"
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            //if - are doing an item insert
            //this global quantity variable should be 0 if doing an insert
            if (quantity == 0)
            {
                //if nud quantity exceeds the quantity in the warehouse
                if (int.Parse(nudOrderQuantity.Value.ToString()) > int.Parse(lblWarehouseQuantity.Text))
                {
                    DialogResult btnValueReturned = MessageBox.Show("Quantity selected of this item to be added to your order exceeds the quantity available in the warehouse." +
                        "\n\nDo you wish to add the quantity requested but not currently available to your store's backorder?" +
                        "\n\nIf a backorder doesn't currently exist for your store, then a new one will be created.",
                        "Quantity in Order Requested More than Warehouse Quantity", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    //if - user selects the yes btn
                    if (btnValueReturned == DialogResult.Yes)
                    {
                        //check if backorder currently exists for the employee's site (should be a 0 or 1 returned)
                        long numBackOrders = TxnAccessor.GetCountOfActiveBackOrdersForSite(employeeSite);

                        //txn object - for the most recent txn (mostly just want the last barcode)
                        Txn mostRecentTxn = TxnAccessor.GetLastTxn();

                        //converting the barcode to an int
                        long mostRecentBarcode = long.Parse(mostRecentTxn.barCode);

                        //new barcode will be most recent barcode plus 1
                        string newBarcode = (mostRecentBarcode + 1).ToString();

                        //byte var for emergency delivery
                        //back order shouldn't be considered an emergency delivery
                        byte emergencyDelivery = 0;

                        //get the employee's site
                        Site site = SiteAccessor.GetOneSite(employeeSite);

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

                        //if backorder doesn't exist, then create one (txn) and add this txnitem to it
                        if (numBackOrders == 0)
                        {
                            //create new txn object
                            Txn newTxn = new Txn(mostRecentTxn.txnID + 1, employeeSite, 2, "New",
                                shipDate, "Back Order", newBarcode, DateTime.Now, emergencyDelivery);

                            //insert the back order txn
                            bool success1 = TxnAccessor.InsertNewTxn(newTxn);

                            //calculate the quantity to be added to the backorder
                            int backOrderQuantity = int.Parse(nudOrderQuantity.Value.ToString()) - int.Parse(lblWarehouseQuantity.Text);

                            int quantityAvailableForOrder = int.Parse(lblWarehouseQuantity.Text) - int.Parse(nudOrderQuantity.Value.ToString());

                            //if the quantity available in the warehouse for the store/emergency order is above 0 then
                            if (int.Parse(lblWarehouseQuantity.Text) > 0)
                            {
                                //create txnitem object - to be added to the store/emergency order
                                TxnItems txnItemForOrder = new TxnItems(newOrder.txnID, item.itemID,
                                        int.Parse(lblWarehouseQuantity.Text), txtNotes.Text);

                                //then can add this txn item to the store/emergency order txn
                                bool success2 = TxnItemsAccessor.InsertNewTxnItem(txnItemForOrder);

                                //update the backorder quantity
                                //backOrderQuantity -= quantityAvailableForOrder;
                            }

                            else
                            {
                                MessageBox.Show("Insufficient quantity available in warehouse to add any quantity of item to current store order.", "Insufficient Quantity");

                                //and backorder quantity should be updated to be this - the full requested amount in the nud
                                backOrderQuantity = int.Parse(nudOrderQuantity.Value.ToString());
                            }

                            //if success
                            if (success1)
                            {
                                //now get the newly created backorder for the site
                                Txn theNewBackOrder = TxnAccessor.GetOneNewBackOrder(employeeSite);

                                //create txnitem object - to be added to the backorder
                                TxnItems txnItemForBackOrder = new TxnItems(theNewBackOrder.txnID, item.itemID,
                                        backOrderQuantity, txtNotes.Text);

                                //insert this txnitem into the newly created backorder now
                                bool success3 = TxnItemsAccessor.InsertNewTxnItem(txnItemForBackOrder);

                                if (success3)
                                {
                                    MessageBox.Show("Unavailable item quantity of " + backOrderQuantity + " added to current backorder for " + site.name + "." +
                                    "\n\nEstimated Shipping Date for backorder: " + shipDate, "Item Successfully Added to Backorder");

                                    //close this form
                                    this.Close();
                                }
                            }
                        }

                        //else - backorder already exists
                        else
                        {
                            //now get the already created backorder for the site
                            Txn theBackOrder = TxnAccessor.GetOneNewBackOrder(employeeSite);

                            //calculate the quantity to be added to the backorder
                            int backOrderQuantity = int.Parse(nudOrderQuantity.Value.ToString()) - int.Parse(lblWarehouseQuantity.Text);

                            //calculate the quantity available for the store/emergency order
                            int quantityAvailableForOrder = int.Parse(lblWarehouseQuantity.Text) - int.Parse(nudOrderQuantity.Value.ToString());

                            //if the quantity available in the warehouse for the store/emergency order is above 0 then
                            if (int.Parse(lblWarehouseQuantity.Text) > 0)
                            {
                                //create txnitem object - to be added to the store/emergency order
                                TxnItems txnItemForOrder = new TxnItems(newOrder.txnID, item.itemID,
                                        int.Parse(lblWarehouseQuantity.Text), txtNotes.Text);

                                //then can add this txn item to the store/emergency order txn
                                bool success2 = TxnItemsAccessor.InsertNewTxnItem(txnItemForOrder);

                                //update the backorder quantity
                                //backOrderQuantity -= quantityAvailableForOrder;
                            }

                            else
                            {
                                MessageBox.Show("Insufficient quantity available in warehouse to add any quantity of item to current store order.", "Insufficient Quantity");

                                //and backorder quantity should be updated to be this - the full requested amount in the nud
                                backOrderQuantity = int.Parse(nudOrderQuantity.Value.ToString());
                            }


                            //create txnitem object - to be added to the backorder
                            TxnItems txnItemForBackOrder = new TxnItems(theBackOrder.txnID, item.itemID,
                                    backOrderQuantity, txtNotes.Text);

                            //insert this txnitem into the newly created backorder now
                            bool success3 = TxnItemsAccessor.InsertNewTxnItem(txnItemForBackOrder);

                            if (success3)
                            {
                                MessageBox.Show("Unavailable item quantity of " + backOrderQuantity + " added to current backorder for " + site.name + "." +
                                "\n\nEstimated Shipping Date for backorder: " + shipDate, "Item Successfully Added to Backorder");

                                //close this form
                                this.Close();
                            }
                        }
                    }
                }

                //else - nud quantity does NOT exceed warehouse quantity
                else
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
                        MessageBox.Show("Quantity of item in order has been decreased to " +
                            nudOrderQuantity.Value.ToString() + ".", "Successful Quantity Update");

                        this.Close();
                    }
                }

                //else if - the quantity in the order has been increased and it's over the amount available (in the warehouse + amount already in the order)
                else if (nudOrderQuantity.Value > quantity && int.Parse(nudOrderQuantity.Value.ToString()) > int.Parse(lblWarehouseQuantity.Text))
                {
                    DialogResult btnValueReturned = MessageBox.Show("Quantity selected of this item to be added to your order exceeds the quantity available in the warehouse." +
                    "\n\nDo you wish to add the quantity requested but not currently available to your store's backorder?" +
                    "\n\nIf a backorder doesn't currently exist for your store, then a new one will be created.",
                    "Quantity in Order Requested More than Warehouse Quantity", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                    //if - user selects the yes btn
                    if (btnValueReturned == DialogResult.Yes)
                    {
                        //check if backorder currently exists for the employee's site (should be a 0 or 1 returned)
                        long numBackOrders = TxnAccessor.GetCountOfActiveBackOrdersForSite(employeeSite);

                        //txn object - for the most recent txn (mostly just want the last barcode)
                        Txn mostRecentTxn = TxnAccessor.GetLastTxn();

                        //converting the barcode to an int
                        long mostRecentBarcode = long.Parse(mostRecentTxn.barCode);

                        //new barcode will be most recent barcode plus 1
                        string newBarcode = (mostRecentBarcode + 1).ToString();

                        //byte var for emergency delivery
                        //back order shouldn't be considered an emergency delivery
                        byte emergencyDelivery = 0;

                        //get the employee's site
                        Site site = SiteAccessor.GetOneSite(employeeSite);

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

                        //if backorder doesn't exist, then create one (txn) and add this txnitem to it
                        if (numBackOrders == 0)
                        {
                            //create new txn object
                            Txn newTxn = new Txn(mostRecentTxn.txnID + 1, employeeSite, 2, "New",
                                shipDate, "Back Order", newBarcode, DateTime.Now, emergencyDelivery);

                            //insert the back order txn
                            bool success1 = TxnAccessor.InsertNewTxn(newTxn);

                            //calculate the quantity to be added to the backorder
                            int backOrderQuantity = int.Parse(nudOrderQuantity.Value.ToString()) - quantity;

                            int quantityAvailableForOrder = int.Parse(lblWarehouseQuantity.Text) - int.Parse(nudOrderQuantity.Value.ToString());

                            //if the quantity available in the warehouse for the store/emergency order is above 0 then
                            if (int.Parse(lblWarehouseQuantity.Text) > 0)
                            {
                                //create txnitem object - to be added to the store/emergency order
                                TxnItems txnItemForOrder = new TxnItems(newOrder.txnID, item.itemID,
                                        int.Parse(lblWarehouseQuantity.Text), txtNotes.Text);

                                //then can add this txn item to the store/emergency order txn
                                bool success2 = TxnItemsAccessor.UpdateTxnItem(txnItemForOrder);
                            }

                            /* else
                            {
                                MessageBox.Show("Insufficient quantity available in warehouse to add any quantity of item to current store order.", "Insufficient Quantity");

                                //and backorder quantity should be updated to be this - the full requested amount in the nud
                                backOrderQuantity = int.Parse(nudOrderQuantity.Value.ToString());
                            } */

                            //if success
                            if (success1)
                            {
                                //now get the newly created backorder for the site
                                Txn theNewBackOrder = TxnAccessor.GetOneNewBackOrder(employeeSite);

                                //create txnitem object - to be added to the backorder
                                TxnItems txnItemForBackOrder = new TxnItems(theNewBackOrder.txnID, item.itemID,
                                        backOrderQuantity, txtNotes.Text);

                                //insert this txnitem into the newly created backorder now
                                bool success3 = TxnItemsAccessor.InsertNewTxnItem(txnItemForBackOrder);

                                if (success3)
                                {
                                    MessageBox.Show("Unavailable item quantity of " + backOrderQuantity + " added to current backorder for " + site.name + "." +
                                    "\n\nEstimated Shipping Date for backorder: " + shipDate, "Item Successfully Added to Backorder");

                                    //close this form
                                    this.Close();
                                }
                            }
                        }

                        //else - backorder already exists
                        else
                        {
                            //now get the already created backorder for the site
                            Txn theBackOrder = TxnAccessor.GetOneNewBackOrder(employeeSite);

                            //calculate the quantity to be added to the backorder
                            int backOrderQuantity = int.Parse(nudOrderQuantity.Value.ToString()) - quantity;

                            //calculate the quantity available for the store/emergency order
                            int quantityAvailableForOrder = int.Parse(lblWarehouseQuantity.Text) - int.Parse(nudOrderQuantity.Value.ToString());

                            //if the quantity available in the warehouse for the store/emergency order is above 0 then
                            if (int.Parse(lblWarehouseQuantity.Text) > 0)
                            {
                                //create txnitem object - to be added to the store/emergency order
                                TxnItems txnItemForOrder = new TxnItems(newOrder.txnID, item.itemID,
                                        int.Parse(lblWarehouseQuantity.Text), txtNotes.Text);

                                //then can add this txn item to the store/emergency order txn
                                bool success2 = TxnItemsAccessor.UpdateTxnItem(txnItemForOrder);
                            }

                            /* else
                            {
                                MessageBox.Show("Insufficient quantity available in warehouse to add any quantity of item to current store order.", "Insufficient Quantity");

                                //and backorder quantity should be updated to be this - the full requested amount in the nud
                                backOrderQuantity = int.Parse(nudOrderQuantity.Value.ToString());
                            } */

                            //create txnitem object - to be added to the backorder
                            TxnItems txnItemForBackOrder = new TxnItems(theBackOrder.txnID, item.itemID,
                                    backOrderQuantity, txtNotes.Text);

                            //insert this txnitem into the newly created backorder now
                            bool success3 = TxnItemsAccessor.InsertNewTxnItem(txnItemForBackOrder);

                            if (success3)
                            {
                                MessageBox.Show("Unavailable item quantity of " + backOrderQuantity + " added to current backorder for " + site.name + "." +
                                "\n\nEstimated Shipping Date for backorder: " + shipDate, "Item Successfully Added to Backorder");

                                //close this form
                                this.Close();
                            }
                        }
                    }
                }

                //else if - quantity in the order has been increased and is equal to or under the amount available in the warehouse
                else if (nudOrderQuantity.Value > quantity && int.Parse(nudOrderQuantity.Value.ToString()) <= int.Parse(lblWarehouseQuantity.Text))
                {
                    //create a txnitems obj to send to the accessor for an update
                    TxnItems updatedItem = new TxnItems(newOrder.txnID, item.itemID,
                        int.Parse(nudOrderQuantity.Value.ToString()), txtNotes.Text);

                    //update the quantity and notes of the item
                    bool success = TxnItemsAccessor.UpdateTxnItem(updatedItem);

                    //if success, then display msg and close the form
                    if (success)
                    {
                        MessageBox.Show("Quantity of item in order has been increased to " +
                            nudOrderQuantity.Value.ToString() + ".", "Successful Quantity Update");

                        this.Close();
                    }
                }
            }
        }
    }
}
