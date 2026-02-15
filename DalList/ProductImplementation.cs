
using DalApi;
using DO;
using Dal;
using static Dal.DataSource;
using System.Linq;
using System.Reflection;
using Tools;
namespace DalList;

internal class ProductImplementation : IProduct
{
    public int Create(Product item)
    {
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "start create");
        if (products.Any(p => item.ProdId == p?.ProdId))
            throw new IdAlreadyExistsException($"{item.ProdId}");

        int id = Config.getStaticValueProduct;
        Product product = item with { ProdId = id };
        products.Add(product);
        return id;
    }

    public Product Read(int id)
    {
        var product = products.FirstOrDefault(p => id == p?.ProdId);
        if (product == null)
            throw new IdNotFoundException($"{id}");
        return product;
    }
    public Product? Read(Func<Product, bool> filter)
    {
        var product = products.FirstOrDefault(p => filter(p));
        if (product == null)
            throw new NullItemException("product");
        return product;
    }

    public List<Product?> ReadAll(Func<Product?, bool> filter = null)
    {
        if (filter != null)
        {
            var list=from p in products
                     where filter(p)
                     select p ;
            return list.ToList ();
               

   
        }
        return products.ToList();
    }

    public void Update(Product item)
    {
        if (item == null)
            throw new NullItemException("Product cannot be null.");

        var existingProduct = products.FirstOrDefault(p => item.ProdId == p?.ProdId);
        if (existingProduct != null)
        {
            Delete(item.ProdId);
            products.Add(item);
        }
        else
        {
            throw new IdNotFoundException($"{item.ProdId}");
        }
    }

    public void Delete(int id)
    {
        var product = products.FirstOrDefault(p => id == p?.ProdId);
        if (product != null)
        {
            products.Remove(product);
        }
        else
        {
            throw new NullItemException("Product cannot be null.");
        }
    }
}

//using DalApi;
//using DO;
//using Dal;  
//using static Dal.DataSource;


//namespace DalList;

//internal class ProductImplementation : IProduct
//{
//    public int Create(Product item)
//    {

//        foreach (var p in products)
//        {
//            if (item.ProdId == p?.ProdId)
//                throw new Exception("this id existing!");
//        }
//        int id = Config.getStaticValueProduct;
//        Product product = item with { ProdId = id };
//        products.Add(product);
//        return id;

//    }
//    public Product Read(int id)
//    {
//        foreach (var p in products)
//        {
//            if (id == p.ProdId)
//                return p;

//        }
//        throw new NotImplementedException("not existing!");
//    }
//    public List<Product?> ReadAll()
//    {
//        return products;
//    }
//    public void Update(Product item)
//    {
//        bool f = false;
//        if (item == null)
//            throw new Exception("Product  cannot be null.");
//        foreach (var p in products)
//        {
//            if (item.ProdId == p?.ProdId)
//            {
//                f = true;
//                Delete(item.ProdId);
//                products.Add(item);
//                return;
//            }
//        }
//        if (!f)
//        {
//            throw new Exception("not id existing!");
//        }


//    }
//    public void Delete(int id)
//    {
//        foreach (var p in products)
//        {
//            if (id == p?.ProdId)
//            {
//                products.Remove(p);
//                return;
//            }
//        }
//        throw new NotImplementedException();

//    }
//}
