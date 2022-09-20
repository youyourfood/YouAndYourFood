namespace YouAndYourFood.Models
{
    public class RestaurantsData
    {
        public Restaurant[]? Restaurants { get; set; }
    }

    public class Restaurant
    {
        public string? Name { get; set; }
        
        public string? Image { get; set; }
    
        public string? PriceRange { get; set; }
        
        public string? ServesCuisine { get; set; }
        
        public Menu? Menu { get; set; }

        public int? MinWaitingTime { get; set; }

        public int? MaxWaitingTime { get; set; }
    }

    public class Menu
    {
        public Item[]? Items { get; set; }
    }

    public class Item
    {
        public string? Name { get; set; }

        public string? Image { get; set; }

        public string? Description { get; set; }

        public string? Price { get; set; }

        public string? Cooktimeinminutes { get; set; }

        public string? TotalOrders { get; set; }

        public int? WaitingTime { get; set; }

        public int? Calories { get; set; }
    }

}
