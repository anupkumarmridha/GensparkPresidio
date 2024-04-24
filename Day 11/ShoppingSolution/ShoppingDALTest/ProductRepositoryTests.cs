using ShoppingDALLibrary;
using ShoppingModelLibrary;

namespace ShoppingDALTest
{
    public class ProductRepositoryTests
    {
        private ProductRepository productRepository;

        [SetUp]
        public void Setup()
        {
            productRepository = new ProductRepository();
        }

        [Test]
        public void Add_Product_Success()
        {
            // Arrange
            Product product = new Product(1, 10.99, "Test Product", 5);

            // Act
            Product addedProduct = productRepository.Add(product);

            // Assert
            Assert.AreEqual(product, addedProduct);
            Assert.Contains(addedProduct, productRepository.GetAll().ToList());
        }

        [Test]
        public void Add_Product_Null_Fails()
        {
            // Arrange
            Product product = null;

            // Act & Assert
            Assert.That(() => productRepository.Add(product), Throws.ArgumentNullException);
        }

        [Test]
        public void GetByKey_Existing_Product_Returns_Product()
        {
            // Arrange
            Product productToAdd = new Product(1, 10.99, "Test Product", 5);
            productRepository.Add(productToAdd);

            // Act
            Product retrievedProduct = productRepository.GetByKey(1);

            // Assert
            Assert.AreEqual(productToAdd, retrievedProduct);
        }

        [Test]
        public void GetByKey_NonExisting_Product_Returns_Null()
        {
            // Act
            Product retrievedProduct = productRepository.GetByKey(100);

            // Assert
            Assert.IsNull(retrievedProduct);
        }

        [Test]
        public void Update_Existing_Product_Success()
        {
            // Arrange
            Product productToAdd = new Product(1, 10.99, "Test Product", 5);
            productRepository.Add(productToAdd);

            Product updatedProduct = new Product(1, 15.99, "Updated Product", 10);

            // Act
            Product updatedProductResult = productRepository.Update(updatedProduct);

            // Assert
            Assert.AreEqual(updatedProduct, updatedProductResult);
            Assert.Contains(updatedProduct, productRepository.GetAll().ToList());
        }

        [Test]
        public void Update_NonExisting_Product_Returns_Null()
        {
            // Arrange
            Product nonExistingProduct = new Product(100, 20.99, "Non-existing Product", 15);

            // Act
            Product updatedProductResult = productRepository.Update(nonExistingProduct);

            // Assert
            Assert.IsNull(updatedProductResult);
        }

        [Test]
        public void Delete_Existing_Product_Success()
        {
            // Arrange
            Product productToAdd = new Product(1, 10.99, "Test Product", 5);
            productRepository.Add(productToAdd);

            // Act
            Product deletedProduct = productRepository.Delete(1);

            // Assert
            Assert.AreEqual(productToAdd, deletedProduct);
            CollectionAssert.DoesNotContain(productRepository.GetAll(), productToAdd);
        }

        [Test]
        public void Delete_NonExisting_Product_Returns_Null()
        {
            // Act
            Product deletedProduct = productRepository.Delete(100);

            // Assert
            Assert.IsNull(deletedProduct);
        }

        [Test]
        public void Add_Product_With_Duplicate_Id_Fails()
        {
            // Arrange
            Product product1 = new Product(1, 10.99, "Test Product 1", 5);
            Product product2 = new Product(1, 15.99, "Test Product 2", 10);

            // Act
            productRepository.Add(product1);

            // Assert
            Assert.That(() => productRepository.Add(product2), Throws.ArgumentException);
        }

        [Test]
        public void Update_Product_Success()
        {
            // Arrange
            Product originalProduct = new Product(1, 10.99, "Original Product", 5);
            productRepository.Add(originalProduct);

            Product updatedProduct = new Product(1, 15.99, "Updated Product", 10);

            // Act
            Product result = productRepository.Update(updatedProduct);

            // Assert
            Assert.AreEqual(updatedProduct, result);

            // Ensure the product was updated in the repository
            Product retrievedProduct = productRepository.GetByKey(1);
            Assert.AreEqual(updatedProduct, retrievedProduct);
        }


        [Test]
        public void Get_All_Products_Returns_All_Products()
        {
            // Arrange
            Product product1 = new Product(1, 10.99, "Test Product 1", 5);
            Product product2 = new Product(2, 15.99, "Test Product 2", 10);
            productRepository.Add(product1);
            productRepository.Add(product2);

            // Act
            List<Product> allProducts = productRepository.GetAll().ToList();

            // Assert
            Assert.Contains(product1, allProducts);
            Assert.Contains(product2, allProducts);
        }

        [Test]
        public void Delete_Product_Success()
        {
            // Arrange
            Product product = new Product(1, 10.99, "Test Product", 5);
            productRepository.Add(product);

            // Act
            Product deletedProduct = productRepository.Delete(1);

            // Assert
            Assert.AreEqual(product, deletedProduct);
            Assert.IsEmpty(productRepository.GetAll());
        }

        [Test]
        public void Delete_Products_Empty_Repository_Returns_Null()
        {
            // Act
            Product deletedProduct = productRepository.Delete(1);

            // Assert
            Assert.IsNull(deletedProduct);
        }
    }
}