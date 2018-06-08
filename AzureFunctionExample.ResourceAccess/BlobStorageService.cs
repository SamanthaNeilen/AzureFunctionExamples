using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.IO;

namespace AzureFunctionExample.ResourceAccess
{
    public class BlobStorageService
    {
        private readonly string _storageUri;
        private readonly string _accountName;
        private readonly string _key;

        public BlobStorageService(string storageUri, string accountName, string key)
        {
            _storageUri = storageUri;
            _accountName = accountName;
            _key = key;
        }

        public string GetEmailTemplateContents(string containerName, string emailTemplateName)
        {
            var result = string.Empty;
            CloudBlobClient client = new CloudBlobClient(new Uri(_storageUri), new StorageCredentials(_accountName, _key));
            var container = client.GetContainerReference(containerName);

            if (container.ExistsAsync().Result)
            {
                using (var stream = new MemoryStream())
                {
                    var blob = container.GetBlobReference(emailTemplateName);
                    blob.DownloadToStreamAsync(stream).Wait();

                    stream.Position = 0; 
                    result = new StreamReader(stream).ReadToEnd();
                }
            }
            else
            {
                throw new Exception($"Container {containerName} not found");
            }
            return result;
        }        
    }
}
