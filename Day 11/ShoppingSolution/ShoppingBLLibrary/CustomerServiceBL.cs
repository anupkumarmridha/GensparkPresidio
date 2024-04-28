using ShoppingDALLibrary;
using ShoppingModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBLLibrary
{
    public class CustomerServiceBL : ICustomerService
    {
        private readonly IRepository<int, Customer> _customerRepository;

        public CustomerServiceBL(IRepository<int, Customer> customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Customer> AddCustomer(Customer customer)
        {
            if (customer == null)
                throw new ArgumentNullException(nameof(customer));

            List<Customer> customers = await _customerRepository.GetAll();
            if (customers.Any(c => c.Id == customer.Id))
            {
                throw new ArgumentException("A Customer with the same ID already exists.", nameof(customer));
            }

            return await _customerRepository.Add(customer);
        }

        public async Task<Customer> DeleteCustomer(int customerId)
        {
            Customer deletedCustomer = await _customerRepository.Delete(customerId);

            if (deletedCustomer == null)
            {
                throw new InvalidOperationException($"Customer with ID {customerId} not found.");
            }

            return deletedCustomer;

        }

        public async Task<List<Customer>> GetAllCustomers()
        {
            List<Customer> customers = await _customerRepository.GetAll();
            return customers.ToList();
        }

        public async Task<Customer> GetCustomerById(int customerId)
        {
            return await _customerRepository.GetByKey(customerId);
        }

        public async Task<Customer> UpdateCustomer(Customer customer)
        {
            if (customer == null)
                throw new ArgumentNullException(nameof(customer));
            return await _customerRepository.Update(customer);
        }
    }
}
