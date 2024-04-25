using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingModelLibrary.Exceptions
{
    public class NoProductWithGiveIdException:Exception
    {

        string message;
        public NoProductWithGiveIdException()
        {
            message = "Product with the given Id is not present";
        }public NoProductWithGiveIdException(int _productId)
        {
            message = $"Product with the {_productId} Id is not present";
        }
        public override string Message => message;
    }
}
