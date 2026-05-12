using DalApi;
using DO;
using Dal;
using static Dal.DataSource;
using System.Linq;
using System.Reflection;
using Tools;
using System.Collections.Generic;
using System;
using BO;
using BL.BO;

namespace DalList
{
    internal class SaleImplementation : ISale
    {
        public int Create(Sale item)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "start create");
            if (item == null)
            {
                LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "exception create");
                throw new NullItemException("Sale");
            }

            if (sales.Any(s => s?.SaleId == item.SaleId))
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
            if (filter == null) throw new NullItemException("filter");
            var sale = sales.FirstOrDefault(s => s != null && filter(s));
            if (sale == null)
            {
                LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "exception read filter");
                throw new IdNotFoundException("Sale");
            }
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "finish read filter");
            return sale;
        }

        public List<Sale?> ReadAll(Func<Sale?, bool>? filter = null)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "start readAll");
            IEnumerable<Sale?> query = sales;
            if (filter != null)
                query = query.Where(s => filter(s));

            var list = query.ToList();
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "finish readAll");
            return list;
        }

        public void Update(Sale item)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "start update");

            if (item == null)
            {
                LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "exception update");
                throw new NullItemException("Sale cannot be null.");
            }

            var index = sales.FindIndex(s => s?.SaleId == item.SaleId);
            if (index >= 0)
            {
                sales[index] = item;
                LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "finish update");
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
            if (removedCount == 0)
            {
                LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "exception delete");
                throw new IdNotFoundException($"{id}");
            }
        }
    }
}

