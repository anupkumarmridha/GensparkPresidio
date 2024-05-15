using PizzaHutAPI.Models.DB_Models;

namespace PizzaHutAPI.Repositories.Interfaces
{
    public interface ICustomerRepository : IRepository<int, Customer>
    {
        Task<Customer> GetCustomerByEmail(string email);
    }
}
