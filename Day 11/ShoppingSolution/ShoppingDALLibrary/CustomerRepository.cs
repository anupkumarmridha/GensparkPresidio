using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingDALLibrary
{
    public class CustomerRepository : AbstractRepository<int, Customer>
    {
        public override async Task<Customer> Add(Customer item)
        {
            if (item == null) throw new ArgumentNullException("item");
            if (items.Any(p => p.Id == item.Id))
            {
                throw new ArgumentException("A Customer with the same ID already exists.");
            }
            items.Add(item);
            return item;
        }
        public override async Task<Customer> Delete(int key)
        {
            Customer customer = await GetByKey(key);
            if (customer != null)
            {
                items.Remove(customer);
            }
            return customer;
        }

        public override async Task<Customer> GetByKey(int key)
        {
            Customer customer = items.FirstOrDefault(item => item.Id == key);
            return customer;
        }

        public override async Task<Customer> Update(Customer item)
        {
            Customer customer = await GetByKey(item.Id);
            if (customer != null)
            {
                customer = item;
            }
            return customer;
        }
    }
}
