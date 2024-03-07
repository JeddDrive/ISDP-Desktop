using JeddoreISDPDesktop.DAO_Classes;
using JeddoreISDPDesktop.Entity_Classes;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Site = JeddoreISDPDesktop.Entity_Classes.Site;

namespace JeddoreISDPDesktop
{
    public partial class ModifyTransactionRecord : Form
    {
        //class level/global variable for the employee object from the dashboard
        Employee employee = null;

        //global variable for the txn ID sent into this form
        int txnID = 0;

        //global variable for the txn object
        Txn txn = null;

        public ModifyTransactionRecord(Employee employeeLoggedIn, int theTxnID)
        {
            InitializeComponent();
            employee = employeeLoggedIn;
            txnID = theTxnID;

            //get the transaction object
            txn = TxnAccessor.GetOneTxn(txnID);
        }

        private void ModifyTransactionRecord_Load(object sender, EventArgs e)
        {
            //setting the tooltip for the help image
            toolTipHelp.SetToolTip(picHelp, "Click here for help.");

            //display the employee's username and location in this form
            lblUsername.Text = employee.username;
            lblLocation.Text = employee.siteName;

            //list of deliveries from the delivery accessor
            List<Delivery> deliveriesList = DeliveryAccessor.GetAllDeliveriesList();

            //list of txn types
            List<TxnType> txnTypesList = TxnTypeAccessor.GetAllTxnTypesList();

            //list of txn statuses
            List<TxnStatus> txnStatusesList = TxnStatusAccessor.GetAllTxnStatusesList();

            //list of sites
            List<Site> sitesList = SiteAccessor.GetAllSitesList();

            //put properties of the txn object into their respective labels, txtboxes, and cboboxes
            lblTxnID.Text = txn.txnID.ToString();
            txtBarcode.Text = txn.barCode;

            //set DTP values
            dtpShipDate.Value = txn.shipDate;
            dtpShipDateTime.Value = txn.shipDate;

            //if txn emergency delivery is 1 for true, then check the checkbox
            if (txn.emergencyDelivery == 1)
            {
                chkEmergency.Checked = true;
            }

            //foreach loop thru sites list
            foreach (Site site in sitesList)
            {
                //add each site to both site comboboxes
                cboDestinationSites.Items.Add(site.siteID + " - " + site.name);
                cboOriginSites.Items.Add(site.siteID + " - " + site.name);
            }

            //foreach loop thru txn types list
            foreach (TxnType txnType in txnTypesList)
            {
                //add to combobox
                cboTxnTypes.Items.Add(txnType.txnType);
            }

            //foreach loop thru txn statuses list
            foreach (TxnStatus txnStatus in txnStatusesList)
            {
                //add to combobox
                cboTxnStatuses.Items.Add(txnStatus.statusName);
            }

            //foreach loop thru deliveries list
            foreach (Delivery delivery in deliveriesList)
            {
                //add to combobox
                cboDeliveryIDs.Items.Add(delivery.deliveryID + " - " + delivery.vehicleType);
            }

            //loop thru the destination sites combobox
            foreach (var site in cboDestinationSites.Items)
            {
                //get the text from the destination sites combobox for the site
                string siteText = cboDestinationSites.GetItemText(site);

                //split the string at each empty space
                string[] splitArray = siteText.Split(' ');

                //get the siteID from the array
                int siteID = int.Parse(splitArray[0]);

                //if site ID is a match with the siteID of the txn object, then select it
                //and break from the loop
                if (siteID == txn.siteIDTo)
                {
                    cboDestinationSites.SelectedItem = site;
                    break;
                }
            }

            //loop thru the origin sites combobox
            foreach (var site in cboOriginSites.Items)
            {
                //get the text from the origin sites combobox for the site
                string siteText = cboOriginSites.GetItemText(site);

                //split the string at each empty space
                string[] splitArray = siteText.Split(' ');

                //get the siteID from the array
                int siteID = int.Parse(splitArray[0]);

                //if site ID is a match with the siteID of the txn object, then select it
                //and break from the loop
                if (siteID == txn.siteIDFrom)
                {
                    cboOriginSites.SelectedItem = site;
                    break;
                }
            }

            //loop thru the txn types combobox
            foreach (var txnTypeItem in cboTxnTypes.Items)
            {
                //get the text from the combobox
                string txnType = cboTxnTypes.GetItemText(txnTypeItem);

                //if txnType is a match with the txnType of the txn object, then select it
                //and break from the loop
                if (txnType == txn.txnType)
                {
                    cboTxnTypes.SelectedItem = txnTypeItem;
                    break;
                }
            }

            //loop thru the txn statuses combobox
            foreach (var txnStatusItem in cboTxnStatuses.Items)
            {
                //get the text from the combobox
                string txnStatus = cboTxnStatuses.GetItemText(txnStatusItem);

                //if txnStatus is a match with the status of the txn object, then select it
                //and break from the loop
                if (txnStatus == txn.status)
                {
                    cboTxnStatuses.SelectedItem = txnStatusItem;
                    break;
                }
            }

            //loop thru the delivery IDs combobox
            foreach (var deliveryItem in cboDeliveryIDs.Items)
            {
                //get the text from the delivery IDs combobox for the delivery item
                string deliveryText = cboDeliveryIDs.GetItemText(deliveryItem);

                //split the string at each empty space
                string[] splitArray = deliveryText.Split(' ');

                //get the deliveryID from the array
                int deliveryID = int.Parse(splitArray[0]);

                //if deliveryID is a match with the delivery ID of the txn object, then select it
                //and break from the loop
                if (deliveryID == txn.deliveryID)
                {
                    cboDeliveryIDs.SelectedItem = deliveryItem;
                    break;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
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
            MessageBox.Show("This is the form for modifying transaction records." +
            "\n\nPlease ensure to select a valid delivery ID, ship date, transaction type, and transaction status before saving modifications to a transaction.", "Modify Transaction Records Help"
            , MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ModifyTransactionRecord_KeyDown(object sender, KeyEventArgs e)
        {
            //if the F1 key is pressed down
            if (e.KeyCode == Keys.F1)
            {
                MessageBox.Show("This is the form for modifying transaction records." +
                "\n\nPlease ensure to select a valid delivery ID, ship date, transaction type, and transaction status before saving modifications to a transaction.", "Modify Transaction Records Help"
                , MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult btnValueReturned = MessageBox.Show("Are you sure you want to save your modification(s) for transaction: " +
            txn.txnID + "?", "Confirm Transaction Modification",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            //if - user selects the yes btn
            if (btnValueReturned == DialogResult.Yes)
            {
                //byte for emergency delivery
                byte emergencyDelivery = 0;

                //int for delivery ID
                int deliveryID = 0;

                //if the checkbox is checked, then emergencyDelivery should be 1
                if (chkEmergency.Checked)
                {
                    emergencyDelivery = 1;
                }

                //if new ship date is before the created date, then display msg and return
                if (dtpShipDate.Value < txn.createdDate)
                {
                    MessageBox.Show("Ship date for a transaction can't be prior to the created date." +
                        "\n\nEdited Ship Date: " + dtpShipDate.Value + "\nCreated Date: " + txn.createdDate,
                        "Ship Date Prior to Created Date Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    dtpShipDate.Focus();

                    return;
                }

                //if bar code is empty
                if (txtBarcode.Text == "")
                {
                    MessageBox.Show("Bar code can't be empty.", "Empty Bar Code Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    txtBarcode.Focus();

                    return;
                }

                //if selected index for the origin site combobox is below 0
                if (cboOriginSites.SelectedIndex < 0)
                {
                    MessageBox.Show("Must select a valid origin site from it's respective combobox for a transaction.", "Invalid Origin Site",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    return;
                }

                //if selected index for the destination site combobox is below 0
                if (cboDestinationSites.SelectedIndex < 0)
                {
                    MessageBox.Show("Must select a valid destination site from it's respective combobox for a transaction.", "Invalid Destination Site",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    return;
                }

                //if selected index for the txn type combobox is below 0
                if (cboTxnTypes.SelectedIndex < 0)
                {
                    MessageBox.Show("Must select a valid transaction type from it's respective combobox for a transaction.", "Invalid Transaction Type",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    return;
                }

                //if selected index for the txn status combobox is below 0
                if (cboTxnStatuses.SelectedIndex < 0)
                {
                    MessageBox.Show("Must select a valid transaction status from it's respective combobox for a transaction.", "Invalid Transaction Status",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    return;
                }

                //if selected inedx for the delivery ID combobox is ABOVE -1
                if (cboDeliveryIDs.SelectedIndex > -1)
                {
                    //get the text from the delivery IDs combobox for the delivery item
                    string deliveryText = cboDeliveryIDs.Text;

                    //split the string at each empty space
                    string[] splitArray = deliveryText.Split(' ');

                    //get the deliveryID from the array
                    int deliveryIDSelected = int.Parse(splitArray[0]);

                    //assign the selected ID to the delivery ID int variable
                    deliveryID = deliveryIDSelected;
                }

                //get the text from the destination sites combobox for the site
                string destinationSiteText = cboDestinationSites.Text;

                //split the string at each empty space
                string[] splitArray1 = destinationSiteText.Split(' ');

                //get the siteIDTo from the array
                int siteIDTo = int.Parse(splitArray1[0]);

                //get the text from the destination sites combobox for the site
                string originSiteText = cboOriginSites.Text;

                //split the string at each empty space
                string[] splitArray2 = originSiteText.Split(' ');

                //get the siteID from the array
                int siteIDFrom = int.Parse(splitArray2[0]);

                //txn type
                string txnType = cboTxnTypes.Text;

                //txn status
                string txnStatus = cboTxnStatuses.Text;

                //barcode
                string barCode = txtBarcode.Text;

                //getting just the date from the dtp for the date
                DateTime dateOnly = dtpShipDate.Value.Date;

                //getting just the time from the dtp for the time
                //TimeOfDay returns a TimeSpan
                TimeSpan timeOnly = dtpShipDateTime.Value.TimeOfDay;

                //add the timespan obj to the date for the combined date
                //this is the new ship date
                DateTime combinedNewShipDate = dateOnly.Date.Add(timeOnly);

                //if deliveryID is 0, meaning that it's null for the update
                if (deliveryID == 0)
                {
                    //new txn object
                    Txn newTxn = new Txn(txn.txnID, siteIDTo, siteIDFrom, txnStatus, combinedNewShipDate, txnType,
                        barCode, 0, emergencyDelivery);

                    //update the txn, sending in the txn object
                    bool success = TxnAccessor.UpdateModifyRecord(newTxn);

                    //if success
                    if (success)
                    {
                        MessageBox.Show("Transaction " + txn.txnID + " has been successfully modified.", "Transaction Record Modified");

                        this.Close();
                    }
                }

                //else - deliveryID isn't 0, so a valid deliveryID for the update
                else
                {
                    //new txn object
                    Txn newTxn = new Txn(txn.txnID, siteIDTo, siteIDFrom, txnStatus, combinedNewShipDate, txnType,
                        barCode, deliveryID, emergencyDelivery);

                    //update the txn, sending in the txn object
                    bool success = TxnAccessor.UpdateModifyRecord(newTxn);

                    //if success
                    if (success)
                    {
                        MessageBox.Show("Transaction " + txn.txnID + " has been successfully modified.", "Transaction Record Modified");

                        this.Close();
                    }
                }
            }
        }
    }
}
