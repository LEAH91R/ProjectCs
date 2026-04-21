using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class SaleInProduct
    {
        public int ProdId { get; set; }
        public int QuantityInSale { get; set; }
        public double Price { get; set; }
        public bool ForClub { get; set; }
        public override string ToString() => this.ToStringProperty();

        public SaleInProduct(int ProdId,int QuantityInSale, double Price, bool ForClub) {
            this.ProdId = ProdId;
            this.QuantityInSale = QuantityInSale;
            this.Price = Price;
            this.ForClub = ForClub;
        }

    }
}
