using Azure.Storage.Blobs;
using Azure.Data.Tables;
using Microsoft.AspNetCore.Mvc;
using FileUploadApi.Models;// 👈 for FileMetadata model
using Microsoft.Extensions.Logging;


[ApiController]
[Route("api/files")]
public class FilesController : ControllerBase
{
    private readonly BlobServiceClient _blobServiceClient;
    private readonly TableClient _tableClient;
    private readonly ILogger<FilesController> _logger;


    public FilesController(
    BlobServiceClient blobServiceClient,
    TableServiceClient tableServiceClient,
    ILogger<FilesController> logger)
    {
        _blobServiceClient = blobServiceClient;

        _tableClient = tableServiceClient.GetTableClient("FileMetadata");
        _tableClient.CreateIfNotExists();

        _logger = logger;
    }


    [HttpPost("upload")]
    public async Task<IActionResult> Upload(IFormFile file)
    {
        if (file == null || file.Length == 0)
            return BadRequest("No file uploaded");

        _logger.LogInformation("Uploading file: {FileName}", file.FileName);

        // Upload file to Blob Storage
        var container = _blobServiceClient.GetBlobContainerClient("uploads");
        await container.CreateIfNotExistsAsync();

        var blob = container.GetBlobClient(file.FileName);

        using var stream = file.OpenReadStream();
        await blob.UploadAsync(stream, overwrite: true);

        // Save metadata to Azure Table Storage
        var metadata = new FileMetadata
        {
            FileName = file.FileName,
            FileSize = file.Length,
            UploadTime = DateTime.UtcNow
        };

        await _tableClient.AddEntityAsync(metadata);

        _logger.LogInformation("Metadata saved for {FileName}", file.FileName);

        // Response
        return Ok(new
        {
            file.FileName,
            file.Length,
            Message = "File uploaded and metadata saved successfully"
        });
    }
}
