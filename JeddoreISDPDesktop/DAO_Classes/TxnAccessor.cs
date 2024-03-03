using JeddoreISDPDesktop.Entity_Classes;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Windows.Forms;

namespace JeddoreISDPDesktop.DAO_Classes
{
    //DAO public static class for Txn
    public static class TxnAccessor
    {
        //private static connection string
        private static string connString = ConfigurationManager.ConnectionStrings["ISDPConnString"].ConnectionString;

        //create a connection
        private static MySqlConnection connection = new MySqlConnection(connString);

        //SQL statements for the Txn entity
        //selectAllOrdersStatement - are not selecting any txns by default that are COMPLETE (closed), CANCELLED, or REJECTED
        //and txns have to be either a STORE ORDER or an EMERGENCY order
        private static string selectAllOrdersStatement = "select t.txnID, s2.name as originSite, s.name as destinationSite, t.siteIDTo, t.siteIDFrom, t.status, t.shipDate, t.txnType, t.barCode, t.createdDate, IFNULL(t.deliveryID, '') as deliveryID, IFNULL(t.emergencyDelivery, '') as emergencyDelivery, IFNULL(t.notes, '') as notes from txn t " +
            "inner join site s on t.siteIDTo = s.siteID inner join site s2 on t.siteIDFrom = s2.siteID where t.Status NOT IN ('Complete', 'Cancelled', 'Rejected') and txnType IN ('Store Order', 'Emergency', 'Back Order')";
        private static string selectAllOrdersBySiteStatement = "select t.txnID, s2.name as originSite, s.name as destinationSite, t.siteIDTo, t.siteIDFrom, t.status, t.shipDate, t.txnType, t.barCode, t.createdDate, IFNULL(t.deliveryID, '') as deliveryID, IFNULL(t.emergencyDelivery, '') as emergencyDelivery, IFNULL(t.notes, '') as notes from txn t " +
            "inner join site s on t.siteIDTo = s.siteID inner join site s2 on t.siteIDFrom = s2.siteID where t.Status NOT IN ('Complete', 'Cancelled', 'Rejected') and txnType IN ('Store Order', 'Emergency', 'Back Order') and (t.siteIDTo = @destinationSite or t.siteIDFrom = @originSite)";
        private static string selectAllOrdersByStatusStatement = "select t.txnID, s2.name as originSite, s.name as destinationSite, t.siteIDTo, t.siteIDFrom, t.status, t.shipDate, t.txnType, t.barCode, t.createdDate, IFNULL(t.deliveryID, '') as deliveryID, IFNULL(t.emergencyDelivery, '') as emergencyDelivery, IFNULL(t.notes, '') as notes from txn t " +
            "inner join site s on t.siteIDTo = s.siteID inner join site s2 on t.siteIDFrom = s2.siteID where t.status = @status and txnType IN ('Store Order', 'Emergency', 'Back Order')";
        private static string selectAllOrdersByStatusAndSiteStatement = "select t.txnID, s2.name as originSite, s.name as destinationSite, t.siteIDTo, t.siteIDFrom, t.status, t.shipDate, t.txnType, t.barCode, t.createdDate, IFNULL(t.deliveryID, '') as deliveryID, IFNULL(t.emergencyDelivery, '') as emergencyDelivery, IFNULL(t.notes, '') as notes from txn t " +
    "inner join site s on t.siteIDTo = s.siteID inner join site s2 on t.siteIDFrom = s2.siteID where t.status = @status and txnType IN ('Store Order', 'Emergency', 'Back Order') and (t.siteIDTo = @destinationSite or t.siteIDFrom = @originSite)";
        private static string selectAllOrdersByStatusAndSiteFromOnlyStatement = "select t.txnID, s2.name as originSite, s.name as destinationSite, t.siteIDTo, t.siteIDFrom, t.status, t.shipDate, t.txnType, t.barCode, t.createdDate, IFNULL(t.deliveryID, '') as deliveryID, IFNULL(t.emergencyDelivery, '') as emergencyDelivery, IFNULL(t.notes, '') as notes from txn t " +
"inner join site s on t.siteIDTo = s.siteID inner join site s2 on t.siteIDFrom = s2.siteID where t.status = @status and txnType IN ('Store Order', 'Emergency', 'Back Order') and t.siteIDFrom = @originSite";
        //getting the last/most recent txn record, mostly for the barcode
        private static string selectLastTxnStatement = "select t.txnID, s2.name as originSite, s.name as destinationSite, t.siteIDTo, t.siteIDFrom, t.status, t.shipDate, t.txnType, t.barCode, t.createdDate from txn t " +
            "inner join site s on t.siteIDTo = s.siteID inner join site s2 on t.siteIDFrom = s2.siteID order by t.txnID DESC LIMIT 1";
        private static string selectOneOrderStatement = "select t.txnID, s2.name as originSite, s.name as destinationSite, t.siteIDTo, t.siteIDFrom, t.status, t.shipDate, t.txnType, t.barCode, t.createdDate from txn t " +
            "inner join site s on t.siteIDTo = s.siteID inner join site s2 on t.siteIDFrom = s2.siteID where t.txnID = @txnID and txnType IN ('Store Order', 'Emergency')";
        private static string selectOneBackOrderStatement = "select t.txnID, s2.name as originSite, s.name as destinationSite, t.siteIDTo, t.siteIDFrom, t.status, t.shipDate, t.txnType, t.barCode, t.createdDate from txn t " +
            "inner join site s on t.siteIDTo = s.siteID inner join site s2 on t.siteIDFrom = s2.siteID where t.txnID = @txnID and txnType = 'Back Order'";
        private static string selectOneTxnStatement = "select t.txnID, s2.name as originSite, s.name as destinationSite, t.siteIDTo, t.siteIDFrom, t.status, t.shipDate, t.txnType, t.barCode, t.createdDate from txn t " +
            "inner join site s on t.siteIDTo = s.siteID inner join site s2 on t.siteIDFrom = s2.siteID where t.txnID = @txnID";
        //despite the name, these next 2 statements will get a site's new, submitted, or assembling store/back order
        //NOTE: may change this later
        private static string selectSiteNewOrderStatement = "select t.txnID, s2.name as originSite, s.name as destinationSite, t.siteIDTo, t.siteIDFrom, t.status, t.shipDate, t.txnType, t.barCode, t.createdDate from txn t inner join site s on t.siteIDTo = s.siteID inner join site s2 on t.siteIDFrom = s2.siteID where status = 'New' and txnType IN ('Store Order', 'Emergency') and t.siteIDTo = @siteID";
        private static string selectSiteNewOrSubmittedOrderStatement = "select t.txnID, s2.name as originSite, s.name as destinationSite, t.siteIDTo, t.siteIDFrom, t.status, t.shipDate, t.txnType, t.barCode, t.createdDate from txn t inner join site s on t.siteIDTo = s.siteID inner join site s2 on t.siteIDFrom = s2.siteID where status IN ('New', 'Submitted', 'Assembling') and txnType IN ('Store Order', 'Emergency') and t.siteIDTo = @siteID";
        private static string selectSiteActiveOrderStatement = "select t.txnID, s2.name as originSite, s.name as destinationSite, t.siteIDTo, t.siteIDFrom, t.status, t.shipDate, t.txnType, t.barCode, t.createdDate from txn t inner join site s on t.siteIDTo = s.siteID inner join site s2 on t.siteIDFrom = s2.siteID where status NOT IN ('Complete', 'Cancelled', 'Rejected') and txnType IN ('Store Order', 'Emergency') and t.siteIDTo = @siteID";
        private static string selectSiteNewBackOrderStatement = "select t.txnID, s2.name as originSite, s.name as destinationSite, t.siteIDTo, t.siteIDFrom, t.status, t.shipDate, t.txnType, t.barCode, t.createdDate from txn t inner join site s on t.siteIDTo = s.siteID inner join site s2 on t.siteIDFrom = s2.siteID where status IN ('New', 'Submitted', 'Assembling') and txnType IN ('Back Order') and t.siteIDTo = @siteID";
        private static string selectCountActiveNewOrdersForSiteStatement = "select count(*) from txn where siteIDTo = @siteIDTo and status = 'New' and txnType IN ('Store Order', 'Emergency')";
        private static string selectCountActiveBackOrdersForSiteStatement = "select count(*) from txn where siteIDTo = @siteIDTo and status NOT IN ('Complete', 'Cancelled', 'Rejected') and txnType IN ('Back Order')";
        private static string insertTxnStatement = " insert into `txn` (`siteIDTo`, `siteIDFrom`, `status`, `shipDate`, `txnType`, `barCode`, `createdDate`, `emergencyDelivery`) VALUES " +
            "(@siteIDTo, @siteIDFrom, @status, @shipDate, @txnType, @barCode, @createdDate, @emergencyDelivery)";
        private static string updateTxnShipDateStatement = "update txn set shipDate = @shipDate where txnID = @txnID";
        private static string updateTxnStatusStatement = "update txn set status = @status where txnID = @txnID";

