using Microsoft.EntityFrameworkCore;
using ApparelShoppingAppAPI.Contexts;
using ApparelShoppingAppAPI.Models.DB_Models;
using ApparelShoppingAppAPI.Repositories.Interfaces;

namespace ApparelShoppingAppAPI.Repositories.Classes
{
    public class CustomerRepository:BaseRepository<int, Customer>, ICustomerRepository
    {
        public CustomerRepository(ShoppingAppDbContext context) : base(context)
        {
        }

        public override async Task<Customer> GetById(int id)
        {
            var customer = await _context.Customers
                .Include(c => c.Carts)
                .Include(c => c.Orders)
                .FirstOrDefaultAsync(c => c.Id == id);
            return customer;
        }

        public override async Task<IEnumerable<Customer>> GetAll()
        {
            var customers = await _context.Customers
                .Include(c => c.Carts)
                .Include(c => c.Orders)
                .ToListAsync();

            return customers;
        }

        public async Task<Customer> GetCustomerByEmail(string email)
        {
            var customer = await _context.Customers
                .Include(c => c.Carts)
                .Include(c => c.Orders)
                .FirstOrDefaultAsync(c => c.Email == email);
            return customer;
        }
    }
}
