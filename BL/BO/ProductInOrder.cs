using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.BO
{
    public class ProductInOrder
    {
        public int ProdId { get; set; }
       public string ProdName { get; set; } = string.Empty;
        public double ProdPrice { get; set; }
        public int QuantityInOrder { get; set; }
        public List<SaleInProduct> ListSaleInProduct { get; set; }
        public double finalPrice { get; set; }
        public override string ToString() => base.ToString();
    }
}
