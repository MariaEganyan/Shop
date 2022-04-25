using Microsoft.AspNetCore.Mvc;
using Serilog;
using Shop.Interfaces;
using Shop.Models;

namespace Shop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController: ControllerBase
    {
        private IOrderService _orderservice;
        public OrderController(IOrderService orderService)
        {
            _orderservice = orderService;
        }

        [HttpGet]
        public IActionResult GetOrders()
        {
            try
            {
                return Ok(_orderservice.GetOrders());
            }
            catch (Exception ex)
            {
                Log.Error(ex.ToString());
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult AddOrder(Oorder order)
        {
            try
            {
                var o = new OorderDto()
                {
                    Orderid = order.Orderid,
                    Costumerid = order.Costumerid,
                };
                _orderservice.AddOrder(o);
                return Ok(o);
            }
            catch(Exception ex)
            {
                Log.Error(ex.ToString());
                return BadRequest(ex.Message);
            }
        }
    }
}
