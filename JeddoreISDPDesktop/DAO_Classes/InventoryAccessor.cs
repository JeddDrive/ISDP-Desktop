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
        private static string selectAllBySiteIDStatement = "select iv.itemID, it.name, it.description, it.category, iv.siteID, s.name AS siteName, iv.quantity, it.retailPrice, iv.itemLocation, IFNULL(iv.reorderThreshold, '') as reorderThreshold, iv.optimumThreshold, IFNULL(iv.notes, '') as notes" +
            " from inventory iv inner join item it on iv.itemID = it.itemID inner join site s on iv.siteID = s.siteID where iv.siteID = @siteID";
        private static string selectAllBySiteIDAndCategoryStatement = "select iv.itemID, it.name, it.description, it.category, iv.siteID, s.name AS siteName, iv.quantity, it.retailPrice, iv.itemLocation, IFNULL(iv.reorderThreshold, '') as reorderThreshold, iv.optimumThreshold, IFNULL(iv.notes, '') as notes" +
            " from inventory iv inner join item it on iv.itemID = it.itemID inner join site s on iv.siteID = s.siteID where iv.siteID = @siteID and it.category = @category";
        private static string selectAllBySiteIDAndSupplierStatement = "select iv.itemID, it.name, it.description, it.category, it.supplierID, iv.siteID, s.name AS siteName, iv.quantity, it.retailPrice, iv.itemLocation, IFNULL(iv.reorderThreshold, '') as reorderThreshold, iv.optimumThreshold, IFNULL(iv.notes, '') as notes" +
            " from inventory iv inner join item it on iv.itemID = it.itemID inner join site s on iv.siteID = s.siteID where iv.siteID = @siteID and it.supplierID = @supplierID";
        private static string selectOneStatement = "select iv.itemID, it.name, it.description, it.category, iv.siteID, s.name AS siteName, iv.quantity, it.retailPrice, iv.itemLocation, IFNULL(iv.reorderThreshold, '') as reorderThreshold, iv.optimumThreshold, IFNULL(iv.notes, '') as notes" +
            " from inventory iv inner join item it on iv.itemID = it.itemID inner join site s on iv.siteID = s.siteID where iv.siteID = @siteID and iv.itemID = @itemID";
        private static string updateReorderAndOptimumThresholdsStatement = "update inventory set reorderThreshold = @reorderThreshold, optimumThreshold = @optimumThreshold, notes = @notes where itemID = @itemID and siteID = @siteID";
        private static string updateInventoryAtNewLocationStatement = "update inventory set quantity = quantity + @quantity, itemLocation = @itemLocation where siteID = @siteID and itemID = @itemID";
        private static string updateInventoryAtOldLocationStatement = "update inventory set quantity = quantity - @quantity where siteID = @siteID and itemID = @itemID";

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
        * Get all of the inventory by a specific site ID AND category.
        *
        * @param int siteID
        * @return a DataTable, possibly empty, of Inventory.
        */
        public static DataTable GetAllInventoryBySiteAndCategoryDataTable(int siteID, string category)
        {
            //create a command
            MySqlCommand cmd = new MySqlCommand(selectAllBySiteIDAndCategoryStatement, connection);

            //create datatable
            DataTable dt = new DataTable();

            //two parameters for the query - int siteID and string category
            cmd.Parameters.AddWithValue("@siteID", siteID);
            cmd.Parameters.AddWithValue("@category", category);

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
                MessageBox.Show(ex.Message, "Error Getting All Inventory by Site ID and Category");

                connection.Close();
            }

            //return the datatable
            return dt;
        }

        /**
        * Get all of the inventory by a specific site ID and supplier ID.
        *
        * @param int siteID, int supplierID
        * @return a DataTable, possibly empty, of Inventory.
        */
        public static DataTable GetAllInventoryBySiteAndSupplierDataTable(int siteID, int supplierID)
        {
            //create a command
            MySqlCommand cmd = new MySqlCommand(selectAllBySiteIDAndSupplierStatement, connection);

            //create datatable
            DataTable dt = new DataTable();

            //two parameters for the query - int siteID and int supplierID
            cmd.Parameters.AddWithValue("@siteID", siteID);
            cmd.Parameters.AddWithValue("@supplierID", supplierID);

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
                MessageBox.Show(ex.Message, "Error Getting All Inventory by Site ID and Supplier ID");

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
                    string siteName = reader.GetString("siteName");
                    string category = reader.GetString("category");
                    decimal retailPrice = reader.GetDecimal("retailPrice");

                    //create an employee object
                    inv = new Inventory(itemID, siteID, quantity, itemLocation, reorderThreshold,
                        optimumThreshold, notes, name, description, siteName,
                        category, retailPrice);
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

            //return the inventory obj
            return inv;
        }

        /**
        * Updates an existing inventory item and some of it's fields.
        *
        * @param inventory object
        * @return bool - if inventory was updated or not
        */
        public static bool UpdateInventoryItem(Inventory inventory)
        {
            //create a command
            MySqlCommand cmd = new MySqlCommand(updateReorderAndOptimumThresholdsStatement, connection);

            //5 parameters for this update query
            cmd.Parameters.AddWithValue("@reorderThreshold", inventory.reorderThreshold);
            cmd.Parameters.AddWithValue("@optimumThreshold", inventory.optimumThreshold);
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

        /**
        * Moves an inventory item and it's quantity from one old site to a new one.
        *
        * @param inventory object
        * @return bool - if inventory was updated or not
        */
        public static bool UpdateInventoryToNewLocation(int quantity, string itemLocation, int siteID, int itemID)
        {
            //create a command
            MySqlCommand cmd = new MySqlCommand(updateInventoryAtNewLocationStatement, connection);

            //4 parameters for this update query
            cmd.Parameters.AddWithValue("@quantity", quantity);
            cmd.Parameters.AddWithValue("@itemLocation", itemLocation);
            cmd.Parameters.AddWithValue("@siteID", siteID);
            cmd.Parameters.AddWithValue("@itemID", itemID);

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
                MessageBox.Show(ex.Message, "Error Moving Inventory to New Location");

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
        * Updates the inventory quantity for an item at it's old location.
        *
        * @param inventory object
        * @return bool - if inventory was updated or not
        */
        public static bool UpdateInventoryFromOldLocation(int quantity, int siteID, int itemID)
        {
            //create a command
            MySqlCommand cmd = new MySqlCommand(updateInventoryAtOldLocationStatement, connection);

            //4 parameters for this update query
            cmd.Parameters.AddWithValue("@quantity", quantity);
            cmd.Parameters.AddWithValue("@siteID", siteID);
            cmd.Parameters.AddWithValue("@itemID", itemID);

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
                MessageBox.Show(ex.Message, "Error Moving Inventory from Old Location");

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
