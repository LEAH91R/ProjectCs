using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{       public class Product
    {

        public int ProdId { get; init; }
        public string ProdName { get; set; } = string.Empty;
        public Categories ? Category { get; set; }
        public double ProdPrice { get; set; }
        public int QuantityInStock { get; set; }
        public List<SaleInProduct> ListSaleInProduct { get; set; }

        public override string ToString() => this.ToStringProperty();

        public Product(int ProdId = 0, string? ProdName = null, Categories? category, double ProdPrice = 0, int QuantityInStock = 0)
        {
            this.ProdId = ProdId;
            this.ProdName = ProdName ?? string.Empty;
            this.Category = category;
            this.ProdPrice = ProdPrice;
            this.QuantityInStock = QuantityInStock;
            ListSaleInProduct = new List<SaleInProduct>();
        }
    }

}

