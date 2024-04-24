using ShoppingModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingDALLibrary
{
    public class CartRepository : AbstractRepository<int, Cart>
    {
        public override Cart Add(Cart item)
        {
            if (item == null) throw new ArgumentNullException("item");
            if (items.Any(p => p.Id == item.Id))
            {
                throw new ArgumentException("A Cart with the same ID already exists.");
            }
            items.Add(item);
            return item;
        }
        public override Cart Delete(int key)
        {
            Cart cart = GetByKey(key);
            if (cart != null)
            {
                items.Remove(cart);
            }
            return cart;
        }

        public override Cart GetByKey(int key)
        {
            Cart cart = items.FirstOrDefault(c => c.Id == key);
            return cart;
        }

        public override Cart Update(Cart item)
        {
            Cart cart = GetByKey(item.Id);
            if (cart != null)
            {
                cart = item;
            }
            return cart;
        }
    }
}
