using YouAndYourFood.Models;

namespace YouAndYourFood.Services;

public interface IRestaurentService
{
    Task<UsersPreferencesCollection> GetUsersPreferences();

    Task<UsersPreferencesCollection> AddPreference(Preference preference, string username);

    Task<RestaurantsData> GetRestaurents();
    
    Task<RestaurantsData> GetRestaurent();
}
