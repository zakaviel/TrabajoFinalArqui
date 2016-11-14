using MvcShopping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcShopping.DAL;

namespace MvcShopping.Controllers
{
    public class HomeController : Controller
    {
        MusicStoreEntities storeDB = new MusicStoreEntities();
        // GET: Home
        [AllowAnonymous]
        public ActionResult Index()
        {
      
            var cart = ShoppingCart.GetCart(this.HttpContext);
            
            Session["NumeroItems"] = 0;
            return View();
        }
        public ActionResult Temp()
        {
            return View();
        }
    }
}