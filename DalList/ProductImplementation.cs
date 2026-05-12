
using DalApi;
using DO;
using Dal;
using static Dal.DataSource;
using System.Linq;
using System.Reflection;
using Tools;
namespace DalList;
using BO;
using BL.BO;

internal class ProductImplementation : IProduct
{
    public int Create(Product item)
    {
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "start create");
        if (products.Any(p => item.ProdId == p?.ProdId))
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "exception create");
            throw new IdAlreadyExistsException($"{item.ProdId}");
        }

        int id = Config.getStaticValueProduct;
        Product product = item with { ProdId = id };
        products.Add(product);
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "finish create");
        return id;
    }

    public Product Read(int id)
    {
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "start read");
        var product = products.FirstOrDefault(p => id == p?.ProdId);
        if (product == null)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "exception read");
            throw new IdNotFoundException($"{id}");
        }
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "finish read");
        return product;
    }
    public Product? Read(Func<Product, bool> filter)
    {
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "start filter read");
        var product = products.FirstOrDefault(p => filter(p));
        if (product == null)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "exception filter read");
            throw new NullItemException("product");
        }
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "finish filter read");
        return product;
    }

    public List<Product?> ReadAll(Func<Product?, bool> filter = null)
    {
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "start readAll");
        if (filter != null)
        {
            var list=from p in products
                     where filter(p)
                     select p ;
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "finish readAll");
            return list.ToList ();
        }
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "finish null readAll");
        return products.ToList();
    }

    public void Update(Product item)
    {
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "start update");
        if (item == null)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "exception update");
            throw new NullItemException("Product cannot be null.");
        }

        var existingProduct = products.FirstOrDefault(p => item.ProdId == p?.ProdId);
        if (existingProduct != null)
        {
            Delete(item.ProdId);
            products.Add(item);
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "finish update");
        }
        else
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "exception id update");
            throw new IdNotFoundException($"{item.ProdId}");
        }
    }

    public void Delete(int id)
    {
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "start delete");
        var product = products.FirstOrDefault(p => id == p?.ProdId);
        if (product != null)
        {
            products.Remove(product);
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "finish update");
        }
        else
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "exception id update");
            throw new NullItemException("Product cannot be null.");
        }
    }
}
