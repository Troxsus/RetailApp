using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Grpc.Net.Client;
using RetailApp.PaymentService.Protos;
using RetailApp.API.Clients.Interfaces;
using RetailApp.API.Models;
using RetailApp.API.Models.ConfigOptions;
using AutoMapper;


namespace RetailApp.API.Clients
{
    public class PaymentClient : IPaymentClient
    {
        private readonly IMapper _mapper;
        private readonly PaymentContract.PaymentContractClient _paymentClient;

        public PaymentClient(IMapper mapper ,IOptions<ServiceAddressOptions> addressOptions)
        {
            _mapper = mapper;

            var channel = GrpcChannel.ForAddress(addressOptions.Value.PaymentServiceAddress);
            _paymentClient = new PaymentContract.PaymentContractClient(channel);
        }

        public async Task<IEnumerable<PaymentDisplay>> GetUserPayments(Guid userId)
        {
            var request = new PaymentIdRequest { Id = userId.ToString() };

            var userPayments = await _paymentClient.GetUserPaymentsAsync(request);

            return userPayments.Payments.Select(x => _mapper.Map<PaymentDisplay>(x));
        }

        public async Task<PaymentDisplay> GetPaymentById(Guid paymentId)
        {
            var request = new PaymentIdRequest { Id = paymentId.ToString() };

            var payment = await _paymentClient.GetPaymentByIdAsync(request);

            return _mapper.Map<PaymentDisplay>(payment);
        }

        public async Task<bool> CreatePayment(PaymentCreate payment)
        {
            var paymentToCreate = _mapper.Map<PaymentCreateRequest>(payment);

            var result = await _paymentClient.CreatePaymentAsync(paymentToCreate);

            return result.IsSuccess;
        }
    }
}
