using YouAndYourFood.Models;

namespace YouAndYourFood.Repository
{
    public interface IRestaurentRepository
    {
        RestaurantsData GetRestaurents();

        UsersPreferencesCollection GetUsersPreferences();

        UsersPreferencesCollection SaveUserPreferences(UsersPreferencesCollection preferences);
    }
}
