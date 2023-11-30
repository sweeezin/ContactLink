// See https://aka.ms/new-console-template for more information
using ContactLinkDBAccess;
Console.WriteLine("-- Start to show student info:");

Student.DisplayStudent();
CLOG.DisplayCLOG();
CLOG.UpdateStudent(1, "Garside", "James", "email", "number", "profession", "mmm", "mmm", "mmm", "mmm", "2022-11-11");
CLOG.DisplayCLOG();

Console.WriteLine("That's all");

