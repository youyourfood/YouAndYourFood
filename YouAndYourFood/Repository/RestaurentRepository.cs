using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Runtime.Serialization.Formatters.Binary;
using YouAndYourFood.Repository;
using YouAndYourFood.Models;

namespace YouAndYourFood.Repository;

public class RestaurentRepository : IRestaurentRepository
{
    RestaurantsData dataReader()
    {
        string data = System.IO.File.ReadAllText("./Models/json.json");
        RestaurantsData restaurents = JsonConvert.DeserializeObject<RestaurantsData>(data);
        return restaurents;
    }

    public RestaurantsData GetRestaurent()
    {

        return dataReader();
    }

    RestaurantsData IRestaurentRepository.GetRestaurents()
    {
        RestaurantsData restaurents = dataReader();

        return restaurents;
    }
}