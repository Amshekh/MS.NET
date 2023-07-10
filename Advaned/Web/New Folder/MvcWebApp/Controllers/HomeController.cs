using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcWebApp.Controllers
{
    using Models;

    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            using (ShopEntities shop = new ShopEntities())
            {
                return View(shop.Products.ToList());
            }
        }

        public ActionResult Details(int id)
        {
            ViewData["ProductNo"] = id;

            using (ShopEntities shop = new ShopEntities())
            {
                Product product = shop.Products.Single(p => p.ProductNo == id);
                return View(product.OrderDetails.ToList());
            }
        }

        public ActionResult Create()
        {
            return View(new ProductDto());
        }

        [HttpPost]
        public ActionResult Create(ProductDto product)
        {
            if (ModelState.IsValid)
            {
                product.Insert();
                return RedirectToAction("Index");
            }

            return View(product);
        }
    }
}
