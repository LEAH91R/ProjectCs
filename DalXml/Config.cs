using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalXml
{
    internal static class Config
    {
        private static string FileName = "data-config";
        internal static int getStaticValueSale { get { return ++staticValueSale; } }
        internal static int getStaticValueCustomer { get => ++staticValueCustomer };
        internal static int getStaticValueProduct { get => ++staticValueProduct };
    } 
}