        /**
        * Get all of the orders (except for ones that are closed/cancelled/rejected/etc.).
        *
        * @return a DataTable, possibly empty, of Txns.
        */
        public static DataTable GetAllOrdersDataTable()
        {
            //create a command
            MySqlCommand cmd = new MySqlCommand(selectAllOrdersStatement, connection);

            //create datatable
            DataTable dt = new DataTable();

            //create a datareader and execute
            try
            {
                connection.Open();

                //execute the SQL statement against the DB
                //load into the DataTable object
                dt.Load(cmd.ExecuteReader());

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Getting All Open Transactions");

                connection.Close();
            }

            //return the datatable
            return dt;
        }

        /**
        * Get all of the orders for a particular site location.
        *
        * @return a DataTable, possibly empty, of Txns.
        */
        public static DataTable GetAllOrdersBySiteDataTable(int inSiteID)
        {
            //create a command
            MySqlCommand cmd = new MySqlCommand(selectAllOrdersBySiteStatement, connection);

            //create datatable
            DataTable dt = new DataTable();

            //two parameters for the query - inSiteID is used twice
            cmd.Parameters.AddWithValue("@destinationSite", inSiteID);
            cmd.Parameters.AddWithValue("@originSite", inSiteID);

            //create a datareader and execute
            try
            {
                connection.Open();

                //execute the SQL statement against the DB
                //load into the DataTable object
                dt.Load(cmd.ExecuteReader());

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Getting Transactions by Site");

                connection.Close();
            }

            //return the datatable
            return dt;
        }

