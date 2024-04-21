using EmployeeManagmentModelLibery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementDALLibery.Interfaces
{
    public interface IEmployeeRepository : IRepository<EmployeeModel>
    {
        List<EmployeeModel> GetEmployeesByDepartment(string departmentName);
    }
}
