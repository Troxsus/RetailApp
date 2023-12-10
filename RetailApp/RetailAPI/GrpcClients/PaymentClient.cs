using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Grpc.Net.Client;
using RetailApp.PaymentService.Protos;
using RetailApp.API.GrpcClients.Interfaces;
using RetailApp.API.Models;
using RetailApp.API.Mappers;
using RetailApp.API.Models.ConfigOptions;


namespace RetailApp.API.GrpcClients
{
    public class PaymentClient : IPaymentClient
    {
        private readonly PaymentContract.PaymentContractClient _paymentClient;

        public PaymentClient(IOptions<ServiceAddressOptions> addressOptions)
        {
            var channel = GrpcChannel.ForAddress(addressOptions.Value.PaymentServiceAddress);
            _paymentClient = new PaymentContract.PaymentContractClient(channel);
        }

        public async Task<IEnumerable<PaymentDisplay>> GetUserPayments(Guid userId)
        {
            var request = PaymentApiMapper.MapToPaymentIdRequest(userId);

            var userPayments = await _paymentClient.GetUserPaymentsAsync(request);

            return userPayments.Payments.Select(x => PaymentApiMapper.MapToProductDisplay(x));
        }

        public async Task<PaymentDisplay> GetPaymentById(Guid paymentId)
        {
            var request = PaymentApiMapper.MapToPaymentIdRequest(paymentId);

            var payment = await _paymentClient.GetPaymentByIdAsync(request);

            return PaymentApiMapper.MapToProductDisplay(payment);
        }

        public async Task<bool> CreatePayment(PaymentCreate payment)
        {
            var paymentToCreate = PaymentApiMapper.MapToPaymentCreateRequest(payment);

            var result = await _paymentClient.CreatePaymentAsync(paymentToCreate);

            return result.IsSuccess;
        }
    }
}
