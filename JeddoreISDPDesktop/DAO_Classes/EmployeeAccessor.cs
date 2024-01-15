using JeddoreISDPDesktop.Entity_Classes;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Windows.Forms;

namespace JeddoreISDPDesktop.DAO_Classes
{
    //DAO static class for Employee
    public static class EmployeeAccessor
    {
        //private static connection string
        private static string connString = ConfigurationManager.ConnectionStrings["ISDPConnString"].ConnectionString;

        //create a connection
        private static MySqlConnection connection = new MySqlConnection(connString);

        //SQL statements for the Employee entity
        private static string selectAllStatement = "select e.*, s.name from employee e inner join site s on e.siteID = s.siteID";
        private static string updateLockedStatement = "update employee set locked = 1 where employeeID = @employeeID";

        /**
         * Get all of the employees.
         *
         * @return a DataTable, possibly empty, of Employee objects.
         */
        public static DataTable getAllEmployeesDataTable()
        {
            //create a command
            MySqlCommand cmd = new MySqlCommand(selectAllStatement, connection);

            //create datatable
            DataTable dt = new DataTable();

            //create a datareader and execute
            try
            {
                //execute the SQL statement against the DB
                //load into the DataTable object
                dt.Load(cmd.ExecuteReader());

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Getting All Employees");

            }

            //return the datatable
            return dt;
        }

        /**
        * Get all of the employees.
        *
        * @return a List, possibly empty, of Employee objects.
        */
        public static List<Employee> getAllEmployeesList()
        {
            //create a command
            MySqlCommand cmd = new MySqlCommand(selectAllStatement, connection);

            //list to be returned
            List<Employee> employeesList = new List<Employee>();

            //create a datareader and execute
            try
            {
                //create a datareader and execute the SQL statement against the DB
                MySqlDataReader reader = cmd.ExecuteReader();

                //run loop thru datareader to get each table name
                //while - there is another record to read
                while (reader.Read())
                {
                    //get the values from the columns
                    int employeeID = reader.GetInt32("employeeID");
                    string password = reader.GetString("Password");
                    string firstName = reader.GetString("FirstName");
                    string lastName = reader.GetString("LastName");
                    string email = reader.GetString("Email");
                    byte active = reader.GetByte("active");
                    int positionID = reader.GetInt32("PositionID");
                    int siteID = reader.GetInt32("siteID");
                    byte locked = reader.GetByte("locked");
                    string username = reader.GetString("username");
                    string notes = reader.GetString("notes");
                    string siteName = reader.GetString("name");

                    //create an employee object
                    Employee employee = new Employee(employeeID, password, firstName, lastName, email,
                        active, positionID, siteID, locked, username, notes, siteName);

                    //add to the list
                    employeesList.Add(employee);
                }

                //close reader after while loop
                reader.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Getting All Employees");

            }

            //return the employees list
            return employeesList;
        }

        /**
        * Updates an employee to be locked.
        *
        * @param employee ID
        * @return bool - if employee was updated or not
        * otherwise
        */
        public static bool updateEmployeeToLocked(int employeeID)
        {
            //create a command
            MySqlCommand cmd = new MySqlCommand(updateLockedStatement, connection);

            //one parameter for the query - integer employeeID
            cmd.Parameters.AddWithValue("@employeeID", employeeID);

            //variable for rowCount
            int rowCount = 0;

            //bool to be returned
            bool goodNonQuery = false;

            try
            {
                //execute a non query
                rowCount = cmd.ExecuteNonQuery();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Updating Employee");
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
