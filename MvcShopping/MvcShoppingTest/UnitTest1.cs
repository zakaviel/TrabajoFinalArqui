using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcShopping.Controllers;
using MvcShopping.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Web.Http.Results;
using System.Diagnostics;

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
            await Task.Run(()=>ProcedimientoAsincrono(testalbums));
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
            Console.WriteLine(result);
        }

        private List<Album> GetTestalbums()
        {
            Stopwatch stopwatch = new Stopwatch();

            // Begin timing.
            stopwatch.Start();
            

            
            

            var testalbums = new List<Album>();
            for (int i = 1; i < 1000000; i++)
            {
                testalbums.Add(new Album { AlbumId = i, Title = "Demo1" + i.ToString(), Price = 1 });
                //Ejecutar subproceso i
            }

            // Stop timing.
            stopwatch.Stop();

            // Write result.
            Console.WriteLine("Time elapsed: {0}", stopwatch.Elapsed);

            return testalbums;
        }
        private async Task ProcedimientoAsincrono(List<Album> temp)
        {
            Stopwatch stopwatch = new Stopwatch();

            // Begin timing.
            stopwatch.Start();





            var testalbums = new List<Album>();
            for (int i = 1; i < 1000000; i++)
            {
                testalbums.Add(new Album { AlbumId = i, Title = "Demo1" + i.ToString(), Price = 1 });
                //Ejecutar subproceso i
            }

            // Stop timing.
            stopwatch.Stop();

            // Write result.
            Console.WriteLine("Time elapsed: {0}", stopwatch.Elapsed);

            temp = testalbums;
        }
    }
}
