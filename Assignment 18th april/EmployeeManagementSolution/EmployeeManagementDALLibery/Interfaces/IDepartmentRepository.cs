using EmployeeManagmentModelLibery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementDALLibery.Interfaces
{
    public interface IDepartmentRepository : IRepository<DepartmentModel>
    {
        DepartmentModel GetDepartmentByName(string departmentName);

    }
}
