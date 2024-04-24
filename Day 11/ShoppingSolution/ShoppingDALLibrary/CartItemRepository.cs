using ShoppingModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingDALLibrary
{
    public class CartItemRepository : AbstractRepository<int, CartItem>
    {
        public override CartItem Delete(int key)
        {
            throw new NotImplementedException();
        }

        public override CartItem GetByKey(int key)
        {
            throw new NotImplementedException();
        }

        public override CartItem Update(CartItem item)
        {
            throw new NotImplementedException();
        }
    }
}
