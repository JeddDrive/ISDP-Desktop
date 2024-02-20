using JeddoreISDPDesktop.Entity_Classes;
using MySql.Data.MySqlClient;
using System;
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
        private static string selectAllItemsByTxnIDStatement = "select txnID, itemID, quantity, IFNULL(notes, '') as notes from txnitems where txnID = @txnID";
        private static string selectOneByTxnIDAndItemIDStatement = "select txnID, itemID, quantity, IFNULL(notes, '') as notes from txnitems where txnID = @txnID and itemID = @itemID";
        private static string updateTxnItemQuantityAndNotesStatement = "update txnitems set quantity = @quantity, notes = @notes where txnID = @txnID and itemID = @itemID";
        private static string insertTxnItemStatement = " insert into `txnitems` (`txnID`, `itemID`, `quantity`, `notes`) VALUES " +
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

                    //create a txnitems object
                    txnItem = new TxnItems(txnID, itemID, quantity, notes);
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
