--use Dbtest
use DbTest
Go
--Drop table if exist
Drop table Designation
--create new table
CREATE TABLE Designation (
    Id int IDENTITY(1,1) NOT NULL,
	Designation varchar(50),
	CONSTRAINT PK_d PRIMARY KEY (Id)
);

--Drop table if exist
Drop table Employees
--create new table
CREATE TABLE Employees (
    Id int IDENTITY(1,1) NOT NULL,
	first_name varchar(50),
	middle_name varchar(50),
    last_name varchar(50),
	dob date,
	mobile_number varchar(10),
	address_ varchar(100),
	salary decimal(18, 2),
	DesignationId int NOT NULL,
	CONSTRAINT PK_e PRIMARY KEY (Id),
	FOREIGN KEY(DesignationId) REFERENCES Designation(Id)
);

--check forign key is asign or not
Exec sp_help Employees;


--insert records in Designation tables
insert into Designation Values('Trainee Engineers');
insert into Designation Values('Software Engineers');
insert into Designation Values('Lead Software Engineers');

--fetch all records
select * from Designation;

--insert records in Employees
insert into Employees Values('Dhuvin','Hasmukhbhai','Jariwala','2000-05-23',9624063630,'9/622,WadiFaliya,Sidha mata ni street, Surat',50000,3);
insert into Employees Values('Karan','JitendraKumar','Jariwala','1999-08-30',8866629665,'6/665,Sangadiawad Gopipura, Surat',35000,1);
insert into Employees Values('Raju','Manojkumar','Kapadia','1999-04-11',8866629665,'2/85,Udhna Darwaja, Surat',36520,1);
insert into Employees Values('Divyesh','Dipakkumar','Jariwala','2000-06-26',9401435951,'B-25,Vijay Nagar Society, Surat',25000,2);
insert into Employees Values('Mayank','Hirenkumar','Jariwala','1999-10-11',9624063630,'8/662,Sagrampura,Surat',19000,2);
insert into Employees Values('Pratik','Nitinkumar','Jariwala','1999-01-26',8866629665,'6/665,Udhna, Gopipura, Surat',65000,3);
insert into Employees Values('Fenil','Ajaykumar','Damwala','1999-10-17',9624063630,'9/522,Sagrampura, Surat',10000,1);

--fetch all records
select * from Employees;

--query to count the number of records by designation name
select count(Designation) from Designation;

--query to display First Name, Middle Name, Last Name & Designation name
select e.first_name,e.middle_name,e.last_name,d.Designation from Employees as e,Designation as d where d.Id=e.DesignationId;

--database view that outputs Employee Id, First Name, Middle Name, Last Name, Designation, DOB, Mobile Number, Address & Salary
select * from DesginView;

--Create a stored procedure to insert data into the Designation table with required parameters
Exec InsertDatainDesignation 'Senior Software Enginer';
	--Record Inserted
	select * from Designation;
		--1	Trainee Engineers
		--2 Software Engineers
		--3 Lead Software Engineers
		--4 Senior Software Enginer	

--Create a stored procedure to insert data into the Employee table with required parameters
Exec InsertDatainEmployees 'Yogesh','Pankajbhai','Bhanushali','1987-10-01',8866629541,'B-52, Ramnath socity,Vapi',10000,1;
	--Record Inserted
	select * from Employees;
	--1	Dhuvin	Hasmukhbhai	Jariwala	2000-05-23	9624063630	9/622,WadiFaliya,Sidha mata ni street, Surat	50000.00	3
	--2	Karan	JitendraKumar	Jariwala	1999-08-30	8866629665	6/665,Sangadiawad Gopipura, Surat	35000.00	1
	--3	Raju	Manojkumar	Kapadia	1999-04-11	8866629665	2/85,Udhna Darwaja, Surat	36520.00	1
	--4	Divyesh	Dipakkumar	Jariwala	2000-06-26	9401435951	B-25,Vijay Nagar Society, Surat	25000.00	2
	--5	Mayank	Hirenkumar	Jariwala	1999-10-11	9624063630	8/662,Sagrampura,Surat	19000.00	2
	--6	Pratik	Nitinkumar	Jariwala	1999-01-26	8866629665	6/665,Udhna, Gopipura, Surat	65000.00	3
	--7	Fenil	Ajaykumar	Damwala	1999-10-17	9624063630	9/522,Sagrampura, Surat	10000.00	1
	--new Record 8	Yogesh	Pankajbhai	Bhanushali	1987-10-01	8866629541	B-52, Ramnath socity,Vapi	10000.00	1

--query that displays only those designation names that have more than 1 employee
SELECT D.Designation FROM Designation D WHERE (SELECT COUNT(*)FROM Employees E WHERE E.DesignationId = D.id) > 1

--stored procedure that returns a list of employees with columns Employee Id, First Name, Middle Name, Last Name, Designation, DOB, Mobile Number, Address & Salary (records should be ordered by DOB)
Exec listofemployees;

--stored procedure that return a list of employees by designation id (Input) with columns Employee Id, First Name, Middle Name, Last Name, DOB, Mobile Number, Address & Salary (records should be ordered by First Name)
Exec listofemployeesByInput 1;

--Create Non-Clustered index on the DesignationId column of the Employee table
Create nonclustered index Xdesignation on Employees([DesignationID] DESC)
execute sp_helpindex Employees;

--Write a query to find the employee having maximum salary
select first_name,last_name,dob,mobile_number,address_,salary from Employees where salary =(select MAX(salary) from Employees)