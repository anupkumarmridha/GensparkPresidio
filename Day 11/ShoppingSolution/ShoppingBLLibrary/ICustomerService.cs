using ShoppingModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBLLibrary
{
    public interface ICustomerService
    {
        /// <summary>
        /// Adds a new customer.
        /// </summary>
        /// <param name="customer">The customer to add.</param>
        /// <returns>The added customer.</returns>
        Customer AddCustomer(Customer customer);

        /// <summary>
        /// Retrieves a customer by their ID.
        /// </summary>
        /// <param name="customerId">The ID of the customer to retrieve.</param>
        /// <returns>The retrieved customer.</returns>
        Customer GetCustomerById(int customerId);

        /// <summary>
        /// Retrieves all customers.
        /// </summary>
        /// <returns>A list of all customers.</returns>
        List<Customer> GetAllCustomers();

        /// <summary>
        /// Updates an existing customer.
        /// </summary>
        /// <param name="customer">The updated customer information.</param>
        /// <returns>The updated customer.</returns>
        Customer UpdateCustomer(Customer customer);

        /// <summary>
        /// Deletes a customer.
        /// </summary>
        /// <param name="customerId">The ID of the customer to delete.</param>
        /// <returns>The deleted customer.</returns>
        Customer DeleteCustomer(int customerId);
    }
}
