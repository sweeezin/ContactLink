// See https://aka.ms/new-console-template for more information
using ContactLinkDBAccess;
Console.WriteLine("-- Start to show student info:");

Student.DisplayStudent();
CLOG.DisplayCLOG();
CLOG.UpdateServer(14, "Garside", "James", "email", "number", "profession", "role", "organization", "mentorExperience", "recievedFrom", "2022-11-11");
CLOG.DisplayCLOG();

Console.WriteLine("That's all");

