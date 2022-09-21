using YouAndYourFood.Models;

namespace YouAndYourFood.Repository
{
    public interface IRestaurentRepository
    {
        Task<RestaurantsData> GetRestaurents();
        Task<RestaurantsData> GetRestaurent();
    }
}
