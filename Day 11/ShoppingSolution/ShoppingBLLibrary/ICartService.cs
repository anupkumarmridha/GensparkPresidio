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
        public Cart AddProductToCart(int customerId, int productId, int quantity);
        Cart UpdateCartItemQuantity(int cartId, int productId, int newQuantity);
        Cart RemoveProductFromCart(int cartId, int productId);
        Cart GetCartById(int cartId);
        List<Cart> GetAllCarts();

    }
}
