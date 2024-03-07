using JeddoreISDPDesktop.DAO_Classes;
using JeddoreISDPDesktop.Entity_Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace JeddoreISDPDesktop
{
    public partial class TransactionManagement : Form
    {
        //class level/global variable for the employee object from the dashboard
        Employee employee = null;

        public TransactionManagement(Employee employeeLoggedIn)
        {
            InitializeComponent();
            employee = employeeLoggedIn;
        }

        private void OrdersManagement_Load(object sender, EventArgs e)
        {
            //setting the tooltip for the help image
            toolTipHelp.SetToolTip(picHelp, "Click here for help.");

            //display the employee's username and location in this form
            lblUsername.Text = employee.username;
            lblLocation.Text = employee.siteName;

            //add ALL OPEN as first item in the combobox
            cboTxnTypes.Items.Add("ALL OPEN");

            //get a list of all of the txn statuses
            List<TxnStatus> txnStatusesList = TxnStatusAccessor.GetAllTxnStatusesList();

            //foreach txnStatus in this list, add to the combobox
            foreach (TxnStatus txnStatus in txnStatusesList)
            {
                cboTxnTypes.Items.Add(txnStatus.statusName);
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
            MessageBox.Show("This is the form for viewing and modifying open transaction records. You can view all transactions from here, as well as filter by order type and search by fields such as status, created date, and ship date." +
            "\n\nClick on the 'refresh' button to load the transactions data grid.", "Modify Transaction Records Help"
            , MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void OrdersManagement_KeyDown(object sender, KeyEventArgs e)
        {
            //if the F1 key is pressed down
            if (e.KeyCode == Keys.F1)
            {
                MessageBox.Show("This is the form for viewing and modifying open transaction records. You can view all transactions from here, as well as filter by order type and search by fields such as status, created date, and ship date." +
                "\n\nClick on the 'refresh' button to load the transactions data grid.", "Modify Transaction Records Help"
                , MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            //call show default txns ftn
            ShowDefaultTxns();

            //enable the textbox for user search
            txtSearchTxns.Enabled = true;

            //enable the combobox
            cboTxnTypes.Enabled = true;

            //reset the text in the search textbox
            txtSearchTxns.ResetText();

            //enable the modify and cancel btns
            btnModifyTxn.Enabled = true;
            btnCancelTxn.Enabled = true;

            //select the first index of the combobox (ALL OPEN)
            cboTxnTypes.SelectedIndex = 0;
        }

        //Show Default Txns - to display default txns meaning ones that are active and not complete, cancelled, etc.
        private void ShowDefaultTxns()
        {
            //create a new bindingsource
            BindingSource bindingSource = new BindingSource();

            DataTable dt = null;

            //creare datatable, getting all open txns
            dt = TxnAccessor.GetAllOpenTxnsDataTable();

            //set the binding source's datasource to the datatable
            bindingSource.DataSource = dt;

            //set the dgv's datasource to the bindingSource
            dgvTxns.DataSource = bindingSource;

            //autoresize dgv columns
            dgvTxns.AutoResizeColumns();

            //display the binding nav
            bindingNavigator.Visible = true;

            //set the binding source of the binding nav to the binding source created
            bindingNavigator.BindingSource = bindingSource;

            //hide the following columns
            dgvTxns.Columns["siteIDTo"].Visible = false;
            dgvTxns.Columns["siteIDFrom"].Visible = false;
            dgvTxns.Columns["deliveryID"].Visible = false;

            //change the header text of these columns
            dgvTxns.Columns["txnID"].HeaderText = "Txn ID";
            dgvTxns.Columns["originSite"].HeaderText = "Origin Site";
            dgvTxns.Columns["destinationSite"].HeaderText = "Destination Site";
            dgvTxns.Columns["status"].HeaderText = "Status";
            dgvTxns.Columns["shipDate"].HeaderText = "Ship Date";
            dgvTxns.Columns["txnType"].HeaderText = "Order Type";
            dgvTxns.Columns["barCode"].HeaderText = "Bar Code";
            dgvTxns.Columns["createdDate"].HeaderText = "Created Date";
            //dgvTxns.Columns["deliveryID"].HeaderText = "Delivery ID";
            dgvTxns.Columns["emergencyDelivery"].HeaderText = "Emergency Order";
            dgvTxns.Columns["notes"].HeaderText = "Notes";

            dgvTxns.Refresh();
        }

        //Show Txns by Status - to display txns by status selected in the combobox
        private void ShowTxnsByStatus()
        {
            //create a new bindingsource
            BindingSource bindingSource = new BindingSource();

            //create datatable
            DataTable dt = null;

            //assign to the datatable, all txns by status
            dt = TxnAccessor.GetAllTxnsByStatusDataTable(cboTxnTypes.Text);

            //set the binding source's datasource to the datatable
            bindingSource.DataSource = dt;

            //set the dgv's datasource to the bindingSource
            dgvTxns.DataSource = bindingSource;

            //autoresize dgv columns
            dgvTxns.AutoResizeColumns();

            //display the binding nav
            bindingNavigator.Visible = true;

            //set the binding source of the binding nav to the binding source created
            bindingNavigator.BindingSource = bindingSource;

            //hide the following columns
            dgvTxns.Columns["siteIDTo"].Visible = false;
            dgvTxns.Columns["siteIDFrom"].Visible = false;
            dgvTxns.Columns["deliveryID"].Visible = false;

            //change the header text of these columns
            dgvTxns.Columns["txnID"].HeaderText = "Txn ID";
            dgvTxns.Columns["originSite"].HeaderText = "Origin Site";
            dgvTxns.Columns["destinationSite"].HeaderText = "Destination Site";
            dgvTxns.Columns["status"].HeaderText = "Status";
            dgvTxns.Columns["shipDate"].HeaderText = "Ship Date";
            dgvTxns.Columns["txnType"].HeaderText = "Order Type";
            dgvTxns.Columns["barCode"].HeaderText = "Bar Code";
            dgvTxns.Columns["createdDate"].HeaderText = "Created Date";
            //dgvTxns.Columns["deliveryID"].HeaderText = "Delivery ID";
            dgvTxns.Columns["emergencyDelivery"].HeaderText = "Emergency Order";
            dgvTxns.Columns["notes"].HeaderText = "Notes";

            dgvTxns.Refresh();
        }

        private void cboTxnTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTxnTypes.SelectedIndex == 0)
            {
                //call show default txns ftn
                ShowDefaultTxns();
            }

            //else
            else
            {
                //call orders by status ftn
                ShowTxnsByStatus();
            }
        }

        private void txtSearchTxns_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //want to clear DGV row selection to prevent DGV errors/program from crashing
                //each time the text is changed and if the user clicks on a CRUD btn for example
                dgvTxns.ClearSelection();

                //converting the search text to all lower case
                string theSearchText = txtSearchTxns.Text.ToLower();

                CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[dgvTxns.DataSource];

                foreach (DataGridViewRow row in dgvTxns.Rows)
                {
                    //get the cell values for the following columns
                    var originSiteCellValue = row.Cells["originSite"].Value;
                    var destinationSiteCellValue = row.Cells["destinationSite"].Value;
                    var statusCellValue = row.Cells["status"].Value;
                    var txnTypeCellValue = row.Cells["txnType"].Value;
                    var createdDateCellValue = row.Cells["createdDate"].Value;
                    var shippedDateCellValue = row.Cells["shipDate"].Value;

                    //if txtbox is empty, then just show all the rows and continue
                    if (txtSearchTxns.Text.Equals(""))
                    {
                        row.Visible = true;
                        continue;
                    }

                    //else if - origin site cell converted to string contains the txtbox text
                    else if (originSiteCellValue != null && originSiteCellValue.ToString().ToLower().Contains(theSearchText))
                    {
                        row.Visible = true;
                    }

                    //else if - destination site cell converted to string contains the txtbox text
                    else if (destinationSiteCellValue != null && destinationSiteCellValue.ToString().ToLower().Contains(theSearchText))
                    {
                        row.Visible = true;
                    }

                    //if - status cell converted to string contains the txtbox text
                    else if (statusCellValue != null && statusCellValue.ToString().ToLower().Contains(theSearchText))
                    {
                        row.Visible = true;
                    }

                    //else if - created date cell converted to lower case contains the txtbox text
                    else if (createdDateCellValue != null && createdDateCellValue.ToString().ToLower().Contains(theSearchText))
                    {
                        row.Visible = true;
                    }

                    //else if - shipped date cell converted to lower case contains the txtbox text
                    else if (shippedDateCellValue != null && shippedDateCellValue.ToString().ToLower().Contains(theSearchText))
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

        private void btnCancelTxn_Click(object sender, EventArgs e)
        {
            int selectedRowsCount = dgvTxns.SelectedRows.Count;

            //if number of selected rows is not one
            if (selectedRowsCount != 1)
            {
                MessageBox.Show("Must select one row from the data grid in order to cancel that specific transaction.",
                    "Transaction Cancellation Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //clear all selected rows from the dgv
                dgvTxns.ClearSelection();
            }

            //else - 1 order item row is selected
            else
            {
                //get the current row
                DataGridViewRow dgvRow = dgvTxns.CurrentRow;

                //get the cell with the selected row's txnID in the orders DGV
                int txnID = int.Parse(dgvRow.Cells[0].Value.ToString());

                //get the transaction
                Txn theTxn = TxnAccessor.GetOneTxn(txnID);

                DialogResult btnValueReturned = MessageBox.Show("Are you sure you want to cancel transaction: " +
                theTxn.txnID + "?", "Confirm Transaction Cancellation",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                //if - user selects the yes btn
                if (btnValueReturned == DialogResult.Yes)
                {
                    //if the status of the txn is closed so complete, rejected, or cancelled then
                    if (theTxn.status == "Complete" || theTxn.status == "Rejected" || theTxn.status == "Cancelled")
                    {
                        MessageBox.Show("The status of your selected transaction is: " + theTxn.status + "." +
                            "\n\nOnly open transactions which are not already complete, rejected, or cancelled can be cancelled.",
                            "Unsuccessful Cancellation", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        dgvTxns.ClearSelection();
                    }

                    //else - the status is new then
                    else
                    {
                        //update the txn's status to cancelled
                        theTxn.status = "Cancelled";

                        //send the txn obj to the accessor
                        bool success = TxnAccessor.UpdateTxnStatus(theTxn);

                        //if success
                        if (success)
                        {
                            MessageBox.Show("Transaction for " + theTxn.destinationSite + " has been successfully cancelled.",
                                "Transaction Cancelled");

                            dgvTxns.Refresh();
                        }
                    }
                }
            }
        }

        private void btnModifyTxn_Click(object sender, EventArgs e)
        {
            int selectedRowsCount = dgvTxns.SelectedRows.Count;

            //if number of selected rows is not one
            if (selectedRowsCount != 1)
            {
                MessageBox.Show("Must select one row from the data grid in order to modify that transaction record.",
                    "Transaction Modification Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //clear all selected rows from the dgv
                dgvTxns.ClearSelection();
            }

            //else - 1 order item row is selected
            else
            {
                //get the current row
                DataGridViewRow dgvRow = dgvTxns.CurrentRow;

                //get the cell with the selected row's txnID in the orders DGV
                int txnID = int.Parse(dgvRow.Cells[0].Value.ToString());

                //get the transaction object
                Txn theTxn = TxnAccessor.GetOneTxn(txnID);

                //checking the status of the txn
                //if the status of the txn is closed so complete, rejected, or cancelled then
                if (theTxn.status == "Complete" || theTxn.status == "Rejected" || theTxn.status == "Cancelled")
                {
                    MessageBox.Show("The status of your selected transaction is: " + theTxn.status + "." +
                        "\n\nOnly active transactions which are not already complete, rejected, or cancelled can be modified.",
                        "Unsuccessful Modification", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    dgvTxns.ClearSelection();

                    return;
                }

                //creating form object, sending in the employee and txn objects
                ModifyTransactionRecord frmModifyTxnRecord = new ModifyTransactionRecord(employee, txnID);

                //open the modify transaction record form (modal)
                frmModifyTxnRecord.ShowDialog();
            }
        }
    }
}
