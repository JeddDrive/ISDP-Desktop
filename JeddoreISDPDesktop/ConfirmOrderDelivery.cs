using JeddoreISDPDesktop.DAO_Classes;
using JeddoreISDPDesktop.Entity_Classes;
using JeddoreISDPDesktop.Helper_Classes;
using System;
using System.Windows.Forms;

namespace JeddoreISDPDesktop
{
    public partial class ConfirmOrderDelivery : Form
    {
        //class level/global variable for the one employee object and one site object
        Employee employee = null;

        //global variable for the txn sent in
        Txn txn = null;

        //global variable for the delivery details
        Delivery delivery = null;

        public ConfirmOrderDelivery(Employee employeeLoggedIn, Txn txnDelivered)
        {
            InitializeComponent();
            employee = employeeLoggedIn;
            txn = txnDelivered;
            delivery = DeliveryAccessor.GetOneDelivery(txn.deliveryID);
        }

        private void ConfirmOrderDelivery_Load(object sender, EventArgs e)
        {
            //setting the tooltip for the help image
            toolTipHelp.SetToolTip(picHelp, "Click here for help.");

            //display the employee's username and location in this form
            lblUsername.Text = employee.username;
            lblLocation.Text = employee.siteName;

            //getting delivery obj
            //Delivery delivery = DeliveryAccessor.GetOneDelivery(txn.deliveryID);

            //populate labels/any other controls
            lblTxnID.Text = txn.txnID.ToString();
            //lblDeliveryID.Text = txn.deliveryID.ToString();
            lblDestinationSite.Text = txn.destinationSite;
            lblTxnType.Text = txn.txnType;

            if (delivery != null)
            {
                lblVehicleType.Text = delivery.vehicleType;
                lblDeliveryID.Text = delivery.deliveryID.ToString();
            }

            else
            {
                lblVehicleType.Text = "N/A";
                lblDeliveryID.Text = "N/A";
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
            MessageBox.Show("This is the form for confirming the delivery of an order that was in transit. Please enter an accurate number for the delivery time here, as well as a valid signature." +
            "\n\nClick on the 'confirm' button when you're ready to confirm the order's delivery.", "Confirm Order Delivery Help"
            , MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void ConfirmOrderDelivery_KeyDown(object sender, KeyEventArgs e)
        {
            //if the F1 key is pressed down
            if (e.KeyCode == Keys.F1)
            {
                MessageBox.Show("This is the form for confirming the delivery of an order that was in transit. Please enter an accurate number for the delivery time here, as well as a valid signature." +
                "\n\nClick on the 'confirm' button when you're ready to confirm the order's delivery.", "Confirm Order Delivery Help"
                , MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            //var for employee full name
            string fullName = (employee.firstName + " " + employee.lastName).ToLower();

            //doing a signature check for the user that is logged in
            if (txtSignature.Text.ToLower() != fullName &&
                txtSignature.Text.ToLower() != employee.username)
            {
                MessageBox.Show("Invalid signature, user name not recognized." +
                    "\n\nFor an order delivery signature, please enter your first and last name separated by a space, or your username.", "Invalid Signature",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtSignature.Focus();

                return;
            }

            //doing a delivery time check
            if (nudDeliveryTime.Value < 0.1m || nudDeliveryTime.Value > 24.0m)
            {
                MessageBox.Show("Delivery time for a store order can't be under 0.1 hours, or over 24 hours." +
                    "Please enter a valid delivery time.", "Invalid Delivery Time",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                nudDeliveryTime.Focus();

                return;
            }

            DialogResult btnValueReturned = MessageBox.Show("Confirm delivery for site -  " + txn.destinationSite + "?" +
            "\n\nDelivery Time: " + nudDeliveryTime.Value + " hours." +
            "\nSignature: " + txtSignature.Text + ".", "Confirm Order Delivery", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            //if - user selects the yes btn
            if (btnValueReturned == DialogResult.Yes)
            {
                //if the delivery object is NOT null, can calculate the delivery cost
                if (delivery != null)
                {
                    //need to get the warehouse to store distance first
                    int distanceKM = DeliveryCalculator.GetWarehouseToStoreDistance(txn.siteIDTo);

                    //need a vehicle object next
                    Vehicle vehicle = VehicleAccessor.GetOneVehicle(delivery.vehicleType);

                    //now can calculate the delivery cost
                    decimal deliveryCost = DeliveryCalculator.CalculateDeliveryCost(vehicle, distanceKM, nudDeliveryTime.Value);

                    //updating the delivery object
                    delivery.distanceCost = deliveryCost;

                    //var for notes signature
                    string notesSignature = " Delivery Signature: " + txtSignature.Text;

                    delivery.notes = notesSignature;

                    //now can update the delivery cost
                    bool distanceCostUpdate = DeliveryAccessor.UpdateDistanceCostAndNotes(delivery);

                    //updating the txn's status to Delivered
                    txn.status = "Delivered";

                    //now can update the txn as well
                    bool orderDeliveredUpdate = TxnAccessor.UpdateTxnStatus(txn);

                    //if success from both updates
                    if (distanceCostUpdate && orderDeliveredUpdate)
                    {
                        MessageBox.Show("Store order has been confirmed as successfully delivered, and the distance cost has been calculated as well." +
                            "\n\nDistance Cost: " + deliveryCost.ToString("c") + "." +
                            "\nOrder Delivery Signature: " + txtSignature.Text + ".", "Order Delivery Confirmed");

                        this.Close();
                    }
                }

                //else - the delivery object is null, so we don't have a delivery ID or vehicle type
                //just want to update the txn then
                else
                {
                    //var for notes signature
                    //are going to put this in the txn table instead
                    string notesSignature = "Delivery Signature: " + txtSignature.Text;

                    //updating the txn's status to Delivered
                    //and notes as well
                    txn.status = "Delivered";
                    txn.notes = notesSignature;

                    //now can update the txn as well
                    bool orderDeliveredUpdate = TxnAccessor.UpdateTxnStatusAndNotes(txn);

                    //if success from both updates
                    if (orderDeliveredUpdate)
                    {
                        MessageBox.Show("Store order has been confirmed as successfully delivered." +
                            "\n\nOrder Delivery Signature: " + txtSignature.Text + ".", "Order Delivery Confirmed");

                        this.Close();
                    }
                }
            }
        }
    }
}
