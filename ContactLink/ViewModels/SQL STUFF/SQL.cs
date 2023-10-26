using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Markup;

/* namespace ContactLink.ViewModels.NewFolder
{

    internal class SQL
    {
    }
}

*/

/*
CREATE TABLE Student (
    SID int,
    LastName varchar(255),
    FirstName varchar(255),
    Address varchar(255),
    City varchar(255),

 

      Email varchar(255),     PRIMARY KEY(SID)


);

CREATE TABLE Advisor (
    AID int,
    LastName varchar(255),
    FirstName varchar(255),
    Address varchar(255),
    City varchar(255),
      Email varchar(255),     PRIMARY KEY(AID)


);

-----------------------------------------------------





CREATE TABLE StudentAdvisor(
    AID int,
SID int
PRIMARY KEY (SID, AID)




);



--Sample data for the Student table
INSERT INTO Student (SID, LastName, FirstName, Address, City, Email)
VALUES
    (1, 'Doe', 'John', '123 Main St', 'Anytown', 'john.doe@example.com'),
    (2, 'Smith', 'Jane', '456 Elm St', 'Othertown', 'jane.smith@example.com'),
    (3, 'Johnson', 'Mark', '789 Oak St', 'Sometown', 'mark.johnson@example.com'),
    (4, 'Wilson', 'Sarah', '101 Pine St', 'Cityville', 'sarah.wilson@example.com'),
    (5, 'Brown', 'Emily', '555 Cedar St', 'Yourtown', 'emily.brown@example.com');



--Sample data for the Advisor table
INSERT INTO Advisor (AID, LastName, FirstName, Address, City, Email)
VALUES
    (1, 'Lewis', 'Michael', '222 Birch St', 'Theirtown', 'michael.lewis@example.com'),
    (2, 'Williams', 'Chris', '333 Maple St', 'Anothertown', 'chris.williams@example.com'),
    (3, 'Anderson', 'Alice', '444 Willow St', 'Elsewhere', 'alice.anderson@example.com'),
    (4, 'Davis', 'David', '888 Redwood St', 'Somewhere', 'david.davis@example.com');



--Sample data for the StudentAdvisor table
INSERT INTO StudentAdvisor (AID, SID)
VALUES
    (1, 1),
    (2, 4),
    (3, 3),
    (4, 2),
    (4, 5);




select* from student where sid in (1,4)
select* from advisor
select * from advisor where aid=4
select * from studentAdvisor where aid =3
select
studentAdvisor.*,
A.lastname,
B.lastname
from
studentAdvisor
inner join  student A on studentAdvisor.SID = A.SID
inner join advisor B on studentAdvisor.AID = B.AID

*/


