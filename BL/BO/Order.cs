using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
     public class Order
    {
        public bool IsClub { get; set; }
        public List<ProductInOrder> TotalProductInOrder { get; set; }
        public double TotalPrice { get; set; }
        public override string ToString() => this.ToStringProperty();
        public Order(bool IsClub) { 
        this.IsClub = IsClub;
            TotalProductInOrder = new List<ProductInOrder>();
             TotalPrice = 0;
        }
    }
}
