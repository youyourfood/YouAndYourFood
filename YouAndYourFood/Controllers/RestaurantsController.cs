using Microsoft.AspNetCore.Mvc;
using YouAndYourFood.Models;
using YouAndYourFood.Services;

namespace YouAndYourFood.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RestaurantsController : ControllerBase
    {
        private readonly ILogger<RestaurantsController> _logger;

        private readonly IRestaurentService restaurentService;

        public RestaurantsController(ILogger<RestaurantsController> logger,
            IRestaurentService restaurentService)
        {
            _logger = logger;
            this.restaurentService = restaurentService;
        }

        [HttpGet]
        public async Task<RestaurantsData> Get()
        {
            return await restaurentService.GetRestaurents();
        }

        [HttpPut(Name = "/getUserPreferences")]
        public async Task<UserPreferences> GetUserPreferences(string username)
        {
            return await restaurentService.GetUserPreferences(username);
        }

        [HttpPut(Name = "/addPreference")]
        public async Task<UsersPreferencesCollection> AddPreference(Preference preference, string username)
        {
            return await restaurentService.AddPreference(preference, username);
        }
    }
}