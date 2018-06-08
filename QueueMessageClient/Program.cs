using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Queue;
using Newtonsoft.Json;

namespace QueueMessageClient
{
    class Program
    {
        static void Main(string[] args)
        {
            //Get access to appsettings
            var builder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json");
            var configuration = builder.Build();

            //Get or create queue in StorageAccount
            var client = new CloudQueueClient(new Uri(configuration["AzureStorageUri"]), 
                new StorageCredentials(configuration["AzureStorageAccountName"],configuration["AzureStorageAccountKey"]));
             var queue = client.GetQueueReference(configuration["AzureStorageQueueName"]);
            var creationresult = queue.CreateIfNotExistsAsync().Result;

            //Create and send message as JSON
            var message = new QueueMessage
            {
                Order = 1,
                Person = 1,
                Status = (int)OrderStatus.Processed
            };
            var messageJSON = JsonConvert.SerializeObject(message);
            queue.AddMessageAsync(new CloudQueueMessage(messageJSON));

            Console.WriteLine("Message Sent");
            Console.ReadKey();
        }
    }
}
