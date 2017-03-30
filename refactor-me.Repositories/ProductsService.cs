using System;
using System.Collections.Generic;
using System.Linq;
using refactor_me.Contract;
using refactor_me.SharedObjects.Models;

namespace refactor_me.Repositories
{
    public class ProductsService : IProductsService
    {
        public Products GetAllProducts()
        {
            try
            {
                using (DatabaseEntities context = new DatabaseEntities())
                {
                    IList<Product> allProducts = context.Products.ToList();
                    return new Products(allProducts);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Products GetAllProductsByName(string name)
        {
            try
            {
                using (DatabaseEntities context = new DatabaseEntities())
                {
                    IList<Product> productByName = context.Products.Where(p => p.Name.ToLower().Contains(name.ToLower())).ToList();
                    return new Products(productByName);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Product GetProductById(Guid productId)
        {
            try
            {
                using (DatabaseEntities context = new DatabaseEntities())
                {
                    Product productById = context.Products.FirstOrDefault(p => p.Id == productId);
                    return productById;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void CreateProduct(Product productDetails)
        {
            try
            {
                using (DatabaseEntities context = new DatabaseEntities())
                {
                    //Set New Instance
                    Product newProduct = new Product
                    {
                        Id = Guid.NewGuid(),
                        Name = productDetails.Name,
                        Description = productDetails.Description,
                        Price = productDetails.Price,
                        DeliveryPrice = productDetails.DeliveryPrice
                    };

                    //Add Product to Object
                    context.Products.Add(newProduct);
                    //Update Database
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateProduct(Product productDetails)
        {
            try
            {
                using (DatabaseEntities context = new DatabaseEntities())
                {
                    //Set New Instance
                    Product updateProduct = context.Products.FirstOrDefault(p => p.Id == productDetails.Id);

                    //Update Object with New Details
                    updateProduct.Name = productDetails.Name;
                    updateProduct.Description = productDetails.Description;
                    updateProduct.Price = productDetails.Price;
                    updateProduct.DeliveryPrice = productDetails.DeliveryPrice;
                    //Update Database
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteProduct(Guid Id)
        {
            try
            {
                using (DatabaseEntities context = new DatabaseEntities())
                {
                    //Before we Delete to Product Must Delete Related Product Options
                    ProductOption productOptions = context.ProductOptions.FirstOrDefault(po => po.ProductId == Id);
                    if (productOptions != null)
                        context.ProductOptions.Remove(productOptions);
                    //Update Database
                    context.SaveChanges();

                    //Delete to Product
                    Product product = context.Products.FirstOrDefault(p => p.Id == Id);
                    context.Products.Remove(product);
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
