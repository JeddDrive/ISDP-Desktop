using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace JeddoreISDPDesktop.Helper_Classes
{
    //public static helper class
    public static class PasswordCharacters
    {
        //static function for showing password chars
        public static void ShowPasswordChars(TextBox txtbox, PictureBox picShow, PictureBox picHide)
        {
            //show the raw password chars
            txtbox.PasswordChar = '\0';

            //hide this picturebox and make the other one visible
            //also send to back and bring other picturebox to the front
            picShow.Visible = false;
            picHide.Visible = true;
            picShow.SendToBack();
            picHide.BringToFront();
        }

        //static function for hiding password chars
        public static void HidePasswordChars(TextBox txtbox, PictureBox picShow, PictureBox picHide)
        {
            //hide the raw password chars
            txtbox.PasswordChar = char.Parse("*");

            //hide this picturebox and make the other one visible
            //also send to back and bring other picturebox to the front
            picHide.Visible = false;
            picShow.Visible = true;
            picHide.SendToBack();
            picShow.BringToFront();
        }

        //method for validating passwords
        public static bool ValidatePassword(string password, out string errorMessage)
        {
            //variables, including a bool to be returned
            bool goodPassword = false;
            var input = password;
            errorMessage = "";

            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMiniMaxChars = new Regex(@".{8,64}");
            var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");

            if (string.IsNullOrWhiteSpace(input))
            {
                errorMessage = "Password should not be empty.";
            }

            else if (input.Length > 0 && input.Length < 8)
            {
                errorMessage = "Password must be at least 8 characters long.";
            }

            else if (!hasUpperChar.IsMatch(input))
            {
                errorMessage = "Password should contain at least one upper case letter.";
            }

            else if (!hasMiniMaxChars.IsMatch(input))
            {
                errorMessage = "Password should not be lesser than 8 or greater than 64 characters.";
            }

            else if (!hasNumber.IsMatch(input))
            {
                errorMessage = "Password should contain at least one numeric value.";
            }

            else if (!hasSymbols.IsMatch(input))
            {
                errorMessage = "Password should contain at least one special case character.";
            }

            //else - password is good
            else
            {
                goodPassword = true;
            }

            //return the bool
            return goodPassword;
        }
    }
}
