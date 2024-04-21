using EmployeeManagementDALLibery.Interfaces;
using EmployeeManagmentModelLibery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementDALLibery.Repositories
{
    public class DepartmentRepository : BaseRepository<DepartmentModel>, IDepartmentRepository
    {
        public DepartmentModel GetDepartmentByName(string departmentName)
        {
            foreach (var department in _data.Values)
            {
                if (department.Name == departmentName)
                {
                    return department;
                }
            }

            return null; // Department not found
        }

    }
}
