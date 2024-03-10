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
    public static class VehicleAccessor
    {
        //private static connection string
        private static string connString = ConfigurationManager.ConnectionStrings["ISDPConnString"].ConnectionString;

        //create a connection
        private static MySqlConnection connection = new MySqlConnection(connString);

        //SQL statements for the Employee entity
        private static string selectAllStatement = "select * from vehicle";
        private static string selectOneStatement = "select * from vehicle where vehicleType = @vehicleType";

        /**
        * Get all of the vehicles.
        *
        * @return a DataTable, possibly empty, of Vehicle objects.
        */
        public static DataTable GetAllVehiclesDataTable()
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
                MessageBox.Show(ex.Message, "Error Getting All Vehicles (DataTable)");

                connection.Close();
            }

            //return the datatable
            return dt;
        }

        /**
        * Get all of the vehicles.
        *
        * @return a List, possibly empty, of Vehicle objects.
        */
        public static List<Vehicle> GetAllVehiclesList()
        {
            //create a command
            MySqlCommand cmd = new MySqlCommand(selectAllStatement, connection);

            //list to be returned
            List<Vehicle> vehiclesList = new List<Vehicle>();

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
                    string vehicleType = reader.GetString("vehicleType");
                    decimal maxWeight = reader.GetDecimal("maxWeight");
                    decimal hourlyTruckCost = reader.GetDecimal("HourlyTruckCost");
                    decimal costPerKm = reader.GetDecimal("costPerKm");
                    string notes = reader.GetString("notes");

                    //create a vehicle object
                    Vehicle vehicle = new Vehicle(vehicleType, maxWeight, hourlyTruckCost, costPerKm,
                        notes);

                    //add to the list
                    vehiclesList.Add(vehicle);
                }

                //close reader after while loop
                reader.Close();

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Getting All Vehicles (List)");

                connection.Close();
            }

            //return the list
            return vehiclesList;
        }

        /**
        * Gets one vehicle, based on the vehicleType PK.
        *
        * @param string inVehicleType
        * @return a Vehicle object, possibly null if none found based on the vehicleType.
        */
        public static Vehicle GetOneVehicle(string inVehicleType)
        {
            //create a command
            MySqlCommand cmd = new MySqlCommand(selectOneStatement, connection);

            //vehicle to be returned
            Vehicle vehicle = null;

            //one parameter for the query - string vehicleType
            cmd.Parameters.AddWithValue("@vehicleType", inVehicleType);

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
                    string vehicleType = reader.GetString("vehicleType");
                    decimal maxWeight = reader.GetDecimal("maxWeight");
                    decimal hourlyTruckCost = reader.GetDecimal("HourlyTruckCost");
                    decimal costPerKm = reader.GetDecimal("costPerKm");
                    string notes = reader.GetString("notes");

                    //instantiate a vehicle object
                    vehicle = new Vehicle(vehicleType, maxWeight, hourlyTruckCost, costPerKm,
                        notes);
                }

                //close reader after if statement
                reader.Close();

                //close the connection
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Getting the One Vehicle");

                connection.Close();
            }

            //return the object
            return vehicle;
        }
    }
}
