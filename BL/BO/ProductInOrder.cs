using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class ProductInOrder
    {
        public int ProdId { get; set; }
       public string ProdName { get; set; } = string.Empty;
        public double ProdPrice { get; set; }
        public int QuantityInOrder { get; set; }
        public List<SaleInProduct> ListSaleInProduct { get; set; }
        public double finalPrice { get; set; }
        public override string ToString() => this.ToStringProperty();

        public ProductInOrder(int ProdId = 0, string? ProdName = null, double ProdPrice = 0, int QuantityInOrder = 0)
        {
            this.ProdId = ProdId;
            this.ProdName = ProdName ?? string.Empty;
            this.ProdPrice = ProdPrice;
            this.QuantityInOrder = QuantityInOrder;
            ListSaleInProduct = new List<SaleInProduct>();
            finalPrice = 0;
        }
    }
}
