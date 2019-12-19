using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zadanie.Database.Entities;
using Zadanie.Models.ProductModels;

namespace Zadanie.Services.ProductServices.Abstract
{
    public interface IProductFactory
    {
        Product GetProduct(ProductCreateInputModel product);
        Product GetProduct(ProductUpdateInputModel product);
    }
}
