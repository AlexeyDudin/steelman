using Domain;
using Infrastructure;
using Infrastructure.EMail;

namespace Application
{
    public class MainApplication : IMainApp
    {
        private readonly IEmailSender _helper;

        public MainApplication(IEmailSender helper) => _helper = helper;

        public void SendMail(EmailModel email)
        {
            _helper.Send(email);
        }
    }
}
