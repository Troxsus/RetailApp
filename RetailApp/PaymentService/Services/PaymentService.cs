using System.Threading.Tasks;
using Grpc.Core;
using RetailApp.BAL.Providers.Interfaces;
using RetailApp.PaymentService.Mappers;
using RetailApp.PaymentService.Protos;

namespace RetailApp.PaymentService.Services
{
    public class PaymentService : PaymentContract.PaymentContractBase
    {
        private readonly IPaymentProvider _paymentProvider;

        public PaymentService(IPaymentProvider provider)
        {
            _paymentProvider = provider;
        }

        public override Task<PaymentListReply> GetUserPayments(PaymentIdRequest request, ServerCallContext context)
        {
            var userPayments = _paymentProvider.GetUserPayments(request.Id);

            var response = PaymentMapper.MapToPaymentListReply(userPayments);

            return Task.FromResult(response);
        }

        public override Task<PaymentReply> GetPaymentById(PaymentIdRequest request, ServerCallContext context)
        {
            var payment = _paymentProvider.GetPaymentById(request.Id);

            var response = PaymentMapper.MapToPaymentReply(payment);

            return Task.FromResult(response);
        }

        public override Task<PaymentCreateReply> CreatePayment(PaymentCreateRequest request, ServerCallContext context)
        {
            var paymentToCreate = PaymentMapper.MapToPaymentCreateModel(request);

            _paymentProvider.CreatePayment(paymentToCreate);

            return Task.FromResult(new PaymentCreateReply { IsSuccess = true });
        }
    }
}
