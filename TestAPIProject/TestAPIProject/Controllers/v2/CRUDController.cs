using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestAPIProject.Controllers.v2
{
    [Route("api/[controller]")]
    [ApiController]

    //class product for sample test
    public class Product
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public double Price { get; set; }
    }

    public class CRUDController : ControllerBase
    {
        private static List<Product> _products = new List<Product>
        {
            new Product { Id = 1, Name = "Product 1", Price = 10.99 },
            new Product { Id = 2, Name = "Product 2", Price = 20.99 }
        };

        [HttpGet]
        public IActionResult GetAllProducts()
        {
            return Ok(_products);
        }

        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public IActionResult CreateProduct([FromBody] Product product)
        {
            if (product == null)
            {
                return BadRequest();
            }

            product.Id = _products.Count + 1;
            _products.Add(product);

            return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, [FromBody] Product product)
        {
            var existingProduct = _products.FirstOrDefault(p => p.Id == id);
            if (existingProduct == null)
            {
                return NotFound();
            }

            existingProduct.Name = product.Name;
            existingProduct.Price = product.Price;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            _products.Remove(product);
            return NoContent();
        }
    }
}
