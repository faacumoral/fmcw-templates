using FMCW.Template.Results;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MimeKit;
using System.Threading.Tasks;

namespace FMCW.Template.EmailSender
{
    public class MailService : IMailService
    {
        private readonly MailConfig _mailConfig;
        private string _adminMail;

        public MailService(IConfiguration configuration,
                            MailConfig mailConfig)
        {
            _mailConfig = mailConfig;
            _adminMail = configuration["Admin"];
        }

        public async Task<BoolResult> SendMail(MailRequest mailRequest)
        {
            var email = new MimeMessage
            {
                Sender = MailboxAddress.Parse(_mailConfig.From)
            };
            email.To.Add(MailboxAddress.Parse(mailRequest.To));
            email.Subject = mailRequest.Subject;
            var builder = new BodyBuilder();
            if (mailRequest.Attachments != null)
            {
                foreach (var file in mailRequest.Attachments)
                {  
                    builder.Attachments.Add(file.FileName, file.Content, ContentType.Parse(file.ContentType));
                    
                }
            }
            builder.HtmlBody = mailRequest.Body;
            email.Body = builder.ToMessageBody();
            using var smtp = new SmtpClient();
            smtp.Connect(_mailConfig.Smtp, _mailConfig.Port, SecureSocketOptions.StartTls);
            smtp.Authenticate(_mailConfig.From, _mailConfig.FromPassword);
            await smtp.SendAsync(email);
            smtp.Disconnect(true);
            return BoolResult.Ok();
        }

        public async Task<BoolResult> SendTestMail()
        {
            var message = new MailRequest
            {
                Body = "Test mail",
                Subject = "Test mail",
                To = _adminMail
            };
            return await SendMail(message);
        }
    }
}
