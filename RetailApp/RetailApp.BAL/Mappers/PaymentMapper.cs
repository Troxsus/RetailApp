using System;
using RetailApp.Data.Models;
using RetailApp.BAL.Models;

namespace RetailApp.BAL.Mappers
{
    internal static class PaymentMapper
    {
        public static PaymentTransferModel MapToPaymentTransferModel(Payment payment)
        {
            return new PaymentTransferModel
            {
                Id = payment.Id,
                CreatedOn = payment.CreatedOn,
                OrderId = payment.OrderId,
                Price = payment.Price,
                UserId = payment.UserId
            };
        }

        public static Payment MapToDbPayment(PaymentCreateModel payment)
        {
            return new Payment
            {
                Id = Guid.NewGuid(),
                CreatedOn = payment.CreatedOn,
                OrderId = payment.OrderId,
                Price = payment.Price,
                UserId = payment.UserId
            };
        }
    }
}
