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
        private static string selectAllStatement = "select e.employeeID, e.Password, e.FirstName, e.LastName, IFNULL(e.Email, '') AS Email, e.active, e.PositionID, e.siteID, e.locked, e.username, IFNULL(e.notes, '') as notes, s.name from employee e inner join site s on e.siteID = s.siteID";
        private static string selectOneStatement = "select e.employeeID, e.Password, e.FirstName, e.LastName, IFNULL(e.Email, '') AS Email, e.active, e.PositionID, e.siteID, e.locked, e.username, IFNULL(e.notes, '') as notes, s.name from employee e inner join site s on e.siteID = s.siteID " +
            "where username = @username";
        private static string updateLockedStatement = "update employee set locked = 1 where employeeID = @employeeID";
        private static string updateInactiveStatement = "update employee set active = 0 where employeeID = @employeeID";
        private static string updatePasswordStatement = "update employee set password = @password where employeeID = @employeeID";
        private static string InsertEmployeeStatement = "insert into employee (`employeeID`, `Password`, `FirstName`, `LastName`, `Email`, `active`, `siteID`, `username`, `locked`, `PositionID`) VALUES "
            + "(@employeeID, @password, @firstName, @lastName, @email, @active, @siteID, @username, @locked, @positionID)";
        /**
         * Get all of the employees.
         *
         * @return a DataTable, possibly empty, of Employee objects.
         */
        public static DataTable GetAllEmployeesDataTable()
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
                MessageBox.Show(ex.Message, "Error Getting All Employees");

                connection.Close();

            }

            //return the datatable
            return dt;
        }

        /**
        * Get all of the employees.
        *
        * @return a List, possibly empty, of Employee objects.
        */
        public static List<Employee> GetAllEmployeesList()
        {
            //create a command
            MySqlCommand cmd = new MySqlCommand(selectAllStatement, connection);

            //list to be returned
            List<Employee> employeesList = new List<Employee>();

            //create a datareader and execute
            try
            {
                connection.Open();

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

                connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Getting All Employees");

                connection.Close();

            }

            //return the employees list
            return employeesList;
        }

        /**
        * Gets one employee, based on the username.
        *
        * @return an Employee, possibly null if none found based on the username.
        */
        public static Employee GetOneEmployee(string usernameSentIn)
        {
            //create a command
            MySqlCommand cmd = new MySqlCommand(selectOneStatement, connection);

            //employee to be returned
            Employee employee = null;

            //one parameter for the query - string username
            cmd.Parameters.AddWithValue("@username", usernameSentIn);

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
                    string notes = reader.GetString("notes") as string;
                    string siteName = reader.GetString("name");

                    //create an employee object
                    employee = new Employee(employeeID, password, firstName, lastName, email,
                        active, positionID, siteID, locked, username, notes, siteName);
                }

                //close reader after if statement
                reader.Close();

                //close the connection
                connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Getting the One Employee");

                connection.Close();

            }

            //return the employee
            return employee;
        }

        /**
        * Updates an employee to be locked.
        *
        * @param employee ID
        * @return bool - if employee was updated or not
        */
        public static bool UpdateEmployeeToLocked(int employeeID)
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
                connection.Open();

                //execute a non query
                rowCount = cmd.ExecuteNonQuery();

                connection.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Updating Employee");

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
        * Updates an employee to be inactive
        *
        * @param employee ID
        * @return bool - if employee was updated or not
        */
        public static bool UpdateEmployeeToInactive(int employeeID)
        {
            //create a command
            MySqlCommand cmd = new MySqlCommand(updateInactiveStatement, connection);

            //one parameter for the query - integer employeeID
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
                MessageBox.Show(ex.Message, "Error Updating Employee");

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
        * Updates an employee's password.
        *
        * @param password, employee ID
        * @return bool - if employee was updated or not
        */
        public static bool UpdateEmployeePassword(string password, int employeeID)
        {
            //create a command
            MySqlCommand cmd = new MySqlCommand(updatePasswordStatement, connection);

            //two parameters for the query - password and employeeID
            cmd.Parameters.AddWithValue("@password", password);
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
                MessageBox.Show(ex.Message, "Error Updating Employee");

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
        * Inserts a new employee.
        *
        * @param employee object
        * @return bool - if employee was inserted or not
        */
        public static bool InsertNewEmployee(Employee employee)
        {
            //create a command
            MySqlCommand cmd = new MySqlCommand(InsertEmployeeStatement, connection);

            //two parameters for the query - password and employeeID
            cmd.Parameters.AddWithValue("@employeeID", employee.employeeID);
            cmd.Parameters.AddWithValue("@password", employee.password);
            cmd.Parameters.AddWithValue("@firstName", employee.firstName);
            cmd.Parameters.AddWithValue("@lastName", employee.lastName);
            cmd.Parameters.AddWithValue("@email", employee.email);
            cmd.Parameters.AddWithValue("@active", employee.active);
            cmd.Parameters.AddWithValue("@positionID", employee.positionID);
            cmd.Parameters.AddWithValue("@siteID", employee.siteID);
            cmd.Parameters.AddWithValue("@locked", employee.locked);
            cmd.Parameters.AddWithValue("@username", employee.username);
            cmd.Parameters.AddWithValue("@notes", employee.notes);

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
                MessageBox.Show(ex.Message, "Error Inserting Employee");

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
