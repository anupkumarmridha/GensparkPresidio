  sp_help Employees

 -- non cluster index can be created on null and not unique column
create index idxEmpEmail on Employees(email)

select * from employees where email like 'r%'

drop index idxEmpEmail on Employees


create procedure proc_FirstProcedure
as
begin
    print 'Hello'
end

execute proc_FirstProcedure

create proc proc_GreetWithName(@cname varchar(20))
as
begin
   print 'Hello '+@cname
end

exec proc_GreetWithName 'Ramu'

select * from Employees

create proc proc_AddEmployee(@ename varchar(10),@edob datetime,
@earea varchar(10), @ephone varchar(15), @eemail varchar(15))
as
begin
   insert into Employees(name,DateOfBirth,EmployeeArea,Phone,Email)
   values(@ename,@edob,@earea,@ephone,@eemail)
end

exec proc_AddEmployee 'Bimu','2000-09-07','HHHH','1122334455','bimu@gmail.com'


alter proc proc_GreetWithName(@cname varchar(20))
as
begin
   print 'Welcome '+@cname
end

exec proc_GreetWithName 'Ramu'

Create proc proc_PrintDetails(@cname varchar(20),@cage int,@cphone varchar(15))
as
begin
   print 'Welcome '+@cname + ' and you are '+@cage +'years old, Your phone is '+@cphone
end

alter  proc proc_PrintDetails(@cname varchar(20),@cage int,@cphone varchar(15))
as
begin
   print 'Welcome '+@cname + ' and you are '+cast(@cage as varchar(3))+'years old, Your phone is '+@cphone
end

proc_PrintDetails 'Ramu',23,'8877665544'