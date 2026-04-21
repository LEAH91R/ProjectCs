using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.BO;

namespace BL.BlApi
{
    public interface IOrder : ICrud<Order>
    {
        //List<SaleInProduct> AddProductToOrder(Order order, int productId, int amount);
    }
}
