using MarketInvoiceFruits.Logic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MarketInvoiceFruit.Web.Controllers
{
    public class FruitsController : Controller
    {
        public ActionResult List()
        {
            string basePath = FruitsLocation.GetBaseDirectory();

            var fruitsReader = new JsonFileSystemFruitsReader(basePath);

            var fruits = fruitsReader.ReadAllFruits().ToList();

            return View(fruits);
        }
    }
}