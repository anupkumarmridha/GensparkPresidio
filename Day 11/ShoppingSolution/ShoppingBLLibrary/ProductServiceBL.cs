using ShoppingDALLibrary;
using ShoppingModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBLLibrary
{
    public class ProductServiceBL : IProductService
    {
        private readonly IRepository<int, Product> _productRepository;

        public ProductServiceBL(IRepository<int, Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public  async Task<Product> AddProduct(Product product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));

            List<Product> products = await _productRepository.GetAll();

            if (products.Any(c => c.Id == product.Id))
            {
                throw new ArgumentException("A Product with the same ID already exists.", nameof(product));
            }
            return await _productRepository.Add(product);
        }

        public async Task<Product> DeleteProduct(int productId)
        {
            Product deletedProduct = await _productRepository.Delete(productId);

            if (deletedProduct == null)
            {
                throw new InvalidOperationException($"Product with ID {productId} not found.");
            }

            return deletedProduct;
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return await _productRepository.GetAll();
        }

        public async Task<Product> GetProductById(int productId)
        {
            return await _productRepository.GetByKey(productId);
        }

        public async Task<Product> UpdateProduct(Product product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));
            return await _productRepository.Update(product);
        }
    }
}
