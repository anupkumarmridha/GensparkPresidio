use dbEmployeeTracker

select * from EmployeeSkill

select * from Employees

--Update 
update Employees set phone = '9876543210'
where id = 101
update Employees set phone = '9988776655'
where id = 105


Insert into EmployeeSkill values(105,2,7)
Insert into EmployeeSkill values(105,3,7)

update EmployeeSkill set skillLevel = 8
where skill = 2 and Employee_id = 101


-- Update the skill level to 5 if it is 7 and to 9 if it is 8 otherwise leave it as it is
update EmployeeSkill set skillLevel = case 
				when skillLevel= 7 then 5
				when skillLevel = 8 then 9
				else skillLevel
				end
where Employee_id = 101

Delete from EmployeeSkill where Employee_id = 105


select * from areas

delete from Areas where area = 'DDDD'