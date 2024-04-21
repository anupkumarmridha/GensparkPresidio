using EmployeeManagementDALLibery.Interfaces;
using EmployeeManagmentModelLibery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementDALLibery.Repositories
{
    public class EmployeeRepository : BaseRepository<EmployeeModel>, IEmployeeRepository
    {
        public List<EmployeeModel> GetEmployeesByDepartment(string departmentName)
        {
            List<EmployeeModel> employeesInDepartment = new List<EmployeeModel>();

            foreach (var employee in _data.Values)
            {
                if (employee.Department == departmentName)
                {
                    employeesInDepartment.Add(employee);
                }
            }

            return employeesInDepartment.ToList();
        }
    }
}
