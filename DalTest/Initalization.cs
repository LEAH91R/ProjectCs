using DO;
using DalApi;
using Dal;

namespace DalTest; 

public static class Initalization
{
    private static IDal? s_dal;
private static void createSale(ISale si)
{

        si.Create(new Sale ( 1, 1, 100, 1.0, true, null, null ));
        si.Create(new Sale ( 2, 2, 200, 2.0, false, null, null ));
        si.Create(new Sale ( 3, 3, 150, 1.5, true, null, null ));
        si.Create(new Sale ( 4, 4, 300, 3.0, false, null, null ));
        si.Create (new Sale ( 5, 5, 250, 2.5, true, null, null ));
        si.Create (new Sale ( 6, 6, 120, 150, false, null, null ));
        si.Create (new Sale ( 7, 7, 180, 1.8, true, null, null ));
        si.Create (new Sale ( 8, 8, 220, 2.2, false, null, null ));


    }
private static void createCustomer(ICustomer ci)
{

        ci.Create(new Customer(1, "Tamar", "Herzel 5", "0583295797"));
        ci.Create(new Customer(2, "Shira", "Ben Gurion 10", "05556706410"));
        ci.Create(new Customer(3, "Tovi", "Jabotinsky 3", "0556751892"));
        ci.Create(new Customer(4, "Dvora", "Hertzelia", "0556743432"));
        ci.Create(new Customer(5, "Dvory", "Rabi akiva", "57453243"));
        ci.Create(new Customer(6, "Tamar", "Petah Tikva", "235437548"));
        ci.Create(new Customer(7, "Bina", "Mesilat yosef", "45636457"));
        ci.Create(new Customer(8, "Shosh", "Rashbi", "7456634"));
        ci.Create(new Customer(9, "Tsipora", "Meromei Sade", "6547568"));
        ci.Create(new Customer(10, "Yael", "Chazon david", "42556578"));
        ci.Create(new Customer(11, "Shimon", "Yatkovski 7", "6435342"));
        ci.Create(new Customer(12, "David", "Mesilat", "3534645"));
        ci.Create(new Customer(13, "Kobi", "Meromei Sade", "657658"));

    }
    private static void createProduct(IProduct pi)
    {
        pi.Create(new Product(1, "Puma", Categories.SHIRTS, 100, 50));
        pi.Create(new Product(2, "Adidas", Categories.PANTS, 150, 30));
        pi.Create(new Product(3, "Reebok", Categories.SOCKS, 80, 70));
        pi.Create(new Product(4, "Nike", Categories.PANTS, 200, 20));
        pi.Create(new Product(5, "Puma", Categories.SOCKS, 50, 100));
        pi.Create(new Product(6, "Castro", Categories.DRESSES, 300, 15));
        pi.Create(new Product(7, "Fox", Categories.PAJAMS, 250, 25));
        pi.Create(new Product(8, "Renuar", Categories.SHIRTS, 180, 40));
        pi.Create(new Product(9, "Zara", Categories.DRESSES, 400, 10));
    }
public static void initialize(IDal dal)
{
    s_dal = dal;
    createSale(s_dal.Sale);
    createCustomer(s_dal.Customer);
    createProduct(s_dal.Product);
}
}
