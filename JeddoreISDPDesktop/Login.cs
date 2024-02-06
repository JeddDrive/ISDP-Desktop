using JeddoreISDPDesktop.DAO_Classes;
using JeddoreISDPDesktop.Entity_Classes;
using JeddoreISDPDesktop.Helper_Classes;
using System;
using System.Windows.Forms;

namespace JeddoreISDPDesktop
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        //insert any needed class level code here

        private void Form1_Load(object sender, EventArgs e)
        {
            //setting the tooltip for the help image
            toolTipHelp.SetToolTip(picHelp, "Click here for help.");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void picHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Please enter your username and password to login. You can also click on " +
                "'Forgot Password' in order to reset your password if needed.", "Login Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //this ftn resets the username and password textboxes
        private void ResetFormUsernameAndPassword()
        {
            //clear out both textboxes
            txtUsername.ResetText();
            txtPassword.ResetText();

            //focus on top textbox (username)
            txtUsername.Focus();
        }

        //this ftn resets the password textbox
        private void ResetFormPassword()
        {
            //clear out the password textbox
            txtPassword.ResetText();

            //focus on top txtbox
            txtPassword.Focus();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //call ftn for instantiating employee object
            InstantiateEmployee(out string password, out Employee employee);

            //if - username/user does not exist
            if (employee == null)
            {
                MessageBox.Show("No user currently exists with that username.", "Nonexistent User");

                ResetFormUsernameAndPassword();
            }

            //else - employee does exist, then check the password
            else
            {
                //getting the password salt string for that employee
                string passwordSalt = PasswordSaltAccessor.GetOnePasswordSaltString(employee.employeeID);

                //get the hash for the password + salt (salt goes after the raw password)
                string userHash = PasswordEncrypter.GetHash(password + passwordSalt);

                //if employee is locked but has 0 login attempts
                //meaning that they were previously locked but are no longer locked
                //then want to update their login attempts back to 3
                if (employee.locked == 0 && employee.loginAttempts == 0)
                {
                    bool goodUpdate = EmployeeAccessor.UpdateEmployeeLoginAttemptsToThree(employee.employeeID);
                }

                //if - employee exists but is inactive
                if (employee.active == 0)
                {
                    MessageBox.Show("Invalid username and/or password. Please contact your Administrator admin@bullseye.ca for assistance.", "Invalid Username and/or Password");

                    //call reset form password ftn
                    ResetFormPassword();
                }

                //else if - employee exists but is locked
                else if (employee.locked == 1)
                {
                    MessageBox.Show("Your account has been locked because of too many incorrect login attempts. Please contact your Administrator at admin@bullseye.ca for assistance.", "Account Locked");

                    //call reset form password ftn
                    ResetFormPassword();
                }

                //else if - the hash returned matches the hashed password in the DB
                //successful login
                else if (userHash == employee.password)
                {
                    //if employee is making their first login, then prompt them to change their password
                    if (employee.madeFirstLogin == 0)
                    {
                        MessageBox.Show("Password is a match, but because this is your first login, please change the default password.", "First Successful Login");

                        //sending in the employee username and ID into the constructor for this form
                        ResetPassword newResetPasswordForm = new ResetPassword(employee.username, employee.employeeID);

                        //show the reset password form (modal)
                        newResetPasswordForm.ShowDialog();
                    }

                    //else - not their first login
                    else
                    {
                        MessageBox.Show("Password is a match. You are now logged in.", "Successful Login");
                        //MessageBox.Show(userHash + "\n" + employee.password, "Checking Passwords");
                        UpdateEmployeeSaltAndHashedPassword(password, employee);

                        //if employee login attempts is under 3, then update it back to the default (3)
                        //because of the successful login
                        if (employee.loginAttempts < 3)
                        {
                            bool goodUpdate = EmployeeAccessor.UpdateEmployeeLoginAttemptsToThree(employee.employeeID);
                        }

                        //want to send the employee obj to the dashboard form
                        Dashboard frmDashboard = new Dashboard(employee);

                        //open the dashboard form (modal)
                        frmDashboard.ShowDialog();

                    }
                }

                //else - incorrect hash
                else
                {
                    //subtract 1 from login attempts
                    bool goodLoginAttemptsUpdate = EmployeeAccessor.UpdateEmployeeLoginAttemptsMinusOne(employee.employeeID);

                    //call ftn for instantiating employee object
                    //need to get the new updated login attempts number for this employee
                    InstantiateEmployee(out password, out employee);

                    //if login attempts reaches 0, then lock that employee/user
                    if (goodLoginAttemptsUpdate && employee.loginAttempts == 0)
                    {
                        EmployeeAccessor.UpdateEmployeeToLocked(employee.employeeID);

                        MessageBox.Show("Your account has been locked because of too many incorrect login attempts. Please contact your Administrator at admin@bullseye.ca for assistance.", "Account Locked");
                    }

                    //else - login attempts not yet at 0
                    else if (goodLoginAttemptsUpdate && employee.loginAttempts > 0)
                    {
                        MessageBox.Show("Incorrect Password. You have " + (employee.loginAttempts).ToString() + " login attempts remaining.",
                            "Unsuccessful Login Attempt");

                        //MessageBox.Show(userHash + "\n" + employee.password, "Checking Passwords");
                    }

                    //call reset form password ftn
                    ResetFormPassword();
                }

            }

        }

        //instantiate employee object function - based on the username sent in
        private void InstantiateEmployee(out string password, out Employee employee)
        {
            //get the typed in username and password
            string username = txtUsername.Text;
            password = txtPassword.Text;

            //getting one employee based on the username
            employee = EmployeeAccessor.GetOneEmployee(username);
        }

        //function for updating the salt for the employee's password
        //should be called after each successful login
        private static void UpdateEmployeeSaltAndHashedPassword(string password, Employee employee)
        {
            //now update the password salt for that user, now that they are successfully logged in
            //so that the same salt isn't always used
            string newSalt = PasswordEncrypter.GetSalt();

            bool goodSaltUpdate = PasswordSaltAccessor.UpdatePasswordSalt(newSalt, employee.employeeID);

            /* if (goodSaltUpdate)
            {
                MessageBox.Show("The salt was updated.");
            } */

            //now get a new hashed password - based on the password and new salt text
            string newHash = PasswordEncrypter.GetHash(password + newSalt);

            //and update the password in the DB to be the new hashed password
            bool goodNewHash = EmployeeAccessor.UpdateEmployeePassword(newHash, employee.employeeID);

            /* if (goodNewHash)
            {
                MessageBox.Show("The hashed password was updated.");
            } */
        }

        private void lblForgotPassword_Click(object sender, EventArgs e)
        {
            //call ftn for instantiating employee object
            InstantiateEmployee(out string password, out Employee employee);

            //if employee username exists (not null) and employee is NOT locked then
            if (employee != null && employee.locked == 0)
            {
                //sending in the employee username and ID into the constructor for this form
                ResetPassword newResetPasswordForm = new ResetPassword(employee.username, employee.employeeID);

                //show the reset password form (modal)
                newResetPasswordForm.ShowDialog();
            }

            //else - employee username does not exist, or is locked
            else
            {
                MessageBox.Show("Password can't be reset for a user that does not exist or is locked.", "Unable to Reset Password");
            }
        }

        private void picEyeHide_Click(object sender, EventArgs e)
        {
            //hide password chars ftn
            PasswordCharacters.HidePasswordChars(txtPassword, picEyeShow, picEyeHide);
        }

        private void picEyeShow_Click_1(object sender, EventArgs e)
        {
            //show password chars ftn
            PasswordCharacters.ShowPasswordChars(txtPassword, picEyeShow, picEyeHide);
        }

        private void Login_KeyDown(object sender, KeyEventArgs e)
        {
            //if the F1 key is pressed down
            if (e.KeyCode == Keys.F1)
            {
                MessageBox.Show("Please enter your username and password to login. You can also click on " +
                "'Forgot Password' in order to reset your password if needed.", "Login Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
