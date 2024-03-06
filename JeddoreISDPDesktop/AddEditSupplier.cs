using JeddoreISDPDesktop.DAO_Classes;
using JeddoreISDPDesktop.Entity_Classes;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace JeddoreISDPDesktop
{
    public partial class AddEditSupplier : Form
    {
        //class level/global variable for the one employee object and one site object
        Employee employee = null;
        Supplier supplierEdit = null;

        //two constructors for this form - one for adding a supplier, and the other for editing a supplier
        public AddEditSupplier(Employee employeeLoggedIn, Supplier inSupplierEdit)
        {
            InitializeComponent();
            employee = employeeLoggedIn;
            supplierEdit = inSupplierEdit;
        }

        public AddEditSupplier(Employee employeeLoggedIn)
        {
            InitializeComponent();
            employee = employeeLoggedIn;
        }

        private void AddEditSupplier_Load(object sender, EventArgs e)
        {
            //list of provinces from the province accessor
            List<Province> provincesList = ProvinceAccessor.GetAllProvincesList();

            //countries hashset - for unique countries only (string)
            HashSet<string> countriesHashSet = new HashSet<string>();

            //setting the tooltip for the help image
            toolTipHelp.SetToolTip(picHelp, "Click here for help.");

            //display the employee's username and location in this form
            lblUsername.Text = employee.username;
            lblLocation.Text = employee.siteName;

            //foreach loop thru provincesList
            foreach (Province province in provincesList)
            {
                //add each province ID to the provinces combobox
                cboProvinces.Items.Add(province.provinceID);

                //add each country to the countries hash set - unique strings only
                countriesHashSet.Add(province.countryCode);
            }

            //foreach loop thru countriesHashSet
            foreach (string country in countriesHashSet)
            {
                cboCountries.Items.Add(country);
            }

            //if supplier to be edited is null - so are adding a supplier
            if (supplierEdit == null)
            {
                //auto select the items in these cboboxes
                cboCountries.SelectedIndex = 0;
                cboProvinces.SelectedItem = "NB";

                //get the last supplier in the DB
                //we want to get the supplier with the highest current supplier ID
                Supplier lastSupplier = SupplierAccessor.GetLastSupplier();

                //int for supplier ID for new supplier
                int newID = lastSupplier.supplierID + 1;

                //put this inside the disabled label
                lblSupplierID.Text = newID.ToString();

                //also disable the active checkbox and check it
                chkActive.Enabled = false;
                chkActive.Checked = true;
            }

            //else - are EDITING a supplier
            else
            {
                //put properties of supplierEdit into their respective labels, txtboxes, and cboboxes
                lblSupplierID.Text = supplierEdit.supplierID.ToString();
                txtName.Text = supplierEdit.name;
                txtCity.Text = supplierEdit.city;
                txtAddress1.Text = supplierEdit.address1;
                txtAddress2.Text = supplierEdit.address2;
                txtPostalCode.Text = supplierEdit.postalCode;
                txtPhone.Text = supplierEdit.phone;
                txtContact.Text = supplierEdit.contact;
                txtNotes.Text = supplierEdit.notes;
                cboProvinces.SelectedItem = supplierEdit.province;
                cboCountries.SelectedItem = supplierEdit.country;

                //if site is not active, then uncheck the checkbox
                if (supplierEdit.active == 0)
                {
                    chkActive.Enabled = false;
                }
            }

            //focus on top txtbox
            txtName.Focus();
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
            MessageBox.Show("This is the page for adding or editing a supplier. " +
            "\n\nPlease ensure to type in a valid supplier name, address (address 1), and phone number and postal code for a supplier if adding a new one." +
            "\n\nOptionally, miscellaneous notes and a supplier contact can also be added or edited for a supplier at the bottom of this form.", "Add/Edit Supplier Help"
            , MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void AddEditSupplier_KeyDown(object sender, KeyEventArgs e)
        {
            //if the F1 key is pressed down
            if (e.KeyCode == Keys.F1)
            {
                MessageBox.Show("This is the page for adding or editing a supplier. " +
                "\n\nPlease ensure to type in a valid supplier name, address (address 1), and phone number and postal code for a supplier if adding a new one." +
                "\n\nOptionally, miscellaneous notes and a supplier contact can also be added or edited for a supplier at the bottom of this form.", "Add/Edit Supplier Help"
                , MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //regex for numbers only (for the phone number)
            var numbersOnlyRegex = new Regex("^[0-9]+$");

            //regex for valid Canadian postal code
            //space in the middle is optional
            var postalCodeRegex = new Regex("^[ABCEGHJKLMNPRSTVXY][0-9][ABCEGHJKLMNPRSTVWXYZ] " +
                "?[0-9][ABCEGHJKLMNPRSTVWXYZ][0-9]$");

            //variable for notes
            string notes = txtNotes.Text;

            //variable (byte) for active
            byte active = 0;

            //if the checkbox is checked, then active should be 1
            if (chkActive.Checked)
            {
                active = 1;
            }

            //if notes textbox if empty, then set notes to null
            if (notes.Equals(""))
            {
                notes = null;
            }

            //if name is empty
            if (txtName.Text.Equals(""))
            {
                //display the error message
                MessageBox.Show("Location name can't be empty.", "Valid Location Name Required");

                //focus on txtbox
                txtName.Focus();

                return;
            }

            //if address 1 is empty
            if (txtAddress1.Text.Equals(""))
            {
                //display the error message
                MessageBox.Show("Address can't be empty.", "Valid Address Required");

                //focus on txtbox
                txtAddress1.Focus();

                return;
            }

            //if city is empty
            if (txtCity.Text.Equals(""))
            {
                //display the error message
                MessageBox.Show("City can't be empty.", "Valid City Required");

                //focus on txtbox
                txtCity.Focus();

                return;
            }

            //if phone is empty or not a match
            if (txtPhone.Text.Equals("") || !numbersOnlyRegex.IsMatch(txtPhone.Text))
            {
                //display the error message
                MessageBox.Show("Phone can't be empty, and must match the following pattern:" +
                    "\n\nAll numbers with no spaces or brackets ex. 0123456789", "Valid Phone Number Required");

                //focus on txtbox
                txtPhone.Focus();

                return;
            }

            //if postal code is empty or not a match
            if (txtPostalCode.Text.Equals("") || !postalCodeRegex.IsMatch(txtPostalCode.Text))
            {
                //display the error message
                MessageBox.Show("Postal code can't be empty, and must match the pattern of a valid Canadian postal code.", "Valid Postal Code Required");

                //focus on txtbox
                txtPostalCode.Focus();

                return;
            }

            //if - checking for cbo selections
            if (cboProvinces.SelectedIndex < 0 || cboCountries.SelectedIndex < 0)
            {
                //display the error message
                MessageBox.Show("Must select a valid option from both comboboxes.", "Valid Selections Required");

                return;
            }

            //if notes text characters are over 255
            if (txtNotes.TextLength > 255)
            {
                MessageBox.Show("Maximum number of text characters for notes is 255.", "Notes Error");
                txtNotes.Focus();
                return;
            }

            //if supplierEdit is null, so are doing an ADD
            if (supplierEdit == null)
            {
                DialogResult btnValueReturned = MessageBox.Show("New supplier's name: " + txtName.Text +
                "\nNew supplier's address: " + txtAddress1.Text + "\nNew supplier's city: " + txtCity.Text +
                "\n\nFinalize Supplier Creation?", "Confirm New Supplier Creation",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                //if - user selects the yes btn
                if (btnValueReturned == DialogResult.Yes)
                {
                    //create a supplier obj to be sent to the accessor class
                    Supplier supplierNew = new Supplier(int.Parse(lblSupplierID.Text), txtName.Text,
                        txtAddress1.Text, txtAddress2.Text, txtCity.Text, cboCountries.Text,
                        cboProvinces.Text, txtPostalCode.Text, txtPhone.Text, txtContact.Text, notes, active);

                    //attempt to insert the supplier
                    bool goodInsert = SupplierAccessor.InsertNewSupplier(supplierNew);

                    //if successful
                    if (goodInsert)
                    {
                        MessageBox.Show("Supplier has been added to the system.", "Successful New Supplier Addition");

                        //close the form
                        this.Close();
                    }
                }
            }

            //else -  supplierEdit is NOT null, so are doing an EDIT
            else
            {
                DialogResult btnValueReturned = MessageBox.Show("Edited supplier's name: " + txtName.Text +
                "\nEdited supplier's address: " + txtAddress1.Text + "\nEdited supplier's city: " + txtCity.Text +
                "\n\nFinalize Supplier Edit?", "Confirm Supplier Edit",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                //if - user selects the yes btn
                if (btnValueReturned == DialogResult.Yes)
                {
                    //create a supplier obj to be sent to the accessor class
                    Supplier supplierEdit = new Supplier(int.Parse(lblSupplierID.Text), txtName.Text,
                        txtAddress1.Text, txtAddress2.Text, txtCity.Text, cboCountries.Text,
                        cboProvinces.Text, txtPostalCode.Text, txtPhone.Text, txtContact.Text, notes, active);

                    //attempt to update the supplier
                    bool goodUpdate = SupplierAccessor.UpdateSupplierFields(supplierEdit);

                    //if successful
                    if (goodUpdate)
                    {
                        MessageBox.Show("Supplier has been edited in the system.", "Successful Supplier Edit");

                        //close the form
                        this.Close();
                    }
                }
            }
        }
    }
}
