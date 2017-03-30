using System;
using refactor_me.SharedObjects.Models;
using refactor_me.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace refactor_me.Tests
{
    [TestClass]
    public class ProductOptionsServiceTests
    {
        [TestMethod]
        public void Stage004_GetOptionsByProductIdTest()
        {
            var productOptionRepo = new ProductOptionsService();
            var output = productOptionRepo.GetOptionsByProductId(new Guid("de1287c0-4b15-4a7b-9d8a-dd21b3cafec3"));
            Assert.IsNotNull(output);
            Assert.AreNotEqual(0, output.Items.Count);
        }

        [TestMethod]
        public void Stage005_GetOptionByProductOptionIdTest()
        {
            var productOptionRepo = new ProductOptionsService();
            var output = productOptionRepo.GetOptionByProductOptionId(new Guid("9ae6f477-a010-4ec9-b6a8-92a85d6c5f03"));
            Assert.IsNotNull(output);
            Assert.AreEqual(new Guid("9ae6f477-a010-4ec9-b6a8-92a85d6c5f03"), output.Id);
        }

        [TestMethod]
        public void Stage007_CreateProductOptionTest()
        {
            var productRepo = new ProductsService();
            var createdDetails = productRepo.GetAllProductsByName("Nokia");

            var productOptionRepo = new ProductOptionsService();
            var input = new ProductOption
            {
                ProductId = createdDetails.Items[0].Id,
                Name = "Grey",
                Description = "Grey Nokia"
            };

            productOptionRepo.CreateProductOption(input);

            var output = productOptionRepo.GetOptionsByProductId(createdDetails.Items[0].Id);
            Assert.IsNotNull(output);
            Assert.AreEqual(createdDetails.Items[0].Id, output.Items[0].ProductId);
        }

        [TestMethod]
        public void Stage009_UpdateProductOptionTest()
        {
            var productRepo = new ProductsService();
            var createdProductDetails = productRepo.GetAllProductsByName("Nokia 3310");

            var productOptionRepo = new ProductOptionsService();
            var createdProductOptionDetails = productOptionRepo.GetOptionsByProductId(createdProductDetails.Items[0].Id);

            var input = new ProductOption
            {
                Id = createdProductOptionDetails.Items[0].Id,
                ProductId = createdProductOptionDetails.Items[0].ProductId,
                Name = "Midnight Grey",
                Description = "Grey Nokia"
            };

            productOptionRepo.UpdateProductOption(input);

            var output = productOptionRepo.GetOptionByProductOptionId(createdProductOptionDetails.Items[0].Id);
            Assert.IsNotNull(output);
            Assert.AreEqual("Midnight Grey", output.Name);
        }

        [TestMethod]
        public void Stage010_DeleteProductOptionTest()
        {
            var productRepo = new ProductsService();
            var createdProductDetails = productRepo.GetAllProductsByName("Nokia 3310");

            var productOptionRepo = new ProductOptionsService();
            var createdProductOptionDetails = productOptionRepo.GetOptionsByProductId(createdProductDetails.Items[0].Id);

            productOptionRepo.DeleteProductOption(createdProductOptionDetails.Items[0].Id);

            var output = productOptionRepo.GetOptionByProductOptionId(createdProductOptionDetails.Items[0].Id);
            Assert.IsNull(output);
        }
    }
}
