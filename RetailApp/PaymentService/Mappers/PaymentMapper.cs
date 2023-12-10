using System;
using System.Collections.Generic;
using System.Linq;
using RetailApp.BAL.Models;
using RetailApp.PaymentService.Protos;

namespace RetailApp.PaymentService.Mappers
{
    public static class PaymentMapper
    {
        public static PaymentListReply MapToPaymentListReply(IEnumerable<PaymentTransferModel> payments)
        {
            var responsePayments = new PaymentListReply();

            var paymentsToAdd = payments.Select(x => PaymentMapper.MapToPaymentReply(x));
            responsePayments.Payments.AddRange(paymentsToAdd);


            return responsePayments;
        }

        public static PaymentReply MapToPaymentReply(PaymentTransferModel payment)
        {
            return new PaymentReply
            {
                Id = payment.Id.ToString(),
                CreatedOn = payment.CreatedOn.ToString(),
                Price = Convert.ToDouble(payment.Price),
                OrderId = payment.OrderId.ToString(),
                UserId = payment.UserId.ToString()
            };
        }

        public static PaymentCreateModel MapToPaymentCreateModel(PaymentCreateRequest payment)
        {
            return new PaymentCreateModel
            {
                CreatedOn = Convert.ToDateTime(payment.CreatedOn),
                Price = Convert.ToDecimal(payment.Price),
                OrderId = Guid.Parse(payment.OrderId),
                UserId = Guid.Parse(payment.UserId)
            };
        }
    }
}
