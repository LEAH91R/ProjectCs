using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.BO
{          public class Sale
        {
            public int SaleId { get; init; }
            public int ProdId { get; set; }
            public int QuantitySale { get; set; }
            public double SalePrice { get; set; }
            public bool IsClub { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }

            public override string ToString() => base.ToString();
        }
}

