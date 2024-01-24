using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Abstractions;
using Microsoft.Extensions.Configuration;
using Twilio.TwiML.Messaging;

namespace Persistence.Payment
{
    public class PaystackService : IPaystackService
    {
        private static HttpClient _client;
        private readonly IConfiguration _config;
        private string _apiKey;

        public PaystackService(HttpClient client, IConfiguration config)
        {
            _client = client;
            _config = config;
            _apiKey = _config.GetValue<string>("PaystackKey");
        }

        public async Task<string> InitializePayment(string _email, decimal amount)
        {
            var transactionRequest = new
            {
                amount = amount * 100,
                email = _email,
                reference = Guid.NewGuid().ToString(),
                currency = "NGN",
                callback_url = "https://localhost:7122/payment",
                receipt_number = $"SO52534624_{new Random().Next(4000000, 9000000)}",
                message = "school fee payment",
                first_name = "TEST FIRST NAME",
                last_name = "TEST LAST NAME",
            };
            var jsonPayload = Newtonsoft.Json.JsonConvert.SerializeObject(transactionRequest);
            var request = new HttpRequestMessage(HttpMethod.Post, "https://api.paystack.co/transaction/initialize");
            request.Content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");
            request.Headers.Add("Authorization", $"Bearer {_apiKey}");
            var response = await _client.SendAsync(request);
            var responseContent = await response.Content.ReadAsStringAsync();
            return responseContent;
        }
        public async Task<string> PaymentReference(string ReferenceId)
        {
            string url = $"https://api.paystack.co/transaction/verify/{ReferenceId}";
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("Authorization", $"Bearer {_apiKey}");
            var response = await _client.SendAsync(request);
            var responseContent = await response.Content.ReadAsStringAsync();
            return responseContent;
        }

    }
}
