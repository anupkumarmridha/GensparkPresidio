using ShoppingDALLibrary;
using ShoppingModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingDALTest
{
    public class CartItemRepositoryTests
    {
        private CartItemRepository cartItemRepository;

        [SetUp]
        public void Setup()
        {
            cartItemRepository = new CartItemRepository();
        }

        [Test]
        public async Task Add_CartItem_Success()
        {
            // Arrange
            CartItem cartItem = new CartItem
            {
                CartId = 1,
                ProductId = 1,
                Product = new Product { Id = 1, Name = "Product 1", Price = 10.99, QuantityInHand = 5 },
                Quantity = 2,
                Price = 10.99,
                Discount = 1.00,
                PriceExpiryDate = DateTime.Now.AddDays(7)
            };

            // Act
            CartItem addedCartItem = await cartItemRepository.Add(cartItem);
            List<CartItem> allCartItems = await cartItemRepository.GetAll();
            // Assert
            Assert.AreEqual(cartItem, addedCartItem);
            Assert.Contains(addedCartItem, allCartItems.ToList());
        }

        [Test]
        public async Task Add_CartItem_Null_Fails()
        {
            // Arrange
            CartItem cartItem = null;

            // Act & Assert
            Assert.That(() => cartItemRepository.Add(cartItem), Throws.ArgumentNullException);
        }

        [Test]
        public async Task Add_CartItem_With_Null_Product_Fails()
        {
            // Arrange
            CartItem cartItem = new CartItem { CartId = 1, Product = null };

            // Act & Assert
            Assert.That(() => cartItemRepository.Add(cartItem), Throws.ArgumentException);
        }

        [Test]
        public async Task GetByKey_Existing_CartItem_Returns_CartItem()
        {
            // Arrange
            CartItem cartItemToAdd = new CartItem { CartId = 1, ProductId = 1, Product = new Product { Id = 1, Name = "Product 1" } };
            cartItemRepository.Add(cartItemToAdd);

            // Act
            CartItem retrievedCartItem = await cartItemRepository.GetByKey(1);

            // Assert
            Assert.AreEqual(cartItemToAdd, retrievedCartItem);
        }

        [Test]
        public async Task GetByKey_NonExisting_CartItem_Returns_Null()
        {
            // Act
            CartItem retrievedCartItem = await cartItemRepository.GetByKey(100);

            // Assert
            Assert.IsNull(retrievedCartItem);
        }

        [Test]
        public async Task Update_Existing_CartItem_Success()
        {
            // Arrange
            CartItem cartItemToAdd = new CartItem { CartId = 1, ProductId = 1, Product = new Product { Id = 1, Name = "Product 1" } };
            cartItemRepository.Add(cartItemToAdd);

            CartItem updatedCartItem = new CartItem { CartId = 1, ProductId = 2, Product = new Product { Id = 2, Name = "Product 2" } };

            // Act
            CartItem updatedCartItemResult = await cartItemRepository.Update(updatedCartItem);

            List<CartItem> allCartItems = await cartItemRepository.GetAll();
            // Assert
            Assert.AreEqual(updatedCartItem, updatedCartItemResult);
            Assert.Contains(updatedCartItem, allCartItems.ToList());
        }

        [Test]
        public async Task Update_NonExisting_CartItem_Returns_Null()
        {
            // Arrange
            CartItem nonExistingCartItem = new CartItem { CartId = 100, ProductId = 100 };

            // Act
            CartItem updatedCartItemResult = await cartItemRepository.Update(nonExistingCartItem);

            // Assert
            Assert.IsNull(updatedCartItemResult);
        }

        [Test]
        public async Task Delete_Existing_CartItem_Success()
        {
            // Arrange
            CartItem cartItemToAdd = new CartItem { CartId = 1, ProductId = 1, Product = new Product { Id = 1, Name = "Product 1" } };
            cartItemRepository.Add(cartItemToAdd);

            // Act
            CartItem deletedCartItem = await cartItemRepository.Delete(1);

            // Assert
            Assert.AreEqual(cartItemToAdd, deletedCartItem);
            CollectionAssert.DoesNotContain(await cartItemRepository.GetAll(), cartItemToAdd);
        }

        [Test]
        public async Task Delete_NonExisting_CartItem_Returns_Null()
        {
            // Act
            CartItem deletedCartItem = await cartItemRepository.Delete(100);

            // Assert
            Assert.IsNull(deletedCartItem);
        }

        [Test]
        public async Task Get_All_CartItems_Returns_All_CartItems()
        {
            // Arrange
            CartItem cartItem1 = new CartItem { CartId = 1, ProductId = 1, Product = new Product { Id = 1, Name = "Product 1" } };
            CartItem cartItem2 = new CartItem { CartId = 2, ProductId = 2, Product = new Product { Id = 2, Name = "Product 2" } };
            cartItemRepository.Add(cartItem1);
            cartItemRepository.Add(cartItem2);

            // Act
            List<CartItem> allCartItems = await cartItemRepository.GetAll();
            List<CartItem> allCartItemsList = allCartItems.ToList();
            // Assert
            Assert.Contains(cartItem1, allCartItemsList);
            Assert.Contains(cartItem2, allCartItemsList);
        }

        [Test]
        public async Task Delete_CartItems_Empty_Repository_Returns_Null()
        {
            // Act
            CartItem deletedCartItem = await cartItemRepository.Delete(1);

            // Assert
            Assert.IsNull(deletedCartItem);
        }

        [Test]
        public async Task CartItem_Equals_Returns_True_For_Same_CartId()
        {
            // Arrange
            CartItem cartItem1 = new CartItem { CartId = 1 };
            CartItem cartItem2 = new CartItem { CartId = 1 };

            // Act
            bool result = cartItem1.Equals(cartItem2);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public async Task CartItem_Equals_Returns_False_For_Different_CartId()
        {
            // Arrange
            CartItem cartItem1 = new CartItem { CartId = 1 };
            CartItem cartItem2 = new CartItem { CartId = 2 };

            // Act
            bool result = cartItem1.Equals(cartItem2);

            // Assert
            Assert.IsFalse(result);
        }
    }
}
