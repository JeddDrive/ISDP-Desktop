using JeddoreISDPDesktop.Entity_Classes;
using System.Windows.Forms;

namespace JeddoreISDPDesktop
{
    public partial class EditItem : Form
    {
        //class level/global variable for the employee object, and item object
        Employee employee = null;
        Item item = null;

        public EditItem(Employee employeeLoggedIn, Item itemSelected)
        {
            InitializeComponent();
            employee = employeeLoggedIn;
            item = itemSelected;
        }

        private void EditItem_Load(object sender, System.EventArgs e)
        {
            //display the employee's username and location in this form
            lblUsername.Text = employee.username;
            lblLocation.Text = employee.siteName;
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
    }
}
