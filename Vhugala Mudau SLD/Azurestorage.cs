using Azure.Storage.Blobs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

public class Program
{
    static async Task Main(string[] args)
    {
        // Retrieve your connection string from the Azure portal
        string connectionString = "DefaultEndpointsProtocol=https;AccountName=azblobsld2024;AccountKey=ZckiZALlmvO4ZRKFQPB3ogeXRd5ZRF3FbV3BQ56h1tiAkMySYESOdhlUtIoWEXmoeC01mwJGhwQe+ASt2lgc/g==;EndpointSuffix=core.windows.net";

        // Initialize BlobServiceClient with the connection string
        BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);

        string containerName = "vhugalacontainer";
        string blobName = "blobvhu";
        string filePath = "C:\\Users\\Vhugala\\OneDrive - CTU Career\\Documents\\#slddiff\\blobvhu.txt";
        string downloadPath = "C:\\Users\\Vhugala\\OneDrive - CTU Career\\Documents\\#slddiff\\blobvhu.txt";

        await UploadBlobAsync(blobServiceClient, containerName, blobName, filePath);
        await ListBlobsAsync(blobServiceClient, containerName);
        await DownloadBlobAsync(blobServiceClient, containerName, blobName, downloadPath);
        await DeleteBlobAsync(blobServiceClient, containerName, blobName);
    }

    static async Task UploadBlobAsync(BlobServiceClient blobServiceClient, string containerName, string blobName, string filePath)
    {
        try
        {
            // Get a reference to the container
            var containerClient = blobServiceClient.GetBlobContainerClient(containerName);

            // Create the container if it doesn't exist
            await containerClient.CreateIfNotExistsAsync();

            // Get a reference to the blob
            var blobClient = containerClient.GetBlobClient(blobName);

            // Upload the file
            await blobClient.UploadAsync(filePath, true);

            Console.WriteLine($"File '{Path.GetFileName(filePath)}' uploaded successfully to blob '{blobName}' in container '{containerName}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error uploading blob: {ex.Message}");
        }
    }

    static async Task ListBlobsAsync(BlobServiceClient blobServiceClient, string containerName)
    {
        try
        {
            var containerClient = blobServiceClient.GetBlobContainerClient(containerName);

            // List blobs in the container
            await foreach (var blobItem in containerClient.GetBlobsAsync())
            {
                Console.WriteLine($"Blob: {blobItem.Name}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error listing blobs: {ex.Message}");
        }
    }

    static async Task DownloadBlobAsync(BlobServiceClient blobServiceClient, string containerName, string blobName, string downloadPath)
    {
        try
        {
            var containerClient = blobServiceClient.GetBlobContainerClient(containerName);
            var blobClient = containerClient.GetBlobClient(blobName);

            // Download the blob
            await blobClient.DownloadToAsync(downloadPath);

            Console.WriteLine($"Blob '{blobName}' downloaded successfully to '{downloadPath}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error downloading blob: {ex.Message}");
        }
    }

    static async Task DeleteBlobAsync(BlobServiceClient blobServiceClient, string containerName, string blobName)
    {
        try
        {
            var containerClient = blobServiceClient.GetBlobContainerClient(containerName);

            // Get a reference to the blob
            var blobClient = containerClient.GetBlobClient(blobName);

            // Check if blob exists before attempting to delete
            if (await blobClient.ExistsAsync())
            {
                // Delete the blob
                await blobClient.DeleteAsync();
                Console.WriteLine($"Blob '{blobName}' deleted successfully.");
            }
            else
            {
                Console.WriteLine($"Blob '{blobName}' does not exist.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error deleting blob: {ex.Message}");
            // You can handle the error appropriately (e.g., log it, throw it, etc.)
        }
    }
}
