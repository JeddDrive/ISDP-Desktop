using JeddoreISDPDesktop.DAO_Classes;
using JeddoreISDPDesktop.Entity_Classes;
using System;
using System.Windows.Forms;

namespace JeddoreISDPDesktop
{
    public partial class EditInventory : Form
    {
        //class level/global variables for the employee object, and inventory object
        Employee employee = null;
        Inventory inventoryItem = null;

        public EditInventory(Employee employeeLoggedIn, Inventory inventorySentIn)
        {
            InitializeComponent();
            employee = employeeLoggedIn;
            inventoryItem = inventorySentIn;
        }

        private void EditInventory_Load(object sender, EventArgs e)
        {
            //setting the tooltip for the help image
            toolTipHelp.SetToolTip(picHelp, "Click here for help.");

            //display the employee's username and location in this form
            lblUsername.Text = employee.username;
            lblLocation.Text = employee.siteName;

            //display/populate the item labels and textboxes
            lblItemID.Text = inventoryItem.itemID.ToString();
            lblSiteID.Text = inventoryItem.siteID.ToString();
            lblName.Text = inventoryItem.name;
            lblQuantity.Text = inventoryItem.quantity.ToString();
            lblItemLocation.Text = inventoryItem.itemLocation;
            txtDescription.Text = inventoryItem.description;
            nudReorderThreshold.Value = inventoryItem.reorderThreshold;
            nudOptimumThreshold.Value = inventoryItem.optimumThreshold;
            txtNotes.Text = inventoryItem.notes;
        }

        //timer to close this form after 20 minutes
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void picHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This is the page for editing an inventory item. " +
                "The reorder threshold and notes for an item in your inventory can be edited here.", "Edit Inventory Help"
            , MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void EditInventory_KeyDown(object sender, KeyEventArgs e)
        {
            //if the F1 key is pressed down
            if (e.KeyCode == Keys.F1)
            {
                MessageBox.Show("This is the page for editing an inventory item. " +
                "The reorder threshold and notes for an item in your inventory can be edited here.", "Edit Inventory Help"
                , MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //variable for notes
            string notes = null;

            //if the notes textbox is not empty, then assign to the notes variable
            if (!txtNotes.Text.Equals(""))
            {
                notes = txtNotes.Text;
            }

            //if reorder threshold nud is below zero
            if (nudReorderThreshold.Value < 0 || nudReorderThreshold.Value > 100)
            {
                MessageBox.Show("Reorder Threshold can't be below 0 or above 100.", "Reorder Threshold Error");
                nudReorderThreshold.Focus();
                return;
            }

            //if notes text characters are over 255
            if (txtNotes.TextLength > 255)
            {
                MessageBox.Show("Maximum number of text characters for notes is 255.", "Notes Error");
                txtNotes.Focus();
                return;
            }

            DialogResult btnValueReturned = MessageBox.Show("Edited Inventory Item's Reorder Threshold: " +
                nudReorderThreshold.Value + "\n\nEdited Inventory Item's Notes: " +
                txtNotes.Text, "Confirm Inventory Item Edit",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            //if - user selects the yes btn
            if (btnValueReturned == DialogResult.Yes)
            {
                //create an inventory obj to be sent to the accessor update method
                Inventory inventoryEdited = new Inventory(inventoryItem.itemID, inventoryItem.siteID,
                    inventoryItem.quantity, inventoryItem.itemLocation, (int)nudReorderThreshold.Value,
                    inventoryItem.optimumThreshold, notes, inventoryItem.name, inventoryItem.description,
                    inventoryItem.siteName);

                //attempt to update the inventory
                bool goodUpdate = InventoryAccessor.UpdateInventoryItem(inventoryEdited);

                //if successful update
                if (goodUpdate)
                {
                    MessageBox.Show("Inventory has been updated in the system.", "Successful Inventory Update");

                    //close the form
                    this.Close();
                }
            }
        }
    }
}
