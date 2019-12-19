using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Zadanie.Exceptions;
using Zadanie.Infrastructure.Abstract;
using Zadanie.Models.ProductModels;
using Zadanie.Services.ProductServices.Abstract;

namespace Zadanie.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductRepository _repo;
        private readonly IProductFactory _productFactory;

        public ProductController(IProductRepository repo, IProductFactory productFactory)
        {
            this._repo = repo;
            this._productFactory = productFactory;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var products = _repo.GetProducts();
                return Ok(products);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                var product = _repo.GetProduct(id);
                return Ok(product);
            }
            catch(EntityNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody]ProductCreateInputModel product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var productToAdd = _productFactory.GetProduct(product);
                _repo.AddProduct(productToAdd);
                return Ok(productToAdd.Id);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpPut]
        public IActionResult Put([FromBody]ProductUpdateInputModel product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var productToEdit = _productFactory.GetProduct(product);
                _repo.EditProduct(productToEdit);
                return Ok();
            }
            catch(EntityNotFoundException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _repo.DeleteProduct(id);
                return Ok();
            }
            catch(EntityNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
