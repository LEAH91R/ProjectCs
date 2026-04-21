using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
   public class Customer
    {
         public int CustId { get; init; }
        public string CustName { get; set; } = string.Empty;
        public string CustAddress { get; set; } = string.Empty;
        public string CustPhone { get; set; } = string.Empty;
        public override string ToString() => this.ToStringProperty();
        public Customer(int CustId = 0, string? CustName = null, string? CustAddress = null, string? CustPhone = null) {
            this.CustId = CustId;
            this.CustName = CustName ?? string.Empty;
            this.CustAddress = CustAddress ?? string.Empty;
            this.CustPhone = CustPhone ?? string.Empty;
        }
    }
}




