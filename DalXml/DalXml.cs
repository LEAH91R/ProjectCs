
using DalApi;

namespace Dal
{
    public class DalXml : IDal
    {
        public IProduct Product => new ProductImplementation();
        public ICustomer Customer => new CustomerImplementation();
        public ISale Sale => new SaleImplementation();
        public static readonly  DalXml instance= new DalXml();
        public static DalXml Instance { get { return instance; } }
    }
}
