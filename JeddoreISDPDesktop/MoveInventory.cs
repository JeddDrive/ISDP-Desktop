using JeddoreISDPDesktop.DAO_Classes;
using JeddoreISDPDesktop.Entity_Classes;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace JeddoreISDPDesktop
{
    public partial class MoveInventory : Form
    {
        //class level/global variables for the employee object, and inventory object
        Employee employee = null;
        Inventory inventoryItem = null;

        public MoveInventory(Employee employeeLoggedIn, Inventory inventorySentIn)
        {
            InitializeComponent();
            employee = employeeLoggedIn;
            inventoryItem = inventorySentIn;
        }

        private void MoveInventory_Load(object sender, EventArgs e)
        {
            //setting the tooltip for the help image
            toolTipHelp.SetToolTip(picHelp, "Click here for help.");

            //display the employee's username and location in this form
            lblUsername.Text = employee.username;
            lblLocation.Text = employee.siteName;

            //getting item obj based on the inventory item's itemID
            //need the case size
            Item theItem = ItemAccessor.GetOneItem(inventoryItem.itemID);

            //display/populate the item labels and textboxes
            lblItemID.Text = inventoryItem.itemID.ToString();
            lblSiteID.Text = inventoryItem.siteID.ToString();
            lblName.Text = inventoryItem.name;
            lblItemLocation.Text = inventoryItem.itemLocation;
            txtDescription.Text = inventoryItem.description;
            txtNotes.Text = inventoryItem.notes;
            lblSiteNameLocation.Text = inventoryItem.siteName;
            lblSiteQuantity.Text = inventoryItem.quantity.ToString();
            lblCaseSize.Text = theItem.caseSize.ToString();

            //setting nud properties
            nudQuantityToMove.Increment = theItem.caseSize;
            nudQuantityToMove.Maximum = inventoryItem.quantity;
            nudQuantityToMove.Minimum = theItem.caseSize;
            nudQuantityToMove.Value = theItem.caseSize;

            //getting a list of all of the sites
            List<Site> sitesList = SiteAccessor.GetAllSitesList();

            //foreach loop
            foreach (Site site in sitesList)
            {
                //populate the site locations list box
                cboSiteLocations.Items.Add(site.siteID + " - " + site.name);
            }

            //populate the item locations combo box with these items here
            cboItemLocations.Items.Add("0");
            cboItemLocations.Items.Add("STOREFRON");
            cboItemLocations.Items.Add("STOREROOM");

            //select the first item in the item location combobox by default
            cboItemLocations.SelectedIndex = 0;

            //loop thru the site location combo box
            foreach (String siteLocation in cboSiteLocations.Items)
            {
                //split the string (item location) at each empty space
                string[] splitArray = siteLocation.Split(' ');

                //get the siteID from the array
                int siteID = int.Parse(splitArray[0]);

                //if siteID is a match
                if (siteID == inventoryItem.siteID)
                {
                    //then select this site location by default and break from the loop
                    cboSiteLocations.SelectedItem = siteLocation;

                    break;
                }
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
            MessageBox.Show("This is the page for moving an inventory item to a new location externally or internally. " +
            "A new site (external) and/or item location (internal) can be selected from the two combo boxes next to each other below.", "Move Inventory Help"
            , MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void MoveInventory_KeyDown(object sender, KeyEventArgs e)
        {
            //if the F1 key is pressed down
            if (e.KeyCode == Keys.Enter)
            {
                MessageBox.Show("This is the page for moving an inventory item to a new location externally or internally. " +
                "A new site (external) and/or item location (internal) can be selected from the two combo boxes next to each other below.", "Move Inventory Help"
                , MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //if valid selection in both combo boxes then
            if (cboSiteLocations.SelectedIndex > -1 && cboItemLocations.SelectedIndex > -1)
            {
                //get the text from the site combobox for the selected item
                string siteText = cboSiteLocations.GetItemText(cboSiteLocations.SelectedItem);

                //split the string at each empty space
                string[] splitArray = siteText.Split(' ');

                //get the siteID from the array
                int siteIDNew = int.Parse(splitArray[0]);

                //get the item location from the other combobox
                string itemLocation = cboItemLocations.Text;

                //get the quantity to move from the nud - and convert from decimal to an int
                int quantityToMove = Convert.ToInt32(nudQuantityToMove.Value);

                //update - move item's quantity to new location
                bool success1 = InventoryAccessor.UpdateInventoryToNewLocation(quantityToMove, itemLocation,
                    siteIDNew, inventoryItem.itemID);

                //update - the old location quantity
                bool success2 = InventoryAccessor.UpdateInventoryFromOldLocation(quantityToMove, inventoryItem.siteID,
                    inventoryItem.itemID);

                //if success with both updates AND internal move only (same siteID), then display msg and close this form
                if (success1 && success2 && siteIDNew == inventoryItem.siteID)
                {
                    MessageBox.Show("Internal move of inventory detected. Full quantity of " + inventoryItem.quantity + " for item " + inventoryItem.itemID + " has been successfully moved to item location: " + cboItemLocations.Text +
                        " at site: " + cboSiteLocations.Text + ".", "Inventory Move Successful");

                    this.Close();
                }

                //else if - success with both updates (external move), then display msg and close this form
                else if (success1 && success2)
                {
                    MessageBox.Show("Quantity of " + quantityToMove + " for item " + inventoryItem.itemID + " has been successfully moved externally to site: " + cboSiteLocations.Text +
                        " and item location: " + cboItemLocations.Text + ".", "Inventory Move Successful");

                    this.Close();
                }
            }
        }
    }
}
