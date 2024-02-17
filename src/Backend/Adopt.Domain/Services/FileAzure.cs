using Azure.Storage.Blobs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Adopt.Domain.Services;

public class FileAzure
{
    BlobServiceClient blobServiceClient = new BlobServiceClient("DefaultEndpointsProtocol=https;AccountName=adoptme;AccountKey=YxY7VK7lzeSbv0rkD8dQhp373A/2kLuz47gRtcOJYaGflCJW1NJWQVhPhqgzT7FlB7NR2XaGiqUg+AStIx6liQ==;EndpointSuffix=core.windows.net");

    public string UploadFile(string base64,string container)
    {
        

        var fileName = Guid.NewGuid().ToString() + ".png";

        var data = new Regex(@"^data:image\/[a-zA-Z]+;base64,").Replace(base64, "");

        byte[] bytes = Convert.FromBase64String(data);

        var blobContainerClient = blobServiceClient.GetBlobContainerClient(container);

        var blobClient = blobContainerClient.GetBlobClient(fileName);

        using (var stream = new MemoryStream(bytes))
        {
            blobClient.Upload(stream);
        }

        return blobClient.Uri.AbsoluteUri;
    }

    public async Task<byte[]> DowloadFile(string urlImage)
    {
        try
        {

            using (var webClient = new WebClient())
            {
                var bytes = await webClient.DownloadDataTaskAsync(new Uri(urlImage));
                return bytes;
            }
        }
        catch (Exception)
        {
            throw new ApplicationException("Erro ao baixar a imagem");
        }
        
    }

    public async Task DeleteFile(string urlImage)
    {
        var blobUriBuilder = new UriBuilder(urlImage);
        string containerName = blobUriBuilder.Uri.Segments[1]; 
        string blobName = blobUriBuilder.Uri.Segments[2]; 

        var blobContainerClient = blobServiceClient.GetBlobContainerClient(containerName);
        var blobClient = blobContainerClient.GetBlobClient(blobName);

        await blobClient.DeleteIfExistsAsync();

        Console.WriteLine("Imagem deletada com sucesso.");
    }
}




