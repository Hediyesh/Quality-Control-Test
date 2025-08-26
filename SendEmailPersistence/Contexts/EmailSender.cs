using Microsoft.Extensions.Configuration;
using SendEmailApplication.Interfaces.Contexts;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace SendEmailPersistence.Contexts
{

    public class EmailSender : IEmailSender
    {
        private readonly IConfiguration _configuration;

        public EmailSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var smtpSection = _configuration.GetSection("Smtp");

            using var smtpClient = new SmtpClient
            {
                Host = smtpSection["Host"],
                Port = int.Parse(smtpSection["Port"]),
                EnableSsl = true, // پورت 587 نیاز به STARTTLS دارد
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(
                    smtpSection["UserName"],
                    smtpSection["Password"]
                )
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress("hello@demomailtrap.co", "Magic Elves"), // ✅ آدرس مجاز
                Subject = subject,
                Body = htmlMessage,
                IsBodyHtml = true
            };

            mailMessage.To.Add(email);

            await smtpClient.SendMailAsync(mailMessage);
        }

        //private readonly string _smtpHost;
        //private readonly int _smtpPort;
        //private readonly string _smtpUser;
        //private readonly string _smtpPass;
        //private readonly string _fromAddress;

        //public EmailSender(IConfiguration config)
        //{
        //    _smtpHost = config["EmailSettings:SmtpServer"];
        //    _smtpPort = int.Parse(config["EmailSettings:Port"]);
        //    _smtpUser = config["EmailSettings:Username"];
        //    _smtpPass = config["EmailSettings:Password"];
        //    _fromAddress = config["EmailSettings:From"];
        //}

        //public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        //{
        //    using var client = new SmtpClient(_smtpHost, _smtpPort)
        //    {
        //        Credentials = new NetworkCredential(_smtpUser, _smtpPass),
        //        EnableSsl = true
        //    };

        //    var mail = new MailMessage(_fromAddress, email, subject, htmlMessage)
        //    {
        //        IsBodyHtml = true
        //    };

        //    await client.SendMailAsync(mail);
        //}
    }
}
