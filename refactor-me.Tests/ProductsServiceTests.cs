using System;
using refactor_me.SharedObjects.Models;
using refactor_me.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace refactor_me.Tests
{
    [TestClass]
    public class ProductsServiceTests
    {
        #region Positive Tests
        [TestMethod]
        public void Stage001_GetAllProductsTest()
        {
            var productRepo = new ProductsService();
            var output = productRepo.GetAllProducts();
            Assert.IsNotNull(output);
        }

        [TestMethod]
        public void Stage002_GetAllProductsByNameTest()
        {
            var productRepo = new ProductsService();
            var output = productRepo.GetAllProductsByName("Samsung");
            Assert.IsNotNull(output);
            Assert.AreNotEqual(0, output.Items.Count);
        }

        [TestMethod]
        public void Stage003_GetProductByIdTest()
        {
            var productRepo = new ProductsService();
            var output = productRepo.GetProductById(new Guid("de1287c0-4b15-4a7b-9d8a-dd21b3cafec3"));
            Assert.IsNotNull(output);
            Assert.AreEqual(new Guid("de1287c0-4b15-4a7b-9d8a-dd21b3cafec3"), output.Id);
        }

        [TestMethod]
        public void Stage006_CreateProductTest()
        {
            var productRepo = new ProductsService();
            var input = new Product
            {
                Name = "Nokia",
                Description = "Best phone ever",
                Price = 14576.99M,
                DeliveryPrice = 45.98M
            };

            productRepo.CreateProduct(input);

            var output = productRepo.GetAllProductsByName("Nokia");
            Assert.IsNotNull(output);
            Assert.AreEqual("Nokia", output.Items[0].Name);
        }

        [TestMethod]
        public void Stage008_UpdateProductTest()
        {
            var productRepo = new ProductsService();
            var createdDetails = productRepo.GetAllProductsByName("Nokia");

            Assert.IsNotNull(createdDetails);
            var input = new Product
            {
                Id = createdDetails.Items[0].Id,
                Name = "Nokia 3310",
                Description = "Best phone ever",
                Price = 14576.99M,
                DeliveryPrice = 45.98M
            };

            productRepo.UpdateProduct(input);

            var output = productRepo.GetAllProductsByName("Nokia 3310");
            Assert.IsNotNull(output);
            Assert.AreEqual("Nokia 3310", output.Items[0].Name);
        }

        [TestMethod]
        public void Stage011_DeleteProductTest()
        {
            var productRepo = new ProductsService();
            var createdDetails = productRepo.GetAllProductsByName("Nokia 3310");

            Assert.IsNotNull(createdDetails);
            productRepo.DeleteProduct(createdDetails.Items[0].Id);

            var output = productRepo.GetProductById(createdDetails.Items[0].Id);
            Assert.IsNull(output);
        }

        #endregion
    }
}
