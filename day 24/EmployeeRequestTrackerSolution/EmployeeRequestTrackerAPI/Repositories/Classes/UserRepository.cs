using EmployeeRequestTrackerAPI.Contexts;
using EmployeeRequestTrackerAPI.Models.DBModels;
using EmployeeRequestTrackerAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EmployeeRequestTrackerAPI.Repositories.Classes
{
    public class UserRepository : IUserRepository
    {
        private RequestTrackerContext _context;

        public UserRepository(RequestTrackerContext context)
        {
            _context = context;
        }
        public async Task<User> Add(User item)
        {
            item.Status = "Disabled";
            _context.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<User> DeleteByKey(int key)
        {
            var user = await GetByKey(key);
            if (user != null)
            {
                _context.Remove(user);
                await _context.SaveChangesAsync();
                return user;
            }
            throw new Exception("No user with the given ID");
        }

        public async Task<User> GetByKey(int key)
        {
            return (await _context.Users.SingleOrDefaultAsync(u => u.EmployeeId == key)) ?? throw new Exception("No user with the given ID");
        }

        public async Task<IList<User>> GetAll()
        {
            return (await _context.Users.ToListAsync());
        }

        public async Task<User> Update(User item)
        {
            var user = await GetByKey(item.EmployeeId);
            if (user != null)
            {
                _context.Update(item);
                await _context.SaveChangesAsync();
                return user;
            }
            throw new Exception("No user with the given ID");
        }

        public async Task<User> GetUserByEmail(string email)
        {
            var user = await _context.Users.Include(u => u.Employee)
                 .FirstOrDefaultAsync(u => u.Employee.Email == email);
            return user;
        }
    }
}
