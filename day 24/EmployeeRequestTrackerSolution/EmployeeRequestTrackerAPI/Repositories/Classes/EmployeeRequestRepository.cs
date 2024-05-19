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
            var employee = await _context.Employees.Include(e => e.RequestsRaised).SingleOrDefaultAsync(e => e.Id == key);
            if (employee == null)
            {
                throw new Exception("Employee not found");
            }
            return employee;
        }
    }
}
