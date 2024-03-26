using JeddoreISDPDesktop.Entity_Classes;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Windows.Forms;

namespace JeddoreISDPDesktop.DAO_Classes
{
    //public static accessor class for TxnItems
    public static class TxnItemsAccessor
    {
        //private static connection string
        private static string connString = ConfigurationManager.ConnectionStrings["ISDPConnString"].ConnectionString;

        //create a connection
        private static MySqlConnection connection = new MySqlConnection(connString);

        //SQL statements for the TxnItems entity
        private static string selectAllItemsByTxnIDStatement = "select ti.txnID, ti.itemID, i.name, IFNULL(i.description, '') as description, ti.quantity, i.caseSize, i.weight, IFNULL(ti.notes, '') as notes from txnitems ti inner join item i on ti.itemID = i.itemID where ti.txnID = @txnID";
        private static string selectOneByTxnIDAndItemIDStatement = "select ti.txnID, ti.itemID, i.name, IFNULL(i.description, '') as description, ti.quantity, i.caseSize, i.weight, IFNULL(ti.notes, '') as notes from txnitems ti inner join item i on ti.itemID = i.itemID where ti.txnID = @txnID and ti.itemID = @itemID";
        private static string selectCountItemsInTxnStatement = "select count(*) from txnitems where txnID = @txnID";
        private static string selectCountSpecificIteminTxnStatement = "select count(*) from txnitems where txnID = @txnID and itemID = @itemID";
        private static string selectTxnWeightForTxnStatement = "select ti.txnID, sum(i.weight * ti.quantity) as txnWeight from txnitems ti inner join item i on ti.itemID = i.itemID where txnID = @txnID group by ti.txnID";
        private static string selectDeliveryWeightForStoreOrdersOnShipDateStatement = "select t.shipDate, sum(i.weight * ti.quantity) as txnWeight from txnitems ti inner join item i on ti.itemID = i.itemID inner join txn t on ti.txnID = t.txnID where t.txnType IN ('Store Order', 'Emergency') and t.shipDate = @shipDate group by t.shipDate";
        private static string updateTxnItemQuantityAndNotesStatement = "update txnitems set quantity = @quantity, notes = @notes where txnID = @txnID and itemID = @itemID";
        private static string insertTxnItemStatement = "insert into `txnitems` (`txnID`, `itemID`, `quantity`, `notes`) VALUES " +
            "(@txnID, @itemID, @quantity, @notes)";
        private static string deleteTxnItemStatement = "delete from txnitems where txnID = @txnID and itemID  = @itemID";

        /**
        * Get all of the transaction items.
        *
        * @param int txnID
        * @return a DataTable, possibly empty, of TxnItems.
        */
        public static DataTable GetAllTxnItemsByTxnIDDataTable(int txnID)
        {
            //create a command
            MySqlCommand cmd = new MySqlCommand(selectAllItemsByTxnIDStatement, connection);

            //create datatable
            DataTable dt = new DataTable();

            //one parameter for the query - int txnID
            cmd.Parameters.AddWithValue("@txnID", txnID);

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
                MessageBox.Show(ex.Message, "Error Getting All Transaction Items by Transaction ID");

                connection.Close();
            }

            //return the datatable
            return dt;
        }

