using System;
using System.Web.Http;
using refactor_me.Contract;
using refactor_me.SharedObjects.Models;

namespace refactor_me.Controllers
{
    [RoutePrefix("products")]
    public class ProductOptionsController : ApiController
    {
        private IProductOptionsService _productOptionsService;

        public ProductOptionsController(IProductOptionsService productOptionsService)
        {
            _productOptionsService = productOptionsService;
        }

        /// <summary>
        /// Method          {GET}
        /// Url             {/products/{id}/options}
        /// Description     {Finds all Options for a Specified Product ID - ID is a GUID.}
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        [Route("{productId}/options")]
        [HttpGet]
        public ProductOptions GetOptions(Guid productId)
        {
            return _productOptionsService.GetOptionsByProductId(productId);
        }

        /// <summary>
        /// Method          {GET}
        /// Url             {/products/{id}/options/{optionId}}
        /// Description     {Finds the Specified Product Option for the Specified Option ID - ID is a GUID.}
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="Id"></param>
        /// <returns></returns>
        [Route("{productId}/options/{id}")]
        [HttpGet]
        public ProductOption GetOption(Guid productId, Guid Id)
        {
            return _productOptionsService.GetOptionByProductOptionId(Id);
        }

        /// <summary>
        /// Method          {POST}
        /// Url             {/products/{id}/options}
        /// Description     {Adds a New Product Option to the Specified Product.}
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="option"></param>
        [Route("{productId}/options")]
        [HttpPost]
        public void CreateOption(Guid productId, ProductOption option)
        {
            _productOptionsService.CreateProductOption(option);
        }

        /// <summary>
        /// Method          {PUT}
        /// Url             {/products/{id}/options/{optionId}}
        /// Description     {Updates the Specified Product Option.}
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="option"></param>
        [Route("{productId}/options/{id}")]
        [HttpPut]
        public void UpdateOption(Guid Id, ProductOption option)
        {
            _productOptionsService.UpdateProductOption(option);
        }

        /// <summary>
        /// Method          {DELETE}
        /// Url             {/products/{id}/options/{optionId}}
        /// Description     {Deletes the Specified Option ID - ID is a GUID.}
        /// </summary>
        /// <param name="Id"></param>
        [Route("{productId}/options/{id}")]
        [HttpDelete]
        public void DeleteOption(Guid Id)
        {
            _productOptionsService.DeleteProductOption(Id);
        }
    }
}