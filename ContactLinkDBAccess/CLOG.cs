using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace ContactLinkDBAccess
{
    public class CLOG
    {
        public int SID;
        public string Name;

        public string FirstName;
        public string LastName;
        public string number;
        public string email;
        public string studentID;
        public string profession;
        public string organization;
        public string mentor_experience;
        public string recieved_from;
        public string last_contacted_date;



        public CLOG() { }

        public static List<CLOG> GetAllStudents()
        {
            List<CLOG> contact = new List<CLOG>();

            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

            builder.DataSource = "nutcrackerdb.database.windows.net";
            builder.UserID = "contactlinkclient";
            builder.Password = "Big@8013";
            builder.InitialCatalog = "contactlinkdb";


            //string connString = @"Server=tcp:contactlinkserver.database.windows.net,1433;Initial Catalog=ContactLinkDB;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;Authentication=""Active Directory Default";
            using (SqlConnection con = new SqlConnection(builder.ConnectionString))
            {
                con.Open();

                using (SqlCommand command = new SqlCommand("select * from ContactLog", con))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        CLOG ContactLog = new CLOG();
                        ContactLog.studentID = reader.GetInt32(0).ToString();
                        ContactLog.LastName = reader.GetString(1);
                        ContactLog.FirstName = reader.GetString(2);
                        ContactLog.email = reader.GetString(3);
                        ContactLog.number = reader.GetString(4); 
                        ContactLog.profession = reader.GetString(5); 
                        ContactLog.organization = reader.GetString(6); 
                        ContactLog.mentor_experience = reader.GetString(7); 
                        ContactLog.recieved_from = reader.GetString(8); 
                        ContactLog.last_contacted_date = reader.GetString(9); 


                        contact.Add(ContactLog);
                        //Console.WriteLine(SID + "\t" + lastName + "\t" + firstName + "\t" + city + "\t" + email);
                    }

                }
                return contact;
            }
        }

        public static void DisplayCLOG()
        {
        

            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

            builder.DataSource = "nutcrackerdb.database.windows.net";
            builder.UserID = "contactlinkclient";
            builder.Password = "Big@8013";
            builder.InitialCatalog = "contactlinkdb";


            //string connString = @"Server=tcp:contactlinkserver.database.windows.net,1433;Initial Catalog=ContactLinkDB;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;Authentication=""Active Directory Default";
            using (SqlConnection con = new SqlConnection(builder.ConnectionString))
            {
                con.Open();

                using (SqlCommand command = new SqlCommand("select * from ContactLog", con))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        int studentID = reader.GetInt32(0);
                        string LastName = reader.GetString(1);  
                        string FirstName = reader.GetString(2); 
                        string email = reader.GetString(3); 
                        string number = reader.GetString(4);
                        string profession = reader.GetString(5);
                        string organization = reader.GetString(6);
                        string mentor_experience = reader.GetString(7);
                        string recieved_from = reader.GetString(8);
                        string last_contacted_date = reader.GetString(9);
                        Console.WriteLine($"{studentID}\t{LastName}\t{FirstName}\t{email}\t{number}\t{profession}\t{organization}\t{mentor_experience}\t{recieved_from}\t{last_contacted_date}");
                    }

                }
            }
        }

        public static void UpdateStudent(string firstName, string lastName, string address, string city)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "nutcrackerdb.database.windows.net";
            builder.UserID = "contactlinkclient";
            builder.Password = "Big@8013";
            builder.InitialCatalog = "contactlinkdb";

            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("UPDATE ContactLog SET Address = @add, City = @cit WHERE FirstName = @fn AND LastName = @ln", connection))
                {
                    command.Parameters.AddWithValue("@fn", firstName);
                    command.Parameters.AddWithValue("@ln", lastName);
                    command.Parameters.AddWithValue("@add", address);
                    command.Parameters.AddWithValue("@cit", city);

                    int rowsAffected = command.ExecuteNonQuery();
                    Console.WriteLine(rowsAffected + " row(s) updated");

                    public static void Main(String[] args)
        {
            Console.WriteLine("Main Method");
        }
    }
}
