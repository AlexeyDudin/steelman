using Domain;
using System.Net;
using System.Net.Mail;

namespace Infrastructure.EMail
{
    public class EMailHelper : IEmailSender
    {
        private const string _sendMessageTo = "info@steelman12.ru";
        private const string _sendMessageFrom = "admin@steelman12.ru";
        private const string _password = "Zaqwsx_655";

        private readonly MailAddress _fromMail = new MailAddress(_sendMessageFrom);
        private readonly MailAddress _toMail = new MailAddress(_sendMessageTo);
        private readonly SmtpClient smtp = new SmtpClient("mail.steelman12.ru", 587);

        public async void Send(EmailModel email)
        {
            try
            {
                MailMessage m = new MailMessage(_fromMail, _toMail);
                m.Subject = "Запрос с сайта";
                m.Body = @$"От пользователя: {email.FromUser}
Тема: {email.Theme}
Сообщение: {email.Text}";
                m.IsBodyHtml = false;
                smtp.Credentials = new NetworkCredential(_sendMessageFrom, _password);
                smtp.EnableSsl = false;
                await smtp.SendMailAsync(m);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
