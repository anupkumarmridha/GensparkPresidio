using EmployeeManagementBLLibery.Interfaces;
using EmployeeManagementDALLibery.Interfaces;
using EmployeeManagmentModelLibery;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementBLLibery.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public EmployeeModel AddEmployee(EmployeeModel employee)
        {
            if (string.IsNullOrEmpty(employee.Name) || string.IsNullOrEmpty(employee.Department) || employee.Salary <= 0)
            {
                throw new ValidationException("Employee details are invalid.");
            }
            return _employeeRepository.Add(employee);
        }

        public bool DeleteEmployee(int employeeId)
        {
            EmployeeModel employee= _employeeRepository.GetById(employeeId);
            if (employee == null)
            {
                throw new KeyNotFoundException($"Employee with ID {employeeId} not found.");
            }
            return _employeeRepository.Delete(employeeId);
        }

        public EmployeeModel GetEmployeeById(int employeeId)
        {
            return _employeeRepository.GetById(employeeId);
        }

        public EmployeeModel UpdateEmployee(EmployeeModel employee)
        {
            return _employeeRepository.Update(employee);
        }

        public List<EmployeeModel> GetAllEmployees()
        {
              return _employeeRepository.GetAll();
        }

        public List<EmployeeModel> GetEmployeesByDepartment(string departmentName)
        {
            return _employeeRepository.GetEmployeesByDepartment(departmentName);
        }
    }
}
