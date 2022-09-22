using YouAndYourFood.Models;

namespace YouAndYourFood.Services;

public interface IRestaurentService
{
    UsersPreferencesCollection GetUsersPreferences();

    UsersPreferencesCollection AddPreference(Preference preference, string username);

    Task<RestaurantsData> GetRestaurents();
    
    Task<RestaurantsData> GetRestaurent();
}
