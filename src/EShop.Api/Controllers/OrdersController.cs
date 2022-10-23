using EShop.Api.Contracts;
using EShop.Api.Entities;
using EShop.Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EShop.Api.Controllers
{
    [ApiController]
    [AllowAnonymous]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderServices _orderServices;
        public OrdersController(IOrderServices orderServices)
        {
            _orderServices = orderServices;
        }

        [HttpGet]
        [Route("api/get")]
        public IActionResult Get()
        {
            return Ok("Hello World!");
        }

        [HttpPost]
        [Route("api/postorder")]
        public IActionResult Post([FromBody] Order order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            bool result = _orderServices.Add(order);

            if (result)
            {
                return Created("", "True");
            }
            else
            {
                return NoContent();
            }
        }

        [HttpGet]
        [Route("api/getorders")]
        public IEnumerable<Order> GetOrders(string code, string buyerName, string PuchaseOrderNumber)
        {
            var filter = new OrderFilter()
            {
                BillingZipCode = code,
                BuyerName = buyerName,
                PuchaseOrderNum = PuchaseOrderNumber
            };
            return _orderServices.Get(filter);
        }
    }
}
