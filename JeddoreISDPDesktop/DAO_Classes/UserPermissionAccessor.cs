using JeddoreISDPDesktop.Entity_Classes;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Windows.Forms;

namespace JeddoreISDPDesktop.DAO_Classes
{
    //DAO static class for UserPermission
    public static class UserPermissionAccessor
    {
        //private static connection string
        private static string connString = ConfigurationManager.ConnectionStrings["ISDPConnString"].ConnectionString;

        //create a connection
        private static MySqlConnection connection = new MySqlConnection(connString);

        //SQL statements for the Employee entity
        private static string selectAllEmployeesUserPermissionsStatement = "select * from user_permission";
        private static string selectOneEmployeeUserPermissionsStatement = "select * from user_permission where employeeID = @employeeID";
        private static string insertUserPermissionStatement = "INSERT INTO `user_permission` (`employeeID`, `permissionID`) VALUES (@employeeID, @permissionID)";
        private static string deleteUserPermissionStatement = "DELETE FROM `user_permission` where employeeID = @employeeID and permissionID = @permissionID";

        /**
        * Gets one user permission object, based on the employeeID sent in.
        *
        * @return an Employee, possibly null if none found based on the username.
        */
        public static UserPermission GetOneEmployeeUserPermissions(int employeeID)
        {
            //create a command
            MySqlCommand cmd = new MySqlCommand(selectOneEmployeeUserPermissionsStatement, connection);

            //userpermssion obj to be returned
            UserPermission userPermission = null;

            //list of string permissions (permission IDs)
            List<string> employeePermissions = new List<string>();

            //one parameter for the query - int employeeID
            cmd.Parameters.AddWithValue("@employeeID", employeeID);

            //create a datareader and execute
            try
            {
                connection.Open();

                //create a datareader and execute the SQL statement against the DB
                MySqlDataReader reader = cmd.ExecuteReader();

                //if - there are records to read
                //NOTE: if this doesn't work, try a loop here instead
                while (reader.Read())
                {
                    //get just one value from one column - permissionID
                    string permissionID = reader.GetString("permissionID");

                    //add the permission ID to the list
                    employeePermissions.Add(permissionID);
                }

                //instantiate userpermission object
                userPermission = new UserPermission(employeeID, employeePermissions);

                //close reader after if statement
                reader.Close();

                //close the connection
                connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Getting that Employee's User Permissions");

                connection.Close();

            }

            //return the employee
            return userPermission;
        }

        /**
        * Inserts a new user permission record.
        *
        * @param int employeeID, string permissionID
        * @return bool - if user permission was inserted or not
        */
        public static bool InsertNewUserPermission(int employeeID, string permissionID)
        {
            //create a command
            MySqlCommand cmd = new MySqlCommand(insertUserPermissionStatement, connection);

            //two parameters for the query - employeeID and permissionID
            cmd.Parameters.AddWithValue("@employeeID", employeeID);
            cmd.Parameters.AddWithValue("@permissionID", permissionID);

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
                MessageBox.Show(ex.Message, "Error Inserting User Permission");

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
        * Deletes an existing user permission record.
        *
        * @param int employeeID, string permissionID
        * @return bool - if user permission was deleted or not
        */
        public static bool DeleteNewUserPermission(int employeeID, string permissionID)
        {
            //create a command
            MySqlCommand cmd = new MySqlCommand(deleteUserPermissionStatement, connection);

            //two parameters for the query - employeeID and permissionID
            cmd.Parameters.AddWithValue("@employeeID", employeeID);
            cmd.Parameters.AddWithValue("@permissionID", permissionID);

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
                MessageBox.Show(ex.Message, "Error Deleting User Permission");

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
