CREATE PROCEDURE InsertDatainDesignation
(
@Designation varchar(50)
)
As
BEGIN;

insert into Designation Values(@Designation);

END;