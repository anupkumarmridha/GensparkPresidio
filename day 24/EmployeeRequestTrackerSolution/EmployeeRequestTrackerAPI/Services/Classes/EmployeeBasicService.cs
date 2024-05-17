using EmployeeRequestTrackerAPI.Models.DBModels;
using EmployeeRequestTrackerAPI.Repositories.Interfaces;
using EmployeeRequestTrackerAPI.Services.Interfaces;

namespace EmployeeRequestTrackerAPI.Services.Classes
{
    public class EmployeeBasicService : IEmployeeService
    {
        private readonly IEmployeeRepository _repository;

        public EmployeeBasicService(IEmployeeRepository reposiroty)
        {
            _repository = reposiroty;
        }
        public async Task<Employee> GetEmployeeByPhone(string phoneNumber)
        {
            var employee = (await _repository.GetAll()).FirstOrDefault(e => e.Phone == phoneNumber);
            if (employee == null)
                throw new Exception("No employee found with the given phone number");
            return employee;

        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            var employees = await _repository.GetAll();
            if (employees.Count() == 0)
                throw new Exception("No employees found");
            return employees;
        }

        public async Task<Employee> UpdateEmployeePhone(int id, string phoneNumber)
        {
            var employee = await _repository.GetByKey(id);
            if (employee == null)
                throw new Exception("No employee found with the given id");
            employee.Phone = phoneNumber;
            employee = await _repository.Update(employee);
            return employee;
        }
    }
}
