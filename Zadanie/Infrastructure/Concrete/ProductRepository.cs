using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zadanie.Database;
using Zadanie.Exceptions;
using Zadanie.Infrastructure.Abstract;
using Zadanie.Database.Entities;

namespace Zadanie.Infrastructure.Concrete
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _dataContext;

        public ProductRepository(DataContext dataContext)
        {
            this._dataContext = dataContext;
        }

        public Guid AddProduct(Product product)
        {
            _dataContext.Add(product);
            _dataContext.SaveChanges();
            return product.Id;
        }

        public void DeleteProduct(Guid id)
        {
            var productToDelete = _dataContext.Products
                .Where(x => x.Id == id)
                .FirstOrDefault();

            if (productToDelete != null)
            {
                _dataContext.Products.Remove(productToDelete);
                _dataContext.SaveChanges();
                return;
            }
            throw new EntityNotFoundException($"Entity with id {id} not found");
        }

        public void EditProduct(Product product)
        {
            var productToEdit = _dataContext.Products
                           .Where(x => x.Id == product.Id)
                           .FirstOrDefault();

            if (productToEdit != null)
            {
                productToEdit.Name = product.Name;
                productToEdit.Price = product.Price;
                _dataContext.SaveChanges();
                return;
            }
            throw new EntityNotFoundException($"Entity {product} not found");
        }

        public Product GetProduct(Guid id)
        {
            var product = _dataContext.Products
                           .Where(x => x.Id == id)
                           .FirstOrDefault();

            if (product == null)
            {
                throw new EntityNotFoundException($"Entity with id {id} not found");
            }
            return product;
        }

        public List<Product> GetProducts()
        {
            var products = _dataContext.Products.ToList();
            if (!products.Any())
            {
                throw new NoEntityFoundException($"No entities found");
            }
            return products;
        }
    }
}
