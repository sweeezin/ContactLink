using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace ContactLinkDBAccess
{
    public class CLOG
    {
        public int ID { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string number { get; set; }
        public string profession { get; set; }
        public string role { get; set; }
        public string organization { get; set; }
        public string mentorExperience { get; set; }
        public string recievedFrom { get; set; }
        public DateTime lastContactedDate { get; set; }



        public CLOG() { }

        public static List<CLOG> GetAllStudents()
        {
            List<CLOG> contact = new List<CLOG>();

            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            initializeConnection(builder);


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
                        ContactLog.ID = reader.GetInt32(0);
                        ContactLog.firstName = reader.GetString(1);
                        ContactLog.lastName = reader.GetString(2);
                        ContactLog.email = reader.GetString(3);
                        ContactLog.number = reader.GetString(4);
                        ContactLog.profession = reader.GetString(5);
                        ContactLog.role = reader.GetString(6);
                        ContactLog.organization = reader.GetString(7);
                        ContactLog.mentorExperience = reader.GetString(8);
                        ContactLog.recievedFrom = reader.GetString(9);
                        ContactLog.lastContactedDate = reader.GetDateTime(10);


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
            initializeConnection(builder);


            //string connString = @"Server=tcp:contactlinkserver.database.windows.net,1433;Initial Catalog=ContactLinkDB;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;Authentication=""Active Directory Default";
            using (SqlConnection con = new SqlConnection(builder.ConnectionString))
            {
                con.Open();

                using (SqlCommand command = new SqlCommand("select * from ContactLog", con))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        int ID = reader.GetInt32(0);
                        string LastName = reader.GetString(1);
                        string FirstName = reader.GetString(2);
                        string email = reader.GetString(3);
                        string number = reader.GetString(4);
                        string profession = reader.GetString(5);
                        string organization = reader.GetString(6);
                        string mentor_experience = reader.GetString(7);
                        string recieved_from = reader.GetString(8);
                        string last_contacted_date = reader.GetString(9);
                        Console.WriteLine($"{ID}\t{LastName}\t{FirstName}\t{email}\t{number}\t{profession}\t{organization}\t{mentor_experience}\t{recieved_from}\t{last_contacted_date}");
                    }

                }
            }
        }

        public static void DeleteCLOG(int studentID)
        {

            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            initializeConnection(builder);

            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("DELETE FROM ContactLog WHERE StudentID = @StudentID", connection))
                {
                    // Add parameters to the SQL command
                    command.Parameters.AddWithValue("@StudentID", studentID);

                    // Execute the SQL command
                    command.ExecuteNonQuery();
                }
            }
        }

        public static void UpdateServer(int studentID,
            string lastName,
            string firstName,
            string email,
            string number,
            string profession,
            string role,
            string organization,
            string mentorExperience,
            string recievedFrom,
            DateTime lastContactedDate)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            initializeConnection(builder);

            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(@"UPDATE ContactLog 
                    SET lastname = @ln, 
                    firstname = @fn, 
                    email = @em, 
                    number = @num, 
                    profession = @prof, 
                    role = @rol, 
                    organization = @org, 
                    mentor_experience = @menEx, 
                    received_from = @rf, 
                    last_contacted_date = @lcd 
                    WHERE studentID = @sID", connection))
                {
                    command.Parameters.AddWithValue("@sID", studentID);
                    command.Parameters.AddWithValue("@ln", lastName);
                    command.Parameters.AddWithValue("@fn", firstName);
                    command.Parameters.AddWithValue("@em", email);
                    command.Parameters.AddWithValue("@num", number);
                    command.Parameters.AddWithValue("@prof", profession);
                    command.Parameters.AddWithValue("@rol", role);
                    command.Parameters.AddWithValue("@org", organization);
                    command.Parameters.AddWithValue("@menEX", mentorExperience);
                    command.Parameters.AddWithValue("@rf", recievedFrom);
                    command.Parameters.AddWithValue("@lcd", lastContactedDate);

                    command.ExecuteNonQuery();
                }
            }
        }
        public static void addRow()
        { //TODO: Make sure that the user that adds the row can see the row - not necessary currently because we have not implemented users being unable to see rows.
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            initializeConnection(builder);

            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(@"INSERT INTO ContactLog (lastname, 
                firstname, 
                email, 
                number, 
                profession, 
                role, 
                organization, 
                mentor_experience, 
                received_from, 
                last_contacted_date 
                ) VALUES
                (@ln, @fn, @em, @num, @pro, @rol, @org, @mex, @rf, @lcd)", connection))
                {
                    command.Parameters.AddWithValue("@ln", "");
                    command.Parameters.AddWithValue("@fn", "");
                    command.Parameters.AddWithValue("@em", "");
                    command.Parameters.AddWithValue("@num", "");
                    command.Parameters.AddWithValue("@pro", "");
                    command.Parameters.AddWithValue("@rol", "");
                    command.Parameters.AddWithValue("@org", "");
                    command.Parameters.AddWithValue("@mex", "");
                    command.Parameters.AddWithValue("@rf", "");
                    command.Parameters.AddWithValue("@lcd", "2022-11-11");

                    command.ExecuteNonQuery();
                }

            }
        }
        //Use this command to change where we are adding new rows from. Don't let user use it. Place change a row before where we want to add new rows too.
        public static void devOnlyAutoIncrementChange(int change)
        {
           
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            initializeConnection(builder);

            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand($"DBCC CHECKIDENT('ContactLog', reseed, {change})", connection))
                {
                    command.ExecuteNonQuery();
                }

            }
        }
        public static SqlConnectionStringBuilder initializeConnection(SqlConnectionStringBuilder build)
        {
            build.DataSource = "nutcrackerdb.database.windows.net";
            build.UserID = "contactlinkclient";
            build.Password = "Big@8013";
            build.InitialCatalog = "contactlinkdb";

            return build;
        }
    }
}