        /**
        * Get all of the orders for a particular txn status.
        *
        * @return a DataTable, possibly empty, of Txns.
        */
        public static DataTable GetAllOrdersByStatusDataTable(string status)
        {
            //create a command
            MySqlCommand cmd = new MySqlCommand(selectAllOrdersByStatusStatement, connection);

            //create datatable
            DataTable dt = new DataTable();

            //one parameter for the query - int txnID
            cmd.Parameters.AddWithValue("@status", status);

            //create a datareader and execute
            try
            {
                connection.Open();

                //execute the SQL statement against the DB
                //load into the DataTable object
                dt.Load(cmd.ExecuteReader());

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Getting Transactions by Status");

                connection.Close();
            }

            //return the datatable
            return dt;
        }

        /**
        * Get all of the orders for a particular txn status AND site.
        *
        * @return a DataTable, possibly empty, of Txns.
        */
        public static DataTable GetAllOrdersByStatusAndSiteDataTable(string status, int inSiteID)
        {
            //create a command
            MySqlCommand cmd = new MySqlCommand(selectAllOrdersByStatusAndSiteStatement, connection);

            //create datatable
            DataTable dt = new DataTable();

            //three parameters for the query - status and siteID (twice)
            cmd.Parameters.AddWithValue("@status", status);
            cmd.Parameters.AddWithValue("@destinationSite", inSiteID);
            cmd.Parameters.AddWithValue("@originSite", inSiteID);

            //create a datareader and execute
            try
            {
                connection.Open();

                //execute the SQL statement against the DB
                //load into the DataTable object
                dt.Load(cmd.ExecuteReader());

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Getting Transactions by Status and Site");

                connection.Close();
            }

            //return the datatable
            return dt;
        }

        /**
        * Get all of the orders for a particular txn status AND site (origin/from site only).
        *
        * @return a DataTable, possibly empty, of Txns.
        */
        public static DataTable GetAllOrdersByStatusAndSiteFromDataTable(string status, int inSiteID)
        {
            //create a command
            MySqlCommand cmd = new MySqlCommand(selectAllOrdersByStatusAndSiteFromOnlyStatement, connection);

            //create datatable
            DataTable dt = new DataTable();

            //three parameters for the query - status and siteID (twice)
            cmd.Parameters.AddWithValue("@status", status);
            cmd.Parameters.AddWithValue("@originSite", inSiteID);

            //create a datareader and execute
            try
            {
                connection.Open();

                //execute the SQL statement against the DB
                //load into the DataTable object
                dt.Load(cmd.ExecuteReader());

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Getting Transactions by Status and Site");

                connection.Close();
            }

            //return the datatable
            return dt;
        }

