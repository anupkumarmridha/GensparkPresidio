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
    internal class CustomerBLTest
    {
        private ICustomerService _customerService;
        private IRepository<int, Customer> _customerRepository;

        [SetUp]
        public void Setup()
        {
            _customerRepository = new CustomerRepository();
            _customerService = new CustomerServiceBL(_customerRepository);
        }

        [Test]
        public async Task AddCustomer_Success()
        {
            // Arrange
            Customer customer = new Customer { Id = 1, Name = "John Doe", Age = 30, Phone = "1234567890" };

            Customer addedCustomer = await _customerService.AddCustomer(customer);
            Assert.That(addedCustomer, Is.EqualTo(customer));
        }

        [Test]
        public async Task AddCustomer_NullCustomer_Fails()
        {
            // Arrange
            Customer customer = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => _customerService.AddCustomer(customer));
        }

        [Test]
        public async Task DeleteCustomer_Success()
        {
            // Arrange
            int customerId = 1;
            Customer customerToDelete = new Customer { Id = customerId, Name = "John Doe", Age = 30, Phone = "1234567890" };
            _customerService.AddCustomer(customerToDelete);

            // Act
            Customer deletedCustomer = await _customerService.DeleteCustomer(customerId);

            // Assert
            Assert.IsNotNull(deletedCustomer);
            Assert.That(deletedCustomer, Is.EqualTo(customerToDelete));
            List<Customer> customers = await _customerService.GetAllCustomers();
            Assert.IsFalse(customers.Any(c => c.Id == customerId));
        }

        [Test]
        public async Task DeleteCustomer_NonExistingCustomerId_ReturnsException()
        {
            // Arrange
            int nonExistingCustomerId = 100;
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => _customerService.DeleteCustomer(nonExistingCustomerId));
            Assert.That(exception.Message, Is.EqualTo($"Customer with ID {nonExistingCustomerId} not found."));
        }

        [Test]
        public async Task GetAllCustomers_ReturnsAllCustomers()
        {
            // Arrange

            List<Customer> customers = new List<Customer>
            {
                new Customer { Id = 1, Name = "John Doe", Age = 30, Phone = "1234567890" },
                new Customer { Id = 2, Name = "Jane Smith", Age = 25, Phone = "9876543210" }
            };

            Customer customer1 = new Customer { Id = 1, Name = "John Doe", Age = 30, Phone = "1234567890" };
            Customer customer2 = new Customer { Id = 2, Name = "Jane Smith", Age = 25, Phone = "9876543210" };

            _customerService.AddCustomer(customer1);
            _customerService.AddCustomer(customer2);


            List<Customer> retrievedCustomers = await _customerService.GetAllCustomers();

            // Assert
            CollectionAssert.AreEquivalent(customers, retrievedCustomers);
        }

        [Test]
        public async Task GetCustomerById_ExistingId_ReturnsCustomer()
        {
            // Arrange
            int customerId = 1;
            Customer customer = new Customer { Id = customerId, Name = "John Doe", Age = 30, Phone = "1234567890" };
            _customerService.AddCustomer(customer);
            Customer retrievedCustomer = await _customerService.GetCustomerById(customerId);

            // Assert
            Assert.That(retrievedCustomer, Is.EqualTo(customer));
        }

        [Test]
        public async Task GetCustomerById_NonExistingId_ReturnsNull()
        {
            // Arrange
            int nonExistingCustomerId = 100;
            Customer retrievedCustomer = await _customerService.GetCustomerById(nonExistingCustomerId);

            // Assert
            Assert.IsNull(retrievedCustomer);
        }

        [Test]
        public async Task UpdateCustomer_Success()
        {
            // Arrange
            Customer customer = new Customer { Id = 1, Name = "John Doe", Age = 34, Phone = "1234567890" };
            Customer newCustomer = await _customerService.AddCustomer(customer);
            Customer customer1 = new Customer { Id = 1, Name = "John Doe", Age = 30, Phone = "1234567890" };
            Customer updatedCustomer = await _customerService.UpdateCustomer(customer1);

            // Assert
            Assert.That(updatedCustomer, Is.EqualTo(newCustomer));
        }

        [Test]
        public async Task UpdateCustomer_NullCustomer_Fails()
        {
            // Arrange
            Customer customer = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(async() => await _customerService.UpdateCustomer(customer));
        }

        [Test]
        public async Task UpdateCustomer_NonExistingId_Fails()
        {
            // Arrange
            Customer customer = new Customer { Id = 100, Name = "John Doe", Age = 30, Phone = "1234567890" };
            Customer updatedCustomer = await _customerService.UpdateCustomer(customer);

            // Assert
            Assert.IsNull(updatedCustomer);
        }

        [Test]
        public async Task AddCustomer_DuplicateId_Fails()
        {
            // Arrange
            Customer existingCustomer = new Customer { Id = 1, Name = "John Doe", Age = 30, Phone = "1234567890" };
            Customer duplicateCustomer = new Customer { Id = 1, Name = "Jane Smith", Age = 25, Phone = "9876543210" };
            _customerService.AddCustomer(existingCustomer);
            // Assert
            Assert.Throws<ArgumentException>(async() => await _customerService.AddCustomer(duplicateCustomer));
        }

        [Test]
        public async Task GetAllCustomers_EmptyRepository_ReturnsEmptyList()
        {
            // Arrange
            List<Customer> emptyList = new List<Customer>();
            List<Customer> retrievedCustomers = await _customerService.GetAllCustomers();

            // Assert
            CollectionAssert.IsEmpty(retrievedCustomers);
        }

        [Test]
        public async Task UpdateCustomer_EmptyRepository_ReturnsNull()
        {
            // Arrange
            Customer customer = new Customer { Id = 1, Name = "John Doe", Age = 30, Phone = "1234567890" };
            Customer updatedCustomer = await _customerService.UpdateCustomer(customer);

            // Assert
            Assert.IsNull(updatedCustomer);
        }
    }
}
