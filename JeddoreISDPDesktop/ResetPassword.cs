using JeddoreISDPDesktop.DAO_Classes;
using JeddoreISDPDesktop.Entity_Classes;
using JeddoreISDPDesktop.Helper_Classes;
using System;
using System.Windows.Forms;

namespace JeddoreISDPDesktop
{
    public partial class ResetPassword : Form
    {
        //class level/global variable for storing the employeeID from the login form
        int globalEmployeeID;

        public ResetPassword(string username, int employeeID)
        {
            InitializeComponent();

            //setting lbl text to the username string sent in
            lblUsername.Text = username;

            globalEmployeeID = employeeID;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void picHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Please enter a new password here, and ensure that that you confirm it before resetting.",
                "Password Reset Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void picEyeNewShow_Click(object sender, EventArgs e)
        {
            //show password chars ftn
            PasswordCharacters.ShowPasswordChars(txtPasswordNew, picEyeNewShow, picEyeNewHide);
        }

        private void picEyeNewHide_Click(object sender, EventArgs e)
        {
            //hide password chars ftn
            PasswordCharacters.HidePasswordChars(txtPasswordNew, picEyeNewShow, picEyeNewHide);
        }

        private void picEyeConfirmShow_Click(object sender, EventArgs e)
        {
            //show password chars ftn
            PasswordCharacters.ShowPasswordChars(txtPasswordConfirm, picEyeConfirmShow, picEyeConfirmHide);
        }

        private void picEyeConfirmHide_Click(object sender, EventArgs e)
        {
            //hide password chars ftn
            PasswordCharacters.HidePasswordChars(txtPasswordConfirm, picEyeConfirmShow, picEyeConfirmHide);
        }

        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            //error message string
            string errorMessage = "";

            //if passwords match and it passes validation
            if (txtPasswordNew.Text == txtPasswordConfirm.Text && PasswordCharacters.ValidatePassword(txtPasswordConfirm.Text, out errorMessage))
            {
                //now update the password salt for that user, now that the passwords match and is validated
                //so that the same salt isn't always used
                string newSalt = PasswordEncrypter.GetSalt();

                bool goodSaltUpdate = PasswordSaltAccessor.UpdatePasswordSalt(newSalt, globalEmployeeID);

                //now get a new hashed password - based on the password and new salt text
                string newHash = PasswordEncrypter.GetHash(txtPasswordConfirm.Text + newSalt);

                //and update the password in the DB to be the new hashed password
                bool goodNewHash = EmployeeAccessor.UpdateEmployeePassword(newHash, globalEmployeeID);
                MessageBox.Show("Your password has been successfully reset.", "Password Successfully Reset");

                //call ftn for instantiating employee object
                InstantiateEmployee(out Employee employee);

                //if employee's madeFirstLogin value is 0, then change it to 1
                if (employee.madeFirstLogin == 0)
                {
                    bool goodUpdate = EmployeeAccessor.UpdateEmployeeMadeFirstLogin(employee.employeeID);
                }

                //close the form
                this.Close();
            }

            //else if - passwords don't match
            else if (txtPasswordNew.Text != txtPasswordConfirm.Text)
            {
                MessageBox.Show("Ensure that the confirmed password matches the new password.", "Passwords Don't Match");

                txtPasswordConfirm.Focus();
            }

            //else - password didn't pass validation
            else
            {
                //display the error message
                MessageBox.Show(errorMessage, "Password Validation Failure");

                txtPasswordConfirm.Focus();
            }
        }

        private void ResetPassword_Load(object sender, EventArgs e)
        {
            //setting the tooltip for the help image
            toolTipHelp.SetToolTip(picHelp, "Click here for help.");
        }

        //instantiate employee object function - based on the username sent in
        private void InstantiateEmployee(out Employee employee)
        {
            //get the typed in username
            string username = lblUsername.Text;

            //getting one employee based on the username
            employee = EmployeeAccessor.GetOneEmployee(username);
        }
    }
}
