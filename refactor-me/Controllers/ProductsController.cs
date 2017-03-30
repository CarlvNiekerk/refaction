using System;
using System.Web.Http;
using refactor_me.Contract;
using refactor_me.SharedObjects.Models;

namespace refactor_me.Controllers
{
    [RoutePrefix("products")]
    public class ProductsController : ApiController
    {
        private IProductsService _productsService;

        public ProductsController(IProductsService productsService)
        {
            _productsService = productsService;
        }

        /// <summary>
        /// Method          {GET}
        /// Url             {/products}
        /// Description     {Gets All Products.}
        /// </summary>
        /// <returns></returns>
        [Route]
        [HttpGet]
        public Products GetAll()
        {
            return _productsService.GetAllProducts();
        }

        /// <summary>
        /// Method          {GET}
        /// Url             {/products?name={name}}
        /// Description     {Finds All Products Matching the Specified Name.}
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [Route]
        [HttpGet]
        public Products SearchByName(string name)
        {
            return _productsService.GetAllProductsByName(name);
        }

        /// <summary>
        /// Method          {GET}
        /// Url             {/products/{id}}
        /// Description     {Gets the Project that Matches the Specified ID - ID is a GUID.}
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [Route("{id}")]
        [HttpGet]
        public Product GetProduct(Guid Id)
        {
            return _productsService.GetProductById(Id);
        }

        /// <summary>
        /// Method          {POST}
        /// Url             {/products}
        /// Description     {Creates a New Product.}
        /// </summary>
        /// <param name="product"></param>
        [Route]
        [HttpPost]
        public void Create(Product product)
        {
            _productsService.CreateProduct(product);
        }

        /// <summary>
        /// Method          {PUT}
        /// Url             {/products/{id}}
        /// Description     {Updates a Product.}
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="product"></param>
        [Route("{id}")]
        [HttpPut]
        public void Update(Guid Id, Product product)
        {
            _productsService.UpdateProduct(product);
        }

        /// <summary>
        /// Method          {DELETE}
        /// Url             {/products/{id}}
        /// Description     {Deletes a Product and its Options for a Specified ID - ID is a GUID.} 
        /// </summary>
        /// <param name="Id"></param>
        [Route("{id}")]
        [HttpDelete]
        public void Delete(Guid Id)
        {
            _productsService.DeleteProduct(Id);
        }
    }
}
