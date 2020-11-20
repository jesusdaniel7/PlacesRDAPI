using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PlacesRDAPI.Services
{
    public class FileStoraAzure : IFileStorage
    {
        private readonly string connectionstring;

        public FileStoraAzure(IConfiguration  configuration)
        {
            connectionstring = configuration.GetConnectionString("AzureStorage");
        }

        public async Task DeleteFile(string route, string container)
        {
            if (route != null)
            {
                var account = CloudStorageAccount.Parse(connectionstring);
                var client = account.CreateCloudBlobClient();
                var containerReference = client.GetContainerReference(container);

                var blobName = Path.GetFileName(route);
                var blob = containerReference.GetBlobReference(blobName);

                await blob.DeleteIfExistsAsync();
            }
        }

        public async Task<string> EditFile(byte[] content, string extension, string container, string route, string contentType)
        {
            await DeleteFile(route, container);
            return await SaveFile(content, extension, container, contentType);
        }

        public async Task<string> SaveFile(byte[] content, string extension, string container, string contentType)
        {
            var account = CloudStorageAccount.Parse(connectionstring);
            var client = account.CreateCloudBlobClient();
            var containerReference = client.GetContainerReference(container);

            await containerReference.CreateIfNotExistsAsync();
            await containerReference.SetPermissionsAsync(new BlobContainerPermissions
            {
                PublicAccess = BlobContainerPublicAccessType.Blob
            });
            var fileName = $"{Guid.NewGuid()}{extension}";
            var blob = containerReference.GetBlockBlobReference(fileName);
            await blob.UploadFromByteArrayAsync(content, 0, content.Length);
            blob.Properties.ContentType = contentType;
            await blob.SetPropertiesAsync();
            return blob.Uri.ToString();
        }
    }
}
