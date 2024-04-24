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

        public Customer AddCustomer(Customer customer)
        {
            if (customer == null)
                throw new ArgumentNullException(nameof(customer));

            if (_customerRepository.GetAll().Any(c => c.Id == customer.Id))
            {
                throw new ArgumentException("A Customer with the same ID already exists.", nameof(customer));
            }

            return _customerRepository.Add(customer);
        }

        public Customer DeleteCustomer(int customerId)
        {
            Customer deletedCustomer = _customerRepository.Delete(customerId);

            if (deletedCustomer == null)
            {
                throw new InvalidOperationException($"Customer with ID {customerId} not found.");
            }

            return deletedCustomer;

        }

        public List<Customer> GetAllCustomers()
        {
            return _customerRepository.GetAll().ToList();
        }

        public Customer GetCustomerById(int customerId)
        {
            return _customerRepository.GetByKey(customerId);
        }

        public Customer UpdateCustomer(Customer customer)
        {
            if (customer == null)
                throw new ArgumentNullException(nameof(customer));
            return _customerRepository.Update(customer);
        }
    }
}
