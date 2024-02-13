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
        //selectAllStatement - are not selecting any txns by default that are COMPLETE (closed), CANCELLED, or REJECTED
        private static string selectAllStatement = "select t.txnID, s2.name as originSite, s.name as destinationSite, t.siteIDTo, t.siteIDFrom, t.status, t.shipDate, t.txnType, t.barCode, t.createdDate, IFNULL(t.deliveryID, '') as deliveryID, IFNULL(t.emergencyDelivery, '') as emergencyDelivery, IFNULL(t.notes, '') as notes from txn t " +
            "inner join site s on t.siteIDTo = s.siteID inner join site s2 on t.siteIDFrom = s2.siteID where t.Status NOT IN ('Complete', 'Cancelled', 'Rejected')";
        private static string selectAllBySiteStatement = "select t.txnID, s2.name as originSite, s.name as destinationSite, t.siteIDTo, t.siteIDFrom, t.status, t.shipDate, t.txnType, t.barCode, t.createdDate, IFNULL(t.deliveryID, '') as deliveryID, IFNULL(t.emergencyDelivery, '') as emergencyDelivery, IFNULL(t.notes, '') as notes from txn t " +
            "inner join site s on t.siteIDTo = s.siteID inner join site s2 on t.siteIDFrom = s2.siteID where t.Status NOT IN ('Complete', 'Cancelled', 'Rejected') and (t.siteIDTo = @destinationSite or t.siteIDFrom = @originSite)";
        private static string selectAllByStatusStatement = "select t.txnID, s2.name as originSite, s.name as destinationSite, t.siteIDTo, t.siteIDFrom, t.status, t.shipDate, t.txnType, t.barCode, t.createdDate, IFNULL(t.deliveryID, '') as deliveryID, IFNULL(t.emergencyDelivery, '') as emergencyDelivery, IFNULL(t.notes, '') as notes from txn t " +
            "inner join site s on t.siteIDTo = s.siteID inner join site s2 on t.siteIDFrom = s2.siteID where t.status = @status";
        private static string selectAllByStatusAndSiteStatement = "select t.txnID, s2.name as originSite, s.name as destinationSite, t.siteIDTo, t.siteIDFrom, t.status, t.shipDate, t.txnType, t.barCode, t.createdDate, IFNULL(t.deliveryID, '') as deliveryID, IFNULL(t.emergencyDelivery, '') as emergencyDelivery, IFNULL(t.notes, '') as notes from txn t " +
    "inner join site s on t.siteIDTo = s.siteID inner join site s2 on t.siteIDFrom = s2.siteID where t.status = @status and (t.siteIDTo = @destinationSite or t.siteIDFrom = @originSite)";
        private static string selectOneStatement = "select t.txnID, s2.name as originSite, s.name as destinationSite, t.siteIDTo, t.siteIDFrom, t.status, t.shipDate, t.txnType, t.barCode, t.createdDate, IFNULL(t.deliveryID, '') as deliveryID, IFNULL(t.emergencyDelivery, '') as emergencyDelivery, IFNULL(t.notes, '') as notes from txn t " +
            "inner join site s on t.siteIDTo = s.siteID inner join site s2 on t.siteIDFrom = s2.siteID where t.txnID = @txnID";
        private static string selectCountActiveOrdersForSiteStatement = "select count(*) from txn where siteIDTo = @siteIDTo and status NOT IN ('Complete', 'Cancelled', 'Rejected') and txnType IN ('Store Order', 'Emergency')";

        /**
        * Get all of the txns (except for ones that are closed/cancelled/rejected/etc.).
        *
        * @return a DataTable, possibly empty, of Txns.
        */
        public static DataTable GetAllTxnsDataTable()
        {
            //create a command
            MySqlCommand cmd = new MySqlCommand(selectAllStatement, connection);

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
        * Get all of the txns for a particular site location.
        *
        * @return a DataTable, possibly empty, of Txns.
        */
        public static DataTable GetAllTxnsBySiteDataTable(int inSiteID)
        {
            //create a command
            MySqlCommand cmd = new MySqlCommand(selectAllBySiteStatement, connection);

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
        * Get all of the txns for a particular txn status.
        *
        * @return a DataTable, possibly empty, of Txns.
        */
        public static DataTable GetAllTxnsByStatusDataTable(string status)
        {
            //create a command
            MySqlCommand cmd = new MySqlCommand(selectAllByStatusStatement, connection);

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
        * Get all of the txns for a particular txn status AND site.
        *
        * @return a DataTable, possibly empty, of Txns.
        */
        public static DataTable GetAllTxnsByStatusAndSiteDataTable(string status, int inSiteID)
        {
            //create a command
            MySqlCommand cmd = new MySqlCommand(selectAllByStatusAndSiteStatement, connection);

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
        * Gets all transactions.
        *
        * @return a list of Txn objects.
        */
        public static List<Txn> GetAllTxnsList()
        {
            //create a command
            MySqlCommand cmd = new MySqlCommand(selectAllStatement, connection);

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
        * Gets one txn, based on the txnID.
        *
        * @param int txnID
        * @return a Txn object, possibly null if none found based on the txnID.
        */
        public static Txn GetOneTxn(int inTxnID)
        {
            //create a command
            MySqlCommand cmd = new MySqlCommand(selectOneStatement, connection);

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
                    int deliveryID = reader.GetInt32("deliveryID");
                    byte emergencyDelivery = reader.GetByte("emergencyDelivery");
                    string notes = reader.GetString("notes");

                    //create a txn object
                    txn = new Txn(txnID, originSite, destinationSite, siteIDTo, siteIDFrom, status,
                        shipDate, txnType, barCode, createdDate, deliveryID, emergencyDelivery, notes);
                }

                //close reader after if statement
                reader.Close();

                //close the connection
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Getting the one Transaction");

                connection.Close();
            }

            //return the employee
            return txn;
        }

        /**
        * Gets the count (number) of active store/emergency orders for a particular site.
        *
        * @return a long, possibly 0 if none found based on siteIDTo.
        */
        public static long GetCountOfActiveOrdersForSite(int siteIDTo)
        {
            //create a command
            MySqlCommand cmd = new MySqlCommand(selectCountActiveOrdersForSiteStatement, connection);

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

            //return the rowCount (int)
            return rowCount;
        }
    }
}
