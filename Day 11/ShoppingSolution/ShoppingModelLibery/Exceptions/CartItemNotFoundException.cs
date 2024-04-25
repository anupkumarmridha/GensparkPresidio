using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingModelLibrary.Exceptions
{
    public class CartItemNotFoundException:Exception
    {
        string message;
        public CartItemNotFoundException(int _cartItemId)
        {
            message = $"CartItem not available with {_cartItemId} Id ";
        }
    }
}
