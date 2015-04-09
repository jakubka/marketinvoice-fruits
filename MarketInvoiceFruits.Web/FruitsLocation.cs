using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace MarketInvoiceFruit.Web
{
    public class FruitsLocation
    {
        public static string GetBaseDirectory()
        {
            return Path.Combine(new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory).Parent.FullName, "StateTest");
        }
    }
}