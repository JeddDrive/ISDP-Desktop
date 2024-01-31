using JeddoreISDPDesktop.Entity_Classes;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Windows.Forms;

namespace JeddoreISDPDesktop.DAO_Classes
{
    //DAO static class for Posn
    public static class PosnAccessor
    {
        //private static connection string
        private static string connString = ConfigurationManager.ConnectionStrings["ISDPConnString"].ConnectionString;

        //create a connection
        private static MySqlConnection connection = new MySqlConnection(connString);

        //SQL statements for the Posn entity
        private static string selectAllStatement = "select * from posn";
        private static string selectOneStatement = "select * from posn where positionID = @positionID";

        /**
        * Get all of the positions.
        *
        * @return a List, possibly empty, of Posn objects.
        */
        public static List<Posn> GetAllPositionsList()
        {
            //create a command
            MySqlCommand cmd = new MySqlCommand(selectAllStatement, connection);

            //list to be returned
            List<Posn> posnList = new List<Posn>();

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
                    //get the position ID and permission level
                    int positionID = reader.GetInt32("positionID");
                    string permissionLevel = reader.GetString("permissionLevel");

                    //custom constructor for posn
                    Posn posn = new Posn(positionID, permissionLevel);

                    //add to the list
                    posnList.Add(posn);
                }

                //close reader after while loop
                reader.Close();

                connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Getting All Positions");

                connection.Close();

            }

            //return the employees list
            return posnList;
        }

        /**
        * Gets one Posn object, based on the positionID.
        *
        * @param int positionID
        * @return a Posn object, possibly null if none found based on the positionID.
        */
        public static Posn GetOnePosition(int positionID)
        {
            //create a command
            MySqlCommand cmd = new MySqlCommand(selectOneStatement, connection);

            //obj to be returned
            Posn posn = null;

            //one parameter for the query - string username
            cmd.Parameters.AddWithValue("@positionID", positionID);

            //create a datareader and execute
            try
            {
                connection.Open();

                //create a datareader and execute the SQL statement against the DB
                MySqlDataReader reader = cmd.ExecuteReader();

                //if - there is a record to read
                if (reader.Read())
                {
                    //get the position ID and permission level
                    int positionIDDB = reader.GetInt32("positionID");
                    string permissionLevel = reader.GetString("permissionLevel");

                    //custom constructor for posn
                    posn = new Posn(positionIDDB, permissionLevel);
                }

                //close reader after if statement
                reader.Close();

                connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Getting the Position");

                connection.Close();

            }

            //return the position obj
            return posn;
        }
    }
}