        /**
        * Get all of the txnitems for a specific txn, returned in a list.
        *
        * @param int inTxnID
        * @return a List, possibly empty, of TxnItems objects.
        */
        public static List<TxnItems> GetAllTxnItemsList(int inTxnID)
        {
            //create a command
            MySqlCommand cmd = new MySqlCommand(selectAllItemsByTxnIDStatement, connection);

            //list to be returned
            List<TxnItems> txnItemsList = new List<TxnItems>();

            //one parameter for the query - int txnID
            cmd.Parameters.AddWithValue("@txnID", inTxnID);

            //create a datareader and execute
            try
            {
                connection.Open();

                //create a datareader and execute the SQL statement against the DB
                MySqlDataReader reader = cmd.ExecuteReader();

                //run loop thru datareader
                //while - there is another record to read
                while (reader.Read())
                {
                    //get the values from the columns
                    int txnID = reader.GetInt32("txnID");
                    int itemID = reader.GetInt32("itemID");
                    int quantity = reader.GetInt32("quantity");
                    string notes = reader.GetString("notes");
                    string name = reader.GetString("name");
                    string description = reader.GetString("description");
                    int caseSize = reader.GetInt32("caseSize");
                    decimal weight = reader.GetDecimal("weight");

                    //create a txnitems object
                    TxnItems txnItem = new TxnItems(txnID, itemID, quantity, notes,
                        name, description, caseSize, weight);

                    //add to the list
                    txnItemsList.Add(txnItem);
                }

                //close reader after while loop
                reader.Close();

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Getting List of Transaction Items by Transaction ID");

                connection.Close();
            }

            //return the txnitems list
            return txnItemsList;
        }

        /**
        * Gets one specific item in a transaction.
        *
        * @param int txnID, int itemID
        * @return a TxnItems object, possibly null if none found based on the txnID and itemID.
        */
        public static TxnItems GetOneTxnItem(int inTxnID, int inItemID)
        {
            //create a command
            MySqlCommand cmd = new MySqlCommand(selectOneByTxnIDAndItemIDStatement, connection);

            //txn to be returned
            TxnItems txnItem = null;

            //two parameters for this query
            //are basically getting a particular item in a transaction
            cmd.Parameters.AddWithValue("@txnID", inTxnID);
            cmd.Parameters.AddWithValue("@itemID", inItemID);

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
                    int itemID = reader.GetInt32("itemID");
                    int quantity = reader.GetInt32("quantity");
                    string notes = reader.GetString("notes");
                    string name = reader.GetString("name");
                    string description = reader.GetString("description");
                    int caseSize = reader.GetInt32("caseSize");
                    decimal weight = reader.GetDecimal("weight");

                    //create a txnitems object
                    txnItem = new TxnItems(txnID, itemID, quantity, notes,
                        name, description, caseSize, weight);
                }

                //close reader after if statement
                reader.Close();

                //close the connection
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Getting the one Transaction Item");

