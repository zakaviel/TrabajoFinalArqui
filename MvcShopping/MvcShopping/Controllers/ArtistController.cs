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
    public class ArtistController : ApiController
    {

        List<Artist> Artists = new List<Artist>();

        public ArtistController() { }

        public ArtistController(List<Artist> Artists)
        {
            this.Artists = Artists;
        }

        public IEnumerable<Artist> GetAllArtists()
        {
            return Artists;
        }

        public async Task<IEnumerable<Artist>> GetAllArtistsAsync()
        {
            return await Task.FromResult(GetAllArtists());
        }

        public IHttpActionResult GetArtist(int id)
        {
            var Artist = Artists.FirstOrDefault((p) => p.ArtistId == id);
            if (Artist == null)
            {
                return NotFound();
            }
            return Ok(Artist);
        }

        public async Task<IHttpActionResult> GetArtistAsync(int id)
        {
            return await Task.FromResult(GetArtist(id));
        }
    }
}
