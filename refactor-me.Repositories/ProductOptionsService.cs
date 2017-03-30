using System;
using System.Collections.Generic;
using System.Linq;
using refactor_me.Contract;
using refactor_me.SharedObjects.Models;

namespace refactor_me.Repositories
{
    public class ProductOptionsService : IProductOptionsService
    {
        public ProductOptions GetOptionsByProductId(Guid productId)
        {
            try
            {
                using (DatabaseEntities context = new DatabaseEntities())
                {
                    IList<ProductOption> productsOptionsByProductId = context.ProductOptions.Where(po => po.ProductId == productId).ToList();
                    return new ProductOptions(productsOptionsByProductId);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ProductOption GetOptionByProductOptionId(Guid optionId)
        {
            try
            {
                using (DatabaseEntities context = new DatabaseEntities())
                {
                    ProductOption productOptionById = context.ProductOptions.FirstOrDefault(po => po.Id == optionId);
                    return productOptionById;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void CreateProductOption(ProductOption optionDetails)
        {
            try
            {
                using (DatabaseEntities context = new DatabaseEntities())
                {
                    //Set New Instance
                    ProductOption newProductOptions = new ProductOption
                    {
                        Id = Guid.NewGuid(),
                        ProductId = optionDetails.ProductId,
                        Name = optionDetails.Name,
                        Description = optionDetails.Description
                    };

                    //Add Product to Object
                    context.ProductOptions.Add(newProductOptions);
                    //Update Database
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateProductOption(ProductOption optionDetails)
        {
            try
            {
                using (DatabaseEntities context = new DatabaseEntities())
                {
                    //Set New Instance
                    ProductOption updateProductOptions = context.ProductOptions.FirstOrDefault(p => p.Id == optionDetails.Id);

                    //Update Object with New Details
                    updateProductOptions.Name = optionDetails.Name;
                    updateProductOptions.Description = optionDetails.Description;
                    //Update Database
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteProductOption(Guid Id)
        {
            try
            {
                using (DatabaseEntities context = new DatabaseEntities())
                {
                    //Delete to Product
                    ProductOption productOptions = context.ProductOptions.FirstOrDefault(po => po.Id == Id);
                    context.ProductOptions.Remove(productOptions);
                    //Update Database
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
