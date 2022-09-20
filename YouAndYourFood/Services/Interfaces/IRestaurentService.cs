using YouAndYourFood.Models;

namespace YouAndYourFood.Services;

public interface IRestaurentService
{
    RestaurantsData GetRestaurents();
    RestaurantsData GetRestaurent();
}
