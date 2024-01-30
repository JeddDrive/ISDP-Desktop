using JeddoreISDPDesktop.DAO_Classes;
using JeddoreISDPDesktop.Entity_Classes;
using JeddoreISDPDesktop.Helper_Classes;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace JeddoreISDPDesktop
{
    public partial class AddEditUser : Form
    {
        //class level const for the email domain
        private const string EMAILDOMAIN = "@bullseye.ca";

        //class level/global variable for two employee objects from the user management page
        Employee employee = null;
        Employee employeeEdit = null;

        //class level variable for username and email
        string username = "";
        string email = "";

        //two constructors for this form - one for adding a user, and the other for editing a user
        public AddEditUser(Employee employeeLoggedIn)
        {
            InitializeComponent();
            employee = employeeLoggedIn;
        }

        public AddEditUser(Employee employeeLoggedIn, Employee employeeToBeEdited)
        {
            InitializeComponent();
            employee = employeeLoggedIn;
            employeeEdit = employeeToBeEdited;
        }

        private void AddEditUser_Load(object sender, EventArgs e)
        {
            //display the employee's username and location in this form
            lblUsername.Text = employee.username;
            lblLocation.Text = employee.siteName;

            txtEmail.Text = EMAILDOMAIN;

            //get a list of all positions
            List<Posn> positionsList = PosnAccessor.GetAllPositionsList();

            //get a list of all sites
            List<Site> sitesList = SiteAccessor.GetAllSitesList();

            //foreach loop thru positionsList
            foreach (var position in positionsList)
            {
                cboPosition.Items.Add(position.positionID + " - " + position.permissionLevel);
            }

            //foreach loop thru sitesList
            foreach (var site in sitesList)
            {
                cboLocation.Items.Add(site.siteID + " - " + site.name);
            }

            //if employee to be edited is null - so are adding a user
            if (employeeEdit == null)
            {
                //put the default password in the disabled txtbox for password
                txtPassword.Text = "P@ssw0rd-";

                //focus on the top txtbox for adding (first name)
                txtFirstName.Focus();

                //get the last employee in the DB
                //we want to get the employee with the highest current employee ID
                Employee lastEmployee = EmployeeAccessor.GetLastEmployee();

                //int for employee ID for new employee/user
                int newID = lastEmployee.employeeID + 1;

                //put this inside the disabled label
                lblEmployeeID.Text = newID.ToString();
            }

            //else - are editing a user
            else
            {
                //put properties of employeeEdit into their respective labels, txtboxes, and cboboxes
                lblEmployeeID.Text = employeeEdit.employeeID.ToString();
                txtFirstName.Text = employeeEdit.firstName;
                txtLastName.Text = employeeEdit.lastName;
                txtUsername2.Text = employeeEdit.username;
                txtEmail.Text = employeeEdit.email;
                txtUsername2.Enabled = true;
                txtEmail.Enabled = true;
                cboLocation.SelectedIndex = employeeEdit.siteID - 1;

                //enable the password txtbox
                txtPassword.Enabled = true;

                //for now - are putting the hashed password in that textbox
                //NOTE: may remove this later
                txtPassword.Text = employeeEdit.password;

                //focus on the top txtbox for adding (username2)
                txtUsername2.Focus();

                //if positionID is not 99999999
                if (employeeEdit.positionID != 99999999)
                {
                    cboPosition.SelectedIndex = employeeEdit.positionID - 1;
                }

                //else - positionID is 99999999 (admin)
                else
                {
                    cboPosition.SelectedIndex = cboPosition.Items.Count - 1;
                }

                //if employee is not active, uncheck the checkbox
                if (employee.active == 0)
                {
                    chkActive.Checked = false;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void picEyeShow_Click(object sender, EventArgs e)
        {
            //show password chars ftn
            PasswordCharacters.ShowPasswordChars(txtPassword, picEyeShow, picEyeHide);
        }

        private void picEyeHide_Click(object sender, EventArgs e)
        {
            //hide password chars ftn
            PasswordCharacters.HidePasswordChars(txtPassword, picEyeShow, picEyeHide);
        }

        //text changed event for the last name txtbox
        private void txtLastName_TextChanged(object sender, EventArgs e)
        {
            //call update username and email text ftn
            UpdateUsernameAndEmailText();
        }

        //this ftn updates the username and email labels based on what they type into the
        //first name and last name textboxes
        private void UpdateUsernameAndEmailText()
        {
            char firstCharacter;

            if (txtFirstName.Text != "")
            {
                firstCharacter = txtFirstName.Text[0];

                //set username variable
                //want to lowercase the entire username
                username = (firstCharacter.ToString() + txtLastName.Text).ToLower();

                //set email variable
                email = username + EMAILDOMAIN;
            }

            //set email textbox to the email variable
            txtEmail.Text = email;

            //set username2 textbox to the username variable
            txtUsername2.Text = username;
        }

        //text changed event for the first name txtbox
        private void txtFirstName_TextChanged(object sender, EventArgs e)
        {
            //call update username and email text ftn
            UpdateUsernameAndEmailText();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //if employeeEdit is null, meaning are doing an ADD
            if (employeeEdit == null)
            {
                //byte var for active
                byte active = 0;

                //if either cbo is blank
                if (cboPosition.SelectedIndex < 0 || cboLocation.SelectedIndex < 0)
                {
                    //display the error message
                    MessageBox.Show("Must select a position and location for a new user.", "No Site and/or Location");

                    return;
                }

                //get the position and site/location IDs from the comboboxes
                int positionID = int.Parse(cboPosition.SelectedItem.ToString().Split(' ')[0]);
                int siteID = int.Parse(cboLocation.SelectedItem.ToString().Split(' ')[0]);

                //MessageBox.Show(positionID.ToString() + "\n" + siteID.ToString());

                //if checkbox is checked, then active should be 1
                if (chkActive.Checked)
                {
                    active = 1;
                }

                //if first name is empty
                if (txtFirstName.TextLength == 0)
                {
                    //display the error message
                    MessageBox.Show("User's first name can't be empty.", "Valid First Name Required");

                    //focus on txtbox
                    txtFirstName.Focus();

                    return;
                }

                //if last name is empty
                if (txtLastName.TextLength == 0)
                {
                    //display the error message
                    MessageBox.Show("User's last name can't be empty.", "Valid Last Name Required");

                    //focus on txtbox
                    txtLastName.Focus();

                    return;
                }

                //checking the count of existing users with the username generated
                long userCountWithUsername = EmployeeAccessor.GetCountWithTheUsername(username);

                //if that ftn returned greater than 0, then must assign a number to the username and email
                //ex. adding a 01 to the end if a 1 was returned
                if (userCountWithUsername > 0)
                {
                    //convert the int to a string
                    string userCountWithUsernameString = "0" + userCountWithUsername.ToString();

                    //update the username to add the number at the end of it
                    username += userCountWithUsernameString;

                    //also must update the email
                    email = username + EMAILDOMAIN;
                }

                //MessageBox.Show(userCountWithUsername.ToString() + "\n" + username + "\n" + email);

                //checking for validated password
                //if not validated
                if (!PasswordCharacters.ValidatePassword(txtPassword.Text, out string errorMessage))
                {
                    //display the error message
                    MessageBox.Show(errorMessage, "Password Validation Failure");

                    //focus on txtbox
                    txtPassword.Focus();
                }

                //else - password is validated
                else
                {
                    DialogResult btnValueReturned = MessageBox.Show("New user's username: " + username +
                        "\nNew User's email: " + email + "\n\nFinalize User Creation?", "Confirm New User Creation",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    //if - user selects the yes btn
                    if (btnValueReturned == DialogResult.Yes)
                    {
                        //new user will need a salt for their password - get one
                        string newSalt = PasswordEncrypter.GetSalt();

                        //now get a new hashed password - based on the raw password and new salt text
                        string newHash = PasswordEncrypter.GetHash(txtPassword.Text + newSalt);

                        //create an employee obj to be sent to the accessor class
                        Employee emp = new Employee(int.Parse(lblEmployeeID.Text), newHash,
                            txtFirstName.Text, txtLastName.Text, email, active, positionID, siteID,
                            0, username, null, null, null, 3, 0);

                        //attempt to insert the employee
                        bool goodInsert = EmployeeAccessor.InsertNewEmployee(emp);

                        bool goodSaltUpdate = PasswordSaltAccessor.InsertPasswordSalt(newSalt, emp.employeeID);

                        //if successful
                        if (goodInsert && goodSaltUpdate)
                        {
                            MessageBox.Show("User has been added to the system.", "Successful New User Addition");

                            //close the form
                            this.Close();
                        }
                    }
                }
            }

            //else - are doing an EDIT
            else
            {
                //byte var for active
                byte active = 0;

                //if either cbo is blank
                if (cboPosition.SelectedIndex < 0 || cboLocation.SelectedIndex < 0)
                {
                    //display the error message
                    MessageBox.Show("Must select a position and location for a user.", "No Site and/or Location");

                    return;
                }

                //get the position and site/location IDs from the comboboxes
                int positionID = int.Parse(cboPosition.SelectedItem.ToString().Split(' ')[0]);
                int siteID = int.Parse(cboLocation.SelectedItem.ToString().Split(' ')[0]);

                //MessageBox.Show(positionID.ToString() + "\n" + siteID.ToString());

                //if checkbox is checked, then active should be 1
                if (chkActive.Checked)
                {
                    active = 1;
                }

                //if first name is empty
                if (txtFirstName.TextLength == 0)
                {
                    //display the error message
                    MessageBox.Show("User's first name can't be empty.", "Valid First Name Required");

                    //focus on txtbox
                    txtFirstName.Focus();

                    return;
                }

                //if last name is empty
                if (txtLastName.TextLength == 0)
                {
                    //display the error message
                    MessageBox.Show("User's last name can't be empty.", "Valid Last Name Required");

                    //focus on txtbox
                    txtLastName.Focus();

                    return;
                }

                //checking the count of existing users with the username generated
                long userCountWithUsername = EmployeeAccessor.GetCountWithTheUsername(username);

                //if that ftn returned greater than 0, then must assign a number to the username and email
                //ex. adding a 01 to the end if a 1 was returned
                if (userCountWithUsername > 0)
                {
                    //convert the int to a string
                    string userCountWithUsernameString = "0" + userCountWithUsername.ToString();

                    //update the username to add the number at the end of it
                    username += userCountWithUsernameString;

                    //also must update the email
                    email = username + EMAILDOMAIN;
                }

                //MessageBox.Show(userCountWithUsername.ToString() + "\n" + username + "\n" + email);

                //checking for validated password
                //if not validated
                if (!PasswordCharacters.ValidatePassword(txtPassword.Text, out string errorMessage)
                    && txtPassword.Text != employeeEdit.password)
                {
                    //display the error message
                    MessageBox.Show(errorMessage, "Password Validation Failure");

                    //focus on txtbox
                    txtPassword.Focus();
                }

                //else - password is validated
                else
                {
                    DialogResult btnValueReturned = MessageBox.Show("Edited user's username: " + username +
                        "\nEdited User's email: " + email + "\n\nFinalize User Modification?", "Confirm Existing User Modification",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    //if - user selects the yes btn and the user's password has been edited then
                    //so they will need a new salt and hash for their new raw password
                    if (btnValueReturned == DialogResult.Yes && txtPassword.Text != employeeEdit.password)
                    {
                        //new user will need a salt for their password - get one
                        string newSalt = PasswordEncrypter.GetSalt();

                        //now get a new hashed password - based on the raw password and new salt text
                        string newHash = PasswordEncrypter.GetHash(txtPassword.Text + newSalt);

                        //create an employee obj to be sent to the accessor class
                        Employee emp = new Employee(int.Parse(lblEmployeeID.Text), newHash,
                            txtFirstName.Text, txtLastName.Text, email, active, positionID, siteID,
                            0, username, null, null, null, 3, 0);

                        //attempt to insert the employee
                        bool goodEmployeeUpdate = EmployeeAccessor.UpdateEmployeeFields(emp);

                        //update the employee's password salt
                        bool goodSaltUpdate = PasswordSaltAccessor.UpdatePasswordSalt(newSalt, emp.employeeID);

                        //if successful
                        if (goodEmployeeUpdate && goodSaltUpdate)
                        {
                            MessageBox.Show("User in the system has been edited.", "Successful User Edit");

                            //close the form
                            this.Close();
                        }
                    }

                    //if - user selects the yes btn and the user's password has NOT been edited then
                    //meaning that the edited user will NOT need a new salt and hash for their password
                    if (btnValueReturned == DialogResult.Yes && txtPassword.Text == employeeEdit.password)
                    {
                        //create an employee obj to be sent to the accessor class
                        Employee emp = new Employee(int.Parse(lblEmployeeID.Text), txtPassword.Text,
                            txtFirstName.Text, txtLastName.Text, email, active, positionID, siteID,
                            0, username, null, null, null, 3, 0);

                        //attempt to insert the employee
                        bool goodEmployeeUpdate = EmployeeAccessor.UpdateEmployeeFields(emp);

                        //if successful
                        if (goodEmployeeUpdate)
                        {
                            MessageBox.Show("User in the system has been edited.", "Successful User Edit");

                            //close the form
                            this.Close();
                        }
                    }
                }
            }
        }

        //timer should close this form after 20 minutes
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
