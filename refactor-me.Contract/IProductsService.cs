using System;
using refactor_me.SharedObjects.Models;

namespace refactor_me.Contract
{
    public interface IProductsService
    {
        Products GetAllProducts();

        Products GetAllProductsByName(string name);

        Product GetProductById(Guid productId);

        void CreateProduct(Product product);

        void UpdateProduct(Product product);

        void DeleteProduct(Guid Id);
    }
}
