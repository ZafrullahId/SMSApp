namespace Application.Abstractions.Services
{
    public interface IPaymentRequestService
    {
        Task<string> InitiatePaymentAsync(string email, decimal amount);
        Task<string> PaymentReferenceAsync(string referenceId);
    }
}