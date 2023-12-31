﻿using System.Collections.Generic;
using RetailApp.BAL.Models;

namespace RetailApp.BAL.Providers.Interfaces
{
    public interface IPaymentProvider
    {
        IEnumerable<PaymentTransferModel> GetUserPayments(string userId);

        PaymentTransferModel GetPaymentById(string paymentId);

        bool CreatePayment(PaymentCreateModel paymentToInsert);
    }
}
