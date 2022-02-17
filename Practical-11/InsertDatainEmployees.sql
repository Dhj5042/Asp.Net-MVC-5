CREATE PROCEDURE InsertDatainEmployees
(
	@first_name varchar(50),
	@middle_name varchar(50),
    @last_name varchar(50),
	@dob date,
	@mobile_number varchar(10),
	@address_ varchar(100),
	@salary decimal(18, 2),
	@DesignationId int
)
As
BEGIN;

insert into Employees Values(@first_name,@middle_name,@last_name,@dob,@mobile_number,@address_,@salary,@DesignationId);

END;