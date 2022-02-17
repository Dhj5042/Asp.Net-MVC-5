--use Dbtest
use DbTest
Go

--Drop table
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
	CONSTRAINT PK PRIMARY KEY (Id)
);

--insert query
insert into Employees Values('Dhuvin','Hasmukhbhai','Jariwala','2000-05-23',9624063630,'9/622,WadiFaliya,Sidha mata ni street, Surat',50000);
insert into Employees Values('Karan','JitendraKumar','Jariwala','1999-08-30',8866629665,'6/665,Sangadiawad Gopipura, Surat',40000);
insert into Employees Values('Raju','Manojkumar','Kapadia','1999-04-11',8866629665,'2/85,Udhna Darwaja, Surat',30000);
insert into Employees Values('Divyesh','Dipakkumar','Jariwala','2000-06-26',9401435951,'B-25,Vijay Nagar Society, Surat',35000);
insert into Employees Values('Mayank','Hirenkumar','Jariwala','1999-10-11',9624063630,'8/662,Sagrampura,Surat',55000);
insert into Employees Values('Pratik','Nitinkumar','Jariwala','1999-01-26',8866629665,'6/665,Udhna, Gopipura, Surat',45000);
insert into Employees Values('Fenil','Ajaykumar','Damwala','1999-10-17',9624063630,'9/522,Sagrampura, Surat',25520);

--fetch all data
select * from Employees;

--SQL query to find the total amount of salaries
select Sum(salary)as TotalSalary from Employees;


--SQL query to find all employees having DOB less than 01-01-2000
--1	Dhuvin	Hasmukhbhai	Jariwala	2000-05-23	9624063630	9/622,WadiFaliya,Sidha mata ni street, Surat	50000.00
--4	Divyesh	Dipakkumar	Jariwala	2000-06-26	9401435951	B-25,Vijay Nagar Society, Surat	35000.00
select * from Employees where dob<'01-01-2000';

-- SQL query to count employees having Middle Name NULL
select * from Employees where middle_name=null;