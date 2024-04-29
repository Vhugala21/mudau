# Azure Blob Storage Project

## Overview
This project demonstrates how to perform basic operations on Azure Blob Storage using the Azure.Storage.Blobs library in C#. It includes examples of uploading, listing, downloading, and deleting blobs.

## Prerequisites
- An Azure subscription
- An Azure Storage Account
- .NET Core SDK

## Configuration
Replace the `connectionString` variable in the `Program.cs` file with your Azure Storage Account connection string.

## Usage
The `Program` class contains asynchronous methods to interact with Azure Blob Storage:
- `UploadBlobAsync`: Uploads a file to a specified blob.
- `ListBlobsAsync`: Lists all blobs in a specified container.
- `DownloadBlobAsync`: Downloads a specified blob to a local file path.
- `DeleteBlobAsync`: Deletes a specified blob.

## Running the Application
To run the application, use the following command in the terminal:

```shell
dotnet run
