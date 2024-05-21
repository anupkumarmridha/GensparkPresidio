using ApparelShoppingAppAPI.Contexts;
using ApparelShoppingAppAPI.Models.DB_Models;
using ApparelShoppingAppAPI.Models.DTO_Models;
using ApparelShoppingAppAPI.Repositories.Interfaces;

namespace ApparelShoppingAppAPI.Repositories.Classes
{
    public class UserRegisterRepository : IUserRegisterRepository
    {
        private readonly ShoppingAppDbContext _context;

        public UserRegisterRepository(ShoppingAppDbContext context)
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
