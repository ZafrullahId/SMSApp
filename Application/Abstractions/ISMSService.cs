namespace Application.Abstractions
{
    public interface ISMSService
    {
        bool SendSmsAsync(string toNumber, string fromNumber, string body);
    }
}