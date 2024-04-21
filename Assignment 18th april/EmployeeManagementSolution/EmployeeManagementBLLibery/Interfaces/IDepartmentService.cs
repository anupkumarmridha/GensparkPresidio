using EmployeeManagmentModelLibery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementBLLibery.Interfaces
{
    public interface IDepartmentService
    {
        DepartmentModel GetDepartmentByName(string departmentName);
        DepartmentModel GetDepartmentById(int department_id);
        DepartmentModel AddDepartment(DepartmentModel department);
        DepartmentModel UpdateDepartment(DepartmentModel department);
        bool DeleteDepartment(string departmentName);
        List<DepartmentModel> GetAllDepartments();
    }
}
