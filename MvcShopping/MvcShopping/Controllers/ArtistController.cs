using MvcShopping.DAL;
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
        MusicStoreEntities storeDB = new MusicStoreEntities();

        List<Artist> artist = new List<Artist>();



        public ArtistController()
        {

        }

        public ArtistController(List<Artist> Artists)
        {
       
            foreach (Artist a in Artists)
                storeDB.Artists.Add(a);

            storeDB.SaveChanges();

        }



        [Route("GetAllArtists")]
        [HttpGet]
        public IEnumerable<Artist> GetAllArtists()
        {


            return storeDB.Artists.ToList(); ;
        }

        [Route("api/artists2")]
        [HttpGet]
        public async Task<IEnumerable<Artist>> GetAllArtistsAsync()
        {
            return await Task.FromResult(GetAllArtists());
        }

        [Route("api/artists/{id}")]
        [HttpGet]
        public IHttpActionResult GetArtist(int id)
        {
            var Artist = storeDB.Artists.FirstOrDefault((p) => p.ArtistId == id);
            if (Artist == null)
            {
                return NotFound();
            }
            return Ok(Artist);
        }
        [Route("api/artists2/{id}")]
        [HttpGet]
        public async Task<IHttpActionResult> GetArtistAsync(int id)
        {
            return await Task.FromResult(GetArtist(id));
        }
    }
}
