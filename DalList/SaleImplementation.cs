
using DalApi;
using DO;
using Dal;
using static Dal.DataSource;
using System.Linq;
using System.Reflection;
namespace DalList
{
    internal class SaleImplementation : ISale
    {
        public int Create(Sale item)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "start create");
            if (sales.Any(s => item.SaleId == s?.SaleId))
            {
                LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "exception create");
                throw new IdAlreadyExistsException($"{item.SaleId}");
            }

            int id = Config.getStaticValueSale;
            Sale sale = item with { SaleId = id };
            sales.Add(sale);
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "finish create");
            return id;
        }

        public Sale? Read(int id)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "start read");
            var sale = sales.FirstOrDefault(s => s?.SaleId == id);

            if (sale == null)
            {
                LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "exception read");
                throw new IdNotFoundException($"{id}");
            }
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "finish read");
            return sale;
        }
        public Sale? Read(Func<Sale, bool> filter)

        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "start read filter");
            var sale = sales.FirstOrDefault(s => filter(s));
            if (sale == null)
            {
                LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "exception read filter");
                throw new NullItemException("Sale");
            }
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "finish read filter");
            return sale;
        }
        public List<Sale?> ReadAll(Func<Sale?, bool> filter = null)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "start readAll");
            if (filter != null) { 
            var list = 
                from s in sales
                where filter(s)
                select s ;
                              
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "finish readAll");
                return list.ToList();

        {
            var sale = sales.FirstOrDefault(s => filter(s));
            if (sale == null) {
                        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "exception readAll");
                        throw new NullItemException("sale");
            return sale;
        }
       
       }

        public void Update(Sale item)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "start update");

            if (item == null) {
                LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "exception update");

                throw new NullItemException("Sale cannot be null.");

        
            var entry = sales
                .Select((s, i) => new { Sale = s, Index = i })
                .FirstOrDefault(x => x.Sale?.SaleId == item.SaleId);

            if (entry != null)
            {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "finish update");

                    sales[entry.Index] = item;
            }
            else
            {
                    LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "exception update");

                    throw new IdNotFoundException($"{item.SaleId}");
            }
        }

        public void Delete(int id)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "start delete");

            var removedCount = sales.RemoveAll(s => s?.SaleId == id);
            if (removedCount == 0) {
                LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "exception delete");

                throw new NullItemException("");
            } 
        }

    }
}


//using DalApi;
//using DO;
//using Dal;
//using static Dal.DataSource;

//namespace DalList
//{
//    internal class SaleImplementation :ISale
//    {


//        public int Create(Sale item)
//        {
//            foreach (var c in sales)
//            {
//                if (item.SaleId == c?.SaleId)
//                    throw new Exception("this id existing!");
//            }
//            int id = Config.getStaticValueSale;
//            Sale sale = item with { SaleId = id };
//            sales.Add(sale);
//            return id;
//        }

//        public Sale? Read(int id)
//        {
//            foreach (var c in sales)
//            {
//                if (id == c?.SaleId)
//                    return c;
//            }
//            throw new NotImplementedException("not existing!");
//        }

//        public List<Sale?> ReadAll()
//        {
//            return sales;
//        }

//        public void Update(Sale item)
//        {
//            bool f = false;
//            if (item == null)
//                throw new Exception("Product  cannot be null.");
//            foreach (var c in sales)
//            {
//                if (item.SaleId == c?.SaleId)
//                {
//                    f=true;
//                    Delete(item.SaleId);
//                    sales.Add(item);
//                    return;
//                }    
//            }
//            if (!f)
//            {
//                throw new Exception("not id existing!");
//            }

//        }

//        public void Delete(int id)
//        {
//            foreach (var c in sales)
//            {
//                if (id == c?.SaleId)
//                {
//                    sales.Remove(c);
//                    return;
//                }
//            }
//            throw new NotImplementedException();
//        }
//    }
//}

