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

        public Product AddProduct(Product product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));

            if (_productRepository.GetAll().Any(c => c.Id == product.Id))
            {
                throw new ArgumentException("A Product with the same ID already exists.", nameof(product));
            }

            return _productRepository.Add(product);
        }

        public Product DeleteProduct(int productId)
        {
            Product deletedProduct = _productRepository.Delete(productId);

            if (deletedProduct == null)
            {
                throw new InvalidOperationException($"Product with ID {productId} not found.");
            }

            return deletedProduct;
        }

        public List<Product> GetAllProducts()
        {
            return _productRepository.GetAll().ToList();
        }

        public Product GetProductById(int productId)
        {
            return _productRepository.GetByKey(productId);
        }

        public Product UpdateProduct(Product product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));
            return _productRepository.Update(product);
        }
    }
}
