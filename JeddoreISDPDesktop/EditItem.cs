using JeddoreISDPDesktop.DAO_Classes;
using JeddoreISDPDesktop.Entity_Classes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using Image = System.Drawing.Image;
using Item = JeddoreISDPDesktop.Entity_Classes.Item;

namespace JeddoreISDPDesktop
{
    public partial class EditItem : Form
    {
        //class level/global variable for the employee object, and item object
        Employee employee = null;
        Item item = null;

        //get the last/most recent item in the DB
        Item itemLast = ItemAccessor.GetLastItem();

        public EditItem(Employee employeeLoggedIn, Item itemSelected)
        {
            InitializeComponent();
            employee = employeeLoggedIn;
            item = itemSelected;
        }

        public EditItem(Employee employeeLoggedIn)
        {
            InitializeComponent();
            employee = employeeLoggedIn;
        }

        private void EditItem_Load(object sender, System.EventArgs e)
        {
            //setting the tooltip for the help image
            toolTipHelp.SetToolTip(picHelp, "Click here for help.");

            //display the employee's username and location in this form
            lblUsername.Text = employee.username;
            lblLocation.Text = employee.siteName;

            //getting a list of suppliers
            List<Supplier> listSuppliers = SupplierAccessor.GetAllSuppliersList();

            //foreach loop thru the suppliers
            foreach (Supplier supplier in listSuppliers)
            {
                cboSuppliers.Items.Add(supplier.supplierID + " - " + supplier.name);
            }

            //getting a list of distinct categories
            List<string> listCategories = ItemAccessor.GetAllCategoriesList();

            //foreach loop thru the categories
            foreach (string category in listCategories)
            {
                cboCategories.Items.Add(category);
            }

            //if the item is not null
            if (item != null)
            {
                //display/populate the item labels and textboxes
                lblItemID.Text = item.itemID.ToString();
                txtName.Text = item.name;
                lblSKU.Text = item.sku;
                //lblCategory.Text = item.category;
                nudWeight.Value = item.weight;
                nudCaseSize.Value = item.caseSize;
                nudCostPrice.Value = item.costPrice;
                nudRetailPrice.Value = item.retailPrice;
                //lblSupplierID.Text = item.supplierID.ToString();
                txtDescription.Text = item.description;
                txtNotes.Text = item.notes;
                txtImageFileLocation.Text = item.imageFileLocation;

                //foreach loop thru the categories combobox
                foreach (var cboItem in cboCategories.Items)
                {
                    //if the category is a match, then select it and break
                    if (cboItem.ToString() == item.category)
                    {
                        cboCategories.SelectedItem = cboItem;

                        break;
                    }
                }

                //foreach loop thru the suppliers combobox
                foreach (var cboItem in cboSuppliers.Items)
                {
                    string[] result = cboItem.ToString().Split(' ');

                    //if the supplier ID is a match, then select it and break
                    if (result[0] == item.supplierID.ToString())
                    {
                        cboSuppliers.SelectedItem = cboItem;

                        break;
                    }
                }

                //check the checkbox depending on if the item is active or not
                //if item is NOT active
                if (item.active == 0)
                {
                    chkActive.Checked = false;
                }

                //if imageFileLocation for the item is NOT empty
                if (!item.imageFileLocation.Equals(""))
                {
                    //load the image in the picturebox based on the image's path
                    picItemImage.Image = Image.FromFile(@item.imageFileLocation);
                }
            }

            //else - the item is null
            else
            {
                //by default, just select the first index of each combobox
                cboCategories.SelectedIndex = 0;
                cboSuppliers.SelectedIndex = 0;

                //and check the active checkbox
                chkActive.Checked = true;

                //putting the new itemID and sku in their labels
                lblItemID.Text = (itemLast.itemID + 1).ToString();
                lblSKU.Text = (itemLast.sku + 1);

                //enable the two price nuds
                nudCostPrice.Enabled = true;
                nudRetailPrice.Enabled = true;
                nudCostPrice.Value = 0.99m;
                nudRetailPrice.Value = 0.99m;
                nudWeight.Value = 1m;
            }

            //focus on top enabled textbox (name)
            txtName.Focus();
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        //timer should close this form after 20 minutes
        private void timer1_Tick(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            //variables
            byte active = 0;
            string description = txtDescription.Text;
            string name = txtName.Text;
            string notes = txtNotes.Text;
            bool hasImage = false;
            decimal weight = nudWeight.Value;
            int caseSize = Convert.ToInt32(nudCaseSize.Value);

            //if item name is empty
            if (description.Equals(""))
            {
                MessageBox.Show("Item name shouldn't be empty.", "Empty Item Name");
                txtName.Focus();
                return;
            }

            //if item description is empty
            if (description.Equals(""))
            {
                MessageBox.Show("Item description shouldn't be empty.", "Empty Item Description");
                txtDescription.Focus();
                return;
            }

            //if notes text characters are over 255
            if (txtNotes.TextLength > 255)
            {
                MessageBox.Show("Maximum number of text characters for notes is 255.", "Notes Error");
                txtNotes.Focus();
                return;
            }

            //if the weight is under 0.01 or over 500
            if (weight < 0.01m || weight > 500m)
            {
                MessageBox.Show("Weight must be between 0.01 and 500.", "Weight Error");
                nudWeight.Focus();
                return;
            }

            //if the case size is under 1 or over 100
            if (caseSize < 1 || caseSize > 100)
            {
                MessageBox.Show("Case size must be between 1 and 100.", "Case Size Error");
                nudCaseSize.Focus();
                return;
            }

            //if no supplier is selected
            if (cboSuppliers.SelectedIndex < 0)
            {
                MessageBox.Show("Must select a valid supplier ID for the item from the suppliers combobox.", "Supplier ID Error");
                cboSuppliers.Focus();
                return;
            }

            //if no category is selected
            if (cboCategories.SelectedIndex < 0)
            {
                MessageBox.Show("Must select a valid category for the item from the categories combobox.", "Category Error");
                cboCategories.Focus();
                return;
            }

            //if active chkbox is checked, set active to 1
            if (chkActive.Checked)
            {
                active = 1;
            }

            //if txtbox for the image file location is NOT empty
            //then hasImage is true
            if (!txtImageFileLocation.Text.Equals(""))
            {
                hasImage = true;
            }

            //if the item is not null, so is an edit
            if (item != null)
            {
                string activeStatus = active == 1 ? "Active" : "Inactive";
                string strHasImage = hasImage == true ? "Yes" : "No";

                DialogResult btnValueReturned = MessageBox.Show("Edited Item's Description: " +
                    description + "\n\nEdited Item's Notes: " + notes +
                    "\n\nEdited Item's Status: " + activeStatus + "\n\nItem Has Image: " + strHasImage +
                    "\n\nConfirm Item Edit?", "Confirm Item Edit",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                //if - user selects the yes btn
                if (btnValueReturned == DialogResult.Yes)
                {
                    //get the supplier ID from that combobox
                    string[] result = cboSuppliers.Text.Split(' ');

                    int supplierID = int.Parse(result[0]);

                    //create an item obj to be sent to the accessor update method
                    Item itemEdited = new Item(item.itemID, name, item.sku,
                        description, cboCategories.Text, weight, caseSize,
                        item.costPrice, item.retailPrice, supplierID, active,
                        notes, txtImageFileLocation.Text);

                    //attempt to update the item
                    //bool goodUpdate = ItemAccessor.UpdateItemFields(itemEdited);
                    bool goodUpdate = ItemAccessor.UpdateProductItemFields(itemEdited);

                    //if successful update
                    if (goodUpdate)
                    {
                        MessageBox.Show("Product item has been updated in the system.", "Successful Item Update");

                        //close the form
                        this.Close();
                    }
                }
            }

            //else - the item is null, so are doing an insert
            else
            {
                string activeStatus = active == 1 ? "Active" : "Inactive";
                string strHasImage = hasImage == true ? "Yes" : "No";

                DialogResult btnValueReturned = MessageBox.Show("New Item's Description: " +
                    description + "\n\nNew Item's Notes: " + notes +
                    "\n\nNew Item's Status: " + activeStatus + "\n\nItem Has Image: " + strHasImage +
                    "\n\nConfirm New Item Addition?", "Confirm Item Addition",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                //if - user selects the yes btn
                if (btnValueReturned == DialogResult.Yes)
                {
                    //get the supplier ID from that combobox
                    string[] result = cboSuppliers.Text.Split(' ');

                    int supplierID = int.Parse(result[0]);

                    //create an item obj to be sent to the accessor insert method
                    Item itemNew = new Item(Convert.ToInt32(lblItemID.Text), name, lblSKU.Text,
                        description, cboCategories.Text, weight, caseSize,
                        nudCostPrice.Value, nudRetailPrice.Value, supplierID, active,
                        notes, txtImageFileLocation.Text);

                    //attempt to insert the item
                    bool goodInsert = ItemAccessor.InsertProductItem(itemNew);

                    //if successful update
                    if (goodInsert)
                    {
                        MessageBox.Show("New product item has been added to the system.", "Successful Item Addition");

                        //close the form
                        this.Close();
                    }
                }
            }
        }

        private void btnAddImageLink_Click(object sender, System.EventArgs e)
        {
            //ofd
            OpenFileDialog ofdImage = new OpenFileDialog();

            var codecs = ImageCodecInfo.GetImageEncoders();

            //want to set a filter - for valid image file extensions only
            var codecFilter = "Image Files|";

            //foreach loop to get valid image codecs/file extensions
            foreach (var codec in codecs)
            {
                codecFilter += codec.FilenameExtension + ";";
            }

            ofdImage.Filter = codecFilter;

            //if user clicks the OK btn
            if (ofdImage.ShowDialog() == DialogResult.OK)
            {
                //get the filename of the image
                string imageFilePath = ofdImage.FileName;

                //put the image path in the disabled txtbox
                txtImageFileLocation.Text = imageFilePath;

                //display image in the picture box
                picItemImage.Image = new Bitmap(ofdImage.FileName);
            }
        }

        private void picHelp_Click(object sender, System.EventArgs e)
        {
            MessageBox.Show("This is the form for editing a product item. The name, description, case size, notes, active status and more " +
            "fields for an item can be updated here." +
            "\n\nOptionally, an image can be selected to be associated with an item as well, " +
            "simply by clicking on the 'Add Item Image' button below and selecting a valid image file.", "Edit Item Help"
        , MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void EditItem_KeyDown(object sender, KeyEventArgs e)
        {
            //if the F1 key is pressed down
            if (e.KeyCode == Keys.F1)
            {
                MessageBox.Show("This is the form for editing a product item. The name, description, case size, notes, active status and more " +
                "fields for an item can be updated here." +
                "\n\nOptionally, an image can be selected to be associated with an item as well, " +
                "simply by clicking on the 'Add Item Image' button below and selecting a valid image file.", "Edit Item Help"
                , MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
