using JeddoreISDPDesktop.Entity_Classes;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Windows.Forms;

namespace JeddoreISDPDesktop.DAO_Classes
{
    //DAO public static class for Delivery
    public static class DeliveryAccessor
    {
        //private static connection string
        private static string connString = ConfigurationManager.ConnectionStrings["ISDPConnString"].ConnectionString;

        //create a connection
        private static MySqlConnection connection = new MySqlConnection(connString);

        //SQL statements for the Employee entity
        private static string selectAllStatement = "select deliveryID, distanceCost, vehicleType, IFNULL(notes, '') AS notes from delivery";
        private static string selectOneStatement = "select deliveryID, distanceCost, vehicleType, IFNULL(notes, '') AS notes from delivery where deliveryID = @deliveryID";
        private static string selectLastDeliveryStatement = "select deliveryID, distanceCost, vehicleType, IFNULL(notes, '') AS notes from delivery" +
            " order by deliveryID DESC LIMIT 1";
        private static string insertDeliveryStatement = "insert into `delivery` (`distanceCost`, `vehicleType`, `notes`) VALUES (@distanceCost, @vehicleType, @notes)";
        private static string updateDistanceCostAndNotesStatement = "update delivery set distanceCost = @distanceCost, notes = CONCAT(notes, @notes) where deliveryID = @deliveryID";

        /**
        * Get all of the deliveries.
        *
        * @return a DataTable, possibly empty, of Delivery objects.
         */
        public static DataTable GetAllDeliveriesDataTable()
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
                MessageBox.Show(ex.Message, "Error Getting All Deliveries (DataTable)");

                connection.Close();
            }

            //return the datatable
            return dt;
        }

        /**
        * Get all of the deliveries.
        *
        * @return a List, possibly empty, of Delivery objects.
        */
        public static List<Delivery> GetAllDeliveriesList()
        {
            //create a command
            MySqlCommand cmd = new MySqlCommand(selectAllStatement, connection);

            //list to be returned
            List<Delivery> deliveriesList = new List<Delivery>();

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
                    int deliveryID = reader.GetInt32("deliveryID");
                    decimal distanceCost = reader.GetDecimal("distanceCost");
                    string vehicleType = reader.GetString("vehicleType");
                    string notes = reader.GetString("notes");

                    //create a delivery object
                    Delivery delivery = new Delivery(deliveryID, distanceCost, vehicleType, notes);

                    //add to the list
                    deliveriesList.Add(delivery);
                }

                //close reader after while loop
                reader.Close();

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Getting All Deliveries (List)");

                connection.Close();
            }

            //return the list
            return deliveriesList;
        }

        /**
        * Gets one delivery, based on the deliveryID.
        *
        * @param int deliveryID
        * @return a Delivery object, possibly null if none found based on the deliveryID.
        */
        public static Delivery GetOneDelivery(int inDeliveryID)
        {
            //create a command
            MySqlCommand cmd = new MySqlCommand(selectOneStatement, connection);

            //delivery to be returned
            Delivery delivery = null;

            //one parameter for the query - int deliveryID
            cmd.Parameters.AddWithValue("@deliveryID", inDeliveryID);

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
                    int deliveryID = reader.GetInt32("deliveryID");
                    decimal distanceCost = reader.GetDecimal("distanceCost");
                    string vehicleType = reader.GetString("vehicleType");
                    string notes = reader.GetString("notes");

                    //assign to the delivery object
                    delivery = new Delivery(deliveryID, distanceCost, vehicleType, notes);
                }

                //close reader after if statement
                reader.Close();

                //close the connection
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Getting the One Delivery");

                connection.Close();
            }

            //return the object
            return delivery;
        }

        /**
        * Gets one delivery (the last/latest one).
        *
        * @param int deliveryID
        * @return a Delivery object.
        */
        public static Delivery GetLastDelivery()
        {
            //create a command
            MySqlCommand cmd = new MySqlCommand(selectLastDeliveryStatement, connection);

            //delivery to be returned
            Delivery delivery = null;

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
                    int deliveryID = reader.GetInt32("deliveryID");
                    decimal distanceCost = reader.GetDecimal("distanceCost");
                    string vehicleType = reader.GetString("vehicleType");
                    string notes = reader.GetString("notes");

                    //assign to the delivery object
                    delivery = new Delivery(deliveryID, distanceCost, vehicleType, notes);
                }

                //close reader after if statement
                reader.Close();

                //close the connection
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Getting the Last Delivery");

                connection.Close();
            }

            //return the object
            return delivery;
        }

        /**
        * Updates an existing delivery's distance cost and notes fields (Ex. when it's delivered).
        *
        * @param delivery object
        * @return bool - if delivery was updated or not
        */
        public static bool UpdateDistanceCostAndNotes(Delivery delivery)
        {
            //create a command
            MySqlCommand cmd = new MySqlCommand(updateDistanceCostAndNotesStatement, connection);

            //three parameters for this update query
            cmd.Parameters.AddWithValue("@distanceCost", delivery.distanceCost);
            cmd.Parameters.AddWithValue("@notes", delivery.notes);
            cmd.Parameters.AddWithValue("@deliveryID", delivery.deliveryID);

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
                MessageBox.Show(ex.Message, "Error Updating Delivery's Distance Cost and Notes");

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
        * Inserts a new delivery.
        *
        * @param delivery object
        * @return bool - if delivery was inserted or not
        */
        public static bool InsertNewDelivery(Delivery delivery)
        {
            //create a command
            MySqlCommand cmd = new MySqlCommand(insertDeliveryStatement, connection);

            //three parameters for this query
            cmd.Parameters.AddWithValue("@distanceCost", delivery.distanceCost);
            cmd.Parameters.AddWithValue("@vehicleType", delivery.vehicleType);
            cmd.Parameters.AddWithValue("@notes", delivery.notes);

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
                MessageBox.Show(ex.Message, "Error Inserting Delivery");

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
