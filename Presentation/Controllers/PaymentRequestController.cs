using Application.Abstractions.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentRequestController : ControllerBase
    {
        private readonly IPaymentRequestService _paymentRequestService;
        public PaymentRequestController(IPaymentRequestService paymentRequestService)
        {
            _paymentRequestService = paymentRequestService;
        }
        [HttpGet]
        public async Task<IActionResult> InitiatePaymentAsync(string email, decimal amount)
        {
            var response = await _paymentRequestService.InitiatePaymentAsync(email, amount);
            var jsonObject = Newtonsoft.Json.JsonConvert.DeserializeObject<object>(response);
            return new ContentResult
            {
                Content = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObject),
                ContentType = "application/json",
            };
        }
    }
}
