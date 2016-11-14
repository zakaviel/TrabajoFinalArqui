using MvcShopping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcShopping.Controllers
{
    public class PaypalController : Controller
    {
        // GET: Paypal
        public ActionResult Index()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);

        
            cart.MigrateCart(User.Identity.Name);

            if (cart==null)
            {
                return RedirectToAction("ShoppingCart","Index");
            }

            var ls = cart.GetCartItems() ;

            

            return View(ls);
        }
        public ActionResult GetDataPaypal()
        {
           

            var getData = new GetDataPaypal();
            var order = getData.InformationOrder(getData.GetPayPalResponse(Request.QueryString["tx"]));
            ViewBag.tx = Request.QueryString["tx"];
            return View();
        }


    }
}