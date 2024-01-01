using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RetailApp.API.Clients.Interfaces;
using RetailApp.API.Models;

namespace RetailApp.API.Controllers
{
    [Route("api/payment")]
    public class PaymentController : Controller
    {
        private readonly IPaymentClient _paymentClient;

        public PaymentController(IPaymentClient paymentClient)
        {
            _paymentClient = paymentClient;
        }

        [HttpGet]
        [Route("user")]
        public async Task<JsonResult> GetUserPayments(Guid userId)
        {
            var userPayments = await _paymentClient.GetUserPayments(userId);

            return new JsonResult(userPayments);
        }

        [HttpGet]
        public async Task<JsonResult> GetPaymentById(Guid paymentId)
        {
            var payment = await _paymentClient.GetPaymentById(paymentId);

            return new JsonResult(payment);
        }

        [HttpPost]
        public async Task<JsonResult> CreatePayment(PaymentCreate payment)
        {
            var result = await _paymentClient.CreatePayment(payment);

            return new JsonResult(result);
        }
    }
}
