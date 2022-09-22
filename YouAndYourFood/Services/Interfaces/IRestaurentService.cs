using YouAndYourFood.Models;

namespace YouAndYourFood.Services;

public interface IRestaurentService
{
    RestaurantsData GetRestaurents();

    UsersPreferencesCollection GetUsersPreferences();

    UsersPreferencesCollection AddPreference(Preference preference, string username);
}
