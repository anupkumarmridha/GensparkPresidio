using Microsoft.EntityFrameworkCore;
using PizzaHutAPI.Contexts;
using PizzaHutAPI.Models.DB_Models;
using PizzaHutAPI.Repositories.Interfaces;

namespace PizzaHutAPI.Repositories.Classes
{
    public class UserRepository: BaseRepository<int, User>, IUserRepository
    {
        public UserRepository(PizzaHutDbContext context) : base(context)
        {
        }

        public async Task<User> GetUserByEmail(string email)
        {
            var user = await _context.Users
                 .Include(u => u.Customer)
                 .FirstOrDefaultAsync(u => u.Customer.Email == email);
            return user;
        }
    }
}