        /**
        * Gets all orders.
        *
        * @return a list of Txn objects.
        */
        public static List<Txn> GetAllOrdersList()
        {
            //create a command
            MySqlCommand cmd = new MySqlCommand(selectAllOrdersStatement, connection);

            //list of txns to be returned
            List<Txn> txnsList = new List<Txn>();

            //create a datareader and execute
            try
            {
                connection.Open();

                //create a datareader and execute the SQL statement against the DB
                MySqlDataReader reader = cmd.ExecuteReader();

                //if - there is a record to read
                while (reader.Read())
                {
                    //get the values from the columns
                    int txnID = reader.GetInt32("txnID");
                    string originSite = reader.GetString("originSite");
                    string destinationSite = reader.GetString("destinationSite");
                    int siteIDTo = reader.GetInt32("siteIDTo");
                    int siteIDFrom = reader.GetInt32("siteIDFrom");
                    string status = reader.GetString("status");
                    DateTime shipDate = reader.GetDateTime("shipDate");
                    string txnType = reader.GetString("txnType");
                    string barCode = reader.GetString("barCode");
                    DateTime createdDate = reader.GetDateTime("createdDate");
                    int deliveryID = reader.GetInt32("deliveryID");
                    byte emergencyDelivery = reader.GetByte("emergencyDelivery");
                    string notes = reader.GetString("notes");

                    //create a txn object
                    Txn txn = new Txn(txnID, originSite, destinationSite, siteIDTo, siteIDFrom, status,
                        shipDate, txnType, barCode, createdDate, deliveryID, emergencyDelivery, notes);

                    //add object to the list
                    txnsList.Add(txn);
                }

                //close reader after if statement
                reader.Close();

                //close the connection
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Getting All Open Transactions");

                connection.Close();
            }

            //return the employee
            return txnsList;
        }

        /**
         * Gets the last/most recent transaction.
         *
         * @return a Txn object.
         */
        public static Txn GetLastTxn()
        {
            //create a command
            MySqlCommand cmd = new MySqlCommand(selectLastTxnStatement, connection);

            //txn to be returned
            Txn txn = null;

            //create a datareader and execute
            try
            {
                connection.Open();

                //create a datareader and execute the SQL statement against the DB
                MySqlDataReader reader = cmd.ExecuteReader();

                //if - there is a record to read
                if (reader.Read())
                {
                    //get the values from the columns
                    int txnID = reader.GetInt32("txnID");
                    string originSite = reader.GetString("originSite");
                    string destinationSite = reader.GetString("destinationSite");
                    int siteIDTo = reader.GetInt32("siteIDTo");
                    int siteIDFrom = reader.GetInt32("siteIDFrom");
                    string status = reader.GetString("status");
                    DateTime shipDate = reader.GetDateTime("shipDate");
                    string txnType = reader.GetString("txnType");
                    string barCode = reader.GetString("barCode");
                    DateTime createdDate = reader.GetDateTime("createdDate");
                    //int deliveryID = reader.GetInt32("deliveryID");
                    //byte emergencyDelivery = reader.GetByte("emergencyDelivery");
                    //string notes = reader.GetString("notes");

                    //create a txn object
                    txn = new Txn(txnID, originSite, destinationSite, siteIDTo, siteIDFrom, status,
                        shipDate, txnType, barCode, createdDate);
                }

                //close reader after if statement
                reader.Close();

                //close the connection
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Getting the Last Transaction");

                connection.Close();
            }

            //return the txn
            return txn;
        }

