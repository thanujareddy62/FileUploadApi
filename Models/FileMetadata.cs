using Azure;
using Azure.Data.Tables;

namespace FileUploadApi.Models
{
    public class FileMetadata : ITableEntity
    {
        // Group all uploaded files together
        public string PartitionKey { get; set; } = "Uploads";

        // Unique row per file
        public string RowKey { get; set; } = Guid.NewGuid().ToString();

        public string FileName { get; set; }
        public long FileSize { get; set; }
        public DateTime UploadTime { get; set; }

        public DateTimeOffset? Timestamp { get; set; }
        public ETag ETag { get; set; }
    }
}