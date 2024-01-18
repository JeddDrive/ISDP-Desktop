using JeddoreISDPDesktop.DAO_Classes;
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
                MessageBox.Show(errorMessage, "Failed Password Validation");

                txtPasswordConfirm.Focus();
            }
        }
    }
}
