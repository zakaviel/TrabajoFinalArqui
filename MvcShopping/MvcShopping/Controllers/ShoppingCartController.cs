using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcShopping.Models;
using MvcShopping.ViewModel;
using MvcShopping.DAL;

namespace MvcShopping.Controllers
{
    public class ShoppingCartController : Controller
    {
        MusicStoreEntities storeDB = new MusicStoreEntities();
        public PartialViewResult _GenresList()
        {
            var genres = storeDB.Genres.ToList();
            return PartialView("~/Views/Shared/_GenresList.cshtml", genres);
        }

        //
        // GET: /ShoppingCart/
        public ActionResult Index()
        {
            
            var cart = ShoppingCart.GetCart(this.HttpContext);

            

            // Set up our ViewModel
            var viewModel = new ShoppingCartViewModel
            {
                CartItems = cart.GetCartItems(),
                CartTotal = cart.GetTotal()
            };
            // Return the view
            return View(viewModel);
        }
        //
        // GET: /Store/AddToCart/5
        public ActionResult AddToCart(int id)
        {
            // Retrieve the album from the database
            var addedAlbum = storeDB.Albums
                .Single(album => album.AlbumId == id);

            addedAlbum.Genre.Name.ToString();

            // Add it to the shopping cart
            var cart = ShoppingCart.GetCart(this.HttpContext);

            cart.AddToCart(addedAlbum);

            Session["NumeroItems"] = (cart==null?0:cart.GetCount());
            // Go back to the main store page for more shopping
            String genre =addedAlbum.Genre.Name.ToString();
            var genreModel = storeDB.Genres.Include("Albums").Single(g => g.Name == genre);

            var results = new ShoppingCartRemoveViewModel
            {
                Message = Server.HtmlEncode(addedAlbum.Title) +
                     " has been Add to your shopping cart."
               
            };
           
            return Json(results);
        }
        //
        // AJAX: /ShoppingCart/RemoveFromCart/5
        [HttpPost]
        public ActionResult RemoveFromCart(int id)
        {
            // Remove the item from the cart
            var cart = ShoppingCart.GetCart(this.HttpContext);

            // Get the name of the album to display confirmation
            string albumName = storeDB.Carts
                .Single(item => item.RecordId == id).Album.Title;

            // Remove from cart
            int itemCount = cart.RemoveFromCart(id);

            // Display the confirmation message
            var results = new ShoppingCartRemoveViewModel
            {
                Message = Server.HtmlEncode(albumName) +
                    " has been removed from your shopping cart.",
                CartTotal = cart.GetTotal(),
                CartCount = cart.GetCount(),
                ItemCount = itemCount,
                DeleteId = id
            };
            Session["NumeroItems"] = (results==null?0:results.CartCount);
            return Json(results);
        }
        //
        // GET: /ShoppingCart/CartSummary
        [ChildActionOnly]
        public ActionResult CartSummary()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);

            ViewData["CartCount"] = (cart==null?0:cart.GetCount());

            return PartialView("CartSummary");
        }
    }
}