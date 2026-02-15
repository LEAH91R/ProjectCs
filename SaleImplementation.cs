using DalApi;
using DO;
using static Dal.DataSource;
using Tools;
namespace Dal
{
    internal class SaleImplementation : ISale
    {
        public int Create(Sale item)
        {
            foreach (var s in Sales) 
            {
                if (item?.SaleId == s.SaleId)
                {
                    throw new Exception($"Sale with Id {s?.SaleId} already exists");
                }
            }
            int id = Config.getStaticValue;
            Sale sale = s with { SaleId=id};
            Sales.Add(sale);
            return id;
        }
        public Sale Read(int id)
        {
            foreach (var s in Sales)
            {
                if (item?.SaleId == s.SaleId)
                {
                    return s;
                }
            }
            throw new Exception($"Sale with Id {id} not found");

            throw new NotImplementedException();
        }
        public Sale ReadAll()
        {
            if (Sales != null) {  return Sales;}
               
            throw new NotImplementedException();
        }
        public void Update(Sale item)
        {
            foreach (var s in Sales)
            {
                if (item?.SaleId == s.SaleId)
                {
                    sales.remove(s);
                    sales.add(item);
                    //s.ProdId = item.ProdId;
                    //s.QuantitySale = item.QuantitySale;
                    //s.SalePrice = item.SalePrice;
                    //s.IsClub = item.IsClub;
                    //s.StartDate = item.StartDate;
                    //s.EndDate = item.EndDate;   
                    return;
                }
            }
            throw new NotImplementedException();
        }
        public void Delete(int id)
        {

            foreach (var s in Sales)
            {
                if (item?.SaleId == s.SaleId)
                {
                    sales.remove(s);
                }
            }
        }
    }
}
