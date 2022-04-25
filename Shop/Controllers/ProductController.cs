using Microsoft.AspNetCore.Mvc;
using Serilog;
using Shop.Interfaces;
using Shop.Models;

namespace Shop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : Controller
    {
        private IProductservice _productservice;
        public ProductController(IProductservice productservice)
        {
            _productservice = productservice;   
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            try
            {
                return Ok(_productservice.GetProducts());
            }
            catch (Exception ex)
            {
                Log.Error(ex.ToString());
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            try
            {
                var p = new ProductDto()
                {
                    Description = product.Description,
                    Price = product.Price,
                    Productid = product.Productid,
                };
                _productservice.AddProduct(p);
                return Ok(p);
            }
            catch(Exception ex)
            {
                Log.Error(ex.ToString());
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public IActionResult Deletbyid(int id)
        {
            try
            {
                _productservice.DeletProductById(id);
                return Ok();
            }
            catch(Exception ex)
            {
                Log.Error(ex.ToString());
                return BadRequest(ex.Message);
            }
        }
    }
}
