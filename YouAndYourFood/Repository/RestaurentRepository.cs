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
    RestaurantsData RestaurantDataReader()
    {
        string data = System.IO.File.ReadAllText("./Models/json.json");
        RestaurantsData restaurents = JsonConvert.DeserializeObject<RestaurantsData>(data);
        return restaurents;
    }

    UsersPreferencesCollection PreferencesDataReader()
    {
        string data = System.IO.File.ReadAllText("./Models/preferences.json");
        UsersPreferencesCollection preferences = JsonConvert.DeserializeObject<UsersPreferencesCollection>(data);
        return preferences;
    }

    public UsersPreferencesCollection SaveUserPreferences(UsersPreferencesCollection preferences)
    {
        StreamWriter file = new("./Models/preferences.json");
        string data = JsonConvert.SerializeObject(preferences);
        try
        {
            file.WriteLineAsync(data);
            file.Close();
        }
        catch
        {
            throw;
        }
        return PreferencesDataReader();
    }

    public UsersPreferencesCollection GetUsersPreferences()
    {
        return PreferencesDataReader();
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
            var token = @"youandyourfoodcontainer?sp=r&st=2022-09-21T23:58:18Z&se=2022-09-27T07:58:18Z&spr=https&sv=2021-06-08&sr=c&sig=4VGPKmH6893%2FBVbxj6M6YH3xkjaY9NrwYGtLl45stL4%3D";
            var uri = new Uri(@"https://youandyourfoodsa.blob.core.windows.net/"+token);
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