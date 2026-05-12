using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DalApi;
using BO;

namespace BL.BlApi
{
    public class IBl
    {
        IProduct Product { get; }
        ICustomer Customer { get; }
        ISale Sale { get; }
        IOrder Order { get; }
    }
}
