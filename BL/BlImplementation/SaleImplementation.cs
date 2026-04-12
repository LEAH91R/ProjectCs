using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DalXml;
using DO;
using System.Xml.Linq;

namespace Dal
{
    internal class SaleImplementation: ISale
    {
        כדי להתקדם במימוש ה-CRUD עבור כל הישויות, בואו נבנה את התשתית בצורה מסודרת.כפי שביקשתן, נממש את הפעולות בעזרת שתי השיטות(Serializer ו-Linq to XML).

הכנתי לכן כאן את המימוש המלא עבור שתי ישויות מרכזיות, כך שתוכלו להעתיק ולשנות את השאר לפי אותו דגם.

1. מימוש ישות ה-Sale (בשיטת XmlSerializer)
זו השיטה המומלצת לרוב הישויות כי היא הכי פשוטה לתחזוקה.

C#

using DalApi;
using DO;

namespace Dal;

    internal class SaleImplementation : ISale
    {
        // פונקציות עזר לטעינה ושמירה מהירה
        private List<Sale> Load() => XMLTools.LoadListFromXmlSerializer<Sale>("sales");
        private void Save(List<Sale> list) => XMLTools.SaveListToXmlSerializer(list, "sales");

        public int Create(Sale item)
        {
            var sales = Load();

            // קבלת מספר רץ מהקונפיגורציה שיצרתן
            int nextId = Config.getStaticValueSale;

            // יצירת מופע חדש עם ה-ID שקיבלנו
            Sale newSale = item with { SaleId = nextId };

            sales.Add(newSale);
            Save(sales);
            return nextId;
        }

        public Sale? Read(int id) => Load().FirstOrDefault(s => s.SaleId == id);

        public IEnumerable<Sale?> ReadAll(Func<Sale, bool>? filter = null)
        {
            var sales = Load();
            return filter == null ? sales : sales.Where(filter);
        }

        public void Update(Sale item)
        {
            var sales = Load();
            // מחיקת הישן והוספת החדש (כי זה record)
            if (sales.RemoveAll(s => s.SaleId == item.SaleId) == 0)
                throw new Exception("Sale not found");

            sales.Add(item);
            Save(sales);
        }

        public void Delete(int id)
        {
            var sales = Load();
            if (sales.RemoveAll(s => s.SaleId == id) == 0)
                throw new Exception("Sale not found");
            Save(sales);
        }
}
