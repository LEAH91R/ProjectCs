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
                CustName = names[i],
                CustAddress = cities[i],
                CustPhone = $"058578665{i}"
              
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
                ProdName = name,
                category = Categories.SOCKS,
                ProdPrice = 400,
                QuantityInStock = 30
            });


        foreach (var name in SHIRTSNames)
            s_dal.Product?.Create(new()
            {
                ProdName = name,
                category = Categories.SHIRTS,
                ProdPrice = 300,
                QuantityInStock = 20
            });


        foreach (var name in PAJAMSNames)
            s_dal.Product?.Create(new()
            {
               
                ProdName = name,
                category = Categories.PAJAMS,
                ProdPrice = 60,
                QuantityInStock = 14
            });


        foreach (var name in PANTSNames)
            s_dal.Product?.Create(new()
            {
                ProdName = name,
                category = Categories.PANTS,
                ProdPrice = 200,
                QuantityInStock = 16
            });


        foreach (var name in DRESSESNames)
            s_dal.Product?.Create(new()
            {
                ProdName = name,
                category = Categories.DRESSES,
                ProdPrice = 100,
                QuantityInStock = 15
            });



    }

    private static void CreateSales()
    {
        var productsList = s_dal!.Product.ReadAll().ToList();

        for (int i = 0; i < productsList.Count; i++)
        {
            s_dal.Sale.Create(new Sale
            {
                ProdId = productsList[i]!.ProdId,
                QuantitySale = i + 1,
               SalePrice = productsList[i]!.ProdPrice * 0.8,
                IsClub = i % 2 == 0,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddMonths(1)
            });
        }
    }
}