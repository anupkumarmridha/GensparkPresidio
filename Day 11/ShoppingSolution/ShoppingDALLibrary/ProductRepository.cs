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
        public override async Task<Product> Add(Product item)
        {
            if (item == null) throw new ArgumentNullException("item");
            if (items.Any(p => p.Id == item.Id))
            {
                throw new ArgumentException("A product with the same ID already exists.");
            }
            items.Add(item);
            return item;
        }
        public override async Task<Product> Delete(int key)
        {
            try
            {
                Product product = await GetByKey(key);
                if (product != null)
                {
                    items.Remove(product);
                }
                return product;
            }
            catch (NoProductWithGiveIdException)
            {
                throw new NoProductWithGiveIdException(key);
            }
        }

        public override async Task<Product> GetByKey(int key)
        {
            Product product = items.FirstOrDefault(p => p.Id == key);
            if (product == null)
            {
                throw new NoProductWithGiveIdException(key);
            }
            return product;
        }

        public override async Task<Product> Update(Product item)
        {
            if (item == null) throw new ArgumentNullException("item");
            try
            {
                Product existingProduct =await GetByKey(item.Id);
                if (existingProduct != null && existingProduct.Id != item.Id)
                {
                    throw new ArgumentException("Cannot update product with a duplicate Id.");
                }
                Product product = await GetByKey(item.Id);
                if (product != null)
                {
                    product = item;
                }
                return product;
            }
            catch (NoProductWithGiveIdException)
            {
                throw new NoProductWithGiveIdException(item.Id);
            }
        }
    }
}
