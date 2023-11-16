// See https://aka.ms/new-console-template for more information
using ContactLinkDBAccess;

Console.WriteLine("-- Start to show student info:");

Student.DisplayStudent();
CLOGManager.DisplayCLOG();
CLOG clog = new CLOG(1, "lastName", "firstName", "email", "number", "profession", "role", "organization", "mentorExp", "receivedFrom", DateTime.Now);
CLOGManager.InsertNewCLOG(clog);
CLOGManager.DisplayCLOG();

Console.WriteLine("That's all");

