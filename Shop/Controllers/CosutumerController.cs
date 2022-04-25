using Microsoft.AspNetCore.Mvc;
using Serilog;
using Shop.Interfaces;
using Shop.Models;

namespace Shop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CosutumerController : ControllerBase
    {
        private ICostumerService _costumerService;
        public CosutumerController(ICostumerService costumerService)
        {
            _costumerService = costumerService;
        }

        [HttpGet]
        public IActionResult GetCostumers()
        {
            try
            {
                return Ok(_costumerService.GetCostumers());
            }
            catch (Exception ex)
            {
                Log.Error(ex.ToString());
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult AddCostumer(Costumer costumer)
        {
            try
            {
                var c = new CostumerDto()
                {
                    Costumerid = costumer.Costumerid,
                    Name = costumer.Name,
                };
                _costumerService.AddCostumer(c);
                
                return Ok(c);
            }
            catch(Exception ex)
            {
                Log.Error(ex.ToString());
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public IActionResult DeletCostumerById(int id)
        {
            try
            {
                _costumerService.DeletCostumerById(id);
                return Ok();
            }
            catch (Exception ex)
            {
                Log.Error(ex.ToString());
                return BadRequest(ex.Message);
            }
        }
    }
}