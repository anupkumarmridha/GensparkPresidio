using Microsoft.EntityFrameworkCore;
using ApparelShoppingAppAPI.Contexts;
using ApparelShoppingAppAPI.Models.DB_Models;
using ApparelShoppingAppAPI.Repositories.Interfaces;

namespace ApparelShoppingAppAPI.Repositories.Classes
{
    public class UserRepository: BaseRepository<int, User>, IUserRepository
    {
        public UserRepository(ShoppingAppDbContext context) : base(context)
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