        /**
        * Gets one order, based on the txnID. MUST be a store or emergency order.
        *
        * @param int txnID
        * @return a Txn object, possibly null if none found based on the txnID.
        */
        public static Txn GetOneOrder(int inTxnID)
        {
            //create a command
            MySqlCommand cmd = new MySqlCommand(selectOneOrderStatement, connection);

            //txn to be returned
            Txn txn = null;

            //one parameter for the query - int txnID
            cmd.Parameters.AddWithValue("@txnID", inTxnID);

            //create a datareader and execute
            try
            {
                connection.Open();

                //create a datareader and execute the SQL statement against the DB
                MySqlDataReader reader = cmd.ExecuteReader();

                //if - there is a record to read
                if (reader.Read())
                {
                    //get the values from the columns
                    int txnID = reader.GetInt32("txnID");
                    string originSite = reader.GetString("originSite");
                    string destinationSite = reader.GetString("destinationSite");
                    int siteIDTo = reader.GetInt32("siteIDTo");
                    int siteIDFrom = reader.GetInt32("siteIDFrom");
                    string status = reader.GetString("status");
                    DateTime shipDate = reader.GetDateTime("shipDate");
                    string txnType = reader.GetString("txnType");
                    string barCode = reader.GetString("barCode");
                    DateTime createdDate = reader.GetDateTime("createdDate");
                    //int deliveryID = reader.GetInt32("deliveryID");
                    //byte emergencyDelivery = reader.GetByte("emergencyDelivery");
                    //string notes = reader.GetString("notes");

                    //create a txn object
                    txn = new Txn(txnID, originSite, destinationSite, siteIDTo, siteIDFrom, status,
                        shipDate, txnType, barCode, createdDate);
                }

                //close reader after if statement
                reader.Close();

                //close the connection
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Getting the One Order");

                connection.Close();
            }

            //return the txn
            return txn;
        }

        /**
        * Gets one back order, based on the txnID.
        *
        * @param int txnID
        * @return a Txn object, possibly null if none found based on the txnID.
        */
        public static Txn GetOneBackOrder(int inTxnID)
        {
            //create a command
            MySqlCommand cmd = new MySqlCommand(selectOneBackOrderStatement, connection);

            //txn to be returned
            Txn txn = null;

            //one parameter for the query - int txnID
            cmd.Parameters.AddWithValue("@txnID", inTxnID);

            //create a datareader and execute
            try
            {
                connection.Open();

                //create a datareader and execute the SQL statement against the DB
                MySqlDataReader reader = cmd.ExecuteReader();

                //if - there is a record to read
                if (reader.Read())
                {
                    //get the values from the columns
                    int txnID = reader.GetInt32("txnID");
                    string originSite = reader.GetString("originSite");
                    string destinationSite = reader.GetString("destinationSite");
                    int siteIDTo = reader.GetInt32("siteIDTo");
                    int siteIDFrom = reader.GetInt32("siteIDFrom");
                    string status = reader.GetString("status");
                    DateTime shipDate = reader.GetDateTime("shipDate");
                    string txnType = reader.GetString("txnType");
                    string barCode = reader.GetString("barCode");
                    DateTime createdDate = reader.GetDateTime("createdDate");

                    //create a txn object
                    txn = new Txn(txnID, originSite, destinationSite, siteIDTo, siteIDFrom, status,
                        shipDate, txnType, barCode, createdDate);
                }

                //close reader after if statement
                reader.Close();

                //close the connection
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Getting the One Back Order");

                connection.Close();
            }

            //return the txn
            return txn;
        }

        /**
        * Gets one txn, based on the txnID.
        *
        * @param int txnID
        * @return a Txn object, possibly null if none found based on the txnID.
        */
        public static Txn GetOneTxn(int inTxnID)
        {
            //create a command
            MySqlCommand cmd = new MySqlCommand(selectOneTxnStatement, connection);

            //txn to be returned
            Txn txn = null;

            //one parameter for the query - int txnID
            cmd.Parameters.AddWithValue("@txnID", inTxnID);

            //create a datareader and execute
            try
            {
                connection.Open();

                //create a datareader and execute the SQL statement against the DB
                MySqlDataReader reader = cmd.ExecuteReader();

                //if - there is a record to read
                if (reader.Read())
                {
                    //get the values from the columns
                    int txnID = reader.GetInt32("txnID");
                    string originSite = reader.GetString("originSite");
                    string destinationSite = reader.GetString("destinationSite");
                    int siteIDTo = reader.GetInt32("siteIDTo");
                    int siteIDFrom = reader.GetInt32("siteIDFrom");
                    string status = reader.GetString("status");
                    DateTime shipDate = reader.GetDateTime("shipDate");
                    string txnType = reader.GetString("txnType");
                    string barCode = reader.GetString("barCode");
                    DateTime createdDate = reader.GetDateTime("createdDate");

                    //create a txn object
                    txn = new Txn(txnID, originSite, destinationSite, siteIDTo, siteIDFrom, status,
                        shipDate, txnType, barCode, createdDate);
                }

                //close reader after if statement
                reader.Close();

                //close the connection
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Getting the One Txn");

                connection.Close();
            }

            //return the txn
            return txn;
        }

