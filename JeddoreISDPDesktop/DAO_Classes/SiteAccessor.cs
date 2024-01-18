using JeddoreISDPDesktop.Entity_Classes;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Windows.Forms;

namespace JeddoreISDPDesktop.DAO_Classes
{
    //DAO static class for Employee
    public static class SiteAccessor
    {
        //private static connection string
        private static string connString = ConfigurationManager.ConnectionStrings["ISDPConnString"].ConnectionString;

        //create a connection
        private static MySqlConnection connection = new MySqlConnection(connString);

        //SQL statements for the Employee entity
        private static string selectAllStatement = "select siteID, name, provinceID, address, address2, city, country, postalCode, phone, IFNULL(dayOfWeek, ''), distanceFromWH, IFNULL(notes, '') from site";

        /**
        * Get all of the sites
        *
        * @return a List, possibly empty, of Site objects.
        */
        public static List<Site> GetAllSitesList()
        {
            //create a command
            MySqlCommand cmd = new MySqlCommand(selectAllStatement, connection);

            //list to be returned
            List<Site> sitesList = new List<Site>();

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
                    int siteID = reader.GetInt32("siteID");
                    string name = reader.GetString("name");
                    string provinceID = reader.GetString("provinceID");
                    string address = reader.GetString("address");
                    string address2 = reader.GetString("address2");
                    string city = reader.GetString("city");
                    string country = reader.GetString("country");
                    string postalCode = reader.GetString("postalCode");
                    string phone = reader.GetString("phone");
                    string dayOfWeek = reader.GetString("dayOfWeek");
                    int distanceFromWH = reader.GetInt32("distanceFromWH");
                    string notes = reader.GetString("notes");

                    //create an employee object
                    Site site = new Site(siteID, name, provinceID, address, address2, city, country,
                        postalCode, phone, dayOfWeek, distanceFromWH, notes);

                    //add to the list
                    sitesList.Add(site);
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

            //return the sites list
            return sitesList;
        }
    }
}
