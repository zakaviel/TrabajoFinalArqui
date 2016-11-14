using MvcShopping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace MvcShopping.Controllers
{
    public class GenreController : ApiController
    {

        List<Genre> Genres = new List<Genre>();

        public GenreController() { }

        public GenreController(List<Genre> Genres)
        {
            this.Genres = Genres;
        }

        public IEnumerable<Genre> GetAllGenres()
        {
            return Genres;
        }

        public async Task<IEnumerable<Genre>> GetAllGenresAsync()
        {
            return await Task.FromResult(GetAllGenres());
        }

        public IHttpActionResult GetGenre(int id)
        {
            var Genre = Genres.FirstOrDefault((p) => p.GenreId == id);
            if (Genre == null)
            {
                return NotFound();
            }
            return Ok(Genre);
        }

        public async Task<IHttpActionResult> GetGenreAsync(int id)
        {
            return await Task.FromResult(GetGenre(id));
        }
    }
}
