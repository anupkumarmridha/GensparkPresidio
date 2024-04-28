using ShoppingDALLibrary;
using ShoppingModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingDALTest
{
    internal class CustomerRepositoryTests
    {
        private CustomerRepository customerRepository;

        [SetUp]
        public void Setup()
        {
            customerRepository = new CustomerRepository();
        }

        [Test]
        public async Task Add_Customer_Success()
        {
            // Arrange
            Customer customer = new Customer
            {
                Id = 1,
                Name = "John Doe",
                Phone = "1234567890",
                Age = 30
            };

            // Act
            Customer addedCustomer = await customerRepository.Add(customer);
            List<Customer> allCustomers = await customerRepository.GetAll();
            // Assert
            Assert.AreEqual(customer, addedCustomer);
            Assert.Contains(addedCustomer, allCustomers.ToList());
        }

        [Test]
        public async Task Add_Customer_Null_Fails()
        {
            // Arrange
            Customer customer = null;

            // Act & Assert
            Assert.That(async () => await  customerRepository.Add(customer), Throws.ArgumentNullException);
        }

        [Test]
        public async Task Add_Customer_With_Duplicate_Id_Fails()
        {
            // Arrange
            Customer customer1 = new Customer
            {
                Id = 1,
                Name = "John Doe",
                Phone = "1234567890",
                Age = 30
            };
            Customer customer2 = new Customer
            {
                Id = 1,
                Name = "Jane Doe",
                Phone = "9876543210",
                Age = 35
            };

            // Act
            customerRepository.Add(customer1);

            // Assert
            Assert.That(async () => await  customerRepository.Add(customer2), Throws.ArgumentException);
        }

        [Test]
        public async Task GetByKey_Existing_Customer_Returns_Customer()
        {
            // Arrange
            Customer customerToAdd = new Customer
            {
                Id = 1,
                Name = "John Doe",
                Phone = "1234567890",
                Age = 30
            };
            customerRepository.Add(customerToAdd);

            // Act
            Customer retrievedCustomer = await customerRepository.GetByKey(1);

            // Assert
            Assert.AreEqual(customerToAdd, retrievedCustomer);
        }

        [Test]
        public async Task GetByKey_NonExisting_Customer_Returns_Null()
        {
            // Act
            Customer retrievedCustomer = await customerRepository.GetByKey(100);

            // Assert
            Assert.IsNull(retrievedCustomer);
        }

        [Test]
        public async Task Update_Existing_Customer_Success()
        {
            // Arrange
            Customer customerToAdd = new Customer
            {
                Id = 1,
                Name = "John Doe",
                Phone = "1234567890",
                Age = 30
            };
            customerRepository.Add(customerToAdd);

            Customer updatedCustomer = new Customer
            {
                Id = 1,
                Name = "Jane Doe",
                Phone = "0987654321",
                Age = 35
            };

            // Act
            Customer updatedCustomerResult = await customerRepository.Update(updatedCustomer);
            List<Customer> allCustomers = await customerRepository.GetAll();
            // Assert
            Assert.AreEqual(updatedCustomer, updatedCustomerResult);
            Assert.Contains(updatedCustomer, allCustomers.ToList());
        }

        [Test]
        public async Task Update_NonExisting_Customer_Returns_Null()
        {
            // Arrange
            Customer nonExistingCustomer = new Customer
            {
                Id = 100,
                Name = "Non-existing Customer",
                Phone = "9876543210",
                Age = 25
            };

            // Act
            Customer updatedCustomerResult = await customerRepository.Update(nonExistingCustomer);

            // Assert
            Assert.IsNull(updatedCustomerResult);
        }

        [Test]
        public async Task Delete_Existing_Customer_Success()
        {
            // Arrange
            Customer customerToAdd = new Customer
            {
                Id = 1,
                Name = "John Doe",
                Phone = "1234567890",
                Age = 30
            };
            customerRepository.Add(customerToAdd);

            // Act
            Customer deletedCustomer = await customerRepository.Delete(1);

            // Assert
            Assert.AreEqual(customerToAdd, deletedCustomer);
            CollectionAssert.DoesNotContain(await customerRepository.GetAll(), customerToAdd);
        }

        [Test]
        public async Task Delete_NonExisting_Customer_Returns_Null()
        {
            // Act
            Customer deletedCustomer = await customerRepository.Delete(100);

            // Assert
            Assert.IsNull(deletedCustomer);
        }

        [Test]
        public async Task Get_All_Customers_Returns_All_Customers()
        {
            // Arrange
            Customer customer1 = new Customer
            {
                Id = 1,
                Name = "John Doe",
                Phone = "1234567890",
                Age = 30
            };
            Customer customer2 = new Customer
            {
                Id = 2,
                Name = "Jane Smith",
                Phone = "9876543210",
                Age = 35
            };
            customerRepository.Add(customer1);
            customerRepository.Add(customer2);

            // Act
            List<Customer> allCustomers = await customerRepository.GetAll();
            List<Customer> allCustomersList = allCustomers.ToList();

            // Assert
            Assert.Contains(customer1, allCustomersList);
            Assert.Contains(customer2, allCustomersList);
        }

        [Test]
        public async Task Delete_Customers_Empty_Repository_Returns_Null()
        {
            // Act
            Customer deletedCustomer = await customerRepository.Delete(1);

            // Assert
            Assert.IsNull(deletedCustomer);
        }
    }
}
