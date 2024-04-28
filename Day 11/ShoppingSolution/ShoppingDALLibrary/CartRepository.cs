using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingDALLibrary
{
    public class CartRepository : AbstractRepository<int, Cart>
    {
        public override async Task<Cart> Add(Cart item)
        {
            if (item == null) throw new ArgumentNullException("item");
            if (items.Any(p => p.Id == item.Id))
            {
                throw new ArgumentException("A Cart with the same ID already exists.");
            }
            item.Id = items.Count + 1;
            items.Add(item);
            return await Task.FromResult(item);
        }
        public override async Task<Cart> Delete(int key)
        {
            try
            {
                Cart cart = await GetByKey(key);
            
                if (cart == null) {
                    throw new CartNotFoundException(key);
                }
                if (cart != null)
                {
                    items.Remove(cart);
                }
                return cart;
            }
            catch (CartNotFoundException)
            {
               throw new CartNotFoundException(key);
            }
        }

        public override async Task<Cart> GetByKey(int key)
        {
            Cart cart = items.FirstOrDefault(c => c.Id == key);
            if (cart == null)
            {
                throw new CartNotFoundException(key);
            }
            return cart;
        }

        public override async Task<List<Cart>> GetAll()
        {
            return await Task.FromResult(items.ToList());
        }

        public override async Task<Cart> Update(Cart item)
        {
            try
            {
                Cart existingCart = await GetByKey(item.Id);

                if (existingCart != null)
                {
                    // Find the index of the existing cart in the items list
                    int index = items.FindIndex(cart => cart.Id == existingCart.Id);
                    if (index != -1)
                    {
                        items[index] = item;
                        return item;
                    }
                }

                throw new CartNotFoundException(item.Id);
            }
            catch (CartNotFoundException)
            {
                throw new CartNotFoundException(item.Id);
            }
        }
    }
}
