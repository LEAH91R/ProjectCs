using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DalXml
{
    internal static class Config
    {
        private static string FileName = "data-config";
        internal static int getStaticValueSale { 
                get => GetAndIncrement("staticValueSale");
            }
        internal static int getStaticValueCustomer
        {
            get => GetAndIncrement("staticValueCustomer");
        }
        internal static int getStaticValueProduct
        {
            get => GetAndIncrement("staticValueProduct");
        }
        private static int GetAndIncrement(string elementName)
        {
            if (!File.Exists(FileName))
                throw new Exception($"קובץ הקונפיגורציה לא נמצא בנתיב: {Path.GetFullPath(FileName)}");

            try
            {
                XElement root = XElement.Load(FileName);
                XElement? node = root.Element(elementName);

                if (node == null)
                    throw new Exception($"האלמנט {elementName} לא נמצא בקובץ הקונפיגורציה.");

                int currentVal = int.Parse(node.Value);
                int nextVal = currentVal + 1;

                // עדכון ושמירה לקובץ
                node.Value = nextVal.ToString();
                root.Save(FileName);

                return nextVal; // מחזירים את הערך המקודם (בדומה ל- ++NextId)
            }
            catch (Exception ex)
            {
                throw new Exception($"שגיאה בגישה לנתוני קונפיגורציה: {ex.Message}");
            }
        }
    }
    } 
}
