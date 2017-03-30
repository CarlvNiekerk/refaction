using System;
using refactor_me.SharedObjects.Models;

namespace refactor_me.Contract
{
    public interface IProductOptionsService
    {
        ProductOptions GetOptionsByProductId(Guid productId);

        ProductOption GetOptionByProductOptionId(Guid optionId);

        void CreateProductOption(ProductOption option);

        void UpdateProductOption(ProductOption option);

        void DeleteProductOption(Guid Id);
    }
}
