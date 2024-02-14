using JeddoreISDPDesktop.Entity_Classes;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Windows.Forms;

namespace JeddoreISDPDesktop.DAO_Classes
{
    //public static class for Province
    public static class ProvinceAccessor
    {
        //private static connection string
        private static string connString = ConfigurationManager.ConnectionStrings["ISDPConnString"].ConnectionString;

        //create a connection
        private static MySqlConnection connection = new MySqlConnection(connString);

        //SQL statements
        private static string selectAllStatement = "select * from province";

        /**
        * Get all of the provinces.
        *
        * @return a List, possibly empty, of Province objects.
        */
        public static List<Province> GetAllProvincesList()
        {
            //create a command
            MySqlCommand cmd = new MySqlCommand(selectAllStatement, connection);

            //list to be returned
            List<Province> provinceList = new List<Province>();

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
                    string provinceID = reader.GetString("provinceID");
                    string provinceName = reader.GetString("provinceName");
                    string countryCode = reader.GetString("countryCode");

                    //custom constructor for posn
                    Province province = new Province(provinceID, provinceName, countryCode);

                    //add to the list
                    provinceList.Add(province);
                }

                //close reader after while loop
                reader.Close();

                connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Getting All Provinces");

                connection.Close();

            }

            //return the employees list
            return provinceList;
        }
    }
}
