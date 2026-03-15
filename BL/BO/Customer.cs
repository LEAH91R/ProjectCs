using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.BO
{
    class Customer
    {
         public int CustId { get; init; }
        public string CustName { get; set; } = string.Empty;
        public string CustAddress { get; set; } = string.Empty;
        public string CustPhone { get; set; } = string.Empty;
        public override string ToString() => base.ToString();
    }
}




