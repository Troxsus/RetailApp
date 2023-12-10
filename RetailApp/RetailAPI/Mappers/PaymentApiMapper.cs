using System;
using RetailApp.PaymentService.Protos;
using RetailApp.API.Models;

namespace RetailApp.API.Mappers
{
    public static class PaymentApiMapper
    {
        public static PaymentDisplay MapToProductDisplay(PaymentReply payment)
        {
            return new PaymentDisplay
            {
                Id = Guid.Parse(payment.Id),
                CreatedOn = Convert.ToDateTime(payment.CreatedOn),
                Price = Convert.ToDecimal(payment.Price),
                UserId = Guid.Parse(payment.UserId),
                OrderId = Guid.Parse(payment.OrderId)
            };
        }

        public static PaymentIdRequest MapToPaymentIdRequest(Guid id)
        {
            return new PaymentIdRequest
            {
                Id = id.ToString()
            };
        }

        public static PaymentCreateRequest MapToPaymentCreateRequest(PaymentCreate payment)
        {
            return new PaymentCreateRequest
            {
                CreatedOn = payment.CreatedOn.ToString(),
                Price = Convert.ToDouble(payment.Price),
                OrderId = payment.OrderId.ToString(),
                UserId = payment.UserId.ToString()
            };
        }
    }
}
