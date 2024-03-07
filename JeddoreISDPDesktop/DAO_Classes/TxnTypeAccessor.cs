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
    public static class TxnTypeAccessor
    {
        //private static connection string
        private static string connString = ConfigurationManager.ConnectionStrings["ISDPConnString"].ConnectionString;

        //create a connection
        private static MySqlConnection connection = new MySqlConnection(connString);

        //SQL statements for the TxnType entity
        private static string selectAllStatement = "select * from txntype";
        private static string selectOneStatement = "select * from txntype where txnType = @txnType";

        /**
        * Get all of the transaction types.
        *
        * @return a DataTable, possibly empty, of TxnTypes.
        */
        public static DataTable GetAllTxnTypesDataTable()
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
                MessageBox.Show(ex.Message, "Error Getting All Transaction Types");

                connection.Close();
            }

            //return the datatable
            return dt;
        }

        /**
        * Get all of the txntypes.
        *
        * @return a List, possibly empty, of TxnType objects.
        */
        public static List<TxnType> GetAllTxnTypesList()
        {
            //create a command
            MySqlCommand cmd = new MySqlCommand(selectAllStatement, connection);

            //list to be returned
            List<TxnType> txnTypesList = new List<TxnType>();

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
                    //get the values from the columns (just one)
                    string txnType = reader.GetString("txnType");

                    //create an employee object
                    TxnType txnTypeObject = new TxnType(txnType);

                    //add to the list
                    txnTypesList.Add(txnTypeObject);
                }

                //close reader after while loop
                reader.Close();

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Getting All Transaction Types (List)");

                connection.Close();
            }

            //return the employees list
            return txnTypesList;
        }

        /**
        * Gets one txn type object, based on the txn type field (PK).
        *
        * @param string inTxnType
        * @return a TxnType object, possibly null if none found based on the txntype field..
        */
        public static TxnType GetOneTxnType(string inTxnType)
        {
            //create a command
            MySqlCommand cmd = new MySqlCommand(selectOneStatement, connection);

            //txntype object to be returned
            TxnType txnTypeObject = null;

            //one parameter for the query - string txnType
            cmd.Parameters.AddWithValue("@txnType", inTxnType);

            //create a datareader and execute
            try
            {
                connection.Open();

                //create a datareader and execute the SQL statement against the DB
                MySqlDataReader reader = cmd.ExecuteReader();

                //if - there is a record to read
                //NOTE: if this doesn't work, try a loop here instead
                if (reader.Read())
                {
                    //get the values from the columns (just one)
                    string txnType = reader.GetString("txnType");

                    //assign to the object
                    txnTypeObject = new TxnType(txnType);
                }

                //close reader after if statement
                reader.Close();

                //close the connection
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Getting the One Transaction Type");

                connection.Close();
            }

            //return the one object
            return txnTypeObject;
        }
    }
}
