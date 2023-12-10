using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RetailApp.API.Models;

namespace RetailApp.API.GrpcClients.Interfaces
{
    public interface IPaymentClient
    {
        Task<IEnumerable<PaymentDisplay>> GetUserPayments(Guid userId);

        Task<PaymentDisplay> GetPaymentById(Guid paymentId);

        Task<bool> CreatePayment(PaymentCreate payment);
    }
}
