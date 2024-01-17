using System;
using System.Windows.Forms;

namespace JeddoreISDPDesktop
{
    public partial class ResetPassword : Form
    {
        public ResetPassword(string username)
        {
            InitializeComponent();

            //setting lbl text to the username string sent in
            lblUsername.Text = username;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void picHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Please enter a new password here, and ensure that it is confirmed before resetting. ",
                "Password Reset Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
