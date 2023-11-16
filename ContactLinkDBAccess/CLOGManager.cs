using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace ContactLinkDBAccess
{
    public class CLOGManager
    {
        public int SID;
        public string Name;

        public string FirstName;
        public string LastName;
        public string number;
        public string email;
        public string studentID;
        public string profession;
        public string role;
        public string organization;
        public string mentor_experience;
        public string recieved_from;
        public string last_contacted_date;

        

        public CLOGManager() { }

        public static List<CLOGManager> GetAllClog()
        {
            List<CLOGManager> contact = new List<CLOGManager>();

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
                        CLOGManager ContactLog = new CLOGManager();
                        ContactLog.studentID = reader.GetInt32(0).ToString();
                        ContactLog.LastName = reader.GetString(1);
                        ContactLog.FirstName = reader.GetString(2);
                        ContactLog.email = reader.GetString(3);
                        ContactLog.number = reader.GetString(4); 
                        ContactLog.profession = reader.GetString(5); 
                        ContactLog.role = reader.GetString(6);
                        ContactLog.organization = reader.GetString(7); 
                        ContactLog.mentor_experience = reader.GetString(8); 
                        ContactLog.recieved_from = reader.GetString(9); 
                        ContactLog.last_contacted_date = reader.GetString(10); 


                        contact.Add(ContactLog);
                        //Console.WriteLine(SID + "\t" + lastName + "\t" + firstName + "\t" + city + "\t" + email);
                    }

                }
                return contact;
            }
        }

        public static int InsertNewCLOG(CLOG newCLOG)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

            builder.DataSource = "nutcrackerdb.database.windows.net";
            builder.UserID = "contactlinkclient";
            builder.Password = "Big@8013";
            builder.InitialCatalog = "contactlinkdb";

            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("INSERT INTO ContactLog (LastName, FirstName, Email, Number, Profession, Role, Organization, Mentor_Experience, Received_From, Last_Contacted_Date) VALUES (@LastName, @FirstName, @Email, @Number, @Profession, @Role, @Organization, @MentorExperience, @ReceivedFrom, @LastContactedDate); SELECT SCOPE_IDENTITY();", connection))
                {
                    // Add parameters to the SQL command
                    command.Parameters.AddWithValue("@LastName", newCLOG.LastName);
                    command.Parameters.AddWithValue("@FirstName", newCLOG.FirstName);
                    command.Parameters.AddWithValue("@Email", newCLOG.Email);
                    command.Parameters.AddWithValue("@Number", newCLOG.Number);
                    command.Parameters.AddWithValue("@Profession", newCLOG.Profession);
                    command.Parameters.AddWithValue("@Role", newCLOG.Role);
                    command.Parameters.AddWithValue("@Organization", newCLOG.Organization);
                    command.Parameters.AddWithValue("@MentorExperience", newCLOG.MentorExperience);
                    command.Parameters.AddWithValue("@ReceivedFrom", newCLOG.ReceivedFrom);
                    command.Parameters.AddWithValue("@LastContactedDate", newCLOG.LastContactedDate);
                    // Add other parameters as needed

                    // Execute the SQL command
                    return Convert.ToInt32(command.ExecuteScalar());
                }
            }
        }
        public static void DeleteCLOG(int studentID)
        {

            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

            builder.DataSource = "nutcrackerdb.database.windows.net";
            builder.UserID = "contactlinkclient";
            builder.Password = "Big@8013";
            builder.InitialCatalog = "contactlinkdb";

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
                        string role = reader.GetString(6);
                        string organization = reader.GetString(7);
                        string mentor_experience = reader.GetString(8);
                        string recieved_from = reader.GetString(9);
                        DateTime last_contacted_date = reader.GetDateTime(10);

                        Console.WriteLine($"{studentID}\t{LastName}\t{FirstName}\t{email}\t{number}\t{profession}\t{role}\t{organization}\t{mentor_experience}\t{recieved_from}\t{last_contacted_date}");
                    }

                }
            }
        }
    }
}

//update database


public class CLOG
{
    // Properties of your CLOG class
    public int StudentID { get; set; }
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public string Email { get; set; }
    public string Number { get; set; }
    public string Profession { get; set; }
    public string Role { get; set; }
    public string Organization { get; set; }
    public string MentorExperience { get; set; }
    public string ReceivedFrom { get; set; }
    public DateTime LastContactedDate { get; set; }

    // ... other properties

    public CLOG() { }

    // Constructor with all properties
    public CLOG(int studentID, string lastName, string firstName, string email, string number, string profession, string role, string organization, string mentorExperience, string receivedFrom, DateTime lastContactedDate)
    {
        StudentID = studentID;
        LastName = lastName;
        FirstName = firstName;
        Email = email;
        Number = number;
        Profession = profession;
        Role = role;
        Organization = organization;
        MentorExperience = mentorExperience;
        ReceivedFrom = receivedFrom;
        LastContactedDate = lastContactedDate;
        // Set other properties
    }
    public CLOG(string lastName, string firstName, string email, string number, string profession, string role, string organization, string mentorExperience, string receivedFrom, DateTime lastContactedDate)
    {
        LastName = lastName;
        FirstName = firstName;
        Email = email;
        Number = number;
        Profession = profession;
        Role = role;
        Organization = organization;
        MentorExperience = mentorExperience;
        ReceivedFrom = receivedFrom;
        LastContactedDate = lastContactedDate;
    }
}

public class DatabaseManager
{
    private string connectionString;

    public DatabaseManager(string connectionString)
    {
        this.connectionString = connectionString;
    }

   
}

class Program
{
    static void Main()
    {
        string connectionString = "your_connection_string_here";
        DatabaseManager dbManager = new DatabaseManager(connectionString);

        // Example: Creating a new CLOG instance
        CLOG newCLOG = new CLOG
        {
            LastName = "Jin",
            FirstName = "Fiona",
            Email = "fiona.y.jin@gmail.com",
            Number = "425-451-8621",
            Profession = "declogger",
            Role = "pro gamer",
            Organization = "clog",
            MentorExperience = "Experienced mentor",
            ReceivedFrom = "Referral",
            LastContactedDate = DateTime.Now,
        };

        // Inserting the new row into the database
        // dbManager.InsertNewCLOG(newCLOG);
    }
}

