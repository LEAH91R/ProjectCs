using DO;
using DalApi;
using static Dal.DataSource;
using Tools;
using System.Reflection;
using BO;
using BL.BO;

namespace Dal;

internal class OrderImplementation : SaleInProduct
{
    public int Create(Order item)
    {
        LogManager.Log(MethodBase.GetCurrentMethod().DeclaringType.FullName,
            MethodBase.GetCurrentMethod().Name, $"Attempting to create order for customer ID: {item.CustomerId}");

        // יצירת מזהה רץ אוטומטי להזמנה
        Order finalizedItem = item with { Id = Config.getStaticValueProduct };
        DataSource.SaleInProduct.Add(finalizedItem);

        LogManager.Log(MethodBase.GetCurrentMethod().DeclaringType.FullName,
            MethodBase.GetCurrentMethod().Name, $"Order created successfully. New ID: {finalizedItem.Id}");

        return finalizedItem.Id;
    }

    public Order? Read(int id)
    {
        LogManager.Log(MethodBase.GetCurrentMethod().DeclaringType.FullName,
            MethodBase.GetCurrentMethod().Name, $"Reading order with ID: {id}");

        var order = DataSource.SaleInProduct.FirstOrDefault(o => o?.Id == id);

        if (order == null)
            LogManager.Log(MethodBase.GetCurrentMethod().DeclaringType.FullName,
                MethodBase.GetCurrentMethod().Name, $"Order with ID {id} not found.");

        return order;
    }

    public Order? Read(Func<Order, bool> filter)
    {
        LogManager.Log(MethodBase.GetCurrentMethod().DeclaringType.FullName,
            MethodBase.GetCurrentMethod().Name, "Reading order using filter.");

        return DataSource.SaleInProduct.FirstOrDefault(o => o != null && filter(o));
    }

    public List<Order?> ReadAll(Func<Order, bool>? filter = null)
    {
        LogManager.Log(MethodBase.GetCurrentMethod().DeclaringType.FullName,
            MethodBase.GetCurrentMethod().Name, filter == null ? "Reading all orders." : "Reading orders with filter.");

        if (filter == null)
        {
            return DataSource.SaleInProduct.Select(o => o == null ? null : new Order
            {
                Id = o.Id,
                CustomerId = o.CustomerId,
                OrderDate = o.OrderDate,
                TotalPrice = o.TotalPrice
            }).ToList();
        }

        return DataSource.SaleInProduct
            .Where(o => o != null && filter(o))
            .Select(o => o == null ? null : new Order
            {
                Id = o.Id,
                CustomerId = o.CustomerId,
                OrderDate = o.OrderDate,
                TotalPrice = o.TotalPrice
            }).ToList();
    }

    public void Update(Order item)
    {
        LogManager.Log(MethodBase.GetCurrentMethod().DeclaringType.FullName,
            MethodBase.GetCurrentMethod().Name, $"Updating order with ID: {item.Id}");

        var oldItem = DataSource.SaleInProduct.FirstOrDefault(o => o?.Id == item.Id);
        if (oldItem == null)
        {
            LogManager.Log(MethodBase.GetCurrentMethod().DeclaringType.FullName,
                MethodBase.GetCurrentMethod().Name, $"Error: Order with ID {item.Id} not found for update.");
            throw new IdNotFoundException(item.Id, "Order");
        }

        int index = DataSource.SaleInProduct.IndexOf(oldItem);
        DataSource.SaleInProduct[index] = item;

        LogManager.Log(MethodBase.GetCurrentMethod().DeclaringType.FullName,
            MethodBase.GetCurrentMethod().Name, $"Order with ID {item.Id} updated successfully.");
    }

    public void Delete(int id)
    {
        LogManager.Log(MethodBase.GetCurrentMethod().DeclaringType.FullName,
            MethodBase.GetCurrentMethod().Name, $"Attempting to delete order with ID: {id}");

        var order = DataSource.SaleInProduct.FirstOrDefault(o => o?.Id == id);
        if (order == null)
        {
            LogManager.Log(MethodBase.GetCurrentMethod().DeclaringType.FullName,
                MethodBase.GetCurrentMethod().Name, $"Error: Order with ID {id} not found for deletion.");
            throw new IdNotFoundException(id, "Order");
        }

        DataSource.SaleInProduct.Remove(order);

        LogManager.Log(MethodBase.GetCurrentMethod().DeclaringType.FullName,
            MethodBase.GetCurrentMethod().Name, $"Order with ID {id} deleted successfully.");
    }
}