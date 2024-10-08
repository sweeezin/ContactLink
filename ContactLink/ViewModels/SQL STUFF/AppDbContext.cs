﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using Microsoft.VisualBasic.Logging;
using ContactLinkDBAccess;


namespace ContactLink.ViewModels.SQL_STUFF
{
    public class ContactLinkDataAccessLayer
    {
        public static void DisplayStudent()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            CLOG.initializeConnection(builder);
            using (SqlConnection con = new SqlConnection(builder.ConnectionString))
            {
                con.Open();

                using (SqlCommand command = new SqlCommand("select * from student", con))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        int SID = reader.GetInt32(0);    // Weight int
                        string lastName = reader.GetString(1);  // Name string
                        string firstName = reader.GetString(2); // Breed string
                        string city = reader.GetString(3); // Breed string
                        string email = reader.GetString(4); // Breed string
                        Console.WriteLine(SID + "\t" + lastName + "\t" + firstName + "\t" + city + "\t" + email);
                    }

                    /*
                        1	Doe	John	123 Main St	Anytown	john.doe@example.com
                        2	Smith	Jane	456 Elm St	Othertown	jane.smith@example.com
                        3	Johnson	Mark	789 Oak St	Sometown	mark.johnson@example.com
                        4	Wilson	Sarah	101 Pine St	Cityville	sarah.wilson@example.com
                        5	Brown	Emily	555 Cedar St	Yourtown	emily.brown@example.com 
                     * */
                }
            }
        }
    }
}