        /**
        * Gets one store OR emergency order with the status of 'New', based on the siteID. (The current store or emergency order for a store)
        *
        * @param int siteID
        * @return a Txn object, possibly null if none found based on the siteID.
        */
        public static Txn GetOneNewOrder(int inSiteID)
        {
            //create a command
            MySqlCommand cmd = new MySqlCommand(selectSiteNewOrderStatement, connection);

            //txn to be returned
            Txn txn = null;

            //one parameter for the query - int txnID
            cmd.Parameters.AddWithValue("@siteID", inSiteID);

            //create a datareader and execute
            try
            {
                connection.Open();

                //create a datareader and execute the SQL statement against the DB
                MySqlDataReader reader = cmd.ExecuteReader();

                //if - there is a record to read
                if (reader.Read())
                {
                    //get the values from the columns
                    int txnID = reader.GetInt32("txnID");
                    string originSite = reader.GetString("originSite");
                    string destinationSite = reader.GetString("destinationSite");
                    int siteIDTo = reader.GetInt32("siteIDTo");
                    int siteIDFrom = reader.GetInt32("siteIDFrom");
                    string status = reader.GetString("status");
                    DateTime shipDate = reader.GetDateTime("shipDate");
                    string txnType = reader.GetString("txnType");
                    string barCode = reader.GetString("barCode");
                    DateTime createdDate = reader.GetDateTime("createdDate");

                    //create a txn object
                    txn = new Txn(txnID, originSite, destinationSite, siteIDTo, siteIDFrom, status,
                        shipDate, txnType, barCode, createdDate);
                }

                //close reader after if statement
                reader.Close();

                //close the connection
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Getting the One New Store/Emergency Order");

                connection.Close();
            }

            //return the txn
            return txn;
        }

        /**
        * Gets one store OR emergency order with the status of 'New', 'Submitted', or 'Assembling', based on the siteID. (The current order for a store)
        *
        * @param int siteID
        * @return a Txn object, possibly null if none found based on the siteID.
        */
        public static Txn GetOneNewOrSubmittedOrInAssemblyOrder(int inSiteID)
        {
            //create a command
            MySqlCommand cmd = new MySqlCommand(selectSiteNewOrSubmittedOrderStatement, connection);

            //txn to be returned
            Txn txn = null;

            //one parameter for the query - int txnID
            cmd.Parameters.AddWithValue("@siteID", inSiteID);

            //create a datareader and execute
            try
            {
                connection.Open();

                //create a datareader and execute the SQL statement against the DB
                MySqlDataReader reader = cmd.ExecuteReader();

                //if - there is a record to read
                if (reader.Read())
                {
                    //get the values from the columns
                    int txnID = reader.GetInt32("txnID");
                    string originSite = reader.GetString("originSite");
                    string destinationSite = reader.GetString("destinationSite");
                    int siteIDTo = reader.GetInt32("siteIDTo");
                    int siteIDFrom = reader.GetInt32("siteIDFrom");
                    string status = reader.GetString("status");
                    DateTime shipDate = reader.GetDateTime("shipDate");
                    string txnType = reader.GetString("txnType");
                    string barCode = reader.GetString("barCode");
                    DateTime createdDate = reader.GetDateTime("createdDate");
                    //int deliveryID = reader.GetInt32("deliveryID");
                    //byte emergencyDelivery = reader.GetByte("emergencyDelivery");
                    //string notes = reader.GetString("notes");

                    //create a txn object
                    txn = new Txn(txnID, originSite, destinationSite, siteIDTo, siteIDFrom, status,
                        shipDate, txnType, barCode, createdDate);
                }

                //close reader after if statement
                reader.Close();

                //close the connection
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Getting the One New, Submitted, or Assembling Store/Emergency Order");

                connection.Close();
            }

            //return the txn
            return txn;
        }

