using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Product.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            WebSiteEntities Context = new WebSiteEntities();
            ViewBag.data = Context.Products.ToList();
            
            return View();
        }
    }
}