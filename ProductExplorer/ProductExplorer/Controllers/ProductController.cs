using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductExplorer.DAL;
using ProductExplorer.Models;

namespace ProductExplorer.Controllers
{
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductProvider _productProvider;

        public ProductController(IProductProvider productProvider)
        {
            _productProvider = productProvider ?? throw new ArgumentNullException(nameof(productProvider));
        }

        [HttpGet("product")]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _productProvider.GetProducts();
            return Ok(products);
        }

        [HttpGet("product/{id}")]
        public async Task<IActionResult> GetProduct([FromRoute] int id)
        {
            var product = await _productProvider.GetProduct(id);
            return Ok(product);
        }

        [HttpPost("product")]
        public async Task<IActionResult> AddProduct([FromBody] AddProductModel model)
        {
            var product = await _productProvider.AddProduct(model.Name, model.Description);
            return Created($"product/{product.Id}", product);
        }

        [HttpPut("product/{id}")]
        public async Task<IActionResult> UpdateProduct([FromRoute] int id, [FromBody] UpdateProductModel model)
        {
            await _productProvider.UpdateProduct(id, model.Name, model.Description);
            return NoContent();
        }

        [HttpDelete("product/{id}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] int id)
        {
            await _productProvider.DeleteProduct(id);
            return Ok();
        }
    }
}