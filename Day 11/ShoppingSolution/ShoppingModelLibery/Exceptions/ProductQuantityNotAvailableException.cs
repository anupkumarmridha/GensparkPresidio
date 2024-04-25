using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingModelLibrary.Exceptions
{
    public class ProductQuantityNotAvailableException : Exception
    {
        string message;
        public ProductQuantityNotAvailableException() {
            message = $"Not enough quantity available for product";
        }
        public ProductQuantityNotAvailableException(string _productName, int _quantityInHand) {
            message = $"Not enough quantity available for {_productName} \n available quantity = {_quantityInHand}";
        }
    }
}
