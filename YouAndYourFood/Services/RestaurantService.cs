using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using YouAndYourFood.Models;
using YouAndYourFood.Repository;
using YouAndYourFood.Services;

namespace YouAndYourFood.Services
{
    public class RestaurantService : IRestaurantService
    {

        private readonly IRestaurantRepository restaurantRepository;

        public RestaurantService(IRestaurantRepository restaurantRepository)
        {
            this.restaurantRepository = restaurantRepository;
        }
        RestaurantsData IRestaurantService.GetRestaurants()
        {
            return restaurantRepository.GetRestaurants();
        }
    }
}