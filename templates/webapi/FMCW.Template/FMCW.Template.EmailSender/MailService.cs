using FMCW.Template.Results;
using MailKit.Security;
using Microsoft.Extensions.Logging;
using MimeKit;
using System;
using System.Net.Mail;

namespace FMCW.Template.EmailSender
{
    public class MailService
    {
        private readonly EmailConfig _emailConfig;
        private readonly ILogger<MailService> _logger;

        public MailService(ILogger<MailService> logger,
                            EmailConfig emailConfig)
        {
            _logger = logger;
            _emailConfig = emailConfig;
        }

        private BoolResult EnviarMail(MimeMessage message)
        {
            throw new NotImplementedException();
            //message.From.Add(new MailboxAddress(_emailConfig.FromName, _emailConfig.From));
            //try
            //{
            //    using (var client = new SmtpClient())
            //    {
            //        client.Connect(_emailConfig.Smtp, _emailConfig.Port, SecureSocketOptions.StartTls);

            //        client.AuthenticationMechanisms.Remove("XOAUTH2");

            //        // Note: only needed if the SMTP server requires authentication
            //        client.Authenticate(_emailConfig.From, _emailConfig.FromPassword);

            //        client.Send(message);
            //        client.Disconnect(true);
            //    }
            //    return BoolResult.Ok();
            //}
            //catch (SmtpProtocolException ex)
            //{
            //    _logger.LogError(ex.ToString());
            //    return BoolResult.Error(ex);
            //}
        }

        public BoolResult SendTestMail()
        {
            var message = new MimeMessage();
            message.To.Add(new MailboxAddress("TO_NAME", "TO_EMAIL"));
            message.Subject = "SUBJECT";

            var bodyBuilder = new BodyBuilder
            {
                HtmlBody = "HTML_BODY"
            };
            message.Body = bodyBuilder.ToMessageBody();

            return EnviarMail(message);
        }
    }
}
