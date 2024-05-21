using ApparelShoppingAppAPI.Models.DB_Models;

namespace ApparelShoppingAppAPI.Repositories.Interfaces
{
    public interface IProductRepository:IRepository<int, Product>
    {
        public Task<Product> GetProductByName(string name);
    }
}
