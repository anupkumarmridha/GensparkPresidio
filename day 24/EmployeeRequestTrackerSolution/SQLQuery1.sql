SELECT TOP (1000) [Id]
      ,[Name]
      ,[Email]
      ,[DateOfBirth]
      ,[Phone]
      ,[Image]
      ,[Role]
  FROM [dbRequestTracker14May24].[dbo].[Employees]

  delete from Employees;

  select * from users;

  update Employees set Role='Admin' where Id=4;