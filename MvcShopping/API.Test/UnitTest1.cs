using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using APIMvcShopping.Controllers;

namespace API.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
        }

        [TestMethod]
        public void GetReturnsProduct()
        {
            // Arrange
            var controller = new ArtistsController(repository);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            // Act
            var response = controller.Get(10);

            // Assert
            Product product;
            Assert.IsTrue(response.TryGetContentValue<Product>(out product));
            Assert.AreEqual(10, product.Id);
        }
    }
}
