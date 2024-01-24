using Application.Abstractions;
using Application.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class PaymentRequestService : IPaymentRequestService
    {
        private readonly IPaystackService _paystackService;
        public PaymentRequestService(IPaystackService paystackService)
        {
            _paystackService = paystackService;
        }
        public async Task<string> InitiatePaymentAsync(string email, decimal amount)
        {
            var response = await _paystackService.InitializePayment(email, amount);
            return response;
        }
        public async Task<string> PaymentReferenceAsync(string referenceId)
        {
            var response = await _paystackService.PaymentReference(referenceId);
            return response;
        }

    }
}
