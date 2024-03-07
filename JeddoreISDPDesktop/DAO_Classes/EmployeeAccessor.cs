using JeddoreISDPDesktop.Entity_Classes;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Windows.Forms;

namespace JeddoreISDPDesktop.DAO_Classes
{
    //DAO public static class for Employee
    public static class EmployeeAccessor
    {
        //private static connection string
        private static string connString = ConfigurationManager.ConnectionStrings["ISDPConnString"].ConnectionString;

        //create a connection
        private static MySqlConnection connection = new MySqlConnection(connString);

        //SQL statements for the Employee entity
        private static string selectAllStatement = "select e.employeeID, e.Password, e.FirstName, e.LastName, IFNULL(e.Email, '') as Email, e.active, e.PositionID, e.siteID, e.locked, e.username, IFNULL(e.notes, '') as notes, loginAttempts, madeFirstLogin, s.name, p.permissionLevel from employee e inner join site s on e.siteID = s.siteID inner join posn p on e.positionID = p.positionID order by employeeID";
        private static string selectOneStatement = "select e.employeeID, e.Password, e.FirstName, e.LastName, IFNULL(e.Email, '') as Email, e.active, e.PositionID, e.siteID, e.locked, e.username, IFNULL(e.notes, '') as notes, loginAttempts, madeFirstLogin, s.name, p.permissionLevel from employee e inner join site s on e.siteID = s.siteID inner join posn p on e.positionID = p.positionID " +
            "where username = @username";
        private static string selectLastEmployeeStatement = "select e.employeeID, e.Password, e.FirstName, e.LastName, IFNULL(e.Email, '') as Email, e.active, e.PositionID, e.siteID, e.locked, e.username, IFNULL(e.notes, '') as notes, loginAttempts, madeFirstLogin, s.name, p.permissionLevel from employee e inner join site s on e.siteID = s.siteID inner join posn p on e.positionID = p.positionID" +
            " order by employeeid DESC LIMIT 1";
        private static string selectCountEmployeesWithUsernameAndNotEmployeeID = "select count(*) from employee where username like @username and employeeID != @employeeID";
        private static string selectCountEmployeesWithUsername = "select count(*) from employee where username like @username";
        private static string updateLockedStatement = "update employee set locked = 1 where employeeID = @employeeID";
        private static string updateInactiveStatement = "update employee set active = 0 where employeeID = @employeeID";
        private static string updatePasswordStatement = "update employee set password = @password where employeeID = @employeeID";
        private static string updateLoginAttemptsMinusOneStatement = "update employee set loginAttempts = loginAttempts - 1 where employeeID = @employeeID";
        private static string updateLoginAttemptsToThreeStatement = "update employee set loginAttempts = 3 where employeeID = @employeeID";
        private static string updateMadeFirstLoginStatement = "update employee set madeFirstLogin = 1 where employeeID = @employeeID";
        private static string updateEmployeeFieldsStatement = "update employee set username = @username, password = @password, firstName = @firstName, lastName = @lastName, email = @email, active = @active, siteID = @siteID, locked = @locked, positionID = @positionID where employeeID = @employeeID";
        private static string insertEmployeeStatement = "insert into employee (`Password`, `FirstName`, `LastName`, `Email`, `active`, `siteID`, `username`, `locked`, `PositionID`) VALUES "
            + "(@password, @firstName, @lastName, @email, @active, @siteID, @username, @locked, @positionID)";

        /**
         * Get all of the employees.
         *
         * @return a DataTable, possibly empty, of Employees.
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

                //run loop thru datareader
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
                    string permissionLevel = reader.GetString("permissionLevel");
                    byte loginAttempts = reader.GetByte("loginAttempts");
                    byte madeFirstLogin = reader.GetByte("madeFirstLogin");

                    //create an employee object
                    Employee employee = new Employee(employeeID, password, firstName, lastName, email,
                        active, positionID, siteID, locked, username, notes, siteName, permissionLevel,
                        loginAttempts, madeFirstLogin);

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
        * @param string username
        * @return an Employee object, possibly null if none found based on the username.
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
                    string notes = reader.GetString("notes");
                    string siteName = reader.GetString("name");
                    string permissionLevel = reader.GetString("permissionLevel");
                    byte loginAttempts = reader.GetByte("loginAttempts");
                    byte madeFirstLogin = reader.GetByte("madeFirstLogin");

                    //create an employee object
                    employee = new Employee(employeeID, password, firstName, lastName, email,
                        active, positionID, siteID, locked, username, notes, siteName, permissionLevel,
                        loginAttempts, madeFirstLogin);
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
        * Gets the last employee in the DB, AKA the one with the highest employee ID.
        *
        * @return an Employee, possibly null if none found based.
        */
        public static Employee GetLastEmployee()
        {
            //create a command
            MySqlCommand cmd = new MySqlCommand(selectLastEmployeeStatement, connection);

            //employee to be returned
            Employee employee = null;

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
                    string permissionLevel = reader.GetString("permissionLevel");
                    byte loginAttempts = reader.GetByte("loginAttempts");
                    byte madeFirstLogin = reader.GetByte("madeFirstLogin");

                    //create an employee object
                    employee = new Employee(employeeID, password, firstName, lastName, email,
                        active, positionID, siteID, locked, username, notes, siteName, permissionLevel,
                        loginAttempts, madeFirstLogin);
                }

