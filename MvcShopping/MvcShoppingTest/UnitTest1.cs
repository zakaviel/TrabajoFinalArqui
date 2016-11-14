using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcShopping.Controllers;
using MvcShopping.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Web.Http.Results;

namespace MvcShopping.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetAllalbums_ShouldReturnAllalbums()
        {
            var testalbums = GetTestalbums();
            var controller = new AlbumController(testalbums);

            var result = controller.GetAllalbums() as List<Album>;
            Assert.AreEqual(testalbums.Count, result.Count);
        }

        [TestMethod]
        public async Task GetAllalbumsAsync_ShouldReturnAllalbums()
        {
            var testalbums = GetTestalbums();
            var controller = new AlbumController(testalbums);

            var result = await controller.GetAllalbumsAsync() as List<Album>;
            Assert.AreEqual(testalbums.Count, result.Count);
        }

        [TestMethod]
        public void Getalbum_ShouldReturnCorrectalbum()
        {
            var testalbums = GetTestalbums();
            var controller = new AlbumController(testalbums);

            var result = controller.Getalbum(4) as OkNegotiatedContentResult<Album>;
            Assert.IsNotNull(result);
            Assert.AreEqual(testalbums[3].Title, result.Content.Title);
        }

        [TestMethod]
        public async Task GetalbumAsync_ShouldReturnCorrectalbum()
        {
            var testalbums = GetTestalbums();
            var controller = new AlbumController(testalbums);

            var result = await controller.GetalbumAsync(4) as OkNegotiatedContentResult<Album>;
            Assert.IsNotNull(result);
            Assert.AreEqual(testalbums[3].Title, result.Content.Title);
        }

        [TestMethod]
        public void Getalbum_ShouldNotFindalbum()
        {
            var controller = new AlbumController(GetTestalbums());

            var result = controller.Getalbum(999);
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        private List<Album> GetTestalbums()
        {
            var testalbums = new List<Album>();
            testalbums.Add(new Album { AlbumId = 1, Title = "Demo1", Price = 1 });
            testalbums.Add(new Album { AlbumId = 2, Title = "Demo2", Price = 3.75M });
            testalbums.Add(new Album { AlbumId = 3, Title = "Demo3", Price = 16.99M });
            testalbums.Add(new Album { AlbumId = 4, Title = "Demo4", Price = 11.00M });

            return testalbums;
        }
    }
}
