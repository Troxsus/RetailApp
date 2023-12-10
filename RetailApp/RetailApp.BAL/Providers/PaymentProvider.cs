using System;
using System.Collections.Generic;
using System.Linq;
using RetailApp.Data.Models;
using RetailApp.Data.Repository.Interfaces;
using RetailApp.BAL.Mappers;
using RetailApp.BAL.Models;
using RetailApp.BAL.Providers.Interfaces;

namespace RetailApp.BAL.Providers
{
    public class PaymentProvider : BaseProvider<Payment>, IPaymentProvider
    {
        public PaymentProvider(IDbContextRepository<Payment> paymentsRepository)
            : base(paymentsRepository)
        { }

        public IEnumerable<PaymentTransferModel> GetUserPayments(string userId)
        {
            var userIdAsGuid = Guid.Parse(userId);

            var userPayments = base
                .GetAll()
                .Where(x => x.UserId == userIdAsGuid)
                .Select(x => PaymentMapper.MapToPaymentTransferModel(x))
                .ToList();

            return userPayments;
        }

        public PaymentTransferModel GetPaymentById(string paymentId)
        {
            var payment = base.GetById(paymentId);

            return PaymentMapper.MapToPaymentTransferModel(payment);
        }

        public bool CreatePayment(PaymentCreateModel payment)
        {
            var paymentToInsert = PaymentMapper.MapToDbPayment(payment);

            base.Create(paymentToInsert);

            return true;
        }
    }
}
