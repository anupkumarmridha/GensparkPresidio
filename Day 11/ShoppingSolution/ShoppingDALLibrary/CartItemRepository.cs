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
        public override CartItem Add(CartItem item)
        {
            if (item == null) throw new ArgumentNullException("item");
            if (item.Product == null)
            {
                throw new ArgumentException("Product cannot be null.");
            }

            return base.Add(item);
        }
        public override CartItem Delete(int key)
        {
            CartItem cartItem = GetByKey(key);
            if (cartItem != null)
            {
                items.Remove(cartItem);
            }
            return cartItem;
        }

        public override CartItem GetByKey(int key)
        {
            CartItem cartItem = items.FirstOrDefault(item => item.CartId == key);
            return cartItem;
        }

        public override CartItem Update(CartItem item)
        {
            CartItem cartItem = GetByKey(item.CartId);
            if (cartItem != null)
            {
                cartItem = item;
            }
            return cartItem;
        }
    }
}
