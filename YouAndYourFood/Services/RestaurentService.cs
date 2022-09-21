using Microsoft.AspNetCore.Mvc;
using YouAndYourFood.Models;
using YouAndYourFood.Repository;
using YouAndYourFood.Services;

namespace YouAndYourFood.Services
{
    public class RestaurentService : IRestaurentService
    {

        private readonly IRestaurentRepository restaurentRepository;

        public RestaurentService(IRestaurentRepository restaurentRepository)
        {
            this.restaurentRepository = restaurentRepository;
        }

        RestaurantsData IRestaurentService.GetRestaurents()
        {
            return restaurentRepository.GetRestaurents();
        }
    }
}