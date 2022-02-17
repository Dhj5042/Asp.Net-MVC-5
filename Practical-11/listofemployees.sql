DROP PROCEDURE If EXISTS listofemployees
GO
CREATE PROCEDURE listofemployees
As
BEGIN;

select e.id,e.first_name,e.middle_name,e.last_name,d.Designation,e.dob,e.mobile_number,e.address_,e.salary from Employees as e,Designation as d where d.Id=e.DesignationId Order by e.dob;
END;