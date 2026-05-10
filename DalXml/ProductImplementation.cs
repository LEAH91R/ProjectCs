using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
    {
        internal class ProductImplementation : IProduct
        {
            readonly string s_path = @"xml\products.xml";

            public int Create(Product item)
            {
                List<Product> list = XMLTools.LoadListFromXmlSerializer<Product>(s_path);
                int nextId = Config.ProductId;

                Product newItem = item with { Id = nextId }; // יצירת עותק עם ה-ID החדש
                list.Add(newItem);

                XMLTools.SaveListToXmlSerializer(list, s_path);
                return nextId;
            }

            public Product? Read(int id) =>
                XMLTools.LoadListFromXmlSerializer<Product>(s_path).FirstOrDefault(p => p.Id == id);

            public Product? Read(Func<Product, bool> filter) =>
                XMLTools.LoadListFromXmlSerializer<Product>(s_path).FirstOrDefault(filter);

            public List<Product> ReadAll(Func<Product, bool>? filter = null)
            {
                List<Product> list = XMLTools.LoadListFromXmlSerializer<Product>(s_path);
                return filter == null ? list : list.Where(filter).ToList();
            }

            public void Update(Product item)
            {
                List<Product> list = XMLTools.LoadListFromXmlSerializer<Product>(s_path);
                int index = list.FindIndex(p => p.Id == item.Id);

                if (index == -1) throw new Exception("Product not found");

                list[index] = item;
                XMLTools.SaveListToXmlSerializer(list, s_path);
            }

            public void Delete(int id)
            {
                List<Product> list = XMLTools.LoadListFromXmlSerializer<Product>(s_path);
                Product? item = list.FirstOrDefault(p => p.Id == id);

                if (item == null) throw new Exception("Product not found");

                list.Remove(item);
                XMLTools.SaveListToXmlSerializer(list, s_path);
            }
        }
    }

