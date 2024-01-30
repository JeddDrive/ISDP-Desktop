using JeddoreISDPDesktop.DAO_Classes;
using JeddoreISDPDesktop.Entity_Classes;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using Item = JeddoreISDPDesktop.Entity_Classes.Item;

namespace JeddoreISDPDesktop
{
    public partial class EditItem : Form
    {
        //class level/global variable for the employee object, and item object
        Employee employee = null;
        Item item = null;

        public EditItem(Employee employeeLoggedIn, Item itemSelected)
        {
            InitializeComponent();
            employee = employeeLoggedIn;
            item = itemSelected;
        }

        private void EditItem_Load(object sender, System.EventArgs e)
        {
            //display the employee's username and location in this form
            lblUsername.Text = employee.username;
            lblLocation.Text = employee.siteName;

            //display/populate the item labels
            lblItemID.Text = item.itemID.ToString();
            lblName.Text = item.name;
            lblSKU.Text = item.sku;
            lblCategory.Text = item.category;
            lblWeight.Text = item.weight.ToString();
            lblCaseSize.Text = item.caseSize.ToString();
            lblCostPrice.Text = item.costPrice.ToString();
            lblRetailPrice.Text = item.retailPrice.ToString();
            lblSupplierID.Text = item.supplierID.ToString();
            txtDescription.Text = item.description;
            txtNotes.Text = item.notes;
            txtImageFileLocation.Text = item.imageFileLocation;

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

            //focus on top enabled textbox (description)
            txtDescription.Focus();
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
            string notes = txtNotes.Text;
            bool hasImage = false;

            //if item description is empty
            if (description.Equals(""))
            {
                MessageBox.Show("Item description shouldn't be empty.", "Empty Item Description");
                txtDescription.Focus();
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
                //create an item obj to be sent to the accessor update method
                Item itemEdited = new Item(item.itemID, item.name, item.sku,
                    description, item.category, item.weight, item.caseSize,
                    item.costPrice, item.retailPrice, item.supplierID, active,
                    notes, txtImageFileLocation.Text);

                //attempt to update the item
                bool goodUpdate = ItemAccessor.UpdateItemFields(itemEdited);

                //if successful update
                if (goodUpdate)
                {
                    MessageBox.Show("Item has been updated in the system.", "Successful Item Update");

                    //close the form
                    this.Close();
                }
            }
        }

        private void btnAddImageLink_Click(object sender, System.EventArgs e)
        {
            //ofd
            OpenFileDialog ofdImage = new OpenFileDialog();

            var codecs = ImageCodecInfo.GetImageEncoders();

            //want to set a filter - for valid image file extensions ONLY
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
    }
}
