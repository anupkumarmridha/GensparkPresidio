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
        public async Task Add_Product_Success()
        {
            // Arrange
            Product product = new Product(1, 10.99, "Test Product", 5);

            // Act
            Product addedProduct = await productRepository.Add(product);
            List<Product> allProducts = await productRepository.GetAll();
            // Assert
            Assert.AreEqual(product, addedProduct);
            Assert.Contains(addedProduct, allProducts.ToList());
        }

        [Test]
        public async Task Add_Product_Null_Fails()
        {
            // Arrange
            Product product = null;

            // Act & Assert
            Assert.That(async () => await productRepository.Add(product), Throws.ArgumentNullException);
        }

        [Test]
        public async Task GetByKey_Existing_Product_Returns_Product()
        {
            // Arrange
            Product productToAdd = new Product(1, 10.99, "Test Product", 5);
            productRepository.Add(productToAdd);

            // Act
            Product retrievedProduct = await productRepository.GetByKey(1);

            // Assert
            Assert.AreEqual(productToAdd, retrievedProduct);
        }

        [Test]
        public async Task GetByKey_NonExisting_Product_Returns_Null()
        {
            // Act
            Product retrievedProduct = await productRepository.GetByKey(100);

            // Assert
            Assert.IsNull(retrievedProduct);
        }

        [Test]
        public async Task Update_Existing_Product_Success()
        {
            // Arrange
            Product productToAdd = new Product(1, 10.99, "Test Product", 5);
            productRepository.Add(productToAdd);

            Product updatedProduct = new Product(1, 15.99, "Updated Product", 10);

            // Act
            Product updatedProductResult =await productRepository.Update(updatedProduct);
            List<Product> allProducts = await productRepository.GetAll();

            // Assert
            Assert.AreEqual(updatedProduct, updatedProductResult);
            Assert.Contains(updatedProduct, allProducts.ToList());
        }

        [Test]
        public async Task Update_NonExisting_Product_Returns_Null()
        {
            // Arrange
            Product nonExistingProduct = new Product(100, 20.99, "Non-existing Product", 15);

            // Act
            Product updatedProductResult = await productRepository.Update(nonExistingProduct);

            // Assert
            Assert.IsNull(updatedProductResult);
        }

        [Test]
        public async Task Delete_Existing_Product_Success()
        {
            // Arrange
            Product productToAdd = new Product(1, 10.99, "Test Product", 5);
            productRepository.Add(productToAdd);

            // Act
            Product deletedProduct =await productRepository.Delete(1);
            List<Product> allProducts = await productRepository.GetAll();

            // Assert
            Assert.AreEqual(productToAdd, deletedProduct);
            CollectionAssert.DoesNotContain(allProducts, productToAdd);
        }

        [Test]
        public async Task Delete_NonExisting_Product_Returns_Null()
        {
            // Act
            Product deletedProduct = await productRepository.Delete(100);

            // Assert
            Assert.IsNull(deletedProduct);
        }

        [Test]
        public async Task Add_Product_With_Duplicate_Id_Fails()
        {
            // Arrange
            Product product1 = new Product(1, 10.99, "Test Product 1", 5);
            Product product2 = new Product(1, 15.99, "Test Product 2", 10);

            // Act
            productRepository.Add(product1);

            // Assert
            Assert.That(async () => await productRepository.Add(product2), Throws.ArgumentException);
        }

        [Test]
        public async Task Update_Product_Success()
        {
            // Arrange
            Product originalProduct = new Product(1, 10.99, "Original Product", 5);
            productRepository.Add(originalProduct);

            Product updatedProduct = new Product(1, 15.99, "Updated Product", 10);

            // Act
            Product result = await productRepository.Update(updatedProduct);

            // Assert
            Assert.AreEqual(updatedProduct, result);

            // Ensure the product was updated in the repository
            Product retrievedProduct = await productRepository.GetByKey(1);
            Assert.AreEqual(updatedProduct, retrievedProduct);
        }


        [Test]
        public async Task Get_All_Products_Returns_All_Products()
        {
            // Arrange
            Product product1 = new Product(1, 10.99, "Test Product 1", 5);
            Product product2 = new Product(2, 15.99, "Test Product 2", 10);
            productRepository.Add(product1);
            productRepository.Add(product2);

            // Act
            List<Product> allProducts = await productRepository.GetAll();

            // Assert
            Assert.Contains(product1, allProducts.ToList());
            Assert.Contains(product2, allProducts.ToList());
        }

        [Test]
        public async Task Delete_Product_Success()
        {
            // Arrange
            Product product = new Product(1, 10.99, "Test Product", 5);
            await productRepository.Add(product);

            // Act
            Product deletedProduct = await productRepository.Delete(1);

            List<Product> allProducts = await productRepository.GetAll();

            // Assert
            Assert.AreEqual(product, deletedProduct);
            Assert.IsEmpty(allProducts.ToList());
        }

        [Test]
        public async Task Delete_Products_Empty_Repository_Returns_Null()
        {
            // Act
            Product deletedProduct = await productRepository.Delete(1);

            // Assert
            Assert.IsNull(deletedProduct);
        }
    }
}