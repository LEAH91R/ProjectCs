using DO; // שימוש בשכבת הנתונים בלבד
using System;
using System.Collections.Generic;
using System.Linq;

namespace Dal
{
    // 1. שינוי שם הממשק ל-ICustomer מה-DAL (ולא מ-BlApi)
    internal class CustomerImplementation : DalApi.ICustomer
    {
        // 2. שימוש מפורש ב-DO.Customer כדי למנוע כפילות עם BO
        private List<DO.Customer> Load() => XMLTools.LoadListFromXmlSerializer<DO.Customer>("customers");
        private void Save(List<DO.Customer> list) => XMLTools.SaveListToXmlSerializer(list, "customers");

        // 3. שינוי החתימה שתקבל ותחזיר DO.Customer
        public int Create(DO.Customer item)
        {
            var customers = Load();

            // שימוש ב-Config של ה-DAL לקבלת מזהה רץ
            int newId = Config.getStaticValueCustomer;

            // יצירת אובייקט חדש של DO (העתקה עם מזהה חדש)
            DO.Customer newCust = item with { CustId = newId }; // ודאי שב-DO השדה הוא Id ולא CustId

            customers.Add(newCust);
            Save(customers);
            return newId;
        }

        public DO.Customer? Read(int id) => Load().FirstOrDefault(c => c.CustId == id);

        public IEnumerable<DO.Customer?> ReadAll(Func<DO.Customer, bool>? filter = null)
        {
            var customers = Load();
            return filter == null ? customers : customers.Where(filter);
        }

        public void Update(DO.Customer item)
        {
            var customers = Load();
            // ב-DO השדה המזהה הוא בדרך כלל Id
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
    }
}