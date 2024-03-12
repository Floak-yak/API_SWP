using API_SWP.Interface;
using System.Net;
using System.Net.Mail;

namespace API_SWP.Repository
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string message)
        {
            var mail = "";
            var password = ".";
            var client = new SmtpClient("mail", 587)
            {
                EnableSsl = true,
                Credentials = new NetworkCredential(mail, password)
            };
            return client.SendMailAsync(new MailMessage(from: mail, to: email, "Bao gia tien", message));
        }
    }
}
