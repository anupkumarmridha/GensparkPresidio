using EmployeeRequestTrackerAPI.Contexts;
using EmployeeRequestTrackerAPI.Models.DBModels;
using Microsoft.EntityFrameworkCore;

namespace EmployeeRequestTrackerAPI.Repositories.Classes
{
    public class EmployeeRequestRepository : EmployeeRepository
    {
        public EmployeeRequestRepository(RequestTrackerContext context) : base(context)
        {
        }
        public async override Task<IList<Employee>> GetAll()
        {
            return await _context.Employees.Include(e => e.RequestsRaised).ToListAsync();
        }
        public async override Task<Employee> GetByKey(int key)
        {
            var employee = _context.Employees.Include(e => e.RequestsRaised).SingleOrDefault(e => e.Id == key);
            return employee;
        }
    }
}
