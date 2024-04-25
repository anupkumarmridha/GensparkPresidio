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
    public class CartServiceBLTests
    {
        private IRepository<int, Cart> _cartRepository;
        private IRepository<int, Product> _productRepository;
        private IRepository<int, Customer> _customerRepository;
        private ICartService _cartService;
        private ICustomerService _customerService;
        private IProductService _productService;

        [SetUp]
        public void Setup()
        {
            _cartRepository = new CartRepository();
            _productRepository = new ProductRepository();
            _customerRepository = new CustomerRepository();
            _cartService = new CartService(_cartRepository, _productRepository, _customerRepository);
            _customerService = new CustomerServiceBL(_customerRepository);
            _productService = new ProductServiceBL(_productRepository);
        }

        [Test]
        public void AddProductToCart_ValidInputs_Success()
        {
            // Arrange
            int quantity1 = 3;
            int quantity2 = 4;
            int quantity3 = 1;

            Customer customer = new Customer { Id = 1, Name = "John Doe", Age = 30, Phone = "1234567890" };
            Customer addedCustomer = _customerService.AddCustomer(customer);
            Assert.AreEqual(customer, addedCustomer);

            //Products to add to cart

            Product product1 = new Product { Id = 1, Name = "Laptop", Price = 100000, QuantityInHand = 80 };
            Product addedProduct1 = _productService.AddProduct(product1);
            Assert.AreEqual(product1, addedProduct1);
            
            Product product2 = new Product { Id = 2, Name = "Phone", Price = 5000, QuantityInHand = 80 };
            Product addedProduct2 = _productService.AddProduct(product2);
            Assert.AreEqual(product2, addedProduct2);
            
            Product product3 = new Product { Id = 3, Name = "Earphone", Price = 1200, QuantityInHand = 80 };
            Product addedProduct3 = _productService.AddProduct(product3);
            Assert.AreEqual(product3, addedProduct3);
                

            // Act
            Cart result1 = _cartService.AddProductToCart(customer.Id, addedProduct1.Id, quantity1);
            Console.WriteLine(result1.ToString());
            Assert.IsNotNull(result1);

            Cart result2 = _cartService.AddProductToCart(customer.Id, addedProduct2.Id, quantity2);
            Assert.IsNotNull(result2);
            
            Cart result3 = _cartService.AddProductToCart(customer.Id, addedProduct3.Id, quantity3);
            Console.WriteLine(result3.ToString());
            Assert.IsNotNull(result3);
            // Assert
            Assert.AreEqual(3, result1.CartItems.Count);
        }

    }
}
