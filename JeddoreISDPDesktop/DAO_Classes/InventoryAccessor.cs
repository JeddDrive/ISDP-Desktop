using JeddoreISDPDesktop.Entity_Classes;
using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;
using System.Windows.Forms;

namespace JeddoreISDPDesktop.DAO_Classes
{
    //DAO static class for Inventory
    public static class InventoryAccessor
    {
        //private static connection string
        private static string connString = ConfigurationManager.ConnectionStrings["ISDPConnString"].ConnectionString;

        //create a connection
        private static MySqlConnection connection = new MySqlConnection(connString);

        //SQL statements for the Employee entity
        private static string selectAllBySiteIDStatement = "select iv.itemID, it.name, it.description, iv.siteID, iv.quantity, iv.itemLocation, IFNULL(iv.reorderThreshold, '') as reorderThreshold, iv.optimumThreshold, IFNULL(iv.notes, '') as notes" +
            " from inventory iv inner join item it on iv.itemID = it.itemID where iv.siteID = @siteID";
        private static string selectOneStatement = "select iv.itemID, it.name, it.description, iv.siteID, iv.quantity, iv.itemLocation, IFNULL(iv.reorderThreshold, '') as reorderThreshold, iv.optimumThreshold, IFNULL(iv.notes, '') as notes" +
            " from inventory iv inner join item it on iv.itemID = it.itemID where siteID = @siteID and iv.itemID = @itemID";
        private static string updateReorderThresholdStatement = "update inventory set reorderThreshold = @reorderThreshold, notes = @notes where itemID = @itemID and siteID = @siteID";

        /**
        * Get all of the inventory by a specific site ID.
        *
        * @param int siteID
        * @return a DataTable, possibly empty, of Inventory.
        */
        public static DataTable GetAllInventoryBySiteDataTable(int siteID)
        {
            //create a command
            MySqlCommand cmd = new MySqlCommand(selectAllBySiteIDStatement, connection);

            //create datatable
            DataTable dt = new DataTable();

            //one parameter for the query - int siteID
            cmd.Parameters.AddWithValue("@siteID", siteID);

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
                MessageBox.Show(ex.Message, "Error Getting All Inventory by Site ID");

                connection.Close();
            }

            //return the datatable
            return dt;
        }

        /**
        * Gets one inventory item, based on the siteID and itemID.
        *
        * @param int siteID, int itemID
        * @return a Inventory object, possibly null if none found based on the parameters.
        */
        public static Inventory GetOneInventoryItem(int siteIDSentIn, int itemIDSentIn)
        {
            //create a command
            MySqlCommand cmd = new MySqlCommand(selectOneStatement, connection);

            //inventory obj to be returned
            Inventory inv = null;

            //one parameter for the query - string username
            cmd.Parameters.AddWithValue("@siteID", siteIDSentIn);
            cmd.Parameters.AddWithValue("@itemID", itemIDSentIn);

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
                    //get the values from the columns
                    int itemID = reader.GetInt32("itemID");
                    string name = reader.GetString("name");
                    string description = reader.GetString("description");
                    int siteID = reader.GetInt32("siteID");
                    int quantity = reader.GetInt32("quantity");
                    string itemLocation = reader.GetString("itemLocation");
                    int reorderThreshold = reader.GetInt32("reorderThreshold");
                    int optimumThreshold = reader.GetInt32("optimumThreshold");
                    string notes = reader.GetString("notes");

                    //create an employee object
                    inv = new Inventory(itemID, siteID, quantity, itemLocation, reorderThreshold,
                        optimumThreshold, notes, name, description);
                }

                //close reader after if statement
                reader.Close();

                //close the connection
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Getting the one Inventory Item");

                connection.Close();
            }

            //return the employee
            return inv;
        }

        /**
        * Updates an existing employee and most of it's fields.
        *
        * @param inventory object
        * @return bool - if employee was updated or not
        */
        public static bool UpdateInventoryItem(Inventory inventory)
        {
            //create a command
            MySqlCommand cmd = new MySqlCommand(updateReorderThresholdStatement, connection);

            //4 parameters for this update query
            cmd.Parameters.AddWithValue("@reorderThreshold", inventory.reorderThreshold);
            cmd.Parameters.AddWithValue("@notes", inventory.notes);
            cmd.Parameters.AddWithValue("@itemID", inventory.itemID);
            cmd.Parameters.AddWithValue("@siteID", inventory.siteID);

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
                MessageBox.Show(ex.Message, "Error Updating Existing Inventory Item");

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
