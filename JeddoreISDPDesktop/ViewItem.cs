using JeddoreISDPDesktop.DAO_Classes;
using JeddoreISDPDesktop.Entity_Classes;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace JeddoreISDPDesktop
{
    public partial class ViewItem : Form
    {
        //class level/global variable for the employee object, and item object
        Employee employee = null;
        Item item = null;

        public ViewItem(Employee employeeLoggedIn, Item itemSelected)
        {
            InitializeComponent();
            employee = employeeLoggedIn;
            item = itemSelected;
        }

        private void ViewItem_Load(object sender, EventArgs e)
        {
            //setting the tooltip for the help image
            toolTipHelp.SetToolTip(picHelp, "Click here for help.");

            //display the employee's username and location in this form
            lblUsername.Text = employee.username;
            lblLocation.Text = employee.siteName;

            //get the item's supplier, based on the supplier ID
            Supplier itemSupplier = SupplierAccessor.GetOneSupplier(item.supplierID);

            //if the item is NOT null
            if (item != null)
            {
                //if the item is NOT active, then uncheck the checkbox
                if (item.active == 0)
                {
                    chkActive.Checked = false;
                }

                //if the imageFileLocation for the item is NOT empty
                if (!item.imageFileLocation.Equals(""))
                {
                    //load the image in the picturebox based on the image's path
                    picItemImage.Image = Image.FromFile(@item.imageFileLocation);
                }

                //display/populate the item labels and textboxes
                lblItemID.Text = item.itemID.ToString();
                lblName.Text = item.name;
                lblSKU.Text = item.sku;
                lblCategory.Text = item.category;
                lblWeight.Text = item.weight.ToString();
                lblCaseSize.Text = item.caseSize.ToString();
                lblCostPrice.Text = item.costPrice.ToString("c2");
                lblRetailPrice.Text = item.retailPrice.ToString("c2");
                lblSupplierID.Text = itemSupplier.supplierID.ToString() + " - " + itemSupplier.name;
                lblDescription.Text = item.description;
                txtNotes.Text = item.notes;
                txtImageFileLocation.Text = item.imageFileLocation;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
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
            MessageBox.Show("This is the form for viewing details about a product item. The name, description, case size, notes, active status and more " +
            "fields for an item can be viewed here." +
            "\n\nAdditionally, an item image can be viewed here if one has been added and is associated with the selected item.", "View Item Info Help"
            , MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ViewItem_KeyDown(object sender, KeyEventArgs e)
        {
            //if the F1 key is pressed down
            if (e.KeyCode == Keys.F1)
            {
                MessageBox.Show("This is the form for viewing details about a product item. The name, description, case size, notes, active status and more " +
                "fields for an item can be viewed here." +
                "\n\nAdditionally, an item image can be viewed here if one has been added and is associated with the selected item.", "View Item Info Help"
                , MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
