using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.BO
{
     public class Order
    {
        public bool IsClub { get; set; }
        public ProductInOrder AllProductInOrder { get; set; }
        public double AllPrice { get; set; }
    }
}
