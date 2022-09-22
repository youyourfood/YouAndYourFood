using YouAndYourFood.Models;

namespace YouAndYourFood.Repository
{
    public interface IRestaurentRepository
    {
        Task<UsersPreferencesCollection> GetUsersPreferences();

        Task<UsersPreferencesCollection> SaveUserPreferences(UsersPreferencesCollection preferences);

        Task<RestaurantsData> GetRestaurents();
        
        Task<RestaurantsData> GetRestaurent();
    }
}
