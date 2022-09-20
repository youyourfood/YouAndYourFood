using YouAndYourFood.Models;

namespace YouAndYourFood.Repository
{
    public interface IRestaurentRepository
    {
        RestaurantsData GetRestaurents();
        RestaurantsData GetRestaurent();
    }
}
