using Valtegy.Domain.Models;
using Microsoft.Extensions.Options;
using System;
using System.Net.Mail;
using Valtegy.Domain.Services;

namespace Valtegy.Service.Services
{
    public class SmtpEmailConfiguration
    {
        public string Server { get; set; }
        public int Port { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
    }

    public class EmailService : IEmailService
    {
        private readonly IOptions<SmtpEmailConfiguration> _emailOptions;

        public EmailService(IOptions<SmtpEmailConfiguration> emailOptions)
        {
            _emailOptions = emailOptions;
        }

        public ResponseModel Send(string to, string subject, string body, bool isBodyHtml = false, string cc = "", string cco = "")
        {
            MailMessage message = new (_emailOptions.Value.User, to)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = isBodyHtml
            };

            if (!string.IsNullOrEmpty(cc))
                message.CC.Add(cc);

            if (!string.IsNullOrEmpty(cco))
                message.Bcc.Add(cco);

            SmtpClient client = new (_emailOptions.Value.Server)
            {
                Port = _emailOptions.Value.Port,
                Credentials = new System.Net.NetworkCredential(_emailOptions.Value.User, _emailOptions.Value.Password)
            };

            try
            {
                client.Send(message);
                return new ResponseModel(true, null);
            }
            catch (Exception ex)
            {
                return new ResponseModel(false, ex.Message);
            }
        }
    }
}
