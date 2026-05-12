//using DO;
using DalApi;
using BO;


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
