// See https://aka.ms/new-console-template for more information
using ContactLinkDBAccess;

Console.WriteLine("-- Start to show student info:");

Student.DisplayStudent();
CLOGManager.DisplayCLOG();
CLOG clog = new("lastName", "firstName", "email", "number", "profession", "role", "organization", "mentorExp", "receivedFrom", DateTime.Now);
var newId = CLOGManager.InsertNewCLOG(clog);
CLOGManager.DisplayCLOG();
CLOGManager.DeleteCLOG(newId);
CLOGManager.DisplayCLOG();

Console.WriteLine("That's all");

