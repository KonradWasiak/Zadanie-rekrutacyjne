using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zadanie.Database.Entities;

namespace Zadanie.Infrastructure.Abstract
{
    public interface IProductRepository
    {
        List<Product> GetProducts();
        Product GetProduct(Guid id);
        void EditProduct(Product product);
        void DeleteProduct(Guid id);
        Guid AddProduct(Product product);
    }
}
