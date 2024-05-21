
using Microsoft.EntityFrameworkCore;
using ApparelShoppingAppAPI.Contexts;
using ApparelShoppingAppAPI.Models.DB_Models;
using ApparelShoppingAppAPI.Repositories.Interfaces;

namespace ApparelShoppingAppAPI.Repositories.Classes
{
    public class ProductRepository: BaseRepository<int, Product>, IProductRepository
    {
        public ProductRepository(ShoppingAppDbContext context) : base(context)
        {
        }

        public async Task<Product> GetProductByName(string name)
        {
            var product = await _context.Products
            .FirstOrDefaultAsync(p => p.Name.ToUpper() == name.ToUpper());
            if (product == null)
            {
                throw new InvalidOperationException($"{name} not found.");
            }
            return product;
        }
    }
}
