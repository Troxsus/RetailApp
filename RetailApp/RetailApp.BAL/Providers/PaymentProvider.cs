using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using RetailApp.Data.Models;
using RetailApp.BAL.Models;
using RetailApp.BAL.Providers.Interfaces;
using RetailApp.Data.Providers.Interfaces;

namespace RetailApp.BAL.Providers
{
    public class PaymentProvider : BaseProvider<Payment>, IPaymentProvider
    {
        public PaymentProvider(IMapper mapper, IDbRepositoryProvider provider)
            : base(mapper)
        {
            _repository = provider.GetRepository<Payment>();
        }

        public IEnumerable<PaymentTransferModel> GetUserPayments(string userId)
        {
            var userIdAsGuid = Guid.Parse(userId);

            var userPayments = base
                .GetAll()
                .Where(x => x.UserId == userIdAsGuid)
                .Select(x => _mapper.Map<PaymentTransferModel>(x))
                .ToList();

            return userPayments;
        }

        public PaymentTransferModel GetPaymentById(string paymentId)
        {
            var payment = base.GetById(paymentId);

            return _mapper.Map<PaymentTransferModel>(payment);
        }

        public bool CreatePayment(PaymentCreateModel payment)
        {
            var paymentToInsert = _mapper.Map<Payment>(payment);

            base.Create(paymentToInsert);

            return true;
        }
    }
}
