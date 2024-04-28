using ShoppingModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBLLibrary
{
    public interface IProductService
    {
        Task<Product> AddProduct(Product product);
        Task<Product> GetProductById(int productId);
        Task<List<Product>> GetAllProducts();
        Task<Product> UpdateProduct(Product product);
        Task<Product> DeleteProduct(int productId);
    }
}
