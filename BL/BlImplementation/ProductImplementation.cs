using DalApi;
using System.Xml.Linq;
using BO;

namespace Dal
{
    internal class ProductImplementation : IProduct
    {
        readonly string filePath = @"..\xml\products.xml";

        public int Create(Product item)
        {
            XElement root = XElement.Load(filePath);
            int nextId = Config.getStaticValueProduct;

            XElement prod = new XElement("Product",
                new XElement("ProdId", nextId),
                new XElement("ProdName", item.ProdName),
                new XElement("category", item.category.ToString()), // המרת Enum למחרוזת
                new XElement("ProdPrice", item.ProdPrice),
                new XElement("QuantityInStock", item.QuantityInStock)
            );

            root.Add(prod);
            root.Save(filePath);
            return nextId;
        }

        public int Create(DO.Product t)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Product? Read(int id)
        {
            XElement root = XElement.Load(filePath);

            return (from p in root.Elements()
                    where (int?)p.Element("ProdId") == id
                    select new Product
                    {
                        ProdId = (int)p.Element("ProdId")!,
                        ProdName = (string?)p.Element("ProdName"),
                        category = Enum.Parse<Categories>((string)p.Element("category")!),
                        ProdPrice = (double)(double?)p.Element("ProdPrice"),
                        QuantityInStock = (int)(int?)p.Element("QuantityInStock")
                    }).FirstOrDefault();
        }

        public DO.Product? Read(Func<DO.Product, bool> filter)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product?> ReadAll(Func<Product, bool>? filter = null)
        {
            XElement root = XElement.Load(filePath);

            var products = from p in root.Elements()
                           select new Product
                           {
                               ProdId = (int)p.Element("ProdId")!,
                               ProdName = (string?)p.Element("ProdName"),
                               category = Enum.Parse<Categories>((string)p.Element("category")!),
                               ProdPrice = (double?)p.Element("ProdPrice"),
                               QuantityInStock = (int?)p.Element("QuantityInStock")
                           };

            return filter == null ? products : products.Where(filter);
        }

        public List<DO.Product?> ReadAll(Func<DO.Product?, bool>? filter = null)
        {
            throw new NotImplementedException();
        }

        public void Update(DO.Product t)
        {
            throw new NotImplementedException();
        }

        DO.Product? ICrud<DO.Product>.Read(int id)
        {
            throw new NotImplementedException();
        }

        // במימוש Update ו-Delete ב-XElement, מחפשים את ה-Element לפי ה-ID ומוחקים/מעדכנים אותו מה-Root
    }
}
