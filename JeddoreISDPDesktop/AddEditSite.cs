using JeddoreISDPDesktop.DAO_Classes;
using JeddoreISDPDesktop.Entity_Classes;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Site = JeddoreISDPDesktop.Entity_Classes.Site;

namespace JeddoreISDPDesktop
{
    public partial class AddEditSite : Form
    {
        //class level/global variable for the one employee object and one site object
        Employee employee = null;
        Site siteEdit = null;

        //two constructors for this form - one for adding a site, and the other for editing a site
        public AddEditSite(Employee employeeLoggedIn, Site inSiteEdit)
        {
            InitializeComponent();
            employee = employeeLoggedIn;
            siteEdit = inSiteEdit;
        }

        public AddEditSite(Employee employeeLoggedIn)
        {
            InitializeComponent();
            employee = employeeLoggedIn;
        }

        private void AddEditSite_Load(object sender, EventArgs e)
        {
            //list of provinces from the province accessor
            List<Province> provincesList = ProvinceAccessor.GetAllProvincesList();

            //countries hashset - for unique countries only (string)
            HashSet<string> countriesHashSet = new HashSet<string>();

            //list of delivery days
            List<string> deliveryDaysList = new List<string>() { "SUNDAY", "MONDAY", "TUESDAY",
            "WEDNESDAY", "THURSDAY", "FRIDAY", "SATURDAY"};

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

            //foreach loop thru deliveryDaysList
            foreach (string day in deliveryDaysList)
            {
                cboDeliveryDays.Items.Add(day);
            }

            //if site to be edited is null - so are adding a site
            if (siteEdit == null)
            {
                //auto select the items in these cboboxes
                cboCountries.SelectedIndex = 0;
                cboProvinces.SelectedItem = "NB";
                cboDeliveryDays.SelectedItem = "MONDAY";

                //get the last site in the DB
                //we want to get the site with the highest current site ID
                Site lastSite = SiteAccessor.GetLastSite();

                //int for site ID for new site
                int newID = lastSite.siteID + 1;

                //put this inside the disabled label
                lblSiteID.Text = newID.ToString();
            }

            //else - are EDITING a site
            else
            {
                //put properties of siteEdit into their respective labels, txtboxes, and cboboxes
                lblSiteID.Text = siteEdit.siteID.ToString();
                txtName.Text = siteEdit.name;
                txtCity.Text = siteEdit.city;
                txtAddress.Text = siteEdit.address;
                txtPostalCode.Text = siteEdit.postalCode;
                txtPhone.Text = siteEdit.phone;
                txtNotes.Text = siteEdit.notes;
                cboProvinces.SelectedItem = siteEdit.provinceID;
                cboCountries.SelectedItem = siteEdit.country;
                cboDeliveryDays.SelectedItem = siteEdit.dayOfWeek;
                nudDistance.Value = siteEdit.distanceFromWH;

                //if site is not active, then uncheck the checkbox
                if (siteEdit.active == 0)
                {
                    chkActive.Enabled = false;
                }
            }

            //focus on top txtbox
            txtName.Focus();
        }

        private void picHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This is the page for adding or editing a site. " +
            "Please ensure to type in a valid location name, city, address, and postal code for a site if adding a new one." +
            " Optionally, miscellaneous notes can also be added or edited for a site at the bottom of this page.", "Add/Edit Site Help"
            , MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void AddEditSite_KeyDown(object sender, KeyEventArgs e)
        {
            //if the F1 key is pressed down
            if (e.KeyCode == Keys.F1)
            {
                MessageBox.Show("This is the page for adding or editing a site. " +
                "Please ensure to type in a valid location name, city, address, and postal code for a site if adding a new one." +
                " Optionally, miscellaneous notes can also be added or edited for a site at the bottom of this page.", "Add/Edit Site Help"
                , MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //timer should close this form after 20 minutes
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
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

            //if address is empty
            if (txtAddress.Text.Equals(""))
            {
                //display the error message
                MessageBox.Show("Address can't be empty.", "Valid Address Required");

                //focus on txtbox
                txtAddress.Focus();

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
            if (cboProvinces.SelectedIndex < 0 || cboCountries.SelectedIndex < 0 ||
                cboDeliveryDays.SelectedIndex < 0)
            {
                //display the error message
                MessageBox.Show("Must select valid options from all three comboboxes.", "Valid Selections Required");

                return;
            }

            //if - nud is below 0
            if (nudDistance.Value < 0)
            {
                //display the error message
                MessageBox.Show("Distance from Warehouse can't be below 0 kms.", "Valid Distance from WH Required");

                //focus on txtbox
                nudDistance.Focus();

                return;
            }

            //if notes text characters are over 255
            if (txtNotes.TextLength > 255)
            {
                MessageBox.Show("Maximum number of text characters for notes is 255.", "Notes Error");
                txtNotes.Focus();
                return;
            }

            //if siteEdit is null, so are doing an ADD
            //are also checking for valid phone number and postal code
            if (siteEdit == null)
            {
                DialogResult btnValueReturned = MessageBox.Show("New site's name: " + txtName.Text +
                "\nNew site's address: " + txtAddress.Text + "\nNew site's city: " + txtCity.Text +
                "\n\nFinalize Site Creation?", "Confirm New Site Creation",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                //if - user selects the yes btn
                if (btnValueReturned == DialogResult.Yes)
                {
                    //create a site obj to be sent to the accessor class
                    Site siteNew = new Site(int.Parse(lblSiteID.Text), txtName.Text,
                        cboProvinces.Text, txtAddress.Text, null,
                        txtCity.Text, cboCountries.Text, txtPostalCode.Text,
                        txtPhone.Text, cboDeliveryDays.Text, (int)nudDistance.Value,
                        notes, active); ;

                    //attempt to insert the site
                    bool goodInsert = SiteAccessor.InsertNewSite(siteNew);

                    //if successful
                    if (goodInsert)
                    {
                        MessageBox.Show("Site has been added to the system.", "Successful New Site Addition");

                        //close the form
                        this.Close();
                    }
                }
            }

            //else -  siteEdit is NOT null, so are doing an EDIT
            else
            {
                DialogResult btnValueReturned = MessageBox.Show("Edited site's name: " + txtName.Text +
                "\nEdited site's address: " + txtAddress.Text + "\nEdited site's city: " + txtCity.Text +
                "\n\nFinalize Site Edit?", "Confirm Site Edit",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                //if - user selects the yes btn
                if (btnValueReturned == DialogResult.Yes)
                {
                    //create a site obj to be sent to the accessor class
                    Site siteNew = new Site(int.Parse(lblSiteID.Text), txtName.Text,
                        cboProvinces.Text, txtAddress.Text, siteEdit.address2,
                        txtCity.Text, cboCountries.Text, txtPostalCode.Text,
                        txtPhone.Text, cboDeliveryDays.Text, (int)nudDistance.Value,
                        notes, active);

                    //attempt to update the site
                    bool goodUpdate = SiteAccessor.UpdateSiteFields(siteNew);

                    //if successful
                    if (goodUpdate)
                    {
                        MessageBox.Show("Site has been edited in the system.", "Successful Site Edit");

                        //close the form
                        this.Close();
                    }
                }
            }
        }
    }
}
