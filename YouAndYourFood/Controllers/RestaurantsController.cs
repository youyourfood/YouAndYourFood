using Microsoft.AspNetCore.Mvc;
using YouAndYourFood.Models;

namespace YouAndYourFood.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RestaurantsController : ControllerBase
    {
        private readonly ILogger<RestaurantsController> _logger;

        public RestaurantsController(ILogger<RestaurantsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public RestaurantsData Get()
        {
            return new RestaurantsData
            {
                Restaurants = new Restaurant[]
                {
                    new Restaurant
                    {
                        Name = "Acapulco Fresh",
                        Image = "https://fastly.4sqi.net/img/general/200x200/351684_xa9nBS_OAKxUEGE28o9VfnUzgtCSyI94HJw8Xrs2kqw.jpg",
                        MinWaitingTime = 15,
                        MaxWaitingTime = 30,
                        Menu = new Menu
                        {
                            Items = new Item[]
                            {
                                new Item
                                {
                                    Name = "Spicy Jalapeno Burrito",
                                    Image = "https://secureservercdn.net/192.169.223.13/002.49d.myftpupload.com/wp-content/uploads/2020/09/Burrito-pie-5-640x640.jpg",
                                    WaitingTime = 15,
                                    Calories = 500
                                }
                            }
                        }
                    },
                    new Restaurant
                    {
                        Name = "Taco Tuesday",
                        Image = "https://www.fbca.org/wp-content/uploads/2019/05/tacotuesday-logo-01-1024x1024.jpg",
                        MinWaitingTime = 15,
                        MaxWaitingTime = 30,
                        Menu = new Menu
                        {
                            Items = new Item[]
                            {
                                new Item
                                {
                                    Name = "Hard Shell Taco",
                                    Image = "https://i.pinimg.com/originals/f1/5a/04/f15a04f34b05687c8452cdff7e8985c5.jpg",
                                    WaitingTime = 15,
                                    Calories = 500
                                }
                            }
                        }
                    }
                }
            };
        }
    }
}