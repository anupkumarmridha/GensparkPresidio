using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingModelLibrary.Exceptions
{
    public class MaxQuantityExceededException:Exception
    {
        string message;
        public MaxQuantityExceededException()
        {
            message = "More than 5 products are not allowed";
        }
        public MaxQuantityExceededException(int productId)
        {
            message = "More than 5 products are not allowed";
        }
    }
}
