using RequestTrackerDALLibery;
using RequestTrackerModelLibery;

namespace RequestTrackerBLLibery
{
    public class DepartmentBL
    {
        readonly IRepository<int, Department> _departmentRepository;
        public DepartmentBL()
        {
            _departmentRepository = new DepartmentRepository();
        }
    }
}