                connection.Close();
            }

            //return the employee
            return txnItem;
        }

        /**
        * Gets the count (number) of items in a specific txn.
        *
        * @return a long, possibly 0 if none found based on txnID
        */
        public static long GetCountOfItemsInTxn(int txnID)
        {
            //create a command
            MySqlCommand cmd = new MySqlCommand(selectCountItemsInTxnStatement, connection);

            //int to be returned
            long rowCount = 0;

            //one parameter for the query - int txnID
            cmd.Parameters.AddWithValue("@txnID", txnID);

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
                MessageBox.Show(ex.Message, "Error Getting the Count of Items in Transaction");

                connection.Close();

            }

            //return the rowCount (long)
            return rowCount;
        }

        /**
        * Gets the count (number) of a specific item in a txn.
        *
        * @return a long, possibly 0 if none found based on txnID. 1 or 0 should be returned.
        */
        public static long GetCountOfSpecificItemInTxn(int txnID, int itemID)
        {
            //create a command
            MySqlCommand cmd = new MySqlCommand(selectCountSpecificIteminTxnStatement, connection);

            //int to be returned
            long rowCount = 0;

            //two parameters for the query - txnID and itemID
            cmd.Parameters.AddWithValue("@txnID", txnID);
            cmd.Parameters.AddWithValue("@itemID", itemID);

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
                MessageBox.Show(ex.Message, "Error Getting the Count of Items in Transaction");

                connection.Close();

            }

            //return the rowCount (long)
            return rowCount;
        }

        /**
        * Gets the txn weight for a particular txn.
        *
        * @param DateTime inShipDate
        * @return a decimal (weight).
        */
        public static Decimal GetTxnWeightForTxn(int inTxnID)
        {
            //create a command
            MySqlCommand cmd = new MySqlCommand(selectTxnWeightForTxnStatement, connection);

            //decimal var (weight) to be returned
            decimal weight = 0.0m;

            //one parameters for this query - txnID
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
                    //get the txnWeight value from the column(s)
                    weight = reader.GetDecimal("txnWeight");
                }

                //close reader after if statement
                reader.Close();

                //close the connection
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Getting the Transaction Weight");

                connection.Close();
            }

            //return the employee
            return weight;
        }

        /**
        * Gets the txn weight for all store orders on a ship date.
        *
        * @param DateTime inShipDate
        * @return a decimal (weight).
        */
        public static Decimal GetTxnWeightForShipDate(DateTime inShipDate)
        {
            //create a command
            MySqlCommand cmd = new MySqlCommand(selectDeliveryWeightForStoreOrdersOnShipDateStatement, connection);

            //decimal var (weight) to be returned
            decimal weight = 0.0m;

            //want to get just the date in string form from the datetime object
            //don't want or need the time from the datetime object
            //string shipDateOnly = inShipDate.ToShortDateString();
            string dateFormatForMySql = inShipDate.ToString("yyyy-MM-dd");

            //one parameter for the query - ship date
            cmd.Parameters.AddWithValue("@shipDate", dateFormatForMySql);

            //create a datareader and execute
            try
            {
                connection.Open();

                //create a datareader and execute the SQL statement against the DB
                MySqlDataReader reader = cmd.ExecuteReader();

                //if - there is a record to read
                if (reader.Read())
                {
                    //get the txnWeight value from the column(s)
                    weight = reader.GetDecimal("txnWeight");
                }

                //close reader after if statement
                reader.Close();

                //close the connection
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Getting the Transaction Weight");

                connection.Close();
            }

            //return the employee
            return weight;
        }

        /**
        * Updates an a TxnItem's quantity and notes.
        *
        * @param TxnItem object
        * @return bool - if employee was updated or not
        */
        public static bool UpdateTxnItem(TxnItems txnItem)
        {
            //create a command
            MySqlCommand cmd = new MySqlCommand(updateTxnItemQuantityAndNotesStatement, connection);

            //4 parameters for this update query
            cmd.Parameters.AddWithValue("@quantity", txnItem.quantity);
            cmd.Parameters.AddWithValue("@notes", txnItem.notes);
            cmd.Parameters.AddWithValue("@txnID", txnItem.txnID);
            cmd.Parameters.AddWithValue("@itemID", txnItem.itemID);

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
                MessageBox.Show(ex.Message, "Error Updating Existing Transaction Item");

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
        * Inserts a new item for a txn.
        *
        * @param txnitem object
        * @return bool - if the txnitem was inserted or not
        */
        public static bool InsertNewTxnItem(TxnItems txnItem)
        {
            //create a command
            MySqlCommand cmd = new MySqlCommand(insertTxnItemStatement, connection);

            //4 parameters for this insert query
            cmd.Parameters.AddWithValue("@txnID", txnItem.txnID);
            cmd.Parameters.AddWithValue("@itemID", txnItem.itemID);
            cmd.Parameters.AddWithValue("@quantity", txnItem.quantity);
            cmd.Parameters.AddWithValue("@notes", txnItem.notes);

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
                MessageBox.Show(ex.Message, "Error Inserting Transaction Item");

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
        * Deletes an existing item in a txn.
        *
        * @param txnitem object
        * @return bool - if the txnitem was deleted or not
        */
        public static bool DeleteTxnItem(TxnItems txnItem)
        {
            //create a command
            MySqlCommand cmd = new MySqlCommand(deleteTxnItemStatement, connection);

            //2 parameters for this delete query
            cmd.Parameters.AddWithValue("@txnID", txnItem.txnID);
            cmd.Parameters.AddWithValue("@itemID", txnItem.itemID);

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
                MessageBox.Show(ex.Message, "Error Deleting Transaction Item");

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
