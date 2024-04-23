using RequestTrackerDALLibery;
using RequestTrackerModelLibery;

namespace RequestTrackerTest
{
    public class DepartmentRepositoryTests
    {
        IRepository<int, Department> repository;
        [SetUp]
        public void Setup()
        {
            repository = new DepartmentRepository();
        }

        [Test]
        public void AddSuccessTest()
        {
            //Arrange 
            Department department = new Department() { Name = "IT", Department_Head = 101 };
            //Action
            var result = repository.Add(department);
            //Console.WriteLine(result.ToString());
            //Assert
            Assert.AreEqual(1, result.Id);
        }

        [Test]
        public void GetAllDepartment()
        {
            //Arrange 
            Department department = new Department() { Name = "IT", Department_Head = 101 };
            repository.Add(department);
            
            Department department1 = new Department() { Name = "CSE", Department_Head = 102 };
            repository.Add(department1);

            var result = repository.GetAll();
            //Console.WriteLine(result.Count);
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
        }

        [TestCase(1, "Hr", 101)]
        //[TestCase(2, "Admin", 101)]
        public void GetPassTest(int id, string name, int hid)
        {
            // Arrange 
            Department department = new Department() { Name = name, Department_Head = hid };
            repository.Add(department);

            // Action
            var result = repository.Get(id);

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void AddFailTest()
        {
            //Arrange 
            Department department = new Department() { Name = "IT", Department_Head = 101 };
            repository.Add(department);
            department = new Department() { Name = "IT", Department_Head = 102 };
            //Action
            var result = repository.Add(department);
            //Assert
            Assert.IsNull(result);
        }
    }
}