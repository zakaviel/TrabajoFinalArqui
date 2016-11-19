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
    public class AlbumController : ApiController
    {
        
        List<Album> albums = new List<Album>();

        public AlbumController() { }

        public AlbumController(List<Album> albums)
        {
            this.albums = albums;
        }

        public IEnumerable<Album> GetAllalbums()
        {
            return albums;
        }

        public void CreateAlbum()
        {

            MusicStoreEntities db = new MusicStoreEntities();
            db.Database.ExecuteSqlCommand("exec CreateArtist3");
        }

        public async Task<IEnumerable<Album>> GetAllalbumsAsync()
        {
            return await Task.FromResult(GetAllalbums());
        }

        public IHttpActionResult Getalbum(int id)
        {
            var album = albums.FirstOrDefault((p) => p.AlbumId == id);
            if (album == null)
            {
                return NotFound();
            }
            return Ok(album);
        }

        public async Task<IHttpActionResult> GetalbumAsync(int id)
        {
            return await Task.FromResult(Getalbum(id));
        }
    }
}
