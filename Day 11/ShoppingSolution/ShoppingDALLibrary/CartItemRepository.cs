using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingDALLibrary
{
    public class CartItemRepository : AbstractRepository<int, CartItem>
    {
        public override async Task<CartItem> Add(CartItem item)
        {
            if (item == null) throw new ArgumentNullException("item");
            if (item.Product == null)
            {
                throw new ArgumentException("Product cannot be null.");
            }

            return await base.Add(item);
        }
        public override async Task<CartItem> Delete(int key)
        {
            CartItem cartItem = await GetByKey(key);
            if (cartItem != null)
            {
                items.Remove(cartItem);
            }

            return await Task.FromResult(cartItem);
        }

        public override async Task<CartItem> GetByKey(int key)
        {
            CartItem cartItem = items.FirstOrDefault(item => item.CartId == key);
            if (cartItem == null)
            {
                throw new CartItemNotFoundException(key);
            }
            return await Task.FromResult(cartItem);
        }

        public override async Task<CartItem> Update(CartItem item)
        {
            CartItem cartItem = await GetByKey(item.CartId);
            if (cartItem != null)
            {
                cartItem = item;
            }
            return await Task.FromResult(cartItem);
        }
    }
}
