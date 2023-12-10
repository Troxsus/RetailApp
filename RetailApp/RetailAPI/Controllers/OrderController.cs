using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RetailApp.API.GrpcClients.Interfaces;

namespace RetailApp.API.Controllers
{
    [Route("api/order")]
    public class OrderController : Controller
    {
        private readonly IOrderClient _orderClient;

        public OrderController(IOrderClient orderClient)
        {
            _orderClient = orderClient;
        }

        [HttpGet]
        public async Task<JsonResult> GetById(Guid orderId)
        {
            var order = await _orderClient.GetOrderById(orderId);

            return new JsonResult(order);
        }

        [HttpGet]
        [Route("user")]
        public async Task<ActionResult> GetOrdersForUser(Guid userId)
        {
            var orders = await _orderClient.GetUserOrders(userId);

            return new JsonResult(orders);
        }
    }
}
