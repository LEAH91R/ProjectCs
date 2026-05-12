using DalApi;
using DalXml;
using DO;
using Tools;
using System;

namespace Dal
{
    internal class CustomerImplementation : ICustomer
    {
        private List<Customer> Load() => XMLTools.LoadListFromXmlSerializer<Customer>("customers");
        private void Save(List<Customer> list) => XMLTools.SaveListToXmlSerializer(list, "customers");

        public int Create(Customer item)
        {
            var customers = Load();

            // שימוש ב-Config שיצרתן כדי לקבל ID רץ
            int newId = Config.getStaticValueCustomer;

            // יצירת אובייקט חדש עם ה-ID המעודכן
            Customer newCust = item with { CustId = newId };

            customers.Add(newCust);
            Save(customers);
            return newId;
        }

        public Customer? Read(int id) => Load().FirstOrDefault(c => c.CustId == id);

        public IEnumerable<Customer?> ReadAll(Func<Customer, bool>? filter = null)
        {
            var customers = Load();
            return filter == null ? customers : customers.Where(filter);
        }

        public void Update(Customer item)
        {
            var customers = Load();
            if (customers.RemoveAll(c => c.CustId == item.CustId) == 0)
                throw new Exception("Customer not found");

            customers.Add(item);
            Save(customers);
        }

        public void Delete(int id)
        {
            var customers = Load();
            if (customers.RemoveAll(c => c.CustId == id) == 0)
                throw new Exception("Customer not found");
            Save(customers);
        }

        public Customer? Read(Func<Customer, bool> filter)
        {
            throw new NotImplementedException();
        }

        List<Customer?> ICrud<Customer>.ReadAll(Func<Customer?, bool>? filter)
        {
            throw new NotImplementedException();
        }
    }
}
