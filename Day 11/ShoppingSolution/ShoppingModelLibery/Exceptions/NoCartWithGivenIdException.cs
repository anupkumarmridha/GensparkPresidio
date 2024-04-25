using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingModelLibrary.Exceptions
{
    public class NoCartWithGivenIdException: Exception
    {
        public int CartId { get; set; }
        public NoCartWithGivenIdException(int cartId)
        {
            CartId = cartId;
        }
        public override string Message => $"No cart with the given ID {CartId} was found.";
    }
}
