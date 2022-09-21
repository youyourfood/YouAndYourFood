using Newtonsoft.Json;
using System.Net;

namespace YouAndYourFood.Models
{
    public class Address
    {
        [JsonProperty("streetAddress")]
        public string StreetAddress { get; set; }

        [JsonProperty("addressLocality")]
        public string AddressLocality { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("postalCode")]
        public string PostalCode { get; set; }
    }

    public class RestaurantsData
    {
        [JsonProperty("restaurants")]
        public Restaurant[]? Restaurants { get; set; }
    }

    public class Restaurant
    {
        [JsonProperty("id")]
        public string? Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

//        public string Image { get; set; }

        [JsonProperty("telephone")]
        public string Telephone { get; set; }

        [JsonProperty("priceRange")]
        public string PriceRange { get; set; }

        [JsonProperty("servesCuisine")]
        public string ServesCuisine { get; set; }

        [JsonProperty("address")]
        public Address Address { get; set; }

        [JsonProperty("menu")]
        public Menu Menu { get; set; }

        public int? MinWaitingTime { get; set; } = new Random().Next(0, 20);

        public int MaxWaitingTimee { get; set; } = new Random().Next(21, 60);
    }

    public class Menu
    {
        [JsonProperty("items")]
        public Item[]? Items { get; set; }
    }

    public class Item
    {
        [JsonProperty("id")]
        public string? Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

 //       public string? Image { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("price")]
        public string Price { get; set; }

        [JsonProperty("cooktimeinminutes")]
        public int Cooktimeinminutes { get; set; }

        [JsonProperty("totalOrders")]
        public int TotalOrders { get; set; } = new Random().Next(1, 25);

        public int? WaitingTime { get { return Cooktimeinminutes * TotalOrders; } set{ } }

        public int? Calories { get; set; } = new Random().Next(100, 500);
    }

}
