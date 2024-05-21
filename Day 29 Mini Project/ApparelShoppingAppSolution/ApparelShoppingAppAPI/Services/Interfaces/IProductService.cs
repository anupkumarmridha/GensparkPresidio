using ApparelShoppingAppAPI.Models.DB_Models;
using ApparelShoppingAppAPI.Models.DTO_Models;

namespace ApparelShoppingAppAPI.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProducts();
        Task<Product> GetProductById(int id);
        Task<Product> GetProductByName(string name);
        Task<Product> AddProduct(ProductDTO product);
        Task<Product> UpdateProduct(int id, ProductDTO product);
        Task<Product> DeleteProduct(int id);
    }
}
