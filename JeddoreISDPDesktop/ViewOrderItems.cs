using JeddoreISDPDesktop.DAO_Classes;
using JeddoreISDPDesktop.Entity_Classes;
using System;
using System.Data;
using System.Windows.Forms;

namespace JeddoreISDPDesktop
{
    public partial class ViewOrderItems : Form
    {
        //class level/global variable for the employee object from the dashboard
        Employee employee = null;

        //global variable for the txn ID sent into this form
        int txnID = 0;

        public ViewOrderItems(Employee employeeLoggedIn, int theTxnID)
        {
            InitializeComponent();
            employee = employeeLoggedIn;
            txnID = theTxnID;
        }

        private void ViewOrderItems_Load(object sender, EventArgs e)
        {
            //setting the tooltip for the help image
            toolTipHelp.SetToolTip(picHelp, "Click here for help.");

            //display the employee's username and location in this form
            lblUsername.Text = employee.username;
            lblLocation.Text = employee.siteName;

            //display the txn/order ID
            lblOrderID.Text = txnID.ToString();
        }

        //timer to close this form after 20 minutes
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void picHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This is the page for viewing items for a specific order. You can also search for order items by fields such as name and description." +
            "\n\nClick on the 'refresh' button to load the order items data grid.", "View Order Items Help"
            , MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ViewOrderItems_KeyDown(object sender, KeyEventArgs e)
        {
            //if F1 key is pressed down
            if (e.KeyCode == Keys.F1)
            {
                MessageBox.Show("This is the page for viewing items for a specific order. You can also search for order items by fields such as name and description." +
                "\n\nClick on the 'refresh' button to load the order items data grid.", "View Order Items Help"
                 , MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtSearchOrderItems_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //want to clear DGV row selection to prevent DGV errors/program from crashing
                //each time the text is changed and if the user clicks on a CRUD btn for example
                //dgvOrders.ClearSelection();
                dgvOrderItems.ClearSelection();

                //converting the search text to all lower case
                string theSearchText = txtSearchOrderItems.Text.ToLower();

                CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[dgvOrderItems.DataSource];

                foreach (DataGridViewRow row in dgvOrderItems.Rows)
                {
                    //get the cell values for the following columns
                    var nameCellValue = row.Cells["Name"].Value;
                    var descriptionCellValue = row.Cells["description"].Value;
                    var itemIDCellValue = row.Cells["itemID"].Value;

                    //if txtbox is empty, then just show all the rows and continue
                    if (txtSearchOrderItems.Text.Equals(""))
                    {
                        row.Visible = true;
                        continue;
                    }

                    //if - first name cell converted to lower case contains the txtbox text
                    if (nameCellValue != null && nameCellValue.ToString().ToLower().Contains(theSearchText))
                    {
                        row.Visible = true;
                    }

                    //else if - last name cell converted to lower case contains the txtbox text
                    else if (descriptionCellValue != null && descriptionCellValue.ToString().ToLower().Contains(theSearchText))
                    {
                        row.Visible = true;
                    }

                    //else if - item ID cell contains the txtbox text
                    else if (itemIDCellValue != null && itemIDCellValue.ToString().Contains(theSearchText))
                    {
                        row.Visible = true;
                    }

                    //else - no text contains match in any of the above cells then
                    else
                    {
                        //need to suspend and resume binding before and after row visibilty is false
                        //or else will get an error
                        currencyManager1.SuspendBinding();
                        row.Visible = false;
                        currencyManager1.ResumeBinding();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            //get all the txn items for the txn, based on the txnID
            DataTable dt = TxnItemsAccessor.GetAllTxnItemsByTxnIDDataTable(txnID);

            //create a new bindingsource
            BindingSource bindingSource = new BindingSource();

            //set the binding source's datasource to the datatable
            bindingSource.DataSource = dt;

            //set the dgv's datasource to the bindingSource
            dgvOrderItems.DataSource = bindingSource;

            //autoresize dgv columns
            dgvOrderItems.AutoResizeColumns();

            //display the binding nav
            bindingNavigator.Visible = true;

            //set the binding source of the binding nav to the binding source created
            bindingNavigator.BindingSource = bindingSource;

            //hide these columns in the DGV
            dgvOrderItems.Columns["notes"].Visible = false;
            dgvOrderItems.Columns["txnID"].Visible = false;

            //change the header text of these columns
            //dgvOrder.Columns["txnID"].HeaderText = "Txn ID";
            dgvOrderItems.Columns["itemID"].HeaderText = "Item ID";
            dgvOrderItems.Columns["name"].HeaderText = "Name";
            dgvOrderItems.Columns["description"].HeaderText = "Description";
            dgvOrderItems.Columns["quantity"].HeaderText = "Quantity";
            dgvOrderItems.Columns["caseSize"].HeaderText = "Case Size";
            dgvOrderItems.Columns["weight"].HeaderText = "Weight";
            dgvOrderItems.Columns["notes"].HeaderText = "Notes";

            dgvOrderItems.Refresh();

            //enable the search txtbox
            txtSearchOrderItems.Enabled = true;
        }
    }
}
