using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RetailApp.API.GrpcClients.Interfaces;
using RetailApp.API.Models;

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

        [HttpPost]
        public async Task<ActionResult> CreateOrder([FromBody] OrderCreate orderInfo)
        {
            var result = await _orderClient.CreateOrder(orderInfo);

            return new JsonResult(result);
        }

        [HttpPatch]
        public async Task<ActionResult> UpdateOrder([FromBody] OrderUpdate orderInfo)
        {
            var result = await _orderClient.UpdateOrder(orderInfo);
            
            return new JsonResult(result);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteOrder(Guid orderId)
        {
            var result = await _orderClient.DeleteOrder(orderId);

            return new JsonResult(result);
        }
    }
}
