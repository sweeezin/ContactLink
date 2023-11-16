using System;
using ContactLinkDBAccess;
public class CLOGManager
{
    private List<CLOG> contactList;

    public CLOGManager()
    {
        // Initialize the list
        contactList = CLOG.GetAllStudents();
    }

    public void AddNewContact()
    {
        // Collect user input
        Console.Write("Enter Last Name: ");
        string lastName = Console.ReadLine();

        Console.Write("Enter First Name: ");
        string firstName = Console.ReadLine();

        Console.Write("Enter Email: ");
        string email = Console.ReadLine();

        Console.Write("Enter Phone Number: ");
        string number = Console.ReadLine();

        // Create a new CLOG instance with user input
        CLOG newContact = new CLOG
        {
            LastName = lastName,
            FirstName = firstName,
            email = email,
            number = number,
            // ... (populate other properties as needed)
        };

        // Add the new contact to the list
        contactList.Add(newContact);

        // Update the SQL Server database
        UpdateDatabase();
    }

    private void UpdateDatabase()
    {
        // Your code to update the SQL Server database using contactList
        // Example using Entity Framework:
        using (var dbContext = new YourDbContext()) // Replace YourDbContext with your actual DbContext class
        {
            // Assuming YourDbContext has a DbSet<CLOG> named CLOGs
            dbContext.CLOGs.AddRange(contactList);
            dbContext.SaveChanges();
        }
    }

    public void DisplayAllContacts()
    {
        // Display all contacts in the list
        foreach (var contact in contactList)
        {
            Console.WriteLine($"Student ID: {contact.studentID}, Last Name: {contact.LastName}, First Name: {contact.FirstName}, Email: {contact.email}, ...");
        }
    }
}
