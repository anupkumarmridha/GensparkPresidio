using RequestTrackerModelLibery;

namespace RequestTrackerBLLibrary
{
    public interface IEmployeeLoginBL
    {
        public Task<Employee> Login(Employee employee);
        public Task<Employee> Register(Employee employee);
    }
}
