
using GuardianNotifyBackend.Domain;
using GuardianNotifyBackend.Services.NotificationService;
using Microsoft.Extensions.Configuration;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

public static class SmsNotificationSender
{
    public class EmailNotificationSender : IEmailNotificationSender
    {
        private readonly string _smtpServer;
        private readonly int _smtpPort;
        private readonly string _smtpUsername;
        private readonly string _smtpPassword;

        public EmailNotificationSender(IConfiguration configuration)
        {
            _smtpServer = configuration["Email:SmtpServer"];
            _smtpPort = int.Parse(configuration["Email:SmtpPort"]);
            _smtpUsername = configuration["Email:SmtpUsername"];
            _smtpPassword = configuration["Email:SmtpPassword"];
        }

        public async Task<EmailResult> SendEmailNotificationAsync(string recipientEmail, string message)
        {
            try
            {
                using var smtpClient = new SmtpClient(_smtpServer)
                {
                    Port = _smtpPort,
                    Credentials = new NetworkCredential(_smtpUsername, _smtpPassword),
                    EnableSsl = true,
                };

                using var mailMessage = new MailMessage(_smtpUsername, recipientEmail)
                {
                    Subject = "Notification",
                    Body = message
                };

                await smtpClient.SendMailAsync(mailMessage);

                return new EmailResult
                {
                    Success = true,
                    Message = "Email sent successfully",
                    RecipientEmail = recipientEmail
                };
            }
            catch (Exception ex)
            {
                return new EmailResult
                {
                    Success = false,
                    Message = ex.Message,
                    RecipientEmail = recipientEmail
                };
            }
        }
    }

}
