using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcShopping.Models;
using MvcShopping.DAL;


namespace MvcShopping.Controllers
{
    public class StoreController : Controller
    {
        MusicStoreEntities storeDB = new MusicStoreEntities();
        public PartialViewResult _GenresList()
        {
            try
            {
                

                var genres = storeDB.Genres.ToList();

                return PartialView("~/Views/Shared/_GenresList.cshtml", genres);
            }
            catch(Exception ex)
            {
                ex.GetBaseException();
                
                return PartialView();
            }

        }

        // GET: Store
        public ActionResult Index()
        {
            

            return View();
        }
        public ActionResult Browse(string genre) //esto deberia ser un json
        {
            
            //var genreModel = new Genre { Name = genre };

            try
            {
                var genreModel = storeDB.Genres.Include("Albums")
                .Single(g => g.Name == genre);
                return View(genreModel);
            }catch(Exception ex)
            {
                return RedirectToAction("Index");
            }
            
        }
        public ActionResult BrowseSearch(string searchString) //esto deberia ser un json
        {
            
            //var genreModel = new Genre { Name = genre };
            var albumsModel= storeDB.Albums.Where(s => s.Title.Contains(searchString)
                                       || s.Artist.Name.Contains(searchString));
            return View(albumsModel);
        }
        
        public ActionResult Details(int id)
        {
            
            //var album = new Album { Title = "Album " + id };
            var album = storeDB.Albums.Find(id);
            return View(album);
        }
    }
}