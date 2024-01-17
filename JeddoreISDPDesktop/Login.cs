using JeddoreISDPDesktop.DAO_Classes;
using JeddoreISDPDesktop.Entity_Classes;
using JeddoreISDPDesktop.Helper_Classes;
using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Windows.Forms;

namespace JeddoreISDPDesktop
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        //class level code below
        //class-level config to the connection string
        private static string connString = ConfigurationManager.ConnectionStrings["ISDPConnString"].ConnectionString;

        //create a connection
        MySqlConnection connection = new MySqlConnection(connString);

        //int for keeping track of login attempts
        int loginAttempts = 3;

        private void Form1_Load(object sender, EventArgs e)
        {
            //setting the tooltip for the help image
            toolTipHelp.SetToolTip(picHelp, "Click here for help.");

            //open the connection - need try catch, like if db not found
            try
            {
                connection.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Database Connection Not Opened.", MessageBoxButtons.OK, MessageBoxIcon.Error);

                //close the form
                this.Close();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            //close the connection
            connection.Close();
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
            //subtract 1 from login attempts
            loginAttempts--;

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
                string userHash = PasswordEncryption.GetHash(password + passwordSalt);

                //if the hash returned matches the hashed password in the DB
                if (userHash == employee.password)
                {
                    MessageBox.Show("Password is a match. You are now logged in.", "Successful Login");
                    //MessageBox.Show(userHash + "\n" + employee.password, "Checking Passwords");
                    UpdateEmployeeSaltAndHashedPassword(password, employee);
                }

                //else - incorrect hash
                else
                {
                    //call reset form password ftn
                    ResetFormPassword();

                    MessageBox.Show("Incorrect Password. You have " + loginAttempts.ToString() + " login attempts remaining.",
                        "Unsuccessful Login");

                    //MessageBox.Show(userHash + "\n" + employee.password, "Checking Passwords");
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
            string newSalt = PasswordEncryption.GetSalt();

            bool goodSaltUpdate = PasswordSaltAccessor.UpdatePasswordSalt(newSalt, employee.employeeID);

            if (goodSaltUpdate)
            {
                MessageBox.Show("The salt was updated.");
            }

            //now get a new hashed password - based on the password and new salt text
            string newHash = PasswordEncryption.GetHash(password + newSalt);

            //and update the password in the DB to be the new hashed password
            bool goodNewHash = EmployeeAccessor.UpdateEmployeePassword(newHash, employee.employeeID);

            if (goodNewHash)
            {
                MessageBox.Show("The hashed password was updated.");
            }
        }

        private void lblForgotPassword_Click(object sender, EventArgs e)
        {
            //call ftn for instantiating employee object
            InstantiateEmployee(out string password, out Employee employee);

            //if employee username exists (not null)
            if (employee != null)
            {
                //sending in the employee username into the constructor for this form
                ResetPassword newResetPasswordForm = new ResetPassword(employee.username);

                //show the reset password form (modal)
                newResetPasswordForm.ShowDialog();
            }

            //else - employee username does not exist
            else
            {
                MessageBox.Show("Password can't be reset for a user that does not exist.", "Unable to Reset Password");
            }
        }

        private void picEyeHide_Click(object sender, EventArgs e)
        {
            //hide the raw password chars
            txtPassword.PasswordChar = char.Parse("*");

            //hide this picturebox and make the other one visible
            //also send to back and bring other picturebox to the front
            picEyeHide.Visible = false;
            picEyeShow.Visible = true;
            picEyeHide.SendToBack();
            picEyeShow.BringToFront();
        }

        private void picEyeShow_Click_1(object sender, EventArgs e)
        {
            //show the raw password chars
            txtPassword.PasswordChar = '\0';

            //hide this picturebox and make the other one visible
            //also send to back and bring other picturebox to the front
            picEyeShow.Visible = false;
            picEyeHide.Visible = true;
            picEyeShow.SendToBack();
            picEyeHide.BringToFront();
        }
    }
}
