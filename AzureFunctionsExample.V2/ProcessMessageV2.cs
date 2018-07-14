using AzureFunctionExample.ResourceAccess;
using AzureFunctionExample.ResourceAccess.DataAccess;
using AzureFunctionsExample.Shared;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace AzureFunctionsExample.V2
{
    public static class ProcessMessageV2
    {
        [FunctionName("ProcessMessageV2")]
        public static void Run([QueueTrigger("messages", Connection = "AzureWebJobsStorage")]QueueMessage myQueueItem, TraceWriter log, ExecutionContext context)
        {
            var dbContext = OrderDbContext.GetInstance(Environment.GetEnvironmentVariable("OrderDbConnection"));
            var blobService = new BlobStorageService(Environment.GetEnvironmentVariable("BlobStorageUri"),
                Environment.GetEnvironmentVariable("BlobStorageAccount"),
                Environment.GetEnvironmentVariable("BlobStorageKey")
                );

            var order = dbContext.Order.Include(o => o.Person).FirstOrDefault(o => o.Id == myQueueItem.Order && o.PersonID == myQueueItem.Person);

            var mailData = new MailData
            {
                PersonName = $"{order.Person.FirstName} {order.Person.LastName}",
                Email = order.Person.Email,
                OrderNumber = order.OrderNumber,
                Status = ((OrderStatus)myQueueItem.Status).ToString(),
                EmailTemplate = blobService.GetEmailTemplateContents(Environment.GetEnvironmentVariable("EmailTemplateContainerName"),
                    Environment.GetEnvironmentVariable("EmailTemplateBlobName"))
            };

            var senGridService = new EmailService(Environment.GetEnvironmentVariable("SendGridApiKey"), Environment.GetEnvironmentVariable("FromEmail"));
            senGridService.SendEmail(mailData);

            log.Info($"C# Queue trigger function processed: {myQueueItem}");
        }
    }
}
