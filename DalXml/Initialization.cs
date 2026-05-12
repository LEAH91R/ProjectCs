using DO;
using DalApi;

namespace Dal;

public static class Initialization
{
    private static IDal? s_dal;

    /// <summary>
    /// פונקציית האתחול הראשית - נקראת מהבנאי של DalXml
    /// </summary>
    /// <param name="dal">המופע של ה-DAL שדרכו נשמור את הנתונים</param>
    public static void Do(IDal dal)
    {
        s_dal = dal;

        try
        {
            // אם הלקוחות לא קיימים - צור אותם
            if (!s_dal.Customer.ReadAll().Any())
                CreateCustomers();

            // אם המוצרים לא קיימים - צור אותם
            if (!s_dal.Product.ReadAll().Any())
                CreateProducts();

            // אם המכירות לא קיימות - צור אותן
            if (!s_dal.Sale.ReadAll().Any())
                CreateSales();
        }
        catch (Exception ex)
        {
            // זריקת השגיאה למעלה - ה-UI יתפוס אותה ויציג אותה
            throw new Exception($"Initialization failed: {ex.Message}", ex);
        }
    }

    private static void CreateCustomers()
    {
        string[] names = { "tamar", "chani", "leah ", "tovi", "dvora" };
        string[] cities = { "Boltimore", "Jerusalem", "New Jersey", "Tel Aviv", "New York" };

        for (int i = 0; i < names.Length; i++)
        {
            s_dal!.Customer.Create(new Customer
            {
                CustomerName = names[i],
                Address = cities[i],
                PhoneNumber = $"058578665{i}",
                IsClubMember = i % 2 == 0
            });
        }
    }

    private static void CreateProducts()
    {
        string[] SOCKSNames =
  {

  "Ankle Socks",   // גרבי קרסול
  "Crew Socks",    // גרביים רגילים (חצי גובה)
  "Knee Highs",    // גרביים עד הברך
  "Quarter Socks", // גרבי רבע
  "No Show Socks", // גרביים נסתרים
  "Thermal Socks"  // גרביים תרמיים

    };

        string[] SHIRTSNames =
        {
   "T-Shirt",        // חולצת טי
  "Polo Shirt",     // חולצת פולו
  "Button-Down",    // חולצה מכופתרת
  "Dress Shirt",    // חולצת ערב/חגיגית
  "Oxford Shirt",   // חולצת אוקספורד
  "Flannel Shirt",  // חולצת פלנל (משובצת)
  "V-Neck",         // חולצת וי
  "Long Sleeve"
};

        string[] PAJAMSNames =
        {
"Flannel Set",      // סט פלנל
  "Cotton Pajamas",   // פיג'מת כותנה
  "Button-Up Set",    // סט מכופתר
  "Thermal Sleepwear", // בגדי שינה תרמיים
  "Two-Piece Set",    // סט שני חלקים
  "Fleece Pajamas",   // פיג'מת פליז
  "Classic Sleepwear" // בגדי שינה קלאסיים
};

        string[] PANTSNames =
        {
   "Casual Chinos",    // מכנסי צ'ינו
  "Denim Jeans",      // ג'ינס
  "Dress Trousers",   // מכנסיים מחויטים/רשמיים
  "Cargo Pants",      // מכנסי דגמ"ח
  "Sweatpants",       // מכנסי פוטר/טרנינג
  "Corduroy Pants",   // מכנסי קורדרוי
  "Khaki Pants",      // מכנסי חאקי
  "Linen Trousers"    // מכנסי פשתן
};

        string[] DRESSESNames =
        {
    "A-Line Dress",    // שמלת איי-ליין (גזרה מתרחבת)
  "Maxi Dress",      // שמלת מקסי (ארוכה)
  "Midi Dress",      // שמלת מידי (באורך בינוני)
  "Pleated Dress",   // שמלת פליסה (קפלים)
  "Button-Up Dress", // שמלת כפתורים
  "Shift Dress",     // שמלת שיפט (גזרה ישרה)
  "Wrap Dress"       // שמלת מעטפת
};

        foreach (var name in SOCKSNames)
            s_dal.Product?.Create(new()
            {
                Name = name,
                Category = Categories.SOCKS,
                Price = 400,
                Quantity = 30
            });


        foreach (var name in SHIRTSNames)
            s_dal.Product?.Create(new()
            {
                Name = name,
                Category = Categories.SHIRTS,
                Price = 300,
                Quantity = 20
            });


        foreach (var name in PAJAMSNames)
            s_dal.Product?.Create(new()
            {
               
                Name = name,
                Category = Categories.PAJAMS,
                Price = 60,
                Quantity = 14
            });


        foreach (var name in PANTSNames)
            s_dal.Product?.Create(new()
            {
                Name = name,
                Category = Categories.PANTS,
                Price = 200,
                Quantity = 16
            });


        foreach (var name in DRESSESNames)
            s_dal.Product?.Create(new()
            {
                Name = name,
                Category = Categories.DRESSES,
                Price = 100,
                Quantity = 15
            });



    }

    private static void CreateSales()
    {
        var productsList = s_dal!.Product.ReadAll().ToList();

        for (int i = 0; i < productsList.Count; i++)
        {
            s_dal.Sale.Create(new Sale
            {
                ProductId = productsList[i]!.Id,
                RequiredQuantity = i + 1,
                DiscountedPrice = productsList[i]!.Price * 0.8,
                IsForClubMembers = i % 2 == 0,
                SaleStartDate = DateTime.Now,
                SaleEndDate = DateTime.Now.AddMonths(1)
            });
        }
    }
}