using Application.Dtos;

namespace Application.Abstractions
{
    public interface IMailService
    {
        void SendEMailAsync(MailRequest mailRequest);
        void GetRecievers(List<MailRequest> mailRequests);
    }
}