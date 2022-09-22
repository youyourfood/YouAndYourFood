using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Runtime.Serialization.Formatters.Binary;
using YouAndYourFood.Repository;
using YouAndYourFood.Models;
using Azure.Storage.Blobs;
using Azure;
using System.ComponentModel;
using System;

namespace YouAndYourFood.Repository;

public class RestaurentRepository : IRestaurentRepository
{
    RestaurantsData dataReader()
    {
        string data = System.IO.File.ReadAllText("./Models/yyf.json");
        RestaurantsData restaurents = JsonConvert.DeserializeObject<RestaurantsData>(data);
        return restaurents;
    }

    public async Task<RestaurantsData> GetRestaurent()
    {
        return await readDinningData();
    }

    async Task<RestaurantsData> IRestaurentRepository.GetRestaurents()
    {
        return await readDinningData(); ;
    }

    private async Task<RestaurantsData> readDinningData()
    {
        try
        {
            var token = @"youandyourfoodcontainer?sp=r&st=2022-09-22T17:42:57Z&se=2022-09-28T01:42:57Z&spr=https&sv=2021-06-08&sr=c&sig=snC0BMwiSeXGmviZrmMNqYwjwve%2BEaqcyu%2B1hhFJVwk%3D";
            var uri = new Uri(@"https://youandyourfoodsa.blob.core.windows.net/" + token);
            var endpoint = $"{uri.Scheme}://{uri.Host}";
            var sasToken = uri.Query;

            var credentials = new AzureSasCredential(sasToken);
            var serviceClient = new BlobServiceClient(new Uri(endpoint), credentials);
            BlobContainerClient containerClient = serviceClient.GetBlobContainerClient("youandyourfoodcontainer");
            BlobClient blobClient = containerClient.GetBlobClient("yyf.json");
            if (await blobClient.ExistsAsync())
            {
                var response = await blobClient.DownloadAsync();
                using (var streamReader = new StreamReader(response.Value.Content))
                {
                    while (!streamReader.EndOfStream)
                    {
                        var data = await streamReader.ReadToEndAsync();

                        var rdata = JsonConvert.DeserializeObject<RestaurantsData>(data);

                        return rdata;

                    }
                }
            }

            return dataReader();

        }
        catch (Exception ex)
        {

            throw new Exception("Dinning data is not available.");
        }
    }
}