CREATE VIEW DesginView 
AS SELECT e.Id,e.first_name,e.middle_name,e.last_name,d.Designation,e.dob,e.mobile_number,e.salary,e.address_ FROM Employees as e,Designation as d where d.Id=e.DesignationId;
