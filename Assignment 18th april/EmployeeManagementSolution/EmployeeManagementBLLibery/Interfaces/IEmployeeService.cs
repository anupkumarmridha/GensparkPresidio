using EmployeeManagmentModelLibery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementBLLibery.Interfaces
{
    public interface IEmployeeService
    {
        EmployeeModel GetEmployeeById(int employeeId);
        EmployeeModel AddEmployee(EmployeeModel employee);
        EmployeeModel UpdateEmployee(EmployeeModel employee);
        bool DeleteEmployee(int employeeId);
        List<EmployeeModel> GetAllEmployees();
        List<EmployeeModel> GetEmployeesByDepartment(string departmentName);
    }
}
