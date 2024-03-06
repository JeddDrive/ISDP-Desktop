using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Windows.Forms;

namespace JeddoreISDPDesktop.DAO_Classes
{
    //DAO public static class for Supplier
    public static class SupplierAccessor
    {
        //private static connection string
        private static string connString = ConfigurationManager.ConnectionStrings["ISDPConnString"].ConnectionString;

        //create a connection
        private static MySqlConnection connection = new MySqlConnection(connString);

        //SQL statements for the Employee entity
        private static string selectAllStatement = "select supplierID, name, address1, IFNULL(address2, '') AS address2, city, country, province, postalcode, phone, IFNULL(contact, '') AS contact, IFNULL(notes, '') AS notes, active from supplier";
        private static string selectOneStatement = "select supplierID, name, address1, IFNULL(address2, '') AS address2, city, country, province, postalcode, phone, IFNULL(contact, '') AS contact, IFNULL(notes, '') AS notes, active from supplier" +
            " where supplierID = @supplierID";
        private static string selectLastSupplierStatement = "select supplierID, name, address1, IFNULL(address2, '') AS address2, city, country, province, postalcode, phone, IFNULL(contact, '') AS contact, IFNULL(notes, '') AS notes, active from supplier" +
            " order by supplierID DESC LIMIT 1";
        private static string updateSupplierStatement = "update supplier set name = @name, address1 = @address1, address2 = @address2, city = @city, country = @country, province = @province, postalcode = @postalcode, phone = @phone, contact = @contact, notes = @notes, active = @active where supplierID = @supplierID";
        private static string insertSupplierStatement = "insert into `supplier` (`name`, `address1`, `address2`, `city`, `country`, `province`, `postalcode`, `phone`, `contact`, `notes`, `active`) VALUES " +
            "(@name, @address1, @address2, @city, @country, @province, @postalcode, @phone, @contact, @notes, 1)";

        /**
        * Get all of the suppliers.
        *
        * @return a DataTable, possibly empty, of Suppliers.
        */
        public static DataTable GetAllSuppliersDataTable()
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
                MessageBox.Show(ex.Message, "Error Getting All Suppliers");

                connection.Close();
            }

