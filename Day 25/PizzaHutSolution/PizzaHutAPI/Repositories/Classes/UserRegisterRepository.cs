using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PizzaHutAPI.Contexts;
using PizzaHutAPI.Models.DB_Models;
using PizzaHutAPI.Models.DTO_Models;
using PizzaHutAPI.Repositories.Interfaces;

namespace PizzaHutAPI.Repositories.Classes
{
    public class UserRegisterRepository : IUserRegisterRepository
    {
        private readonly PizzaHutDbContext _context;

        public UserRegisterRepository(PizzaHutDbContext context)
        {
            _context = context;
        }
        public async Task<(Customer customer, User user)> AddUserWithTransaction(UserRegisterRepositoryDTO userRegisterDTO)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    var newCustomer = new Customer
                    {
                        Name = userRegisterDTO.Name,
                        Email = userRegisterDTO.Email
                    };
                    await _context.Customers.AddAsync(newCustomer);
                    await _context.SaveChangesAsync();
                    var newUser = new User
                   {
                       CustomerId = newCustomer.Id,
                       Password = userRegisterDTO.Password,
                       PasswordHashKey = userRegisterDTO.PasswordHashKey
                   };
                    _context.Users.Add(newUser);
                    await _context.SaveChangesAsync();

                    await transaction.CommitAsync();

                    return (newCustomer, newUser);
                }
                catch (Exception)
                {
                    await transaction.RollbackAsync();
                    throw new Exception("Error while adding user");
                }
            }
        }
    }
}
