using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingModelLibrary.Exceptions
{
    public class CartNotFoundException:Exception
    {
        string message;
        public CartNotFoundException(int _cartId)
        {
            this.message = $"No Cart found with this {_cartId} Id.";
        }
    }
}
