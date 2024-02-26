using JeddoreISDPDesktop.DAO_Classes;
using JeddoreISDPDesktop.Entity_Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace JeddoreISDPDesktop
{
    public partial class ViewOrders : Form
    {
        //class level/global variable for the employee object from the dashboard
        Employee employee = null;

        public ViewOrders(Employee employeeLoggedIn)
        {
            InitializeComponent();
            employee = employeeLoggedIn;
        }

        private void ViewOrders_Load(object sender, EventArgs e)
        {
            //setting the tooltip for the help image
            toolTipHelp.SetToolTip(picHelp, "Click here for help.");

            //display the employee's username and location in this form
            lblUsername.Text = employee.username;
            lblLocation.Text = employee.siteName;

            //add ALL OPEN as first item in the combobox
            cboOrderTypes.Items.Add("ALL OPEN");

            //get a list of all of the txn statuses
            List<TxnStatus> txnStatusesList = TxnStatusAccessor.GetAllTxnStatusesList();

            //foreach txnStatus in this list, add to the combobox
            foreach (TxnStatus txnStatus in txnStatusesList)
            {
                cboOrderTypes.Items.Add(txnStatus.statusName);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //timer to close this form after 20 minutes
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void picHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This is the page for viewing store and emergency orders. You can read orders from here, as well as filter by order type and search by fields such as status, created date, and ship date." +
            "\n\nClick on the 'refresh' button to load the orders data grid.", "View Orders Help"
            , MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ViewOrders_KeyDown(object sender, KeyEventArgs e)
        {
            //if F1 key is pressed down
            if (e.KeyCode == Keys.F1)
            {
                MessageBox.Show("This is the page for viewing store and emergency orders. You can read orders from here, as well as filter by order type and search by fields such as status, created date, and ship date." +
                "\n\nClick on the 'refresh' button to load the orders data grid.", "View Orders Help"
                , MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            //call show default orders ftn
            ShowDefaultOrders();

            //enable the textbox for user search
            txtSearchOrders.Enabled = true;

            //enable the combobox
            cboOrderTypes.Enabled = true;
        }

        //Show Default Orders - to display default orders meaning ones that are active and not complete, cancelled, etc.
        private void ShowDefaultOrders()
        {
            //create a new bindingsource
            BindingSource bindingSource = new BindingSource();

            DataTable dt = null;

            //if the employee logged in has admin or warehouse manager privileges, then show all orders regardless of site
            if (employee.positionID == 99999999 || employee.positionID == 4)
            {
                //create datatable - getting all orders regardless of site, returned as a datatable
                dt = TxnAccessor.GetAllOrdersDataTable();
            }

            //else - employee logged in is not an admin (Ex. store manager) then
            else
            {
                //create datatable - getting all orders by employee's site, returned as a datatable
                dt = TxnAccessor.GetAllOrdersBySiteDataTable(employee.siteID);
            }

            //set the binding source's datasource to the datatable
            bindingSource.DataSource = dt;

            //set the dgv's datasource to the bindingSource
            dgvOrders.DataSource = bindingSource;

            //autoresize dgv columns
            dgvOrders.AutoResizeColumns();

            //display the binding nav
            bindingNavigator.Visible = true;

            //set the binding source of the binding nav to the binding source created
            bindingNavigator.BindingSource = bindingSource;

            //hide the following columns
            dgvOrders.Columns["siteIDTo"].Visible = false;
            dgvOrders.Columns["siteIDFrom"].Visible = false;
            dgvOrders.Columns["deliveryID"].Visible = false;

            //change the header text of these columns
            dgvOrders.Columns["txnID"].HeaderText = "Order ID";
            dgvOrders.Columns["originSite"].HeaderText = "Origin Site";
            dgvOrders.Columns["destinationSite"].HeaderText = "Destination Site";
            dgvOrders.Columns["status"].HeaderText = "Status";
            dgvOrders.Columns["shipDate"].HeaderText = "Ship Date";
            dgvOrders.Columns["txnType"].HeaderText = "Order Type";
            dgvOrders.Columns["barCode"].HeaderText = "Bar Code";
            dgvOrders.Columns["createdDate"].HeaderText = "Created Date";
            //dgvOrders.Columns["deliveryID"].HeaderText = "Delivery ID";
            dgvOrders.Columns["emergencyDelivery"].HeaderText = "Emergency Order";
            dgvOrders.Columns["notes"].HeaderText = "Notes";

            dgvOrders.Refresh();
        }

        //Show Orders by Status - to display orders by status selected in the combobox
        private void ShowOrdersByStatus()
        {
            //create a new bindingsource
            BindingSource bindingSource = new BindingSource();

            DataTable dt = null;

            //if the employee logged in has admin OR warehouse manager privileges, then show all orders regardless of site
            if (employee.positionID == 99999999 || employee.positionID == 4)
            {
                //create datatable - getting all orders by status regardless of site, returned as a datatable
                dt = TxnAccessor.GetAllOrdersByStatusDataTable(cboOrderTypes.Text);
            }

            //else - employee logged in is not an admin or warehouse manager (ex. store manager) then
            else
            {
                //create datatable - getting all orders by employee's site AND status, returned as a datatable
                dt = TxnAccessor.GetAllOrdersByStatusAndSiteDataTable(cboOrderTypes.Text, employee.siteID);
            }

            //set the binding source's datasource to the datatable
            bindingSource.DataSource = dt;

            //set the dgv's datasource to the bindingSource
            dgvOrders.DataSource = bindingSource;

            //autoresize dgv columns
            dgvOrders.AutoResizeColumns();

            //display the binding nav
            bindingNavigator.Visible = true;

            //set the binding source of the binding nav to the binding source created
            bindingNavigator.BindingSource = bindingSource;

            //hide the following columns
            dgvOrders.Columns["siteIDTo"].Visible = false;
            dgvOrders.Columns["siteIDFrom"].Visible = false;
            dgvOrders.Columns["deliveryID"].Visible = false;

            //change the header text of these columns
            dgvOrders.Columns["txnID"].HeaderText = "Order ID";
            dgvOrders.Columns["originSite"].HeaderText = "Origin Site";
            dgvOrders.Columns["destinationSite"].HeaderText = "Destination Site";
            dgvOrders.Columns["status"].HeaderText = "Status";
            dgvOrders.Columns["shipDate"].HeaderText = "Ship Date";
            dgvOrders.Columns["txnType"].HeaderText = "Order Type";
            dgvOrders.Columns["barCode"].HeaderText = "Bar Code";
            dgvOrders.Columns["createdDate"].HeaderText = "Created Date";
            //dgvOrders.Columns["deliveryID"].HeaderText = "Delivery ID";
            dgvOrders.Columns["emergencyDelivery"].HeaderText = "Emergency Order";
            dgvOrders.Columns["notes"].HeaderText = "Notes";

            dgvOrders.Refresh();
        }

        private void cboOrderTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboOrderTypes.SelectedIndex == 0)
            {
                //call show default orders ftn
                ShowDefaultOrders();
            }

            //else
            else
            {
                //call orders by status ftn
                ShowOrdersByStatus();
            }
        }

        private void txtSearchOrders_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //want to clear DGV row selection to prevent DGV errors/program from crashing
                //each time the text is changed and if the user clicks on a CRUD btn for example
                dgvOrders.ClearSelection();

                CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[dgvOrders.DataSource];

                foreach (DataGridViewRow row in dgvOrders.Rows)
                {
                    //get the cell values for the following columns
                    var statusCellValue = row.Cells["status"].Value;
                    var txnTypeCellValue = row.Cells["txnType"].Value;
                    var createdDateCellValue = row.Cells["createdDate"].Value;
                    var shippedDateCellValue = row.Cells["shipDate"].Value;

                    //if txtbox is empty, then just show all the rows and continue
                    if (txtSearchOrders.Text.Equals(""))
                    {
                        row.Visible = true;
                        continue;
                    }

                    //if - status cell converted to string contains the txtbox text
                    else if (statusCellValue != null && statusCellValue.ToString().ToLower().Contains(txtSearchOrders.Text))
                    {
                        row.Visible = true;
                    }

                    //else if - txn type cell converted to lower case contains the txtbox text
                    /* else if (txnTypeCellValue != null && txnTypeCellValue.ToString().ToLower().Contains(txtSearchOrders.Text))
                    {
                        row.Visible = true;
                    } */

                    //else if - created date cell converted to lower case contains the txtbox text
                    else if (createdDateCellValue != null && createdDateCellValue.ToString().ToLower().Contains(txtSearchOrders.Text))
                    {
                        row.Visible = true;
                    }

                    //else if - shipped date cell converted to lower case contains the txtbox text
                    else if (shippedDateCellValue != null && shippedDateCellValue.ToString().ToLower().Contains(txtSearchOrders.Text))
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

        private void btnReceive_Click(object sender, EventArgs e)
        {
            int selectedRowsCount = dgvOrders.SelectedRows.Count;

            //if number of selected rows is not one
            if (selectedRowsCount != 1)
            {
                MessageBox.Show("Must select one row from the data grid in order to receive that specific order.",
                    "Receive Order Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                //clear all selected rows from the dgv
                dgvOrders.ClearSelection();
            }

            //else - 1 order item row is selected
            else
            {
                //get the current row
                DataGridViewRow dgvRow = dgvOrders.CurrentRow;

                //get the cell with the selected row's txnID in the orders DGV
                int txnID = int.Parse(dgvRow.Cells[0].Value.ToString());

                //get the transaction
                Txn theTxn = TxnAccessor.GetOneOrder(txnID);

                //if the status of the txn is NOT submitted then
                if (theTxn.status != "Submitted")
                {
                    MessageBox.Show("The status of your selected order is: " + theTxn.status + "." +
                        "\n\nOnly orders with the status of 'Submitted' can be received by the warehouse for order assembly.",
                        "Unsuccessful Receival", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    dgvOrders.ClearSelection();
                }

                //else - the status is new then
                else
                {
                    //update the txn's status to assembling
                    theTxn.status = "Assembling";

                    //send the txn obj to the accessor
                    bool success = TxnAccessor.UpdateTxnStatus(theTxn);

                    //if success
                    if (success)
                    {
                        MessageBox.Show("Order for " + theTxn.destinationSite + " has been successfully received for assembly. It's status has been updated to " + theTxn.status + ".",
                            "Successful Receival");
                    }
                }
            }
        }
    }
}
