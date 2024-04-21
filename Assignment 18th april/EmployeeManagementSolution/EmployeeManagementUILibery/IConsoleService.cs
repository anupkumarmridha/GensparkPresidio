using EmployeeManagementBLLibery.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementUILibery
{
    public interface IConsoleService
    {
        void DisplayEmployeeMenu();
        void DisplayDepartmentMenu();
        int GetValidIntegerInput(string prompt);
        string GetValidStringInput(string prompt);
        void AddEmployee(IEmployeeService employeeService);
        void UpdateEmployee(IEmployeeService employeeService);
        void DeleteEmployee(IEmployeeService employeeService);
        void GetEmployeeById(IEmployeeService employeeService);
        void GetAllEmployees(IEmployeeService employeeService);
        void AddDepartment(IDepartmentService departmentService);
        void UpdateDepartment(IDepartmentService departmentService);
        void DeleteDepartment(IDepartmentService departmentService);
        void GetDepartmentByName(IDepartmentService departmentService);
        void GetAllDepartments(IDepartmentService departmentService);
    }
}
