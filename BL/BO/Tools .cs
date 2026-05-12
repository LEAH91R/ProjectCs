using DO;
using System.Collections;
using System.Reflection;
using System.Text;

namespace BO
{
    internal static class Tools
    {
        public static string ToStringProperty<T>(this T obj, string prefix = "")
        {
            StringBuilder sb = new StringBuilder();
            var properties = typeof(T)?.GetProperties();
            if (properties == null) throw new Exception("OBJECT IS NULL");
            foreach (var prop in properties)
            {
                if (prop.PropertyType.IsPrimitive || prop.PropertyType == typeof(string) || prop.PropertyType == typeof(DateTime))
                {
                    var value = prop.GetValue(obj);
                    sb.AppendLine($"{prefix}{prop.Name}: {value}");
                }
                else
                {
                    Console.WriteLine($"{prefix}{prop.Name}:");
                    sb.AppendLine(prop.Name);
                }
            }

            return sb.ToString();
        }
        public static string ToStringProperty<T>(this T t)
        {
            string str = "";
            Type type = t.GetType();
            PropertyInfo[] properties = type.GetProperties();
            foreach (PropertyInfo property in properties)
            {
                if (typeof(IEnumerable).IsAssignableFrom(property.PropertyType) && property.PropertyType != typeof(string))
                {
                    str += $"{property.Name}:\n";
                    IEnumerable enumerable = property.GetValue(t) as IEnumerable;
                    if (enumerable != null)
                    {
                        foreach (var item in enumerable)
                        {
                            str += item.ToStringProperty();
                        }
                    }

                }
                else
                    str += $"{property.Name}: {property.GetValue(t)}\n";
            }
            return str;
        }
        public static DO.Product ConvertToDO(this BO.Product p)
        {
            return new DO.Product
            {
                ProdId = p.ProdId,
                ProdName = p.ProdName,
                category = (DO.Categories)Enum.Parse(typeof(DO.Categories), p.Category.ToString()),
                ProdPrice = p.ProdPrice,
                QuantityInStock = p.QuantityInStock
            };
        }
        public static BO.Product ConvertToBO(this DO.Product p)
        {
            return new BO.Product
            (
                ProdId: p.ProdId,
                ProdName: p.ProdName,
                category: (BO.Categories?)Enum.Parse(typeof(BO.Categories), p.category.ToString()),
                ProdPrice: p.ProdPrice ?? 0,
                QuantityInStock: p.QuantityInStock ?? 0
            );
        }
        public static DO.Customer ConvertToDO(this BO.Customer c)
        {
            return new DO.Customer
            {
                CustId = c.CustId,
                CustName = c.CustName,
                CustPhone = c.CustPhone,
                CustAddress = c.CustAddress
            };
        }
        public static BO.Customer ConvertToBO(this DO.Customer c)
        {
            return new BO.Customer
            (
                CustId: c.CustId,
                CustName: c.CustName,
                CustPhone: c.CustPhone,
                CustAddress: c.CustAddress
            );
        }
        public static DO.Sale ConvertToDO(this BO.Sale s)
        {
            return new DO.Sale
            {
                SaleId = s.SaleId,
                ProdId = s.ProdId,
                QuantitySale = s.QuantitySale,
                SalePrice = s.SalePrice,
                IsClub = s.IsClub,
                StartDate = s.StartDate,
                EndDate = s.EndDate
            };
        }
        public static BO.Sale ConvertToBO(this DO.Sale s)
        {
            return new BO.Sale
            (
                SaleId: s.SaleId,
                ProdId: s.ProdId,
                QuantitySale: s.QuantitySale ?? 0,
                SalePrice: s.SalePrice ?? 0,
                IsClub: s.IsClub ?? false,
                StartDate: s.StartDate ?? DateTime.Now,
                EndDate: s.EndDate ?? DateTime.Now.AddDays(7)
            );
        }
        public static BO.SaleInProduct ConvertSaleToSaleInProduct(this DO.Sale s)
        {
            return new BO.SaleInProduct
            (
                ProdId: s.ProdId,
                QuantityInSale: s.QuantitySale ?? 0,
                Price: s.SalePrice ?? 0,
               ForClub: s.IsClub ?? false
            );
        }
        public static BO.ProductInOrder ConvertSaleToProductInOrder(this DO.Product s)
        {
            return new BO.ProductInOrder
            (
                ProdId: s.ProdId,
                ProdName: s.ProdName,
                ProdPrice: s.ProdPrice ?? 0,
                QuantityInOrder: s.QuantityInStock ?? 0

                );
        }
    }
}              
                
                