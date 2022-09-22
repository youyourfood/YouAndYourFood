using YouAndYourFood.Models;

namespace YouAndYourFood.Repository
{
    public interface IRestaurentRepository
    {
        UsersPreferencesCollection GetUsersPreferences();

        UsersPreferencesCollection SaveUserPreferences(UsersPreferencesCollection preferences);

        Task<RestaurantsData> GetRestaurents();
        
        Task<RestaurantsData> GetRestaurent();
    }
}
