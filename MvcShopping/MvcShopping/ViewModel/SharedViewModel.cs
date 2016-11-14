using MvcShopping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcShopping.DAL;
namespace MvcShopping.ViewModel
{
    public abstract class SharedViewModel
    {
        MusicStoreEntities storeDB = new MusicStoreEntities();

        public List<Genre> GetListGenres()
        {
            var genres = storeDB.Genres.ToList();

            return genres;
        }
    }
}