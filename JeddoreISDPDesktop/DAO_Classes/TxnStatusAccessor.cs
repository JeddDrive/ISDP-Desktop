using JeddoreISDPDesktop.Entity_Classes;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Windows.Forms;

namespace JeddoreISDPDesktop.DAO_Classes
{
    //DAO public statis class for TxnStatus
    public static class TxnStatusAccessor
    {
        //private static connection string
        private static string connString = ConfigurationManager.ConnectionStrings["ISDPConnString"].ConnectionString;

        //create a connection
        private static MySqlConnection connection = new MySqlConnection(connString);

        //SQL statements for the TxnStatus entity
        private static string selectAllStatement = "select statusName, statusDescription from txnStatus";
        private static string selectOneStatement = "select statusName, statusDescription from txnStatus where statusName = @statusName";

        /**
        * Get all of the txn statuses.
        *
        * @return a List, possibly empty, of TxnStatus objects.
        */
        public static List<TxnStatus> GetAllTxnStatusesList()
        {
            //create a command
            MySqlCommand cmd = new MySqlCommand(selectAllStatement, connection);

            //list to be returned
            List<TxnStatus> statusesList = new List<TxnStatus>();

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
                    string statusName = reader.GetString("statusName");
                    string statusDescription = reader.GetString("statusDescription");

                    //create an employee object
                    TxnStatus txnStatus = new TxnStatus(statusName, statusDescription);

                    //add to the list
                    statusesList.Add(txnStatus);
                }

                //close reader after while loop
                reader.Close();

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Getting All Transaction Statuses");

                connection.Close();
            }

            //return the txnstatuses list
            return statusesList;
        }

        /**
        * Get one txn status, based on the status name.
        *
        * @param string statusName (primary key for TxnStatus)
        * @return a TxnStatus object, possibly null if none found.
        */
        public static TxnStatus GetOneTxnStatus(string inStatusName)
        {
            //create a command
            MySqlCommand cmd = new MySqlCommand(selectOneStatement, connection);

            //txnstatus to be returned
            TxnStatus txnStatus = null;

            //one parameter for the query - string statusname
            cmd.Parameters.AddWithValue("@statusName", inStatusName);

            //create a datareader and execute
            try
            {
                connection.Open();

                //create a datareader and execute the SQL statement against the DB
                MySqlDataReader reader = cmd.ExecuteReader();

                //run loop thru datareader
                //if - there is another record to read
                if (reader.Read())
                {
                    //get the values from the columns
                    string statusName = reader.GetString("statusName");
                    string statusDescription = reader.GetString("statusDescription");

                    //assign to the txnStatus object
                    txnStatus = new TxnStatus(statusName, statusDescription);
                }

                //close reader after while loop
                reader.Close();

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Getting the Transaction Status");

                connection.Close();
            }

            //return the txnstatus object
            return txnStatus;
        }
    }
}
