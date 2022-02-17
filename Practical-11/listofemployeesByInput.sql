DROP PROCEDURE If EXISTS listofemployeesByInput
GO
CREATE PROCEDURE listofemployeesByInput
(
	@DesignationId int
)
As
BEGIN;
SELECT       dbo.Employees.Id, dbo.Employees.first_name, dbo.Employees.middle_name, dbo.Employees.last_name, dbo.Employees.dob, dbo.Employees.mobile_number, dbo.Employees.salary, dbo.Employees.address_, dbo.Designation.Designation
FROM            dbo.Designation INNER JOIN
                         dbo.Employees ON dbo.Designation.Id = dbo.Employees.DesignationId
WHERE        (dbo.Employees.DesignationId = @DesignationId) Order by dbo.Employees.first_name

END;
