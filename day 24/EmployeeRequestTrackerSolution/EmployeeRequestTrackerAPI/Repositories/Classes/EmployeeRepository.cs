using EmployeeRequestTrackerAPI.Contexts;
using EmployeeRequestTrackerAPI.Models.DBModels;
using EmployeeRequestTrackerAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EmployeeRequestTrackerAPI.Repositories.Classes
{
    public class EmployeeRepository : IEmployeeRepository
    {
        protected readonly RequestTrackerContext _context;

        public EmployeeRepository(RequestTrackerContext context)
        {
            _context = context;
        }
        public async Task<Employee> Add(Employee entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Employee> DeleteByKey(int key)
        {
            var employee = await GetByKey(key);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();
            }
            return employee;
        }

        public virtual async Task<Employee> GetByKey(int key)
        {
            var employee = _context.Employees.SingleOrDefault(e => e.Id == key);
            return employee;
        }

        public virtual async Task<IList<Employee>> GetAll()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee> Update(Employee entity)
        {
            var employee = await GetByKey(entity.Id);
            if (employee != null)
            {
                _context.Entry<Employee>(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            return entity;
        }

        public async Task<Employee> GetEmployeeByEmail(string email)
        {
           return await _context.Employees.SingleOrDefaultAsync(e => e.Email == email);
        }
    }
}
