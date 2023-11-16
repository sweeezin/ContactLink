// See https://aka.ms/new-console-template for more information
using ContactLinkDBAccess;

Console.WriteLine("-- Start to show student info:");

Student.DisplayStudent();
CLOGManager.DisplayCLOG();
CLOG clog = new CLOG(12345555, "lastName", "firstName", "email", "number", "profession", "organization", "mentorExp", "receivedFrom", "lastContactedDate");
CLOGManager.InsertNewCLOG(clog);


Console.WriteLine("That's all");

