using YouAndYourFood.Models;

namespace YouAndYourFood.Services;

public interface IRestaurentService
{
    Task<RestaurantsData> GetRestaurents();
    Task<RestaurantsData> GetRestaurent();
}
