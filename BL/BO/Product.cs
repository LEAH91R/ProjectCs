using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.BO
{       public class Product
    {
        public int ProdId { get; init; }
        public string ProdName { get; set; } = string.Empty;
        public Categories Category { get; set; }
        public double ProdPrice { get; set; }
        public int QuantityInStock { get; set; }

        public override string ToString() => base.ToString();
    }

}

