

//מימוש של linq
using DalApi;
using DO;
using static Dal.DataSource;
using System.Linq;

namespace Dal
{
    internal class CustomerImplementation : ICustomer
    {
        public int Create(Customer item)
        {
            if (customers.Any(c => item.CustId == c?.CustId))
                throw new IdAlreadyExistsException($"{item.CustId}");

            int id = Config.getStaticValueCustomer;
            Customer cust = item with { CustId = id };
            customers.Add(cust);
            return id;
        }

        public Customer? Read(int id)
        {
            var customer = customers.FirstOrDefault(c => id == c?.CustId);
            if (customer == null)
                throw new IdNotFoundException($"{id}");
            return customer;
        }


        public Customer? Read(Func<Customer, bool> filter)
        {
            var customer = customers.FirstOrDefault(c => filter(c));
            if (customer == null)
                throw new NullItemException("customer");
            return customer;
        }
        public List<Customer?> ReadAll(Func<Customer?, bool> filter = null)
        {
            if (filter != null)
            {
                var list =
                     from c in customers
                     where filter(c)
                     select c;
                     
                return list.ToList();
            }
           return customers.ToList();
        }

        public void Update(Customer item)
        {
            if (item == null)
                throw new NullItemException("Customer cannot be null.");

            var existingCustomer = customers.FirstOrDefault(c => item.CustId == c?.CustId);
            if (existingCustomer != null)
            {
                Delete(item.CustId);
                customers.Add(item);
            }
            else
            {
                throw new IdNotFoundException($"{item.CustId}");
            }
        }

        public void Delete(int id)
        {
            // Find the customer with the read given id
            var customer = customers.FirstOrDefault(c => id == c?.CustId);
            if (customer != null)
            {
                customers.Remove(customer);
            }
            else
            {
                throw new NullItemException("");
            }
        }
    }
}