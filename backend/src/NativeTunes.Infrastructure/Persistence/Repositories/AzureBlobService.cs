using Azure.Storage.Blobs;
using Azure.Storage;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using NativeTunes.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;

namespace NativeTunes.Infrastructure.Persistence.Repositories
{
    public class AzureBlobService : IStorageService
    {
        private readonly string _containerName = "assets";
        private readonly AzureBlobSettings _azureBlobSettings;
        private readonly BlobServiceClient _blobServiceClient;
        public AzureBlobService(IOptions<AzureBlobSettings> azureBlobOptions)
        {
            _azureBlobSettings = azureBlobOptions.Value;
            var credentials = new StorageSharedKeyCredential(_azureBlobSettings.StorageAccount, _azureBlobSettings.Key);
            var blobUri = $"https://{_azureBlobSettings.StorageAccount}.blob.core.windows.net";

            _blobServiceClient = new BlobServiceClient(new System.Uri(blobUri), credentials);
        }
        public async Task<FileUploadInfo> UploadFileAsync(string folder, IFormFile file)
        {
            var fileExtension = Path.GetExtension(file.FileName);
            if (String.IsNullOrEmpty(fileExtension))
            {
                return FileUploadInfo.Failed("Invalid Extension");
            }
            var fileName = Guid.NewGuid() + fileExtension;


            var containerClient = _blobServiceClient.GetBlobContainerClient(_containerName);
            BlobClient client = containerClient.GetBlobClient($"{folder}/{fileName}");
            await using (Stream data = file.OpenReadStream())
            {
                await client.UploadAsync(data);
            }
            return new FileUploadInfo(fileName.ToString(), client.Uri.AbsoluteUri);

        }
        public async Task<bool> DeleteAsync(string fileUrl)
        {
            var blobName = GetBlobNameFromUrl(fileUrl);

            var containerClient = _blobServiceClient.GetBlobContainerClient(_containerName);

            BlobClient blobClient = containerClient.GetBlobClient(blobName);
            if (!await blobClient.ExistsAsync())
            {
                return false;
            }
            await blobClient.DeleteAsync();
            return true;

        }
        private static string GetBlobNameFromUrl(string fileUrl)
        {
            Uri fileUri = new Uri(fileUrl);
            string blobName = fileUri.AbsolutePath;
            string[] parts = blobName.Split('/');

            if (parts.Length < 3)
            {
                throw new ArgumentException("Invalid Blob Uri");
            }
            return string.Join("/", parts, 2, parts.Length - 2);
        }
    }
}
