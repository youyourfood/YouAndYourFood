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
        public RestaurantsData Get()
        {
            return restaurentService.GetRestaurents();
        }
    }
}