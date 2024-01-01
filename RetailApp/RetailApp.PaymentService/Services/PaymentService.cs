using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Grpc.Core;
using RetailApp.Data.ConfigOptions.Enums;
using RetailApp.BAL.Models;
using RetailApp.BAL.Providers.Interfaces;
using RetailApp.PaymentService.Protos;

namespace RetailApp.PaymentService.Services
{
    public class PaymentService : PaymentContract.PaymentContractBase
    {
        private readonly IMapper _mapper;
        private readonly IPaymentProvider _paymentProvider;

        public PaymentService(IMapper mapper, IPaymentProvider provider)
        {
            _mapper = mapper;
            _paymentProvider = provider;
            _paymentProvider.ConfigureProviderRepository(DbContextTypes.RetailApp);
        }

        public override Task<PaymentListReply> GetUserPayments(PaymentIdRequest request, ServerCallContext context)
        {
            var userPayments = _paymentProvider.GetUserPayments(request.Id);
            var paymentsList = new PaymentTransferModelList { Payments = new List<PaymentTransferModel>(userPayments) };

            var response = _mapper.Map<PaymentListReply>(paymentsList);

            return Task.FromResult(response);
        }

        public override Task<PaymentReply> GetPaymentById(PaymentIdRequest request, ServerCallContext context)
        {
            var payment = _paymentProvider.GetPaymentById(request.Id);

            var response = _mapper.Map<PaymentReply>(payment);

            return Task.FromResult(response);
        }

        public override Task<PaymentCreateReply> CreatePayment(PaymentCreateRequest request, ServerCallContext context)
        {
            var paymentToCreate = _mapper.Map<PaymentCreateModel>(request);

            _paymentProvider.CreatePayment(paymentToCreate);

            return Task.FromResult(new PaymentCreateReply { IsSuccess = true });
        }
    }
}
