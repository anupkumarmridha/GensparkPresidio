using EmployeeRequestTrackerAPI.Contexts;
using EmployeeRequestTrackerAPI.Models.DBModels;
using EmployeeRequestTrackerAPI.Repositories.Classes;
using EmployeeRequestTrackerAPI.Repositories.Interfaces;
using EmployeeRequestTrackerAPI.Services.Classes;
using EmployeeRequestTrackerAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerTest
{
     public class EmployeeRepositoryTest
    {
        RequestTrackerContext context;
        [SetUp]
        public void Setup()
        {
            DbContextOptionsBuilder optionsBuilder = new DbContextOptionsBuilder().UseInMemoryDatabase("dummyDB");
            context = new RequestTrackerContext(optionsBuilder.Options);
                                                    
        }
        [Test]
        public void GetEmployeeTest() 
        {
            //Arrange
            IEmployeeRepository employeeRepo = new EmployeeRepository(context);
            employeeRepo.Add(new Employee {
                Id = 101,
                Name = "Test1",
                DateOfBirth = new DateTime(2002, 12, 12),
                Phone = "9988776655",
                Role = "Admin",
                Image = ""
            });
            IEmployeeService employeeService = new EmployeeBasicService(employeeRepo);

            //Action
            var result = employeeService.GetEmployeeByPhone("9988776655");

            //Assert
            //Assert.IsNotNull(result);
            Assert.That(result, Is.Not.Null);

        }
    }
}
