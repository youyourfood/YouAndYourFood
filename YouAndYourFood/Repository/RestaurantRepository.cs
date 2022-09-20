using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Runtime.Serialization.Formatters.Binary;
using YouAndYourFood.Models;
using YouAndYourFood.Repository;

namespace YouAndYourFood.Repository;

public class RestaurantRepository : IRestaurantRepository
{

    RestaurantsData IRestaurantRepository.GetRestaurants()
    {
        string data = System.IO.File.ReadAllText(@"C:\Users\srkolluru\Desktop\YouAndYourFood\YouAndYourFood\yyf.json");
        RestaurantsData restaurants = JsonConvert.DeserializeObject<RestaurantsData>(data);

        return restaurants;
    }
}