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
                "'Forgot Password' in order to reset your password.", "Login Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //this ftn resets the form
        private void ResetForm()
        {
            //clear out the textboxes
            txtUsername.Text = "";
            txtPassword.Text = "";

            //focus on top txtbox
            txtUsername.Focus();

            //minus 1 from loginAttempts
            //loginAttempts--;
        }
    }
}