        /**
        * Gets one active store OR emergency order  that is not complete, rejected, or cancelled for a site based on the siteID. (The current order for a store)
        *
        * @param int siteID
        * @return a Txn object, possibly null if none found based on the siteID.
        */
        public static Txn GetOneActiveOrder(int inSiteID)
        {
            //create a command
            MySqlCommand cmd = new MySqlCommand(selectSiteActiveOrderStatement, connection);

            //txn to be returned
            Txn txn = null;

            //one parameter for the query - int txnID
            cmd.Parameters.AddWithValue("@siteID", inSiteID);

            //create a datareader and execute
            try
            {
                connection.Open();

                //create a datareader and execute the SQL statement against the DB
                MySqlDataReader reader = cmd.ExecuteReader();

                //if - there is a record to read
                if (reader.Read())
                {
                    //get the values from the columns
                    int txnID = reader.GetInt32("txnID");
                    string originSite = reader.GetString("originSite");
                    string destinationSite = reader.GetString("destinationSite");
                    int siteIDTo = reader.GetInt32("siteIDTo");
                    int siteIDFrom = reader.GetInt32("siteIDFrom");
                    string status = reader.GetString("status");
                    DateTime shipDate = reader.GetDateTime("shipDate");
                    string txnType = reader.GetString("txnType");
                    string barCode = reader.GetString("barCode");
                    DateTime createdDate = reader.GetDateTime("createdDate");

                    //create a txn object
                    txn = new Txn(txnID, originSite, destinationSite, siteIDTo, siteIDFrom, status,
                        shipDate, txnType, barCode, createdDate);
                }

                //close reader after if statement
                reader.Close();

                //close the connection
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Getting the One Active Order");

                connection.Close();
            }

            //return the txn
            return txn;
        }

        /**
        * Gets one back order with the status of 'New', 'Submitted', or 'Assembling', based on the siteID. (The current back order for a store)
        *
        * @param int siteID
        * @return a Txn object, possibly null if none found based on the siteID.
        */
        public static Txn GetOneNewBackOrder(int inSiteID)
        {
            //create a command
            MySqlCommand cmd = new MySqlCommand(selectSiteNewBackOrderStatement, connection);

            //txn to be returned
            Txn txn = null;

            //one parameter for the query - int txnID
            cmd.Parameters.AddWithValue("@siteID", inSiteID);

            //create a datareader and execute
            try
            {
                connection.Open();

                //create a datareader and execute the SQL statement against the DB
                MySqlDataReader reader = cmd.ExecuteReader();

                //if - there is a record to read
                if (reader.Read())
                {
                    //get the values from the columns
                    int txnID = reader.GetInt32("txnID");
                    string originSite = reader.GetString("originSite");
                    string destinationSite = reader.GetString("destinationSite");
                    int siteIDTo = reader.GetInt32("siteIDTo");
                    int siteIDFrom = reader.GetInt32("siteIDFrom");
                    string status = reader.GetString("status");
                    DateTime shipDate = reader.GetDateTime("shipDate");
                    string txnType = reader.GetString("txnType");
                    string barCode = reader.GetString("barCode");
                    DateTime createdDate = reader.GetDateTime("createdDate");

                    //create a txn object
                    txn = new Txn(txnID, originSite, destinationSite, siteIDTo, siteIDFrom, status,
                        shipDate, txnType, barCode, createdDate);
                }

                //close reader after if statement
                reader.Close();

                //close the connection
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Getting the One Back Order");

                connection.Close();
            }

            //return the txn
            return txn;
        }

        /**
        * Gets the count (number) of active NEW store/emergency orders for a particular site.
        *
        * @return a long, possibly 0 if none found based on siteIDTo.
        */
        public static long GetCountOfActiveNewOrdersForSite(int siteIDTo)
        {
            //create a command
            MySqlCommand cmd = new MySqlCommand(selectCountActiveNewOrdersForSiteStatement, connection);

            //int to be returned
            long rowCount = 0;

            //one parameter for the query - string username
            cmd.Parameters.AddWithValue("@siteIDTo", siteIDTo);

            //create a datareader and execute
            try
            {
                connection.Open();

                //create a datareader and execute the SQL statement against the DB
                //casting to a long here to prevent exception(s)
                rowCount = (long)cmd.ExecuteScalar();

                //close the connection
                connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Getting the Count of Active Orders for that Site");

                connection.Close();

            }

            //return the rowCount (long)
            return rowCount;
        }

