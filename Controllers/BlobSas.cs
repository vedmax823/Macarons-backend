using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Azure.Storage.Sas;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System.ComponentModel.DataAnnotations;
using Azure.Storage.Blobs;


namespace DonMacaron.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlobSas(IConfiguration configuration) : ControllerBase
    {
        private readonly IConfiguration _configuration = configuration;

        private string? _connectionString;
        private string? _containerName;

        [HttpGet("generate-sas")]
        [Authorize]
        public IActionResult GetContainerSasUrl()
        {
            try
            {
                _connectionString = _configuration["AzureStorage:ConnectionString"];
                if (string.IsNullOrEmpty(_connectionString))
                {
                    return BadRequest("Connection string is not configured.");
                }
                _containerName = _configuration["AzureStorage:ContainerName"];
                if (string.IsNullOrEmpty(_containerName))
                {
                    return BadRequest("Container Name is not configured.");
                }
                var sasProtocol = _configuration["AzureStorage:SasProtocol"];
                var storageName = _configuration["AzureStorage:StorageName"];
                var storageKey = _configuration["AzureStorage:StorageKey"];
                // Створення клієнта служби Blob Storage
                BlobServiceClient blobServiceClient = new BlobServiceClient(_connectionString);

                // Створюємо SAS токен на рівні облікового запису
                var sasBuilder = new AccountSasBuilder
                {
                    Services = AccountSasServices.Blobs | AccountSasServices.Files,
                    ResourceTypes = AccountSasResourceTypes.Service | AccountSasResourceTypes.Container | AccountSasResourceTypes.Object,
                    Protocol = sasProtocol == "HttpsAndHttp" ? SasProtocol.HttpsAndHttp : SasProtocol.Https,
                    StartsOn = DateTimeOffset.UtcNow.AddMinutes(-5), // Невеликий зсув назад на випадок різниці часу
                    ExpiresOn = DateTimeOffset.UtcNow.AddHours(1) // Час закінчення дії SAS токена
                };

                // Додати дозволи (читання, запис, видалення, листинг, і т.д.)
                sasBuilder.SetPermissions(AccountSasPermissions.Read |
                                          AccountSasPermissions.Write |
                                          AccountSasPermissions.List);

                // Generate SAS token
                string sasToken = sasBuilder.ToSasQueryParameters(
                    new Azure.Storage.StorageSharedKeyCredential(storageName, storageKey)).ToString();

                // Construct SAS URL for the container
                var sasUrl = $"{blobServiceClient.Uri}?{sasToken}";

                return Ok(new { sasUrl });
            }
            catch (Exception)
            {
                return StatusCode(500, new { message = "An unexpected error occurred." });
            }
        }

    }
}
