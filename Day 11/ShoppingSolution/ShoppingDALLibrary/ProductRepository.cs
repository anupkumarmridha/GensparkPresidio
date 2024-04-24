using ShoppingModelLibrary.Exceptions;
using ShoppingModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingDALLibrary
{
    public class ProductRepository : AbstractRepository<int, Product>
    {
        public override Product Add(Product item)
        {
            if (item == null) throw new ArgumentNullException("item");
            if (items.Any(p => p.Id == item.Id))
            {
                throw new ArgumentException("A product with the same ID already exists.");
            }
            items.Add(item);
            return item;
        }
        public override Product Delete(int key)
        {
            Product product = GetByKey(key);
            if (product != null)
            {
                items.Remove(product);
            }
            return product;
        }

        public override Product GetByKey(int key)
        {
            Product product = items.FirstOrDefault(p => p.Id == key);
            return product;
        }

        public override Product Update(Product item)
        {
            Product existingProduct = GetByKey(item.Id);
            if (existingProduct != null && existingProduct.Id != item.Id)
            {
                throw new ArgumentException("Cannot update product with a duplicate Id.");
            }

            Product product = GetByKey(item.Id);
            if (product != null)
            {
                product = item;
            }
            return product;
        }
    }
}
