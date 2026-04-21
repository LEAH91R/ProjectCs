using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{          public class Sale
        {
            public int SaleId { get; init; }
            public int ProdId { get; set; }
            public int QuantitySale { get; set; }
            public double SalePrice { get; set; }
            public bool IsClub { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }

        public override string ToString() => this.ToStringProperty();

        public Sale(int SaleId = 0, int ProdId = 0, int QuantitySale = 0, double SalePrice = 0, bool IsClub = false, DateTime? StartDate = null, DateTime? EndDate = null)
            {
                this.SaleId = SaleId;
                this.ProdId = ProdId;
                this.QuantitySale = QuantitySale;
                this.SalePrice = SalePrice;
                this.IsClub = IsClub;
                this.StartDate = StartDate ?? DateTime.Now;
                this.EndDate = EndDate ?? DateTime.Now.AddDays(7);
        }
    }
}

