using JeddoreISDPDesktop.Entity_Classes;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Windows.Forms;

namespace JeddoreISDPDesktop.DAO_Classes
{
    //DAO static class for Item
    public static class ItemAccessor
    {
        //private static connection string
        private static string connString = ConfigurationManager.ConnectionStrings["ISDPConnString"].ConnectionString;

        //create a connection
        private static MySqlConnection connection = new MySqlConnection(connString);

        //SQL statements for the Item entity
        private static string selectAllStatement = "select itemID, name, sku, IFNULL(description, '') AS description, category, weight, caseSize, costPrice, retailPrice, supplierID, active, IFNULL(notes, '') AS notes, IFNULL(imageFileLocation, '') AS imageFileLocation from item order by itemID";
        private static string selectOneStatement = "select itemID, name, sku, IFNULL(description, '') AS description, category, weight, caseSize, costPrice, retailPrice, supplierID, active, IFNULL(notes, '') AS notes, IFNULL(imageFileLocation, '') AS imageFileLocation from item where itemID = @itemID";
        private static string updateItemStatement = "update item set active = @active, description = @description, notes = @notes, imageFileLocation = @imageFileLocation where itemID = @itemID";

        /**
        * Get all of the items.
        *
        * @return a DataTable, possibly empty, of Items.
        */
        public static DataTable GetAllItemsDataTable()
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
                MessageBox.Show(ex.Message, "Error Getting All Items");

                connection.Close();

            }

            //return the datatable
            return dt;
        }

        /**
        * Get all of the items.
        *
        * @return a List, possibly empty, of Item objects.
        */
        public static List<Item> GetAllItemsList()
        {
            //create a command
            MySqlCommand cmd = new MySqlCommand(selectAllStatement, connection);

            //list to be returned
            List<Item> itemsList = new List<Item>();

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
                    int itemID = reader.GetInt32("itemID");
                    string name = reader.GetString("name");
                    string sku = reader.GetString("sku");
                    string description = reader.GetString("description");
                    string category = reader.GetString("category");
                    decimal weight = reader.GetDecimal("weight");
                    int caseSize = reader.GetInt32("caseSize");
                    decimal costPrice = reader.GetDecimal("costPrice");
                    decimal retailPrice = reader.GetDecimal("retailPrice");
                    int supplierID = reader.GetInt32("supplierID");
                    byte active = reader.GetByte("active");
                    string notes = reader.GetString("notes");
                    string imageFileLocation = reader.GetString("imageFileLocation");

                    //create an item object
                    Item item = new Item(itemID, name, sku, description, category, weight,
                        caseSize, costPrice, retailPrice, supplierID, active, notes,
                        imageFileLocation);

                    //add to the list
                    itemsList.Add(item);
                }

                //close reader after while loop
                reader.Close();

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Getting All Items");

                connection.Close();
            }

            //return the employees list
            return itemsList;
        }

        /**
        * Gets one item, based on the itemID.
        *
        * @return an Item, possibly null if none found based on the item.
        */
        public static Item GetOneItem(int itemIDSentIn)
        {
            //create a command
            MySqlCommand cmd = new MySqlCommand(selectOneStatement, connection);

            //item to be returned
            Item item = null;

            //one parameter for the query - int itemID
            cmd.Parameters.AddWithValue("@itemID", itemIDSentIn);

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
                    int itemID = reader.GetInt32("itemID");
                    string name = reader.GetString("name");
                    string sku = reader.GetString("sku");
                    string description = reader.GetString("description");
                    string category = reader.GetString("category");
                    decimal weight = reader.GetDecimal("weight");
                    int caseSize = reader.GetInt32("caseSize");
                    decimal costPrice = reader.GetDecimal("costPrice");
                    decimal retailPrice = reader.GetDecimal("retailPrice");
                    int supplierID = reader.GetInt32("supplierID");
                    byte active = reader.GetByte("active");
                    string notes = reader.GetString("notes");
                    string imageFileLocation = reader.GetString("imageFileLocation");

                    //create an item object
                    item = new Item(itemID, name, sku, description, category, weight,
                        caseSize, costPrice, retailPrice, supplierID, active, notes,
                        imageFileLocation);
                }

                //close reader after if statement
                reader.Close();

                //close the connection
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Getting the one Item");

                connection.Close();

            }

            //return the employee
            return item;
        }

        /**
        * Updates an existing item and some of it's fields.
        *
        * @param item object
        * @return bool - if item was updated or not
        */
        public static bool UpdateItemFields(Item item)
        {
            //create a command
            MySqlCommand cmd = new MySqlCommand(updateItemStatement, connection);

            //several parameters for this update query
            cmd.Parameters.AddWithValue("@active", item.active);
            cmd.Parameters.AddWithValue("@description", item.description);
            cmd.Parameters.AddWithValue("@notes", item.notes);
            cmd.Parameters.AddWithValue("@imageFileLocation", item.imageFileLocation);
            cmd.Parameters.AddWithValue("@itemID", item.itemID);

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
                MessageBox.Show(ex.Message, "Error Updating Existing Item");

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
