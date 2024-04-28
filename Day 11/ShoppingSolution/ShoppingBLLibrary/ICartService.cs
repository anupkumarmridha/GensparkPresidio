using ShoppingModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBLLibrary
{
    public interface ICartService
    {
        public Task<Cart> AddProductToCart(int customerId, int productId, int quantity);
        Task<Cart> UpdateCartItemQuantity(int cartId, int productId, int newQuantity);
        Task<Cart> RemoveProductFromCart(int cartId, int productId);
        Task<Cart> GetCartById(int cartId);
        Task<List<Cart>> GetAllCarts();

    }
}
