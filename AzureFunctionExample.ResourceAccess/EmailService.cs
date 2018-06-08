using AzureFunctionsExample.Shared;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace AzureFunctionExample.ResourceAccess
{
    public class EmailService
    {
        private readonly string _apiKey;
        private readonly string _from;
        private IEnumerable<HttpStatusCode> _validStatusCodes = new List<HttpStatusCode>{
            HttpStatusCode.Accepted,
            HttpStatusCode.OK
        };


        public EmailService(string apiKey, string from)
        {
            _apiKey = apiKey;
            _from = from;
        }


        public void SendEmail(MailData mailData)
        {
            var message = new SendGridMessage() {
                From = new EmailAddress(_from)
            };

            message.AddTo(new EmailAddress(mailData.Email));

            message.HtmlContent = mailData.EmailTemplate
                .Replace("{CONTACT}",mailData.PersonName)
                .Replace("{ORDERNUMBER}", mailData.PersonName)
                .Replace("{STATUS}", mailData.Status);
                
            message.Subject = "Mail from Azure Function";

            var client = new SendGridClient(_apiKey);
            var response = client.SendEmailAsync(message).Result;
            if (!_validStatusCodes.Contains(response.StatusCode))
            {
                throw new Exception("Error sending mail");
            }
        }
    }
}