                //close reader after if statement
                reader.Close();

                //close the connection
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Getting the Last Employee");

                connection.Close();

            }

            //return the employee
            return employee;
        }

        /**
        * Gets the count number of employees matching a wildcard pattern of a particular username.
        *
        * @return a long, possibly 0 if none found based on the username wildcard.
        */
        public static long GetCountWithTheUsernameAndEmployeeID(string usernameSentIn, int employeeID)
        {
            //create a command
            MySqlCommand cmd = new MySqlCommand(selectCountEmployeesWithUsernameAndNotEmployeeID, connection);

            //int to be returned
            long rowCount = 0;

            //one parameter for the query - string username
            cmd.Parameters.AddWithValue("@username", "%" + usernameSentIn);
            cmd.Parameters.AddWithValue("@employeeID", employeeID);

            //create a datareader and execute
            try
            {
                connection.Open();

                //create a datareader and execute the SQL statement against the DB
                rowCount = (long)cmd.ExecuteScalar();

                //close the connection
                connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Getting the Count of Employees With That Username and Employee ID");

                connection.Close();

            }

            //return the rowCount (int)
            return rowCount;
        }

        /**
        * Gets the count number of employees matching a wildcard pattern of a particular username.
        *
        * @return a long, possibly 0 if none found based on the username wildcard.
        */
        public static long GetCountWithTheUsername(string usernameSentIn)
        {
            //create a command
            MySqlCommand cmd = new MySqlCommand(selectCountEmployeesWithUsername, connection);

            //int to be returned
            long rowCount = 0;

            //one parameter for the query - string username
            cmd.Parameters.AddWithValue("@username", "%" + usernameSentIn + "%");

            //create a datareader and execute
            try
            {
                connection.Open();

                //create a datareader and execute the SQL statement against the DB
                rowCount = (long)cmd.ExecuteScalar();

                //close the connection
                connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Getting the Count of Employees With That Username");

                connection.Close();

            }

            //return the rowCount (int)
            return rowCount;
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
        * Updates an employee's login attempts by -1.
        *
        * @param employeeID
        * @return bool - if employee was updated or not
        */
        public static bool UpdateEmployeeLoginAttemptsMinusOne(int employeeID)
        {
            //create a command
            MySqlCommand cmd = new MySqlCommand(updateLoginAttemptsMinusOneStatement, connection);

            //just one parameter for the query - employeeID
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
        * Updates an employee's login attempts back to the default (3).
        *
        * @param employeeID
        * @return bool - if employee was updated or not
        */
        public static bool UpdateEmployeeLoginAttemptsToThree(int employeeID)
        {
            //create a command
            MySqlCommand cmd = new MySqlCommand(updateLoginAttemptsToThreeStatement, connection);

            //just one parameter for the query - employeeID
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
        * Updates an employee's madeFirstLogin value to 1 after their first successful login.
        *
        * @param employeeID
        * @return bool - if employee was updated or not
        */
        public static bool UpdateEmployeeMadeFirstLogin(int employeeID)
        {
            //create a command
            MySqlCommand cmd = new MySqlCommand(updateMadeFirstLoginStatement, connection);

            //just one parameter for the query - employeeID
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
        * Updates an existing employee and most of it's fields.
        *
        * @param employee object
        * @return bool - if employee was updated or not
        */
        public static bool UpdateEmployeeFields(Employee employee)
        {
            //create a command
            MySqlCommand cmd = new MySqlCommand(updateEmployeeFieldsStatement, connection);

            //many parameters for this update query
            cmd.Parameters.AddWithValue("@username", employee.username);
            cmd.Parameters.AddWithValue("@password", employee.password);
            cmd.Parameters.AddWithValue("@firstName", employee.firstName);
            cmd.Parameters.AddWithValue("@lastName", employee.lastName);
            cmd.Parameters.AddWithValue("@email", employee.email);
            cmd.Parameters.AddWithValue("@active", employee.active);
            cmd.Parameters.AddWithValue("@siteID", employee.siteID);
            cmd.Parameters.AddWithValue("@positionID", employee.positionID);
            cmd.Parameters.AddWithValue("@locked", employee.locked);
            cmd.Parameters.AddWithValue("@employeeID", employee.employeeID);

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
                MessageBox.Show(ex.Message, "Error Updating Existing Employee");

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
            MySqlCommand cmd = new MySqlCommand(insertEmployeeStatement, connection);

            //many parameters for this insert query
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
