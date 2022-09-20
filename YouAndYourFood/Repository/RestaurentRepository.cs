using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Runtime.Serialization.Formatters.Binary;
using YouAndYourFood.Repository;
using YouAndYourFood.Models;

namespace YouAndYourFood.Repository;

public class RestaurentRepository : IRestaurentRepository
{

    RestaurantsData IRestaurentRepository.GetRestaurents()
    {
        string data = System.IO.File.ReadAllText(@"C:\Users\srkolluru\Desktop\YouAndYourFood\YouAndYourFood\yyf.json");
        RestaurantsData restaurents = JsonConvert.DeserializeObject<RestaurantsData>(data);

        return restaurents;
    }
}