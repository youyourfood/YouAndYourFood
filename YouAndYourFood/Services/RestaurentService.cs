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

        public async Task<RestaurantsData> GetRestaurent()
        {
            return await restaurentRepository.GetRestaurent();
        }

        async Task<RestaurantsData> IRestaurentService.GetRestaurents()
        {
            return await restaurentRepository.GetRestaurents();
        }
    }
}