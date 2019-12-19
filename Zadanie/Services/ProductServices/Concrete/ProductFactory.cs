using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zadanie.Database.Entities;
using Zadanie.Models.ProductModels;
using Zadanie.Services.ProductServices.Abstract;

namespace Zadanie.Services.ProductServices.Concrete
{
    public class ProductFactory : IProductFactory
    {
        public Product GetProduct(ProductCreateInputModel product)
        {
            return new Product()
            {
                Id = Guid.NewGuid(),
                Name = product.Name,
                Price = product.Price ?? throw new NullReferenceException()
            };
        }

        public Product GetProduct(ProductUpdateInputModel product)
        {
            return new Product()
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price ?? throw new NullReferenceException()
        };
        }
    }
}