        /**
        * Gets the count (number) of active backorders for a particular site.
        *
        * @return a long, possibly 0 if none found based on siteIDTo.
        */
        public static long GetCountOfActiveBackOrdersForSite(int siteIDTo)
        {
            //create a command
            MySqlCommand cmd = new MySqlCommand(selectCountActiveBackOrdersForSiteStatement, connection);

            //int to be returned
            long rowCount = 0;

            //one parameter for the query - string username
            cmd.Parameters.AddWithValue("@siteIDTo", siteIDTo);

            //create a datareader and execute
            try
            {
                connection.Open();

                //create a datareader and execute the SQL statement against the DB
                //casting to a long here to prevent exception(s)
                rowCount = (long)cmd.ExecuteScalar();

                //close the connection
                connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Getting the Count of Active Back Orders for that Site");

                connection.Close();

            }

            //return the rowCount (long)
            return rowCount;
        }

        /**
        * Inserts a new txn.
        *
        * @param txn object
        * @return bool - if txn was inserted or not
        */
        public static bool InsertNewTxn(Txn txn)
        {
            //create a command
            MySqlCommand cmd = new MySqlCommand(insertTxnStatement, connection);

            //many parameters for this insert query
            cmd.Parameters.AddWithValue("@siteIDTo", txn.siteIDTo);
            cmd.Parameters.AddWithValue("@siteIDFrom", txn.siteIDFrom);
            cmd.Parameters.AddWithValue("@status", txn.status);
            cmd.Parameters.AddWithValue("@shipDate", txn.shipDate);
            cmd.Parameters.AddWithValue("@txnType", txn.txnType);
            cmd.Parameters.AddWithValue("@barCode", txn.barCode);
            cmd.Parameters.AddWithValue("@createdDate", txn.createdDate);
            cmd.Parameters.AddWithValue("@emergencyDelivery", txn.emergencyDelivery);
            //cmd.Parameters.AddWithValue("@deliveryID", txn.deliveryID);
            //cmd.Parameters.AddWithValue("@notes", txn.notes);

            //variable for rowCount
            int rowCount = 0;

            //bool to be returned
            bool goodNonQuery = false;

            try
            {
                connection.Open();

                //execute a non query
                rowCount = cmd.ExecuteNonQuery();

                connection.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Inserting Transaction");

                connection.Close();
            }

            //if rowCount is 1, then non query was good
            if (rowCount == 1)
            {
                goodNonQuery = true;
            }

            return goodNonQuery;
        }

        /**
        * Updates a Txn's ship date.
        *
        * @param Txn object
        * @return bool - if the txn was updated or not
        */
        public static bool UpdateTxnShipDate(Txn txn)
        {
            //create a command
            MySqlCommand cmd = new MySqlCommand(updateTxnShipDateStatement, connection);

            //2 parameters for this update query
            cmd.Parameters.AddWithValue("@shipDate", txn.shipDate);
            cmd.Parameters.AddWithValue("@txnID", txn.txnID);

            //variable for rowCount
            int rowCount = 0;

            //bool to be returned
            bool goodNonQuery = false;

            try
            {
                connection.Open();

                //execute a non query
                rowCount = cmd.ExecuteNonQuery();

                connection.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Updating Transaction Ship Date");

                connection.Close();
            }

            //if rowCount is 1, then non query was good
            if (rowCount == 1)
            {
                goodNonQuery = true;
            }

            return goodNonQuery;
        }

        /**
        * Updates a Txn's ship date.
        *
        * @param Txn object
        * @return bool - if the txn was updated or not
        */
        public static bool UpdateTxnStatus(Txn txn)
        {
            //create a command
            MySqlCommand cmd = new MySqlCommand(updateTxnStatusStatement, connection);

            //2 parameters for this update query
            cmd.Parameters.AddWithValue("@status", txn.status);
            cmd.Parameters.AddWithValue("@txnID", txn.txnID);

            //variable for rowCount
            int rowCount = 0;

            //bool to be returned
            bool goodNonQuery = false;

            try
            {
                connection.Open();

                //execute a non query
                rowCount = cmd.ExecuteNonQuery();

                connection.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Updating Transaction Status");

                connection.Close();
            }

            //if rowCount is 1, then non query was good
            if (rowCount == 1)
            {
                goodNonQuery = true;
            }

            return goodNonQuery;
        }
    }
}
