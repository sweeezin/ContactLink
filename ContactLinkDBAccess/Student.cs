using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace ContactLinkDBAccess
{
    public class Student
    {
        public static void DisplayStudent()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

            builder.DataSource = "contactlinkserver.database.windows.net";
            builder.UserID = "contactlinkclient";
            builder.Password = "Pwd@8013";
            builder.InitialCatalog = "ContactLinkDB";


            //string connString = @"Server=tcp:contactlinkserver.database.windows.net,1433;Initial Catalog=ContactLinkDB;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;Authentication=""Active Directory Default";
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

                }
            }
        }
    }
}
