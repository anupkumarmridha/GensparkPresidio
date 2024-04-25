using ShoppingDALLibrary;
using ShoppingModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingDALTest
{
    public class CartRepositoryTests
    {
        private CartRepository cartRepository;

        [SetUp]
        public void Setup()
        {
            cartRepository = new CartRepository();
        }

        [Test]
        public void Add_Cart_Success()
        {
            // Arrange
            Cart cart = new Cart
            {
                CustomerId = 1,
                Customer = new Customer { Id = 1, Name = "John Doe", Phone = "1234567890", Age = 30 },
                CartItems = new List<CartItem>()
            };

            // Act
            Cart addedCart = cartRepository.Add(cart);

            // Assert
            Assert.AreEqual(cart, addedCart);
            Assert.Contains(addedCart, cartRepository.GetAll().ToList());
        }

        [Test]
        public void Add_Cart_Null_Fails()
        {
            // Arrange
            Cart cart = null;

            // Act & Assert
            Assert.That(() => cartRepository.Add(cart), Throws.ArgumentNullException);
        }

        [Test]
        public void Add_Cart_With_Duplicate_Id_Fails()
        {
            // Arrange
            Cart cart1 = new Cart { Id = 1, CustomerId = 1, Customer = new Customer { Id = 1, Name = "John Doe" } };
            Cart cart2 = new Cart { Id = 1, CustomerId = 2, Customer = new Customer { Id = 2, Name = "Jane Doe" } };

            // Act
            cartRepository.Add(cart1);

            // Assert
            Assert.That(() => cartRepository.Add(cart2), Throws.ArgumentException);
        }

        [Test]
        public void GetByKey_Existing_Cart_Returns_Cart()
        {
            // Arrange
            Cart cartToAdd = new Cart {CustomerId = 1, Customer = new Customer { Id = 1, Name = "John Doe" } };
            cartRepository.Add(cartToAdd);

            // Act
            Cart retrievedCart = cartRepository.GetByKey(1);

            // Assert
            Assert.AreEqual(cartToAdd, retrievedCart);
        }

        [Test]
        public void GetByKey_NonExisting_Cart_Returns_Null()
        {
            // Act
            Cart retrievedCart = cartRepository.GetByKey(100);

            // Assert
            Assert.IsNull(retrievedCart);
        }

        [Test]
        public void Update_Existing_Cart_Success()
        {
            // Arrange
            Cart cartToAdd = new Cart { Id = 1, CustomerId = 1, Customer = new Customer { Id = 1, Name = "John Doe" } };
            Cart updatedCart= cartRepository.Add(cartToAdd);

            updatedCart.CustomerId = 2;
            updatedCart.Customer = new Customer { Id = 2, Name = "Jane Doe" };

            // Act
            Cart updatedCartResult = cartRepository.Update(updatedCart);

            // Assert
            Assert.That(updatedCartResult, Is.EqualTo(updatedCart));
            Assert.Contains(updatedCart, cartRepository.GetAll().ToList());
        }

        [Test]
        public void Update_NonExisting_Cart_Returns_Null()
        {
            // Arrange
            Cart nonExistingCart = new Cart { Id = 100, CustomerId = 100 };

            // Act
            Cart updatedCartResult = cartRepository.Update(nonExistingCart);

            // Assert
            Assert.IsNull(updatedCartResult);
        }

        [Test]
        public void Delete_Existing_Cart_Success()
        {
            // Arrange
            Cart cartToAdd = new Cart { Id = 1, CustomerId = 1, Customer = new Customer { Id = 1, Name = "John Doe" } };
            cartRepository.Add(cartToAdd);

            // Act
            Cart deletedCart = cartRepository.Delete(1);

            // Assert
            Assert.AreEqual(cartToAdd, deletedCart);
            CollectionAssert.DoesNotContain(cartRepository.GetAll(), cartToAdd);
        }

        [Test]
        public void Delete_NonExisting_Cart_Returns_Null()
        {
            // Act
            Cart deletedCart = cartRepository.Delete(100);

            // Assert
            Assert.IsNull(deletedCart);
        }

        [Test]
        public void Get_All_Carts_Returns_All_Carts()
        {
            // Arrange
            Cart cart1 = new Cart { Id = 1, CustomerId = 1, Customer = new Customer { Id = 1, Name = "John Doe" } };
            Cart cart2 = new Cart { Id = 2, CustomerId = 2, Customer = new Customer { Id = 2, Name = "Jane Doe" } };
            cartRepository.Add(cart1);
            cartRepository.Add(cart2);

            // Act
            List<Cart> allCarts = cartRepository.GetAll().ToList();

            // Assert
            Assert.Contains(cart1, allCarts);
            Assert.Contains(cart2, allCarts);
        }

        [Test]
        public void Delete_Carts_Empty_Repository_Returns_Null()
        {
            // Act
            Cart deletedCart = cartRepository.Delete(1);

            // Assert
            Assert.IsNull(deletedCart);
        }

        [Test]
        public void Cart_Equals_Returns_True_For_Same_Id()
        {
            // Arrange
            Cart cart1 = new Cart { Id = 1 };
            Cart cart2 = new Cart { Id = 1 };

            // Act
            bool result = cart1.Equals(cart2);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void Cart_Equals_Returns_False_For_Different_Id()
        {
            // Arrange
            Cart cart1 = new Cart { Id = 1 };
            Cart cart2 = new Cart { Id = 2 };

            // Act
            bool result = cart1.Equals(cart2);

            // Assert
            Assert.IsFalse(result);
        }
    }
}
