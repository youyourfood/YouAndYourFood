using YouAndYourFood.Models;

namespace YouAndYourFood.Repository
{
    public interface IRestaurantRepository
    {
        RestaurantsData GetRestaurants();
    }
}
