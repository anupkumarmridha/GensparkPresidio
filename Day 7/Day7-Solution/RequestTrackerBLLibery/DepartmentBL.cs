using RequestTrackerDALLibery;
using RequestTrackerModelLibery;

namespace RequestTrackerBLLibery
{
    public class DepartmentBL:IDepartmentService
    {
        readonly IRepository<int, Department> _departmentRepository;
        public DepartmentBL(IRepository<int, Department> departmentRepository)
        {
            //_departmentRepository = new DepartmentRepository();//Tight coupling
            _departmentRepository = departmentRepository;//Loose coupling
        }

        public int AddDepartment(Department department)
        {
            var result = _departmentRepository.Add(department);

            if (result != null)
            {
                return result.Id;
            }

            throw new DuplicateDepartmentNameException();
        }

        public Department ChangeDepartmentName(string departmentOldName, string departmentNewName)
        {

            throw new NotImplementedException();
        }

        public Department GetDepartmentById(int id)
        {
            throw new NotImplementedException();
        }

        public Department GetDepartmentByName(string departmentName)
        {
            var departments = _departmentRepository.GetAll();
            for (int i = 0; i < departments.Count; i++)
                if (departments[i].Name == departmentName)
                    return departments[i];
            throw new DepartmentNotFoundException();
        }

        public int GetDepartmentHeadId(int departmentId)
        {
            throw new NotImplementedException();
        }

        public List<Department> GetDepartmentList()
        {
            throw new NotImplementedException();
        }
    }
}
