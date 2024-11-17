using GuardianNotifyBackend.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuardianNotifyBackend.Services.NotificationService
{
        public interface IEmailNotificationSender
        {
            Task<EmailResult> SendEmailNotificationAsync(string recipientEmail, string message);
        }
    
}
