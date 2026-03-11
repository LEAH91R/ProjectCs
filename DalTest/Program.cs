using DalApi;
using DO;
using Tools;


namespace DalTest;
public class program
{
    private static readonly IDal s_dal = DalApi.Factory.Get;
    public static void Main()
    {
        try
        {
            Initalization.initialize();
            Console.WriteLine("Data initialization completed.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred during DAL initialization: {ex.Message}");
            return;
        }
        int num = 0;
        do
        {
            Console.WriteLine("Please choose a type: ");
            Console.WriteLine("1.  Customer DAL");
            Console.WriteLine("2.  Product DAL");
            Console.WriteLine("3.  Sale DAL");
            Console.WriteLine("4. delete old log");
            Console.WriteLine("5. Exit");

            // safer parse
            var input = Console.ReadLine();
            if (!int.TryParse(input, out num))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                continue;
            }

            switch (num)
            {
                case 1:
                    CRUDcustomer(s_dal.Customer);
                    break;
                case 2:
                    CRUDproduct(s_dal.Product);
                    break;
                case 3:
                    CRUDsale(s_dal.Sale);
                    break;
                case 4:
                    LogManager.DeleteOldLogs();
                    break;
                case 5:
                    Console.WriteLine("Exiting the program.");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        } while (num != 5);

    }
    private static void CRUDcustomer(ICrud<Customer> customer)
    {
        int num = showMenu();
        switch (num)
        {
            case 1:
                customer.Create(detailsCustomer());
                break;
            case 2:
                Console.WriteLine(customer.Read(getId()));
                break;
            case 3:
                customer.Update(detailsCustomer(getId()));
                break;
            case 4:
                customer.Delete(getId());
                break;
            case 5:
                foreach (var cust in customer.ReadAll())
                {
                    Console.WriteLine(cust);
                }
                break;
            case 6:
                Console.WriteLine(customer.Read(c => c.CustName == "Tamar"));
                break;
            case 7:
                Console.WriteLine("Returning to main menu.");
                break;
            default:
                Console.WriteLine("Invalid choice. Please try again.");
                break;
        }
    }
    public static void CRUDproduct(ICrud<Product> product)
    {
        int num = showMenu();
        switch (num)
        {
            case 1:
                product.Create(detailsProduct());
                break;
            case 2:
                Console.WriteLine(product.Read(getId()));
                break;
            case 3:
                product.Update(detailsProduct(getId()));
                break;
            case 4:
                product.Delete(getId());
                break;
            case 5:
                foreach (var prod in product.ReadAll())
                {
                    Console.WriteLine(prod);
                }
                break;
            case 6:
                Console.WriteLine(product.Read(p => p.ProdName == "Puma"));
                break;
            case 7:
                Console.WriteLine("Returning to main menu.");
                break;
            default:
                Console.WriteLine("Invalid choice. Please try again.");
                break;
        }
    }
    private static void CRUDsale(ICrud<Sale> sale)
    {
        int num = showMenu();
        switch (num)
        {
            case 1:
                sale.Create(detailsSale());
                break;
            case 2:
                Console.WriteLine(sale.Read(getId()));
                break;
            case 3:
                sale.Update(detailsSale(getId()));
                break;
            case 4:
                sale.Delete(getId());
                break;
            case 5:
                foreach (var sal in sale.ReadAll())
                {
                    Console.WriteLine(sal);
                }
                break;
            case 6:
                Console.WriteLine(sale.Read(s => s.SalePrice == 150));
                break;
            case 7:
                Console.WriteLine("Returning to main menu.");

                break;
            default:
                Console.WriteLine("Invalid choice. Please try again.");
                break;
        }
    }
    private static Customer detailsCustomer(int id = 0)
    {
        Console.WriteLine("Please enter the customer details: ");
        Console.WriteLine("Name: ");
        Console.WriteLine("Address: ");
        Console.WriteLine("Phone: ");
        string name = Console.ReadLine()!;
        string address = Console.ReadLine()!;
        string phone = Console.ReadLine()!;
        return new Customer(id, name, address, phone);
    }
    private static Product detailsProduct(int id = 0)
    {
        Console.WriteLine("Please enter the product details: ");
        Console.WriteLine("Name: ");
        string name = Console.ReadLine()!;
        Console.WriteLine("Category: ");
        Categories category = (Categories)Enum.Parse(typeof(Categories), Console.ReadLine()!);
        Console.WriteLine("Price: ");
        double price = double.Parse(Console.ReadLine()!);
        Console.WriteLine("Quantity in stock:  ");
        int quantity = int.Parse(Console.ReadLine()!);
        return new Product(id, name, category, price, quantity);
    }
    private static Sale detailsSale(int id = 0)
    {
        Console.WriteLine("Please enter the sale details: ");
        Console.WriteLine("Product ID: ");
        int productId = int.Parse(Console.ReadLine()!);
        Console.WriteLine("Quantity: ");
        int quantity = int.Parse(Console.ReadLine()!);
        Console.WriteLine("Price per unit: ");
        double pricePerUnit = double.Parse(Console.ReadLine()!);
        Console.WriteLine("Is delivered (true/false): ");
        bool isDelivered = bool.Parse(Console.ReadLine()!);
        Console.WriteLine("start date (yyyy-MM-dd) or leave empty: ");
        string startDateInput = Console.ReadLine()!;
        DateTime? startDate = string.IsNullOrWhiteSpace(startDateInput) ? DateTime.Now : DateTime.Parse(startDateInput);
        Console.WriteLine("end date (yyyy-MM-dd) or leave empty: ");
        string endDateInput = Console.ReadLine()!;
        DateTime? endDate = string.IsNullOrWhiteSpace(endDateInput) ? DateTime.Now : DateTime.Parse(endDateInput);
        return new Sale(id, productId, quantity, pricePerUnit, isDelivered, startDate, endDate);
    }
    private static int getId()
    {
        Console.WriteLine("Please enter the ID: ");
        int id;
        while (!int.TryParse(Console.ReadLine(), out id))
        {
            Console.WriteLine("Invalid ID. Please enter a valid integer:");
        }
        return id;
    }

    private static int showMenu()
    {
        int num = 0;

        do
        {
            Console.WriteLine("Please choose a type: ");
            Console.WriteLine("1.  Create ");
            Console.WriteLine("2.  Read ");
            Console.WriteLine("3.  Update ");
            Console.WriteLine("4.  Delete ");
            Console.WriteLine("5.  ReadAll ");
            Console.WriteLine("6.  Read with filter");
            Console.WriteLine("7.  Back");

            var input = Console.ReadLine();
            if (!int.TryParse(input, out num))
            {
                Console.WriteLine("Invalid input. Enter number 1-7.");
                num = 0;
                continue;
            }
        } while (num < 1 || num > 7);

        return num;
    }
}
