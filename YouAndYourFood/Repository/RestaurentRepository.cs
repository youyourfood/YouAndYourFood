using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Runtime.Serialization.Formatters.Binary;
using YouAndYourFood.Repository;
using YouAndYourFood.Models;

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

    RestaurantsData IRestaurentRepository.GetRestaurents()
    {
        return RestaurantDataReader();
    }
}