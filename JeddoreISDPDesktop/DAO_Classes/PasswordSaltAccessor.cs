using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Windows.Forms;

namespace JeddoreISDPDesktop.DAO_Classes
{
    //DAO static class for PasswordSalt
    public static class PasswordSaltAccessor
    {
        //private static connection string
        private static string connString = ConfigurationManager.ConnectionStrings["ISDPConnString"].ConnectionString;

        //create a connection
        private static MySqlConnection connection = new MySqlConnection(connString);

        //SQL statements for the PasswordSalt entity
        private static string selectOneStatement = "select passwordSalt from passwordsalt where employeeID = @employeeID";
        private static string updateSaltStatement = "update passwordsalt set passwordSalt = @passwordSalt where employeeID = @employeeID";

        /**
        * Gets one passwordsalt string, based on the employeeID.
        *
        * @return a passwordsalt string, possibly null if none found based on the username.
        */
        public static string GetOnePasswordSaltString(int employeeID)
        {
            //create a command
            MySqlCommand cmd = new MySqlCommand(selectOneStatement, connection);

            //string to be returned
            string passwordSalt = null;

            //one parameter for the query - string username
            cmd.Parameters.AddWithValue("@employeeID", employeeID);

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
                    //get the password salt string
                    passwordSalt = reader.GetString("passwordSalt");
                }

                //close reader after if statement
                reader.Close();

                connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Getting the Password Salt");

                connection.Close();

            }

            //return the employee
            return passwordSalt;
        }

        /**
        * Updates an employee's password salt string.
        *
        * @param password salt, employee ID
        * @return bool - if passwordsalt was updated or not
        */
        public static bool UpdatePasswordSalt(string passwordSalt, int employeeID)
        {
            //create a command
            MySqlCommand cmd = new MySqlCommand(updateSaltStatement, connection);

            //two parameters for the query - password and employeeID
            cmd.Parameters.AddWithValue("@passwordSalt", passwordSalt);
            cmd.Parameters.AddWithValue("@employeeID", employeeID);

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
                MessageBox.Show(ex.Message, "Error Updating Password Salt");

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
