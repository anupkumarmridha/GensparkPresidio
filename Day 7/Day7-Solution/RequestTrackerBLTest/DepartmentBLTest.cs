using RequestTrackerBLLibery;
using RequestTrackerDALLibery;
using RequestTrackerModelLibery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLTest
{
    internal class DepartmentBLTest
    {
        IRepository<int, Department> repository;
        IDepartmentService departmentService;
        [SetUp]
        public void Setup()
        {
            repository = new DepartmentRepository();
            Department department = new Department() { Name = "IT", Department_Head = 101 };
            repository.Add(department);
            departmentService = new DepartmentBL(repository);
        }

        [Test]
        public void GetDepartmnetByNameTest()
        {
            var department = departmentService.GetDepartmentByName("IT");
            Console.WriteLine(department.ToString());
            Assert.AreEqual(1, department.Id);
        }

        [Test]
        public void GetDepartmnetByNameExceptionTest()
        {
            //Action
            var exception = Assert.Throws<DepartmentNotFoundException>(() => departmentService.GetDepartmentByName("Admin"));
            //Assert
            Assert.AreEqual("No Department with such name", exception.Message);
        }
    }
}