            //return the datatable
            return dt;
        }

        /**
        * Get all of the suppliers.
        *
        * @return a List, possibly empty, of Supplier objects.
        */
        public static List<Supplier> GetAllSuppliersList()
        {
            //create a command
            MySqlCommand cmd = new MySqlCommand(selectAllStatement, connection);

            //list to be returned
            List<Supplier> suppliersList = new List<Supplier>();

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
                    int supplierID = reader.GetInt32("supplierID");
                    string name = reader.GetString("name");
                    string address1 = reader.GetString("address1");
                    string address2 = reader.GetString("address2");
                    string city = reader.GetString("city");
                    string country = reader.GetString("country");
                    string province = reader.GetString("province");
                    string postalcode = reader.GetString("postalcode");
                    string phone = reader.GetString("phone");
                    string contact = reader.GetString("contact");
                    string notes = reader.GetString("notes");
                    byte active = reader.GetByte("active");

                    //create a supplier object
                    Supplier supplier = new Supplier(supplierID, name, address1, address2,
                        city, country, province, postalcode, phone, contact, notes, active);

                    //add to the list
                    suppliersList.Add(supplier);
                }

                //close reader after while loop
                reader.Close();

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Getting All Suppliers");

                connection.Close();
            }

            //return the suppliers list
            return suppliersList;
        }

        /**
        * Gets one supplier, based on the supplier ID.
        *
        * @param int supplierID
        * @return a Supplier object, possibly null if none found based on the supplier ID.
        */
        public static Supplier GetOneSupplier(int inSupplierID)
        {
            //create a command
            MySqlCommand cmd = new MySqlCommand(selectOneStatement, connection);

            //supplier to be returned
            Supplier supplier = null;

            //one parameter for the query - int supplierID
            cmd.Parameters.AddWithValue("@supplierID", inSupplierID);

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
                    int supplierID = reader.GetInt32("supplierID");
                    string name = reader.GetString("name");
                    string address1 = reader.GetString("address1");
                    string address2 = reader.GetString("address2");
                    string city = reader.GetString("city");
                    string country = reader.GetString("country");
                    string province = reader.GetString("province");
                    string postalcode = reader.GetString("postalcode");
                    string phone = reader.GetString("phone");
                    string contact = reader.GetString("contact");
                    string notes = reader.GetString("notes");
                    byte active = reader.GetByte("active");

                    //create a supplier object
                    supplier = new Supplier(supplierID, name, address1, address2,
                        city, country, province, postalcode, phone, contact, notes, active);
                }

                //close reader after if statement
                reader.Close();

                //close the connection
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Getting the One Supplier");

                connection.Close();
            }

            //return the supplier
            return supplier;
        }


        /**
        * Gets the last (one) supplier.
        *
        * @return a Supplier object, possibly null if none found.
        */
        public static Supplier GetLastSupplier()
        {
            //create a command
            MySqlCommand cmd = new MySqlCommand(selectLastSupplierStatement, connection);

            //supplier to be returned
            Supplier supplier = null;

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
                    int supplierID = reader.GetInt32("supplierID");
                    string name = reader.GetString("name");
                    string address1 = reader.GetString("address1");
                    string address2 = reader.GetString("address2");
                    string city = reader.GetString("city");
                    string country = reader.GetString("country");
                    string province = reader.GetString("province");
                    string postalcode = reader.GetString("postalcode");
                    string phone = reader.GetString("phone");
                    string contact = reader.GetString("contact");
                    string notes = reader.GetString("notes");
                    byte active = reader.GetByte("active");

                    //create a supplier object
                    supplier = new Supplier(supplierID, name, address1, address2,
                        city, country, province, postalcode, phone, contact, notes, active);
                }

                //close reader after if statement
                reader.Close();

                //close the connection
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Getting the Last Supplier");

                connection.Close();
            }

            //return the supplier
            return supplier;
        }

        /**
        * Updates an existing supplier and most of it's fields.
        *
        * @param supplier object
        * @return bool - if supplier was updated or not
        */
        public static bool UpdateSupplierFields(Supplier supplier)
        {
            //create a command
            MySqlCommand cmd = new MySqlCommand(updateSupplierStatement, connection);

            //many parameters for this update query
            cmd.Parameters.AddWithValue("@name", supplier.name);
            cmd.Parameters.AddWithValue("@address1", supplier.address1);
            cmd.Parameters.AddWithValue("@address2", supplier.address2);
            cmd.Parameters.AddWithValue("@city", supplier.city);
            cmd.Parameters.AddWithValue("@country", supplier.country);
            cmd.Parameters.AddWithValue("@province", supplier.province);
            cmd.Parameters.AddWithValue("@postalcode", supplier.postalCode);
            cmd.Parameters.AddWithValue("@phone", supplier.phone);
            cmd.Parameters.AddWithValue("@contact", supplier.contact);
            cmd.Parameters.AddWithValue("@notes", supplier.notes);
            cmd.Parameters.AddWithValue("@active", supplier.active);
            cmd.Parameters.AddWithValue("@supplierID", supplier.supplierID);

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
                MessageBox.Show(ex.Message, "Error Updating Existing Supplier");

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
        * Inserts a new supplier.
        *
        * @param supplier object
        * @return bool - if supplier was inserted or not
        */
        public static bool InsertNewSupplier(Supplier supplier)
        {
            //create a command
            MySqlCommand cmd = new MySqlCommand(insertSupplierStatement, connection);

            //many parameters for this insert query
            cmd.Parameters.AddWithValue("@name", supplier.name);
            cmd.Parameters.AddWithValue("@address1", supplier.address1);
            cmd.Parameters.AddWithValue("@address2", supplier.address2);
            cmd.Parameters.AddWithValue("@city", supplier.city);
            cmd.Parameters.AddWithValue("@country", supplier.country);
            cmd.Parameters.AddWithValue("@province", supplier.province);
            cmd.Parameters.AddWithValue("@postalcode", supplier.postalCode);
            cmd.Parameters.AddWithValue("@phone", supplier.phone);
            cmd.Parameters.AddWithValue("@contact", supplier.contact);
            cmd.Parameters.AddWithValue("@notes", supplier.notes);
            //cmd.Parameters.AddWithValue("@active", supplier.active);

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
                MessageBox.Show(ex.Message, "Error Inserting Supplier");

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
