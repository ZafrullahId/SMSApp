using System.Globalization;

namespace Application.Abstractions
{
    public interface IPaystackService
    {
        Task<string> InitializePayment(string email, decimal amount);
        Task<string> PaymentReference(string ReferenceId);
    }
}