using ShoppingBLLibrary;
using ShoppingDALLibrary;
using ShoppingModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBLTest
{
    public class ProductServiceBLTest
    {
        private IProductService _productService;
        private IRepository<int, Product> _productRepository;

        [SetUp]
        public void Setup()
        {
            _productRepository = new ProductRepository();
            _productService = new ProductServiceBL(_productRepository);
        }

        [Test]
        public async Task AddProduct_Success()
        {
            // Arrange
            Product product = new Product { Id = 1, Name = "Laptop", Price = 100000, QuantityInHand=80 };

            Product addedProduct = await _productService.AddProduct(product);
            Assert.AreEqual(product, addedProduct);
        }

        [Test]
        public async Task AddProduct_NullProduct_Fails()
        {
            // Arrange
            Product product = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => _productService.AddProduct(product));
        }

        [Test]
        public async Task DeleteProduct_Success()
        {
            // Arrange
            int productId = 1;
            Product productToDelete = new Product { Id = 1, Name = "Laptop", Price = 100000, QuantityInHand = 80 };
            _productService.AddProduct(productToDelete);

            // Act
            Product deletedProduct = await _productService.DeleteProduct(productId);

            // Assert
            Assert.IsNotNull(deletedProduct);
            Assert.AreEqual(productToDelete, deletedProduct);
            List<Product> products = await _productService.GetAllProducts();
            Assert.IsFalse(products.Any(c => c.Id == productId));
        }

        [Test]
        public async Task DeleteProduct_NonExistingProductId_ReturnsException()
        {
            // Arrange
            int nonExistingProductId = 100;
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => _productService.DeleteProduct(nonExistingProductId));
            Assert.AreEqual($"Product with ID {nonExistingProductId} not found.", exception.Message);
        }

        [Test]
        public async Task GetAllProducts_ReturnsAllProducts()
        {
            // Arrange

            List<Product> products = new List<Product>
            {
                new Product {  Id = 1, Name = "Laptop", Price = 100000, QuantityInHand=80 },
                new Product {  Id = 2, Name = "Phone", Price = 100000, QuantityInHand=80 }
            };

            Product product1 = new Product { Id = 1, Name = "Laptop", Price = 100000, QuantityInHand = 80 };
            Product product2 = new Product { Id = 2, Name = "Phone", Price = 100000, QuantityInHand = 80 };

            _productService.AddProduct(product1);
            _productService.AddProduct(product2);


            List<Product> retrievedProducts = await _productService.GetAllProducts();

            // Assert
            CollectionAssert.AreEquivalent(products, retrievedProducts);
        }

        [Test]
        public async Task GetProductById_ExistingId_ReturnsProduct()
        {
            // Arrange
            int productId = 1;
            Product product = new Product { Id = 1, Name = "Laptop", Price = 100000, QuantityInHand = 80 };
            _productService.AddProduct(product);
            Product retrievedProduct = await _productService.GetProductById(productId);

            // Assert
            Assert.AreEqual(product, retrievedProduct);
        }

        [Test]
        public async Task GetProductById_NonExistingId_ReturnsNull()
        {
            // Arrange
            int nonExistingProductId = 100;
            Product retrievedProduct = await _productService.GetProductById(nonExistingProductId);

            // Assert
            Assert.IsNull(retrievedProduct);
        }

        [Test]
        public async Task UpdateProduct_Success()
        {
            // Arrange
            Product product = new Product { Id = 1, Name = "Laptop", Price = 100000, QuantityInHand = 80 };
            Product newProduct = await _productService.AddProduct(product);
            newProduct.Price = 800000;
            Product updatedProduct = await _productService.UpdateProduct(newProduct);

            // Assert
            Assert.AreEqual(newProduct, updatedProduct);
        }

        [Test]
        public async Task UpdateProduct_NullProduct_Fails()
        {
            // Arrange
            Product product = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(async() =>await _productService.UpdateProduct(product));
        }

        [Test]
        public async Task UpdateProduct_NonExistingId_Fails()
        {
            // Arrange
            Product product = new Product { Id = 1, Name = "Laptop", Price = 100000, QuantityInHand = 80 };
            Product updatedProduct = await _productService.UpdateProduct(product);

            // Assert
            Assert.IsNull(updatedProduct);
        }

        [Test]
        public async Task AddProduct_DuplicateId_Fails()
        {
            // Arrange
            Product existingProduct = new Product { Id = 1, Name = "Laptop", Price = 100000, QuantityInHand = 80 };
            Product duplicateProduct = new Product { Id = 1, Name = "Laptop", Price = 100000, QuantityInHand = 80 };
            _productService.AddProduct(existingProduct);
            // Assert
            Assert.Throws<ArgumentException>(async () => await _productService.AddProduct(duplicateProduct));
        }

        [Test]
        public async Task GetAllProducts_EmptyRepository_ReturnsEmptyList()
        {
            // Arrange
            List<Product> emptyList = new List<Product>();
            List<Product> retrievedProducts = await _productService.GetAllProducts();

            // Assert
            CollectionAssert.IsEmpty(retrievedProducts);
        }

        [Test]
        public async Task UpdateProduct_EmptyRepository_ReturnsNull()
        {
            // Arrange
            Product product = new Product { Id = 1, Name = "Laptop", Price = 100000, QuantityInHand = 80 };
            Product updatedProduct = await _productService.UpdateProduct(product);

            // Assert
            Assert.IsNull(updatedProduct);
        }
    }
}
