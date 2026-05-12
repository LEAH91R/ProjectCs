
using DalApi;
using DO;
using static Dal.DataSource;
using System.Linq;
using System.Reflection;
using Tools;
using BO;
using BL.BO;

namespace Dal
{
    internal class CustomerImplementation : ICustomer
    {
        public int Create(Customer item)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "start create");
            if (customers.Any(c => item.CustId == c?.CustId)) {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "exception create");
            throw new IdAlreadyExistsException($"{item.CustId}");
        }
            int id = Config.getStaticValueCustomer;
            Customer cust = item with { CustId = id };
            customers.Add(cust);
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "finish create");
            return id;
        }

        public Customer? Read(int id)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "start read");
            var customer = customers.FirstOrDefault(c => id == c?.CustId);
            if (customer == null)
            {
                LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "exception read");
                throw new IdNotFoundException($"{id}");
            }
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "finish read");
            return customer;
            }
      

        public Customer? Read(Func<Customer, bool> filter)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "start read filter");
            var customer = customers.FirstOrDefault(c => filter(c));
            if (customer == null)
            {
                LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "exception read filter");
                throw new NullItemException("customer");
            }
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "finish read filter");
            return customer;
        }


        public List<Customer?> ReadAll(Func<Customer?, bool> filter = null)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "start readAll");
            if (filter != null)
            {
                var list = from cust in customers
                           where filter(cust)
                           select cust;
                LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "finish readAll");
                return list.ToList();
            }
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "finish readAllNull");
            return customers;
        }
        //public List<Customer?> ReadAll(Func<Customer?, bool> filter = null)
        //{
        //    if (filter != null)
        //    {
        //        var list =
        //             from c in customers
        //             where filter(c)
        //             select c;
                     
        //        return list.ToList();
        //    }
        //   return customers.ToList();

        //}
        
        public void Update(Customer item)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "start update");
            if (item == null)
            {
                LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "exception null update");
                throw new NullItemException("Customer cannot be null.");
            }
            var existingCustomer = customers.FirstOrDefault(c => item.CustId == c?.CustId);
            if (existingCustomer != null)
            {
                Delete(item.CustId);
                customers.Add(item);
                LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "finish update");

            }
            else
            {
                LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "exception id null ");
                throw new IdNotFoundException($"{item.CustId}");
            }
        }

        public void Delete(int id)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "start delete");
            // Find the customer with the read given id
            var customer = customers.FirstOrDefault(c => id == c?.CustId);
            if (customer != null)
            {
                customers.Remove(customer);
                LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "finish delete");

            }
            else
            {
                LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "exception delete");
                throw new NullItemException("");
            }
        }
    }
}