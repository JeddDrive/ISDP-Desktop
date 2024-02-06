using JeddoreISDPDesktop.Entity_Classes;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Windows.Forms;

namespace JeddoreISDPDesktop.DAO_Classes
{
    //DAO static class for Site
    public static class SiteAccessor
    {
        //private static connection string
        private static string connString = ConfigurationManager.ConnectionStrings["ISDPConnString"].ConnectionString;

        //create a connection
        private static MySqlConnection connection = new MySqlConnection(connString);

        //SQL statements for the Site entity
        private static string selectAllStatement = "select siteID, name, provinceID, address, IFNULL(address2, '') as address2, city, country, postalCode, phone, IFNULL(dayOfWeek, '') as dayOfWeek, distanceFromWH, IFNULL(notes, '') as notes from site";
        private static string selectOneStatement = "select siteID, name, provinceID, address, IFNULL(address2, '') as address2, city, country, postalCode, phone, IFNULL(dayOfWeek, '') as dayOfWeek, distanceFromWH, IFNULL(notes, '') as notes from site where siteID = @siteID";
        private static string updateSiteStatement = "update site set name = @name, provinceID = @provinceID, address = @address, address2 = @address2, city = @city, country = @country, postalCode = @postalCode, phone = @phone, dayOfWeek = @dayOfWeek, distanceFromWH = @distanceFromWH, notes = @notes where siteID = @siteID";
        private static string insertSiteStatement = "insert into site (`siteID`, `name`, `provinceID`, `address`, `address2`, `city`, `country`, `postalCode`, `phone`, `dayOfWeek`, `distanceFromWH`, `notes`) VALUES "
            + "(@siteID, @name, @provinceID, @address, @address2, @city, @country, @postalCode, @phone, @dayOfWeek, @distanceFromWH, @notes)";

        /**
        * Get all of the sites.
        *
        * @return a DataTable, possibly empty, of Sites.
        */
        public static DataTable GetAllSitesDataTable()
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
                MessageBox.Show(ex.Message, "Error Getting All Sites");

                connection.Close();
            }

            //return the datatable
            return dt;
        }

        /**
        * Get all of the sites.
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

                    //create a site object
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
                MessageBox.Show(ex.Message, "Error Getting All Sites");

                connection.Close();

            }

            //return the sites list
            return sitesList;
        }

        /**
        * Get a specific site, based on the siteID.
        *
        * @param int siteID
        * @return a Site object, possibly null if none found based on the siteID.
        */
        public static Site GetOneSite(int siteIDSentIn)
        {
            //create a command
            MySqlCommand cmd = new MySqlCommand(selectOneStatement, connection);

            //one parameter for the query - int siteID
            cmd.Parameters.AddWithValue("@siteID", siteIDSentIn);

            //site to be returned
            Site site = null;

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

                    //assign to site object
                    site = new Site(siteID, name, provinceID, address, address2, city, country,
                        postalCode, phone, dayOfWeek, distanceFromWH, notes);

                }

                //close reader after while loop
                reader.Close();

                connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Getting the one Site");

                connection.Close();

            }

            //return the site
            return site;
        }

        /**
        * Updates an existing site and most of it's fields.
        *
        * @param site object
        * @return bool - if site was updated or not
        */
        public static bool UpdateSiteFields(Site site)
        {
            //create a command
            MySqlCommand cmd = new MySqlCommand(updateSiteStatement, connection);

            //many parameters for this update query
            cmd.Parameters.AddWithValue("@name", site.name);
            cmd.Parameters.AddWithValue("@provinceID", site.provinceID);
            cmd.Parameters.AddWithValue("@address", site.address);
            cmd.Parameters.AddWithValue("@address2", site.address2);
            cmd.Parameters.AddWithValue("@city", site.city);
            cmd.Parameters.AddWithValue("@country", site.country);
            cmd.Parameters.AddWithValue("@postalCode", site.postalCode);
            cmd.Parameters.AddWithValue("@phone", site.phone);
            cmd.Parameters.AddWithValue("@dayOfWeek", site.dayOfWeek);
            cmd.Parameters.AddWithValue("@distanceFromWH", site.distanceFromWH);
            cmd.Parameters.AddWithValue("@notes", site.notes);
            cmd.Parameters.AddWithValue("@siteID", site.siteID);

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
                MessageBox.Show(ex.Message, "Error Updating Existing Site");

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
        * Inserts a new site.
        *
        * @param site object
        * @return bool - if site was inserted or not
        */
        public static bool InsertNewSite(Site site)
        {
            //create a command
            MySqlCommand cmd = new MySqlCommand(insertSiteStatement, connection);

            //many parameters for this insert query
            cmd.Parameters.AddWithValue("@siteID", site.siteID);
            cmd.Parameters.AddWithValue("@name", site.name);
            cmd.Parameters.AddWithValue("@provinceID", site.provinceID);
            cmd.Parameters.AddWithValue("@address", site.address);
            cmd.Parameters.AddWithValue("@address2", site.address2);
            cmd.Parameters.AddWithValue("@city", site.city);
            cmd.Parameters.AddWithValue("@country", site.country);
            cmd.Parameters.AddWithValue("@postalCode", site.postalCode);
            cmd.Parameters.AddWithValue("@phone", site.phone);
            cmd.Parameters.AddWithValue("@dayOfWeek", site.dayOfWeek);
            cmd.Parameters.AddWithValue("@distanceFromWH", site.distanceFromWH);
            cmd.Parameters.AddWithValue("@notes", site.notes);

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
                MessageBox.Show(ex.Message, "Error Inserting Site");

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
