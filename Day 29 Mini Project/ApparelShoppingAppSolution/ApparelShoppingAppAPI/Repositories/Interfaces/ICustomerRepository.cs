using ApparelShoppingAppAPI.Models.DB_Models;

namespace ApparelShoppingAppAPI.Repositories.Interfaces
{
    public interface ICustomerRepository : IRepository<int, Customer>
    {
        Task<Customer> GetCustomerByEmail(string email);
    }
}
