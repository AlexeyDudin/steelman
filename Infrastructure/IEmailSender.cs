using Domain;

namespace Infrastructure
{
    public interface IEmailSender
    {
        void Send(EmailModel email);
    }
}
