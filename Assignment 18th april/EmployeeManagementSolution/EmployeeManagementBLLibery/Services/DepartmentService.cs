using EmployeeManagementBLLibery.Interfaces;
using EmployeeManagementDALLibery.Interfaces;
using EmployeeManagmentModelLibery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementBLLibery.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public DepartmentModel AddDepartment(DepartmentModel department)
        {
            DepartmentModel savedDepartment = _departmentRepository.Add(department);
            return savedDepartment;
        }

        public bool DeleteDepartment(string departmentName)
        {
            var department = _departmentRepository.GetDepartmentByName(departmentName);
            if (department != null)
            {
                bool isSuccess = _departmentRepository.Delete(department.Id);
                return isSuccess;
            }
            return false;
        }

        public DepartmentModel GetDepartmentByName(string departmentName)
        {
            return _departmentRepository.GetDepartmentByName(departmentName);
        }

        public DepartmentModel UpdateDepartment(DepartmentModel department)
        {
            return _departmentRepository.Update(department);
        }

        public List<DepartmentModel> GetAllDepartments()
        {
            return _departmentRepository.GetAll();
        }

        public DepartmentModel GetDepartmentById(int department_id)
        {
            return _departmentRepository.GetById(department_id);
        }
    }
}
